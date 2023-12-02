using Dotnet8ModuleSubmodule.Data.Context;
using Dotnet8ModuleSubmodule.DTOs;
using Dotnet8ModuleSubmodule.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dotnet8ModuleSubmodule.Repository
{
    public class AuthRepository : IAuthRepository
    {
        private readonly IConfiguration _configuration;
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthRepository(IConfiguration configuration, AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto)
        {
            // Check if user exists
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Username == userLoginDto.Username);

            if (user == null)
            {
                // User does not exist
                throw new UnauthorizedAccessException("Username does not exist");
            }

            if (user.Password != userLoginDto.Password)
            {
                // Password is incorrect
                throw new UnauthorizedAccessException("Password is invalid");
            }

            // Token generation logic
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Token"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userLoginDto.Username)
                    // Add other claims as needed
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // Set token and expiration in cookies
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true, // Secure flag may be set based on your requirement
                Expires = token.ValidTo
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append("AuthToken", tokenString, cookieOptions);
            _httpContextAccessor.HttpContext.Response.Cookies.Append("AuthExpiration", token.ValidTo.ToString(), cookieOptions);

            return new UserLoginResponseDto
            {
                UserId= user.Id,
                Name = user.Name,
                Token = tokenString,
                Expiration = token.ValidTo
            };
        }
    }
}
