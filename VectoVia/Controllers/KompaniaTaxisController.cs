using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VectoVia.Models.KompaniaRents.Services;
using VectoVia.Models.KompaniaTaksive.Services;
using VectoVia.Models.Users.Services;
using VectoVia.Views;

namespace VectoVia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KompaniaTaxisController : ControllerBase
    {
        public KompaniaTaxiServices _KompaniaTaxiServices;

        public KompaniaTaxisController(KompaniaTaxiServices KompaniaTaxiServices)
        {
            _KompaniaTaxiServices = KompaniaTaxiServices;
        }

        [HttpGet("get-kompaniteTaxi")]
        public IActionResult GetKompaniteTaxi()
        {
            var kompaniataxi = _KompaniaTaxiServices.GetKompaniteTaxive();
            return Ok(kompaniataxi);
        }

        [HttpGet("get-kompaniteTaxi-id/{companyid}")]
        public IActionResult GetKompaniteTaxiByID(int companyid)
        {
            var kompaniataxi = _KompaniaTaxiServices.GetKompaniteTaxiveByID(companyid);
            return Ok(kompaniataxi);
        }

        [HttpPost("add-KompaniaTaxi")]

        public IActionResult AddKompaniaTaxi([FromBody] KompaniaTaxiVM kompaniaTaxi)
        {
            _KompaniaTaxiServices.AddKompaniaTaxi(kompaniaTaxi);
            return Ok();
        }
        [HttpPut("update-KompaniaTaxi-by-id/{Companyid}")]
        public IActionResult UpdateKompaniaTaxiByID(int Companyid, [FromBody] KompaniaTaxiVM kompaniaTaxi)
        {
            var updatedKompaniaTaxi = _KompaniaTaxiServices.UpdateKompaniaTaxiByID(Companyid, kompaniaTaxi);
            return Ok(updatedKompaniaTaxi);
        }

        [HttpDelete("delete-kompaniaTaxi-by-id/{Companyid}")]
        public IActionResult DeleteKompaniTaxiByID(int Companyid)
        {
            _KompaniaTaxiServices.DeleteKompaniaTaxiByID(Companyid);
            return Ok();
        }

    }
}

