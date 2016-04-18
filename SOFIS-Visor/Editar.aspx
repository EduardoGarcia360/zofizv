<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Editar.aspx.cs" Inherits="SOFIS_Visor.Editar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" type="image/png" href="ico.ico" />
    <title>SOFIS</title>
    <style type="text/css">
    .centrar {
   height: 200px;
   width: 500px;
   margin-top: -150px;
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
<body style="background-image: url(fondo_general.jpg)">
    <form id="form1" runat="server">
    <div class="centrar">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
                <td colspan="2">Nuevo nombre</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="user.png" /></td>
                <td><asp:TextBox ID="txtnombre" runat="server" Width="178px"></asp:TextBox>
                    <asp:Label ID="lblnombre" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Nuevo apellido</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="user.png" /></td>
                <td><asp:TextBox ID="txtapellido" runat="server" Width="178px"></asp:TextBox>
                    <asp:Label ID="lblapellido" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Nuevo correo</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="email.png" /></td>
                <td><asp:TextBox ID="txtcorreo" runat="server" Width="219px"></asp:TextBox>
                    <asp:Label ID="lblcorreo" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Cambiar genero</td>
            </tr>
            <tr>
                <td class="auto-style2"><img src="genero.png" /></td>
                <td>
                    <select id="selegenero" runat="server">
                        <option value="m">Hombre</option>
                        <option value="f">Mujer</option>
                    </select>
                    <asp:Label ID="lblgenero" runat="server" Text=""></asp:Label>
                </td>
            </tr>
            <tr>
                <td colspan="2">Nueva contraseña</td>
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
                <td colspan="2"><asp:Label ID="lblMensaje" runat="server" Text="Puede cambiar todos o ninguno de los datos." ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
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
