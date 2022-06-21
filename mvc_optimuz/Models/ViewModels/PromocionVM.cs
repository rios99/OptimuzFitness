using Microsoft.AspNetCore.Mvc.Rendering;

namespace mvc_optimuz.Models.ViewModels
{
    public class PromocionVM
    {
        public Promocion Promocion { get; set; }
        public IEnumerable<SelectListItem>? ContratoLista { get; set; }
    }
}
