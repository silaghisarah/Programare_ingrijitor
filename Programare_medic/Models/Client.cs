using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Programare_ingrijitor.Models
{
    public class Client
    {
        public int ID { get; set; }

        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]
        public string? Nume { get; set; }
        [RegularExpression(@"^[A-Z]+[a-z\s]*$")]
        [StringLength(30, MinimumLength = 3)]

        public string? Prenume { get; set; }
        public int? Varsta { get; set; }

        
        public string? Email { get; set; }

        
        public string? Telefon { get; set; }
        [Display(Name = "Nume complet")]
        public string? NumeComplet
        {
            get
            {
                return Prenume + " " + Nume;
            }
        }
        public ICollection<Programare>? Programari { get; set; }
    }
}
