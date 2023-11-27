using Dotnet8ModuleSubmodule.DTOs;

namespace Dotnet8ModuleSubmodule.Interface
{
    public interface IAssignModuleToSubModuleRepository
    {
        Task AssignSubModulesToModuleAsync(ModuleSubModuleAssignmentDto assignmentDto);
    }
}
