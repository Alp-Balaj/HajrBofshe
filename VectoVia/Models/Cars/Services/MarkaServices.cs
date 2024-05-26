using vectovia.Views;
using VectoVia_LabCourse.Models.Cars.Model;

namespace vectovia.Models.Cars.Services
{
    public class MarkaServices
    {
        private readonly CarsDbContext _context;
        public MarkaServices(CarsDbContext context) {
        
            _context = context;
        }

        public void AddMarka (MarkaVM markaVM)
        {

            var Markat = new Marka
            {
                EmriMarkes = markaVM.EmriMarkes,
            };

            _context.Markat.Add(Markat);    

        }

        public List<Marka> GetMarkat ()
        {
            var allMarkat = _context.Markat.ToList ();

            return allMarkat;
        }

        public Marka GetMarkaByID (int id)
        {
            return _context.Markat.FirstOrDefault(n => n.MarkaId == id);
        }

        public Marka UpdateMarkaByID(int id, MarkaVM Marka)
        {
            var _Marka = _context.Markat.FirstOrDefault(m => m.MarkaId == id);
            if (_Marka != null)
            {
                _Marka.EmriMarkes = Marka.EmriMarkes;

                _context.SaveChanges ();    
            }

            return _Marka;

        }

        public void DeleteMarkaById(int id)
        {
            var _Marka = _context.Markat.FirstOrDefault(m => m.MarkaId == id);
            if (_Marka != null)
            {
                _context.Markat.Remove(_Marka);
                _context.SaveChanges ();
            }
        }

    }
}
