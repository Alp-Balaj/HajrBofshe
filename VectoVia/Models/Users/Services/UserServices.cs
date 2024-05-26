using vectovia.Models.Users.Services;
using vectovia.Views;
using VectoVia.Models.Users.Model;
using VectoVia.Views;


namespace VectoVia.Models.Users.Services
{
    public class UserServices
    {
        private UsersDbContext _context;
        private RoleServices _roleServices;
        

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
                RoleID = user.RoleID,
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
                _user.RoleID = user.RoleID;

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

        

        public User VerifyUserLogin(string username, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }

        public RegistrationResults RegisterUser(RegisterVM registerData)
        {
            // Check if username or email already exists
            bool usernameExists = _context.Users.Any(u => u.Username == registerData.Username);
            bool emailExists = _context.Users.Any(u => u.Email == registerData.Email);

            if (usernameExists)
            {
                return new RegistrationResults
                {
                    Success = false,
                    Message = "Username already exists. Please choose a different username."
                };
            }

            if (emailExists)
            {
                return new RegistrationResults
                {
                    Success = false,
                    Message = "Email already exists. Please use a different email address."
                };
            }

            int defaultRoleId = 1; // Set the default role ID here

            // Check if any users exist in the database
            bool isFirstUser = !_context.Users.Any();

            // If it's the first user, assign admin role (role ID = 0), otherwise assign default role
            int roleId = isFirstUser ? 0 : defaultRoleId;

            bool roleExists = _context.Roles.FirstOrDefault(r => r.RoleID == roleId) != null;

            if (!roleExists)
            {
                roleId = defaultRoleId; // This ensures a role is assigned if it was missing
                //MessageBox.Show("The role you were trying to give doesn't exists.");
            }

            var user = new User
            {
                Emri = registerData.Emri,
                Mbiemri = registerData.Mbiemri,
                Username = registerData.Username,
                Email = registerData.Email,
                Password = registerData.Password,
                RoleID = roleId
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return new RegistrationResults
            {
                Success = true,
                Message = "User registered successfully."
            };
        }

    }
}

