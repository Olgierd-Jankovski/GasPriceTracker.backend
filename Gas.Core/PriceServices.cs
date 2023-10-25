
using Gas.DB;
using Microsoft.EntityFrameworkCore;

namespace Gas.Core
{
    public class PriceServices : IPriceServices
    {
        private AppDbContext _context;

        public PriceServices(AppDbContext context)
        {
            _context = context;
        }

        public Price AddPrice(Price price)
        {
            //_context.Add(price);
            //_context.SaveChanges();
            /*
             * there is an issue with the insertion of the Price
             * It initialises the child classes (Location and Types) which already exist in the DB
             * There is no need to initialise them again, because database will suffer from duplication issues
             * we might go an Price isnertion in the way assuming the Types and Location properties are already in the DB
             * Additioanlly, the following code fragment solves an unchanged error with the Location/Type.Id property temporary value, which w'd prevent the insertion
             */

            //_context.Set<Price>().Add(price);
            // use the following statement so that the child classes won't be initialised

            if(price.LocationId != 0)
            {
                // Retrieve the existing Location entity by ID
                var location = _context.Locations.Find(price.LocationId);
                if(location != null)
                {
                    price.Location = location;
                    _context.Entry(location).State = EntityState.Unchanged;
                }
            }
            if(price.TypeId != 0)
            {
                // Retrieve the existing Type entity by ID
                var type = _context.Types.Find(price.TypeId);
                if(type != null)
                {
                    price.Type = type;
                    _context.Entry(type).State = EntityState.Unchanged;
                }
            }
            _context.Entry(price).State = EntityState.Added;
            _context.SaveChanges();
            // TODO: migrate the object relations to the DB for the optimisation purposes

            return price;
        }

        public void DeletePrice(int id)
        {
            var price = GetPrice(id);
            if(price != null)
            {
                _context.Remove(price);
                _context.SaveChanges();
            }
        }

        public Price GetPrice(int id) => _context.Prices.FirstOrDefault(p => p.Id == id);

        public Price GetPriceByLocationIdAndTypeId(int locationId, int typeId)
            => _context.Prices.FirstOrDefault(p => p.LocationId == locationId && p.TypeId == typeId);

        public List<Price> GetPrices()
        {
            return _context.Prices.ToList();
        }

        public List<Price> GetPricesByLocationId(int locationId) 
            => _context.Prices.Where(p =>  p.LocationId == locationId).ToList();

        public List<Price> GetPricesByTypeId(int typeId) 
            => _context.Prices.Where(p => p.TypeId == typeId).ToList();


        public Price UpdatePrice(Price price)
        {
            var dbPrice = GetPrice(price.Id);
            if(dbPrice != null)
            {
                dbPrice.Value = price.Value;
                dbPrice.Date = price.Date;
                _context.SaveChanges();
            }

            return dbPrice;
        }
    }
}
