using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace AccesoDatos
{
    public interface IDaoDepartamento
    {
        Departamento ObtenerPorId(int idDepartamento);
        List<Departamento> ObtenerTodos();
    }
}
