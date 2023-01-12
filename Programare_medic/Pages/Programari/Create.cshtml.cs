using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Programare_ingrijitor.Data;
using Programare_ingrijitor.Models;
using Microsoft.EntityFrameworkCore;


namespace Programare_ingrijitor.Pages.Programari
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
            var serviciuList = _context.Serviciu
            .Include(b => b.Ingrijitor)
            .Select(x => new
                            {
                                x.ID,
                                ServiciuDenumireCompleta = x.Denumire_Serviciu + " - " + x.Ingrijitor.Nume + " " +x.Ingrijitor.Prenume
                            });
            ViewData["ServiciuID"] = new SelectList(serviciuList, "ID", "ServiciuDenumireCompleta");
            ViewData["ClientID"] = new SelectList(_context.Client, "ID","NumeComplet");

            return Page();
        }


        [BindProperty]
        public Programare Programare { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
