using VectoVia.Models.Cars.Model;

namespace VectoVia_LabCourse.Models.Cars.Model
{
    public class Marka
    {
        public int MarkaId { get; set; }

        public string EmriMarkes { get; set; }

        public ICollection <Car> Cars { get; set; }
    }

}
