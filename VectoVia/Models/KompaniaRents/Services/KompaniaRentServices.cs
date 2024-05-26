using Microsoft.EntityFrameworkCore;
using vectovia.Models.PickUpLocations.Model;
using VectoVia.Data;
using VectoVia.Models.KompaniaRents;
using VectoVia.Models.KompaniaRents.Model;
using VectoVia.Views;

namespace VectoVia.Models.KompaniaRents.Services
{
    public class KompaniaRentServices
    {

        private KompaniaRentDbContext _context;
        public KompaniaRentServices(KompaniaRentDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }


        public void AddKompaniaRent(KompaniaRentVM kompaniaRentVM)
        {
            var kompaniaRent = new KompaniaRent
            {
                Kompania = kompaniaRentVM.Kompania,
                Qyteti = kompaniaRentVM.Qyteti,
                ContactInfo = kompaniaRentVM.ContactInfo,
                Sigurimi = kompaniaRentVM.Sigurimi,
                PickUpLocations = new List<PickUpLocation>() // Initialize the collection
            };

            _context.KompaniaRents.Add(kompaniaRent);
            _context.SaveChanges();

            var pickUpLocations = _context.PickUpLocations
                .Where(pl => kompaniaRentVM.PickUpLocationIDs.Contains(pl.PickUpLocationID))
                .ToList();

            foreach (var pickUpLocation in pickUpLocations)
            {
                kompaniaRent.PickUpLocations.Add(pickUpLocation);
            }

            _context.SaveChanges();
        }

        public List<Model.KompaniaRent> GetKompaniteRent()
        {
            var allKompaniaRent = _context.KompaniaRents.ToList();
            return allKompaniaRent;
        }
        public KompaniaRent GetKompaniteRentByID(int KompaniaRentID)
        {
            return _context.KompaniaRents.FirstOrDefault(n => n.CompanyID == KompaniaRentID);
        }

        public KompaniaRent UpdateKompaniaRentByID(int KompaniaRentID, KompaniaRentVM kompaniaRentVM)
        {
            var _kompaniaRent = _context.KompaniaRents
                .Include(kr => kr.PickUpLocations) // Include the PickUpLocations in the query
                .FirstOrDefault(n => n.CompanyID == KompaniaRentID);

            if (_kompaniaRent != null)
            {
                _kompaniaRent.Kompania = kompaniaRentVM.Kompania;
                _kompaniaRent.Qyteti = kompaniaRentVM.Qyteti;
                _kompaniaRent.ContactInfo = kompaniaRentVM.ContactInfo;
                _kompaniaRent.Sigurimi = kompaniaRentVM.Sigurimi;

                // Update PickUpLocations
                var existingLocations = _kompaniaRent.PickUpLocations.ToList();
                var newLocationIDs = kompaniaRentVM.PickUpLocationIDs ?? new List<int>();

                // Remove locations that are no longer selected
                foreach (var existingLocation in existingLocations)
                {
                    if (!newLocationIDs.Contains(existingLocation.PickUpLocationID))
                    {
                        _kompaniaRent.PickUpLocations.Remove(existingLocation);
                    }
                }

                // Add new locations that are selected
                foreach (var newLocationID in newLocationIDs)
                {
                    if (!_kompaniaRent.PickUpLocations.Any(pl => pl.PickUpLocationID == newLocationID))
                    {
                        var newLocation = _context.PickUpLocations.FirstOrDefault(pl => pl.PickUpLocationID == newLocationID);
                        if (newLocation != null)
                        {
                            _kompaniaRent.PickUpLocations.Add(newLocation);
                        }
                    }
                }

                _context.SaveChanges();
            }

            return _kompaniaRent;
        }


        public KompaniaRent DeleteKompaniRentByID(int companyID)
        {
            var kompaniaRent = _context.KompaniaRents.FirstOrDefault(n => n.CompanyID == companyID);
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
                .Include(k => k.PickUpLocations)
                .ToList();
        }


    }
}