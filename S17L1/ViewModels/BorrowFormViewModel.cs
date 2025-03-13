using System.ComponentModel.DataAnnotations;

namespace S17L1.ViewModels
{
    public class BorrowFormViewModel
    {

        public Guid IdBook { get; set; }

        public Guid IdUser { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Insert name!")]
        public string Name { get; set; }

        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Insert surname!")]
        public string Surname { get; set; }

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Insert email!")]
        public string Email { get; set; }

        [Display(Name = "End Borrow Date")]
        [Required(ErrorMessage = "Insert a date!")]
        public DateTime BorrowEndDate { get; set; }
    }
}
