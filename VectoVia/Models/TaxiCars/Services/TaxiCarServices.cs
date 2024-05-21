using VectoVia.Models.TaxiCars.Model;
using VectoVia.Views;

namespace VectoVia.Models.TaxiCars.Services

{
    public class TaxiCarServices
    {

        private TaxiCarsDbContext _context;

        public TaxiCarServices(TaxiCarsDbContext context)
        {
            _context = context;
        }

        public void addTaxiCar(TaxiCarVM tx)
        {
            var _taxiCar = new TaxiCar()
            {
                Targat = tx.Targat,

                TaxiID = tx.TaxiID,

                nrPassenger = tx.nrPassenger,

                hapesiraNeBagazh = tx.hapesiraNeBagazh,

                llojiVetures = tx.llojiVetures,

                llojiKarburantit = tx.llojiKarburantit,

                iDisponueshem = tx.iDisponueshem,
            };

            _context.TaxiCars.Add(_taxiCar);
            _context.SaveChanges();


        }

        public List<TaxiCar> GetAllTaxiCars()
        {
            var allTaxiCars = _context.TaxiCars.ToList();
            return allTaxiCars;
        }

        public TaxiCar GetTaxiCarsByTargat(string i)
        {
            return _context.TaxiCars.FirstOrDefault(n => n.Targat.Equals(i));
        }

        public TaxiCar UpdateTaxiCarByTargat(string Targat, TaxiCarVM Car)
        {
            var _taxiCar = _context.TaxiCars.FirstOrDefault(n => n.Targat.Equals(Targat));
            if (_taxiCar != null)
            {
                _taxiCar.TaxiID = Car.TaxiID;
                _taxiCar.nrPassenger = Car.nrPassenger;
                _taxiCar.hapesiraNeBagazh = Car.hapesiraNeBagazh;
                _taxiCar.llojiVetures = Car.llojiVetures;
                _taxiCar.llojiKarburantit = Car.llojiKarburantit;
                _taxiCar.iDisponueshem = Car.iDisponueshem;

                _context.SaveChanges();
            }

            return _taxiCar;
        }


        public void DeleteTaxiCarsByTargat(string i)
        {
            var _taxiCar = _context.TaxiCars.FirstOrDefault(n => n.Targat.Equals(i));
            if (_taxiCar != null)
            {
                _context.TaxiCars.Remove(_taxiCar);
                _context.SaveChanges();
            }
        }


    }
}
