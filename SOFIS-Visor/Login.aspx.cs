using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOFIS_Visor
{
    public partial class Login : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnentrar_Click(object sender, EventArgs e)
        {
            string usuario, password, puesto;
            Conexion cone = new Conexion();
            usuario = txtUserName.Value.ToString();
            password = txtPassword.Value.ToString();
            puesto = selecpuesto.Value.ToString();
            
            if (cone.validar_login(usuario, password, puesto) == true)
            {
                Session["usuario"] = usuario;
                Session["rol"] = puesto;
                if (puesto.Equals("admin"))
                {
                    Response.Redirect("Administrador.aspx");
                }
                else
                {
                    Response.Redirect("Operador.aspx");
                }
            }
            else
            {
                lblError_Login.Text = "Usuario y/o contraseña y/o puesto incorrectos";
            }
        }


    }
}