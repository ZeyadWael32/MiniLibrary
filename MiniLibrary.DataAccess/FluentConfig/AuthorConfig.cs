using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniLibrary.Models.Models;

namespace MiniLibrary.DataAccess.FluentConfig
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> modelBuilder)
        {
            modelBuilder.Property(author => author.FirstName).HasMaxLength(50).IsRequired();
            modelBuilder.Property(author => author.LastName).HasMaxLength(50).IsRequired();
            modelBuilder.Property(author => author.Biography).HasMaxLength(200).IsRequired(false);
        }
    }
}