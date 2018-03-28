using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using AccesoDatos;
using Entidades;

namespace PresentacionWebForms
{
    public partial class SiteMaster : MasterPage
    {
        private IDaoUsuario daoUsuarios;

        public SiteMaster()
        {
            daoUsuarios = (IDaoUsuario)HttpContext.Current.Application["daoUsuarios"];
        }

        private void GestionLogin()
        {
            Usuario usuario = (Usuario)Session["usuario"];

            if (usuario != null)
            {
                linklogin.Text = daoUsuarios.ObtenerNombre(usuario.Id);
                btnLogout.Visible = true;
            }
            else
            {
                linklogin.Text = "Login";
                btnLogout.Visible = false;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            GestionLogin();
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Usuario usuario = daoUsuarios.ObtenerPorNick(txtNick.Text);

            if(usuario != null && usuario.Password == txtPassword.Text)
            {
                scripts.Text = ""; //<asp:Literal EnableViewState="false"
                Session["usuario"] = usuario;
            }
            else
            {
                scripts.Text = "<script>$('#login').slideDown();</script>";
            }

            GestionLogin();
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~");
        }
    }
}