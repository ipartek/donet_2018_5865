﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApiSwagger.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class IpartekEntities : DbContext
    {
        public IpartekEntities()
            : base("name=IpartekEntities")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Articulo> Articulos { get; set; }
        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Departamento> Departamentos { get; set; }
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; }
        public virtual DbSet<EntradasBlog> EntradasBlogs { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<TiposUsuario> TiposUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<RolesActivo> RolesActivos { get; set; }
        public virtual DbSet<UsuariosDeRolUser> UsuariosDeRolUsers { get; set; }
    
        public virtual int BuscadorPorCampoYValor(string campo)
        {
            var campoParameter = campo != null ?
                new ObjectParameter("campo", campo) :
                new ObjectParameter("campo", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("BuscadorPorCampoYValor", campoParameter);
        }
    
        public virtual int ComprobarEmailYPassword(string email, string password)
        {
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("password", password) :
                new ObjectParameter("password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ComprobarEmailYPassword", emailParameter, passwordParameter);
        }
    
        public virtual int ConsultaPorCampo(string campo, string valor)
        {
            var campoParameter = campo != null ?
                new ObjectParameter("campo", campo) :
                new ObjectParameter("campo", typeof(string));
    
            var valorParameter = valor != null ?
                new ObjectParameter("valor", valor) :
                new ObjectParameter("valor", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ConsultaPorCampo", campoParameter, valorParameter);
        }
    
        public virtual ObjectResult<EntradasDeBlogPorUsuario_Result> EntradasDeBlogPorUsuario()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EntradasDeBlogPorUsuario_Result>("EntradasDeBlogPorUsuario");
        }
    
        public virtual ObjectResult<EntradasDeBlogPorUsuarioPorId_Result> EntradasDeBlogPorUsuarioPorId(Nullable<int> idUsuario)
        {
            var idUsuarioParameter = idUsuario.HasValue ?
                new ObjectParameter("IdUsuario", idUsuario) :
                new ObjectParameter("IdUsuario", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<EntradasDeBlogPorUsuarioPorId_Result>("EntradasDeBlogPorUsuarioPorId", idUsuarioParameter);
        }
    
        public virtual int InformeRolesCursores()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InformeRolesCursores");
        }
    
        public virtual int RolesInsertar(string rol, string descripcion, ObjectParameter id)
        {
            var rolParameter = rol != null ?
                new ObjectParameter("Rol", rol) :
                new ObjectParameter("Rol", typeof(string));
    
            var descripcionParameter = descripcion != null ?
                new ObjectParameter("Descripcion", descripcion) :
                new ObjectParameter("Descripcion", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("RolesInsertar", rolParameter, descripcionParameter, id);
        }
    
        public virtual int UsuariosDelete(Nullable<int> original_Id, Nullable<int> isNull_IdRol, Nullable<int> original_IdRol, Nullable<int> isNull_IdTutor, Nullable<int> original_IdTutor, string original_Email, string original_Password)
        {
            var original_IdParameter = original_Id.HasValue ?
                new ObjectParameter("Original_Id", original_Id) :
                new ObjectParameter("Original_Id", typeof(int));
    
            var isNull_IdRolParameter = isNull_IdRol.HasValue ?
                new ObjectParameter("IsNull_IdRol", isNull_IdRol) :
                new ObjectParameter("IsNull_IdRol", typeof(int));
    
            var original_IdRolParameter = original_IdRol.HasValue ?
                new ObjectParameter("Original_IdRol", original_IdRol) :
                new ObjectParameter("Original_IdRol", typeof(int));
    
            var isNull_IdTutorParameter = isNull_IdTutor.HasValue ?
                new ObjectParameter("IsNull_IdTutor", isNull_IdTutor) :
                new ObjectParameter("IsNull_IdTutor", typeof(int));
    
            var original_IdTutorParameter = original_IdTutor.HasValue ?
                new ObjectParameter("Original_IdTutor", original_IdTutor) :
                new ObjectParameter("Original_IdTutor", typeof(int));
    
            var original_EmailParameter = original_Email != null ?
                new ObjectParameter("Original_Email", original_Email) :
                new ObjectParameter("Original_Email", typeof(string));
    
            var original_PasswordParameter = original_Password != null ?
                new ObjectParameter("Original_Password", original_Password) :
                new ObjectParameter("Original_Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("UsuariosDelete", original_IdParameter, isNull_IdRolParameter, original_IdRolParameter, isNull_IdTutorParameter, original_IdTutorParameter, original_EmailParameter, original_PasswordParameter);
        }
    
        public virtual ObjectResult<UsuariosInsert_Result> UsuariosInsert(Nullable<int> idRol, Nullable<int> idTutor, string email, string password)
        {
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            var idTutorParameter = idTutor.HasValue ?
                new ObjectParameter("IdTutor", idTutor) :
                new ObjectParameter("IdTutor", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuariosInsert_Result>("UsuariosInsert", idRolParameter, idTutorParameter, emailParameter, passwordParameter);
        }
    
        public virtual ObjectResult<UsuariosSelect_Result> UsuariosSelect()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuariosSelect_Result>("UsuariosSelect");
        }
    
        public virtual ObjectResult<UsuariosUpdate_Result> UsuariosUpdate(Nullable<int> idRol, Nullable<int> idTutor, string email, string password, Nullable<int> original_Id, Nullable<int> isNull_IdRol, Nullable<int> original_IdRol, Nullable<int> isNull_IdTutor, Nullable<int> original_IdTutor, string original_Email, string original_Password, Nullable<int> id)
        {
            var idRolParameter = idRol.HasValue ?
                new ObjectParameter("IdRol", idRol) :
                new ObjectParameter("IdRol", typeof(int));
    
            var idTutorParameter = idTutor.HasValue ?
                new ObjectParameter("IdTutor", idTutor) :
                new ObjectParameter("IdTutor", typeof(int));
    
            var emailParameter = email != null ?
                new ObjectParameter("Email", email) :
                new ObjectParameter("Email", typeof(string));
    
            var passwordParameter = password != null ?
                new ObjectParameter("Password", password) :
                new ObjectParameter("Password", typeof(string));
    
            var original_IdParameter = original_Id.HasValue ?
                new ObjectParameter("Original_Id", original_Id) :
                new ObjectParameter("Original_Id", typeof(int));
    
            var isNull_IdRolParameter = isNull_IdRol.HasValue ?
                new ObjectParameter("IsNull_IdRol", isNull_IdRol) :
                new ObjectParameter("IsNull_IdRol", typeof(int));
    
            var original_IdRolParameter = original_IdRol.HasValue ?
                new ObjectParameter("Original_IdRol", original_IdRol) :
                new ObjectParameter("Original_IdRol", typeof(int));
    
            var isNull_IdTutorParameter = isNull_IdTutor.HasValue ?
                new ObjectParameter("IsNull_IdTutor", isNull_IdTutor) :
                new ObjectParameter("IsNull_IdTutor", typeof(int));
    
            var original_IdTutorParameter = original_IdTutor.HasValue ?
                new ObjectParameter("Original_IdTutor", original_IdTutor) :
                new ObjectParameter("Original_IdTutor", typeof(int));
    
            var original_EmailParameter = original_Email != null ?
                new ObjectParameter("Original_Email", original_Email) :
                new ObjectParameter("Original_Email", typeof(string));
    
            var original_PasswordParameter = original_Password != null ?
                new ObjectParameter("Original_Password", original_Password) :
                new ObjectParameter("Original_Password", typeof(string));
    
            var idParameter = id.HasValue ?
                new ObjectParameter("Id", id) :
                new ObjectParameter("Id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<UsuariosUpdate_Result>("UsuariosUpdate", idRolParameter, idTutorParameter, emailParameter, passwordParameter, original_IdParameter, isNull_IdRolParameter, original_IdRolParameter, isNull_IdTutorParameter, original_IdTutorParameter, original_EmailParameter, original_PasswordParameter, idParameter);
        }
    }
}