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
            Rol user = new Rol() { Codigo = "USER", NombreDescriptivo = "Usuario" };

            context.Roles.AddRange(new[] { admin, user });
            context.SaveChanges();
            
            context.Usuarios.AddRange(new[] {
                new Usuario()
                {
                    Email = "javierlete@email.net",
                    Password = "contra",
                    Rol = admin
                },
                new Usuario()
                {
                    Email = "pepe@perez.net",
                    Password = "perez",
                    Rol = user
                }
            });

            context.SaveChanges();
        }
    }
}