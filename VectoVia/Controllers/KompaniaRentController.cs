using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VectoVia.Models.KompaniaRents.Services;
using VectoVia.Views;

namespace VectoVia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KompaniaRentController : ControllerBase
    {
        private readonly KompaniaRentServices _kompaniaRentServices;

        public KompaniaRentController(KompaniaRentServices kompaniaRentServices)
        {
            _kompaniaRentServices = kompaniaRentServices;
        }

        [HttpGet("get-kompaniteRent")]
        public IActionResult GetKompaniteRent()
        {
            var kompaniaRentWithPickUpLocations = _kompaniaRentServices.GetKompaniteRentWithPickUpLocations();
            return Ok(kompaniaRentWithPickUpLocations);
        }

        [HttpGet("get-all-cars")]
        public IActionResult GetAllCars()
        {
            var cars = _kompaniaRentServices.GetAllCars();
            return Ok(cars);
        }

        [HttpGet("get-all-cars-by-companyID/{companyID}")]
        public IActionResult GetAllCarsByCompanyID(int companyID)
        {
            var cars = _kompaniaRentServices.GetAllCarsByCompanyID(companyID);
            if (cars == null || !cars.Any())
            {
                return NotFound(new { message = "No cars found for this company" });
            }
            return Ok(cars);
        }

        [HttpPost("add-KompaniaRent")]
        public IActionResult AddKompaniaRent([FromBody] KompaniaRentVM kompaniaRent)
        {
            _kompaniaRentServices.AddKompaniaRent(kompaniaRent);
            return Ok(new { message = "KompaniaRent added successfully" });
        }

        [HttpPut("update-kompaniaRent-by-id/{companyid}")]
        public IActionResult UpdateKompaniaRentByID(int companyid, [FromBody] KompaniaRentVM kompaniaRent)
        {
            var updatedKompaniaRent = _kompaniaRentServices.UpdateKompaniaRentByID(companyid, kompaniaRent);
            if (updatedKompaniaRent == null)
            {
                return NotFound(new { message = "KompaniaRent not found" });
            }
            return Ok(new { message = "KompaniaRent updated successfully", data = updatedKompaniaRent });
        }

        [HttpDelete("delete-kompaniaRent-by-id/{companyID}")]
        public IActionResult DeleteKompaniRentByID(int companyID)
        {
            var deletedKompaniaRent = _kompaniaRentServices.DeleteKompaniaRentByID(companyID);
            if (deletedKompaniaRent == null)
            {
                return NotFound(new { message = "KompaniaRent not found" });
            }
            return Ok(new { message = "KompaniaRent deleted successfully" });
        }
    }
}