using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjemploEntityFrameworkDBFirst
{
    public partial class Usuario
    {
        public override string ToString()
        {
            return $"{Id}, {Email}, {Password}, {Rol}, {Tutor}";
        }

        public string Email
        {
            get
            {
                Console.WriteLine("Getter Email");
                return EmailPrivado;
            }
            set
            {
                Console.WriteLine("Setter Email");
                EmailPrivado = value;
            }
        }
    }
}
