using System.ComponentModel.DataAnnotations;
using vectovia.Models.PickUpLocations.Model;

namespace VectoVia.Models.KompaniaRents.Model
{
    public class KompaniaRent
    {

        [Key]
        public int CompanyID { get; set; }

        public string Kompania { get; set; }

        public string PickUpLocation { get; set; }

        public string Qyteti { get; set; }

        public string ContactInfo { get; set; }

        public string Sigurimi { get; set; }

        public ICollection<PickUpLocation> PickUpLocations
        {
            get; set;

        }
    }
}

