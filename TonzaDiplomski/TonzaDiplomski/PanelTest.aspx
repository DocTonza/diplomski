<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelTest.aspx.cs" Inherits="TonzaDiplomski.PanelTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ScriptManager ID="ScripManager1" runat="server" />
        <asp:Timer ID="timer" Interval="1000" runat="server"  OnTick="timer_Tick"/>
        <asp:UpdatePanel ID="Panel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="testniDiv" runat="server"></div>
        </ContentTemplate>    
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="timer" EventName="Tick" />
            </Triggers>
        </asp:UpdatePanel>
    
    </div>
    </form>
</body>
</html>
