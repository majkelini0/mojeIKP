namespace CodeFirst.Models;

public class Award
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    
    public ICollection<BookAward> BookAwards { get; set; } = new HashSet<BookAward>();
}