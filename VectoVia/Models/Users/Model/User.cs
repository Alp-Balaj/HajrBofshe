using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;

namespace VectoVia.Models.Users.Model
{
    public class User
    {
        public int ID { get; set; }

        public string Emri { get; set; }

        public string Mbiemri { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int RoleID { get; set; }

        [ForeignKey("RoleID")]
        public Role Role { get; set; } // Navigation property

    }
}
