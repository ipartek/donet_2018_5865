using System;
using System.Collections.Generic;
using System.Linq;

namespace Tipos
{
    public class Grupo
    {
        private List<Usuario> usuarios = new List<Usuario>();

        public string Nombre { get; set; }

        public Grupo(string nombre)
        {
            Nombre = nombre;
        }

        public void Add(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new Exception("No se admiten usuarios nulos");
            }

            usuarios.Add(usuario);
        }

        public Usuario FindByEmail(string email)
        {
            //Expresión Lambda
            return usuarios.Find(u => u.Email == email);

            /*
            foreach(Usuario usuario in usuarios)
            {
                if(usuario.Email == email)
                {
                    return usuario;
                }
            }
            */
            /*
            return (from u in usuarios
                    where u.Email == email
                    select u).First<Usuario>();
            */
        }

        public void Remove(Usuario usuario)
        {
            if (usuario == null)
            {
                throw new Exception("No se admiten usuarios nulos");
            }

            usuarios.Remove(usuario);
        }
    }
}
