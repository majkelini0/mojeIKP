using Microsoft.AspNetCore.Mvc;
using mojeIKP.Services;

namespace mojeIKP.Controllers;

[Route("api/[controller]")]
public class PrescriptionsController : ControllerBase
{
    DbService _dbService;
}