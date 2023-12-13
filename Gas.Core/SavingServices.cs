using Gas.DB;

namespace Gas.Core
{
    public class SavingServices : ISavingServices
    {
        private readonly AppDbContext _context;
        public SavingServices(AppDbContext context)
        {
            _context = context;
        }

        public Savings AddSaving(Savings saving)
        {
            _context.Savings.Add(saving);
            _context.SaveChanges();

            return saving;
        }

        public List<Savings> GetSavings()
        {
            return _context.Savings.ToList();
        }

        public Savings GetSavingById(int savingsId)
        {
            return _context.Savings.FirstOrDefault(s => s.Id == savingsId);
        }
    }
}
