namespace CodeFirst.Models;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public double Price { get; set; }
    
    public int TotalPages { get; set; }
    
    public ICollection<Edition> Editions { get; set; } = new HashSet<Edition>();
    public ICollection<BookAward> BookAwards { get; set; } = new HashSet<BookAward>();
    public ICollection<BookAuthor> BookAuthors { get; set; } = new HashSet<BookAuthor>();
}