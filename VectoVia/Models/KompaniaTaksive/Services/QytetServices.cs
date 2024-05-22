using VectoVia.Models.KompaniaTaksive.Model;
using VectoVia.Views;
using VectoVia.Models.KompaniaTaksive;

namespace VectoVia.Models.KompaniaTaksive.Services
{
    public class QytetServices
    {
        private readonly KompaniaTaxiDbContext _context;

        public QytetServices(KompaniaTaxiDbContext context)
        {
            _context = context;
        }

        public void AddQyteti(QytetiVM temp)
        {
            var _qytet = new Qyteti
            {
                Name = temp.Name,
            };
            _context.Qytetet.Add(_qytet);
            _context.SaveChanges();
        }
    }
}
