namespace MiniLibrary.Models.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string? Description { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        public int PublisherId { get; set; }
        public Publisher Publisher { get; set; } = null!;

        public ICollection<Author> Authors { get; set; } = new List<Author>();
    }
}