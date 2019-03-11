<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PresentacionDataSetWeb._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    

    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" DataSourceID="SqlDataSource1" EmptyDataText="No hay registros de datos para mostrar." AllowPaging="True" AllowSorting="True">
    <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
        <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" InsertVisible="False" />
        <asp:BoundField DataField="IdRol" HeaderText="IdRol" SortExpression="IdRol" />
        <asp:BoundField DataField="IdTutor" HeaderText="IdTutor" SortExpression="IdTutor" />
        <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
        <asp:BoundField DataField="Password" HeaderText="Password" SortExpression="Password" />
    </Columns>
</asp:GridView>
    <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" DeleteMethod="Delete" InsertMethod="Insert" OldValuesParameterFormatString="original_{0}" SelectMethod="GetData" TypeName="PresentacionDataSetWeb.EjemploBBDDTableAdapters.UsuariosTableAdapter" UpdateMethod="Update">
        <DeleteParameters>
            <asp:Parameter Name="Original_Id" Type="Int32" />
            <asp:Parameter Name="Original_IdRol" Type="Int32" />
            <asp:Parameter Name="Original_IdTutor" Type="Int32" />
            <asp:Parameter Name="Original_Email" Type="String" />
            <asp:Parameter Name="Original_Password" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="IdRol" Type="Int32" />
            <asp:Parameter Name="IdTutor" Type="Int32" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="IdRol" Type="Int32" />
            <asp:Parameter Name="IdTutor" Type="Int32" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="Original_Id" Type="Int32" />
            <asp:Parameter Name="Original_IdRol" Type="Int32" />
            <asp:Parameter Name="Original_IdTutor" Type="Int32" />
            <asp:Parameter Name="Original_Email" Type="String" />
            <asp:Parameter Name="Original_Password" Type="String" />
        </UpdateParameters>
    </asp:ObjectDataSource>
    <asp:FormView ID="FormView1" runat="server" DataKeyNames="Id" DataSourceID="SqlDataSource2" DefaultMode="Insert" OnItemInserted="FormView1_ItemInserted">
        <EditItemTemplate>
            Id:
            <asp:Label ID="IdLabel1" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            IdRol:
            <asp:TextBox ID="IdRolTextBox" runat="server" Text='<%# Bind("IdRol") %>' />
            <br />
            IdTutor:
            <asp:TextBox ID="IdTutorTextBox" runat="server" Text='<%# Bind("IdTutor") %>' />
            <br />
            Email:
            <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
            <br />
            Password:
            <asp:TextBox ID="PasswordTextBox" runat="server" Text='<%# Bind("Password") %>' />
            <br />
            <asp:LinkButton ID="UpdateButton" runat="server" CausesValidation="True" CommandName="Update" Text="Actualizar" />
            &nbsp;<asp:LinkButton ID="UpdateCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
        </EditItemTemplate>
        <InsertItemTemplate>
            IdRol:
            <asp:TextBox ID="IdRolTextBox" runat="server" Text='<%# Bind("IdRol") %>' />
            <br />
            IdTutor:
            <asp:TextBox ID="IdTutorTextBox" runat="server" Text='<%# Bind("IdTutor") %>' />
            <br />
            Email:
            <asp:TextBox ID="EmailTextBox" runat="server" Text='<%# Bind("Email") %>' />
            <br />
            Password:
            <asp:TextBox ID="PasswordTextBox" runat="server" Text='<%# Bind("Password") %>' />
            <br />
            <asp:LinkButton ID="InsertButton" runat="server" CausesValidation="True" CommandName="Insert" Text="Insertar" />
            &nbsp;<asp:LinkButton ID="InsertCancelButton" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancelar" />
        </InsertItemTemplate>
        <ItemTemplate>
            Id:
            <asp:Label ID="IdLabel" runat="server" Text='<%# Eval("Id") %>' />
            <br />
            IdRol:
            <asp:Label ID="IdRolLabel" runat="server" Text='<%# Bind("IdRol") %>' />
            <br />
            IdTutor:
            <asp:Label ID="IdTutorLabel" runat="server" Text='<%# Bind("IdTutor") %>' />
            <br />
            Email:
            <asp:Label ID="EmailLabel" runat="server" Text='<%# Bind("Email") %>' />
            <br />
            Password:
            <asp:Label ID="PasswordLabel" runat="server" Text='<%# Bind("Password") %>' />
            <br />
            <asp:LinkButton ID="EditButton" runat="server" CausesValidation="False" CommandName="Edit" Text="Editar" />
            &nbsp;<asp:LinkButton ID="DeleteButton" runat="server" CausesValidation="False" CommandName="Delete" Text="Eliminar" />
            &nbsp;<asp:LinkButton ID="NewButton" runat="server" CausesValidation="False" CommandName="New" Text="Nuevo" />
        </ItemTemplate>
    </asp:FormView>
    <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ipartekConnectionString1 %>" DeleteCommand="DELETE FROM [Usuarios] WHERE [Id] = @original_Id AND (([IdRol] = @original_IdRol) OR ([IdRol] IS NULL AND @original_IdRol IS NULL)) AND (([IdTutor] = @original_IdTutor) OR ([IdTutor] IS NULL AND @original_IdTutor IS NULL)) AND [Email] = @original_Email AND [Password] = @original_Password" InsertCommand="INSERT INTO [Usuarios] ([IdRol], [IdTutor], [Email], [Password]) VALUES (@IdRol, @IdTutor, @Email, @Password)" OldValuesParameterFormatString="original_{0}" SelectCommand="SELECT * FROM [Usuarios] WHERE ([Id] = @Id)" UpdateCommand="UPDATE [Usuarios] SET [IdRol] = @IdRol, [IdTutor] = @IdTutor, [Email] = @Email, [Password] = @Password WHERE [Id] = @original_Id AND (([IdRol] = @original_IdRol) OR ([IdRol] IS NULL AND @original_IdRol IS NULL)) AND (([IdTutor] = @original_IdTutor) OR ([IdTutor] IS NULL AND @original_IdTutor IS NULL)) AND [Email] = @original_Email AND [Password] = @original_Password">
        <DeleteParameters>
            <asp:Parameter Name="original_Id" Type="Int32" />
            <asp:Parameter Name="original_IdRol" Type="Int32" />
            <asp:Parameter Name="original_IdTutor" Type="Int32" />
            <asp:Parameter Name="original_Email" Type="String" />
            <asp:Parameter Name="original_Password" Type="String" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="IdRol" Type="Int32" />
            <asp:Parameter Name="IdTutor" Type="Int32" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
        </InsertParameters>
        <SelectParameters>
            <asp:ControlParameter ControlID="GridView1" Name="Id" PropertyName="SelectedValue" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="IdRol" Type="Int32" />
            <asp:Parameter Name="IdTutor" Type="Int32" />
            <asp:Parameter Name="Email" Type="String" />
            <asp:Parameter Name="Password" Type="String" />
            <asp:Parameter Name="original_Id" Type="Int32" />
            <asp:Parameter Name="original_IdRol" Type="Int32" />
            <asp:Parameter Name="original_IdTutor" Type="Int32" />
            <asp:Parameter Name="original_Email" Type="String" />
            <asp:Parameter Name="original_Password" Type="String" />
        </UpdateParameters>
    </asp:SqlDataSource>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ipartekConnectionString1 %>" DeleteCommand="DELETE FROM [Usuarios] WHERE [Id] = @Id" InsertCommand="INSERT INTO [Usuarios] ([IdRol], [IdTutor], [Email], [Password]) VALUES (@IdRol, @IdTutor, @Email, @Password)" ProviderName="<%$ ConnectionStrings:ipartekConnectionString1.ProviderName %>" SelectCommand="SELECT [Id], [IdRol], [IdTutor], [Email], [Password] FROM [Usuarios]" UpdateCommand="UPDATE [Usuarios] SET [IdRol] = @IdRol, [IdTutor] = @IdTutor, [Email] = @Email, [Password] = @Password WHERE [Id] = @Id">
    <DeleteParameters>
        <asp:Parameter Name="Id" Type="Int32" />
    </DeleteParameters>
    <InsertParameters>
        <asp:Parameter Name="IdRol" Type="Int32" />
        <asp:Parameter Name="IdTutor" Type="Int32" />
        <asp:Parameter Name="Email" Type="String" />
        <asp:Parameter Name="Password" Type="String" />
    </InsertParameters>
    <UpdateParameters>
        <asp:Parameter Name="IdRol" Type="Int32" />
        <asp:Parameter Name="IdTutor" Type="Int32" />
        <asp:Parameter Name="Email" Type="String" />
        <asp:Parameter Name="Password" Type="String" />
        <asp:Parameter Name="Id" Type="Int32" />
    </UpdateParameters>
</asp:SqlDataSource>

    

</asp:Content>
