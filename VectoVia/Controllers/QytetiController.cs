using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VectoVia.Models.KompaniaTaksive.Services;
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

    }
}