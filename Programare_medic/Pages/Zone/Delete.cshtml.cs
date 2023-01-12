using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_ingrijitor.Data;
using Programare_ingrijitor.Models;

namespace Programare_ingrijitor.Pages.Zone
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Programare_ingrijitor.Data.Programare_ingrijitorContext _context;

        public DeleteModel(Programare_ingrijitor.Data.Programare_ingrijitorContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Zona Zona { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Zona == null)
            {
                return NotFound();
            }

            var Zona = await _context.Zona.FirstOrDefaultAsync(m => m.ID == id);

            if (Zona == null)
            {
                return NotFound();
            }
            else 
            {
                Zona = Zona;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Zona == null)
            {
                return NotFound();
            }
            var Zona = await _context.Zona.FindAsync(id);

            if (Zona != null)
            {
                Zona = Zona;
                _context.Zona.Remove(Zona);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
