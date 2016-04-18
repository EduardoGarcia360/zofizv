using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOFIS_Visor
{
    public partial class Registrar : System.Web.UI.Page
    {
        
        string nombre = "", apellido = "", correo = "", sexo = "", puesto="" , apodo = "", contra1 = "", contra2 = "";
        Conexion conectar = new Conexion();
        Validaciones valida = new Validaciones();
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


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            nombre = txtnombre.Text;
            apellido = txtapellido.Text;
            correo = txtcorreo.Text;
            sexo = selegenero.Value.ToString();
            puesto = selepuesto.Value.ToString();
            apodo = txtapodo.Text;
            contra1 = txtcontra1.Text;
            contra2 = txtcontra2.Text;
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido) || string.IsNullOrEmpty(correo) || string.IsNullOrEmpty(apodo) || string.IsNullOrEmpty(contra1) || string.IsNullOrEmpty(contra2))
            {
                Label1.Text = "(*) Campo Obligatorio -Por favor llenar todos los campos-";
            }
            else
            {
                if (valida.validar_correo(correo))
                {
                    if (valida.validar_contra(contra1, null, 1))
                    {
                        if (valida.validar_contra(contra1, contra2, 2))
                        {
                            conectar.Nuevo_Usuario(nombre, apellido, correo, sexo, puesto, apodo, contra2);
                            Label1.Text = "Agregado correctamente.";
                            txtnombre.Text = null;
                            txtapellido.Text = null;
                            txtcorreo.Text = null;
                            txtapodo.Text = null;
                            txtcontra1.Text = null;
                            txtcontra2.Text = null;
                        }
                        else
                        {
                            lblcontra2.Text = "Contraseñas no coinciden.";
                        }
                    }
                    else
                    {
                        lblcontra1.Text = "8 carac. minimo y al menos 1 letra mayuscula, minuscula y numero.";
                    }
                }
                else
                {
                    lblcorreo.Text = "Ingrese un correo valido.";
                }
            }
        }

        protected void btnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Administrador.aspx");
        }

    }
}