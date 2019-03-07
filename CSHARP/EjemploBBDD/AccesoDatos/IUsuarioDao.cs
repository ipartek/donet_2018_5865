using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tipos;

namespace AccesoDatos
{
    public interface IUsuarioDao : IDao<Usuario>
    {
        Usuario BuscarPorEmail(string email);
        List<Usuario> BuscarTodosConRol();
    }
}
