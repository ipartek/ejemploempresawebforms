using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace AccesoDatos
{
    public class DaoDepartamentoSql : IDaoDepartamento
    {
        private string cadenaConexion;

        public DaoDepartamentoSql(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public Departamento ObtenerPorId(int idDepartamento)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(cadenaConexion))
                {
                    IDbCommand com = con.CreateCommand();
                    com.CommandText = "SELECT Id, Nombre FROM Departamentos WHERE Id=@Id";

                    IDbDataParameter parId = com.CreateParameter();
                    parId.DbType = DbType.Int32;
                    parId.ParameterName = "Id";
                    com.Parameters.Add(parId);

                    parId.Value = idDepartamento;

                    IDataReader dr = com.ExecuteReader();

                    Departamento departamento = null;

                    if (dr.Read())
                    {
                        departamento = new Departamento()
                        {
                            Id = dr.GetInt32(0),
                            Nombre = dr.GetString(1),
                        };
                    }

                    return departamento;
                }
            }
            catch (Exception e)
            {
                throw new DaoException("No se ha podido consultar el departamento: " + e.Message, e);
            }
        }

        public List<Departamento> ObtenerTodos()
        {
            try
            {
                using (IDbConnection con = new SqlConnection(cadenaConexion))
                {
                    IDbCommand com = con.CreateCommand();
                    com.CommandText = "SELECT Id, IdDepartamento, Nombre, FechaDeNacimiento, Sueldo, DNI FROM Empleados";

                    IDataReader dr = com.ExecuteReader();

                    List<Departamento> departamentos = new List<Departamento>();

                    Departamento departamento = null;

                    while (dr.Read())
                    {
                        departamento = new Departamento()
                        {
                            Id = dr.GetInt32(0),
                            Nombre = dr.GetString(1),
                        };

                        departamentos.Add(departamento);
                    }

                    return departamentos;
                }
            }
            catch (Exception e)
            {
                throw new DaoException("No se ha podido consultar los departamentos: " + e.Message, e);
            }
        }
    }
}
