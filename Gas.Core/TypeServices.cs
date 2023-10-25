using Gas.DB;

namespace Gas.Core
{
    public class TypeServices : ITypeServices
    {
        private readonly AppDbContext _context;
        
        public TypeServices(AppDbContext context)
        {
            _context = context;
        }

        public Gas.DB.Type GetType(int id)
        {
            return _context.Types.FirstOrDefault(t => t.Id == id);
        }

        public List<Gas.DB.Type> GetTypes() => _context.Types.ToList();
    }
}
