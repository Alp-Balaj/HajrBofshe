using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using vectovia.Models.Qytet.Services;
using VectoVia.Models.KompaniaTaksive.Model;
using VectoVia.Models.Users.Services;
using VectoVia.Views;

namespace VectoVia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QytetiController : ControllerBase
    {
        public QytetServices _QytetServices;

        public QytetiController(QytetServices QytetServices)
        {
            _QytetServices = QytetServices;
        }

        [HttpPost("add-qyteti")]

        public IActionResult AddQyteti([FromBody] QytetiVM Qyteti)
        {
            _QytetServices.AddQyteti(Qyteti);
            return Ok();
        }
        [HttpGet("get-qyteti")]
        public IActionResult GetQyteti()
        {
            var users = _QytetServices.GetQyteti();
            return Ok(users);
        }

        [HttpGet("get-qyteti-id/{id}")]
        public IActionResult GetQytetiByID(int id)
        {
            var qyteti = _QytetServices.GetQytetiByID(id);
            return Ok(qyteti);
        }

        [HttpPut("update-qyteti-by-id/{QytetiId}")]
        public IActionResult UpdateQytetetByID(int QytetiId, [FromBody] QytetiVM Qyteti)
        {
            var updatedQyteti = _QytetServices.UpdateQytetetByID(QytetiId, Qyteti);
            return Ok(updatedQyteti);
        }

        [HttpDelete("delete-Qyteti-by-id/{id}")]
        public IActionResult DeleteQytetiByID(int QytetiId)
        {
            _QytetServices.DeleteQytetiByID(QytetiId);
            return Ok();
        }
    }
}