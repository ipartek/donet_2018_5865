using System.Data.Entity;
using Tipos;

namespace EjemploBBDD
{
    public class IpartekDbContext : DbContext
    {
        public IpartekDbContext() : base("EjemploEntityFramework") {
            Database.SetInitializer<IpartekDbContext>(new DropCreateDatabaseAlways<IpartekDbContext>());
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
    }
}
