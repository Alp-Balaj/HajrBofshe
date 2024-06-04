using VectoVia.Models.Cars.Model;
using VectoVia.Views;
using vectovia.Models.Cars;

namespace VectoVia.Models.Cars.Services
{
    public class CarServices
    {
        private CarsDbContext _context;
        public CarServices(CarsDbContext context)
        {
            _context = context;
        }

        public void AddCar(CarVM Car)
        {
            var _car = new Car()
            {
                MarkaID = Car.MarkaID,
                Modeli = Car.Modeli,
                CarUrl = Car.CarUrl,
                Karburanti = Car.Karburanti,
                Transmisioni = Car.Transmisioni,
                VitiProdhimit = Car.VitiProdhimit,
            };
            _context.Car.Add(_car);
            _context.SaveChanges();
        }

        public List<Car> GetCars()
        {
            var allCars = _context.Car.ToList();
            return allCars;
        }
        public Car GetCarsByID(int CarID)
        {
            return _context.Car.FirstOrDefault(n => n.Tabelat == CarID);
        }

        public Car UpdateCarByID(int CarID, CarVM Car)
        {
            var _Car = _context.Car.FirstOrDefault(n => n.Tabelat == CarID);
            if (_Car != null)
            {
                _Car.MarkaID = Car.MarkaID;
                _Car.Modeli = Car.Modeli;
                _Car.CarUrl = Car.CarUrl;
                _Car.Karburanti = Car.Karburanti;
                _Car.Transmisioni = Car.Transmisioni;
                _Car.VitiProdhimit = Car.VitiProdhimit;

                _context.SaveChanges();
            }

            return _Car;

        }

        public void DeleteCarByID(int CarID)
        {
            var _Car = _context.Car.FirstOrDefault(n => n.Tabelat == CarID);
            if (_Car != null)
            {
                _context.Car.Remove(_Car);
                _context.SaveChanges();
            }
        }

    }
}
