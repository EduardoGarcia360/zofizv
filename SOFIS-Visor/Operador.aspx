﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Operador.aspx.cs" Inherits="SOFIS_Visor.Operador" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" type="image/png" href="ico.ico" />
    <title>SOFIS</title>
    
    <style type="text/css">
        .centrar {
   height: 200px;
   width: 500px;
   margin-top: -100px;
   margin-left: -150px;
   left: 50%;
   top: 50%;
   position: absolute;
}
        .auto-style1 {
            width: 76px;
        }
    </style>
    
</head>
     
<body style="background-image: url(fondo_general.jpg)">
    <form id="form1" runat="server">
        <div class="centrar">
            <h1>Bienvenido</h1>
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td colspan="2"><h2>Menu de Opciones</h2></td>
                </tr>
                <tr>
                    <td class="auto-style1"><img src="editar.png" /></td>
                    <td><a href="Editar.aspx"><h2>Editar mis datos</h2></a></td>
                </tr>
                <tr>
                    <td class="auto-style1"><img src="archivos.png" /></td>
                    <td><a href="Archivos.aspx"><h2>Consultar Archivos</h2></a></td>
                </tr>
                <tr>
                    <td class ="auto-style1"><img src="copia.png" /></td>
                    <td><a href="Copia.aspx"><h2>Copia de Seguridad</h2></a></td>
                </tr>
                <tr>
                    <td><asp:ImageButton runat="server" ID="btnSalir" ImageUrl="~/salir.png" OnClick="btnSalir_Click" AlternateText="Salir" ToolTip="Salir" /></td>
                </tr>
                
            </table>

        </div>
    </form>
</body>
</html>
