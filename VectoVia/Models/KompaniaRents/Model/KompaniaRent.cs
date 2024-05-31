    using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using vectovia.Models.PickUpLocations.Model;
using VectoVia.Models.Cars.Model;

namespace VectoVia.Models.KompaniaRents.Model
{
    public class KompaniaRent
    {
        [Key]
       
        public int CompanyID { get; set; }

        public string Kompania { get; set; }

        public string CompanyLogoUrl { get; set; }

        public string Qyteti { get; set; }

        public string ContactInfo { get; set; }

        public string Sigurimi { get; set; }


        //navigation property
        public ICollection<PickUpLocation> PickUpLocations
        {
            get; set;

        } = new List<PickUpLocation>();


        public ICollection<Car> Cars { get; set; } = new List<Car>();
    }

    
}

