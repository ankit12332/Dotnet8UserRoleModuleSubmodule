using Dotnet8ModuleSubmodule.DTOs;

namespace Dotnet8ModuleSubmodule.Interface
{
    public interface IAssignRoleRepository
    {
        Task AssignRolesToUserAsync(RoleAssignmentDto roleAssignment);
    }
}
