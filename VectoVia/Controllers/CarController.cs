using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VectoVia.Models.Cars.Services;
using VectoVia.Views;

namespace VectoVia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        public CarServices _CarService;

        public CarController(CarServices CarServices)
        {
            _CarService = CarServices;
        }

        [HttpGet("get-Cars")]
        public IActionResult GetCars()
        {
            var Cars = _CarService.GetCars();
            return Ok(Cars);
        }

        [HttpGet("get-Cars-id/{id}")]
        public IActionResult GetCarsByID(int id)
        {
            var Car = _CarService.GetCarsByID(id);
            return Ok(Car);
        }


        [HttpPost("add-Car")]

        public IActionResult AddCar([FromBody] CarVM Car)
        {
            _CarService.AddCar(Car);
            return Ok();
        }

        [HttpPut("update-Car-by-id/{id}")]
        public IActionResult UpdateCarByID(int id, [FromBody] CarVM Car)
        {
            var updatedCar = _CarService.UpdateCarByID(id, Car);
            return Ok(updatedCar);
        }

        [HttpDelete("delete-Car-by-id/{id}")]
        public IActionResult DeleteCarByID(int id)
        {
            _CarService.DeleteCarByID(id);
            return Ok();
        }
    }
}

