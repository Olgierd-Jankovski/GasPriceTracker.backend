using Microsoft.AspNetCore.Http;
using System.Linq;

namespace Gas.Core
{
    public class StatisticsServices : IStatisticsServices
    {
        private readonly DB.AppDbContext _context;
        private readonly DB.User _user;

        public StatisticsServices(DB.AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _user = _context.Users
                .First(u => u.Name == httpContextAccessor.HttpContext.User.Identity.Name);
        }

        public IEnumerable<KeyValuePair<string, float>> GetExpenseAmountPerCategory() =>
            _context.Expenses
                .Where(e => e.User.Id == _user.Id)
                //.AsEnumerable()
                //.GroupBy(e => e.TypeId.ToString())
                //.ToDictionary(e => e.Key, e => e.Sum(x => x.Amount))
                .Join(
                    _context.Types,
                    expense => expense.TypeId,
                    type => type.Id,
                    (expense, type) => new { TypeName = type.Name, Amount = expense.Amount }
                )
                .GroupBy(e => e.TypeName)
                .ToDictionary(e => e.Key, e => e.Sum(x => x.Amount))
                .Select(x => new KeyValuePair<string, float>(x.Key, x.Value));

        public IEnumerable<KeyValuePair<string, float>> GetSavingAmountPerCategory() =>
            _context.Savings
                .Where(s => s.UserId == _user.Id)
                .Join(
                    _context.Types,
                    saving => saving.TypeId,
                    type => type.Id,
                    (saving, type) => new { TypeName = type.Name, Amount = saving.Amount }
                    )
            .GroupBy(s => s.TypeName)
            .ToDictionary(s => s.Key, s => s.Sum(x => x.Amount))
            .Select(x => new KeyValuePair<string, float>(x.Key, x.Value));
    }

}
