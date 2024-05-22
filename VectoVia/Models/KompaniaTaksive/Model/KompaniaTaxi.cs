using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VectoVia.Models.KompaniaTaksive.Model
{
    public class KompaniaTaxi
    {

        [Key]
        public int CompanyID { get; set; }

        public string Kompania { get; set; }

        public string Location { get; set; }

        public string ContactInfo { get; set; }

        public string Sigurimi { get; set; }

        public int QytetiId { get; set; }

        [ForeignKey("QytetiId")]
        public Qyteti City { get; set; } // Navigation property
    }
}
