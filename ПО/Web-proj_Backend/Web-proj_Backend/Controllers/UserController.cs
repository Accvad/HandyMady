using Microsoft.AspNetCore.Mvc;
using Web_proj_Backend.Data.Interfaces;
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
        #region GET
        [HttpGet]
        public IActionResult Get([FromQuery] int userId)
        {
            var user = _userRepository.GetById(userId);
            return Ok(new {success = true, message = user});
        }


        [HttpGet("remove")]
        public IActionResult Remove([FromQuery] int userId)
        {
            _userRepository.RemoveById(userId);
            return Ok(new {success = true, message = "success"});
        }
        [HttpGet("findWithTok")]
        public IActionResult FindWithTok([FromQuery] string token)
        {
            var user = _userRepository.GetByToken(token);
            return Ok(new { success = true, message = user});
        }
        #endregion
        #region POST

        [HttpPost("create")]
        public IActionResult Add([FromBody] Users user)
        {
            _userRepository.Add(user);
            return Ok(new { success = true, message = "success" });
        }

        #endregion
    }
}