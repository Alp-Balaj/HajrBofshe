using VectoVia.Models.KompaniaTaksive.Model;
using VectoVia.Models.Users.Model;
using VectoVia.Views;
using VectoVia.Models.KompaniaTaksive;

namespace VectoVia.Models.KompaniaTaksive.Services
{
    public class KompaniaTaxiServices
    {

        private KompaniaTaxiDbContext _context;

        public KompaniaTaxiServices(KompaniaTaxiDbContext context)
        {
            _context = context;
        }

        public void AddKompaniaTaxi(KompaniaTaxiVM kompaniaTaxi)
        {
            var hello = new KompaniaTaxi()
            {
                Kompania = kompaniaTaxi.Kompania,
                PrimaryColour = kompaniaTaxi.PrimaryColour,
                SecondaryColour = kompaniaTaxi.SecondaryColour,
                ContactInfo = kompaniaTaxi.ContactInfo,
                Sigurimi = kompaniaTaxi.Sigurimi,
                QytetiId = kompaniaTaxi.QytetiId,
            };
            _context.KompaniaTaksive.Add(hello);
            _context.SaveChanges();
        }

        public List<Model.KompaniaTaxi> GetKompaniteTaxive()
        {
            var temp = _context.KompaniaTaksive.ToList();
            return temp;
        }
        public Model.KompaniaTaxi GetKompaniteTaxiveByID(int ID)
        {
            return _context.KompaniaTaksive.FirstOrDefault(n => n.CompanyID == ID);
        }
        public KompaniaTaxi UpdateKompaniaTaxiByID(int ID, KompaniaTaxiVM kompaniaTaxi)
        {
            var _kompaniaTaxi = _context.KompaniaTaksive.FirstOrDefault(n => n.CompanyID == ID);
            if (_kompaniaTaxi != null)
            {
                _kompaniaTaxi.Kompania = kompaniaTaxi.Kompania;
                _kompaniaTaxi.PrimaryColour = kompaniaTaxi.PrimaryColour;
                _kompaniaTaxi.SecondaryColour = kompaniaTaxi.SecondaryColour;
                _kompaniaTaxi.ContactInfo = kompaniaTaxi.ContactInfo;
                _kompaniaTaxi.Sigurimi = kompaniaTaxi.Sigurimi;
                _kompaniaTaxi.QytetiId = kompaniaTaxi.QytetiId; 

                _context.SaveChanges();
            }

            return _kompaniaTaxi;

        }

        public void DeleteKompaniaTaxiByID(int ID)
        {
            var _kompaniaTaxi = _context.KompaniaTaksive.FirstOrDefault(n => n.CompanyID == ID);
            if (_kompaniaTaxi != null)
            {
                _context.KompaniaTaksive.Remove(_kompaniaTaxi);
                _context.SaveChanges();
            }
        }

    }
}

