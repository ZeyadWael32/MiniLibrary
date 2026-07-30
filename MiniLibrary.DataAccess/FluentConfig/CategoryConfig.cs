using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniLibrary.Models.Models;

namespace MiniLibrary.DataAccess.FluentConfig
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> modelBuilder)
        {
            modelBuilder.Property(u => u.Name).HasMaxLength(50).IsRequired();
        }
    }
}