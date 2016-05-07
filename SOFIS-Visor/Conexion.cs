using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SOFIS_Visor
{
    public class Conexion
    {
        public Conexion()
        {
           
        }

        public bool Nuevo_Usuario(string nombre, string apellido, string correo, string genero, string puesto, string usuario, string contra)
        {
            string sql = @"INSERT INTO empleado (nombre, apellido, correo, genero, puesto, usuario, contra, activo)"
                                + "VALUES (@nombre, @apellido, @correo, @genero, @puesto, @usuario, @contra, @activo)";
            //cadena conexion
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ToString()))
            {
                conn.Open();//abrimos conexion

                SqlCommand cmd = new SqlCommand(sql, conn); //ejecutamos la instruccion
                cmd.Parameters.AddWithValue("@nombre", nombre);
                cmd.Parameters.AddWithValue("@apellido", apellido); //enviamos los parametros
                cmd.Parameters.AddWithValue("@correo", correo);
                cmd.Parameters.AddWithValue("@genero", genero);
                cmd.Parameters.AddWithValue("@puesto", puesto);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@contra", contra);
                cmd.Parameters.AddWithValue("@activo", 1);

                int count = Convert.ToInt32(cmd.ExecuteScalar()); //devuelve la fila afectada

                if (count == 0)
                    return false;
                else
                    return true;

            }
            //----------------------------------------------------------------------------------------------
        }//fin nuevo usuario

        public bool validar_login(string usuario, string pass, string puesto)
        {
            string sql = @"SELECT COUNT(*) FROM empleado WHERE puesto = @pue AND usuario = @usu AND contra = @con";
            //cadena conexion
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ToString()))
            {
                conn.Open();//abrimos conexion

                SqlCommand cmd = new SqlCommand(sql, conn); //ejecutamos la instruccion

                cmd.Parameters.AddWithValue("@pue", puesto);
                cmd.Parameters.AddWithValue("@usu", usuario); //enviamos los parametros
                cmd.Parameters.AddWithValue("@con", pass);

                int count = Convert.ToInt32(cmd.ExecuteScalar()); //devuelve la fila afectada

                if (count == 0)
                    return false;
                else
                    return true;
            }
        }//fin validar login

        public bool actualizar_dato(string campo, string dato, int codempleado)
        {
            string sql = @"UPDATE empleado SET "+campo+ "=@dato WHERE cod_empleado=@codigo";
            //cadena conexion
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ToString()))
            {
                conn.Open();//abrimos conexion

                SqlCommand cmd = new SqlCommand(sql, conn); //ejecutamos la instruccion

                cmd.Parameters.AddWithValue("@dato", dato);
                cmd.Parameters.AddWithValue("@codigo", codempleado); //enviamos los parametros

                int count = Convert.ToInt32(cmd.ExecuteScalar()); //devuelve la fila afectada

                if (count > 0)
                    return false;
                else
                    return true;
            }
        }//fin actualizar dato

        public int consultar_dato(string campo, string usuario)
        {
            string sql = @"SELECT cod_empleado FROM empleado WHERE usuario=@usuario";
            //cadena conexion
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ToString()))
            {
                conn.Open();//abrimos conexion

                SqlCommand cmd = new SqlCommand(sql, conn); //ejecutamos la instruccion

                cmd.Parameters.AddWithValue("@usuario", usuario); //enviamos los parametros

                
                int retorno = Convert.ToInt32(cmd.ExecuteScalar()); //devuelve la fila afectada
                return retorno;
            }
        }//fin codigo empleado

        public string consultar_dato_texto(string campo, string usuario)
        {
            string sql = @"SELECT "+ campo +" FROM empleado WHERE usuario=@usuario";
            //cadena conexion
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ToString()))
            {
                conn.Open();//abrimos conexion

                SqlCommand cmd = new SqlCommand(sql, conn); //ejecutamos la instruccion

                cmd.Parameters.AddWithValue("@usuario", usuario); //enviamos los parametros


                string retorno = Convert.ToString(cmd.ExecuteScalar()); //devuelve la fila afectada
                return retorno;
            }
        }//fin consultar dato texto

        public string retornar_dato(string campo, int codigousuario)
        {
            string sql = @"SELECT " + campo + " FROM empleado WHERE cod_empleado=@codigo";
            //cadena conexion
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ToString()))
            {
                conn.Open();//abrimos conexion

                SqlCommand cmd = new SqlCommand(sql, conn); //ejecutamos la instruccion

                cmd.Parameters.AddWithValue("@codigo", codigousuario); //enviamos los parametros


                string retorno = Convert.ToString(cmd.ExecuteScalar()); //devuelve la fila afectada
                return retorno;
            }
        }

        public string consultar_dato(string campo, string tabla, string pk, string condicion)
        {
            string sql = @"SELECT " + campo + " FROM " + tabla + " WHERE " + pk + "=@codigo";
            //cadena conexion
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["cadenaConexion"].ToString()))
            {
                conn.Open();//abrimos conexion

                SqlCommand cmd = new SqlCommand(sql, conn); //ejecutamos la instruccion

                cmd.Parameters.AddWithValue("@codigo", condicion); //enviamos los parametros


                string retorno = Convert.ToString(cmd.ExecuteScalar()); //devuelve el dato
                return retorno;
            }
        }
    }
}