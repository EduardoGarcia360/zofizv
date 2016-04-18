using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SOFIS_Visor
{
    public partial class Editar : System.Web.UI.Page
    {
        string nombre = "", apellido = "", correo = "", sexo = "", contra1 = "", contra2 = "", variable="";
        int cod_emp = 0;
        Conexion conectar = new Conexion();
        Validaciones valida = new Validaciones();

        protected void Page_Load(object sender, EventArgs e)
        {
            variable = this.Session["usuario"].ToString();
            cod_emp = conectar.consultar_dato("cod_empleado",variable);
            sexo = conectar.consultar_dato_texto("genero", variable);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            
            nombre = txtnombre.Text;
            apellido = txtapellido.Text;
            correo = txtcorreo.Text;
            sexo = selegenero.Value.ToString();
            contra1 = txtcontra1.Text;
            contra2 = txtcontra2.Text;
            
            if (!string.IsNullOrEmpty(nombre))
            {
                if (conectar.actualizar_dato("nombre", nombre, cod_emp))
                {
                    lblnombre.Text = "Dato Actualizado.";
                }
                else
                {
                    lblnombre.Text = "Error.";
                }
            }
            if (!string.IsNullOrEmpty(apellido))
            {
                if (conectar.actualizar_dato("apellido", apellido, cod_emp))
                {
                    lblapellido.Text = "Dato Actualizado.";
                }
                else
                {
                    lblapellido.Text = "Error.";
                }
            }
            if (!string.IsNullOrEmpty(correo))
            {
                if (valida.validar_correo(correo))
                {
                    if (conectar.actualizar_dato("correo", correo, cod_emp))
                    {
                        lblcorreo.Text = "Dato Actualizado.";
                    }
                    else
                    {
                        lblcorreo.Text = "Error.";
                    }
                }
                else
                {
                    lblcorreo.Text = "Formato invalido.";
                }
                
            }

            if (sexo != selegenero.Value.ToString())
            {
                if (conectar.actualizar_dato("genero", sexo, cod_emp))
                {
                    lblgenero.Text = "Dato actualizado.";
                }
                else
                {
                    lblgenero.Text = "Error.";
                }
            }

            if (!string.IsNullOrEmpty(contra1))
            {
                if (valida.validar_contra(contra1, null, 1))
                {
                    if (valida.validar_contra(contra1, contra2, 2))
                    {
                        lblcontra1.Text = "Contraseña actualizada.";
                    }
                    else
                    {
                        lblcontra2.Text = "Contraseña no coincide.";
                    }
                }
                else
                {
                    lblcontra1.Text = "Formato invalido.";
                }
            }

        }

        protected void btnRegresar_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Operador.aspx");
        }
    }
}