using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace Programare_ingrijitor.Models
{
    public class Programare
    {
        public int ID { get; set; }
        public int? ClientID { get; set; }
        public Client? Client { get; set; }

        public int? IngrijitorID { get; set; }
        public Ingrijitor? Ingrijitor { get; set; }

        public int? ServiciuID { get; set; }
        public Serviciu? Serviciu{ get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data programare")]
        public DateTime DataProgramare { get; set; }

        public int? ZonaID { get; set; }
        public Zona? Zona { get; set; }
    }
}
