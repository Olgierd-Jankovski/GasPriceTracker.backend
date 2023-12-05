using Gas.Core;
using Gas.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Gas.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class PricesController : ControllerBase
    {
        private readonly IPriceServices _priceServices;

        public PricesController(IPriceServices priceServices)
        {
            _priceServices = priceServices;
        }


        [HttpGet("price/{id}", Name = "GetPrice")]
        public IActionResult GetPrice(int id)
        {
            return Ok(_priceServices.GetPrice(id));
        }

        [HttpGet("location/{locationId}", Name = "GetPricesByLocationId")]
        public IActionResult GetPricesByLocationId(int locationId)
        {
            return Ok(_priceServices.GetPricesByLocationId(locationId));
        }

        [HttpGet]
        public IActionResult GetPrices()
        {
            return Ok(_priceServices.GetPrices());
        }

        [HttpGet("type/{typeId}", Name = "GetPricesByTypeId")]
        public IActionResult GetPricesByTypeId(int typeId)
        {
            return Ok(_priceServices.GetPricesByTypeId(typeId));
        }

        [HttpGet("location/{locationId}/type/{typeId}", Name = "GetPriceByLocationIdAndTypeId")]
        public IActionResult GetPriceByLocationIdAndTypeId(int locationId, int typeId)
        {
            return Ok(_priceServices.GetPriceByLocationIdAndTypeId(locationId, typeId));
        }

        [HttpPost]
        public IActionResult AddPrice(Price price)
        {
            var newPrice = _priceServices.AddPrice(price);
            return CreatedAtRoute("GetPrice", new { id = newPrice.Id }, newPrice);
        }
        [HttpPut]
        public IActionResult UpdatePrice(Price price)
        {
            return Ok(_priceServices.UpdatePrice(price));
        }

        [HttpDelete("{id}")]
        public IActionResult DeletePrice(int id)
        {
            _priceServices.DeletePrice(id);
            return NoContent();
        }








    }
}
