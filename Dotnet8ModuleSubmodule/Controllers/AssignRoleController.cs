using Dotnet8ModuleSubmodule.DTOs;
using Dotnet8ModuleSubmodule.Interface;
using Dotnet8ModuleSubmodule.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet8ModuleSubmodule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignRoleController : ControllerBase
    {
        private readonly IAssignRoleRepository _assignRoleRepository;

        public AssignRoleController(IAssignRoleRepository assignRoleRepository)
        {
            _assignRoleRepository = assignRoleRepository;
        }

        [HttpPost("AssignRoles")]
        public async Task<IActionResult> AssignRolesToUser(RoleAssignmentDto roleAssignmentDto)
        {
            try
            {
                await _assignRoleRepository.AssignRolesToUserAsync(roleAssignmentDto);
                return Ok();
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
