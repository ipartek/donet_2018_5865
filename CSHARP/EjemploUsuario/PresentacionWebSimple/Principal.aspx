<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="PresentacionWebSimple.Principal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>PRINCIPAL</h1>
    <form id="form1" runat="server">
        <div>
            Hola, <asp:Label ID="LblUsuario" runat="server" />
            <asp:Button ID="BtnDesconectar" runat="server" OnClick="BtnDesconectar_Click" 
                Text="Desconectar"/>
        </div>
        <div>
            <asp:Label ID="LblChat" runat="server" />
            <asp:TextBox ID="TxtChat" runat="server" />
            <asp:Button ID="BtnChat" runat="server" Text="Enviar chat" OnClick="BtnChat_Click" />
            <asp:Button runat="server" Text="Refrescar Chat" />
        </div>
    </form>
</body>
</html>
