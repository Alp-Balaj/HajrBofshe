using System.ComponentModel.DataAnnotations;

namespace VectoVia.Models.Cars.Model
{
    public class Car
    {
        [Key]
        public int Tabelat { get; set; }

        public string Marka { get; set; }

        public string Modeli { get; set; }

        public string Karburanti { get; set; }

        public string Transmisioni { get; set; }

        public int VitiProdhimit { get; set; }

    }
}
