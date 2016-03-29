<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SOFIS_Visor.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" type="image/png" href="ico.ico" />
    <title>SOFIS</title>
    <style type="text/css">
    .centrar {
   height: 200px;
   width: 500px;
   margin-top: -50px;
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
<body style="background-image: url(fondo2.jpg)">
    <form id="form1" runat="server">
        <div class="centrar">
            <table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                    <td colspan="2">Ingrese su Usuario</td>
                </tr>
                <tr>
                    <td class="auto-style1"><img src="user2.png" /></td>
                    <td><input id="txtUserName" type="text" placeholder="usuario23" required="required" /><asp:Label ID="lblError_Usuario" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2">Ingrese su Contraseña</td>
                </tr>
                <tr>
                    <td class="auto-style1"><img src="key2.png" /></td>
                    <td><input id="txtPassword" type="password" required="required" /><asp:Label ID="lblError_Contra" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td colspan="2"><asp:Label ID="lblError_Login" runat="server" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                    <td><asp:Button ID="btnIniciar" runat="server" Text="Entrar" BorderStyle="Outset" /></td>
                </tr>
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <img src="nuevo2.png" /></td>
                    <td>¿No es un usuario?&nbsp;<a href="Registrar.aspx">Registrese!</a></td>
                </tr>
            </table>

        </div>
    </form>
</body>
</html>
