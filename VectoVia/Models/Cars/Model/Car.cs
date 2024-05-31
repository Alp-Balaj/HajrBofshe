using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VectoVia.Models.KompaniaRents.Model;
using VectoVia_LabCourse.Models.Cars.Model;

namespace VectoVia.Models.Cars.Model
{
    public class Car
    {
        [Key]
        public int Tabelat { get; set; }

        public int MarkaID { get; set; }
        [ForeignKey("MarkaID")]

        public Marka Marka { get; set; }

        public String CarUrl { get; set; }

        public string Modeli { get; set; }

        public string Karburanti { get; set; }

        public string Transmisioni { get; set; }

        public int VitiProdhimit { get; set; }

        // Foreign key for KompaniaRent
        public int? CompanyID { get; set; }

        // Navigation property
        [ForeignKey("CompanyID")]
        public KompaniaRent KompaniaRent { get; set; }
    }

}

