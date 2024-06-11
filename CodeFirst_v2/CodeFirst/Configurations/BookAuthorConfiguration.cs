using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
{
    public void Configure(EntityTypeBuilder<BookAuthor> builder)
    {
        builder.ToTable("book_authors");

        builder.HasKey(e => new { e.BookId, e.AuthorId});

        builder.HasOne(e => e.Book)
            .WithMany(e => e.BookAuthors)
            .HasForeignKey(e => e.BookId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasOne(e => e.Author)
            .WithMany(e => e.BookAuthors)
            .HasForeignKey(e => e.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasData(new List<BookAuthor>()
        {
            new() { AuthorId = 1, BookId = 1 },
            new() { AuthorId = 1, BookId = 2 },
            new() { AuthorId = 1, BookId = 3 },
            new() { AuthorId = 2, BookId = 2 },
            new() { AuthorId = 2, BookId = 3 },
        });
    }
}