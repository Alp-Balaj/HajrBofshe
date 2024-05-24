using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VectoVia.Models.KompaniaTaksive.Model;

namespace VectoVia.Models.Users.Model
{
    public class Role
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RoleID { get; set; }

        public string LlojiIRolit { get; set; }

        public ICollection<User> Users { get; set; } // Navigation property to Users

    }
}
