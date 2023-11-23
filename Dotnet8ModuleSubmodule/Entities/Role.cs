using System.Text.Json.Serialization;

namespace Dotnet8ModuleSubmodule.Entities
{
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
            this.Modules = new HashSet<Module>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        // Implicit Many-to-Many Relationship
        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
        // Implicit Many-to-Many Relationship
        public virtual ICollection<Module> Modules { get; set; }
    }
}
