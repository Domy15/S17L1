using System.ComponentModel.DataAnnotations;
namespace S17L1.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        public string Email { get; set; }

        public ICollection<Borrow> Borrows { get; set; }
    }
}
