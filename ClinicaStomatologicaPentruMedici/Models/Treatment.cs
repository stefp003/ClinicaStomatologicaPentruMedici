using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
namespace ClinicaStomatologicaPentruMedici.Models
{
    public class Treatment
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        public int Cost { get; set; }
        [Required(ErrorMessage = "Campul este obligatoriu.")]
        public string Description { get; set; }
    }
}