namespace CodeFirstFromDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IpartekModel : DbContext
    {
        public IpartekModel()
            : base("name=IpartekModelConnection")
        {
        }

        public virtual DbSet<EntradaBlog> EntradasBlog { get; set; }
        public virtual DbSet<Rol> Roles { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<RolesActivos> RolesActivos { get; set; }
        public virtual DbSet<UsuariosDeRolUser> UsuariosDeRolUser { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EntradaBlog>()
                .Property(e => e.Texto)
                .IsUnicode(false);

            modelBuilder.Entity<EntradaBlog>()
                .HasMany(e => e.Usuarios)
                .WithMany(e => e.EntradasBlog)
                .Map(m => m.ToTable("UsuariosEntradasBlog").MapLeftKey("IdEntradaBlog").MapRightKey("IdUsuarios"));

            modelBuilder.Entity<Rol>()
                .Property(e => e.Nombre)
                .IsUnicode(false);

            modelBuilder.Entity<Rol>()
                .HasMany(e => e.Usuarios)
                .WithOptional(e => e.Rol)
                .HasForeignKey(e => e.IdRol);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Usuario>()
                .HasMany(e => e.Usuarios1)
                .WithOptional(e => e.Usuarios2)
                .HasForeignKey(e => e.IdTutor);

            modelBuilder.Entity<RolesActivos>()
                .Property(e => e.Rol)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosDeRolUser>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<UsuariosDeRolUser>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
