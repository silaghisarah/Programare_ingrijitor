using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Programare_ingrijitor.Models;
using System.Data;
using System.Security.Policy;

namespace Programare_ingrijitor.Pages.Servicii
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : ServiciuCategoriiPageModel
    {
        private readonly Programare_ingrijitor.Data.Programare_ingrijitorContext _context;

        public CreateModel(Programare_ingrijitor.Data.Programare_ingrijitorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            
            var Ingrijitorlist = _context.Ingrijitor.Select(x => new
            {
                x.ID,
                NumeComplet = x.Nume + " " + x.Prenume
            });
            
            ViewData["IngrijitorID"] = new SelectList(Ingrijitorlist, "ID", "NumeComplet");
            

            ViewData["ZonaID"] = new SelectList(_context.Set<Zona>(), "ID","DenumireZona");
            var serviciu = new Serviciu();
            serviciu.ServiciuCategorii = new List<ServiciuCategorie>();
            PopulareAtribuireCategorieServiciu(_context, serviciu);
            return Page();
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; }

        public async Task<IActionResult> OnPostAsync(string[] selectedCategorii)
        {
            var newServiciu = Serviciu;
            if (selectedCategorii != null)
            {
                newServiciu.ServiciuCategorii = new List<ServiciuCategorie>();
                foreach (var cat in selectedCategorii)
                {
                    var catToAdd = new ServiciuCategorie
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newServiciu.ServiciuCategorii.Add(catToAdd);
                }
            }

            _context.Serviciu.Add(newServiciu);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulareAtribuireCategorieServiciu(_context, newServiciu);
            return Page();
        }

    }
}
