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
    public class DaoEmpleadoSql : IDaoEmpleado
    {
        private string cadenaConexion;

        public DaoEmpleadoSql(string cadenaConexion)
        {
            this.cadenaConexion = cadenaConexion;
        }

        public void Alta(Empleado empleado)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();

                    IDbCommand com = con.CreateCommand();
                    com.CommandText = "INSERT INTO Empleados (IdDepartamento, Nombre, FechaDeNacimiento, Sueldo, DNI) VALUES (@IdDepartamento, @Nombre, @FechaDeNacimiento, @Sueldo, @DNI)";

                    IDbDataParameter parIdDepartamento = com.CreateParameter();
                    parIdDepartamento.DbType = DbType.Int32;
                    parIdDepartamento.ParameterName = "IdDepartamento";
                    com.Parameters.Add(parIdDepartamento);

                    IDbDataParameter parNombre = com.CreateParameter();
                    parNombre.DbType = DbType.String;
                    parNombre.ParameterName = "Nombre";
                    com.Parameters.Add(parNombre);

                    IDbDataParameter parFechaDeNacimiento = com.CreateParameter();
                    parFechaDeNacimiento.DbType = DbType.Date;
                    parFechaDeNacimiento.ParameterName = "FechaDeNacimiento";
                    com.Parameters.Add(parFechaDeNacimiento);

                    IDbDataParameter parSueldo = com.CreateParameter();
                    parSueldo.DbType = DbType.Decimal;
                    parSueldo.ParameterName = "Sueldo";
                    com.Parameters.Add(parSueldo);

                    IDbDataParameter parDni = com.CreateParameter();
                    parDni.DbType = DbType.String;
                    parDni.ParameterName = "DNI";
                    com.Parameters.Add(parDni);

                    parIdDepartamento.Value = empleado.IdDepartamento;
                    parNombre.Value = empleado.Nombre;
                    parFechaDeNacimiento.Value = empleado.FechaDeNacimiento;
                    parSueldo.Value = empleado.Sueldo;
                    parDni.Value = empleado.Dni;

                    int numResultados = com.ExecuteNonQuery();

                    if (numResultados != 1)
                        throw new DaoException(
                            "Número de resultados de la insert: " + numResultados);
                }
            }
            catch (Exception e)
            {
                throw new DaoException("No se ha podido insertar el empleado: " + e.Message, e);
                //throw new Exception("No se ha podido insertar el empleado: " + e.Message, e);
            }
        }

        public void Baja(int idEmpleado)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();

                    IDbCommand com = con.CreateCommand();
                    com.CommandText = "DELETE FROM Empleados WHERE Id=@Id";

                    IDbDataParameter parId = com.CreateParameter();
                    parId.DbType = DbType.Int32;
                    parId.ParameterName = "Id";
                    com.Parameters.Add(parId);

                    parId.Value = idEmpleado;

                    int numResultados = com.ExecuteNonQuery();

                    if (numResultados != 1)
                        throw new DaoException(
                            "Número de resultados de la delete: " + numResultados);
                }
            }
            catch (Exception e)
            {
                throw new DaoException("No se ha podido borrar el empleado: " + e.Message, e);
            }
        }

        public void Modificacion(Empleado empleado)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();

                    IDbCommand com = con.CreateCommand();
                    com.CommandText = "UPDATE Empleados SET IdDepartamento=@IdDepartamento, Nombre=@Nombre, FechaDeNacimiento=@FechaDeNacimiento, Sueldo=@Sueldo, DNI=@DNI WHERE Id=@Id";

                    IDbDataParameter parId = com.CreateParameter();
                    parId.DbType = DbType.Int32;
                    parId.ParameterName = "Id";
                    com.Parameters.Add(parId);

                    IDbDataParameter parIdDepartamento = com.CreateParameter();
                    parIdDepartamento.DbType = DbType.Int32;
                    parIdDepartamento.ParameterName = "IdDepartamento";
                    com.Parameters.Add(parIdDepartamento);

                    IDbDataParameter parNombre = com.CreateParameter();
                    parNombre.DbType = DbType.String;
                    parNombre.ParameterName = "Nombre";
                    com.Parameters.Add(parNombre);

                    IDbDataParameter parFechaDeNacimiento = com.CreateParameter();
                    parFechaDeNacimiento.DbType = DbType.Date;
                    parFechaDeNacimiento.ParameterName = "FechaDeNacimiento";
                    com.Parameters.Add(parFechaDeNacimiento);

                    IDbDataParameter parSueldo = com.CreateParameter();
                    parSueldo.DbType = DbType.Decimal;
                    parSueldo.ParameterName = "Sueldo";
                    com.Parameters.Add(parSueldo);

                    IDbDataParameter parDni = com.CreateParameter();
                    parDni.DbType = DbType.String;
                    parDni.ParameterName = "DNI";
                    com.Parameters.Add(parDni);

                    parId.Value = empleado.Id;
                    parIdDepartamento.Value = empleado.IdDepartamento;
                    parNombre.Value = empleado.Nombre;
                    parFechaDeNacimiento.Value = empleado.FechaDeNacimiento;
                    parSueldo.Value = empleado.Sueldo;
                    parDni.Value = empleado.Dni;

                    int numResultados = com.ExecuteNonQuery();

                    if (numResultados != 1)
                        throw new DaoException(
                            "Número de resultados de la update: " + numResultados);
                }
            }
            catch (Exception e)
            {
                throw new DaoException("No se ha podido modificar el empleado: " + e.Message, e);
            }
        }

        public Empleado ObtenerPorId(int idEmpleado)
        {
            try
            {
                using (IDbConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();

                    IDbCommand com = con.CreateCommand();
                    com.CommandText = "SELECT Id, IdDepartamento, Nombre, FechaDeNacimiento, Sueldo, DNI FROM Empleados WHERE Id=@Id";

                    IDbDataParameter parId = com.CreateParameter();
                    parId.DbType = DbType.Int32;
                    parId.ParameterName = "Id";
                    com.Parameters.Add(parId);

                    parId.Value = idEmpleado;

                    IDataReader dr = com.ExecuteReader();

                    Empleado empleado = null;

                    if (dr.Read())
                    {
                        empleado = new Empleado()
                        {
                            Id = dr.GetInt32(0),
                            IdDepartamento = dr.GetInt32(1),
                            Nombre = dr.GetString(2),
                            FechaDeNacimiento = dr.GetDateTime(3),
                            Sueldo = dr.GetDecimal(4),
                            Dni = dr.GetString(5)
                        };
                    }

                    return empleado;
                }
            }
            catch (Exception e)
            {
                throw new DaoException("No se ha podido consultar el empleado: " + e.Message, e);
            }
        }

        public List<Empleado> ObtenerTodos()
        {
            try
            {
                using (IDbConnection con = new SqlConnection(cadenaConexion))
                {
                    con.Open();

                    IDbCommand com = con.CreateCommand();
                    com.CommandText = "SELECT Id, IdDepartamento, Nombre, FechaDeNacimiento, Sueldo, DNI FROM Empleados";

                    IDataReader dr = com.ExecuteReader();

                    List<Empleado> empleados = new List<Empleado>();

                    Empleado empleado = null;

                    while(dr.Read())
                    {
                        empleado = new Empleado()
                        {
                            Id = dr.GetInt32(0),
                            IdDepartamento = dr.GetInt32(1),
                            Nombre = dr.GetString(2),
                            FechaDeNacimiento = dr.GetDateTime(3),
                            Sueldo = dr.GetDecimal(4),
                            Dni = dr.GetString(5)
                        };

                        empleados.Add(empleado);
                    }

                    return empleados;
                }
            }
            catch (Exception e)
            {
                throw new DaoException("No se ha podido consultar el empleado: " + e.Message, e);
            }
        }
    }
}
