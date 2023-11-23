using Dotnet8ModuleSubmodule.DTOs;
using Dotnet8ModuleSubmodule.Interface;
using Dotnet8ModuleSubmodule.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet8ModuleSubmodule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignModulesToRoleController : ControllerBase
    {
        private readonly IAssignRoleToModuleRepository _roleModuleRepository;

        public AssignModulesToRoleController(IAssignRoleToModuleRepository roleModuleRepository)
        {
            _roleModuleRepository = roleModuleRepository;
        }

        [HttpPost("AssignModules")]
        public async Task<IActionResult> AssignModulesToRole([FromBody] ModuleRoleAssignmentDto moduleRoleAssignment)
        {
            try
            {
                await _roleModuleRepository.AssignModulesToRoleAsync(moduleRoleAssignment);
                return Ok("Modules assigned to role successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
