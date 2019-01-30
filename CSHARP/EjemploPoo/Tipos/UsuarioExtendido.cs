using System;

namespace Tipos
{
    public class UsuarioExtendido : Usuario
    {
        private const string NOMBRE_POR_DEFECTO = "DESCONOCIDO";

        public string Nombre { get; set; }

        public UsuarioExtendido(string nombre, string email, string password) : base(email, password)
        {
            Nombre = nombre;
        }

        public UsuarioExtendido(string nombre) : this(nombre, EMAIL_POR_DEFECTO, PasswordPorDefecto) { }

        public UsuarioExtendido() : this(NOMBRE_POR_DEFECTO, EMAIL_POR_DEFECTO, PasswordPorDefecto) { }

        //public UsuarioExtendido():base() { }

        public override string GetTexto()
        {
            return string.Format("Nombre: {0}, {1}", Nombre, base.GetTexto());
        }
    }
}
