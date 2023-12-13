using Gas.DB;

namespace Gas.Core
{
    public interface ISavingServices
    {
        Savings AddSaving(Savings saving);

        List<Savings> GetSavings();
        Savings GetSavingById(int savingsId);
    }
}
