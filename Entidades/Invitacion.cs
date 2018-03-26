using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Invitacion
    {
        public int IdEmpleado { get; set; }
        public int CantidadInvitaciones { get; set; }

        public Empleado EmpleadoInvitado { get; set; }
    }
}
