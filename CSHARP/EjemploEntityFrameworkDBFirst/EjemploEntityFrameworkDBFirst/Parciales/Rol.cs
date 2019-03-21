using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploEntityFrameworkDBFirst
{
    public partial class Rol
    {
        public override string ToString()
        {
            return $"{Id}, {Nombre}, {Descripcion}";
        }
    }
}
