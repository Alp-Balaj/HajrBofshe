
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using vectovia.Models.PickUpLocations.Services;
using vectovia.Views;
using VectoVia.Models.KompaniaRents.Services;
//using VectoVia.Models.KompaniaTaxi.Services;
using VectoVia.Models.Users.Services;
using VectoVia.Views;

namespace VectoVia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickUpLocationController : ControllerBase
    {
        public PickUpLocationServices _PickUpLocationService;

        public PickUpLocationController(PickUpLocationServices p)
        {
            _PickUpLocationService = p;
        }

        [HttpGet("get-pickUpLocation")]
        public IActionResult GetPickUpLocations()
        {
            var pickUpLocation = _PickUpLocationService.GetPickUpLocations();
            return Ok(pickUpLocation);
        }

        [HttpGet("get-pickUpLocation-id/{id}")]
        public IActionResult GetPickUpLocationsByID(int id)
        {
            var pickUpLocation = _PickUpLocationService.GetPickUpLocationsByID(id);
            return Ok(pickUpLocation);
        }

        [HttpPost("add-PickUpLocation")]

        public IActionResult addPickUpLocation([FromBody] PickUpLocationVM pickUpLocation)
        {
            _PickUpLocationService.addPickUpLocation(pickUpLocation);
            return Ok();
        }

        [HttpPut("update-PickUpLocation-by-id/{id}")]
        public IActionResult UpdatePickUpLocationByID(int id, [FromBody] PickUpLocationVM pickUpLocation)
        {
            var updatedPickUpLocation = _PickUpLocationService.UpdatePickUpLocationByID(id, pickUpLocation);
            return Ok(updatedPickUpLocation);
        }

        [HttpDelete("delete-PickUpLocation-by-id/{id}")]
        public IActionResult DeletePickUpLocationByID(int id)
        {
            _PickUpLocationService.DeletePickUpLocationByID(id);
            return Ok();
        }

    }
}
