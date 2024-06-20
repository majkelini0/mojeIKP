using Microsoft.EntityFrameworkCore.Storage;
using mojeIKP.Models;
using mojeIKP.RequestModels;

namespace mojeIKP.Services;

public interface IDbService
{
    Task<IDbContextTransaction> BeginTransactionAsync();
    public Task<bool> DoesDoctorExists(int doctorid);
    public Task DoesMedicamentExists(ICollection<Meds> meds);
    public Task AddNewPatient(AddPrescriptionRequest request);
    public Task<bool> DoesPatienExists(NewPatient patient);
    public Task CreatePrescription(AddPrescriptionRequest request);
    public Task<Patient?> GetPatientInfo(int patientid);
}