using Dotnet8ModuleSubmodule.Data.Context;
using Dotnet8ModuleSubmodule.DTOs;
using Dotnet8ModuleSubmodule.Interface;
using Microsoft.EntityFrameworkCore;

namespace Dotnet8ModuleSubmodule.Repository
{
    public class AssignRoleToModuleRepository : IAssignRoleToModuleRepository
    {
        private readonly AppDbContext _context;

        public AssignRoleToModuleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AssignModulesToRoleAsync(ModuleRoleAssignmentDto moduleRoleAssignment)
        {
            var role = await _context.Roles.Include(r => r.Modules).FirstOrDefaultAsync(r => r.Id == moduleRoleAssignment.RoleId);

            if (role == null)
            {
                throw new ArgumentException("Role not found");
            }

            // Clear existing modules or add logic to only add non-existing modules
            role.Modules.Clear();

            foreach (var moduleId in moduleRoleAssignment.ModuleIds)
            {
                var module = await _context.Modules.FindAsync(moduleId);
                if (module != null)
                {
                    role.Modules.Add(module);
                }
                else
                {
                    // Handle the case where the module doesn't exist
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
