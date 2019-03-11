using System.Data.Entity;
using Tipos;

namespace EjemploBBDD
{
    public class UsuarioDbContext : DbContext
    {
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
