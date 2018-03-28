<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Invitaciones.aspx.cs" Inherits="PresentacionWebForms.Invitaciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <table class="table">
        <thead>
            <tr>
                <th>Id Empleado</th>
                <th>Cantidad</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="tabla" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# DataBinder.Eval((System.Collections.Generic.KeyValuePair<int, int>)Container.DataItem,"Key") %></td>
                        <td><%# DataBinder.Eval((System.Collections.Generic.KeyValuePair<int, int>)Container.DataItem,"Value") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
