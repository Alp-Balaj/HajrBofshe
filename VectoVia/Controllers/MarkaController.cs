using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using vectovia.Models.Cars.Services;
using vectovia.Views;
using VectoVia.Models.Cars.Services;
using VectoVia.Views;

namespace VectoVia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarkaController : ControllerBase
    {
        public MarkaServices _MarkaService;

        public MarkaController(MarkaServices MarkaServices)
        {
            _MarkaService = MarkaServices;
        }

        [HttpGet("get-Marka")]
        public IActionResult GetMarkat()
        {
            var Marka = _MarkaService.GetMarkat();
            return Ok(Marka);
        }

        [HttpGet("get-Marka-id/{id}")]
        public IActionResult GetMarkaByID(int id)
        {
            var Marka = _MarkaService.GetMarkaByID(id);
            return Ok(Marka);
        }


        [HttpPost("add-Marka")]

        public IActionResult AddMarka([FromBody] MarkaVM Marka)
        {
            _MarkaService.AddMarka(Marka);
            return Ok();
        }

        [HttpPut("update-Marka-by-id/{id}")]
        public IActionResult UpdateMarkaByID(int id, [FromBody] MarkaVM Marka)
        {
            var UpdateMarkaByID = _MarkaService.UpdateMarkaByID(id, Marka);
            return Ok(UpdateMarkaByID);
        }

        [HttpDelete("delete-Marka-by-id/{id}")]
        public IActionResult DeleteMarkaById(int id)
        {
            _MarkaService.DeleteMarkaById(id);
            return Ok();
        }
    }
}
