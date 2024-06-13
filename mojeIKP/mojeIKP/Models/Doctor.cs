using System.ComponentModel.DataAnnotations;

namespace mojeIKP.Models;

// name the class Doctor

public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string LastName { get; set; } = null!;
    
    [MaxLength(100)]
    [Required]
    public string Email { get; set; } = null!;
    
    public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
}