using Microsoft.AspNetCore.Mvc;
using Web_proj_Backend.Data.Repositories;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int userId)
        {
            var user = _userRepository.Get(userId);
            return Ok(new {success = true, message = user});
        }

        [HttpPost("create")]
        public IActionResult Add([FromBody] User user)
        {
            _userRepository.Add(user);
            return Ok(new {success = true, message = "success"});
        }

        [HttpGet("remove")]
        public IActionResult Remove([FromQuery] int userId)
        {
            _userRepository.Remove(userId);
            return Ok(new {success = true, message = "success"});
        }
        [HttpGet("findWithTok")]
        public IActionResult FindWithTok([FromQuery] string token)
        {
            var user = _userRepository.GetWithTok(token);
            return Ok(new { success = true, message = user});
        }

    }
}