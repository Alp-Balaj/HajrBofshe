using Microsoft.AspNetCore.Mvc;
using VectoVia.Models.KompaniaTaxi;
using VectoVia.Models.KompaniaTaxi.Model;
using VectoVia.Models.KompaniaTaxi.Services;
using VectoVia.Views;


namespace VectoVia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QytetiController : ControllerBase
    {
        public QytetiServices _QytetiServices;

        public QytetiController(QytetiServices QytetiServices)
        {
            _QytetiServices = QytetiServices;
        }

        [HttpGet("get-qyteti")]
        public IActionResult GetQyteti()
        {
            var qyteti = _QytetiServices.GetQytetet();
            return Ok(qyteti);
        }

        [HttpGet("get-qytetii-id/{QytetiID}")]
        public IActionResult GetKompaniteTaxiByID(int QytetiID)
        {
            var qyteti = _QytetiServices.GetQytetiByID(QytetiID);
            return Ok(qyteti);
        }

        [HttpPost("add-qyteti")]

        public IActionResult AddQyteti([FromBody] QytetiVM qyteti)
        {
            _QytetiServices.AddQyteti(qyteti);
            return Ok();
        }

        [HttpPut("update-qyteti-by-id/{QytetiID}")]
        public IActionResult UpdateQyteti(int QytetiID, [FromBody] QytetiVM qyteti)
        {
            var updatedQyteti = _QytetiServices.UpdateQyteti(QytetiID, qyteti);
            return Ok(updatedQyteti);
        }

        [HttpDelete("delete-qyteti-by-id/{QytetiID}")]
        public IActionResult DeleteQyteti(int QytetiID)
        {
            _QytetiServices.DeleteQyteti(QytetiID);
            return Ok();
        }

    }
}
