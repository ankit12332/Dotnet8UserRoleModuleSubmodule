using System.Text.Json.Serialization;

namespace Dotnet8ModuleSubmodule.Entities
{
    public class Role
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string RoleName { get; set; }
        public string Description { get; set; }

        [JsonIgnore]
        public virtual ICollection<User> Users { get; set; }
    }
}
