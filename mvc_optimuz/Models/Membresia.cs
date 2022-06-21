using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc_optimuz.Models
{
    public class Membresia
    {
        [Key]
        public int Id { get; set; }
        public DateTime FecInicio { get; set; }
        public DateTime FecFin { get; set; }

        //Foreign Key
        public int ContratoId { get; set; }
        [ForeignKey("ContratoId")]
        public virtual Contrato Contrato { get; set; }
    }
}
