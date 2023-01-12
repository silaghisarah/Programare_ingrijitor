using Microsoft.AspNetCore.Mvc.RazorPages;
using Programare_ingrijitor.Data;

namespace Programare_ingrijitor.Models

{
    public class ServiciuCategoriiPageModel : PageModel
    {
        public List<CategorieAtribuitaServiciu> CategorieAtribuitaServiciuList;
        public void PopulareAtribuireCategorieServiciu(Programare_ingrijitorContext context, Serviciu serviciu)
        {
            var allCategorii = context.Categorie;
            var serviciuCategorii = new HashSet<int>(
            serviciu.ServiciuCategorii.Select(c => c.CategorieID)); //
            CategorieAtribuitaServiciuList = new List<CategorieAtribuitaServiciu>();
            foreach (var cat in allCategorii)
            {
                CategorieAtribuitaServiciuList.Add(new CategorieAtribuitaServiciu
                {
                    CategorieID = cat.ID,
                    Denumire = cat.DenumireCategorie,
                    Atribuire = serviciuCategorii.Contains(cat.ID)
                });
            }
        }
        public void UpdateServiciuCategorii(Programare_ingrijitorContext context,
        string[] selectedServicii, Serviciu serviciuToUpdate)
        {
            if (selectedServicii == null)
            {
                serviciuToUpdate.ServiciuCategorii = new List<ServiciuCategorie>();
                return;
            }
            var selectedCategoriiHS = new HashSet<string>(selectedServicii);
            var serviciuCategorii = new HashSet<int>
            (serviciuToUpdate.ServiciuCategorii.Select(c => c.Categorie.ID));
            foreach (var cat in context.Categorie)
            {
                if (selectedCategoriiHS.Contains(cat.ID.ToString()))
                {
                    if (!serviciuCategorii.Contains(cat.ID))
                    {
                        serviciuToUpdate.ServiciuCategorii.Add(
                        new ServiciuCategorie
                        {
                            ServiciuID = serviciuToUpdate.ID,
                            CategorieID = cat.ID
                        });
                    }
                }
                else
                {
                    if (serviciuCategorii.Contains(cat.ID))
                    {
                        ServiciuCategorie courseToRemove
                        = serviciuToUpdate
                        .ServiciuCategorii
                        .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
