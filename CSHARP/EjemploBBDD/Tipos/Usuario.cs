using System;
//csc /t:library Usuario.cs /out:Tipos.dll

namespace Tipos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public Rol Rol { get; set; }

        public Usuario() { }

        public Usuario(int id, string email, string password)
        {
            Id = id;
            Email = email; //?? throw new ArgumentNullException(nameof(email));
            Password = password; //?? throw new ArgumentNullException(nameof(password));
        }

        public Usuario(string email, string password) : this(0, email, password) { }

        public override string ToString() => $"{Id}, {Email}, {Password}, {Rol}";
    }
}
