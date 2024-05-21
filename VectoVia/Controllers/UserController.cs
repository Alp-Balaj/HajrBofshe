using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using VectoVia.Models.Users.Services;
using VectoVia.Views;

namespace VectoVia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserServices _userService;

        public UserController(UserServices userServices)
        {
            _userService = userServices;
        }

        [HttpGet("get-users")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("get-users-id/{id}")]
        public IActionResult GetUsersByID(int id)
        {
            var user = _userService.GetUsersByID(id);
            return Ok(user);
        }


        [HttpPost("add-user")]

        public IActionResult AddUser([FromBody] UserVM user)
        {
            _userService.AddUser(user);
            return Ok();
        }

        [HttpPut("update-user-by-id/{id}")]
        public IActionResult UpdateUserByID(int id, [FromBody] UserVM user)
        {
            var updatedUser = _userService.UpdateUserByID(id, user);
            return Ok(updatedUser);
        }

        [HttpDelete("delete-user-by-id/{id}")]
        public IActionResult DeleteUserByID(int id)
        {
            _userService.DeleteUserByID(id);
            return Ok();
        }
    }
}
