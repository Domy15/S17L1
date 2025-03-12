using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace S17L1.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(30)]
        public string Author { get; set; }

        [Required]
        public int IdGenre { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        public string? URL_Image { get; set; }

        [ForeignKey("IdGenre")]
        public Genre Genre { get; set; }
    }
}
