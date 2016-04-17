<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buscar.aspx.cs" Inherits="SOFIS_Visor.Buscar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>SOFIS</title>
    <style type="text/css">
        .auto-style1 {
            width: 138px;
        }
        .auto-style2 {
            width: 138px;
            height: 30px;
        }
    </style>
</head>
<body style="background-image: url(fondo_general.jpg)">
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td class="auto-style2" colspan="8"><h3 style="width: 677px">Ingrese el contenido para la busqueda</h3></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <h5>Codigo de Usuario</h5>
                </td>
                <td>
                    <input id="txtBusqueda_Codigo" runat="server" type="text" placeholder="Obligatorio" />
                </td>
                <td>
                    <h5>Nombre</h5>
                </td>
                <td>
                    <input id="txtBusqueda_Nombre" runat="server" type="text" placeholder="Opcional" />
                </td>
                <td>
                    <h5>Apellido</h5>
                </td>
                <td>
                    <input id="txtBusqueda_Apellido" runat="server" type="text" placeholder="Opcional" />
                </td>
                <td>

                </td>
                <td>
                    <asp:ImageButton runat="server" ID="btnBuscar_Buscar" ImageUrl="~/buscar.png" ToolTip="Buscar" />
                </td>
                <td>

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td>
                    <asp:ImageButton runat="server" ID="btnBuscar_Todos" ImageUrl="~/todos.png" ToolTip="Mostrar Todos" />
                </td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" EmptyDataText="No hay datos para mostrar" GridLines="Horizontal" AutoGenerateColumns="false"></asp:GridView>
    </div>
    </form>
</body>
</html>
