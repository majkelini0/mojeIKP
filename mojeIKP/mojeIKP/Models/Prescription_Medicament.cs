using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace mojeIKP.Models;

[PrimaryKey(nameof(IdMedicament), nameof(IdPrescription))]
public class Prescription_Medicament
{
    public int IdMedicament { get; set; }
    
    public int IdPrescription { get; set; }
    
    public int Dose { get; set; }
    
    public string Details { get; set; } = string.Empty;
    
    [ForeignKey(nameof(IdMedicament))]
    public Medicament Medicament { get; set; } = null!;
    
    [ForeignKey(nameof(IdPrescription))]
    public Prescription Prescription { get; set; } = null!;
}