<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Buscar.aspx.cs" Inherits="SOFIS_Visor.Buscar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="icon" type="image/png" href="ico.ico" />
    <title>SOFIS</title>
    <style type="text/css">
        .auto-style1 {
            width: 113px;
        }
        .auto-style2 {
            width: 138px;
            height: 30px;
        }
        .auto-style3 {
            width: 67px;
        }
        .auto-style4 {
            width: 30px;
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
                <td class="auto-style3">
                    <input id="txtBusqueda_Codigo" runat="server" type="text" placeholder="Obligatorio" />
                </td>
                <td class="auto-style4">
                    <asp:ImageButton runat="server" ID="btnBuscar_Buscar" ImageUrl="~/buscar.png" ToolTip="Buscar" OnClick="btnBuscar_Buscar_Click" />
                </td>
                <td>

                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td>
                    <asp:ImageButton runat="server" ID="btnBuscar_Todos" ImageUrl="~/todos.png" ToolTip="Mostrar Todos" OnClick="btnBuscar_Todos_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="8"><asp:Label ID="lblmensaje" runat="server" Text="" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
        <asp:GridView ID="GridView1" runat="server" EmptyDataText="No hay datos para mostrar" GridLines="Both" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" >
            <Columns>
                <asp:TemplateField HeaderText="Cod. Empleado">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblCodEmpleado" Text='<%# Eval("cod_empleado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblNombre" Text='<%# Eval("nombre") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Apellido">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblApellido" Text='<%# Eval("apellido") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Correo">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblCorreo" Text='<%# Eval("correo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Genero">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblGenero" Text='<%# Eval("genero") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Puesto">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblPuesto" Text='<%# Eval("puesto") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nombre Usuario">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblUserName" Text='<%# Eval("usuario") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Contraseña">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblContra" Text='<%# Eval("contra") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Activo">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblactivo" Text='<%# Eval("activo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="btnDardebaja" ImageUrl="~/dar_de_baja.png" ToolTip="Dar de Baja" CommandName="DarDeBaja" CommandArgument='<%# Eval("cod_empleado") %>' />
                        <asp:ImageButton runat="server" ID="btnBitacora" ImageUrl="~/ver_bitacora.png" ToolTip="Ver Bitacora" CommandName="Bitacora" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
