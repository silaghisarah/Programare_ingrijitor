using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace Programare_ingrijitor.Models
{
    public class Serviciu
    {
        public int ID { get; set; }

        [Display(Name = "Denumire")]
        [StringLength(30, MinimumLength = 3)]
        public string Denumire_Serviciu { get; set; }

        public int? IngrijitorID { get; set; }
        public Ingrijitor? Ingrijitor { get; set; }

        [Display(Name = "Cost ingrijire")]
        public decimal Cost_consultatie { get; set; }

        [Display(Name = "Data Disponibilitate")]
        [DataType(DataType.Date)]
        public DateTime Data_Programare { get; set; }
        [Display(Name = "Zona")]
        public int? ZonaID { get; set; }
        public Zona? Zona { get; set; }

        
        public ICollection<ServiciuCategorie>? ServiciuCategorii { get; set; }
    }
}
