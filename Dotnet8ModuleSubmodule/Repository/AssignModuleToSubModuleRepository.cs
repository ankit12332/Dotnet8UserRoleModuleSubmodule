using Dotnet8ModuleSubmodule.Data.Context;
using Dotnet8ModuleSubmodule.DTOs;
using Dotnet8ModuleSubmodule.Entities;
using Dotnet8ModuleSubmodule.Entities.Tagging;
using Dotnet8ModuleSubmodule.Interface;
using Microsoft.EntityFrameworkCore;

namespace Dotnet8ModuleSubmodule.Repository
{
    public class AssignModuleToSubModuleRepository : IAssignModuleToSubModuleRepository
    {
        private readonly AppDbContext _context;

        public AssignModuleToSubModuleRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AssignSubModulesToModuleAsync(ModuleSubModuleAssignmentDto assignmentDto)
        {
            var module = await _context.Modules.Include(m => m.ModuleSubModules)
                                       .FirstOrDefaultAsync(m => m.Id == assignmentDto.ModuleId);

            if (module == null)
            {
                throw new ArgumentException("Module not found");
            }

            // First, remove existing taggings to avoid duplicates
            var existingTaggings = module.ModuleSubModules.ToList();
            foreach (var existingTagging in existingTaggings)
            {
                _context.ModuleSubModuleTaggings.Remove(existingTagging);
            }

            // Adding new taggings
            foreach (var subModuleId in assignmentDto.SubModuleIds.Distinct())
            {
                var subModule = await _context.SubModules.FindAsync(subModuleId);
                if (subModule != null)
                {
                    var newTagging = new ModuleSubModuleTagging
                    {
                        SubModuleId = subModule.Id,
                        ModuleId = module.Id,
                    };
                    _context.ModuleSubModuleTaggings.Add(newTagging);
                }
                else
                {
                    // Handle the case where the submodule doesn't exist
                }
            }

            await _context.SaveChangesAsync();
        }
    }
}
