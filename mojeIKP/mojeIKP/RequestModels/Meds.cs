using System.ComponentModel.DataAnnotations;

namespace mojeIKP.RequestModels;

public class Meds
{
    public int IdMedicament { get; set; }
    
    public int  Dose { get; set; }
    
    [Required]
    public string Details { get; set; } = null!;
    // 'Description' leku mozna zdobyc po jego Id.
    // Lepiej w recepcie podac 'Details' jako wskazowki od lekarza dla pacjenta
}