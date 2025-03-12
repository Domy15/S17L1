using System.ComponentModel.DataAnnotations;

namespace S17L1.Models
{
    public class Genre
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
