using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tipos
{
    [Table("Roles")]
    public class Rol
    {
        public const int ID_POR_DEFECTO = -1;

        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }

        public Rol(int id = ID_POR_DEFECTO, string nombre = null, string descripcion = null)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
        }

        public Rol() : this(ID_POR_DEFECTO) { }

        public override string ToString() => $"{Id}, {Nombre}, {Descripcion}";
    }
}
