using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CodeFirst.Configurations;

public class AwardConfiguration : IEntityTypeConfiguration<Award>
{
    public void Configure(EntityTypeBuilder<Award> builder)
    {
        builder.ToTable("awards");

        builder.HasKey(e => e.Id);
        builder.Property(e => e.Name).HasMaxLength(100);
        
        builder.HasData(new List<Award>()
        {
            new() { Id = 1, Name = "Award1"},
            new() { Id = 2, Name = "Award2"}
        });
    }
}