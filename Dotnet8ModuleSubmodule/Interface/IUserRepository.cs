using Dotnet8ModuleSubmodule.DTOs;
using Dotnet8ModuleSubmodule.Entities;

namespace Dotnet8ModuleSubmodule.Interface
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> CreateUserAsync(CreateUserDto createUserDto);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);
    }
}
