using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class EditionConfiguration : IEntityTypeConfiguration<Edition>
{
    public void Configure(EntityTypeBuilder<Edition> builder)
    {
        builder.ToTable("editions");
            
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(100);

        builder.HasOne(e => e.Book)
            .WithMany(e => e.Editions)
            .HasForeignKey(e => e.BookId)
            .OnDelete(DeleteBehavior.Cascade);
        
        builder.HasData(new List<Edition>()
        {
            new() { Id = 1, Name = "Edition11", BookId = 1},
            new() { Id = 2, Name = "Edition12", BookId = 1},
            new() { Id = 3, Name = "Edition21", BookId = 2},
        });
    }
}