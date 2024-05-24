using VectoVia.Models.KompaniaTaksive.Model;
using VectoVia.Views;

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
                Location = kompaniaTaxi.Location,
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

    }
}
