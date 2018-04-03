using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PresentacionWebForms
{
    public partial class Invitaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Dictionary<int, Entidades.Invitacion> dic = 
                (Dictionary<int, Entidades.Invitacion>)Session["invitaciones"];
            var lista = dic.Values;
            tabla.DataSource = lista;
            tabla.DataBind();
        }
    }
}