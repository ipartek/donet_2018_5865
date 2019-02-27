using System.Collections.Generic;

namespace AccesoDatos
{
    public interface IDao<T>
    {
        long Insertar(T tipo);
        long Modificar(T tipo);
        long Borrar(T tipo);
        long Borrar(long id);
        List<T> BuscarTodos();
        T BuscarPorId(long id);
    }
}
