<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="PresentacionWeb.Usuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView CssClass="table" ID="GvUsuarios" runat="server"></asp:GridView>
    <asp:Button runat="server" Text="Refrescar"/>
</asp:Content>
