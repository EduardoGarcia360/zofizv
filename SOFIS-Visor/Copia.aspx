<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Copia.aspx.cs" Inherits="SOFIS_Visor.Copia" %>

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
        .auto-style4 {
            width: 30px;
        }
        #txtArchivo_Fecha {
            width: 197px;
        }
        .auto-style5 {
            width: 4px;
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
                    <h5>Fecha de Recepcion</h5>
                </td>
                <td class="auto-style5">
                    <input id="txtCopia_Fecha" runat="server" type="text" placeholder="Obligatorio. ej. 01/05/2016" />
                </td>
                
                <td class="auto-style4">
                    <asp:ImageButton runat="server" ID="btnBuscar" ImageUrl="~/buscar.png" ToolTip="Buscar" OnClick="btnBuscar_Click" />
                </td>
                <td>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;</td>
                <td>
                    <asp:ImageButton runat="server" ID="btnMostrar_Todos" ImageUrl="~/todos.png" ToolTip="Mostrar Todos" OnClick="btnMostrar_Todos_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="8"><asp:Label ID="lblmensaje" runat="server" Text="" ForeColor="Red"></asp:Label></td>
            </tr>
        </table>
        

        <asp:GridView ID="GridView1" runat="server" EmptyDataText="No hay datos para mostrar" GridLines="Both" AutoGenerateColumns="false" OnRowCommand="GridView1_RowCommand" >
            <Columns>
                <asp:TemplateField HeaderText="Cod. Archivo Copia">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblCodarchivo" Text='<%# Eval("cod_copia") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblnombre" Text='<%# Eval("nombre") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Fecha de Recepcion">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblfechare" Text='<%# Eval("fecha_recepcion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Hora de Recepcion">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblhorare" Text='<%# Eval("hora_recepcion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Accion">
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="btnDescarga" ImageUrl="~/descargar.png" ToolTip="Descargar" CommandName="DescargarC" CommandArgument='<%# Eval("cod_copia") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>