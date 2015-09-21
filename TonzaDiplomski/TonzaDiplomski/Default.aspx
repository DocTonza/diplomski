<%@ Page Title="Test 123" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TonzaDiplomski._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<div class="jumbotron">
        Ovo je jumbotron klasa
        <p>&nbsp;</p>
    </div>--%>
<asp:PlaceHolder runat="server" ID="glavniPlaceholder">
  
        <asp:Timer ID="timerZaStranice" Interval="5000" runat="server" />
        <asp:UpdatePanel ID="Panel01" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div id="divZaStranice" runat="server"></div>
        </ContentTemplate>    
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="timerZaStranice" EventName="Tick" />
            </Triggers>

    </asp:UpdatePanel>

</asp:PlaceHolder>
 

</asp:Content>
