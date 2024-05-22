
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VectoVia.Models.KompaniaRents.Services;
//using VectoVia.Models.KompaniaTaxi.Services;
using VectoVia.Models.Users.Services;
using VectoVia.Views;

namespace VectoVia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KompaniaRentController : ControllerBase
    {
        public KompaniaRentServices _KompaniaRentServices;

        public KompaniaRentController(KompaniaRentServices KompaniaRentServices)
        {
            _KompaniaRentServices = KompaniaRentServices;
        }

        [HttpGet("get-kompaniteRent")]
        public IActionResult GetKompaniteRent()
        {
            var kompaniaRent = _KompaniaRentServices.GetKompaniteRent();
            return Ok(kompaniaRent);
        }

        [HttpGet("get-kompaniteRent-id/{companyid}")]
        public IActionResult GetKompaniteRentByID(int companyid)
        {
            var kompaniaRent = _KompaniaRentServices.GetKompaniteRentByID(companyid);
            return Ok(kompaniaRent);
        }

        [HttpPost("add-KompaniaRent")]

        public IActionResult AddKompaniaRent([FromBody] KompaniaRentVM kompaniaRent)
        {
            _KompaniaRentServices.AddKompaniaRent(kompaniaRent);
            return Ok();
        }

        [HttpPut("update-kompaniaRent-by-id/{companyid}")]
        public IActionResult UpdateKompaniaRentByID(int companyid, [FromBody] KompaniaRentVM kompaniaRent)
        {
            var updatedKompaniaRent = _KompaniaRentServices.UpdateKompaniaRentByID(companyid, kompaniaRent);
            return Ok(updatedKompaniaRent);
        }

        [HttpDelete("delete-kompaniaRent-by-id/{companyid}")]
        public IActionResult DeleteKompaniRentByID(int companyid)
        {
            _KompaniaRentServices.DeleteKompaniRentByID(companyid);
            return Ok();
        }

    }
}
