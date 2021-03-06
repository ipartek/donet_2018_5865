﻿using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

using System.Linq;

using Tipos;

namespace EjemploBBDD
{
    class Program
    {
        private static string CADENA_CONEXION = @"Data Source=.\SQLEXPRESS;Initial Catalog=ipartek;Integrated Security=True";
        private const string FILE_NAME = @"ExportacionDataTableUsuarios.xml";

        static void Main()
        {
            using (DbConnection con = new SqlConnection(CADENA_CONEXION))
            {
                con.Open();

                using (DbCommand com = con.CreateCommand())
                {
                    com.CommandText = "RolesInsertar"; //Nombre del procedimiento
                    com.CommandType = CommandType.StoredProcedure; //Declaro que llamo a un procedimiento

                    DbParameter parIdGenerado = com.CreateParameter();

                    parIdGenerado.Direction = ParameterDirection.Output; //Tipo OUTPUT
                    parIdGenerado.DbType = DbType.Int32;
                    parIdGenerado.ParameterName = "@Id"; //Parámetro del procedimiento

                    com.Parameters.Add(parIdGenerado);

                    parIdGenerado.Value = 1;

                    DbParameter parNombre = com.CreateParameter();
                    parNombre.DbType = System.Data.DbType.String;
                    parNombre.ParameterName = "@Rol";
                    parNombre.Value = "NUEVOROL";

                    com.Parameters.Add(parNombre);
                    
                    DbParameter parDescripcion = com.CreateParameter();
                    parDescripcion.DbType = System.Data.DbType.String;
                    parDescripcion.ParameterName = "@Descripcion";
                    parDescripcion.Value = "Descripción del rol nuevo";

                    com.Parameters.Add(parDescripcion);

                    com.ExecuteNonQuery();

                    Console.WriteLine(parIdGenerado.Value);
                }
            }
        }

        static void MainProcedimientoAlmacenadoTipoInput()
        {
            using (DbConnection con = new SqlConnection(CADENA_CONEXION))
            {
                con.Open();

                using (DbCommand com = con.CreateCommand())
                {
                    com.CommandText = "EntradasDeBlogPorUsuarioPorId"; //Nombre del procedimiento
                    com.CommandType = CommandType.StoredProcedure; //Declaro que llamo a un procedimiento

                    DbParameter parId = com.CreateParameter();

                    //parId.Direction = ParameterDirection.Input;
                    parId.DbType = DbType.Int32;
                    parId.ParameterName = "@IdUsuario"; //Parámetro del procedimiento

                    com.Parameters.Add(parId);

                    parId.Value = 1;

                    using (DbDataReader dr = com.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine($"{dr["Fecha"]}, {dr["Titulo"]}, {dr["Texto"]}");
                        }
                    }
                }
            }
        }

        static void MainNullablesYDateTime()
        {
            //Nullable<DateTime> dtn = null;
            DateTime? dtn = null;

            if (!dtn.HasValue)
                dtn = DateTime.Now;

            Console.WriteLine($"{dtn.Value.Hour}:{dtn.Value.Minute}");

            DateTime dt = dtn.Value;

            Console.WriteLine($"{dt.Hour}:{dt.Minute}");

            Console.WriteLine(dt.ToString("'Hoy es 'd' de 'MMMM' de 'yyyy"));
            Console.WriteLine(dt.ToString("hh:mm"));
            Console.WriteLine(dt.ToString("yyyy-MM-dd"));
            Console.WriteLine(dt.ToString("yyyy-MM-ddThh:mm"));
            Console.WriteLine(dt.ToString("f"));

            dtn = DateTime.Parse("2010-11-10");

            Console.WriteLine(dtn);
        }

        static void MainEntityDao()
        {
            string tipoDao = ConfigurationManager.AppSettings["usuariodao"];

            IUsuarioDao usuarioDao = FabricaDao.GetDaoUsuario(tipoDao); //new UsuarioEntityDao();
            IDao<Rol> rolDao = new RolEntityDao();

            Rol admin = new Rol(nombre: "ADMIN", descripcion: "Administradores");
            Rol user = new Rol(nombre: "USER", descripcion: "Usuarios");

            Usuario usuario1 = new Usuario("javier@email.net", "contra");
            usuario1.Rol = admin;

            Usuario usuario2 = new Usuario("pepe@email.net", "perez");

            usuarioDao.Insertar(usuario1);
            usuarioDao.Insertar(usuario2);

            Console.WriteLine("USUARIOS");

            foreach (Usuario usuario in usuarioDao.BuscarTodos())
            {
                Console.WriteLine(usuario);
            }

            Console.WriteLine("USUARIOS CON ROL");

            foreach (Usuario usuario in usuarioDao.BuscarTodosConRol())
            {
                Console.WriteLine(usuario);
            }

        }

        static void MainEntity()
        {
            using (var ctx = IpartekDbContext.GetInstance())
            {
                var usuario = new Usuario(email: "javier", password: "contra");

                ctx.Usuarios.Add(usuario); // INSERT INTO Usuarios ...
                ctx.Usuarios.Add(new Usuario("pepe", "perez"));

                ctx.SaveChanges();

                foreach (Usuario u in ctx.Usuarios.ToList()) // SELECT * FROM Usuarios
                {
                    Console.WriteLine(u);
                }

                usuario = ctx.Usuarios.Find(1); // SELECT * FROM Usuarios WHERE Id=2

                usuario.Password = "modificada"; // UPDATE Usuarios Set Password = 'modificada' WHERE Id=1 AND Email='javier' AND Password='contra'

                ctx.SaveChanges();

                ctx.Usuarios.Remove(ctx.Usuarios.Find(2)); // DELETE FROM Usuarios WHERE ID = 2 AND Email='pepe' AND Password='perez'

                var emailJavier = from u in ctx.Usuarios //SELECT Email, Password FROM Usuarios WHERE Email LIKE '%javier%'
                                  where u.Email.Contains("javier")
                                  select new { u.Email, u.Password };

                foreach (var u in emailJavier)
                {
                    Console.WriteLine(u);
                }

                Rol rol = new Rol(nombre: "ADMIN", descripcion: "Administradores");
                ctx.Roles.Add(rol);

                usuario.Rol = rol;

                ctx.SaveChanges();

                rol = new Rol(1, nombre: "PRUEBAS", descripcion: "Pruebas");

                Rol rolConectado = ctx.Roles.Find(rol.Id);

                //rolConectado = rol; //NO FUNCIONA PORQUE NO HACE CAMBIOS SOBRE LA REFERENCIA ORIGINAL

                //Mueve todos los datos de un objeto al otro
                ctx.Entry(rolConectado).CurrentValues.SetValues(rol);

                ctx.SaveChanges();

                Console.WriteLine(ctx.Roles.Find(1));

                //No funciona el Attach en el contexto
                //Usuario user = new Usuario(1, "pepe", "yepa");
                //user.Rol = new Rol(1);

                //ctx.Usuarios.Attach(user);
                //ctx.Entry(user).State = System.Data.Entity.EntityState.Modified;

                //ctx.SaveChanges();
            }
        }

        static void MainDataSetTipado()
        {
            EjemploBBDD.UsuariosDataTable dt = new EjemploBBDD.UsuariosDataTable();

            EjemploBBDDTableAdapters.UsuariosTableAdapter ta =
                new EjemploBBDDTableAdapters.UsuariosTableAdapter();

            ta.Fill(dt);

            foreach (EjemploBBDD.UsuariosRow usuariosRow in dt.Rows)
            {
                Console.WriteLine($"{usuariosRow.Email}, {usuariosRow.Password}");
            }
        }

        static void MainDataAdapter()
        {
            DataAdapter da = new SqlDataAdapter("SELECT * FROM Usuarios", CADENA_CONEXION);

            DataSet ds = new DataSet();

            da.Fill(ds); //Abre conexión, rellena el ds y cierra conexión

            ds.Tables[0].Rows[0]["Password"] = "modificada";

            //da.Update(ds); //Necesitamos UpdateCommand

            IEnumerable<DataRow> filas = from DataRow fila in ds.Tables[0].AsEnumerable()
                                         where ((string)fila["Email"]).Contains("javier")
                                         select fila;

            foreach (DataRow dataRow in filas)
            {
                Console.WriteLine($"{dataRow["Email"]}, {dataRow["Password"]}");
            }
        }

        static void MainDataSet()
        {
            DataSet ds = new DataSet();

            ds.ReadXml(FILE_NAME);

            foreach (DataRow dataRow in ds.Tables["Usuarios"].Rows)
            {
                Console.WriteLine($"{dataRow["Email"]}, {dataRow["Password"]}");
            }
        }

        static void MainDataTableWriteXml()
        {
            DataSet ds = new DataSet("EjemploBBDD");

            DataTable dt = new DataTable("Usuarios");
            dt.Columns.Add("Email", typeof(string));
            dt.Columns.Add(new DataColumn("Password", typeof(string)));

            DataRow dr = dt.NewRow();
            dr["Email"] = "javierlete@email.net";
            dr["Password"] = "contra";

            dt.Rows.Add(dr);

            ds.Tables.Add(dt);

            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine($"Fila: {dataRow["Email"]}, {dataRow["Password"]}");

                foreach (DataColumn dataColumn in dt.Columns)
                {
                    Console.Write($"{dataRow[dataColumn]} ");
                }

                Console.WriteLine();
            }

            ds.WriteXml(FILE_NAME, XmlWriteMode.WriteSchema);
        }

        static void MainTestDao()
        {
            IDao<Rol> dao = new RolSqlDao();

            foreach (Rol rol in dao.BuscarTodos())
            {
                Console.WriteLine(rol);
            }

            IUsuarioDao daoUsuario = new UsuarioSqlDao();

            foreach (Usuario usuario in daoUsuario.BuscarTodosConRol())
            {
                Console.WriteLine(usuario);
            }

            Console.WriteLine(daoUsuario.BuscarPorId(2));
        }

        static void MainAnterior()
        {
            try
            {
                try
                {
                    //IUsuarioDao usuarioDao = new UsuarioSqlDao(CADENA_CONEXION);
                    IDao<Usuario> usuarioDao = new UsuarioSqlDao(CADENA_CONEXION);

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
            using (DbDataReader dr = comSelect.ExecuteReader())
            {

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
