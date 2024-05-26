using VectoVia.Models.KompaniaTaksive.Model;
using VectoVia.Views;
using VectoVia.Models.KompaniaTaksive;
using VectoVia.Models.Users.Model;

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
        public List<Qyteti> GetQyteti()
        {
            var allQyteti = _context.Qytetet.ToList();
            return allQyteti;
        }
        public Qyteti GetQytetiByID(int QytetiId)
        {
            return _context.Qytetet.FirstOrDefault(n => n.QytetiId == QytetiId);
        }

        public Qyteti UpdateQytetetByID(int QytetiId, QytetiVM qyteti)
        {
            var _qytet = _context.Qytetet.FirstOrDefault(n => n.QytetiId == QytetiId);
            if (_qytet != null)
            {
                _qytet.Name = qyteti.Name;


                _context.SaveChanges();
            }

            return _qytet;

        }
        public void DeleteQytetiByID(int QytetiId)
        {
            var _qytet = _context.Qytetet.FirstOrDefault(n => n.QytetiId == QytetiId);
            if (_qytet != null)
            {
                _context.Qytetet.Remove(_qytet);
                _context.SaveChanges();
            }
        }
    }
}
