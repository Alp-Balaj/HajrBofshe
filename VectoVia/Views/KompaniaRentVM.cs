namespace VectoVia.Views
{
    public class KompaniaRentVM
    {

        public int CompanyID { get; set; }
        public string Kompania { get; set; }

        public string CompanyLogoUrl { get; set; }
        public int QytetiId { get; set; }
        public string ContactInfo { get; set; }

        public string Sigurimi { get; set; }

        public List<int> PickUpLocationIDs { get; set; }

        public List<int> CarIDs { get; set; }
    }
}

