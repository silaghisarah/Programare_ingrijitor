using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Programare_ingrijitor.Models;
using System.Data;
using System.Security.Policy;

namespace Programare_ingrijitor.Pages.Servicii
{
    [Authorize(Roles = "Admin")]
    public class EditModel : ServiciuCategoriiPageModel
    {
        private readonly Programare_ingrijitor.Data.Programare_ingrijitorContext _context;

        public EditModel(Programare_ingrijitor.Data.Programare_ingrijitorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var serviciu = await _context.Serviciu.FirstOrDefaultAsync(m => m.ID == id);
            Serviciu = await _context.Serviciu
              .Include(b => b.Zona)
              .Include(b => b.Ingrijitor)
              .Include(b => b.ServiciuCategorii).ThenInclude(b => b.Categorie)
              .AsNoTracking()
              .FirstOrDefaultAsync(m => m.ID == id);

            PopulareAtribuireCategorieServiciu(_context, Serviciu);
            if (Serviciu == null)
            {
                return NotFound();
            }

            var IngrijitorList = _context.Ingrijitor.Select(x => new
            {
                x.ID,
                NumeComplet = x.Nume + " " + x.Prenume
            });

            //Serviciu = serviciu;
            ViewData["ZonaID"] = new SelectList(_context.Set<Zona>(), "ID","DenumireZona");
            ViewData["IngrijitorID"] = new SelectList(IngrijitorList, "ID", "NumeComplet");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int? id, string[]selectedCategorii)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviciuToUpdate = await _context.Serviciu
                .Include(i => i.Zona)
                .Include(i => i.Ingrijitor)
                .Include(i => i.ServiciuCategorii)
                .ThenInclude(i => i.Categorie)
                .FirstOrDefaultAsync(s => s.ID == id);

            if (serviciuToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Serviciu>(
            serviciuToUpdate,
            "Serviciu",
            i => i.Denumire_Serviciu, i => i.IngrijitorID,
            i => i.Cost_consultatie, i => i.Data_Programare, i => i.ZonaID))
            {
                UpdateServiciuCategorii(_context, selectedCategorii, serviciuToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            
            UpdateServiciuCategorii(_context, selectedCategorii, serviciuToUpdate);
            PopulareAtribuireCategorieServiciu(_context, serviciuToUpdate);
            return Page();
        }
        private bool ServiciuExists(int id)
        {
            return _context.Serviciu.Any(e => e.ID == id);
        }

    }

}

