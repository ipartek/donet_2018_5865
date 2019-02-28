using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

using Tipos;

namespace AccesoDatos
{
    public class UsuarioSqlDao : IUsuarioDao
    {
        private string cadenaConexion;

        public UsuarioSqlDao(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public int Borrar(Usuario usuario)
        {
            return ConsultaDeModificacionDeTabla(usuario, "DELETE FROM usuarios WHERE Id=@id;");
            /*
            return Borrar(usuario.Id);
            */
        }

        public int Borrar(int id)
        {
            return Borrar(new Usuario(id, null, null));

            /*
            try
            {
                using (DbConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    DbCommand comando = conexion.CreateCommand();
                    comando.CommandText = "DELETE FROM usuarios WHERE Id=@id;";

                    DbParameter parId = comando.CreateParameter();
                    parId.DbType = System.Data.DbType.Int32;
                    parId.ParameterName = "@id";
                    parId.Value = id;

                    comando.Parameters.Add(parId);

                    int filasModificadas = comando.ExecuteNonQuery();

                    if (filasModificadas != 1)
                    {
                        throw new AccesoDatosException("Se han borrado más de una fila");
                    }

                    return filasModificadas;
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException(e.Message, e);
            }
            */
        }

        public Usuario BuscarPorEmail(string email)
        {
            return ConsultaDeUnaFila(
                "SELECT Id, Email, Password FROM usuarios WHERE Email = @email", 
                new Usuario(email, null));
            /*
            Usuario usuario = null;

            try
            {
                using (DbConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    DbCommand comando = conexion.CreateCommand();
                    comando.CommandText = "SELECT Id, Email, Password FROM usuarios WHERE Email = @email";

                    DbParameter parEmail = comando.CreateParameter();
                    parEmail.DbType = System.Data.DbType.String;
                    parEmail.ParameterName = "@email";
                    parEmail.Value = email;

                    comando.Parameters.Add(parEmail);

                    using (DbDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new Usuario(dr.GetInt32(0), dr.GetString(1), dr.GetString(2));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException(e.Message, e);
            }

            return usuario;
            */
        }

        public Usuario BuscarPorId(int id)
        {
            return ConsultaDeUnaFila(
                "SELECT Id, Email, Password FROM usuarios WHERE Id = @id",
                new Usuario(id, null, null));
            /*
            Usuario usuario = null;

            try
            {
                using (DbConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    DbCommand comando = conexion.CreateCommand();
                    comando.CommandText = "SELECT Id, Email, Password FROM usuarios WHERE Id = @id";

                    DbParameter parId = comando.CreateParameter();
                    parId.DbType = System.Data.DbType.Int32;
                    parId.ParameterName = "@id";
                    parId.Value = id;

                    comando.Parameters.Add(parId);

                    using (DbDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            usuario = new Usuario(dr.GetInt32(0), dr.GetString(1), dr.GetString(2));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException(e.Message, e);
            }

            return usuario;
            */
        }

        public List<Usuario> BuscarTodos()
        {
            return ConsultaDeDatosMultiples("SELECT Id, Email, Password FROM usuarios");
            /*
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                using (DbConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    DbCommand comando = conexion.CreateCommand();
                    comando.CommandText = "SELECT Id, Email, Password FROM usuarios";

                    using (DbDataReader dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            usuarios.Add(new Usuario(dr.GetInt32(0), dr.GetString(1), dr.GetString(2)));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException(e.Message, e);
            }

            return usuarios;
            */
        }

        public int Insertar(Usuario usuario)
        {
            return ConsultaDeModificacionDeTabla(usuario, 
                "INSERT INTO usuarios (Email, Password) VALUES (@email, @password); " +
                "SELECT CAST(SCOPE_IDENTITY() AS int);");
            /*
            try
            {
                using (DbConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    DbCommand comando = conexion.CreateCommand();
                    comando.CommandText = "INSERT INTO usuarios (Email, Password) VALUES (@email, @password); SELECT CAST(SCOPE_IDENTITY() AS int);";

                    DbParameter parEmail = comando.CreateParameter();
                    parEmail.DbType = System.Data.DbType.String;
                    parEmail.ParameterName = "@email";
                    parEmail.Value = usuario.Email;

                    comando.Parameters.Add(parEmail);

                    DbParameter parPassword = comando.CreateParameter();
                    parPassword.DbType = System.Data.DbType.String;
                    parPassword.ParameterName = "@password";
                    parPassword.Value = usuario.Password;

                    comando.Parameters.Add(parPassword);

                    int idGenerado = (int)comando.ExecuteScalar();

                    //if(filasModificadas != 1)
                    //{
                    //    throw new AccesoDatosException("Se han modificado más de una fila");
                    //}

                    return idGenerado;
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException(e.Message, e);
            }
            */
        }

        public int Modificar(Usuario usuario)
        {
            return ConsultaDeModificacionDeTabla(usuario,
                "UPDATE usuarios SET Email=@email, Password=@password WHERE Id=@id;");
            /*
            try
            {
                using (DbConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    DbCommand comando = conexion.CreateCommand();
                    comando.CommandText = "UPDATE usuarios SET Email=@email, Password=@password WHERE Id=@id;";

                    DbParameter parEmail = comando.CreateParameter();
                    parEmail.DbType = System.Data.DbType.String;
                    parEmail.ParameterName = "@email";
                    parEmail.Value = usuario.Email;

                    comando.Parameters.Add(parEmail);

                    DbParameter parPassword = comando.CreateParameter();
                    parPassword.DbType = System.Data.DbType.String;
                    parPassword.ParameterName = "@password";
                    parPassword.Value = usuario.Password;

                    comando.Parameters.Add(parPassword);

                    DbParameter parId = comando.CreateParameter();
                    parId.DbType = System.Data.DbType.Int32;
                    parId.ParameterName = "@id";
                    parId.Value = usuario.Id;

                    comando.Parameters.Add(parId);

                    int filasModificadas = comando.ExecuteNonQuery();

                    if (filasModificadas != 1)
                    {
                        throw new AccesoDatosException("Se han modificado más de una fila");
                    }

                    return filasModificadas;
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException(e.Message, e);
            }
            */
        }

        private int ConsultaDeModificacionDeTabla(Usuario usuario, string sql)
        {
            try
            {
                using (DbConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    DbCommand comando = conexion.CreateCommand();
                    comando.CommandText = sql; //"INSERT INTO usuarios (Email, Password) VALUES (@email, @password); SELECT CAST(SCOPE_IDENTITY() AS int);";

                    DbParameter parId = comando.CreateParameter();
                    parId.DbType = System.Data.DbType.Int32;
                    parId.ParameterName = "@id";
                    parId.Value = usuario.Id;

                    comando.Parameters.Add(parId);

                    DbParameter parEmail = comando.CreateParameter();
                    parEmail.DbType = System.Data.DbType.String;
                    parEmail.ParameterName = "@email";
                    parEmail.Value = usuario.Email;

                    comando.Parameters.Add(parEmail);

                    DbParameter parPassword = comando.CreateParameter();
                    parPassword.DbType = System.Data.DbType.String;
                    parPassword.ParameterName = "@password";
                    parPassword.Value = usuario.Password;

                    comando.Parameters.Add(parPassword);

                    int valor;

                    if (sql.Contains("INSERT") && sql.Contains("SELECT"))
                    {
                        valor = (int)comando.ExecuteScalar();
                    }
                    else
                    {
                        valor = comando.ExecuteNonQuery();

                        if (valor != 1)
                        {
                            throw new AccesoDatosException("Se han modificado más de una fila");
                        }
                    }

                    return valor;
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException(e.Message, e);
            }
        }

        private List<Usuario> ConsultaDeDatosMultiples(string sql, Usuario usuario = null)
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                using (DbConnection conexion = new SqlConnection(cadenaConexion))
                {
                    conexion.Open();

                    DbCommand comando = conexion.CreateCommand();
                    comando.CommandText = sql; //"SELECT Id, Email, Password FROM usuarios";

                    if (usuario != null)
                    {
                        DbParameter parId = comando.CreateParameter();
                        parId.DbType = System.Data.DbType.Int32;
                        parId.ParameterName = "@id";
                        parId.Value = usuario.Id;

                        comando.Parameters.Add(parId);

                        DbParameter parEmail = comando.CreateParameter();
                        parEmail.DbType = System.Data.DbType.String;
                        parEmail.ParameterName = "@email";
                        parEmail.Value = usuario.Email;

                        comando.Parameters.Add(parEmail);

                        DbParameter parPassword = comando.CreateParameter();
                        parPassword.DbType = System.Data.DbType.String;
                        parPassword.ParameterName = "@password";
                        parPassword.Value = usuario.Password;

                        comando.Parameters.Add(parPassword);
                    }

                    using (DbDataReader dr = comando.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            usuarios.Add(new Usuario(dr.GetInt32(0), dr.GetString(1), dr.GetString(2)));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new AccesoDatosException(e.Message, e);
            }

            return usuarios;
        }

        private Usuario ConsultaDeUnaFila(string sql, Usuario usuario = null)
        {
            List<Usuario> usuarios = ConsultaDeDatosMultiples(sql, usuario);

            switch(usuarios.Count)
            {
                case 1:
                    return usuarios[0];
                case 0:
                    return null;
                default:
                    throw new AccesoDatosException("Se ha recibido más de un resultado en una consulta de un resultado");
            }
        }

    }
}
