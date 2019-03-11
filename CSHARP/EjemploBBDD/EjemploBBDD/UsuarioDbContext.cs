using System.Data.Entity;
using Tipos;

namespace EjemploBBDD
{
    public class UsuarioDbContext : DbContext
    {
        public UsuarioDbContext() : base("EjemploEntityFramework") {
            Database.SetInitializer<UsuarioDbContext>(new DropCreateDatabaseAlways<UsuarioDbContext>());
        }

        public DbSet<Usuario> Usuarios { get; set; }
    }
}
