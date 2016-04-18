using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SOFIS_Visor
{
    public class Validaciones
    {
        public bool validar_correo(string mail)
        {
            bool valido = false, detener = false;
            string tmp = mail + "#";
            if (!string.IsNullOrEmpty(mail))
            {
                char[] arreglo_correo = tmp.ToArray();
                int posicion = 0, caso = 0;
                string servidor_correo = "";

                while (detener == false)
                {
                    char caracter = arreglo_correo[posicion];
                    switch (caso)
                    {
                        case 0:
                            if (caracter == '@')
                            {
                                caso = 1;
                                posicion++;
                            }
                            else if (char.IsWhiteSpace(caracter))
                            {
                                caso = 9;
                            }
                            else if (caracter == '#')
                            {
                                caso = 9;
                            }
                            else
                            {
                                caso = 0;
                                posicion++;
                            }
                            break;
                        case 1:
                            if (char.IsLetter(caracter))
                            {
                                servidor_correo += caracter.ToString();
                                caso = 1;
                                posicion++;
                            }
                            else if (caracter == '.')
                            {
                                if (servidor_correo.Equals("hotmail") || servidor_correo.Equals("gmail") || servidor_correo.Equals("yahoo"))
                                {
                                    caso = 2;
                                    servidor_correo = "";
                                    posicion++;
                                }
                                else
                                {
                                    caso = 9;
                                }
                            }
                            else if (char.IsNumber(caracter))
                            {
                                caso = 9;
                            }
                            else
                            {
                                caso = 9;
                            }
                            break;
                        case 2:
                            if (char.IsLetter(caracter))
                            {
                                servidor_correo += caracter.ToString();
                                caso = 2;
                                posicion++;
                            }
                            else if (caracter == '#')
                            {
                                if (servidor_correo.Equals("com") || servidor_correo.Equals("net"))
                                {
                                    valido = true;
                                    detener = true;
                                    servidor_correo = "";
                                }
                                else
                                {
                                    caso = 9;
                                }
                            }
                            else
                            {
                                caso = 9;
                            }
                            break;
                        case 9:
                            detener = true;
                            break;
                    }//fin switch
                }
            }
            return valido;
        }//fin validar correo

        public bool validar_contra(string pass1, string pass2, int caso)
        {
            bool valido = false;
            if (caso == 1)
            {
                //validar si tiene 8 caracteres y si cumple con los requisitos
                char[] arreglo_pass1 = pass1.ToArray();
                if (arreglo_pass1.Count() >= 7)
                {
                    int letraM = 0, letram = 0, num = 0;
                    for (int i = 0; i < arreglo_pass1.Count(); i++)
                    {
                        if (char.IsUpper(arreglo_pass1[i]))
                        {
                            letraM++;
                        }
                        else if (char.IsLower(arreglo_pass1[i]))
                        {
                            letram++;
                        }
                        else if (char.IsNumber(arreglo_pass1[i]))
                        {
                            num++;
                        }
                    }
                    if (letraM >= 1 && letram >= 1 && num >= 1)
                    {
                        valido = true;
                    }
                }
            }
            else
            {
                //validar si la otra contraseña es igual
                if (pass1 == pass2)
                {
                    valido = true;
                }
            }
            return valido;
        }//fin validar contra

    }
}