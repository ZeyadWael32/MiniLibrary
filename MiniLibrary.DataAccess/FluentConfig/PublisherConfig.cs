using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MiniLibrary.Models.Models;

namespace MiniLibrary.DataAccess.FluentConfig
{
    public class PublisherConfig : IEntityTypeConfiguration<Publisher>
    {
        public void Configure(EntityTypeBuilder<Publisher> modelBuilder)
        {
            modelBuilder.Property(publisher => publisher.Name).HasMaxLength(100).IsRequired();
            modelBuilder.Property(publisher => publisher.Address).HasMaxLength(200).IsRequired();
        }
    }
}