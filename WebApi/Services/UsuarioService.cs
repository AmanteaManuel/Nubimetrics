using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using WebApi.Models;
using WebApi.Request;

namespace WebApi.Services
{
    public static class UsuarioService
    {

        #region " Querys "

        //query para obtener todos los usuarios
        private const string GET_ALL = @"SELECT * FROM [User]";

        //query para obtener un usuario especifico por ID
        private const string GET_BY_ID = @"SELECT * FROM [User] WHERE Id= @Id";

        private const string CREATE = @"INSERT INTO [User] VALUES(@Nombre, @Apellido, @Email, @Password) SELECT SCOPE_IDENTITY()";

        private const string DELETE = @"DELETE FROM [User] WHERE Id=@userId";

        private const string UPDATE = @"UPDATE [User] SET Nombre=@Nombre, Apellido=@Apellido, Email=@Email,Password=@Password WHERE Id=@Id";

        #endregion

        /// <summary>
        /// Retorna todos los usuario
        /// </summary>
        /// <returns></returns>
        public static List<Usuario> GetAllUsers()
        {
            //instancio la lista de usuario a retornar
            List<Usuario> usuarios = new List<Usuario>();

            //obtengo el conecction string
            string constr = ConfigurationManager.ConnectionStrings["DefaultConecction"].ConnectionString;

            //creo la coneccion e inserto query a ejecutar
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(GET_ALL))
                {
                    cmd.Connection = con;
                    con.Open();

                    //cargo los datos en la lista de retorno
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            usuarios.Add(new Usuario
                            {
                                Id = Convert.ToInt32(sdr["Id"]),
                                Nombre = Convert.ToString(sdr["Nombre"]),
                                Apellido = Convert.ToString(sdr["Apellido"]),
                                Email = Convert.ToString(sdr["Email"]),
                                Password = Convert.ToString(sdr["Password"])
                            });
                        }
                    }
                    //cierro conexion
                    con.Close();
                }
            }
            //si la lista
            if (usuarios.Count == 0)
                return null;
            else
                return usuarios;
        }

        /// <summary>
        /// retorna un solo usuario segun su id o null en caso que no exista
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Usuario GetUserById(int id)
        {
            //instancio el obj a retornar
            Usuario usuario = new Usuario();

            //obtengo el conecction string
            string constr = ConfigurationManager.ConnectionStrings["DefaultConecction"].ConnectionString;

            //creo la coneccion e inserto query a ejecutar
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(GET_BY_ID))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        sdr.Read();

                        //si la lectura tiene datos los cargos
                        if (sdr.HasRows)
                        {
                            usuario.Id = Convert.ToInt32(sdr["Id"]);
                            usuario.Nombre = Convert.ToString(sdr["Nombre"]);
                            usuario.Apellido = Convert.ToString(sdr["Apellido"]);
                            usuario.Email = Convert.ToString(sdr["Email"]);
                            usuario.Password = Convert.ToString(sdr["Password"]);
                        }
                        else //si no hay datos retorno null
                            usuario = null;
                    }
                    con.Close();
                }
            }
            
            //retorno
            return usuario;
        }

        public static int CreateUser(ReqCreateUsuario user)
        {
            //obtengo conecction string
            string constr = ConfigurationManager.ConnectionStrings["DefaultConecction"].ConnectionString;           
            int insertedId;

            //creo la coneccion e inserto query a ejecutar
            using (SqlConnection con = new SqlConnection(constr))
            {
                
                using (SqlCommand cmd = new SqlCommand(CREATE))
                {
                    //cargo datos a insertar
                    cmd.Parameters.AddWithValue("@Nombre", user.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", user.Apellido );
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Connection = con;
                    con.Open();
                    insertedId = Convert.ToInt32(cmd.ExecuteScalar());
                    con.Close();
                }
            }

            //retorno el id insertado
            return insertedId;
        }

        /// <summary>
        /// metodo que modifica un usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool UpdateUser(ReqUpdateUsuario user)
        {
            //obtengo conecction string
            string constr = ConfigurationManager.ConnectionStrings["DefaultConecction"].ConnectionString;

            //creo la conexion e inserto la query
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(UPDATE))
                {
                    //obtengo el usuario de la bd para verificar su exitencia, si no existe retorno false
                    if (GetUserById(user.Id) == null) return false;

                    //cargo los parametros a modificar
                    cmd.Parameters.AddWithValue("@Id", user.Id);
                    cmd.Parameters.AddWithValue("@Nombre", user.Nombre);
                    cmd.Parameters.AddWithValue("@Apellido", user.Apellido);
                    cmd.Parameters.AddWithValue("@Email", user.Email);
                    cmd.Parameters.AddWithValue("@Password", user.Password);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            //si salio todo ok retrono true
            return true;
        }

        /// <summary>
        /// metodo que elimina fisicamente un usuario del sistema
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public static bool DeleteUsuario(int userId)
        {
            //obtengo conecction string
            string constr = ConfigurationManager.ConnectionStrings["DefaultConecction"].ConnectionString;

            //creo la conexion y inserto la query a ejecutar
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(DELETE))
                {
                    //obtengo el usuario de la bd para verificar su exitencia, si no existe retorno false
                    if (GetUserById(userId) == null) return false;

                    cmd.Parameters.AddWithValue("@userId", userId);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            //si salio todo ok retorno true
            return true;
        }
    }
}