using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeFirst.Models;

[Table("editions")]
public class Edition
{
    [Key]
    public int Id { get; set; }
    
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    // gdy przy inicjalizacji obiektu nie podamy wartości, to zostanie przypisana
    // wartość domyślna, czyli string.Empty czyli ""
    
    public int PublicationYear { get; set; }

    public Book Book { get; set; } = null!;
}