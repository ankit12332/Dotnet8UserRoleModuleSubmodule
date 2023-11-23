using Dotnet8ModuleSubmodule.DTOs;

namespace Dotnet8ModuleSubmodule.Interface
{
    public interface IAuthRepository
    {
        Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto);
    }
}
