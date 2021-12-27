using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using TamroTask.Core.DTOs;
using TamroTask.Core.Interfaces;

namespace TamroTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        /// <summary>
        /// Returns list of all users
        /// </summary>
        /// <returns>List of users</returns>
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userRepository.GetUsers();

            if (!users.Any())
            {
                return NoContent();
            }

            var usersDto = users.Select(x => new UserDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
            });

            return Ok(usersDto);
        }
    }
}
