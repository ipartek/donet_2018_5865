<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="LoginMembership.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:LoginView ID="LoginView1" runat="server">
        <AnonymousTemplate>
            <asp:Login ID="Login1" runat="server">
            </asp:Login>
            <asp:CreateUserWizard ID="CreateUserWizard1" runat="server">
                <WizardSteps>
                    <asp:CreateUserWizardStep runat="server" />
                    <asp:CompleteWizardStep runat="server" />
                </WizardSteps>
            </asp:CreateUserWizard>
            <asp:PasswordRecovery ID="PasswordRecovery1" runat="server">
            </asp:PasswordRecovery>
        </AnonymousTemplate>
        <LoggedInTemplate>
            <asp:LoginName ID="LoginName1" runat="server" />
            <asp:ChangePassword ID="ChangePassword1" runat="server">
            </asp:ChangePassword>
        </LoggedInTemplate>
    </asp:LoginView>

    <asp:LoginStatus ID="LoginStatus1" runat="server" />




</asp:Content>
