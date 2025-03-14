﻿using S17L1.Models;

namespace S17L1.ViewModels
{
    public class EditBookViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int IdGenre { get; set; }
        public bool IsAvailable { get; set; }
        public string? URL_Image { get; set; }
        public IFormFile? New_URL_Image { get; set; }
        public List<Genre> Genres { get; set; }
    }
}
