using Gas.DB;

namespace Gas.Core
{
    public interface ILocationServices
    {
        Location GetLocation(int id);
        List<Location> GetLocations(int? stationId = null);
    }
}
