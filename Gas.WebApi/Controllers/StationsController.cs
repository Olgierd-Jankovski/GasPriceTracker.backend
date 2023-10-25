using Gas.Core;
using Gas.DB;
using Microsoft.AspNetCore.Mvc;

namespace Gas.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StationsController : ControllerBase
    {
        private readonly IStationServices _stationServices;
        public StationsController(IStationServices stationServices)
        {
            _stationServices = stationServices;
        }

        [HttpGet]
        public IActionResult GetStations()
        {
            return Ok(_stationServices.GetStations());
        }

        [HttpGet("{id}", Name = "GetStation")]
        public IActionResult GetStation(int id)
        {
            return Ok(_stationServices.GetStation(id));
        }

        [HttpPost]
        public IActionResult AddStation(Station station)
        {
            _stationServices.AddStation(station);
            return CreatedAtRoute("GetStation", new { id = station.Id }, station);
        }   

    }

}