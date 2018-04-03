<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Invitaciones.aspx.cs" Inherits="PresentacionWebForms.Invitaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table">
        <thead>
            <tr>
                <th>Empleado</th>
                <th>Departamento</th>
                <th>Cantidad</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="tabla" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("EmpleadoInvitado.Nombre") %></td>
                        <td><%# Eval("EmpleadoInvitado.DepartamentoAsignado.Nombre") %></td>
                        <td><%# Eval("CantidadInvitaciones") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
