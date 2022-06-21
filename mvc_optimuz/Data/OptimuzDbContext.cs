using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc_optimuz.Models;

namespace mvc_optimuz.Data
{
    public class OptimuzDbContext : IdentityDbContext
    {
        public OptimuzDbContext(DbContextOptions<OptimuzDbContext> options) : base(options)
        {

        }

        public DbSet<Contrato> Contrato { get; set; }
        public DbSet<Socio> Socio { get; set; }
        public DbSet<Personal> Personal { get; set; }
        public DbSet<Promocion> Promocion { get; set; }
        public DbSet<Membresia> Membresia { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

    }
}
