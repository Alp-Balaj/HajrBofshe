using Microsoft.EntityFrameworkCore;
using vectovia.Models.PickUpLocations.Model;
using VectoVia.Data;
using VectoVia.Models.KompaniaRents.Model;
using VectoVia.Models.Cars.Model;
using VectoVia.Views;
using vectovia.Models.Cars;

namespace VectoVia.Models.KompaniaRents.Services
{
    public class KompaniaRentServices
    {
        private readonly KompaniaRentDbContext _context;
        private readonly CarsDbContext _carContext;

        public KompaniaRentServices(KompaniaRentDbContext context, CarsDbContext carContext)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _carContext = carContext ?? throw new ArgumentNullException(nameof(carContext));
        }



        public void AddKompaniaRent(KompaniaRentVM kompaniaRentVM)
        {
            var kompaniaRent = new KompaniaRent
            {
                Kompania = kompaniaRentVM.Kompania,
                QytetiId = kompaniaRentVM.QytetiId,
                ContactInfo = kompaniaRentVM.ContactInfo,
                Sigurimi = kompaniaRentVM.Sigurimi,
                CompanyLogoUrl = kompaniaRentVM.CompanyLogoUrl,
                PickUpLocations = new List<PickUpLocation>(),
                Cars = new List<Car>() 
            };

            _context.KompaniaRents.Add(kompaniaRent);
            _context.SaveChanges();

            // Add PickUpLocations
            var pickUpLocations = _context.PickUpLocations
                .Where(pl => kompaniaRentVM.PickUpLocationIDs.Contains(pl.PickUpLocationID))
                .ToList();

            foreach (var pickUpLocation in pickUpLocations)
            {
                kompaniaRent.PickUpLocations.Add(pickUpLocation);
            }

            // Add Cars
            var cars = _carContext.Car
                .Where(c => kompaniaRentVM.CarIDs.Contains(c.Tabelat))
                .ToList();

            foreach (var car in cars)
            {
                kompaniaRent.Cars.Add(car);
            }

            _context.SaveChanges();
        }

        public List<KompaniaRent> GetKompaniteRent()
        {
            return _context.KompaniaRents.ToList();
        }

        public KompaniaRent GetKompaniteRentByID(int kompaniaRentID)
        {
            return _context.KompaniaRents
                .Include(kr => kr.Cars) 
                .FirstOrDefault(n => n.CompanyID == kompaniaRentID);
        }

        public KompaniaRent UpdateKompaniaRentByID(int kompaniaRentID, KompaniaRentVM kompaniaRentVM)
        {
            var kompaniaRent = _context.KompaniaRents
                .Include(kr => kr.PickUpLocations)
                .Include(kr => kr.Cars)
                .FirstOrDefault(n => n.CompanyID == kompaniaRentID);

            if (kompaniaRent != null)
            {
                kompaniaRent.Kompania = kompaniaRentVM.Kompania;
                kompaniaRent.QytetiId = kompaniaRentVM.QytetiId;
                kompaniaRent.ContactInfo = kompaniaRentVM.ContactInfo;
                kompaniaRent.Sigurimi = kompaniaRentVM.Sigurimi;
                kompaniaRent.CompanyLogoUrl = kompaniaRentVM.CompanyLogoUrl;

               
                var existingLocations = kompaniaRent.PickUpLocations.ToList();
                var newLocationIDs = kompaniaRentVM.PickUpLocationIDs ?? new List<int>();

                
                foreach (var existingLocation in existingLocations)
                {
                    if (!newLocationIDs.Contains(existingLocation.PickUpLocationID))
                    {
                        kompaniaRent.PickUpLocations.Remove(existingLocation);
                    }
                }

                
                foreach (var newLocationID in newLocationIDs)
                {
                    if (!kompaniaRent.PickUpLocations.Any(pl => pl.PickUpLocationID == newLocationID))
                    {
                        var newLocation = _context.PickUpLocations.FirstOrDefault(pl => pl.PickUpLocationID == newLocationID);
                        if (newLocation != null)
                        {
                            kompaniaRent.PickUpLocations.Add(newLocation);
                        }
                    }
                }

               
                var existingCars = kompaniaRent.Cars.ToList();
                var newCarIDs = kompaniaRentVM.CarIDs ?? new List<int>();

               
                foreach (var existingCar in existingCars)
                {
                    if (!newCarIDs.Contains(existingCar.Tabelat))
                    {
                        kompaniaRent.Cars.Remove(existingCar);
                    }
                }

                
                foreach (var newCarID in newCarIDs)
                {
                    if (!kompaniaRent.Cars.Any(c => c.Tabelat == newCarID))
                    {
                        var newCar = _carContext.Car.FirstOrDefault(c => c.Tabelat == newCarID);
                        if (newCar != null)
                        {
                            kompaniaRent.Cars.Add(newCar);
                        }
                    }
                }

                _context.SaveChanges();
            }

            return kompaniaRent;
        }

        public KompaniaRent DeleteKompaniaRentByID(int companyID)
        {
            var kompaniaRent = _context.KompaniaRents
                .Include(kr => kr.Cars) 
                .FirstOrDefault(n => n.CompanyID == companyID);

            if (kompaniaRent != null)
            {
                _context.KompaniaRents.Remove(kompaniaRent);
                _context.SaveChanges();
                return kompaniaRent;
            }
            return null;
        }
        
        public List<KompaniaRent> GetKompaniteRentWithPickUpLocations()
        {
            return _context.KompaniaRents
                .Include(kr => kr.PickUpLocations)
                .Include(kr => kr.Cars)
                .ToList();
        }



        public List<Car> GetAllCars()
        {
            return _carContext.Car.ToList();
        }


        public List<Car>? GetAllCarsByCompanyID(int companyID)
        {
            var company = _context.KompaniaRents
                .Include(kr => kr.Cars)
                .FirstOrDefault(kr => kr.CompanyID == companyID);

            return company?.Cars.ToList();
        }
    }
}