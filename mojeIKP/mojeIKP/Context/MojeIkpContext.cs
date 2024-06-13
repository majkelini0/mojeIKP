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

        modelBuilder.Entity<Doctor>().HasData(
            new Doctor()
            {
                IdDoctor = 1, FirstName = "Michal", LastName = "Tomaszewski", Email = "tomaszewguru@gmail.com"
            },
            new Doctor()
            {
                IdDoctor = 2, FirstName = "Jaroslaw", LastName = "Kaczynski", Email = "jaroslawpolskezbaw@gmail.com"
            },
            new Doctor()
            {
                IdDoctor = 3, FirstName = "Andrzej", LastName = "Duda", Email = "dudawaswyduda@gmail.com"
            },
            new Doctor()
            {
                IdDoctor = 4, FirstName = "Donald", LastName = "German", Email = "germanislove@gmail.com"
            }
        );

        modelBuilder.Entity<Patient>().HasData(
            new Patient()
            {
                IdPatient = 1, FirstName = "Jan", LastName = "Rzezucha", Birthdate = new DateTime(1979, 8, 12)
            },
            new Patient()
            {
                IdPatient = 2, FirstName = "Jan", LastName = "Pawel", Birthdate = new DateTime(1921, 3, 7)
            },
            new Patient()
            {
                IdPatient = 3, FirstName = "Grazyna", LastName = "Komuchuwna", Birthdate = new DateTime(1969, 3, 3)
            },
            new Patient()
            {
                IdPatient = 4, FirstName = "Julia", LastName = "Przysrebska", Birthdate = new DateTime(1990, 1, 1)
            },
            new Patient()
            {
                IdPatient = 5, FirstName = "Jacek", LastName = "Kusrski", Birthdate = new DateTime(1975, 6, 9)
            }
        );

        modelBuilder.Entity<Medicament>().HasData(
            new Medicament()
            {
                IdMedicament = 1, Name = "Paracetamol", Description = "lek przeciwbolowy", Type = "tabletki"
            },
            new Medicament()
            {
                IdMedicament = 2, Name = "Ibuprofen MAX", Description = "lek przeciwzapalny", Type = "tabletki"
            },
            new Medicament()
            {
                IdMedicament = 3, Name = "Tamtum Verde", Description = "na gardlowe stany zapalne", Type = "aerozol" 
            },
            new Medicament()
            {
                IdMedicament = 4, Name = "Isla", Description = "porost islandzki lagodzacy podraznione gardlo", Type = "pastylki do ssania"
            }
            );

        modelBuilder.Entity<Prescription>().HasData(
            new Prescription()
            {
                IdPrescription = 1, Date = DateTime.Now, DueDate = new DateTime(2024, 7, 13), IdPatient = 1, IdDoctor = 1
            },
            new Prescription()
            {
                IdPrescription = 2, Date = DateTime.Now, DueDate = new DateTime(2024, 7, 13), IdPatient = 2, IdDoctor = 2
            },
            new Prescription()
            {
                IdPrescription = 3, Date = DateTime.Now, DueDate = new DateTime(2024, 7, 13), IdPatient = 3, IdDoctor = 3
            },
            new Prescription()
            {
                IdPrescription = 4, Date = DateTime.Now, DueDate = new DateTime(2024, 7, 13), IdPatient = 4, IdDoctor = 4
            },
            new Prescription()
            {
                IdPrescription = 5, Date = DateTime.Now, DueDate = new DateTime(2024, 7, 13), IdPatient = 5, IdDoctor = 3
            }
            );

        modelBuilder.Entity<Prescription_Medicament>().HasData(
            new Prescription_Medicament()
            {
                IdMedicament = 1, IdPrescription = 1, Dose = 1, Details = "po jednej tabletce 3 razy dziennie"
            },
            new Prescription_Medicament()
            {
                IdMedicament = 3, IdPrescription = 1, Dose = 1, Details = "ile wlezie do gardla"
            },
            new Prescription_Medicament()
            {
                IdMedicament = 4, IdPrescription = 1, Dose = 1, Details = "cmukac do woli"
            },
            new Prescription_Medicament()
            {
                IdMedicament = 1, IdPrescription = 2, Dose = 1, Details = "po jednej tabletce 3 razy dziennie"
            },
            new Prescription_Medicament()
            {
                IdMedicament = 2, IdPrescription = 2, Dose = 1, Details = "po jednej tabletce 3 razy dziennie"
            },
            new Prescription_Medicament()
            {
                IdMedicament = 3, IdPrescription = 3, Dose = 1, Details = "cmukac umiarkowanie"
            },
            new Prescription_Medicament()
            {
                IdMedicament = 3, IdPrescription = 4, Dose = 2, Details = "cmukac do woli"
            },
            new Prescription_Medicament()
            {
                IdMedicament = 2, IdPrescription = 5, Dose = 2, Details = "brac kiedy boli glowa"
            }
            );
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
