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

namespace Programare_ingrijitor.Pages.Ingrijitori
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
      public Ingrijitor Ingrijitor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ingrijitor == null)
            {
                return NotFound();
            }

            var Ingrijitor = await _context.Ingrijitor.FirstOrDefaultAsync(m => m.ID == id);

            if (Ingrijitor == null)
            {
                return NotFound();
            }
            else 
            {
                Ingrijitor = Ingrijitor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Ingrijitor == null)
            {
                return NotFound();
            }
            var Ingrijitor = await _context.Ingrijitor.FindAsync(id);

            if (Ingrijitor != null)
            {
                Ingrijitor = Ingrijitor;
                _context.Ingrijitor.Remove(Ingrijitor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
