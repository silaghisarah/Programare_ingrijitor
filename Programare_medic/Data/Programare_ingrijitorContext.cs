using Microsoft.EntityFrameworkCore;
using Programare_ingrijitor.Models;

namespace Programare_ingrijitor.Data
{
    public class Programare_ingrijitorContext : DbContext
    {
        public Programare_ingrijitorContext(DbContextOptions<Programare_ingrijitorContext> options)
            : base(options)
        {
        }

        public DbSet<Programare_ingrijitor.Models.Serviciu> Serviciu { get; set; } = default!;

        public DbSet<Programare_ingrijitor.Models.Zona> Zona { get; set; }

        public DbSet<Programare_ingrijitor.Models.Categorie> Categorie { get; set; }

        public DbSet<Programare_ingrijitor.Models.Ingrijitor> Ingrijitor { get; set; }

        public DbSet<Programare_ingrijitor.Models.Programare> Programare { get; set; }

        public DbSet<Programare_ingrijitor.Models.Client> Client { get; set; }
    }
}
