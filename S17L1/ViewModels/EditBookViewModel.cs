namespace S17L1.ViewModels
{
    public class EditBookViewModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public bool IsAvailable { get; set; }
        public string? URL_Image { get; set; }
    }
}
