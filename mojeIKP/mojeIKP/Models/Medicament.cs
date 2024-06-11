using System.ComponentModel.DataAnnotations;

namespace mojeIKP.Models;

public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(100)]
    [Required]
    public string Description { get; set; } = string.Empty;
    
    [MaxLength(100)]
    [Required]
    public string Type { get; set; } = string.Empty;
    
    public ICollection<Prescription_Medicament> Prescription_Medicaments { get; set; } = new HashSet<Prescription_Medicament>();
}