using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Programare_ingrijitor.Data;
using Programare_ingrijitor.Models;

namespace Programare_ingrijitor.Pages.Clienti
{
    public class CreateModel : PageModel
    {
        private readonly Programare_ingrijitor.Data.Programare_ingrijitorContext _context;

        public CreateModel(Programare_ingrijitor.Data.Programare_ingrijitorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Client Client { get; set; }
        

        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Client.Add(Client);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
