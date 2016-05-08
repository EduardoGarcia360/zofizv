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
        Conexion conectar = new Conexion();

        protected void Page_Load(object sender, EventArgs e)
        {
            
           // string userid = (string)Session["usuario"];
            //if (!IsPostBack)
            //{
              //  if (String.IsNullOrEmpty(userid))
                //{
                  //  Response.Redirect("Login.aspx");
                //}
            //}
            
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
                string codigoarchivo = e.CommandArgument.ToString();
                if (vxml.validar_contenido(codigoarchivo))
                {
                    lblmensaje.Text = "Archivo validado";
                }
                else
                {
                    lblmensaje.Text = "Archivo no validado";
                }
            }
            else if (e.CommandName == "Descargar")
            {
                string codigoarchivo = e.CommandArgument.ToString();
                descargar_archivo(codigoarchivo);
            }
            else if (e.CommandName == "Composicion")
            {

            }
            else if (e.CommandName == "Insercion")
            {

            }
            else if (e.CommandName == "Rendering")
            {

            }
        }//fin validar botones

        private void descargar_archivo(string codigoarchivo)
        {
            //seleccinamos los datos que conforman el nombre del archivo
            string sql = "SELECT departamento, tipo_trabajo, fecha_generado, hora_generado, secuencia FROM archivo WHERE cod_archivo = "+ codigoarchivo;

            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ToString()))
            {
                conn.Open();//abrimos conexion
                SqlDataReader fila = null;

                try
                {
                    SqlCommand cmd = new SqlCommand(sql, conn); //ejecutamos la instruccion
                    fila = cmd.ExecuteReader(); //nos devuelve la fila completa de datos
                    string depa = "", tipo = "", fecha = "", hora = "", secuencia = "";
                    
                    //llenamos los datos que estan almacenados en el Reader
                    while (fila.Read())
                    {
                        depa = fila["departamento"].ToString();
                        tipo = fila["tipo_trabajo"].ToString();
                        fecha = fila["fecha_generado"].ToString(); //23/09/2016
                        hora = fila["hora_generado"].ToString(); //08:00:03 h:m:s
                        secuencia = fila["secuencia"].ToString();
                    }
                    //teniendo los valores ya solo ordenamos la fecha de la siguiente forma a.m.d
                    string[] fechagen = fecha.Split('/'); //[d][m][a]
                    string[] horagen = hora.Split(':'); //[h][m][s]

                    //ordenamos los datos para formar el nombre
                    string nombre = depa + "." + tipo + "." + fechagen[2] + "." + fechagen[1] + "." 
                        + fechagen[0] + "." + horagen[0] + "." + horagen[1] + "." + horagen[2] + "." + secuencia + ".xml";
                    //cerramos la conexion con la BD
                    fila.Close();
                    conn.Close();
                    //procedemos a ejecutar la descarga
                    try
                    {
                        Response.ContentType = "Application/xml";
                        Response.AppendHeader("Content-Disposition", "attachment; filename="+nombre);
                        Response.TransmitFile(Server.MapPath(@"C:\SOFIS\intake\PendingToTransmit/" + nombre));
                        Response.End();
                    }
                    catch (Exception)
                    {
                        lblmensaje.Text = "Error: imposible descargar, verifique la ubicacion del archivo, en C:\\SOFIS\\intake\\PendingToTransmit\\";
                    }
                }
                catch (Exception)
                {
                    lblmensaje.Text = "Error. Archivo no encontrado.";
                }
            }
        }

        protected void btntemporal_Click(object sender, EventArgs e)
        {
            if (vxml.insercion_archivo("COMUNICACION.PUBLICIDAD.2016.09.23.08.00.01.751.xml"))
            {
                lblmensaje.Text = "listo papu";
            }
            else
            {
                lblmensaje.Text = "baneo lince";
            }
        }//fin descargar_archivo

    }
}