using VectoVia.Models.KompaniaTaksive.Model;

namespace VectoVia.Models.Users.Model
{
    public class Role
    {

        public int RoleID { get; set; }

        public string LlojiIRolit { get; set; }

        public ICollection<User> Users { get; set; } // Navigation property to Users

    }
}
