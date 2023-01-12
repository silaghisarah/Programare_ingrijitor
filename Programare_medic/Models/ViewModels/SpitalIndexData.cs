using System.Security.Policy;
using Programare_ingrijitor.Models;

namespace Programare_ingrijitor.Models.ViewModels
{
    public class ZonaIndexData
    {
        public IEnumerable<Zona> Zone { get; set; }
        public IEnumerable<Serviciu> Servicii { get; set; }
    }
}
