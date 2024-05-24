using VectoVia.Models.Users.Model;
using VectoVia.Views;

namespace VectoVia.Models.Users.Services
{
    public class RoleServices
    {
        private readonly UsersDbContext _context;

        public RoleServices(UsersDbContext context)
        {
            _context = context;
        }

        public void AddRole(RoleVM temp)
        {
            var _role = new Role
            {
                RoleID = temp.RoleID,
                LlojiIRolit = temp.LlojiIRolit,
            };
            _context.Roles.Add(_role);
            _context.SaveChanges(); 
        }

        public List<Role> GetRole()
        {
            var allRoles = _context.Roles.ToList();
            return allRoles;
        }
        public Role GetRoleByID(int _RoleID)
        {
            return _context.Roles.FirstOrDefault(n => n.RoleID == _RoleID);
        }

        public Role UpdateRoleByID(int _RoleID, RoleVM role)
        {
            var _role = _context.Roles.FirstOrDefault(n => n.RoleID == _RoleID);
            if (_role != null)
            {
                _role.RoleID = _RoleID;
                _role.LlojiIRolit = role.LlojiIRolit;
                

                _context.SaveChanges();
            }

            return _role;

        }

        public void DeleteRoleByID(int _RoleID)
        {
            var _roles = _context.Roles.FirstOrDefault(n => n.RoleID == _RoleID);
            if (_roles != null)
            {
                _context.Roles.Remove(_roles);
                _context.SaveChanges();
            }
        }

        public string GetRoleNameById(int roleId)
        {
            var role = _context.Roles.FirstOrDefault(r => r.RoleID == roleId);
            return role?.LlojiIRolit;
        }

    }
}
