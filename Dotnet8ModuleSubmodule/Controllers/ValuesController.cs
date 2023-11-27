using Dotnet8ModuleSubmodule.DTOs;
using Dotnet8ModuleSubmodule.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet8ModuleSubmodule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModulesController : ControllerBase
    {
        private readonly IModuleRepository _moduleRepository;

        public ModulesController(IModuleRepository moduleRepository)
        {
            _moduleRepository = moduleRepository;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ModuleDto>> GetModule(int id)
        {
            var module = await _moduleRepository.GetModuleById(id);

            if (module == null)
            {
                return NotFound();
            }

            return Ok(module);
        }
    }
}
