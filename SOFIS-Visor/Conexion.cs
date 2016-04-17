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
        private string cadena_conexion;
        SqlDataReader dr;

        public Conexion()
        {
            cadena_conexion = "Data Source=Edu-PC;Initial Catalog=SOFISBD;Integrated Security=True";
        }

        private SqlConnection get_conexion()
        {
            try
            {
                SqlConnection conn = new SqlConnection(cadena_conexion);
                conn.Open();
                return conn;
            }
            catch (Exception exc)
            {
                return null;
            }
        } //fin private

        public bool Nuevo_Usuario(string nombre, string apellido, string correo, string genero, string puesto, string usuario, string contra)
        {
            SqlConnection conn;
            try
            {
                using (conn = get_conexion())
                {
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = conn;
                        command.CommandType = System.Data.CommandType.Text;
                        command.CommandText = "INSERT INTO empleado (nombre, apellido, correo, genero, puesto, usuario, contra, activo)"
                                + "VALUES (@nombre, @apellido, @correo, @genero, @puesto, @usuario, @contra, @activo)";

                        command.Parameters.Add("@nombre", System.Data.SqlDbType.VarChar).Value = nombre;
                        command.Parameters.Add("@apellido", System.Data.SqlDbType.VarChar).Value = apellido;
                        command.Parameters.Add("@correo", System.Data.SqlDbType.VarChar).Value = correo;
                        command.Parameters.Add("@genero", System.Data.SqlDbType.VarChar).Value = genero;
                        command.Parameters.Add("@puesto", System.Data.SqlDbType.VarChar).Value = puesto;
                        command.Parameters.Add("@usuario", System.Data.SqlDbType.VarChar).Value = usuario;
                        command.Parameters.Add("@contra", System.Data.SqlDbType.VarChar).Value = contra;
                        command.Parameters.Add("@activo", System.Data.SqlDbType.Bit).Value = 1;
                            return (command.ExecuteNonQuery() == 1);
                    }
                }
            }
            catch (Exception exc)
            {
                return false;
            }
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
    }
}