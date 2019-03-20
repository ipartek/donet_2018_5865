<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LabelTextBox.ascx.cs" Inherits="ControlesDeUsuario.LabelTextBox" %>
<div class="form-group">
    <asp:Label ID="Lbl" AssociatedControlID="Txt" CssClass="col-md-2" runat="server">SIN INICIALIZAR</asp:Label>
    <div class="col-md-10">
        <asp:TextBox CssClass="form-control" runat="server" ID="Txt" />
    </div>
</div>
