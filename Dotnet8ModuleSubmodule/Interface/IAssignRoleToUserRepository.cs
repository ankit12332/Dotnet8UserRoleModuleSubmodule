using Dotnet8ModuleSubmodule.DTOs;

namespace Dotnet8ModuleSubmodule.Interface
{
    public interface IAssignRoleToUserRepository
    {
        Task AssignRolesToUserAsync(RoleUserAssignmentDto roleAssignment);
    }
}
