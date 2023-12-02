namespace Dotnet8ModuleSubmodule.DTOs
{
    public class UserLoginResponseDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Token { get; set; }
        public DateTime Expiration { get; set; }
    }
}
