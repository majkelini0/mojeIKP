namespace CodeFirst.Models;

public class BookAward
{
    public int Year { get; set; }
    public int BookId { get; set; }
    public int AwardId { get; set; }
    
    public Book Book { get; set; } = null!;
    public Award Award { get; set; } = null!;
}