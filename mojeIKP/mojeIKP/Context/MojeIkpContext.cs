using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using mojeIKP.Models;

namespace mojeIKP.Context;

public partial class MojeIkpContext : DbContext
{
    public MojeIkpContext()
    {
    }

    public MojeIkpContext(DbContextOptions<MojeIkpContext> options)
        : base(options)
    {
    }
    
    public DbSet<Medicament> Medicament { get; set; }
    
    public DbSet<Doctor> Doctor { get; set; }
    
    public DbSet<Patient> Patient { get; set; }
    
    public DbSet<Prescription> Prescription { get; set; }
    
    public DbSet<Prescription_Medicament> Prescription_Medicament { get; set; }
    

//     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
// #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//         => optionsBuilder.UseSqlServer("Data Source=localhost, 1433; User=SA; Password=M@jkelini0; Initial Catalog=mojeIKP; Integrated Security=False;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
        
        
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
