using Microsoft.AspNetCore.Mvc;
using mojeIKP.Services;

namespace mojeIKP.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatiensController : ControllerBase
{
    private readonly IDbService _dbService;
    
    public PatiensController(IDbService dbService)
    {
        _dbService = dbService;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetPatient()
    {
         var result = await _dbService.GetDoctors();

         return Ok(result);
    }
}