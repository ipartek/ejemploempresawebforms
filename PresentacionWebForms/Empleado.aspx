<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Empleado.aspx.cs" Inherits="PresentacionWebForms.Empleado" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Mantenimiento de empleados</h1>
    <div class="form-horizontal">
        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtId" 
                CssClass="col-sm-2 control-label">Id</asp:Label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" Enabled="false" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="ddlDepartamento" 
                CssClass="col-sm-2 control-label">Departamento</asp:Label>
            <div class="col-sm-10">
                <asp:DropDownList runat="server" ID="ddlDepartamento" CssClass="form-control" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtNombre" 
                CssClass="col-sm-2 control-label">Nombre</asp:Label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtFecha" 
                CssClass="col-sm-2 control-label">Fecha de Nacimiento</asp:Label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="txtFecha" CssClass="form-control" TextMode="Date" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtSueldo" 
                CssClass="col-sm-2 control-label">Sueldo</asp:Label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="txtSueldo" CssClass="form-control" TextMode="Number" />
            </div>
        </div>

        <div class="form-group">
            <asp:Label runat="server" AssociatedControlID="txtDni" 
                CssClass="col-sm-2 control-label">DNI</asp:Label>
            <div class="col-sm-10">
                <asp:TextBox runat="server" ID="txtDni" CssClass="form-control" MaxLength="9" 
                    pattern="\d{8}[A-Z]" />
            </div>
        </div>

        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <asp:Button ID="btnAceptar" runat="server" CssClass="btn"></asp:Button>
                <a href="Admin" class="btn btn-default">Cancelar</a>

<%--                <asp:Button ID="btnCancelar" runat="server" CssClass="btn btn-default"
                    Text="Cancelar"></asp:Button>--%>
            </div>
        </div>
    </div></asp:Content>
