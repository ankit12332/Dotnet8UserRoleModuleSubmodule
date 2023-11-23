namespace Dotnet8ModuleSubmodule.DTOs
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; } 
        public List<RoleDto> Roles { get; set; }
    }
}
