﻿
namespace Gas.Core
{
    public interface IStatisticsServices
    {
        IEnumerable<KeyValuePair<string, float>> GetExpenseAmountPerCategory();
    }
}
