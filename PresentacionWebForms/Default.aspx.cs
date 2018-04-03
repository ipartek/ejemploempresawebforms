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
        IDaoEmpleado dao;

        protected void Page_Load(object sender, EventArgs e)
        {
            dao = (IDaoEmpleado)Application["daoEmpleados"];

            if (!IsPostBack)
            {
                List<Entidades.Empleado> empleados;


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

            Dictionary<int, Entidades.Invitacion> invitaciones =
                (Dictionary<int, Entidades.Invitacion>)Session["invitaciones"];

            if (invitaciones.ContainsKey(id))
                invitaciones[id].CantidadInvitaciones = cantidad;
            else
            {
                IDaoDepartamento daoDepartamento = (IDaoDepartamento)Application["daoDepartamentos"];

                Entidades.Empleado empleado = dao.ObtenerPorId(id);

                empleado.DepartamentoAsignado = daoDepartamento.ObtenerPorId(empleado.IdDepartamento);

                invitaciones.Add(id, new Entidades.Invitacion()
                {
                    IdEmpleado = id,
                    CantidadInvitaciones = cantidad,
                    EmpleadoInvitado = empleado
                }
                );
            }
        }

        public int InvitacionPorId(object idString)
        {
            int id = (int)idString;

            Dictionary<int, Entidades.Invitacion> dic =
                (Dictionary<int, Entidades.Invitacion>)Session["invitaciones"];

            return dic.ContainsKey(id) ? dic[id].CantidadInvitaciones : 0;
        }
    }
}