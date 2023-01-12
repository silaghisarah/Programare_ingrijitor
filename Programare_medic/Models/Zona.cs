using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Programare_ingrijitor.Models
{
    public class Zona
    {
        public int ID { get; set; }

        [Display(Name = "Denumire Zona")]
        [RegularExpression(@"^[A-Z]+[a-z\s]*$", ErrorMessage = "Denumirea Zonaului trebuie să înceapă cu majusculă și să aibă o lungime minimă de caractere 3. Ai văzut tu Zona de 3 litere? C'mon")]
        [StringLength(30, MinimumLength = 3)]
        public string DenumireZona { get; set; }
        public ICollection<Serviciu>? Servicii { get; set; } //navigation property
    }
}
