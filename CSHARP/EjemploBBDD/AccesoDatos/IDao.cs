using System.Collections.Generic;

namespace AccesoDatos
{
    public interface IDao<T>
    {
        int Insertar(T tipo);
        int Modificar(T tipo);
        int Borrar(T tipo);
        int Borrar(int id);
        List<T> BuscarTodos();
        T BuscarPorId(int id);
    }
}
