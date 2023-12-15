

using System.ComponentModel.DataAnnotations;

namespace Gas.Core.DTO
{
    public class Savings
    {
        [Key]
        public int Id { get; set; }
        public float Amount { get; set; }

        public int TypeId { get; set; }

        public static explicit operator Savings(DB.Savings s) => new Savings
        {
            Id = s.Id,
            Amount = s.Amount,
            TypeId = s.TypeId,
        };
    }
}
