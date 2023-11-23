using Dotnet8ModuleSubmodule.Data.Context;
using Dotnet8ModuleSubmodule.DTOs;
using Dotnet8ModuleSubmodule.Interface;
using Microsoft.EntityFrameworkCore;

namespace Dotnet8ModuleSubmodule.Repository
{
    public class AssignRoleRepository : IAssignRoleRepository
    {
        private readonly AppDbContext _context;

        public AssignRoleRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task AssignRolesToUserAsync(RoleAssignmentDto roleAssignment)
        {
            var user = await _context.Users.Include(u => u.Roles).FirstOrDefaultAsync(u => u.Id == roleAssignment.UserId);

            if (user == null)
            {
                throw new ArgumentException("User not found");
            }

            // Clear existing roles or add logic to only add non-existing roles
            user.Roles.Clear();

            foreach (var roleId in roleAssignment.RoleIds)
            {
                var role = await _context.Roles.FindAsync(roleId);
                if (role != null)
                {
                    user.Roles.Add(role);
                }
                else
                {
                    // Handle the case where the role doesn't exist
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
