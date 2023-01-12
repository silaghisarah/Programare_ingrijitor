using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_ingrijitor.Data;
using Programare_ingrijitor.Models;

namespace Programare_ingrijitor.Pages.Clienti
{
    public class DeleteModel : PageModel
    {
        private readonly Programare_ingrijitor.Data.Programare_ingrijitorContext _context;

        public DeleteModel(Programare_ingrijitor.Data.Programare_ingrijitorContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Client Client { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }

            var Client = await _context.Client.FirstOrDefaultAsync(m => m.ID == id);

            if (Client == null)
            {
                return NotFound();
            }
            else 
            {
                Client = Client;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Client == null)
            {
                return NotFound();
            }
            var Client = await _context.Client.FindAsync(id);

            if (Client != null)
            {
                Client = Client;
                _context.Client.Remove(Client);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
