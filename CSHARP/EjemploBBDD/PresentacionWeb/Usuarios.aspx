<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="PresentacionWeb.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="formulario" class="form-horizontal">
        <div class="form-group">
            <asp:Label AssociatedControlID="TxtEmail" CssClass="col-sm-2 control-label" runat="server">Email</asp:Label>
            <div class="col-sm-10">
                <asp:TextBox TextMode="Email" CssClass="form-control" ID="TxtEmail" placeholder="Email" runat="server" />

            </div>
        </div>
        <div class="form-group">
            <asp:Label AssociatedControlID="TxtPassword" CssClass="col-sm-2 control-label" runat="server">Contraseña</asp:Label>
            <div class="col-sm-10">
                <asp:TextBox TextMode="Password" CssClass="form-control" ID="TxtPassword" placeholder="Contraseña" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <asp:Button ID="BtnAceptar" CssClass="btn btn-default" Text="Aceptar" OnClick="BtnAceptar_Click" runat="server"/>
            </div>
        </div>

    </div>

    <asp:GridView CssClass="table" ID="GvUsuarios" runat="server"></asp:GridView>

    <asp:Button runat="server" Text="Refrescar" />

    <table class="table">
        <thead>
            <tr>
                <th>Id</th>
                <th>Email</th>
                <th>Password</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="RUsuarios" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("Password") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</asp:Content>
