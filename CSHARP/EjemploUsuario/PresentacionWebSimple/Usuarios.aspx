<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="PresentacionWebSimple.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Usuarios</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Label">Email</asp:Label>
                <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Label">Password</asp:Label>
                <asp:TextBox ID="TxtPassword" TextMode="Password" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" />
            </div>
        </div>
        <div>
            <asp:GridView ID="GvUsuarios" runat="server"></asp:GridView>
        </div>
    </form>

    
</body>
</html>
