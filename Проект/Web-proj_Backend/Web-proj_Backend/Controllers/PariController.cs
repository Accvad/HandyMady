using Microsoft.AspNetCore.Mvc;
using Web_proj_Backend.Data.Repositories;
using Web_proj_Backend.Domain;
using Web_proj_Backend.Models.Entities;

namespace Web_proj_Backend.Controllers
{
    [Route("api/[controller]")]
    public class PariController : Controller
    {
        private readonly PersonContext _personContext;
        private readonly IPariRepository _pariRepository;

        public PariController(
            IPariRepository pariRepository,
            PersonContext personContext)
        {
            _pariRepository = pariRepository;
            _personContext = personContext;
        }

        [HttpGet]
        public IActionResult Get([FromQuery] int pariId)
        {
            var pari = _pariRepository.Get(pariId);
            return Ok(new { success = true, message = pari });
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {
            var paris = _pariRepository.GetAll();
            return Ok(new {success = true, message = paris});
        }

        [HttpGet("getAllUser")]
        public IActionResult GetAllUser([FromQuery] int userId)
        {
            var paris = _pariRepository.GetAllUser(userId);
            return Ok(new { success = true, message = paris });
        }

        [HttpPost("create")]
        public IActionResult Add([FromBody] Pari pari)
        {
            if (_personContext.ApiKey == null)
            {
                return Unauthorized();
            }

            pari.UserId = _personContext.UserId;
            _pariRepository.Add(pari);
            return Ok(new {success = true, message = "Успешно добавлено"});
        }

        [HttpGet("remove")]
        public IActionResult Remove([FromQuery] int pariId)
        {
            if (_personContext.ApiKey == null)
            {
                return Unauthorized();
            }

            _pariRepository.Delete(pariId);
            return Ok(new {success = true, message = "Успешно удален"});
        }
        [HttpGet("getAllToken")]
        public IActionResult GetAllToken([FromQuery] string token)
        {
            var paris = _pariRepository.GetAllToken(token);
            return Ok(new { success = true, message = paris });
        }

    }
}