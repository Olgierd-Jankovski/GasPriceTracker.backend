using Gas.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Core
{
    public class LocationServices : ILocationServices
    {
        private readonly AppDbContext _context;
        public LocationServices(AppDbContext context)
        {
            _context = context;
        }

        public Location GetLocation(int id)
        {
            return _context.Locations.FirstOrDefault(l => l.Id == id);
        }

        public List<Location> GetLocations(int? stationId = null)
        {
            if (stationId == null)
            {
                return _context.Locations.ToList();
            }
            else
            {
                return _context.Locations.Where(l => l.StationId == stationId).ToList();
            }   
        }
    }
}
