<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="SemaforEdit.aspx.cs" Inherits="TonzaDiplomski.SemaforEdit1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

 <!--   <asp:UpdatePanel runat="server" ID="UpdatePanel" UpdateMode="Conditional">
        <Triggers>
            <asp:PostBackTrigger ControlID="buttonSnimiStranica" />
        </Triggers>
    <ContentTemplate> -->
        <ajaxToolkit:Accordion ID="SemaforiAccordion" runat="server" FadeTransitions="false" 
                FramesPerSecond="50" RequireOpenedPane="False" HeaderCssClass="AccordianSemaforNaslov" 
                TransitionDuration="100" SuppressHeaderPostbacks="false" OnItemCommand="SemaforiAccordion_ItemCommand">
    
        </ajaxToolkit:Accordion>
   <!--     </ContentTemplate>
</asp:UpdatePanel> -->

    <div runat="server" id="modalEditori">

        <div runat="server" id="modal" class="modalBackground" visible="false">&nbsp;</div>

        <div runat="server" id="editorStranice" visible="false" class="lebdeciEditor">
            <br />

            <asp:Label ID="lblIdSemafora" runat="server" Text="Tu treba pisati semafor ID" Visible="true"></asp:Label>
            <asp:Label ID="lblIdStranice" runat="server" Text="Tu treba pisati stranica ID" Visible="true"></asp:Label>
            <asp:Label ID="lblEditInsertDelete" runat="server" Text="Tu treba pisati stranica ID" Visible="true"></asp:Label>
            <br />
            <br />

            <asp:Label ID="lblNaslovStranice" runat="server" Text="Naslov stranice"></asp:Label>
            <asp:TextBox ID="textBoxNaslovStranice" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="lblRefreshStranice" runat="server" Text="Trajanje prikaza stranice"></asp:Label>
            <asp:TextBox ID="textBoxRefreshStranice" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="buttonSnimiStranica" runat="server" Text="Snimi" OnClick="buttonSnimiStranica_Click" />
            <asp:Button ID="buttonOdustaniStranica" runat="server" Text="Odustani" OnClick="buttonOdustaniStranica_Click" />

        </div>

    </div>

    <br /><br /><br /><br /><br /><br />
   

   


  

</asp:Content>
