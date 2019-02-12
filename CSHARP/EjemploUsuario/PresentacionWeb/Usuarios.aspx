<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="PresentacionWebSimple.Usuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>Usuarios</title>

    <script>
        function validarDni(object, args) {
            'use strict';
            var numero, letra, letras;

            letras = 'TRWAGMYFPDXBNJZSQVHLCKE';

            numero = dni.substring(0, dni.length - 1);

            letra = dni[8];

            numero = numero.replace('X', '0').replace('Y', '1').replace('Z', '2');

            args.IsValid = letra === letras[numero % 23];
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="Label1" runat="server" Text="Label">Email</asp:Label>
                <asp:TextBox ID="TxtEmail" runat="server" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El Email es obligatorio" ControlToValidate="TxtEmail" Display="Dynamic">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtEmail" Display="Dynamic" ErrorMessage="El email no tiene el formato adecuado" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:Label ID="Label2" runat="server" Text="Label">Password</asp:Label>
                <asp:TextBox ID="TxtPassword" TextMode="Password" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TxtPassword" Display="Dynamic" ErrorMessage="Es obligatorio rellenar la contraseña">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TxtPassword" Display="Dynamic" ErrorMessage="La contraseña tiene que tener mínimo 6 caracteres" ValidationExpression=".{6,}">*</asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:Label ID="Label3" runat="server" Text="Label">DNI</asp:Label>
                <asp:TextBox ID="TxtDni" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="El DNI es obligatorio" ControlToValidate="TxtDni" Display="Dynamic">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TxtDni" Display="Dynamic" ErrorMessage="El DNI no tiene el formato adecuado" ValidationExpression="^[\dXYZ]\d{7}[A-Z]$">*</asp:RegularExpressionValidator>
                <asp:CustomValidator ID="ValidadorDni" runat="server" ErrorMessage="El DNI no es válido" Text="*" ControlToValidate="TxtDni" OnServerValidate="ValidadorDni_ServerValidate" ClientValidationFunction="validarDni"></asp:CustomValidator>
            </div>
            <div>
                <asp:Button ID="BtnAceptar" runat="server" Text="Aceptar" OnClick="BtnAceptar_Click" />
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
            </div>
        </div>
        <div>
            <asp:GridView ID="GvUsuarios" runat="server"></asp:GridView>
        </div>
    </form>


</body>
</html>
