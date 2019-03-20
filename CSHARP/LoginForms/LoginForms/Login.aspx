<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginForms.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Login</h1>

    <asp:TextBox runat="server" ID="TxtEmail" TextMode="Email" placeholder="Email" />
    <asp:TextBox runat="server" ID="TxtPassword" TextMode="Password" placeholder="Password" />
    <asp:Button runat="server" ID="BtnLogin" Text="Login" OnClick="BtnLogin_Click" />

    <asp:LoginName ID="LoginName1" runat="server" />
    <asp:LoginStatus ID="LoginStatus1" runat="server" />
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>No estás logueado</AnonymousTemplate>
        <LoggedInTemplate>Logueado</LoggedInTemplate>
    </asp:LoginView>

    <%=User.Identity.Name %>
</asp:Content>
