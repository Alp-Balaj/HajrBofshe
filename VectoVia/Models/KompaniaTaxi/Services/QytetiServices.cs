using Microsoft.AspNetCore.Mvc;
using VectoVia.Models.KompaniaRents.Model;
using VectoVia.Models.KompaniaTaxi.Model;
using VectoVia.Views;

namespace VectoVia.Models.KompaniaTaxi.Services
{

    public class QytetiServices
    {
        private QytetiDbContext _context;

        public QytetiServices(QytetiDbContext context)
        {
            _context = context;
        }

        public List<Model.Qyteti> GetQytetet()
        {
            return _context.Qytetet.ToList();
        }

        public Model.Qyteti GetQytetiByID(int QytetiID)
        {
            return _context.Qytetet.FirstOrDefault(q => q.QytetiID == QytetiID);
        }

        public void AddQyteti(QytetiVM kompaniaTaxi)
        {
            var _qyteti = new Qyteti();
            {
               _qyteti.emriIQyteti  = kompaniaTaxi.emriIQyteti;
            };
            _context.Qytetet.Add(_qyteti);
            _context.SaveChanges();
        }

        public Model.Qyteti UpdateQyteti(int QytetiID, QytetiVM qyteti)
        {
            var existingQyteti = _context.Qytetet.FirstOrDefault(q => q.QytetiID == QytetiID);
            if (existingQyteti != null)
            {
                existingQyteti.emriIQyteti = qyteti.emriIQyteti;
                _context.SaveChanges();
            }
            return existingQyteti;
        }

        public Model.Qyteti DeleteQyteti(int QytetiID)
        {
            var qytetiToDelete = _context.Qytetet.FirstOrDefault(q => q.QytetiID == QytetiID);
            if (qytetiToDelete != null)
            {
                _context.Qytetet.Remove(qytetiToDelete);
                _context.SaveChanges();
            }
            return qytetiToDelete;
        }
    }
}
