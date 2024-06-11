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

    public async Task<ICollection<Doctor>> GetDoctors()
    {
        return await _context.Doctor.ToListAsync();
    }
}