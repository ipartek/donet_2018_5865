using System;
using System.Text.RegularExpressions;

namespace Tipos
{
    public class Usuario
    {
        public long Id { get; set; }
        private string email;

        public string Email {
            get { return email; }
            // public void set_Email(string value){
            set
            {
                if(value == null)
                {
                    throw new TiposException("No se admiten emails nulos");
                }

                if(value.Trim().Length == 0)
                {
                    throw new TiposException("Es obligatorio rellenar el email");
                }

                if (!Regex.IsMatch(value.Trim(), @"^\w+@\w+\.\w+$"))
                {
                    throw new TiposException("El email introducido no es válido");
                }

                email = value.Trim();
            }
        }
        public string Password { get; set; }

        public Usuario(long id, string email, string password)
        {
            Id = id;
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Password = password ?? throw new ArgumentNullException(nameof(password));
        }

        public Usuario(string email, string password) : this(0, email, password) { }

        public Usuario() { }

        public override string ToString() => $"{Id}, {Email}, {Password}";
    }
}
