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
                txtId.Text = Request["id"];

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
