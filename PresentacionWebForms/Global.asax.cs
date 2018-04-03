using AccesoDatos;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace PresentacionWebForms
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            string cadenaConexion =
                System.Configuration.ConfigurationManager.
                    ConnectionStrings["ejemploempresa"].ConnectionString;

            IDaoDepartamento daoDepartamentos = new DaoDepartamentoSql(cadenaConexion);
            IDaoEmpleado daoEmpleados = new DaoEmpleadoSql(cadenaConexion);
            IDaoUsuario daoUsuarios = new DaoUsuarioSql(cadenaConexion);

            Application["daoDepartamentos"] = daoDepartamentos;
            Application["daoUsuarios"] = daoUsuarios;
            Application["daoEmpleados"] = daoEmpleados;
        }

        void Session_Start(object sender, EventArgs e)
        {
            Session["invitaciones"] = new Dictionary<int, Invitacion>();
        }
    }
}