using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Globalization;

namespace SOFIS_Visor
{
    public partial class Archivos : System.Web.UI.Page
    {
        ValidarXML vxml = new ValidarXML();
        protected void Page_Load(object sender, EventArgs e)
        {
            /**
            string userid = (string)Session["usuario"];
            if (!IsPostBack)
            {
                if (String.IsNullOrEmpty(userid))
                {
                    Response.Redirect("Login.aspx");
                }
            }
             * */
        }

        protected void btnBuscar_Click(object sender, ImageClickEventArgs e)
        {
            string fecha = txtArchivo_Fecha.Value.ToString();
            string departamento = selecdepa.Value.ToString();
            string tipo = selectipo.Value.ToString();
            string condicion = "";
            if (string.IsNullOrEmpty(fecha))
            {
                lblmensaje.Text = "Debe ingresar una fecha para la busqueda.";
            }
            else
            {
                condicion = "fecha_recepcion='"+ fecha + "'";
                if (!departamento.Equals("OPCIONAL"))
                {
                    condicion += "AND departamento='" + departamento + "'";
                }
                if(!tipo.Equals("OPCIONAL"))
                {
                    condicion += "AND tipo_trabajo='" + tipo + "'";
                }

                try
                {
                    SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ToString());
                    conn.Open();
                    SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM archivo WHERE " + condicion, conn);
                    DataSet ds = new DataSet();
                    ad.Fill(ds, "archivo");
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                    conn.Close();
                    fecha = departamento = tipo = condicion = "";
                }
                catch (Exception)
                {

                    lblmensaje.Text = "No hay archivos que cumplan la condicion";
                    fecha = departamento = tipo = condicion = "";
                }
            }
        }

        protected void btnMostrar_Todos_Click(object sender, ImageClickEventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ToString());
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter("SELECT * FROM archivo", conn);
            DataSet ds = new DataSet();
            ad.Fill(ds, "archivo");
            GridView1.DataSource = ds;
            GridView1.DataBind();
            conn.Close();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ValidarArchivo")
            {
                string dato_codigoarchivo = e.CommandArgument.ToString();
                int codigoarchivo = Convert.ToInt32(dato_codigoarchivo);
            }
            else if (e.CommandName == "Descargar")
            {
                string dato_codigoarchivo = e.CommandArgument.ToString();
                int codigoarchivo = Convert.ToInt32(dato_codigoarchivo);
                Response.ContentType = "Application/xml";
                Response.AppendHeader("Content-Disposition", "attachment; filename=BANCA.CARTA.2016.02.23.08.00.01.311.xml");
                Response.TransmitFile(Server.MapPath(@"C:\SOFIS\intake/BANCA.CARTA.2016.02.23.08.00.01.311.xml"));
                Response.End();
            }
        }

        protected void btnprueba_Click(object sender, EventArgs e)
        {
            //C:/SOFIS/intake/BANCA.CARTA.2016.02.23.08.00.01.311.xml
            string sFilePath = "C:/SOFIS/intake/BANCA.CARTA.2016.02.23.08.00.01.311.xml", sFileName = "BANCA.CARTA.2016.02.23.08.00.01.311.xml";
            FileInfo file = new FileInfo(sFilePath);

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + sFileName);
            Response.AddHeader("Content-Length", file.Length.ToString(CultureInfo.InvariantCulture));
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(file.FullName);
            Response.End();
        }
    }
}