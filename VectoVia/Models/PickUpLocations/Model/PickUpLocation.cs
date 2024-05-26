using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VectoVia.Models.KompaniaRents.Model;

namespace vectovia.Models.PickUpLocations.Model
{
    public class PickUpLocation
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PickUpLocationID { get; set; }

        public string locationName { get; set; }

        public string Address { get; set; }

        public string city { get; set; }

        public string ZipCode { get; set; }

        public int? CompanyID { get; set; }


        //navigation property
        public KompaniaRent RentCompany { get; set; }
    }
}
