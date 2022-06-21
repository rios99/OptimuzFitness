namespace mvc_optimuz.Models.ViewModels
{
    public class DetalleVM
    {
        public DetalleVM()
        {
            Promocion = new Promocion();
        }
        public Promocion Promocion { get; set; }
        public bool ExisteEnCarro { get; set; }
    }
}
