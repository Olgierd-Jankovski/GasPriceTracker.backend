using Gas.Core.DTO;

namespace Gas.Core
{
    public interface ISavingServices
    {
        Savings AddSaving(DB.Savings saving);

        List<Savings> GetSavings();
        Savings GetSavingById(int savingsId);
    }
}
