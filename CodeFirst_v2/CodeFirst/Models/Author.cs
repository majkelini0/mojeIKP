namespace CodeFirst.Models;

public class Author
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    
    public ICollection<BookAuthor> BookAuthors { get; set; } = new HashSet<BookAuthor>();
}