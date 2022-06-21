namespace mvc_optimuz.Models.ViewModels
{
    public class ContratoUsuarioVM
    {
        public ContratoUsuarioVM()
        {
            PromocionLista = new List<Promocion>();
        }

        public Usuario Usuario { get; set; }
        public IEnumerable<Promocion> PromocionLista { get; set; }
    }
}
