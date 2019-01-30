using System;
//csc /t:library Usuario.cs /out:Tipos.dll

namespace Tipos
{
    public class Usuario
    {
        protected const string EMAIL_POR_DEFECTO = "desconocido@desconocidez.com";
        //Variables estáticas / de clase / compartidas
        private static string passwordPorDefecto = "Cámbiala";

        //Propiedad estática / de clase / compartida
        public static string PasswordPorDefecto
        {
            get { return passwordPorDefecto; }
            set { passwordPorDefecto = value; }
        }

        //Variables de instancia / Campos / Fields
        private string email;

        //Constructores
        public Usuario(string email = EMAIL_POR_DEFECTO, string password = null)
        {
            Email = email;
            Password = password;

            Console.WriteLine("Constructor completo");
            Console.WriteLine(email);
            Console.WriteLine(password);
        }
        
        public Usuario() : this(EMAIL_POR_DEFECTO, passwordPorDefecto)
        {
            Console.WriteLine("Constructor vacío");
        }

        //DESTRUCTOR
        ~Usuario()
        {
            Console.WriteLine("Destructor");
        }
        
        //Propiedad "automática" que genera la variable y los accesos
        public string Password { get; set; }
        public Dni Dni { get; set; }

        //Métodos de acceso
        public string GetEmail()
        {
            return email;
        }

        public void SetEmail(string email)
        {
            this.email = email;
        }

        //Propiedad
        public string Email
        {
            //Acceso get
            get { return email; }
            //Acceso set
            set { email = value; }
        }

        //Método de instancia
        public string GetTexto()
        {
            return string.Format("Email: {0}, Password: {1}", Email, Password);
        }

        public enum Formatos
        {
            Bonito,
            Compacto
        }

        //Sobrecargas
        public string GetTexto(string formato)
        {
            switch (formato)
            {
                case "bonito":
                    return GetTexto();
                case "compacto":
                    return string.Format("{0},{1}", Email, Password);
                default:
                    return GetTexto();
            }
        }

        public string GetTexto(Formatos formato)
        {
            switch (formato)
            {
                case Formatos.Bonito:
                    return GetTexto("bonito");
                case Formatos.Compacto:
                    return GetTexto("compacto");
                default:
                    return GetTexto();
            }
        }

        //Sobrecarga de operadores
        public static bool operator>(Usuario u1, Usuario u2)
        {
            return u1.Email.CompareTo(u2.Email) > 0;
        }

        public static bool operator<(Usuario u1, Usuario u2)
        {
            return u1.Email.CompareTo(u2.Email) < 0;
        }


    }
}
