using Dotnet8ModuleSubmodule.Data.Context;
using Dotnet8ModuleSubmodule.DTOs;
using Dotnet8ModuleSubmodule.Entities;
using Dotnet8ModuleSubmodule.Interface;
using Microsoft.EntityFrameworkCore;

namespace Dotnet8ModuleSubmodule.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;

        public UserRepository(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetUserByIdAsync(int id)
        {
            return await _context.Users
                         .Include(u => u.Roles) // Eager loading of roles
                             .ThenInclude(r => r.Modules)
                                .ThenInclude(m => m.ModuleSubModules)
                                    .ThenInclude(msm => msm.SubModule)
                         .FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<User> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new User
            {
                Name = createUserDto.Name,
                Username = createUserDto.Username,
                Password = createUserDto.Password,
                // You can set default values for other properties if needed.
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateUserAsync(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}
