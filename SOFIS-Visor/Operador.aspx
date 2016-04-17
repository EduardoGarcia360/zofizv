<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Operador.aspx.cs" Inherits="SOFIS_Visor.Operador" %>

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
                    <td class="auto-style1"><img src="nuevo.png"</td>
                    <td><a href="Registrar.aspx"><h2>Nuevo Usuario</h2></a></td>
                </tr>
                <tr>
                    <td class="auto-style1"><img src="buscar2.png" /></td>
                    <td><a href="Buscar.aspx"><h2>Buscar Usuario</h2></a></td>
                </tr>
                <tr>
                    
                    <td><asp:ImageButton runat="server" ID="btnSalir" ImageUrl="~/salir.png" OnClick="btnSalir_Click" AlternateText="Salir" ToolTip="Salir" /></td>
                </tr>
                
            </table>

        </div>
    </form>
</body>
</html>
