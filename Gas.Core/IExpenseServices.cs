using Gas.DB;

namespace Gas.Core
{
    public interface IExpenseServices
    {
        Expenses AddExpense(Expenses expense);

        List<Expenses> GetExpenses();
        Expenses GetExpenseById(int id);
        
    }
}
