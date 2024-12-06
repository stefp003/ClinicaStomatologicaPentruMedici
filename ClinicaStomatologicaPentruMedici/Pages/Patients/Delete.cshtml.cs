﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ClinicaStomatologicaPentruMedici.Data;
using ClinicaStomatologicaPentruMedici.Models;

namespace ClinicaStomatologicaPentruMedici.Pages.Patients
{
    public class DeleteModel : PageModel
    {
        private readonly ClinicaStomatologicaPentruMedici.Data.ClinicaStomatologicaPentruMediciContext _context;

        public DeleteModel(ClinicaStomatologicaPentruMedici.Data.ClinicaStomatologicaPentruMediciContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Patient Patient { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient.FirstOrDefaultAsync(m => m.Id == id);

            if (patient == null)
            {
                return NotFound();
            }
            else
            {
                Patient = patient;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var patient = await _context.Patient.FindAsync(id);
            if (patient != null)
            {
                Patient = patient;
                _context.Patient.Remove(Patient);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
