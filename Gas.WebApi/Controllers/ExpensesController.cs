using Gas.DB;
using Gas.Core;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;
using Microsoft.Identity.Client;

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
        public class ExpensePost
        {
            public int Id { get; set; }
            public float Amount { get; set; }
            public int TypeId {  get; set; }
        }

        [HttpPost]
        public IActionResult AddExpense(Expenses expense)
        {
            /*Expenses expense = new Expenses();
            expense.Amount = expensePost.Amount;
            expense.TypeId = expensePost.TypeId;*/

            _expenseServices.AddExpense(expense);
            return CreatedAtRoute("GetExpense", new { id = expense.Id }, expense);
        }

    }
}
