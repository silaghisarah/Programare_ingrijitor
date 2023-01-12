using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using System.Xml.Linq;

namespace Programare_ingrijitor.Models
{
    public class Client
    {
        public int ID { get; set; }

        
        public string? Nume { get; set; }


        public string? Prenume { get; set; }
        public int? Varsta { get; set; }

        
        public string Email { get; set; }

        
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
