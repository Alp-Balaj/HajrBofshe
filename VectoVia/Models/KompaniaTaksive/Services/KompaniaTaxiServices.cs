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
                ImageUrl = kompaniaTaxi.ImageUrl,
                PrimaryColour = kompaniaTaxi.PrimaryColour,
                SecondaryColour = kompaniaTaxi.SecondaryColour,
                ContactInfo = kompaniaTaxi.ContactInfo,
                NumriKontaktues = kompaniaTaxi.NumriKontaktues,
                Sigurimi = kompaniaTaxi.Sigurimi,
                QytetiId = kompaniaTaxi.QytetiId,
            };
            _context.KompaniaTaxi.Add(hello);
            _context.SaveChanges();
        }

        public List<Model.KompaniaTaxi> GetKompaniteTaxive()
        {
            var temp = _context.KompaniaTaxi.ToList();
            return temp;
        }
        public Model.KompaniaTaxi GetKompaniteTaxiveByID(int ID)
        {
            return _context.KompaniaTaxi.FirstOrDefault(n => n.CompanyID == ID);
        }
        public KompaniaTaxi UpdateKompaniaTaxiByID(int ID, KompaniaTaxiVM kompaniaTaxi)
        {
            var _kompaniaTaxi = _context.KompaniaTaxi.FirstOrDefault(n => n.CompanyID == ID);
            if (_kompaniaTaxi != null)
            {
                _kompaniaTaxi.Kompania = kompaniaTaxi.Kompania;
                _kompaniaTaxi.ImageUrl = kompaniaTaxi.ImageUrl;
                _kompaniaTaxi.PrimaryColour = kompaniaTaxi.PrimaryColour;
                _kompaniaTaxi.SecondaryColour = kompaniaTaxi.SecondaryColour;
                _kompaniaTaxi.ContactInfo = kompaniaTaxi.ContactInfo;
                _kompaniaTaxi.NumriKontaktues = kompaniaTaxi.NumriKontaktues;
                _kompaniaTaxi.Sigurimi = kompaniaTaxi.Sigurimi;
                _kompaniaTaxi.QytetiId = kompaniaTaxi.QytetiId; 

                _context.SaveChanges();
            }

            return _kompaniaTaxi;

        }

        public void DeleteKompaniaTaxiByID(int ID)
        {
            var _kompaniaTaxi = _context.KompaniaTaxi.FirstOrDefault(n => n.CompanyID == ID);
            if (_kompaniaTaxi != null)
            {
                _context.KompaniaTaxi.Remove(_kompaniaTaxi);
                _context.SaveChanges();
            }
        }

    }
}

