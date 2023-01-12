using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_ingrijitor.Models;

namespace Programare_ingrijitor.Pages.Servicii
{
    public class IndexModel : PageModel
    {
        private readonly Programare_ingrijitor.Data.Programare_ingrijitorContext _context;

        public IndexModel(Programare_ingrijitor.Data.Programare_ingrijitorContext context)
        {
            _context = context;
        }

        public IList<Serviciu> Serviciu { get; set; } = default!;
        public ServiciuData ServiciuD { get; set; }
        public int ServiciuID { get; set; }
        public int CategorieID { get; set; }
        public string DenumireServiciuSort { get; set; }
        public string IngrijitorSort { get; set; }
        public decimal CostSort { get; set; }
        public string CurrentFilter { get; set; }

        //pentru a afisa doctorii de la fiecare Categorie



        public async Task OnGetAsync(int? id, int? CategorieID, string sortOrder, string
searchString)
        {
            ServiciuD = new ServiciuData();

            DenumireServiciuSort = String.IsNullOrEmpty(sortOrder) ? "denumire_serviciu_desc" : "";
            IngrijitorSort = String.IsNullOrEmpty(sortOrder) ? "Ingrijitor_desc" : "";

            CurrentFilter = searchString;

            ServiciuD.Servicii = await _context.Serviciu
            .Include(b => b.Zona)
            .Include(b => b.Ingrijitor)
            .Include(b => b.ServiciuCategorii)
            .ThenInclude(b => b.Categorie)
            .AsNoTracking()
            .OrderBy(b => b.Denumire_Serviciu)
            .ToListAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                ServiciuD.Servicii = ServiciuD.Servicii.Where(s => s.Ingrijitor.Prenume.Contains(searchString)

               || s.Ingrijitor.Nume.Contains(searchString)
               || s.Denumire_Serviciu.Contains(searchString));
            }

            if (id != null)
            {
                ServiciuID = id.Value;
                Serviciu Serviciu = ServiciuD.Servicii
                .Where(i => i.ID == id.Value).Single();
                ServiciuD.Categorii = Serviciu.ServiciuCategorii.Select(s => s.Categorie);
            }

            switch (sortOrder)
            {
                case "denumire_serviciu_desc":
                    ServiciuD.Servicii = ServiciuD.Servicii.OrderByDescending(s =>
                   s.Denumire_Serviciu);
                    break;
                case "Ingrijitor_desc":
                    ServiciuD.Servicii = ServiciuD.Servicii.OrderByDescending(s =>
                   s.Ingrijitor.NumeComplet);
                    break;
            }

            }
        }
}
