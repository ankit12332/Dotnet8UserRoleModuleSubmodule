using Dotnet8ModuleSubmodule.DTOs;

namespace Dotnet8ModuleSubmodule.Interface
{
    public interface IAssignRoleToModuleRepository
    {
        Task AssignModulesToRoleAsync(ModuleRoleAssignmentDto moduleRoleAssignment);
    }
}
