using Gas.Core;
using Gas.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Gas.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticsServices _statisticsServices;

        public StatisticsController(IStatisticsServices statisticsServices)
        {
            _statisticsServices = statisticsServices;
        }

        [HttpGet("expenses")]
        public IActionResult GetExpenseAmountPerCategory()
        {
            return Ok(_statisticsServices.GetExpenseAmountPerCategory());
        }

        [HttpGet("savings")]
        public IActionResult GetSavingAmountPerCategory()
        {
            return Ok(_statisticsServices.GetSavingAmountPerCategory());
        }
    }
}
