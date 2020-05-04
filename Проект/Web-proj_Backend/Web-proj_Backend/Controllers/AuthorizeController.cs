using Microsoft.AspNetCore.Mvc;
using Web_proj_Backend.Data;
using Web_proj_Backend.Data.Repositories;
using Web_proj_Backend.Domain;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Controllers
{
    [Route("api/[controller]")]
    public class AzuthorizeController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly DataContext _context;

        public AzuthorizeController(
            IUserRepository userRepository,
            DataContext context)
        {
            _userRepository = userRepository;
            _context = context;
        }

        [HttpPost("registration")]
        public IActionResult Registration([FromBody] User userVm)
        {
            if (userVm.Login == "" && userVm.Password == "" && userVm.Username == "")
            {
                return Ok(new {success = false, message = "Недопустимый формат"});
            }

            var user = new User
            {
                Login = userVm.Login,
                Username = userVm.Username,
                //Password = Crypt.GenerateHashPassword(userVm.Password)
                Password = userVm.Password
            };
            _userRepository.Add(user);
            return Ok(new {success = true, message = "Готово"});
        }

        [HttpPost("authorize")]
        public IActionResult Authorize([FromBody] User userVm)
        {
            var user = _userRepository.Get(userVm.Login);
            if (userVm == null || user == null)
            {
                return Ok(new {success = false, message = "что то не так"});
            }

            //if (user.Password != Crypt.GenerateHashPassword(userVm.Password))
            if (user.Password != userVm.Password)

            {
                return Ok(new {success = false, message = "что то не так"});
            }

            user.Token = Crypt.GenerateToken(user.Login);
            _context.SaveChanges();
            return Ok(new {success = true, message = user.Token});
        }

        [HttpGet("deanonId")]
        public IActionResult DeAnonId([FromQuery]int userId)
        {
            var user = _userRepository.Get(userId);
            user.Token = null;
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("deanonToken")]
        public IActionResult DeAnonToken([FromQuery]string token)
        {
            var user = _userRepository.GetWithTok(token);
            user.Token = null;
            _context.SaveChanges();
            return Ok();
        }
        [HttpGet("aaa")]
        public IActionResult PosholNahuy([FromQuery]int qqq)
        {
            if(qqq == 7)
            {
                return Ok(new { success = "KRASAVA" });
            }
            return Ok(new { success = "TI CHO NAHUY" });
        }
    }
}