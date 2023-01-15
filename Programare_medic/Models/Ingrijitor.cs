using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Programare_ingrijitor.Models
{
    public class Ingrijitor
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string Nume { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]

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
