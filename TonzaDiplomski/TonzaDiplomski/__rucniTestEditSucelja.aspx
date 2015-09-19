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
            padding: 10px;
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

        .maliNavText {
            font-size: smaller;
            text-align: right;
        }

        p.navigacija {
            font-size: smaller;
            text-align: right;
        }
    </style>

    <script>
        function ValidateData() {
            if (OK) {
                return true;
            } else {
                return false;
            }
        }
    </script>

    <asp:LinqDataSource ID="semaforiSrc" runat="server" ContextTypeName="TonzaDiplomski.SemaforiDataContext" EntityTypeName="" Select="new (naziv, Id)" TableName="tblSemafors"></asp:LinqDataSource>

    <asp:LinqDataSource ID="straniceSrc" runat="server" ContextTypeName="TonzaDiplomski.SemaforiDataContext" EntityTypeName="" Select="new (naziv, Id, semaforID)" TableName="tblStranicas" AutoGenerateWhereClause="True">
        <WhereParameters>
            <asp:ControlParameter ControlID="labelSemaforID" Name="SemaforId" PropertyName="Text" Type="Int32" />
        </WhereParameters>
    </asp:LinqDataSource>

    <asp:LinqDataSource ID="redoviSrc" runat="server" ContextTypeName="TonzaDiplomski.SemaforiDataContext" EntityTypeName="" Select="new (Id, stranicaID)" TableName="tblRedaks" AutoGenerateWhereClause="True">
        <WhereParameters>
            <asp:ControlParameter ControlID="labelStranicaID" Name="StranicaId" PropertyName="Text" Type="Int32" />
        </WhereParameters>
    </asp:LinqDataSource>

    <asp:LinqDataSource ID="upitiSrc" runat="server" ContextTypeName="TonzaDiplomski.SemaforiDataContext" EntityTypeName="" Select="new (naziv, upit, id, serverID, dbID, tblCelijas, tblServer, tblDB)" TableName="tblUpits"></asp:LinqDataSource>
    <asp:LinqDataSource ID="serveriSrc" runat="server" ContextTypeName="TonzaDiplomski.SemaforiDataContext" EntityTypeName="" Select="new (id, serverString, naziv)" TableName="tblServers"></asp:LinqDataSource>
    <asp:LinqDataSource ID="bazeSrc" runat="server" ContextTypeName="TonzaDiplomski.SemaforiDataContext" EntityTypeName="" Select="new (id, dbAttachString, naziv, korisnik, lozinka, salt, integratedAuth)" TableName="tblDBs"></asp:LinqDataSource>


    <div id="glavni">


        <%--lijevi menu--%>
        <asp:UpdatePanel runat="server" ID="menuUpdatePanel" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>

                <div id="lijeviContent" runat="server" class="lijeviContent">

                    <br />
                    Semafori <span class="maliNavText">(<asp:LinkButton ID="linkButtonDodajSemafor" runat="server" Text="Dodaj" OnClick="DodajSemafor_Click">Dodaj</asp:LinkButton>)</span>
                    <br />
                    <asp:ListView ID="ListViewSemafori" runat="server" DataSourceID="semaforiSrc" OnItemCommand="ListViewSemafori_ItemCommand">
                        <LayoutTemplate>
                            <ul>
                                <div id="itemPlaceHolder" runat="server"></div>
                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>

                            <li>
                                <asp:LinkButton runat="server" ID="OdabraniSemafor" CommandName="OdabraniSemafor" CommandArgument='<%#Eval("ID") %>'><%# Eval("naziv") %></asp:LinkButton></li>

                        </ItemTemplate>

                    </asp:ListView>
                    <%--<asp:Button ID="DodajSemafor" runat="server" Text="Dodaj" OnClick="DodajSemafor_Click"/>--%>


                    <br />
                    Upiti<br />
                    <asp:ListView ID="ListViewUpiti" runat="server" DataSourceID="upitiSrc">
                        <LayoutTemplate>
                            <ul>
                                <div id="itemPlaceHolder" runat="server"></div>

                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li><%# Eval("naziv") %></li>
                        </ItemTemplate>
                    </asp:ListView>

                    Serveri  <span class="maliNavText">(<asp:LinkButton ID="linkButtonDodajServer" runat="server" Text="Dodaj" OnClick="linkButtonDodajServer_Click">Dodaj</asp:LinkButton>)</span><br />
                    <asp:ListView ID="ListViewServeri" runat="server" DataSourceID="serveriSrc" OnItemCommand="ListViewServeri_ItemCommand">
                        <LayoutTemplate>
                            <ul>
                                <div id="itemPlaceHolder" runat="server"></div>

                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>

                            <li>
                                <asp:LinkButton runat="server" ID="odabraniServer" CommandName="OdabraniServer" CommandArgument='<%#Eval("ID") %>'><%# Eval("naziv") %></asp:LinkButton>
                                

                            </li>
                        </ItemTemplate>
                    </asp:ListView>

                    Baze<br />
                    <asp:ListView ID="ListViewBaze" runat="server" DataSourceID="bazeSrc" OnItemCommand="ListViewBaze_ItemCommand">
                        <LayoutTemplate>
                            <ul>
                                <div id="itemPlaceHolder" runat="server"></div>

                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:LinkButton runat="server" ID="odabranaBaza" CommandName="OdabranaBaza" CommandArgument='<%#Eval("ID") %>'><%# Eval("naziv") %></asp:LinkButton>
                            </li>
                        </ItemTemplate>
                    </asp:ListView>

                </div>

            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="textBoxSemaforNaziv" EventName="TextChanged"></asp:AsyncPostBackTrigger>
            </Triggers>
        </asp:UpdatePanel>

        <%--content edit pane--%>
        <asp:UpdatePanel runat="server" ID="contentUpdatePanel" ChildrenAsTriggers="true" UpdateMode="Conditional">
            <ContentTemplate>

                <div id="desniContent" runat="server" class="desniContent">
                    <%--div koji služi za editiranje semafora--%>
                    <div id="editSemafor" runat="server" visible="false">
                        <asp:Label ID="labelSemaforID" runat="server" Visible="false"></asp:Label>

                        <p class="maliNavText">
                            <asp:LinkButton ID="LinkButtonBrisiSemafor" runat="server" OnClick="LinkButtonBrisiSemafor_Click">Briši</asp:LinkButton>
                        </p>
                        Naslov semafora :
                <asp:TextBox ID="textBoxSemaforNaziv" runat="server" AutoPostBack="true" OnTextChanged="textBoxSemaforNaziv_TextChanged" ViewStateMode="Enabled"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="textBoxSemaforNaziv" ErrorMessage="Morate unijeti vrijednost"></asp:RequiredFieldValidator>



                        <hr />
                        <p class="maliNavText">
                            <asp:LinkButton ID="LinkButtonDodajStranicu" runat="server" OnClick="LinkButtonDodajStranicu_Click">Dodaj</asp:LinkButton>
                            |
                    <asp:LinkButton ID="LinkButtonBrisiStranicu" runat="server" OnClick="LinkButtonBrisiStranicu_Click">Briši</asp:LinkButton>

                        </p>
                        Stranice: 

                 <asp:ListView ID="ListViewStranice" runat="server" DataSourceID="straniceSrc" OnItemCommand="ListViewStranice_ItemCommand">
                     <LayoutTemplate>

                         <span id="itemPlaceHolder" runat="server"></span>

                     </LayoutTemplate>
                     <ItemTemplate>
                         <span id="StranicaLink<%#Eval("id")%>">
                             <asp:LinkButton runat="server" ID="OdabranaStranica" CommandName="OdabranaStranica" CommandArgument='<%#Eval("Id") %>' OnClick="OdabranaStranica_Click" stranicaID='<%#Eval("Id") %>'><%# Eval("naziv")%></asp:LinkButton>&nbsp;
                         </span>
                     </ItemTemplate>

                 </asp:ListView>
                        <br />
                        <div id="straniceContainer">

                            <%-- tu sad dodajemo divove sa stranicama --%>
                            <div id="stranica1" class="stranica">

                                <div id="podaciOStranici">
                                    <asp:Label ID="LabelStranicaID" Visible="true" runat="server"></asp:Label>
                                    Naslov stranice: 
                            <asp:TextBox ID="TextBoxStranicaNaziv" runat="server" AutoPostBack="true" ViewStateMode="Enabled" OnTextChanged="TextBoxStranicaNaziv_TextChanged"></asp:TextBox>
                                    <!--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxStranicaNaziv" ErrorMessage="Morate unijeti vrijednost"></asp:RequiredFieldValidator>-->

                                    <br />
                                    Vrijeme prikazivanja:
                                    <asp:TextBox ID="TextBoxStranicaVrijemePrikazivanja" runat="server" AutoPostBack="true" OnTextChanged="TextBoxStranicaVrijemePrikazivanja_TextChanged" onchange="ValidateData(this);"></asp:TextBox>
                                    <asp:CompareValidator runat="server" Operator="DataTypeCheck" Type="Integer" ControlToValidate="TextBoxStranicaVrijemePrikazivanja" ErrorMessage="Morate unijeti cjelobrojnu vrijednost"></asp:CompareValidator>
                                    <!--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxStranicaVrijemePrikazivanja" ErrorMessage="Morate unijeti vrijednost"></asp:RequiredFieldValidator>-->
                                    <br />
                                    broj redova: 
                            <asp:DropDownList ID="DropDownListStranicaBrojRedova" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListStranicaBrojRedova_SelectedIndexChanged">
                                <asp:ListItem>1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                            </asp:DropDownList>
                                </div>

                                <div id="redovi" class="red">

                                    <%-- redovi --%>

                                    <asp:ListView ID="ListViewRedovi" runat="server" DataSourceID="redoviSrc">
                                        <LayoutTemplate>

                                            <span id="itemPlaceHolder" runat="server"></span>

                                        </LayoutTemplate>
                                        <ItemTemplate>

                                            <asp:LinqDataSource ID="celijeSrc" runat="server" ContextTypeName="TonzaDiplomski.SemaforiDataContext" EntityTypeName="" Select="new (upitID, grafID, redakID, id)" TableName="tblCelijas" AutoGenerateWhereClause="True">
                                                <WhereParameters>
                                                    <asp:ControlParameter ControlID="LabelRedakID" Name="redakID" PropertyName="Text" Type="Int32" DefaultValue="0" />
                                                </WhereParameters>
                                            </asp:LinqDataSource>

                                            Red:
                                    <asp:Label ID="LabelRedakID" Visible="true" runat="server" Text='<%#Eval("id") %>'></asp:Label>

                                            <%-- celije --%>
                                            <br />


                                            <asp:ListView ID="ListViewCelije" runat="server" DataSourceID="celijeSrc">
                                                <LayoutTemplate>

                                                    <span id="itemPlaceHolder" runat="server"></span>

                                                </LayoutTemplate>
                                                <ItemTemplate>

                                                    <%--tu idemo sa tri ćelije, u svakoj dva dropdown menu-a; upit i graf koji se prikazuje--%>
                                                    <div id='celija<%#Eval("id") %>' class="celija">
                                                        <%#Eval("id") %>
                                                        <asp:DropDownList ID="DropDownListOdabirUpita" runat="server" DataSourceID="upitiSrc" DataTextField="naziv" DataValueField="id">
                                                        </asp:DropDownList>
                                                    </div>
                                                </ItemTemplate>

                                            </asp:ListView>

                                        </ItemTemplate>

                                    </asp:ListView>
                                    <br />
                                    <br />
                                    <br />

                                </div>



                            </div>
                        </div>


                    </div>

                    <%--div koji služi za editiranje Upita--%>
                    <div id="editUpit" runat="server" visible="false">
                    </div>
                    <%--div koji služi za editiranje Servera--%>
                    <div id="editServer" runat="server" visible="false">
                        ServerID:<asp:Label ID="labelServerID" runat="server"></asp:Label><br />
                        Naziv:<asp:TextBox ID="textBoxServerNaziv" runat="server"></asp:TextBox><br />
                        ServerString:<asp:TextBox ID="textBoxServerServerString" runat="server"></asp:TextBox><br />
                        Database:<asp:TextBox ID="textBoxServerDatabaseName" runat="server"></asp:TextBox><br />
                        <asp:CheckBox ID="checkBoxServerDatabaseIntegratedAuth" runat="server" Text="Integrated authentication" OnCheckedChanged="checkBoxServerDatabaseIntegratedAuth_CheckedChanged" AutoPostBack="true" /><br />
                        
                        Korisnik:<asp:TextBox ID="textBoxServerDatabaseKorisnik" runat="server"></asp:TextBox><br />
                        Lozinka: <asp:TextBox ID="textBoxServerDatabaseLozinka" runat="server" Type="Password"></asp:TextBox><br />
                        Database Attach String:<asp:TextBox ID="textBoxServerDatabaseAttachString" runat="server"></asp:TextBox><br />

                        <asp:Button ID="buttonProvjeriServerDatabaseString" runat="server" Text="Provjeri" OnClick="buttonProvjeriServerDatabaseString_Click"  />
                        <asp:Button ID="buttonServerSnimiPostavke" runat="server" Text="Spremi" OnClick="buttonServerSnimiPostavke_Click" Enabled="false"  />

                        <asp:Label ID="labelServerProvjeraStringa" text="" runat="server"></asp:Label>

                    </div>

                    <%--div koji služi za editiranje baza--%>
                    <div id="editBaza" runat="server" visible="false">

                        <asp:Label ID="labelBazaID" runat="server"></asp:Label><br />
                        <asp:TextBox ID="textBoxBazaNaziv" runat="server"></asp:TextBox><br />
                        <asp:TextBox ID="textBoxBazaKorisnik" runat="server"></asp:TextBox><br />
                        <asp:TextBox ID="textBoxBazaLozinka" runat="server" TextMode="password"></asp:TextBox><br />
                        <asp:CheckBox ID="checkBoxBazaIntegratedAuth" runat="server" Text="Integrated authentication" />

                    </div>
                </div>

            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>

    </div>
</asp:Content>
