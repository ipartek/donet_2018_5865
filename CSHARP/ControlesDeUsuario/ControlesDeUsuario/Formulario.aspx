<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="ControlesDeUsuario.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <jl:LabelTextBox runat="server" ID="ltbNombre" LabelTexto="Nombre" />
    <jl:LabelTextBox runat="server" ID="ltbDireccion" LabelTexto="Dirección" />
    <asp:Button runat="server" ID="BtnTest" OnClick="BtnTest_Click" Text="Ver datos"/>
    <asp:Label runat="server" ID="LblMensaje" />
    <jl:Boton runat="server" ID="BtnBoton" />
</asp:Content>
