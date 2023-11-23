using System.Text.Json.Serialization;

namespace Dotnet8ModuleSubmodule.Entities
{
    public class User
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [JsonIgnore]
        public virtual ICollection<Role> Roles { get; set; }
    }
}
