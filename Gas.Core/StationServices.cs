using Gas.DB;

namespace Gas.Core
{
    public class StationServices : IStationServices
    {
        private readonly AppDbContext _context;
        public StationServices(AppDbContext context)
        {
            _context = context;
        }

        public void AddStation(Station station)
        {
            _context.Add(station);
            _context.SaveChanges();
        }

        public Station GetStation(int id)
        {
            return _context.Stations.FirstOrDefault(s => s.Id == id);
        }

        public List<Station> GetStations() => _context.Stations.ToList();
    }
}