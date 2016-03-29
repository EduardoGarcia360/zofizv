<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="SOFIS_Visor.Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" type="image/png" href="ico.ico" />
    <title>SOFIS</title>
    <style type="text/css">
    .centrar {
   height: 200px;
   width: 500px;
   margin-top: -200px;
   margin-left: -150px;
   left: 50%;
   top: 50%;
   position: absolute;
}
        .auto-style2 {
            width: 32px;
        }
    </style>
</head>
<body style="background-image: url(fondo1.jpg)">
    <form id="form1" runat="server">
    <div class="centrar">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="2">Ingrese su Nombre</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="user.png" /></td>
                <td><asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">Ingrese su Apellido</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="user.png" /></td>
                <td><asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">Ingrese su Correo</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="email.png" /></td>
                <td><asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">Seleccione su Genero</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="genero.png" /></td>
                <td>
                    <select id="Select1">
                        <option>Hombre</option>
                        <option>Mujer</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td colspan="2">Tipo de Usuario al que pertenece</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="puesto.png" /></td>
                <td>
                    <select id="Select2">
                        <option>Administrador</option>
                        <option>Operador</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td colspan="2">Ingrese un nombre de usuario</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="apodo.png" /></td>
                <td><input id="Text1" type="text" placeholder="ej: EGarcia" /></td>
            </tr>
            <tr>
                <td colspan="2">Ingrese una contraseña</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="key.png" /></td>
                <td><input id="Password1" type="password" /></td>
            </tr>
            <tr>
                <td colspan="2">Confirme la contraseña</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="key.png" /></td>
                <td><input id="Password2" type="password" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
