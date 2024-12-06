using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace ClinicaStomatologicaPentruMedici.Models
{
    using System.Collections.Generic;

    public class Doctor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        [EmailAddress(ErrorMessage = "Adresa de email nu este valida.")]
        public string Email { get; set; }
        public ICollection<Patient>? Patients { get; set; }
        public ICollection<Prescription>? Prescriptions { get; set; }
        public ICollection<Appointment>? Appointments { get; set; }

    }
}
