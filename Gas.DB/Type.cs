using System.ComponentModel.DataAnnotations;

namespace Gas.DB
{
    public class Type
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}