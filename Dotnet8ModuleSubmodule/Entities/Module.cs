using Dotnet8ModuleSubmodule.Entities.Tagging;

namespace Dotnet8ModuleSubmodule.Entities
{
    public class Module
    {
        public Module()
        {
            this.Roles = new HashSet<Role>();
            this.SubModules = new HashSet<SubModule>();
        }

        public int Id { get; set; }
        public string ModuleName { get; set; }
        public string Description { get; set; }

        // Implicit Many-to-Many Relationship
        public virtual ICollection<Role> Roles { get; set; }

        // One-to-many relationship
        public virtual ICollection<SubModule> SubModules { get; set; }

        // Many-to-Many relationship through ModuleSubModule
        public virtual ICollection<ModuleSubModuleTagging> ModuleSubModules { get; set; }
    }
}
