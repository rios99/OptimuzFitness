using Microsoft.AspNetCore.Identity;

namespace mvc_optimuz.Models
{
    public class Usuario : IdentityUser
    {
        public string NombreCompleto { get; set; }
    }
}
