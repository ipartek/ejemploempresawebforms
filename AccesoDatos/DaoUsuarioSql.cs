using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace AccesoDatos
{
    public class DaoUsuarioSql : IDaoUsuario
    {
        private string cadenaConexion;

        public DaoUsuarioSql(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public string ObtenerNombre(int idUsuario)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();

                    IDbCommand com = con.CreateCommand();
                    com.CommandText = "SELECT e.Nombre FROM Usuarios u INNER JOIN Empleados e ON e.Id = u.IdEmpleado WHERE u.Id=@Id";

                    IDbDataParameter parId = com.CreateParameter();
                    parId.DbType = DbType.String;
                    parId.ParameterName = "Id";
                    com.Parameters.Add(parId);

                    parId.Value = idUsuario;

                    return (string)com.ExecuteScalar();
                }
            }
            catch (Exception e)
            {
                throw new DaoException("No se ha podido consultar el usuario: " + e.Message, e);
            }
        }

        public Usuario ObtenerPorNick(string nick)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();

                    IDbCommand com = con.CreateCommand();
                    com.CommandText = "SELECT Id, Nick, Password, IdEmpleado FROM Usuarios WHERE Nick=@Nick";

                    IDbDataParameter parNick = com.CreateParameter();
                    parNick.DbType = DbType.String;
                    parNick.ParameterName = "Nick";
                    com.Parameters.Add(parNick);

                    parNick.Value = nick;

                    IDataReader dr = com.ExecuteReader();

                    Usuario usuario = null;

                    if (dr.Read())
                    {
                        usuario = new Usuario()
                        {
                            Id = dr.GetInt32(0),
                            Nick = dr.GetString(1),
                            Password = dr.GetString(2),
                            IdEmpleado = dr.GetInt32(3)
                        };
                    }

                    return usuario;
                }
            }
            catch (Exception e)
            {
                throw new DaoException("No se ha podido consultar los usuarios: " + e.Message, e);
            }
        }
    }
}
