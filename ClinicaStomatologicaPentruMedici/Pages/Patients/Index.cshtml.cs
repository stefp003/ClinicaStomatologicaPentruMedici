using System;
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
    public class IndexModel : PageModel
    {
        private readonly ClinicaStomatologicaPentruMedici.Data.ClinicaStomatologicaPentruMediciContext _context;

        public IndexModel(ClinicaStomatologicaPentruMedici.Data.ClinicaStomatologicaPentruMediciContext context)
        {
            _context = context;
        }

        public IList<Patient> Patient { get;set; } = default!;
        [BindProperty(SupportsGet = true)]
        public string NameSort { get; set; }

        public async Task OnGetAsync(string SortOrder)
        {
            // Setăm starea de sortare pentru afișarea în UI
            NameSort = SortOrder == "name" ? "name_desc" : "name";

            // Construim interogarea pentru pacienți
            IQueryable<Patient> patientQuery = _context.Patient
                .Include(p => p.Doctor); // Include relația cu Doctor

            // Aplicăm sortarea în funcție de parametrul `SortOrder`
            switch (SortOrder)
            {
                case "name_desc":
                    patientQuery = patientQuery.OrderByDescending(p => p.Name);
                    break;
                default:
                    patientQuery = patientQuery.OrderBy(p => p.Name);
                    break;
            }

            Patient = await _context.Patient
         .Include(p => p.Doctor).ToListAsync();
        }
    }
}
