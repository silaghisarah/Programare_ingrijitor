using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Programare_ingrijitor.Data;
using Programare_ingrijitor.Models;
using Programare_ingrijitor.Models.ViewModels;


namespace Programare_ingrijitor.Pages.Zone
{
    public class IndexModel : PageModel
    {
        private readonly Programare_ingrijitor.Data.Programare_ingrijitorContext _context;

        public IndexModel(Programare_ingrijitor.Data.Programare_ingrijitorContext context)
        {
            _context = context;
        }

        public IList<Zona> Zona { get;set; } = default!;

        public ZonaIndexData ZonaData { get; set; }
        public int ZonaID { get; set; }
        public int ServiciuID { get; set; }
        public async Task OnGetAsync(int? id, int? bookID)
        {
            ZonaData = new ZonaIndexData();
            ZonaData.Zone = await _context.Zona
            .Include(i => i.Servicii)
            .ThenInclude(c => c.Ingrijitor)
            .OrderBy(i => i.DenumireZona)
            .ToListAsync();
            if (id != null)
            {
                ZonaID = id.Value;
                Zona publisher = ZonaData.Zone
                .Where(i => i.ID == id.Value).Single();
                ZonaData.Servicii = publisher.Servicii;
            }
        }
    }
}
