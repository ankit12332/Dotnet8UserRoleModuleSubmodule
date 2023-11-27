using Dotnet8ModuleSubmodule.Entities.Tagging;

namespace Dotnet8ModuleSubmodule.Entities
{
    public class SubModule
    {
        public int Id { get; set; }
        public string SubModuleName { get; set; }
        public string Description { get; set; }

        // Foreign key for Module
        public int ModuleId { get; set; }
        public virtual Module Module { get; set; }

        // Many-to-Many relationship through ModuleSubModule
        public virtual ICollection<ModuleSubModuleTagging> ModuleSubModules { get; set; }

    }
}
