using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Tipos;

namespace EjemploBBDD
{
    class Program
    {
        static void Main()
        {
            try
            {
                string cadenaConexion = @"Data Source=DESKTOP-9GKENR5\SQLEXPRESS;Initial Catalog=ipartek;Integrated Security=True";

                try
                {
                    //IUsuarioDao usuarioDao = new UsuarioSqlDao(cadenaConexion);
                    IDao<Usuario> usuarioDao = new UsuarioSqlDao(cadenaConexion);

                    try
                    {
                        Usuario usuario = usuarioDao.BuscarPorId(14);

                        if (usuario == null)
                        {
                            Console.WriteLine("No se ha encontrado ese usuario");
                        }
                        else
                        {
                            Console.WriteLine(usuario);
                        }
                    }
                    catch (AccesoDatosException ade)
                    {
                        Console.WriteLine("Problema al buscar por Id");

                        Console.WriteLine(ade.Source);

                        Console.WriteLine(ade.InnerException.Source);
                        Console.WriteLine(ade.InnerException.Message);
                    }

                    try
                    {
                        Usuario usuario = ((IUsuarioDao)usuarioDao).BuscarPorEmail("javierlete@email.net");

                        if (usuario == null)
                        {
                            Console.WriteLine("No se ha encontrado ese usuario");
                        }
                        else
                        {
                            Console.WriteLine(usuario);
                        }
                    }
                    catch (AccesoDatosException ade)
                    {
                        Console.WriteLine("Problema al buscar por Email");

                        Console.WriteLine(ade.Source);

                        Console.WriteLine(ade.InnerException.Source);
                        Console.WriteLine(ade.InnerException.Message);
                    }

                    int id;

                    try
                    {
                        id = usuarioDao.Insertar(new Usuario("javierlete@email.net", "contra"));
                        MostrarTodos(usuarioDao);
                        Console.WriteLine(usuarioDao.Modificar(new Usuario(id, "modificado@email.net", "modificadocontra")));
                        MostrarTodos(usuarioDao);
                        Console.WriteLine(usuarioDao.Borrar(new Usuario(id, "", "")));
                        MostrarTodos(usuarioDao);
                    }
                    catch (AccesoDatosException)
                    {
                        Console.WriteLine("No se pudo realizar alguna modificación en el usuario");
                    }

                    
                }
                catch (AccesoDatosException ade)
                {
                    Console.WriteLine(ade.Message);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Error no esperado");
            }
        }

        private static void MostrarTodos(IDao<Usuario> usuarioDao)
        {
            try
            {
                List<Usuario> usuarios = usuarioDao.BuscarTodos();

                if (usuarios.Count == 0)
                {
                    Console.WriteLine("No se ha encontrado ningún usuario");
                }
                else
                {
                    foreach (Usuario u in usuarios)
                    {
                        Console.WriteLine(u);
                    }
                }

                Console.WriteLine("-----------------------------------------------------");
            }
            catch (AccesoDatosException)
            {
                Console.WriteLine("No se ha podido acceder a la lista de usuarios");
            }
        }

        private static DbConnection con;
        private static DbCommand comSelect;

        static void MainBasico(string[] args)
        {
            Inicializacion();

            con.Open();

            MostrarTabla();

            Insertar("Prueba", "Pruebez'); DELETE FROM usuarios; --");

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

        private static void Insertar(string email, string password)
        {
            DbCommand com = con.CreateCommand();
            //com.CommandText = $"INSERT INTO usuarios (Email, Password) VALUES ('{email}', '{password}')";
            com.CommandText = "INSERT INT usuarios (Email, Password) VALUES (@email, @password)";
            DbParameter parEmail = CrearParametro(DbType.String, "@email", email, com);

            DbParameter parPassword = com.CreateParameter();
            parPassword.DbType = DbType.String;
            parPassword.ParameterName = "@password";
            parPassword.Value = password;

            com.Parameters.Add(parPassword);

            int filasModificadas = com.ExecuteNonQuery();

            Console.WriteLine($"Se han insertado {filasModificadas} filas");
        }

        private static DbParameter CrearParametro(DbType tipo, string nombre, object valor, DbCommand com)
        {
            DbParameter parametro = com.CreateParameter();

            parametro.DbType = tipo;
            parametro.ParameterName = nombre;
            parametro.Value = valor;

            com.Parameters.Add(parametro);

            return parametro;
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
            using(DbDataReader dr = comSelect.ExecuteReader()) {

                while (dr.Read())
                {
                    //Console.WriteLine("{0}, {1}, {2}", dr["Id"], dr["Email"], dr["Password"]);
                    Console.WriteLine($"{dr["Id"]}, {dr["Email"]}, {dr["Password"]}");
                }

                //dr.Close(); //Al usar el using, los cierres son implícitos
            }

            Console.WriteLine("---------------------------------------------------");
            
        }
    }
}
