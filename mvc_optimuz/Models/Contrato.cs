using System.ComponentModel.DataAnnotations;

namespace mvc_optimuz.Models
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Llenar campo")]
        public string NombreContrato { get; set; }

        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Llenar campo")]
        [Range(1, int.MaxValue, ErrorMessage = "Deber ser mayor a 0")]
        public int Precio { get; set; }
    }
}
