using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace AccesoDatos
{
    public interface IDaoEmpleado
    {
        void Alta(Empleado empleado);
        void Baja(int idEmpleado);
        void Modificacion(Empleado empleado);

        Empleado ObtenerPorId(int idEmpleado);
        List<Empleado> ObtenerTodos();
    }
}
