
using VectoVia.Models.KompaniaTaxi.Model;
using VectoVia.Models.Users.Model;
using VectoVia.Views;



namespace VectoVia.Models.KompaniaTaxi.Services
{
    public class KompaniaTaxiServices
    {
        private KompaniaTaxisDbContext _context;
        public KompaniaTaxiServices(KompaniaTaxisDbContext context)
        {
            _context = context;
        }


        public void AddKompaniaTaxi(KompaniaTaxiVM kompaniaTaxi)
        {
            var _kompaniaTaxi = new KompaniaTaxi()
            {
                Kompania = kompaniaTaxi.Kompania,
                Location = kompaniaTaxi.Location,
                ContactInfo = kompaniaTaxi.ContactInfo,
                Sigurimi = kompaniaTaxi.Sigurimi,
                QytetiID = kompaniaTaxi.QytetiID
            };

            // Ensure the QytetiID is valid
            if (kompaniaTaxi.QytetiID.HasValue)
            {
                var qyteti = _context.Qytetet.Find(kompaniaTaxi.QytetiID.Value);
                if (qyteti == null)
                {
                    throw new Exception("Qyteti not found");
                }
                _kompaniaTaxi.Qyteti = qyteti;
            }

            _context.KompaniaTaxis.Add(_kompaniaTaxi);
            _context.SaveChanges();
        }

        public List<Model.KompaniaTaxi> GetKompaniteTaxi()
        {
            var allKompaniaTaxi = _context.KompaniaTaxis.ToList();
            return allKompaniaTaxi;
        }
        public Model.KompaniaTaxi GetKompaniteTaxiByID(int KompaniaTaxiID)
        {
            return _context.KompaniaTaxis.FirstOrDefault(n => n.CompanyID == KompaniaTaxiID);
        }

        public Model.KompaniaTaxi UpdateKompaniaTaxiByID(int KompaniaTaxiID, KompaniaTaxiVM KompaniaTaxi)
        {
            var _kompaniataxi = _context.KompaniaTaxis.FirstOrDefault(n => n.CompanyID == KompaniaTaxiID);
            if (_kompaniataxi != null)
            {
                _kompaniataxi.Kompania = KompaniaTaxi.Kompania;
                _kompaniataxi.Location = KompaniaTaxi.Location;
                _kompaniataxi.Qyteti = KompaniaTaxi.emriIQyteti;
                _kompaniataxi.ContactInfo = KompaniaTaxi.ContactInfo;
                _kompaniataxi.Sigurimi = KompaniaTaxi.Sigurimi;

                _context.SaveChanges();
            }

            return _kompaniataxi;

        }

        public void DeleteKompaniTaxiByID(int KompaniaTaxiID)
        {
            var _kompaniataxi = _context.KompaniaTaxis.FirstOrDefault(n => n.CompanyID == KompaniaTaxiID);
            if (_kompaniataxi != null)
            {
                _context.KompaniaTaxis.Remove(_kompaniataxi);
                _context.SaveChanges();
            }
        }


    }
}