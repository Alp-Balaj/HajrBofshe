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
            _context = context;
        }


        public void AddKompaniaRent(KompaniaRentVM kompaniaRent)
        {
            var _kompaniaRent = new KompaniaRent()
            {
                Kompania = kompaniaRent.Kompania,
                PickUpLocation = kompaniaRent.PickUpLocation,
                Qyteti = kompaniaRent.Qyteti,
                ContactInfo = kompaniaRent.ContactInfo,
                Sigurimi = kompaniaRent.Sigurimi,
            };
            _context.KompaniaRents.Add(_kompaniaRent);
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

        public KompaniaRent UpdateKompaniaRentByID(int KompaniaRentID, KompaniaRentVM KompaniaRent)
        {
            var _kompaniaRent = _context.KompaniaRents.FirstOrDefault(n => n.CompanyID == KompaniaRentID);
            if (_kompaniaRent != null)
            {
                _kompaniaRent.Kompania = KompaniaRent.Kompania;
                _kompaniaRent.PickUpLocation = KompaniaRent.PickUpLocation;
                _kompaniaRent.Qyteti = KompaniaRent.Qyteti;
                _kompaniaRent.ContactInfo = KompaniaRent.ContactInfo;
                _kompaniaRent.Sigurimi = KompaniaRent.Sigurimi;

                _context.SaveChanges();
            }

            return _kompaniaRent;

        }

        public void DeleteKompaniRentByID(int KompaniaRentID)
        {
            var _kompaniaRent = _context.KompaniaRents.FirstOrDefault(n => n.CompanyID == KompaniaRentID);
            if (_kompaniaRent != null)
            {
                _context.KompaniaRents.Remove(_kompaniaRent);
                _context.SaveChanges();
            }
        }


    }
}