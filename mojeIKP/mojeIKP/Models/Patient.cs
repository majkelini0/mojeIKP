﻿using System.ComponentModel.DataAnnotations;

namespace mojeIKP.Models;

public class Patient
{
    [Key]
    public int IdPatient { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string FirstName { get; set; } = string.Empty;
    
    [MaxLength(100)]
    [Required] 
    public string LastName { get; set; } = string.Empty;
    
    [Required]
    public DateTime Birthdate { get; set; }
    
    public ICollection<Prescription> Prescriptions { get; set; } = new HashSet<Prescription>();
}