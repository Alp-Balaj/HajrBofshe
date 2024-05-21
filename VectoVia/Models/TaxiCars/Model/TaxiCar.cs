using System.ComponentModel.DataAnnotations;

namespace VectoVia.Models.TaxiCars.Model
{
    public class TaxiCar
    {
        [Key]
        public string Targat { get; set; }

        public int TaxiID { get; set; }

        public int nrPassenger { get; set; }

        public int hapesiraNeBagazh { get; set; }

        public string llojiVetures { get; set; }

        public string llojiKarburantit { get; set; }

        public Boolean iDisponueshem { get; set; }



    }
}
