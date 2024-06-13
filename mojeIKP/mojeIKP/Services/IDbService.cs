using mojeIKP.Models;

namespace mojeIKP.Services;

public interface IDbService
{
    public Task<bool> DoesPatienExists(int PatientId);
    public Task<Patient?> GetPatientInfo(int PatientId);
}