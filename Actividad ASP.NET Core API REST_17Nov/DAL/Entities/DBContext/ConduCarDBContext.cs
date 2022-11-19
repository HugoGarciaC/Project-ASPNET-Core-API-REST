using Microsoft.EntityFrameworkCore;

namespace Actividad_ASP.NET_Core_API_REST_17Nov.DAL.Entities.DBContext
{
    public class ConduCarDBContext : DbContext
    {
        public ConduCarDBContext(DbContextOptions<ConduCarDBContext> options) : base(options)
        {

        }

        public virtual DbSet<Matricula> Matricula { get; set; }
        public virtual DbSet<Conductor> Conductor { get; set; }
        public virtual DbSet<Sanciones> Sanciones { get; set; }

    }
}
