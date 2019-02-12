<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PresentacionWebSimple.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>Página de mantenimiento de usuarios</h1>

    <form id="form1" runat="server">
        <div>
            <asp:Label ID="LblNombre" runat="server" Text="Nombre"></asp:Label>
            <asp:TextBox ID="TxtNombre" runat="server"></asp:TextBox>
            <asp:Button ID="BtnAceptar" runat="server" Text="Saludar" OnClick="BtnAceptar_Click" />
            <asp:Label ID="LblSaludo" runat="server"></asp:Label>
            <br />
            <span>Nombre</span>
            <input type="text" id="INombre" runat="server" />
            <input type="submit" id="IAceptar" value="Saludar" runat="server" onserverclick="IAceptar_Click"/>
            <span id="SSaludo" runat="server"></span>
        </div>
    </form>
</body>
</html>
