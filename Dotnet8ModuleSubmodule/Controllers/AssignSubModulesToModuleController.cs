using Dotnet8ModuleSubmodule.DTOs;
using Dotnet8ModuleSubmodule.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet8ModuleSubmodule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssignSubModulesToModuleController : ControllerBase
    {
        private readonly IAssignModuleToSubModuleRepository _repository;

        public AssignSubModulesToModuleController(IAssignModuleToSubModuleRepository repository)
        {
            _repository = repository;
        }

        [HttpPost("AssignSubModules")]
        public async Task<IActionResult> AssignSubModulesToModule([FromBody] ModuleSubModuleAssignmentDto assignmentDto)
        {
            try
            {
                await _repository.AssignSubModulesToModuleAsync(assignmentDto);
                return Ok("Submodules assigned to Modules successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
