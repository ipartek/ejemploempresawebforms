using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWebForms
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Entidades.Empleado> empleados = new List<Entidades.Empleado>();

            empleados.Add(new Entidades.Empleado() {
                Id = 1,
                IdDepartamento = 1,
                Nombre = "Javier Lete",
                FechaDeNacimiento = new DateTime(),
                Sueldo = 24000m,
                Dni = "12345678M"
            });

            empleados.Add(new Entidades.Empleado()
            {
                Id = 2,
                IdDepartamento = 1,
                Nombre = "Pepe Pérez",
                FechaDeNacimiento = new DateTime(),
                Sueldo = 24000m,
                Dni = "87654321A"
            });

            tabla.DataSource = empleados;
            tabla.DataBind();
        }

        protected void btnAlta_Click(object sender, EventArgs e)
        {
            Server.Transfer("~/Empleado.aspx");
        }

        protected void tabla_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

        }
    }
}