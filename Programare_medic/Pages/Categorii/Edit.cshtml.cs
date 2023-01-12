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

namespace Programare_ingrijitor.Pages.Categorii
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
        public Categorie Categorie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categorie == null)
            {
                return NotFound();
            }

            var Categorie =  await _context.Categorie.FirstOrDefaultAsync(m => m.ID == id);
            if (Categorie == null)
            {
                return NotFound();
            }
            Categorie = Categorie;
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

            _context.Attach(Categorie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategorieExists(Categorie.ID))
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

        private bool CategorieExists(int id)
        {
          return _context.Categorie.Any(e => e.ID == id);
        }
    }
}
