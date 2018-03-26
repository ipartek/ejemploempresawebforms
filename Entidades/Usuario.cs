using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public int IdEmpleado { get; set; }

        public Empleado EmpleadoAsociado { get; set; }
    }
}
