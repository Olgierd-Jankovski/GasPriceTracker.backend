using Gas.Core.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Gas.Core
{
    public class ExpenseServices : IExpenseServices
    {
        private readonly DB.AppDbContext _context;
        private readonly DB.User _user;
        
        public ExpenseServices(DB.AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _user = _context.Users
                .First(u => u.Name == httpContextAccessor.HttpContext.User.Identity.Name);
        }

        public Expenses AddExpense(DB.Expenses expense)
        {
            expense.UserId = _user.Id;
            _context.Expenses.Add(expense);
            _context.SaveChanges();

            return (Expenses)expense;
        }

        public Expenses GetExpenseById(int id) =>
               _context.Expenses
                .Where(e => e.UserId == _user.Id && e.Id == id)
                .Select(e => (Expenses)e)
                .First();

        public List<Expenses> GetExpenses() =>
            _context.Expenses
            .Where(e => e.UserId == _user.Id)
            .Select(e => (Expenses)e)
            .ToList();
    }
}
