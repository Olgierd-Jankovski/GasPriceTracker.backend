using System.ComponentModel.DataAnnotations.Schema;

namespace Gas.Core.DTO
{
    public class Expenses
    {
        public int Id { get; set; }
        public float Amount { get; set; }

        public int TypeId { get; set; }

        public static explicit operator Expenses(DB.Expenses e) => new Expenses
        {
            Id = e.Id,
            Amount = e.Amount,
            TypeId = e.TypeId,
        };
    }
}
