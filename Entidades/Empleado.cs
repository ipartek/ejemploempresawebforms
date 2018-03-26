using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Empleado
    {
        public int Id { get; set; }
        public int IdDepartamento { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaDeNacimiento { get; set; }
        public Decimal Sueldo { get; set; }
        public string Dni { get; set; }

        public Departamento DepartamentoAsignado { get; set; }
    }
}
