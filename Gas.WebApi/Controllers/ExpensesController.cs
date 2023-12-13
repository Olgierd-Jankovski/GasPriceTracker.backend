using Gas.DB;
using Gas.Core;
using Microsoft.AspNetCore.Mvc;

namespace Gas.WebApi.Controllers
{
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
        public IActionResult AddExpense(Expenses expense)
        {
            _expenseServices.AddExpense(expense);
            return CreatedAtRoute("GetExpense", new { id = expense.Id }, expense);
        }

    }
}
