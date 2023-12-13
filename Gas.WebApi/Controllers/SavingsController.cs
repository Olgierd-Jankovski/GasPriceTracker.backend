using Gas.Core;
using Gas.DB;
using Microsoft.AspNetCore.Mvc;

namespace Gas.WebApi.Controllers
{
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
            _savingServices.AddSaving(saving);
            return CreatedAtRoute("GetSaving", new {id = saving.Id}, saving);
        }

    }
}
