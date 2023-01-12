using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Programare_ingrijitor.Data;
using Programare_ingrijitor.Models;

namespace Programare_ingrijitor.Pages.Programari
{
    public class EditModel : PageModel
    {
        private readonly Programare_ingrijitor.Data.Programare_ingrijitorContext _context;

        public EditModel(Programare_ingrijitor.Data.Programare_ingrijitorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Programare Programare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Programare == null)
            {
                return NotFound();
            }

            var programare =  await _context.Programare.FirstOrDefaultAsync(m => m.ID == id);
            if (programare == null)
            {
                return NotFound();
            }
            Programare = programare;
           ViewData["IngrijitorID"] = new SelectList(_context.Ingrijitor, "ID", "ID");
           ViewData["ClientID"] = new SelectList(_context.Set<Client>(), "ID", "ID");
           ViewData["ServiciuID"] = new SelectList(_context.Serviciu, "ID", "ID");
           ViewData["ZonaID"] = new SelectList(_context.Zona, "ID", "ID");
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

            _context.Attach(Programare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProgramareExists(Programare.ID))
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

        private bool ProgramareExists(int id)
        {
          return _context.Programare.Any(e => e.ID == id);
        }
    }
}
