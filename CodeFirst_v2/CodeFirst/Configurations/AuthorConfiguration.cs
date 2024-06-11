using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class AuthorConfiguration : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable("authors");
        
        builder.HasKey(e => e.Id);
        builder.Property(e => e.FirstName).HasMaxLength(100);
        builder.Property(e => e.LastName).HasMaxLength(100);
        
        
        builder.HasData(new List<Author>()
        {
            new() { Id = 1, FirstName = "John", LastName = "Doe"},
            new() { Id = 2, FirstName = "Ann", LastName = "Smith"},
            new() { Id = 3, FirstName = "Jack", LastName = "Taylor"}
        });
    }
}