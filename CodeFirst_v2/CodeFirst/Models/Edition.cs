namespace CodeFirst.Models;

public class Edition
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int PublicationYear { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
}