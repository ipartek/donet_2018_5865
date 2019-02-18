<%@ Page Title="Gestión de Usuarios" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="Usuarios.aspx.cs" Inherits="PresentacionWebSimple.Usuarios" %>

<asp:Content runat="server" ContentPlaceHolderID="MainContent" ClientIDMode="Static">
    <div style="margin-top: 1em">
        <div class="form-group row">
            <asp:Label CssClass="col-sm-2 col-12" ID="Label4" runat="server" Text="Label">Id</asp:Label>
            <asp:TextBox CssClass="form-control col-sm-10 col-12" ID="TxtId" runat="server" TextMode="Number" ValidationGroup="usuario"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="El Id es obligatorio" ControlToValidate="TxtId" Display="Dynamic" ValidationGroup="usuario">*</asp:RequiredFieldValidator>
        </div>
        <div class="form-group row">
            <asp:Label CssClass="col-sm-2 col-12" ID="Label1" runat="server" Text="Label">Email</asp:Label>
            <asp:TextBox CssClass="form-control col-sm-10 col-12" ID="TxtEmail" runat="server" TextMode="Email" ValidationGroup="usuario"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="El Email es obligatorio" ControlToValidate="TxtEmail" Display="Dynamic" ValidationGroup="usuario">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TxtEmail" Display="Dynamic" ErrorMessage="El email no tiene el formato adecuado" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="usuario">*</asp:RegularExpressionValidator>
            <asp:CustomValidator ID="ValidadorEmail" runat="server" ErrorMessage="El email no es válido" Text="*" ControlToValidate="TxtEmail" OnServerValidate="ValidadorEmail_ServerValidate" ValidateEmptyText="true" ValidationGroup="usuario"></asp:CustomValidator>
        </div>
        <div class="form-group row">
            <asp:Label CssClass="col-sm-2 col-12" ID="Label2" runat="server" Text="Label">Password</asp:Label>
            <asp:TextBox CssClass="form-control col-sm-10 col-12" ID="TxtPassword" TextMode="Password" runat="server" ValidationGroup="usuario"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RfvPassword" runat="server" ControlToValidate="TxtPassword" Display="Dynamic" ErrorMessage="Es obligatorio rellenar la contraseña" ValidationGroup="usuario">*</asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RevPassword" runat="server" ControlToValidate="TxtPassword" Display="Dynamic" ErrorMessage="La contraseña tiene que tener mínimo 6 caracteres" ValidationExpression=".{6,}" ValidationGroup="usuario">*</asp:RegularExpressionValidator>
        </div>
        <div class="form-group row">
            <asp:Label CssClass="col-sm-2 col-12" ID="Label3" runat="server" Text="Label">DNI</asp:Label>
            <asp:TextBox CssClass="form-control col-sm-10 col-12" ID="TxtDni" runat="server"></asp:TextBox>
            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TxtDni" Display="Dynamic" ErrorMessage="El DNI no tiene el formato adecuado" ValidationExpression="^[\dXYZ]\d{7}[A-Z]$" ValidationGroup="usuario">*</asp:RegularExpressionValidator>--%>
            <asp:CustomValidator ID="ValidadorDni" runat="server" ErrorMessage="El DNI no es válido" Text="*" ControlToValidate="TxtDni" OnServerValidate="ValidadorDni_ServerValidate" ClientValidationFunction="validarDni" ValidationGroup="usuario"></asp:CustomValidator>
        </div>
        <div class="form-group row">
            <asp:Button CssClass="btn btn-primary offset-sm-2" ID="BtnAceptar" runat="server" Text="Aceptar" ValidationGroup="usuario" OnCommand="BtnAceptar_Command"/>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server"  ValidationGroup="usuario"/>
        </div>
    </div>
    <div>
        <table class="table table-striped table-bordered table-hover table-sm">
            <thead>
                <tr>
                    <th>Email</th>
                    <th>Contraseña</th>
                    <th>Opciones</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="RUsuarios" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("Email") %></td>
                            <td><%# DataBinder.Eval(Container.DataItem, "Password") %></td>
                            <td>
                                <asp:Button CssClass="btn btn-primary" ID="BtnEditar" runat="server"
                                    CommandName="editar" CommandArgument='<%# Eval("Id") %>' Text="Editar" OnCommand="ProcesarOpcionRejilla" />
                                <asp:Button CssClass="btn btn-danger" ID="BtnEliminar" runat="server"
                                    CommandName="eliminar" CommandArgument='<%# Eval("Id") %>' Text="Eliminar" OnCommand="ProcesarOpcionRejilla" />

                                <a class="btn btn-primary" 
                                    href="?opcion=editar&id=<%# Eval("Id") %>">Editar</a>
                                <a class="btn btn-danger" href="?opcion=eliminar&id=<%# Eval("Id") %>">Eliminar</a>
                            </td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
        
        <asp:GridView AutoGenerateColumns="false" CssClass="table table-striped table-bordered table-hover table-sm" ID="GvUsuarios" runat="server">
            <Columns>
                <asp:BoundField DataField="Email" HeaderText="Email"></asp:BoundField>
                <asp:BoundField DataField="Password" HeaderText="Contraseña"></asp:BoundField>

                <asp:TemplateField ShowHeader="True" HeaderText="Opciones">
                    <ItemTemplate>
                        <asp:Button CssClass="btn btn-primary" runat="server" Text="Editar" CommandName="Editar" CausesValidation="False" ID="Button1"></asp:Button>
                        <asp:Button CssClass="btn btn-danger" runat="server" Text="Eliminar" CommandName="Borrar" CausesValidation="False" ID="Button3"></asp:Button>
                    </ItemTemplate>
                </asp:TemplateField>

                <%--<asp:CommandField ControlStyle-CssClass="btn btn-danger" ShowDeleteButton="True" ShowEditButton="False" ShowSelectButton="False" ShowHeader="False" HeaderText="" ButtonType="Button"></asp:CommandField>--%>
            </Columns>
        </asp:GridView>

        
    </div>
    
</asp:Content>
