using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace RepasoMVC.Models
{
    public class RepasoMVCContextInicializador: DropCreateDatabaseIfModelChanges<RepasoMVCContext>
    {
        protected override void Seed(RepasoMVCContext context)
        {
            Rol admin = new Rol() { Codigo = "ADMIN", NombreDescriptivo = "Administrador" };
            context.Roles.Add(admin);
            context.SaveChanges();

            context.Usuarios.Add(new Usuario()
                {
                    Email = "javierlete@email.net",
                    Password = "contra",
                    Rol = admin
                }
            );

            context.SaveChanges();
        }
    }
}