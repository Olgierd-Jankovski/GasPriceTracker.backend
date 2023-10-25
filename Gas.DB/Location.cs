using System.ComponentModel.DataAnnotations;

namespace Gas.DB
{
    public class Location
    {
        [Key]
        public int Id { get; set; }
        public int StationId { get; set; }
        public string Address { get; set; }

        public virtual Station Station { get; set; }
    }
}
