using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage;
using mojeIKP.Context;
using mojeIKP.Models;
using mojeIKP.RequestModels;

namespace mojeIKP.Services;

public class DbService : IDbService
{
    private readonly MojeIkpContext _context;

    public DbService(MojeIkpContext context)
    {
        _context = context;
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync()
    {
        return await _context.Database.BeginTransactionAsync();
    }

    public async Task<bool> DoesDoctorExists(int doctorid)
    {
        //return await _context.Doctor.FindAsync(DoctorId) != null;
        return await _context.Doctor.AnyAsync(x => x.IdDoctor == doctorid);
    }

    public async Task<bool> DoesPatienExists(NewPatient patient)
    {
        var res = await _context.Patient.AnyAsync(
            x => x.IdPatient == patient.IdPatient &&
                 x.FirstName == patient.FirstName &&
                 x.LastName == patient.LastName &&
                 x.Birthdate == patient.BirthDate
        );

        if (res == false)
        {
            var res2 = await _context.Patient.AnyAsync(x => x.IdPatient == patient.IdPatient);
            if (res2 == true)
            {
                patient.IdPatient = -1;
                //throw new Exception("Patient with given ID exists but with different data");
            }

            return false;
        }

        return true;
    }

    public async Task DoesMedicamentExists(ICollection<Meds> meds)
    {
        foreach (Meds med in meds)
        {
            if (await _context.Medicament.FindAsync(med.IdMedicament) == null)
            {
                throw new Exception("Medicament with given ID doesn't exist");
            }
        }
    }

    public async Task AddNewPatient(AddPrescriptionRequest request)
    {
        var newPatientEntry = await _context.Patient.AddAsync(
            new Patient()
            {
                FirstName = request.Patient.FirstName,
                LastName = request.Patient.LastName,
                Birthdate = request.Patient.BirthDate
            }
        );
        
        await _context.SaveChangesAsync();
        
        request.Patient.IdPatient = newPatientEntry.Entity.IdPatient;
    }

    public async Task CreatePrescription(AddPrescriptionRequest request)
    {
        var entry = await _context.Prescription.AddAsync(
            new Prescription()
            {
                Date = request.Date,
                DueDate = request.DueDate,
                IdPatient = request.Patient.IdPatient,
                IdDoctor = request.DoctorId
            }
        );
        await _context.SaveChangesAsync();
        
        foreach (var med in request.Medicaments)
        {
            await _context.Prescription_Medicament.AddAsync(
                new Prescription_Medicament()
                {
                    IdMedicament = med.IdMedicament,
                    IdPrescription = entry.Entity.IdPrescription,
                    //IdPrescription = 
                    Dose = med.Dose,
                    Details = med.Details
                }
            );
        }
        
        await _context.SaveChangesAsync();
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