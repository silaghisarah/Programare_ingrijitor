using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_ingrijitor.Data;
using Programare_ingrijitor.Models;

namespace Programare_ingrijitor.Pages.Programari
{
    public class DetailsModel : PageModel
    {
        private readonly Programare_ingrijitor.Data.Programare_ingrijitorContext _context;

        public DetailsModel(Programare_ingrijitor.Data.Programare_ingrijitorContext context)
        {
            _context = context;
        }

      public Programare Programare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Programare == null)
            {
                return NotFound();
            }

            var programare = await _context.Programare.FirstOrDefaultAsync(m => m.ID == id);
            if (programare == null)
            {
                return NotFound();
            }
            else 
            {
                Programare = programare;
            }
            return Page();
        }
    }
}
