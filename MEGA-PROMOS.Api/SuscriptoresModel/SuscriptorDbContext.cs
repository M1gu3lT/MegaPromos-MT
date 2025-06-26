using Microsoft.EntityFrameworkCore;

namespace MEGA_PROMOS.Api.Model
{
    public class SuscriptorDbContext:DbContext
    {
        // Constructor que recibe opciones (como la cadena de conexión) e inicializa la clase base (DbContext)
        public SuscriptorDbContext(DbContextOptions<SuscriptorDbContext> options) : base(options)
        {
        }
        public DbSet<SuscriptorData> Suscriptor { get; set; }
    }
}
