using System.Data;
using System.Diagnostics.Eventing.Reader;
using VectoVia.Models.Users;
using VectoVia.Models.Users.Model;
using VectoVia.Views;

namespace VectoVia.Models.Users.Services
{
    public class UserServices
    {
        private UsersDbContext _context;
        public UserServices(UsersDbContext context)
        {
            _context = context;
        }

        public void AddUser(UserVM user)
        {
            var _user = new User()
            {
                Emri = user.Emri,
                Mbiemri = user.Mbiemri,
                Username = user.Username,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
            };
            _context.Users.Add(_user);
            _context.SaveChanges();
        }

        public List<User> GetUsers()
        {
            var allUsers = _context.Users.ToList();
            return allUsers;
        }
        public User GetUsersByID(int UserID)
        {
            return _context.Users.FirstOrDefault(n => n.ID == UserID);
        }

        public User UpdateUserByID(int UserID, UserVM user)
        {
            var _user = _context.Users.FirstOrDefault(n => n.ID == UserID);
            if (_user != null)
            {
                _user.Emri = user.Emri;
                _user.Mbiemri = user.Mbiemri;
                _user.Username = user.Username;
                _user.Email = user.Email;
                _user.Password = user.Password;
                _user.Role = user.Role;

                _context.SaveChanges();
            }

            return _user;

        }

        public void DeleteUserByID(int UserID)
        {
            var _user = _context.Users.FirstOrDefault(n => n.ID == UserID);
            if (_user != null)
            {
                _context.Users.Remove(_user);
                _context.SaveChanges();
            }
        }

    }
}
