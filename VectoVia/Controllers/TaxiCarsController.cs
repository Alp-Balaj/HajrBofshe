using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VectoVia.Models.TaxiCars.Services;
using VectoVia.Views;

namespace VectoVia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaxiCarController : ControllerBase
    {
        public TaxiCarServices _taxiServices;


        public TaxiCarController(TaxiCarServices tcs)
        {
            _taxiServices = tcs;
        }

        [HttpGet("get-taxi-cars")]
        public IActionResult GetAllTaxiCars()
        {
            var taxiCars = _taxiServices.GetAllTaxiCars();
            return Ok(taxiCars);
        }

        [HttpGet("get-taxiCars-ByTargat/{targat}")]
        public IActionResult GetTaxiCarsByTargat(string targat)
        {
            var taxiCars = _taxiServices.GetTaxiCarsByTargat(targat);
            return Ok(taxiCars);
        }


        [HttpPost("add-taxiCar")]

        public IActionResult AddTaxiCar([FromBody] TaxiCarVM tc)
        {
            _taxiServices.addTaxiCar(tc);
            return Ok();
        }

        [HttpPut("update-taxiCar-by-Targat/{targat}")]
        public IActionResult UpdateTaxiCarByTargat(string targat, [FromBody] TaxiCarVM tc)
        {
            var updatedTaxiCar = _taxiServices.UpdateTaxiCarByTargat(targat, tc);
            return Ok(updatedTaxiCar);
        }

        [HttpDelete("delete-taxiCar-by-Targat/{targat}")]
        public IActionResult DeleteTaxiCarByTargat(string targat)
        {
            _taxiServices.DeleteTaxiCarsByTargat(targat);
            return Ok();
        }
    }
}
