using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_ingrijitor.Data;
using Programare_ingrijitor.Models;

namespace Programare_ingrijitor.Pages.Categorii
{
    public class DetailsModel : PageModel
    {
        private readonly Programare_ingrijitor.Data.Programare_ingrijitorContext _context;

        public DetailsModel(Programare_ingrijitor.Data.Programare_ingrijitorContext context)
        {
            _context = context;
        }

      public Categorie Categorie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Categorie == null)
            {
                return NotFound();
            }

            var Categorie = await _context.Categorie.FirstOrDefaultAsync(m => m.ID == id);
            if (Categorie == null)
            {
                return NotFound();
            }
            else 
            {
                Categorie = Categorie;
            }
            return Page();
        }
    }
}
