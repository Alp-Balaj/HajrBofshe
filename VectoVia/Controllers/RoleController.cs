using Microsoft.AspNetCore.Mvc;
using VectoVia.Models.Users.Services;
using VectoVia.Views;

namespace VectoVia.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        public RoleServices _RoleServices;

        public RoleController(RoleServices RoleServices)
        {
            _RoleServices = RoleServices;
        }

        

        [HttpGet("get-role")]
        public IActionResult GetRole()
        {
            var roles = _RoleServices.GetRole();
            return Ok(roles);
        }

        [HttpGet("get-role-id/{id}")]
        public IActionResult GetRoleByID(int id)
        {
            var role = _RoleServices.GetRoleByID(id);
            return Ok(role);
        }

        [HttpPost("add-role")]
        public IActionResult AddRole([FromBody] RoleVM Role)
        {
            _RoleServices.AddRole(Role);
            return Ok();
        }

        [HttpPut("update-role-by-id/{id}")]
        public IActionResult UpdateRoleByID(int id, [FromBody] RoleVM role)
        {
            var updatedRole = _RoleServices.UpdateRoleByID(id, role);
            return Ok(updatedRole);
        }

        [HttpDelete("delete-role-by-id/{id}")]
        public IActionResult DeleteRoleByID(int id)
        {
            _RoleServices.DeleteRoleByID(id);
            return Ok();
        }


    }

}