using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class BookConfiguration : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("books");
            
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Title).HasMaxLength(100);
        builder.Property(e => e.Price).HasPrecision(3);

        builder.HasData(new List<Book>()
        {
            new() { Id = 1, Title = "Book1", Price = 10.23 },
            new() { Id = 2, Title = "Book2", Price = 15.43 },
            new() { Id = 3, Title = "Book3", Price = 16.33 }
        });
    }
}