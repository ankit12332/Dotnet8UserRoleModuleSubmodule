using Dotnet8ModuleSubmodule.Data.Context;
using Dotnet8ModuleSubmodule.DTOs;
using Dotnet8ModuleSubmodule.Interface;
using Microsoft.EntityFrameworkCore;

namespace Dotnet8ModuleSubmodule.Repository
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly AppDbContext _context;
        public ModuleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ModuleDto> GetModuleById(int id)
        {
            var module = await _context.Modules
                .Include(m => m.SubModules)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (module == null)
            {
                return null;
            }

            return new ModuleDto
            {
                Id = module.Id,
                Name = module.ModuleName,
                Description = module.Description,
                SubModules = module.SubModules.Select(sm => new SubModuleDto
                {
                    Id = sm.Id,
                    Name = sm.SubModuleName,
                    Description = sm.Description
                }).ToList()
            };
        }
    }
}
