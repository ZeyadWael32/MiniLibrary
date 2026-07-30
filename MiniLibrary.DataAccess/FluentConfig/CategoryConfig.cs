using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniLibrary.Models.Models;

namespace MiniLibrary.DataAccess.FluentConfig
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> modelBuilder)
        {
            modelBuilder.Property(category => category.Name).HasMaxLength(50).IsRequired();
        }
    }
}