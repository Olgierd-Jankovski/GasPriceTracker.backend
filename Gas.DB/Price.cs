using System.ComponentModel.DataAnnotations;

namespace Gas.DB
{
    public class Price
    {
        [Key]
        public int Id { get; set; }
        // it should be able to store floating point numbers like: 1.459 is a price for 1 liter
        public float Value { get; set; }
        public int LocationId { get; set; }
        public int TypeId { get; set; }
        // date and time when the price was set
        public DateTime Date { get; set; }

        public virtual Location Location { get; set; }
        public virtual Type Type { get; set; }
    }
}
