namespace Programare_ingrijitor.Models
{
    public class ServiciuData
    {
        //Corespondenta serviciu - Categorie
        public IEnumerable<Serviciu> Servicii { get; set; }
        public IEnumerable<Categorie> Categorii { get; set; }
        public IEnumerable<ServiciuCategorie> ServiciuCategorii { get; set; }
    }
}
