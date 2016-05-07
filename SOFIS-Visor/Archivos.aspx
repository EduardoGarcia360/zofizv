<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Archivos.aspx.cs" Inherits="SOFIS_Visor.Archivos" %>

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
                    <h5>Fecha de Recepcion</h5>
                </td>
                <td class="auto-style3">
                    <input id="txtArchivo_Fecha" runat="server" type="text" placeholder="Obligatorio. ej. 01/05/2016" width="230" />
                </td>
                <td>
                    <select id="selecdepa" runat="server">
                        <option value="OPCIONAL">Departamento</option>
                        <option value="CREDITOS">Creditos</option>
                        <option value="BANCA">Banca</option>
                        <option value="COMUNICACION">Comunicacion</option>
                    </select>
                </td>
                <td>
                    <select id="selectipo" runat="server">
                            <option value="OPCIONAL">Tipo Trabajo</option>
                            <option value="CARTA">Carta</option>
                            <option value="ESTADODECUENTA">Estado de Cuenta</option>
                            <option value="REPORTE">Reporte</option>
                            <option value="PUBLICIDAD">Publicidad</option>
                     </select>
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
                <asp:TemplateField HeaderText="Cod. Archivo">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblCodarchivo" Text='<%# Eval("cod_archivo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Departamento">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lbldepartamento" Text='<%# Eval("departamento") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Tipo de Trabajo">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lbltipo" Text='<%# Eval("tipo_trabajo") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Fecha Generado">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblfechagene" Text='<%# Eval("fecha_generado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Hora Generado">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblhoragene" Text='<%# Eval("hora_generado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Fecha Recepcion">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblfecharece" Text='<%# Eval("fecha_recepcion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Hora Recepcion">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblhorarece" Text='<%# Eval("hora_recepcion") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Num. Secuencia">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblsecuencia" Text='<%# Eval("secuencia") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Estado de Archivo">
                    <ItemTemplate>
                        <asp:Label runat="server" ID="lblestado" Text='<%# Eval("estado") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Acciones">
                    <ItemTemplate>
                        <asp:ImageButton runat="server" ID="btnValidar" ImageUrl="~/validar.png" ToolTip="Validar" CommandName="ValidarArchivo" CommandArgument='<%# Eval("cod_archivo") %>' />
                        <asp:ImageButton runat="server" ID="btnDescargar" ImageUrl="~/descargar.png" ToolTip="Descargar" CommandName="Descargar" CommandArgument='<%# Eval("cod_archivo") %>' />
                        <asp:ImageButton runat="server" ID="btnComposicion" ImageUrl="~/composicion.png" ToolTip="Composicion" CommandName="Composicion" CommandArgument='<%# Eval("cod_archivo") %>' />
                        <asp:ImageButton runat="server" ID="btnInsercion" ImageUrl="~/insercion.png" ToolTip="Insercion a Trab. de Impre." CommandName="Insercion" CommandArgument='<%# Eval("cod_archivo") %>' />
                        <asp:ImageButton runat="server" ID="btnRendering" ImageUrl="~/rendering.png" ToolTip="Rendering de Trab. de Impre." CommandName="Rendering" CommandArgument='<%# Eval("cod_archivo") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>