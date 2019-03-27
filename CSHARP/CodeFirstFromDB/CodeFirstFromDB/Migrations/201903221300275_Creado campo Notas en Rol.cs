namespace CodeFirstFromDB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreadocampoNotasenRol : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntradasBlog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titulo = c.String(nullable: false, maxLength: 50),
                        Texto = c.String(nullable: false, unicode: false, storeType: "text"),
                        Fecha = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdRol = c.Int(),
                        IdTutor = c.Int(),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.IdRol)
                .ForeignKey("dbo.Usuarios", t => t.IdTutor)
                .Index(t => t.IdRol)
                .Index(t => t.IdTutor);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rol = c.String(nullable: false, maxLength: 10, unicode: false),
                        Descripcion = c.String(maxLength: 50),
                        Borrado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RolesActivos",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Rol = c.String(nullable: false, maxLength: 10, unicode: false),
                        Borrado = c.Boolean(nullable: false),
                        Descripcion = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => new { t.Id, t.Rol, t.Borrado });
            
            CreateTable(
                "dbo.UsuariosDeRolUser",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 50, unicode: false),
                        Password = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => new { t.Id, t.Email, t.Password });
            
            CreateTable(
                "dbo.UsuariosEntradasBlog",
                c => new
                    {
                        IdEntradaBlog = c.Int(nullable: false),
                        IdUsuarios = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.IdEntradaBlog, t.IdUsuarios })
                .ForeignKey("dbo.EntradasBlog", t => t.IdEntradaBlog, cascadeDelete: true)
                .ForeignKey("dbo.Usuarios", t => t.IdUsuarios, cascadeDelete: true)
                .Index(t => t.IdEntradaBlog)
                .Index(t => t.IdUsuarios);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UsuariosEntradasBlog", "IdUsuarios", "dbo.Usuarios");
            DropForeignKey("dbo.UsuariosEntradasBlog", "IdEntradaBlog", "dbo.EntradasBlog");
            DropForeignKey("dbo.Usuarios", "IdTutor", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "IdRol", "dbo.Roles");
            DropIndex("dbo.UsuariosEntradasBlog", new[] { "IdUsuarios" });
            DropIndex("dbo.UsuariosEntradasBlog", new[] { "IdEntradaBlog" });
            DropIndex("dbo.Usuarios", new[] { "IdTutor" });
            DropIndex("dbo.Usuarios", new[] { "IdRol" });
            DropTable("dbo.UsuariosEntradasBlog");
            DropTable("dbo.UsuariosDeRolUser");
            DropTable("dbo.RolesActivos");
            DropTable("dbo.Roles");
            DropTable("dbo.Usuarios");
            DropTable("dbo.EntradasBlog");
        }
    }
}
