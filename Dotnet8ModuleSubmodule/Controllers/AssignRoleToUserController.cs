using Dotnet8ModuleSubmodule.DTOs;
using Dotnet8ModuleSubmodule.Interface;
using Dotnet8ModuleSubmodule.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet8ModuleSubmodule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignRoleToUserController : ControllerBase
    {
        private readonly IAssignRoleToUserRepository _assignRoleRepository;

        public AssignRoleToUserController(IAssignRoleToUserRepository assignRoleRepository)
        {
            _assignRoleRepository = assignRoleRepository;
        }

        [HttpPost("AssignRoles")]
        public async Task<IActionResult> AssignRolesToUser(RoleUserAssignmentDto roleAssignmentDto)
        {
            try
            {
                await _assignRoleRepository.AssignRolesToUserAsync(roleAssignmentDto);
                return Ok("Roles assigned to user successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch
            {
                // Handle other potential exceptions
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
