using Dotnet8ModuleSubmodule.DTOs;
using Dotnet8ModuleSubmodule.Entities;
using Dotnet8ModuleSubmodule.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Dotnet8ModuleSubmodule.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // GET: api/User
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return Ok(await _userRepository.GetAllUsersAsync());
        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            var userDto = new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Username = user.Username,
                // Map other properties...
                Roles = user.Roles.Select(r => new RoleDto
                {
                    Id = r.Id,
                    RoleName = r.RoleName
                    // Map other role properties...
                }).ToList()
            };

            return Ok(userDto);
        }


        // POST: api/User
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(CreateUserDto userDto)
        {
            var user = await _userRepository.CreateUserAsync(userDto);
            return CreatedAtAction("GetUser", new { id = user.Id }, user); // Adjust according to your API design
        }


        // PUT: api/User/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            try
            {
                await _userRepository.UpdateUserAsync(user);
            }
            catch
            {
                // Add logic to handle if user doesn't exist
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            await _userRepository.DeleteUserAsync(id);

            return NoContent();
        }
    }
}
