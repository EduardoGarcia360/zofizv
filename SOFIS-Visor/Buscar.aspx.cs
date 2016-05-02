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

        Conexion conectar = new Conexion();
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
                lblmensaje.Text = "Ingrese un codigo de cliente";
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DarDeBaja")
            {
                string dato_codcliente = e.CommandArgument.ToString();
                int codcliente = Convert.ToInt32(dato_codcliente);
                if (conectar.actualizar_dato("activo", "0", codcliente))
                {
                    string nombre = conectar.retornar_dato("nombre", codcliente);
                    lblmensaje.Text = "Empleado "+nombre+" ha sido dado de baja.";
                }
                
            }
        }

    }
}