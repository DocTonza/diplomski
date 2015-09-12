<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="__rucniTestEditSucelja.aspx.cs" Inherits="TonzaDiplomski.__rucniTestEditSucelja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        #glavni {
            background-color: aquamarine;
            margin-left: auto;
            margin-right: auto;
            width: 80%;
            overflow: hidden;
        }

        .lijeviContent {
            position: relative;
            /*left: 10px;
            top: 120px;*/
            float: left;
            width: 15%;
            background-color: white;
            color: black;
        }

        .desniContent {
            position: relative;
            /*left: 220px;
            top: 120px;*/
            float: left;
            width: 85%;
            background-color: lightgray;
            color: black;
        }

        #straniceContainer {
            position: relative;
            /*left: 220px;
            top: 120px;*/
            float: left;
            width: 100%;
            height: 600px;
            background-color: purple;
            color: black;
        }

        .stranica {
            background-color: antiquewhite;
            padding: 10px;
        }

          .Bero {
            
            background-color: blue;
            padding: 0px;
        }

        .red {
            height: 40%;
            background-color: green;
            margin: 5px;
            clear: left;
            padding: 2px;
        }

        .celija {
            /*float:left;*/
            display: inline-block;
            margin: 5px;
            border: 1px solid black;
            padding: 2px;
            background-color: white;
            width: 32%;
        }
    </style>

    <asp:LinqDataSource ID="semaforiSrc" runat="server" ContextTypeName="TonzaDiplomski.SemaforiDataContext" EntityTypeName="" Select="new (naziv, Id)" TableName="tblSemafors"></asp:LinqDataSource>
    <asp:LinqDataSource ID="straniceSrc" runat="server" ContextTypeName="TonzaDiplomski.SemaforiDataContext" EntityTypeName="" Select="new (naziv, Id)" TableName="tblStranicas"></asp:LinqDataSource>
    <asp:LinqDataSource ID="upitiSrc" runat="server" ContextTypeName="TonzaDiplomski.SemaforiDataContext" EntityTypeName="" Select="new (Id, naziv, refreshPeriod,semaforId)" TableName="tblStranicas"></asp:LinqDataSource>

    <div id="glavni">

        <asp:UpdatePanel runat="server" ID="menuUpdatePanel" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>
                
                <div id="lijeviContent" runat="server" class="lijeviContent">

                    <br />
                    Semafori
            <br />
                    <asp:ListView ID="ListViewSemafori" runat="server" DataSourceID="semaforiSrc" OnItemCommand="ListViewSemafori_ItemCommand">
                        <LayoutTemplate>
                            <div>
                                <div id="itemPlaceHolder" runat="server"></div>
                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div>
                                <asp:LinkButton runat="server" ID="OdabraniSemafor" CommandName="OdabraniSemafor" CommandArgument='<%#Eval("ID") %>'><%# Eval("naziv") %></asp:LinkButton>
                            </div>
                        </ItemTemplate>

                    </asp:ListView>

                    <br />
                    Upiti<br />
                    <asp:ListView ID="ListViewUpiti" runat="server" DataSourceID="upitiSrc">
                        <LayoutTemplate>
                            <div>
                                <div id="itemPlaceHolder" runat="server"></div>

                            </div>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <div><%# Eval("naziv") %></div>
                        </ItemTemplate>

                    </asp:ListView>

                </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="textBoxSemaforNaziv" EventName="TextChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>

            <asp:UpdatePanel runat="server" ID="contentUpdatePanel" ChildrenAsTriggers="true">
            <ContentTemplate>

        <div id="desniContent" runat="server" class="desniContent">
            <div id="editSemafor" runat="server" visible="false">
                <asp:Label ID="SemaforID" runat="server" Visible="false"></asp:Label>
                Naslov semafora :
                <asp:TextBox ID="textBoxSemaforNaziv" runat="server" AutoPostBack="true" OnTextChanged="textBoxSemaforNaziv_TextChanged" ViewStateMode="Enabled"></asp:TextBox><br />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="textBoxSemaforNaziv" ErrorMessage="Morate unijeti vrijednost"></asp:RequiredFieldValidator>
                Stranice: 

                 <asp:ListView ID="ListViewStranice" runat="server" DataSourceID="straniceSrc" OnItemCommand="ListViewStranice_ItemCommand">
                        <LayoutTemplate>
                            
                                <span id="itemPlaceHolder" runat="server"></span>
                            
                        </LayoutTemplate>
                        <ItemTemplate>
                                <span id="StranicaLink<%#Eval("id")%>">
                                <asp:LinkButton runat="server" ID="OdabranaStranica" CommandName="OdabranaStranica" CommandArgument='<%#Eval("Id") %>' OnClick="OdabranaStranica_Click"><%# Eval("naziv")%></asp:LinkButton>&nbsp;
                            </span>
                        </ItemTemplate>

                    </asp:ListView>



                <button id="dodajStranicu">Dodaj stranicu</button>
                <br />
                <div id="straniceContainer">

                    <%-- tu sad dodajemo divove sa stranicama --%>
                    <div id="stranica1" class="stranica">

                        <div id="podaciOStranici">
                            <asp:Label ID="LabelStranicaID" Visible="false" runat="server"></asp:Label>
                            Naslov stranice: 
                            <asp:TextBox ID="TextBoxStranicaNaziv" runat="server" AutoPostBack="true" ViewStateMode="Enabled" OnTextChanged="TextBoxStranicaNaziv_TextChanged"></asp:TextBox>
                            <!--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxStranicaNaziv" ErrorMessage="Morate unijeti vrijednost"></asp:RequiredFieldValidator>-->

                            <br />
                            Vrijeme prikazivanja: <asp:TextBox Id="TextBoxStranicaVrijemePrikazivanja" runat="server" AutoPostBack="true" OnTextChanged="TextBoxStranicaVrijemePrikazivanja_TextChanged"></asp:TextBox>
                            <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="TextBoxStranicaVrijemePrikazivanja" ErrorMessage="Morate unijeti cjelobrojnu vrijednost"></asp:CompareValidator>
                            <!--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxStranicaVrijemePrikazivanja" ErrorMessage="Morate unijeti vrijednost"></asp:RequiredFieldValidator>-->
                            <br />
                            broj redova: 
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div id="red1" class="red">
                            Red1:
                            <button id="dodajRed">Dodaj Red</button><br />
                            <div id="celija1" class="celija">ovo je celija</div>
                            <div id="celija2" class="celija">ovo je celija</div>
                            <div id="celija3" class="celija">ovo je celija</div>

                        </div>



                    </div>
                </div>


            </div>
        </div>

                    </ContentTemplate>
            <Triggers>
               
            </Triggers>
        </asp:UpdatePanel>

    </div>
</asp:Content>
