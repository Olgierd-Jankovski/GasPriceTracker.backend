using Gas.Core.DTO;
using Microsoft.AspNetCore.Http;

namespace Gas.Core
{
    public class SavingServices : ISavingServices
    {
        private readonly DB.AppDbContext _context;
        private readonly DB.User _user;
        public SavingServices(DB.AppDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _user = _context.Users
                .First(u => u.Name == httpContextAccessor.HttpContext.User.Identity.Name);
        }

        public Savings AddSaving(DB.Savings saving)
        {
            saving.UserId = _user.Id;
            _context.Savings.Add(saving);
            _context.SaveChanges();

            return (Savings)saving;
        }

        public List<Savings> GetSavings() =>
            _context.Savings
                .Where(s => s.UserId == _user.Id)
                .Select(s => (Savings)s)
                .ToList();

        public Savings GetSavingById(int savingsId) =>
            _context.Savings
                .Where(s => s.UserId == _user.Id && s.Id == savingsId)
                .Select(s => (Savings)s)
                .First();
    }
}
