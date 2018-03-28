<%@ Page Title="Bienvenido" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PresentacionWebForms._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table" id="empleados">
        <thead>
            <tr>
                <th>Id</th>
                <th>Departamento</th>
                <th>Nombre</th>
                <th>Fecha de Nacimiento</th>
                <th>Sueldo</th>
                <th>DNI</th>
                <th>Invitaciones</th>
                <th>Opciones</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="tabla" runat="server" OnItemCommand="tabla_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("DepartamentoAsignado.Nombre") %></td>
                        <td><%# Eval("Nombre") %></td>
                        <td><%# Eval("FechaDeNacimiento", "{0:dd/MM/yyyy}") %></td>
                        <td><%# Eval("Sueldo", "{0:c}") %></td>
                        <td><%# Eval("Dni") %></td>
                        <td>
                            <button class="btnmenos btn btn-default">-</button>
                            <asp:TextBox ID="txtCantidad" runat="server"
                                TextMode="Number" MaxLength="2" 
                                style="width: 4em; display: inline" Text="0"
                                CssClass="form-control"  
                                />
                            <button class="btnmas btn btn-default">+</button>
                        </td>
                        <td>
                            <asp:Button ID="btnAdd" runat="server" 
                                Text="Añadir" CommandArgument='<%# Eval("id") %>' 
                                CssClass="btn btn-primary"/>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>

</asp:Content>
