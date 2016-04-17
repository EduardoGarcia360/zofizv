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
                <td colspan="2">Ingrese su Nombre (*)</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="user.png" /></td>
                <td><asp:TextBox ID="txtnombre" runat="server" Width="178px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">Ingrese su Apellido (*)</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="user.png" /></td>
                <td><asp:TextBox ID="txtapellido" runat="server" Width="178px"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">Ingrese su Correo (*)</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="email.png" /></td>
                <td><asp:TextBox ID="txtcorreo" runat="server" Width="219px"></asp:TextBox>
                    <asp:Label ID="lblcorreo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Seleccione su Genero (*)</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="genero.png" /></td>
                <td>
                    <select id="selegenero" runat="server">
                        <option value="h">Hombre</option>
                        <option value="m">Mujer</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td colspan="2">Tipo de Usuario al que pertenece (*)</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="puesto3.png" /></td>
                <td>
                    <select id="selepuesto" runat="server">
                        <option value="a">Administrador</option>
                        <option value="o">Operador</option>
                    </select>
                </td>
            </tr>
            <tr>
                <td colspan="2">Ingrese un nombre de usuario (*)</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="apodo.png" /></td>
                <td><asp:TextBox ID="txtapodo" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">Ingrese una contraseña (*)</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="key.png" /></td>
                <td><asp:TextBox ID="txtcontra1" runat="server" TextMode="Password"></asp:TextBox><asp:Label ID="lblcontra1" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2">Confirme la contraseña (*)</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="key.png" /></td>
                <td><asp:TextBox ID="txtcontra2" runat="server" TextMode="Password"></asp:TextBox><asp:Label ID="lblcontra2" runat="server" Text=""></asp:Label></td>
            </tr>
            <tr>
                <td colspan="2"><asp:Label ID="Label1" runat="server" Text="(*) Campo Obligatorio" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnGuardar" runat="server" Text="Registrar" OnClick="btnGuardar_Click" />
                </td>
            </tr>
            <tr>
                <td><asp:ImageButton runat="server" ID="btnRegresar" ImageUrl="~/regresar.png" ToolTip="Regresar" OnClick="btnRegresar_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
