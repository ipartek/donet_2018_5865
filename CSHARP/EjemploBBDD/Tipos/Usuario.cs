﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//csc /t:library Usuario.cs /out:Tipos.dll

namespace Tipos
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }

        [NotMapped]
        public int IdRol
        {
            get { return Rol == null ? Rol.ID_POR_DEFECTO : Rol.Id; }
            set {
                if (Rol != null)
                {
                    Rol.Id = value;
                }
                else
                {
                    Rol = new Rol(value);
                }
            }
        }

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
