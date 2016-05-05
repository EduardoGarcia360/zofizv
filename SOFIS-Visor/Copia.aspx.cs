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
    public partial class Copia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            string fecha = txtCopia_Fecha.Value.ToString();
            if (!string.IsNullOrEmpty(fecha))
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ToString());
                conn.Open();
                SqlDataAdapter ad = new SqlDataAdapter("SELECT cod_copia, nombre, fecha_recepcion, hora_recepcion FROM copia WHERE fecha_recepcion="
                    + fecha, conn);
                DataSet ds = new DataSet();
                ad.Fill(ds, "copia");
                GridView1.DataSource = ds;
                GridView1.DataBind();
                conn.Close();
            }
            else
            {
                lblmensaje.Text = "Debe Ingresar una Fecha para hacer la consulta. ej.: 01/05/2016";
            }
        }

        protected void btnMostrar_Todos_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ToString());
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("SELECT cod_copia, nombre, fecha_recepcion, hora_recepcion FROM copia", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "copia");
            GridView1.DataSource = ds;
            GridView1.DataBind();
            conn.Close();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DescargarC")
            {
                string cod = e.CommandArgument.ToString();
                
                string sql = "SELECT cod_copia, nombre, fecha_recepcion, hora_recepcion FROM copia WHERE cod_copia='"+cod+"'";
                
                using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ToString()))
                {
                    conn.Open();//abrimos conexion
                    SqlDataReader fila = null;

                    try
                    {
                        SqlCommand cmd = new SqlCommand(sql, conn); //ejecutamos la instruccion
                        fila = cmd.ExecuteReader();
                        string retorno = "";
                        while (fila.Read())
                        {
                            retorno = fila["cod_copia"].ToString() + "-" + fila["nombre"].ToString() + "-" + fila["fecha_recepcion"].ToString()
                            + "-" + fila["hora_recepcion"].ToString();
                        }
                        lblmensaje.Text = retorno;
                    }
                    catch (Exception)
                    {
                        lblmensaje.Text = "error";
                    }
                }
            }
        }
    }
}