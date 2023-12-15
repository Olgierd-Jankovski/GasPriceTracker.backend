using Gas.Core.DTO;

namespace Gas.Core
{
    public interface IExpenseServices
    {
        Expenses AddExpense(DB.Expenses expense);

        List<Expenses> GetExpenses();
        Expenses GetExpenseById(int id);
        
    }
}
