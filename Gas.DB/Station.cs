using System.ComponentModel.DataAnnotations;

namespace Gas.DB
{
    public class Station
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
