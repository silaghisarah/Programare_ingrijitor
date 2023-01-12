using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Programare_ingrijitor.Data;
using Programare_ingrijitor.Models;

namespace Programare_ingrijitor.Pages.Ingrijitori
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly Programare_ingrijitor.Data.Programare_ingrijitorContext _context;

        public EditModel(Programare_ingrijitor.Data.Programare_ingrijitorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Ingrijitor Ingrijitor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Ingrijitor == null)
            {
                return NotFound();
            }

            var Ingrijitor =  await _context.Ingrijitor.FirstOrDefaultAsync(m => m.ID == id);
            if (Ingrijitor == null)
            {
                return NotFound();
            }
            Ingrijitor = Ingrijitor;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Ingrijitor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngrijitorExists(Ingrijitor.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool IngrijitorExists(int id)
        {
          return _context.Ingrijitor.Any(e => e.ID == id);
        }
    }
}
