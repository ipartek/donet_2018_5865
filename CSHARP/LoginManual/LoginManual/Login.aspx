<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginManual.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:TextBox ID="TxtEmail" runat="server" placeholder="Email" TextMode="Email" />
    <asp:TextBox ID="TxtPassword" runat="server" placeholder="Password" TextMode="Password" />
    <asp:Button ID="BtnLogin" runat="server" OnClick="BtnLogin_Click" Text="Login" />
</asp:Content>
