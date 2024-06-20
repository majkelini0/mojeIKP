using Microsoft.AspNetCore.Mvc;
using mojeIKP.RequestModels;
using mojeIKP.Services;

namespace mojeIKP.Controllers;

[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    private readonly IDbService _dbService;
    
    public PrescriptionsController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpPost]
    public async Task<IActionResult> AddPrescription([FromBody] AddPrescriptionRequest request)
    {
        if (await _dbService.DoesDoctorExists(request.DoctorId) == false)
        {
            return BadRequest("Doctor with given ID doesn't exist");
        }
        
        var patient = await _dbService.DoesPatienExists(request.Patient);

        try
        {
            await _dbService.DoesMedicamentExists(request.Medicaments);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        
        if(request.Medicaments.Count > 10)
        {
            return BadRequest("Too many medicaments! ( >= 10 )");
        }
        
        if(request.DueDate < request.Date)
        {
            return BadRequest("DueDate must be greater or equal to Date");
        }
        
        // begin one big transaction //
        //using var transaction = await _dbService.BeginTransactionAsync();

        //try
        //{
            if (patient == false)
            {
                await _dbService.AddNewPatient(request);
            }

            await _dbService.CreatePrescription(request);
            
            //await transaction.CommitAsync();
        //}
        // catch
        // {
        //     await transaction.RollbackAsync();
        //     throw;
        // }
        // end one big transaction //
        
        return Ok();
    }
}