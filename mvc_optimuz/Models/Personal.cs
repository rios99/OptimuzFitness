using System.ComponentModel.DataAnnotations;

namespace mvc_optimuz.Models
{
    public class Personal
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Llenar campo")]
        public string? NombrePersonal { get; set; }
        [Required(ErrorMessage = "Llenar campo")]
        public string? ApellidoPersonal { get; set; }
        [Required(ErrorMessage = "Llenar campo")]
        public string? tipoDocumento { get; set; }
        [Required(ErrorMessage = "Llenar campo")]
        public string? numDocumento { get; set; }
        public string? correo { get; set; }
        public string? telefono { get; set; }
    }
}
