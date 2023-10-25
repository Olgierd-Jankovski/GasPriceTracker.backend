using Gas.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gas.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly ILocationServices _locationServices;

        public LocationsController(ILocationServices locationServices)
        {
            _locationServices = locationServices;
        }

        [HttpGet]
        public IActionResult GetLocations([FromQuery] int? stationId = null) // ? means nullable
        {
            return Ok(_locationServices.GetLocations(stationId));
        }

        [HttpGet("{id}", Name = "GetLocation")]
        public IActionResult GetLocation(int id)
        {
            return Ok(_locationServices.GetLocation(id));
        }

    }
}
