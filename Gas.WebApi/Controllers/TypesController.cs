using Microsoft.AspNetCore.Mvc;
using Gas.DB;
using Gas.Core;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Gas.WebApi.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class TypesController : ControllerBase
    {
        private readonly ITypeServices _typeServices;

        public TypesController(ITypeServices typesServices)
        {
            _typeServices = typesServices;
        }

        [HttpGet]
        public IActionResult GetTypes()
        {
            return Ok(_typeServices.GetTypes());
        }

        [HttpGet("{id}", Name = "GetType")]
        public IActionResult GetType(int id)
        {
            return Ok(_typeServices.GetType(id));
        }
    }
}
