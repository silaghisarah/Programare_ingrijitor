using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Programare_ingrijitor.Models
{
    public class Ingrijitor
    {
        public int ID { get; set; }

        
        public string Nume { get; set; }

        public string Prenume { get; set; }

        [Display(Name = "Nume complet")]
        public string NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Serviciu>? Servicii { get; set; }
    }
}
