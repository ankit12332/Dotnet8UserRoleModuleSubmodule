namespace Dotnet8ModuleSubmodule.Entities
{
    public class Module
    {
        public Module()
        {
            this.Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string ModuleName { get; set; }
        public string Description { get; set; }

        // Implicit Many-to-Many Relationship
        public virtual ICollection<Role> Roles { get; set; }
    }
}
