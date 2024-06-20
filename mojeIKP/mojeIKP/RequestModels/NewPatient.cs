using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace mojeIKP.RequestModels;

public class NewPatient
{
    public int IdPatient { get; set; } 

    [Required]
    public string FirstName { get; set; } = null!;
    
    [Required]
    public string LastName { get; set; } = null!;
    
    [Required]
    public DateTime BirthDate { get; set; }
}