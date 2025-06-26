using MEGA_PROMOS.Api.PaquetesModel;
using Microsoft.EntityFrameworkCore;

namespace MEGA_PROMOS.Api.PromocionesModel
{
    public class PromocionesDbContext:DbContext
    {
        // Constructor que recibe opciones (como la cadena de conexión) e inicializa la clase base (DbContext)
        public PromocionesDbContext(DbContextOptions<PromocionesDbContext> options) : base(options)
        {
        }
        public DbSet<PromocionesData> promociones { get; set; }
    }
}
