using Gas.Core;
using Gas.Core.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gas.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ExpensesController : ControllerBase
    {
        private readonly IExpenseServices _expenseServices;
        
        public ExpensesController(IExpenseServices expenseServices)
        {
            _expenseServices = expenseServices;
        }

        [HttpGet]
        public IActionResult GetExpenses()
        {
            return Ok(_expenseServices.GetExpenses());
        }

        [HttpGet("{id}", Name = "GetExpense")]
        public IActionResult GetExpense(int id)
        {
            return Ok(_expenseServices.GetExpenseById(id));
        }

        [HttpPost]
        public IActionResult AddExpense(DB.Expenses expense)
        {
            var newExpense = _expenseServices.AddExpense(expense);
            return CreatedAtRoute("GetExpense", new { id = newExpense.Id }, newExpense);
        }

    }
}
