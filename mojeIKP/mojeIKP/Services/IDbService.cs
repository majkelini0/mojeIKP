using mojeIKP.Models;

namespace mojeIKP.Services;

public interface IDbService
{
    Task<ICollection<Doctor>> GetDoctors();
}