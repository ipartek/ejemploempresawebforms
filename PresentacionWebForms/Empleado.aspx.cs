using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWebForms
{
    public partial class Empleado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IDaoDepartamento daoDepartamentos = new DaoDepartamentoSql(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\javierlete\Source\Repos\EjemploEmpresa\PresentacionWebForms\App_Data\EjemploEmpresa.mdf;Integrated Security=True");

                List<Entidades.Departamento> departamentos = daoDepartamentos.ObtenerTodos();

                foreach (Entidades.Departamento departamento in departamentos)
                {
                    ddlDepartamento.Items.Add(
                        new ListItem(departamento.Nombre, departamento.Id.ToString()));
                }

                if (Request["id"] != null)
                {
                    IDaoEmpleado dao = new DaoEmpleadoSql(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\javierlete\Source\Repos\EjemploEmpresa\PresentacionWebForms\App_Data\EjemploEmpresa.mdf;Integrated Security=True");

                    int id = int.Parse(Request["id"]);

                    Entidades.Empleado empleado = dao.ObtenerPorId(id);

                    txtId.Text = empleado.Id.ToString();

                    ddlDepartamento.SelectedValue = empleado.IdDepartamento.ToString();

                    txtNombre.Text = empleado.Nombre;
                    txtFecha.Text = empleado.FechaDeNacimiento.ToString("yyyy-MM-dd");
                    txtSueldo.Text = empleado.Sueldo.ToString("0");
                    txtDni.Text = empleado.Dni;
                }

                switch (Request["opcion"])
                {
                    case "alta":
                        btnAceptar.Text = "Alta";
                        btnAceptar.CssClass += " btn-primary";
                        break;
                    case "borrar":
                        btnAceptar.Text = "Borrar";
                        btnAceptar.CssClass += " btn-danger";
                        break;
                    case "editar":
                        btnAceptar.Text = "Cambiar";
                        btnAceptar.CssClass += " btn-warning";
                        break;
                }
            }
        }

        //protected void btnCancelar_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Admin.aspx");
        //}
    }
}
