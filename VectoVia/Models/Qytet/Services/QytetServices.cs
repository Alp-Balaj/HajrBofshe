using VectoVia.Views;


namespace vectovia.Models.Qytet.Services
{
    public class QytetServices
    {
        private readonly QytetiDbContext _context;

        public QytetServices(QytetiDbContext context)
        {
            _context = context;
        }

        
        public void AddQyteti(QytetiVM temp)
        {
            var _qytet = new Qyteti
            {
                Name = temp.Name,
            };
            _context.Qyteti.Add(_qytet);
            _context.SaveChanges();
        }
        public List<Qyteti> GetQyteti()
        {
            var allQyteti = _context.Qyteti.ToList();
            return allQyteti;
        }
        public Qyteti GetQytetiByID(int _QytetiID)
        {
            return _context.Qyteti.FirstOrDefault(n => n.QytetiId == _QytetiID);
        }

        public Qyteti UpdateQytetetByID(int QytetiId, QytetiVM qyteti)
        {
            var _qytet = _context.Qyteti.FirstOrDefault(n => n.QytetiId == QytetiId);
            if (_qytet != null)
            {
                _qytet.Name = qyteti.Name;


                _context.SaveChanges();
            }

            return _qytet;

        }
        public void DeleteQytetiByID(int QytetiId)
        {
            var _qytet = _context.Qyteti.FirstOrDefault(n => n.QytetiId == QytetiId);
            if (_qytet != null)
            {
                _context.Qyteti.Remove(_qytet);
                _context.SaveChanges();
            }
        }
    }
}
