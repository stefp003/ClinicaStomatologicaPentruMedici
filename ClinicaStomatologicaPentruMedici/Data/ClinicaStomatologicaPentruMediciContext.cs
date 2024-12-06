using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClinicaStomatologicaPentruMedici.Models;

namespace ClinicaStomatologicaPentruMedici.Data
{
    public class ClinicaStomatologicaPentruMediciContext : DbContext
    {
        public ClinicaStomatologicaPentruMediciContext (DbContextOptions<ClinicaStomatologicaPentruMediciContext> options)
            : base(options)
        {
        }

        public DbSet<ClinicaStomatologicaPentruMedici.Models.Doctor> Doctor { get; set; } = default!;
        public DbSet<ClinicaStomatologicaPentruMedici.Models.Patient> Patient { get; set; } = default!;
        public DbSet<ClinicaStomatologicaPentruMedici.Models.Treatment> Treatment { get; set; } = default!;
        public DbSet<ClinicaStomatologicaPentruMedici.Models.Prescription> Prescription { get; set; } = default!;
        public DbSet<ClinicaStomatologicaPentruMedici.Models.Appointment> Appointment { get; set; } = default!;
    }
}
