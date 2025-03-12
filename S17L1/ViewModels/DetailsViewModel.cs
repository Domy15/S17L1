using System.ComponentModel.DataAnnotations;
using S17L1.Models;

namespace S17L1.ViewModels
{
    public class DetailsViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int IdGenre { get; set; }
        public bool IsAvailable { get; set; }
        public string? URL_Image { get; set; }
        public Genre Genre { get; set; }
    }
}
