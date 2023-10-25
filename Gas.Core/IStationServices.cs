using Gas.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gas.Core
{
    public interface IStationServices
    {
        List<Station> GetStations();
        Station GetStation(int id);
        void AddStation(Station station);
    }
}
