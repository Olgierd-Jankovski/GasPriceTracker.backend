using Gas.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Core
{
    public interface IPriceServices
    {

        Price GetPrice(int id);
        List<Price> GetPricesByLocationId(int locationId);
        List<Price> GetPrices();
        List<Price> GetPricesByTypeId(int typeId);

        Price GetPriceByLocationIdAndTypeId(int locationId, int typeId);

        Price AddPrice(Price price);
        Price UpdatePrice(Price price);
        void DeletePrice(int id);
    }
}
