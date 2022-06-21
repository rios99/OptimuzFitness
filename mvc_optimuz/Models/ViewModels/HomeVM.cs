namespace mvc_optimuz.Models.ViewModels
{
    public class HomeVM
    {
        public IEnumerable<Promocion> Promocions { get; set; }
        public IEnumerable<Contrato> Contratos { get; set; }
    }
}
