using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ClinicaStomatologicaPentruMedici.Data;
using ClinicaStomatologicaPentruMedici.Models;

namespace ClinicaStomatologicaPentruMedici.Pages.Prescriptions
{
    public class CreateModel : PageModel
    {
        private readonly ClinicaStomatologicaPentruMedici.Data.ClinicaStomatologicaPentruMediciContext _context;

        public CreateModel(ClinicaStomatologicaPentruMedici.Data.ClinicaStomatologicaPentruMediciContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["PatientId"] = new SelectList(_context.Patient, "Id", "Name");
            ViewData["TreatmentId"] = new SelectList(_context.Treatment, "Id", "Name");
            return Page();
        }

        [BindProperty]
        public Prescription Prescription { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            

            _context.Prescription.Add(Prescription);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
