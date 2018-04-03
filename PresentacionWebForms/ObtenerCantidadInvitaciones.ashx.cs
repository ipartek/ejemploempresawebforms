using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PresentacionWebForms
{
    /// <summary>
    /// Descripción breve de ObtenerCantidadInvitaciones
    /// </summary>
    public class ObtenerCantidadInvitaciones : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            Dictionary<int, Entidades.Invitacion> dic =
                (Dictionary<int, Entidades.Invitacion>)context.Session["invitaciones"];

            int id = int.Parse(context.Request["id"]);

            int cantidad;

            if (dic.ContainsKey(id))
                cantidad = dic[id].CantidadInvitaciones;
            else
                cantidad = 0;

            context.Response.ContentType = "text/plain";
            context.Response.Write(cantidad);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}