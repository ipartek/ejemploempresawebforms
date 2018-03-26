using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entidades;

namespace AccesoDatos
{
    public interface IDaoUsuario
    {
        Empleado ObtenerPorNick(string nick);
        string ObtenerNombre(int idUsuario);
    }
}
