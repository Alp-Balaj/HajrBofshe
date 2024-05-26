using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using vectovia.Views;
using VectoVia.Models.Users.Services;
using VectoVia.Views;

namespace VectoVia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserServices _userService;
        private readonly JwtService _jwtService;
        private readonly RoleServices _roleService;

        public UserController(UserServices userServices, JwtService jwtService, RoleServices roleService) 
        {
            _userService = userServices;
            _jwtService = jwtService;
            _roleService = roleService; 
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



        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginVM loginData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = _userService.VerifyUserLogin(loginData.Username, loginData.Password);

            if (user == null)
            {
                return Unauthorized(new { error = "Invalid username or password" });
            }

            var roleName = _roleService.GetRoleNameById(user.RoleID); //gets role name

            // JWT
            var token = _jwtService.GenerateToken(user.Username, roleName);

            // Return token
            return Ok(new { token });
        }



        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterVM registerData)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _userService.RegisterUser(registerData);

            if (result.Success)
            {
                return Ok(new { message = result.Message });
            }
            else
            {
                return Conflict(new { message = result.Message });
            }
        }

    }
}
