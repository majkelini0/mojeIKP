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

        var temp = new
        {
            ID = pi.Prescriptions.Select(x => x.Doctor.IdDoctor),
            FName = pi.Prescriptions.Select(x => x.Doctor.FirstName),
            LName = pi.Prescriptions.Select(x => x.Doctor.LastName),
            Email = pi.Prescriptions.Select(x => x.Doctor.Email)
        };
        
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
                
                ID = temp.ID,
                FName = temp.FName,
                LName = temp.LName,
                Email = temp.Email
            })
        };

        return Ok(res);
    }
}