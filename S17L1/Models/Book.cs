using System.ComponentModel.DataAnnotations;

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
        [StringLength(50)]
        public string Genre { get; set; }

        [Required]
        public bool IsAvailable { get; set; }

        public string? URL_Image { get; set; }
    }
}
