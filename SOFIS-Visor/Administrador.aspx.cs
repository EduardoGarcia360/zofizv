using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOFIS_Visor
{
    public partial class Administrador : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string userid = (string)Session["usuario"];
            if (!IsPostBack)
            {
                if (String.IsNullOrEmpty(userid))
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void btnSalir_Click(object sender, ImageClickEventArgs e)
        {
            this.Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}