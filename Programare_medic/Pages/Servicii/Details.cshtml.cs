using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_ingrijitor.Models;

namespace Programare_ingrijitor.Pages.Servicii
{
    public class DetailsModel : PageModel
    {
        private readonly Programare_ingrijitor.Data.Programare_ingrijitorContext _context;

        public DetailsModel(Programare_ingrijitor.Data.Programare_ingrijitorContext context)
        {
            _context = context;
        }

        public Serviciu Serviciu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Serviciu == null)
            {
                return NotFound();
            }

            var serviciu = await _context.Serviciu.FirstOrDefaultAsync(m => m.ID == id);
            if (serviciu == null)
            {
                return NotFound();
            }
            else
            {
                Serviciu = serviciu;
            }
            return Page();
        }
    }
}
