using Microsoft.EntityFrameworkCore;
using mojeIKP.Context;
using mojeIKP.Models;

namespace mojeIKP.Services;

public class DbService : IDbService
{
    private readonly MojeIkpContext _context;
    
    public DbService(MojeIkpContext context)
    {
        _context = context;
    }

    public async Task<bool> DoesPatienExists(int PatientId)
    {
        return await _context.Patient.AnyAsync(x => x.IdPatient == PatientId);
    }

    public async Task<Patient?> GetPatientInfo(int PatientId)
    {
        return await _context.Patient
            .Include(x => x.Prescriptions)
            .ThenInclude(x => x.Prescription_Medicaments)
            .ThenInclude(x => x.Medicament)
            .Include(y => y.Prescriptions)
            .ThenInclude(y => y.Doctor)
            .FirstOrDefaultAsync(p => p.IdPatient == PatientId);
    }
}