using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_optimuz.Models
{
    public class Promocion
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Llenar Campo")]
        public string NombrePromocio { get; set; }
        [Required(ErrorMessage = "Llenar Campo")]
        public string DecripcionCorta { get; set; }
        [Required(ErrorMessage = "Llenar Campo")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Llenar Campo")]
        [Range(1, double.MaxValue, ErrorMessage = "Precio mayor a 0")]
        public double Precio { get; set; }
        public string? ImagenURL { get; set; }

        //Foreing Key
        public int ContratoId { get; set; }
        [ForeignKey("ContratoId")]
        public virtual Contrato? Contrato { get; set; }
    }
}
