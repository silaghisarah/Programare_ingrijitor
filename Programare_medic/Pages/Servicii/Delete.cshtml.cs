using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_ingrijitor.Models;
using System.Data;

namespace Programare_ingrijitor.Pages.Servicii
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Serviciu == null)
            {
                return NotFound();
            }
            var serviciu = await _context.Serviciu.FindAsync(id);

            if (serviciu != null)
            {
                Serviciu = serviciu;
                _context.Serviciu.Remove(Serviciu);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
