using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace RepasoMVC.Models
{
    [Table("Roles")]
    public class Rol
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string NombreDescriptivo { get; set; }

        public ICollection<Usuario> Usuarios { get; set; }
    }
}