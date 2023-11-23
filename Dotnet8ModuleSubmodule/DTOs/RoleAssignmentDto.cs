namespace Dotnet8ModuleSubmodule.DTOs
{
    public class RoleAssignmentDto
    {
        public int UserId { get; set; }
        public List<int> RoleIds { get; set; } // List of Role IDs to assign
    }
}
