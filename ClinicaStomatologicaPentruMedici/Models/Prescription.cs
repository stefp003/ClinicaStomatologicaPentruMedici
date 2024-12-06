using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace ClinicaStomatologicaPentruMedici.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }

        public int TreatmentId { get; set; }
        public Treatment Treatment { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]

        public decimal TreatmentCost { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        public string Medicines { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        public int Quantity { get; set; }
    }
}