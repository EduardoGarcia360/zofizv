using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOFIS_Visor
{
    public partial class Buscar : System.Web.UI.Page
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

        protected void btnBuscar_Buscar_Click(object sender, ImageClickEventArgs e)
        {
            string cod = txtBusqueda_Codigo.Value.ToString();
            if (string.IsNullOrEmpty(cod))
            {
                lblerror.Text = "Ingrese un codigo de cliente";
            }
            else
            {
                
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ToString());
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM empleado WHERE cod_empleado= "+cod, conn);
                DataSet ds = new DataSet();
                ad.Fill(ds, "empleado");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                conn.Close();
            }
            
        }

        protected void btnBuscar_Todos_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ToString());
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM empleado", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "empleado");
            GridView1.DataSource = ds;
            GridView1.DataBind();
            conn.Close();
        }

    }
}