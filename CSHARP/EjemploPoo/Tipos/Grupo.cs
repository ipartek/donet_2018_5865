using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        private ReadOnlyCollection<Usuario> GetUsuarios()
        {
            return new ReadOnlyCollection<Usuario>(usuarios);
        }

        public ReadOnlyCollection<Usuario> Usuarios
        {
            get { return GetUsuarios(); }
        }

        //Indizador / Indexador
        public Usuario this[int i]
        {
            get { return usuarios[i]; }
            set { usuarios[i] = value; }
        }

        public Usuario this[string email]
        {
            get { return FindByEmail(email); }
            set
            {
                usuarios[usuarios.IndexOf(FindByEmail(email))] = value;
            }
        }
    }
}
