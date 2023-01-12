using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_ingrijitor.Data;
using Programare_ingrijitor.Models;

namespace Programare_ingrijitor.Pages.Ingrijitori
{
    public class IndexModel : PageModel
    {
        private readonly Programare_ingrijitor.Data.Programare_ingrijitorContext _context;

        public IndexModel(Programare_ingrijitor.Data.Programare_ingrijitorContext context)
        {
            _context = context;
        }

        public IList<Ingrijitor> Ingrijitor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Ingrijitor != null)
            {
                Ingrijitor = await _context.Ingrijitor.ToListAsync();
            }
        }
    }
}
