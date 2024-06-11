using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class BookAwardConfiguration : IEntityTypeConfiguration<BookAward>
{
    public void Configure(EntityTypeBuilder<BookAward> builder)
    {
        builder.ToTable("book_awards");

        builder.HasKey(e => new { e.BookId, e.AwardId});

        builder.HasOne(e => e.Book)
            .WithMany(e => e.BookAwards)
            .HasForeignKey(e => e.BookId)
            .OnDelete(DeleteBehavior.Cascade);
            
        builder.HasOne(e => e.Award)
            .WithMany(e => e.BookAwards)
            .HasForeignKey(e => e.AwardId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasData(new List<BookAward>()
        {
            new() { AwardId = 1, BookId = 1, Year = 2024},
            new() { AwardId = 1, BookId = 2, Year = 2023 },
            new() { AwardId = 1, BookId = 3, Year = 2024 },
            new() { AwardId = 2, BookId = 2, Year = 2022 },
            new() { AwardId = 2, BookId = 3, Year = 2024 },
        });
    }
}