using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace S17L1.Models
{
    [PrimaryKey(nameof(Id), nameof(IdBook))]
    public class Borrow
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid IdBook { get; set; }

        [Required]
        public DateTime BorrowDate { get; set; }

        [Required]
        public DateTime BorrowEndDate { get; set; }

        [Required]
        public bool IsReturned { get; set; }

        [ForeignKey("IdBook")]
        public Book book { get; set; }

        [ForeignKey("Id")]
        public User User { get; set; }
    }
}
