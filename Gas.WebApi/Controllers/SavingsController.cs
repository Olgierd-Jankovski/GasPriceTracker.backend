using Gas.Core;
using Gas.DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gas.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class SavingsController : ControllerBase
    {
        private readonly ISavingServices _savingServices;

        public SavingsController(ISavingServices savingServices)
        {
            _savingServices = savingServices;
        }

        [HttpGet]
        public IActionResult GetSavings()
        {
            return Ok(_savingServices.GetSavings());
        }

        [HttpGet("{id}", Name = "GetSaving")]
        public IActionResult GetSaving(int id)
        {
            return Ok(_savingServices.GetSavingById(id));
        }

        [HttpPost]
        public IActionResult AddSaving(Savings saving)
        {
            var newSaving = _savingServices.AddSaving(saving);
            return CreatedAtRoute("GetSaving", new {id = newSaving.Id}, newSaving);
        }

    }
}
