using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;

namespace SOFIS_Visor
{
    public class ValidarXML
    {

        int total_de_hojas = 0;


        //metodo para validar el contenido de el apartado "datos" dentro del XML
        public bool validar_contenido_datos(string archivo)
        {
            bool valido = false;

            //creamos un documento tipo XML
            XmlDocument documento = new XmlDocument();
            try
            {
                //cargamos el documento pasandole la ruta
                documento.Load(@"C:\SOFIS\intake\" + archivo);

                //creamos una lista con todos los elementos que conforman la seccion "datos" dentro del XML
                XmlNodeList lista_datos = documento.SelectNodes("trabajoImpresion/datos");
                XmlNode nodo_datos;
                //como unicamente hay una parte de "datos" la lista tendra un unico nodo
                nodo_datos = lista_datos.Item(0);
                //tomamos los valores que estan dentro de cada etiqueta
                string fecha_hora = nodo_datos.SelectSingleNode("fechaCreacion").InnerText;
                string identificador = nodo_datos.SelectSingleNode("identificador").InnerText;
                string nombre = nodo_datos.SelectSingleNode("nombre").InnerText;
                string departamento = nodo_datos.SelectSingleNode("departamento").InnerText;
                string tipo = nodo_datos.SelectSingleNode("tipo").InnerText;
                total_de_hojas = Convert.ToInt32(nodo_datos.SelectSingleNode("totalDeHojas").InnerText);

                if (!string.IsNullOrEmpty(fecha_hora) && !string.IsNullOrEmpty(identificador) && !string.IsNullOrEmpty(nombre)
                    && !string.IsNullOrEmpty(departamento) && !string.IsNullOrEmpty(tipo) && total_de_hojas != 0)
                {
                    if (validar_fecha_creacion(fecha_hora))
                    {
                        if (validar_departamento(departamento))
                        {
                            if (validar_tipo(tipo))
                            {
                                valido = true;
                            }
                        }
                    }

                }
            }
            catch (XmlException)
            {
                valido = false;
            }


            return valido;
        }

        private bool validar_departamento(string dato)
        {
            if (dato.Equals("CREDITOS") || dato.Equals("BANCA") || dato.Equals("COMUNICACION"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool validar_tipo(string dato)
        {
            if (dato.Equals("CARTA") || dato.Equals("ESTADODECUENTA") || dato.Equals("REPORTE") || dato.Equals("PUBLICIDAD"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool validar_fecha_creacion(string datocompleto)
        {
            bool valido = false, detener = false;
            string dato = datocompleto + "#";

            //separamos 14-03-2016 10:20:25#
            char[] aDato = dato.ToCharArray();
            int posicion = 0, estado = 1;


            while (detener == false)
            {
                char caracter = aDato[posicion];
                switch (estado)
                {
                    case 1:
                        if (char.IsDigit(caracter))
                        {
                            posicion++;
                        }
                        else if (caracter == '-')
                        {
                            posicion++;
                        }
                        else if (caracter == ':')
                        {
                            posicion++;
                        }
                        else if (char.IsWhiteSpace(caracter))
                        {
                            posicion++;
                        }
                        else if (caracter == '#')
                        {
                            detener = true;
                            valido = true;
                        }
                        else
                        {
                            estado = 3;
                        }

                        break;
                    case 3:
                        detener = true;
                        break;
                }
            }

            return valido;
        }

        private bool es_numero(string numero)
        {
            try
            {
                Convert.ToInt32(numero);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}