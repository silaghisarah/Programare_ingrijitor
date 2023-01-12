using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Programare_ingrijitor.Models
{
    public class Categorie
    {
        public int ID { get; set; }

        [Display(Name = "Denumire Categorie")]
        [StringLength(30, MinimumLength = 3)]
        public string DenumireCategorie { get; set; }
        public ICollection<ServiciuCategorie>? ServiciuCategorii { get; set; }
    }
}
