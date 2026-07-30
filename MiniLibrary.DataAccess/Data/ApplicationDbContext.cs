using Microsoft.EntityFrameworkCore;
using MiniLibrary.DataAccess.FluentConfig;
using MiniLibrary.Models.Models;

namespace MiniLibrary.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Publisher> Publishers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BookConfig());
            modelBuilder.ApplyConfiguration(new AuthorConfig());
            modelBuilder.ApplyConfiguration(new CategoryConfig());
            modelBuilder.ApplyConfiguration(new PublisherConfig());

            var categorylist = new Category[]
            {
                new Category { Id = 1, Name = "Fiction" },
                new Category { Id = 2, Name = "Non-Fiction" },
                new Category { Id = 3, Name = "Science" },
            };

            var publisherlist = new Publisher[]
            {
                new Publisher { Id = 1, Name = "Publisher 1", Address = "123 Main St" },
                new Publisher { Id = 2, Name = "Publisher 2", Address = "456 Oak Ave" },
                new Publisher { Id = 3, Name = "Publisher 3", Address = "789 Pine Rd" }
            };

            var authorlist = new Author[]
            {
                new Author { Id = 1, FirstName = "John", LastName = "Doe", Biography = "John Doe is a prolific author known for his thrilling novels." },
                new Author { Id = 2, FirstName = "Jane", LastName = "Smith", Biography = "Jane Smith is a renowned author who has written numerous bestsellers in the romance genre." },
                new Author { Id = 3, FirstName = "Michael", LastName = "Johnson", Biography = "Michael Johnson is an award-winning author specializing in historical fiction." },
                new Author { Id = 4, FirstName = "Emily", LastName = "Davis", Biography = "Emily Davis is a talented author known for her captivating fantasy novels." },
                new Author { Id = 5, FirstName = "David", LastName = "Wilson", Biography = "David Wilson is a versatile author who has written across various genres, including mystery and thriller." }
            };

            var booklist = new Book[]
            {
                new Book { Id = 1, Title = "Book 1", ISBN = "1234567890", Price = 9.99m, CategoryId = 1, PublisherId = 1 },
                new Book { Id = 2, Title = "Book 2", ISBN = "0987654321", Price = 14.99m, CategoryId = 2, PublisherId = 1 },
                new Book { Id = 3, Title = "Book 3", ISBN = "5678901234", Price = 19.99m, CategoryId = 3, PublisherId = 2 },
                new Book { Id = 4, Title = "Book 4", ISBN = "9876543210", Price = 24.99m, CategoryId = 1, PublisherId = 3 },
                new Book { Id = 5, Title = "Book 5", ISBN = "4321098765", Price = 29.99m, CategoryId = 2, PublisherId = 3 },
                new Book { Id = 6, Title = "Book 6", ISBN = "2468135790", Price = 12.99m, CategoryId = 3, PublisherId = 2 },
                new Book { Id = 7, Title = "Book 7", ISBN = "1357924680", Price = 17.99m, CategoryId = 1, PublisherId = 1 },
                new Book { Id = 8, Title = "Book 8", ISBN = "8642097531", Price = 22.99m, CategoryId = 2, PublisherId = 3 }, 
            };

            modelBuilder.Entity<Category>().HasData(categorylist);
            modelBuilder.Entity<Publisher>().HasData(publisherlist);
            modelBuilder.Entity<Author>().HasData(authorlist);
            modelBuilder.Entity<Book>().HasData(booklist);
        }
    }
}