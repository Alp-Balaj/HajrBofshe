using Microsoft.EntityFrameworkCore;
using vectovia.Models.PickUpLocations.Model;
using vectovia.Views;
using VectoVia.Data;
using VectoVia.Models.KompaniaRents.Model;
using VectoVia.Views;

namespace vectovia.Models.PickUpLocations.Services
{
    public class PickUpLocationServices
    {

        private KompaniaRentDbContext _context;

        public PickUpLocationServices(KompaniaRentDbContext context)
        {
            _context = context;
        }


        public void addPickUpLocation(PickUpLocationVM pickUpLocation)
        {
            var _pickUpLocation = new PickUpLocation()
            {
                locationName = pickUpLocation.locationName,
                Address = pickUpLocation.Address,
                city = pickUpLocation.city,
                ZipCode = pickUpLocation.ZipCode,
            };

            _context.Add(_pickUpLocation);
            _context.SaveChanges();
        }


        public List<Model.PickUpLocation> GetPickUpLocations()
        {
            // Eager loading the related KompaniaRent entities
            var allPickUpLocations = _context.PickUpLocations
                .Include(p => p.RentCompany)
                .ToList();

            return allPickUpLocations;
        }


        public PickUpLocation GetPickUpLocationsByID(int pk)
        {
            return _context.PickUpLocations.FirstOrDefault(n => n.PickUpLocationID == pk);
        }

        public PickUpLocation UpdatePickUpLocationByID(int id, PickUpLocationVM pickUpLocation)
        {
            var _pickUpLocation = _context.PickUpLocations.FirstOrDefault(n => n.PickUpLocationID == id);
            if (_pickUpLocation != null)
            {
                _pickUpLocation.locationName = pickUpLocation.locationName;
                _pickUpLocation.Address = pickUpLocation.Address;
                _pickUpLocation.city = pickUpLocation.city;
                _pickUpLocation.ZipCode = pickUpLocation.ZipCode;

                _context.SaveChanges();
            }

            return _pickUpLocation;

        }

        public void DeletePickUpLocationByID(int id)
        {
            var _pickUpLocation = _context.PickUpLocations.FirstOrDefault(n => n.PickUpLocationID == id);
            if (_pickUpLocation != null)
            {
                _context.PickUpLocations.Remove(_pickUpLocation);
                _context.SaveChanges();
            }
        }




    }
}
