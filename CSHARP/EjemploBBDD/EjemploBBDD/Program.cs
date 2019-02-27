using System;
using System.Data.Common;
using System.Data.SqlClient;

namespace EjemploBBDD
{
    class Program
    {
        private static DbConnection con;
        private static DbCommand comSelect;

        static void Main(string[] args)
        {
            Inicializacion();

            con.Open();

            MostrarTabla();

            Insertar();

            MostrarTabla();

            Modificar();

            MostrarTabla();

            Borrar();

            MostrarTabla();

            con.Close();
        }

        private static void Borrar()
        {
            DbCommand com = con.CreateCommand();
            com.CommandText = "DELETE FROM usuarios WHERE Email='Yepa'";
            int filasModificadas = com.ExecuteNonQuery();

            Console.WriteLine($"Se han borrado {filasModificadas} filas");
        }

        private static void Modificar()
        {
            DbCommand com = con.CreateCommand();
            com.CommandText = "UPDATE usuarios Set Email='Yepa', Password='Yepez' WHERE Email='Prueba'";
            int filasModificadas = com.ExecuteNonQuery();

            Console.WriteLine($"Se han modificado {filasModificadas} filas");
        }

        private static void Insertar()
        {
            DbCommand com = con.CreateCommand();
            com.CommandText = "INSERT INTO usuarios (Email, Password) VALUES ('Prueba', 'Pruebez')";
            int filasModificadas = com.ExecuteNonQuery();

            Console.WriteLine($"Se han insertado {filasModificadas} filas");
        }

        private static void Inicializacion()
        {
            string cadenaConexion = @"Data Source=DESKTOP-9GKENR5\SQLEXPRESS;Initial Catalog=ipartek;Integrated Security=True";
            con = new SqlConnection(cadenaConexion);

            string sql = "SELECT * FROM usuarios";
            comSelect = con.CreateCommand();
            comSelect.CommandText = sql;
        }

        private static void MostrarTabla()
        {
            DbDataReader dr = comSelect.ExecuteReader();

            while (dr.Read())
            {
                //Console.WriteLine("{0}, {1}, {2}", dr["Id"], dr["Email"], dr["Password"]);
                Console.WriteLine($"{dr["Id"]}, {dr["Email"]}, {dr["Password"]}");
            }

            dr.Close();

            Console.WriteLine("---------------------------------------------------");
        }
    }
}
