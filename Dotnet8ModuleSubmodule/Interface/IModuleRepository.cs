using Dotnet8ModuleSubmodule.DTOs;

namespace Dotnet8ModuleSubmodule.Interface
{
    public interface IModuleRepository
    {
        Task<ModuleDto> GetModuleById(int id);
    }
}
