using System.ComponentModel.DataAnnotations;

namespace mojeIKP.RequestModels;

public class AddPrescriptionRequest
{
    [Required]
    public NewPatient Patient { get; set; } = null!;

    [Required] 
    public int DoctorId { get; set; }

    [Required]
    public List<Meds> Medicaments { get; set; } = new List<Meds>();
    
    [Required]
    public DateTime Date { get; set; }
    
    [Required]
    public DateTime DueDate { get; set; }
}