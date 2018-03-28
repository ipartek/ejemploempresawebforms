using AccesoDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWebForms
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Entidades.Empleado> empleados;

                IDaoEmpleado dao = (IDaoEmpleado)Application["daoEmpleados"];
                empleados = dao.ObtenerTodos();

                tabla.DataSource = empleados;
                tabla.DataBind();
            }
        }

        protected void tabla_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            TextBox t = e.Item.FindControl("txtCantidad") as TextBox;

            int cantidad = int.Parse(t.Text);
            int id = int.Parse((string)e.CommandArgument);

            ((Dictionary<int, int>)Session["invitaciones"]).Add(id, cantidad);
        }
    }
}