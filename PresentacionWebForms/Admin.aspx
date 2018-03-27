<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="PresentacionWebForms.Admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button ID="btnAlta" runat="server" Text="Alta" CssClass="btn btn-primary" OnClick="btnAlta_Click" />

    <table class="table" id="empleados">
        <thead>
            <tr>
                <th>Id</th>
                <th>Departamento</th>
                <th>Nombre</th>
                <th>Fecha de Nacimiento</th>
                <th>Sueldo</th>
                <th>DNI</th>
                <th>Opciones</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="tabla" runat="server" OnItemCommand="tabla_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("IdDepartamento") %></td>
                        <td><%# Eval("Nombre") %></td>
                        <td><%# Eval("FechaDeNacimiento") %></td>
                        <td><%# Eval("Sueldo") %></td>
                        <td><%# Eval("Dni") %></td>
                        <td>
                            <asp:LinkButton ID="btnEditar" runat="server" Text="Editar" 
                                CommandName="editar" CommandArgument="1" CssClass="btn btn-primary"/>
                            <asp:LinkButton ID="btnBorrar" runat="server" Text="Borrar" 
                                CommandName="borrar" CommandArgument="1" CssClass="btn btn-danger" />
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
    </table>
</asp:Content>

