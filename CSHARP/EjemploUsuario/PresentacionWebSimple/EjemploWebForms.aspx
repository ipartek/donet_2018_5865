<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EjemploWebForms.aspx.cs" Inherits="PresentacionWebSimple.EjemploWebForms" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <h1>Yepa ASP.NET WebForms</h1>

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
            <asp:Calendar ID="CalFechaNacimiento" runat="server" BackColor="White" BorderColor="#3366CC" BorderWidth="1px" CellPadding="1" DayNameFormat="Shortest" Font-Names="Verdana" Font-Size="8pt" ForeColor="#003399" Height="200px" Width="220px" OnSelectionChanged="CalFechaNacimiento_SelectionChanged">
                <DayHeaderStyle BackColor="#99CCCC" ForeColor="#336666" Height="1px"></DayHeaderStyle>

                <NextPrevStyle Font-Size="8pt" ForeColor="#CCCCFF"></NextPrevStyle>

                <OtherMonthDayStyle ForeColor="#999999"></OtherMonthDayStyle>

                <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99"></SelectedDayStyle>

                <SelectorStyle BackColor="#99CCCC" ForeColor="#336666"></SelectorStyle>

                <TitleStyle BackColor="#003399" BorderColor="#3366CC" BorderWidth="1px" Font-Bold="True" Font-Size="10pt" ForeColor="#CCCCFF" Height="25px"></TitleStyle>

                <TodayDayStyle BackColor="#99CCCC" ForeColor="White"></TodayDayStyle>

                <WeekendDayStyle BackColor="#CCCCFF"></WeekendDayStyle>
            </asp:Calendar>
            <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="1">
                <WizardSteps>
                    <asp:WizardStep runat="server" title="Step 1">
                        Paso 1
                    </asp:WizardStep>
                    <asp:WizardStep runat="server" title="Step 2">
                        Paso 2
                    </asp:WizardStep>
                </WizardSteps>
            </asp:Wizard>
            <asp:Label ID="LblCalendario" runat="server"></asp:Label>

        </div>
    </form>
</body>
</html>
