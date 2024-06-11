using CodeFirst.Configurations;
using CodeFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirst.Data;

public class ApplicationContext : DbContext
{
    protected ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Edition> Editions { get; set; }
    public DbSet<Award> Awards { get; set; }
    public DbSet<BookAward> BookAwards { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        // 1. Model creating through configurations (recommended)
        
        // modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        // modelBuilder.ApplyConfiguration(new BookConfiguration());
        // modelBuilder.ApplyConfiguration(new EditionConfiguration());
        // modelBuilder.ApplyConfiguration(new AwardConfiguration());
        // modelBuilder.ApplyConfiguration(new BookAuthorConfiguration());
        // modelBuilder.ApplyConfiguration(new BookAwardConfiguration());
        
        // 2. Explicit model creating
        
        modelBuilder.Entity<Author>(e =>
        {
            e.ToTable("authors");
            
            e.HasKey(e => e.Id);
            e.Property(e => e.FirstName).HasMaxLength(100);
            e.Property(e => e.LastName).HasMaxLength(100);
            
            e.HasData(new List<Author>()
            {
                new() { Id = 1, FirstName = "John", LastName = "Doe"},
                new() { Id = 2, FirstName = "Ann", LastName = "Smith"},
                new() { Id = 3, FirstName = "Jack", LastName = "Taylor"}
            });
        });

        modelBuilder.Entity<Book>(e =>
        {
            e.ToTable("books");
            
            e.HasKey(e => e.Id);
            e.Property(e => e.Title).HasMaxLength(100);
            e.Property(e => e.Price).HasPrecision(3);
            
            e.HasData(new List<Book>()
            {
                new() { Id = 1, Title = "Book1", Price = 10.23 },
                new() { Id = 2, Title = "Book2", Price = 15.43 },
                new() { Id = 3, Title = "Book3", Price = 16.33 }
            });
        });
        
        modelBuilder.Entity<Edition>(e =>
        {
            e.ToTable("editions");
            
            e.HasKey(e => e.Id);
            e.Property(e => e.Name).HasMaxLength(100);

            e.HasOne(e => e.Book)
                .WithMany(e => e.Editions)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.Cascade);
            
            e.HasData(new List<Edition>()
            {
                new() { Id = 1, Name = "Edition11", BookId = 1},
                new() { Id = 2, Name = "Edition12", BookId = 1},
                new() { Id = 3, Name = "Edition21", BookId = 2},
            });
        });

        modelBuilder.Entity<Award>(e =>
        {
            e.ToTable("awards");

            e.HasKey(e => e.Id);
            e.Property(e => e.Name).HasMaxLength(100);
            
            e.HasData(new List<Award>()
            {
                new() { Id = 1, Name = "Award1"},
                new() { Id = 2, Name = "Award2"}
            });
        });
        
        modelBuilder.Entity<BookAward>(e =>
        {
            e.ToTable("book_awards");

            e.HasKey(e => new { e.BookId, e.AwardId});

            e.HasOne(e => e.Book)
                .WithMany(e => e.BookAwards)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.Cascade);
            
            e.HasOne(e => e.Award)
                .WithMany(e => e.BookAwards)
                .HasForeignKey(e => e.AwardId)
                .OnDelete(DeleteBehavior.Cascade);
            
            e.HasData(new List<BookAward>()
            {
                new() { AwardId = 1, BookId = 1, Year = 2024},
                new() { AwardId = 1, BookId = 2, Year = 2023 },
                new() { AwardId = 1, BookId = 3, Year = 2024 },
                new() { AwardId = 2, BookId = 2, Year = 2022 },
                new() { AwardId = 2, BookId = 3, Year = 2024 },
            });
        });
        
        modelBuilder.Entity<BookAuthor>(e =>
        {
            e.ToTable("book_authors");

            e.HasKey(e => new { e.BookId, e.AuthorId});

            e.HasOne(e => e.Book)
                .WithMany(e => e.BookAuthors)
                .HasForeignKey(e => e.BookId)
                .OnDelete(DeleteBehavior.Cascade);
            
            e.HasOne(e => e.Author)
                .WithMany(e => e.BookAuthors)
                .HasForeignKey(e => e.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);
            
            e.HasData(new List<BookAuthor>()
            {
                new() { AuthorId = 1, BookId = 1 },
                new() { AuthorId = 1, BookId = 2 },
                new() { AuthorId = 1, BookId = 3 },
                new() { AuthorId = 2, BookId = 2 },
                new() { AuthorId = 2, BookId = 3 },
            });
        });
    }
}