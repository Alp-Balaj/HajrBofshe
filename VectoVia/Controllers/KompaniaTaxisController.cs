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

    }
}