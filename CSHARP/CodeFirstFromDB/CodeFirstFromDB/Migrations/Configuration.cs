namespace CodeFirstFromDB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeFirstFromDB.IpartekModel>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(CodeFirstFromDB.IpartekModel context)
        {
            //  This method will be called after migrating to the latest version.

            context.Roles.AddOrUpdate(
                new Rol()
                {
                    Id = 1,
                    Nombre = "Pruebas",
                    Descripcion = "Pruebas de Rol",
                    Borrado = false,
                    Notas = "Notas del rol"
                });
        }
    }
}
