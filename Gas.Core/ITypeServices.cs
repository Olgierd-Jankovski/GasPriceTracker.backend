
namespace Gas.Core
{
    public interface ITypeServices
    {
        Gas.DB.Type GetType(int id);
        List<Gas.DB.Type> GetTypes();
    }
}
