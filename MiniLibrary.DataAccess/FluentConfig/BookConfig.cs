using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniLibrary.Models.Models;

namespace MiniLibrary.DataAccess.FluentConfig
{
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> modelBuilder)
        {
            modelBuilder.Property(u => u.Title).HasMaxLength(100).IsRequired();
            modelBuilder.Property(u => u.ISBN).HasMaxLength(20).IsRequired();
            modelBuilder.Property(u => u.Price).HasPrecision(10, 2);
            modelBuilder.Property(u => u.Description).HasMaxLength(500).IsRequired(false);

            modelBuilder.HasOne(u => u.Publisher).WithMany(u => u.Books).HasForeignKey(u => u.PublisherId);
            modelBuilder.HasOne(u => u.Category).WithMany(u => u.Books).HasForeignKey(u => u.CategoryId);
            modelBuilder.HasMany(u => u.Authors).WithMany(u => u.Books);
                
        }
    }
}