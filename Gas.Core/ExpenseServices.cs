using Gas.DB;

namespace Gas.Core
{
    public class ExpenseServices : IExpenseServices
    {
        private readonly AppDbContext _context;
        
        public ExpenseServices(AppDbContext context)
        {
            _context = context;
        }

        public Expenses AddExpense(Expenses expense)
        {
            _context.Expenses.Add(expense);
            _context.SaveChanges();

            return expense;
        }

        public Expenses GetExpenseById(int id)
        {
            return _context.Expenses.FirstOrDefault(e => e.Id == id);
        }

        public List<Expenses> GetExpenses()
        {
            return _context.Expenses.ToList();
        }
    }
}
