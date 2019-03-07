<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Usuarios.aspx.cs" Inherits="PresentacionWeb.Usuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="formulario" class="form-horizontal">
        <div class="form-group">
            <asp:Label AssociatedControlID="TxtEmail" CssClass="col-sm-2 control-label" runat="server">Email</asp:Label>
            <div class="col-sm-10">
                <asp:TextBox TextMode="Email" CssClass="form-control" ID="TxtEmail" placeholder="Email" runat="server" />

            </div>
        </div>
        <div class="form-group">
            <asp:Label AssociatedControlID="TxtPassword" CssClass="col-sm-2 control-label" runat="server">Contraseña</asp:Label>
            <div class="col-sm-10">
                <asp:TextBox TextMode="Password" CssClass="form-control" ID="TxtPassword" placeholder="Contraseña" runat="server" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label AssociatedControlID="DdlRoles" CssClass="col-sm-2 control-label" runat="server">Rol</asp:Label>
            <div class="col-sm-10">
                <asp:DropDownList CssClass="form-control" ID="DdlRoles" runat="server">
                    <%--<asp:ListItem Value="1" Text="ADMIN" />--%>
                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group">
            <div class="col-sm-offset-2 col-sm-10">
                <asp:Button ID="BtnAceptar" CssClass="btn btn-default" Text="Aceptar" OnClick="BtnAceptar_Click" runat="server" />
            </div>
        </div>

    </div>

    <asp:ObjectDataSource ID="OdsUsuarios" runat="server" DataObjectTypeName="Tipos.Usuario" DeleteMethod="Borrar" InsertMethod="Insertar" SelectMethod="BuscarTodos" TypeName="AccesoDatos.UsuarioSqlDao" UpdateMethod="Modificar">

        <DeleteParameters>
            <asp:Parameter Name="id" Type="Int32"></asp:Parameter>
        </DeleteParameters>
    </asp:ObjectDataSource>
    
    <asp:ObjectDataSource ID="OdsForm" runat="server" DataObjectTypeName="Tipos.Usuario" DeleteMethod="Borrar" InsertMethod="Insertar" SelectMethod="BuscarPorId" TypeName="AccesoDatos.UsuarioSqlDao" UpdateMethod="Modificar" OnDeleted="RefrescarGvCompleto" OnInserted="RefrescarGvCompleto" OnUpdated="RefrescarGvCompleto">
        <SelectParameters>
            <asp:ControlParameter ControlID="GvCompleto" PropertyName="SelectedValue" Name="id" Type="Int32"></asp:ControlParameter>
        </SelectParameters>
    </asp:ObjectDataSource>
    
    <asp:FormView ID="FvCompleto" runat="server" DataSourceID="OdsForm" AllowPaging="True" DataKeyNames="Id" DefaultMode="Insert">
        <EditItemTemplate>
            Id:
            <asp:Label Text='<%# Bind("Id") %>' runat="server" ID="IdTextBox" /><br />
            Email:
            <asp:TextBox Text='<%# Bind("Email") %>' runat="server" ID="EmailTextBox" /><br />
            Password:
            <asp:TextBox Text='<%# Bind("Password") %>' runat="server" ID="PasswordTextBox" /><br />
            <asp:LinkButton runat="server" Text="Actualizar" CommandName="Update" ID="UpdateButton" CausesValidation="True" />&nbsp;<asp:LinkButton runat="server" Text="Cancelar" CommandName="Cancel" ID="UpdateCancelButton" CausesValidation="False" />
        </EditItemTemplate>
        <InsertItemTemplate>
            Email:
            <asp:TextBox Text='<%# Bind("Email") %>' runat="server" ID="EmailTextBox" /><br />
            Password:
            <asp:TextBox Text='<%# Bind("Password") %>' runat="server" ID="PasswordTextBox" /><br />
            <asp:LinkButton runat="server" Text="Insertar" CommandName="Insert" ID="InsertButton" CausesValidation="True" />&nbsp;<asp:LinkButton runat="server" Text="Cancelar" CommandName="Cancel" ID="InsertCancelButton" CausesValidation="False" />
        </InsertItemTemplate>
        <ItemTemplate>
            Id:
            <asp:Label Text='<%# Bind("Id") %>' runat="server" ID="IdLabel" /><br />
            Email:
            <asp:Label Text='<%# Bind("Email") %>' runat="server" ID="EmailLabel" /><br />
            Password:
            <asp:Label Text='<%# Bind("Password") %>' runat="server" ID="PasswordLabel" /><br />
            <asp:LinkButton runat="server" Text="Editar" CommandName="Edit" ID="EditButton" CausesValidation="False" />&nbsp;<asp:LinkButton runat="server" Text="Eliminar" CommandName="Delete" ID="DeleteButton" CausesValidation="False" OnClientClick="return confirm('¿Seguro que quieres borrar?');" />&nbsp;<asp:LinkButton runat="server" Text="Nuevo" CommandName="New" ID="NewButton" CausesValidation="False" />
        </ItemTemplate>
    </asp:FormView>

    <asp:GridView CssClass="table" ID="GvCompleto" runat="server" DataSourceID="OdsUsuarios" AllowPaging="True" AutoGenerateColumns="False" DataKeyNames="Id" OnSelectedIndexChanged="GvCompleto_SelectedIndexChanged">
        <Columns>
            <asp:BoundField DataField="Id" HeaderText="Id" SortExpression="Id"></asp:BoundField>
            <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email"></asp:BoundField>
            <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password"></asp:BoundField>
            <asp:CommandField ShowEditButton="True" ShowDeleteButton="False" ShowSelectButton="False" ControlStyle-CssClass="btn btn-primary"></asp:CommandField>
            <asp:CommandField ShowEditButton="False" ShowDeleteButton="True" ShowSelectButton="False" ControlStyle-CssClass="btn btn-danger"></asp:CommandField>
            <asp:CommandField ShowEditButton="False" ShowDeleteButton="False" ShowSelectButton="True" ControlStyle-CssClass="btn btn-default"></asp:CommandField>
        </Columns>
        
    </asp:GridView>

    <asp:GridView CssClass="table" ID="GvUsuarios" runat="server">
    </asp:GridView>

    <asp:Button runat="server" Text="Refrescar" />

    <%--<table class="table">
        <thead>
            <tr>
                <th>Id</th>
                <th>Email</th>
                <th>Password</th>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="RUsuarios" runat="server">
                <ItemTemplate>
                    <tr>
                        <td><%# Eval("Id") %></td>
                        <td><%# Eval("Email") %></td>
                        <td><%# Eval("Password") %></td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>--%>
</asp:Content>
