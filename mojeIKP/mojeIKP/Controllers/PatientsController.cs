using Microsoft.AspNetCore.Mvc;
using mojeIKP.Models;
using mojeIKP.Services;

namespace mojeIKP.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly IDbService _dbService;
    
    public PatientsController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet]
    [Route("{PatientId:int}")]
    public async Task<IActionResult> GetPatientsInfo(int PatientId)
    {
        var pi = await _dbService.GetPatientInfo(PatientId);
        
        if(pi == null)
        {
            return NotFound($"Client with given ID - {PatientId} doesn't exist");
        }
        
        var res = new
        {
            pi.IdPatient,
            pi.FirstName,
            pi.LastName,
            pi.Birthdate,
            Prescriptions = pi.Prescriptions.Select(x => new
            {
                x.IdPrescription,
                x.Date,
                x.DueDate,
                Medicaments = x.Prescription_Medicaments.Select(y => new
                {
                    y.IdMedicament,
                    y.Medicament.Name,
                    y.Dose,
                    y.Medicament.Description
        
                }).ToList(),
                
                Doctor = new
                {
                    x.Doctor.IdDoctor,
                    x.Doctor.FirstName,
                    x.Doctor.LastName,
                    x.Doctor.Email
                }
            })
        };
        return Ok(res);
    }
}