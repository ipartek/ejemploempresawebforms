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
            if (Session["usuario"] == null)
            {
                Response.Redirect("~");
                return;
            }

            if (!IsPostBack)
            {
                IDaoDepartamento daoDepartamentos = 
                    (IDaoDepartamento)Application["daoDepartamentos"];

                List<Entidades.Departamento> departamentos = daoDepartamentos.ObtenerTodos();

                foreach (Entidades.Departamento departamento in departamentos)
                {
                    ddlDepartamento.Items.Add(
                        new ListItem(departamento.Nombre, departamento.Id.ToString()));
                }

                if (Request["id"] != null)
                {
                    IDaoEmpleado dao =
                        (IDaoEmpleado)Application["daoEmpleados"];

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

                        txtNombre.Enabled = false;
                        txtFecha.Enabled = false;
                        txtDni.Enabled = false;
                        txtSueldo.Enabled = false;
                        ddlDepartamento.Enabled = false;

                        break;
                    case "editar":
                        btnAceptar.Text = "Cambiar";
                        btnAceptar.CssClass += " btn-warning";
                        break;
                }
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            IDaoEmpleado dao = (IDaoEmpleado)Application["daoEmpleados"];

            switch (Request["opcion"])
            {
                case "alta":
                    dao.Alta(new Entidades.Empleado()
                    {
                        IdDepartamento = int.Parse(ddlDepartamento.SelectedValue),
                        Nombre = txtNombre.Text,
                        FechaDeNacimiento = DateTime.Parse(txtFecha.Text),
                        Sueldo = decimal.Parse(txtSueldo.Text),
                        Dni = txtDni.Text
                    });
                    break;
                case "borrar":
                    dao.Baja(int.Parse(txtId.Text));
                    break;
                case "editar":
                    dao.Modificacion(new Entidades.Empleado()
                    {
                        Id = int.Parse(txtId.Text),
                        IdDepartamento = int.Parse(ddlDepartamento.SelectedValue),
                        Nombre = txtNombre.Text,
                        FechaDeNacimiento = DateTime.Parse(txtFecha.Text),
                        Sueldo = decimal.Parse(txtSueldo.Text),
                        Dni = txtDni.Text
                    });
                    break;
            }

            Response.Redirect("~/Admin.aspx");
        }

        //protected void btnCancelar_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("~/Admin.aspx");
        //}
    }
}
