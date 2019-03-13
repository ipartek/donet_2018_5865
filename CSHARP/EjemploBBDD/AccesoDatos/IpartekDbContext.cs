using System.Data.Entity;
using Tipos;

namespace AccesoDatos
{
    public class IpartekDbContext : DbContext
    {
        //public static readonly IpartekDbContext INSTANCE = new IpartekDbContext();

        private static IpartekDbContext INSTANCE = null;

        private IpartekDbContext() : base("EjemploEntityFramework") {
            Database.SetInitializer<IpartekDbContext>(new DropCreateDatabaseAlways<IpartekDbContext>());
        }

        public static IpartekDbContext GetInstance()
        {
            if (INSTANCE == null)
            {
                INSTANCE = new IpartekDbContext();
                INSTANCE.Database.Log = System.Console.Write;
            }

            return INSTANCE;
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>().Property(p => p.IdRol).HasColumnType("char(5)");
        }
    }
}
