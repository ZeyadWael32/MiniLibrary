using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniLibrary.Models.Models;

namespace MiniLibrary.DataAccess.FluentConfig
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> modelBuilder)
        {
            modelBuilder.Property(book => book.Title).HasMaxLength(100).IsRequired();
            modelBuilder.Property(book => book.ISBN).HasMaxLength(20).IsRequired();
            modelBuilder.Property(book => book.Price).HasPrecision(10, 2);
            modelBuilder.Property(book => book.Description).HasMaxLength(500).IsRequired(false);

            modelBuilder.HasOne(book => book.Publisher).WithMany(publisher => publisher.Books).HasForeignKey(book => book.PublisherId);
            modelBuilder.HasOne(book => book.Category).WithMany(category => category.Books).HasForeignKey(book => book.CategoryId);
            modelBuilder.HasMany(book => book.Authors).WithMany(author => author.Books)
                .UsingEntity(join => join
                .HasData(
                    new { BooksId = 1, AuthorsId = 1 },
                    new { BooksId = 2, AuthorsId = 2 },
                    new { BooksId = 3, AuthorsId = 3 },
                    new { BooksId = 4, AuthorsId = 4 },
                    new { BooksId = 5, AuthorsId = 5 },
                    new { BooksId = 6, AuthorsId = 1 },
                    new { BooksId = 7, AuthorsId = 2 },
                    new { BooksId = 8, AuthorsId = 3 }
                ));     
        }
    }
}