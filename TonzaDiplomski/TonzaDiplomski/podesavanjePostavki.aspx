﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="podesavanjePostavki.aspx.cs" Inherits="TonzaDiplomski.__rucniTestEditSucelja" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body {
            background-color: #e6e6e6;
            font-family: 'Arial Unicode MS';
            
        }
       

        input {
            font-family: 'Arial Unicode MS';
            border:1px solid #e6e6e6;
        }

        #glavni {
            background-color: #e6e6e6;
            margin-left: auto;
            margin-right: auto;
            width: 80%;
            overflow: hidden;
        }
        .naslov-a {
            font-family: 'Arial Unicode MS';
            font-size: 22px;
            color: black;
        }
        .naslov {
            /*position: relative;*/
            display: flex;
            margin-left: auto;
            margin-right: auto;
            width: 79%;
            /*background-color: white;*/
            color: black;
            padding-top: 15px;
            padding-bottom: 5px;
            align-content: center;
            justify-content: center;
            margin-bottom: 5px;
            font-size: 24px;
            font-family: 'Arial Unicode MS';
            /*font-weight: bold;*/
            align-items: center;
        }

        .lijeviContent {
            font-family: 'Arial Unicode MS';
            font-size:16px;
            position: relative;
            /*left: 10px;
            top: 120px;*/
            float: left;
            width: 15%;
            background-color: white;
            color: black;
            padding: 5px;
            margin-left: 8px;
            margin-right: 10px;
            margin-top: 15px;
            margin-bottom: 20px;
        }

        .desniContent {
            position: relative;
            /*left: 220px;
            top: 120px;*/
            float: right;
            width: 82%;
            /*background-color: white;*/
            color: black;
            padding: 5px;
            margin-top: 12px;
            margin-left: 0px;
            margin-right: 7px;
        }
        .semaforNaslov {
            padding:2px;
            font-weight:normal;
            font-size:16px;
            font-family: 'Arial Unicode MS';
            text-align:left;
            background-color: white;
            margin-bottom:20px;
            padding-left:20px;
            padding-bottom:30px;
            padding-top:2px;
            padding-right:5px;
        }

        .straniceContainer {
            position: relative;
            /*left: 220px;
            top: 120px;*/
            float: left;
            width: 100%;
            height: 600px;
            background-color: white;
            color: black;
            padding-left:20px;
            padding-top:5px;
            padding-right:5px;
        }

        .izvorContainer {
            position: relative;
            /*left: 220px;
            top: 120px;*/
            float: left;
            width: 100%;
            /*height: 400px;*/
            background-color: white;
            color: black;
            padding-bottom:20px;
            padding-left:20px;
            padding-top:5px;
            padding-right:5px;
        }

        .upitContainer {
            position: relative;
            /*left: 220px;
            top: 120px;*/
            float: left;
            width: 100%;
            /*height: 400px;*/
            background-color: white;
            color: black;
            padding-bottom:20px;
            padding-left:20px;
            padding-top:5px;
            padding-right:5px;
        }

        .stranica {
            display:inline-block;
            background-color: #e6e6e6;
            justify-content:center;
            align-content:center;
            padding-left: 12px;
            padding-top:10px;
            width:120px;
            height:40px;
        }
        .stranicaBijelo {
            display:inline-block;
            background-color: white;
           justify-content:center;
            padding-left: 12px;
            padding-top:10px;
            width:120px;
            height:40px;
        }

        .stranicaDetalj {
            background-color: #e6e6e6;
            padding-top: 20px;
            padding-left:20px;
            padding-right:20px;
            padding-bottom:10px;
            margin-left:-15px;
            margin-righr:15px;
            font-size:16px;
            font-family: 'Arial Unicode MS';
            
        }

        .Bero {
            background-color: blue;
            padding: 0px;
        }

        .red {
            height: 40%;
            background-color: rgb(222, 217, 217);
            margin-bottom: 10px;
            clear: left;
            padding: 20px;
        }

        .celija {
            /*float:left;*/
            display: inline-block;
            margin: 1px;
            /*border: 1px solid black;*/
            padding: 5px;
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

        .selectEditBox {
            width: 650px;
            height: 200px;
            resize: none;
            margin:2px;
            
        }
        .dropDownSelectUpita {
            margin:2px;
            border:1px solid #e6e6e6;
            width:100%;

        }
        .dropDownSelectGrafa {
            margin:2px;
            border:1px solid #e6e6e6;
            width:100%;

        }
        .dropDownSelectZaUpit {
            margin:2px;
            border:1px solid #e6e6e6;
            width:280px;

        }

        .textBoxZaUpit {
            margin:2px;
            border:1px solid #e6e6e6;
            width:520px;
            height:260px;
            font-size:12px;

        }
        td {

            font-size:16px;
            font-family: 'Arial Unicode MS';
            padding:10px;
        }
        table {

            margin-left:100px;
        }

        .greskaUnos {
            
            font-size:10px;
            color:red;
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

        function prikaziDialog(poruka) {
            // ova funkcija prikazuje dialog sa pitanjem i gumbima DA i NE.
            // Vraća true ili false ovisno o odabranom gumbu.
            // prvo prikaži modal background, tako da nema klikanja po stranici dok se ne odgovori na pitanje
            document.getElementById('MainContent_modalBackground').style.display = "block";
            document.getElementById('MainContent_lebdeciDialog').style.display = "block";


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


    <div id="naslov" runat="server" class="naslov">
        <p>Podešavanje postavki:</p>
    </div>
    <div id="glavni">




        <%--lijevi menu--%>
        <asp:UpdatePanel runat="server" ID="menuUpdatePanel" UpdateMode="Conditional">
            <ContentTemplate>

                <div id="lijeviContent" runat="server" class="lijeviContent sjena">

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

                    Izvori <span class="maliNavText">(<asp:LinkButton ID="linkButtonDodajServer" runat="server" Text="Dodaj" OnClick="linkButtonDodajServer_Click">Dodaj</asp:LinkButton>)</span><br />
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



                    Upiti <span class="maliNavText">(<asp:LinkButton ID="linkButtonDodajUpit" runat="server" Text="Dodaj" OnClick="linkButtonDodajUpit_Click">Dodaj</asp:LinkButton>)</span><br />
                    <asp:ListView ID="ListViewUpiti" runat="server" DataSourceID="upitiSrc" OnItemCommand="ListViewUpiti_ItemCommand">
                        <LayoutTemplate>
                            <ul>
                                <div id="itemPlaceHolder" runat="server"></div>

                            </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                            <li>
                                <asp:LinkButton runat="server" ID="odabraniUpit" CommandName="OdabraniUpit" CommandArgument='<%# Eval("id") %>'><%# Eval("naziv") %></asp:LinkButton>

                            </li>
                        </ItemTemplate>
                    </asp:ListView>


                    <%-- Baze<br />
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
                    </asp:ListView>--%>
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

                        <div class="semaforNaslov sjena">
                            <p class="maliNavText">
                                <asp:LinkButton ID="LinkButtonBrisiSemafor" runat="server" OnClick="LinkButtonBrisiSemafor_Click" OnClientClick="return confirm('Da li ste sigurni da želite obrisati ovaj semafor?')">Briši</asp:LinkButton>
                            </p>
                            Naslov semafora :
                            <asp:TextBox ID="textBoxSemaforNaziv" runat="server" AutoPostBack="true" OnTextChanged="textBoxSemaforNaziv_TextChanged" ViewStateMode="Enabled"></asp:TextBox>
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="textBoxSemaforNaziv" ErrorMessage="Morate unijeti vrijednost"></asp:RequiredFieldValidator>

                        </div>

                       
                        
                         
                            <div id="straniceContainer" class="straniceContainer sjena">

                                 <p class="maliNavText">
                            <asp:LinkButton ID="LinkButtonDodajStranicu" runat="server" OnClick="LinkButtonDodajStranicu_Click">Dodaj</asp:LinkButton>
                            |
                            <asp:LinkButton ID="LinkButtonBrisiStranicu" runat="server" OnClick="LinkButtonBrisiStranicu_Click" OnClientClick="return confirm('Da li ste sigurni da želite obrisati ovu stranicu?')">Briši</asp:LinkButton>

                        </p>
                             Stranice: 

                            <asp:ListView ID="ListViewStranice" runat="server" DataSourceID="straniceSrc" OnItemCommand="ListViewStranice_ItemCommand">
                            <LayoutTemplate>

                                <span id="itemPlaceHolder" runat="server"></span>

                            </LayoutTemplate>
                            <ItemTemplate>
                               <span id="StranicaLink<%#Eval("id")%>">
                               <asp:LinkButton runat="server" ID='OdabranaStranica' CommandName="OdabranaStranica" CommandArgument='<%#Eval("Id") %>' OnClick="OdabranaStranica_Click" stranicaID='<%#Eval("Id") %>'><%# Eval("naziv")%></asp:LinkButton>&nbsp;
                               </span>
                            </ItemTemplate>

                        </asp:ListView>
                           
                            <br /><br /><br />

                            <%-- tu sad dodajemo divove sa stranicama --%>
                            <div id="stranica1" class="stranicaDetalj">

                                <div id="podaciOStranici">
                                    <asp:Label ID="LabelStranicaID" Visible="false" runat="server"></asp:Label>
                                    
                                    <table>
                                        <tr>
                                            <td>
                                                Naslov stranice:

                                            </td>
                                            <td> 
                                                 <asp:TextBox ID="TextBoxStranicaNaziv" runat="server" AutoPostBack="true" ViewStateMode="Enabled" OnTextChanged="TextBoxStranicaNaziv_TextChanged"></asp:TextBox>
                                                 <!--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxStranicaNaziv" ErrorMessage="Morate unijeti vrijednost"></asp:RequiredFieldValidator>-->
                                            </td>
                                        </tr>
                                      <tr>
                                          <td>
                                                Vrijeme prikazivanja (ms):
                                          </td>
                                          <td>
                                                <asp:TextBox ID="TextBoxStranicaVrijemePrikazivanja" runat="server" AutoPostBack="true" OnTextChanged="TextBoxStranicaVrijemePrikazivanja_TextChanged" onchange="ValidateData(this);"></asp:TextBox>
                                                <asp:CompareValidator runat="server" 
                                                    Operator="DataTypeCheck" 
                                                    Type="Integer" 
                                                    ControlToValidate="TextBoxStranicaVrijemePrikazivanja" 
                                                    CssClass="greskaUnos"
                                                    ErrorMessage="Morate unijeti cjelobrojnu vrijednost">

                                                </asp:CompareValidator>
                                                <!--<asp:RequiredFieldValidator runat="server" ControlToValidate="TextBoxStranicaVrijemePrikazivanja" ErrorMessage="Morate unijeti vrijednost"></asp:RequiredFieldValidator>-->
                                         </td>
                                      </tr>
                                      <tr>
                                            <td>
                                             broj redova:

                                            </td>
                                          <td> 
                                                <asp:DropDownList ID="DropDownListStranicaBrojRedova" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownListStranicaBrojRedova_SelectedIndexChanged">
                                                    <asp:ListItem>1</asp:ListItem>
                                                    <asp:ListItem>2</asp:ListItem>
                                                </asp:DropDownList>
                                        </td>

                                      </tr>

                                    </table>
                                </div>

                                <div id="redovi" class="red">

                                    <%-- redovi --%>

                                    <asp:ListView ID="ListViewRedovi" runat="server" DataSourceID="redoviSrc">
                                        <LayoutTemplate>

                                            <span id="itemPlaceHolder" runat="server"></span>

                                        </LayoutTemplate>
                                        <ItemTemplate>
                                            <%--celije datasource--%>
                                            <asp:LinqDataSource ID="celijeSrc" runat="server" ContextTypeName="TonzaDiplomski.SemaforiDataContext" EntityTypeName="" Select="new (upitID, grafID, redakID, id)" TableName="tblCelijas" AutoGenerateWhereClause="True" EnableUpdate="False">
                                                <WhereParameters>
                                                    <asp:ControlParameter ControlID="LabelRedakID" Name="redakID" PropertyName="Text" Type="Int32" DefaultValue="0" />
                                                </WhereParameters>
                                            </asp:LinqDataSource>
                                            <%--VrsteGrafa datasource--%>
                                            <asp:LinqDataSource ID="grafoviSrc" runat="server" ContextTypeName="TonzaDiplomski.SemaforiDataContext" EntityTypeName="" Select="new (id,naziv)" TableName="tblVrstaGrafas">
                                            </asp:LinqDataSource>

                                            Red:
                                            <asp:Label ID="LabelRedakID" Visible="false" runat="server" Text='<%#Eval("id") %>'></asp:Label>

                                            <%-- celije --%>
                                            <br />


                                            <asp:ListView ID="ListViewCelije" runat="server" DataSourceID="celijeSrc">
                                                <LayoutTemplate>

                                                    <span id="itemPlaceHolder" runat="server"></span>

                                                </LayoutTemplate>
                                                <ItemTemplate>

                                                    <%--tu idemo sa tri ćelije, u svakoj dva dropdown menu-a; upit i graf koji se prikazuje--%>
                                                    <div id='celija<%#Eval("id") %>' class="celija">
                                                        <asp:Label ID="labelCelijaID" runat="server" Visible="false" Text='<%#Eval("id") %>'></asp:Label>
                                                        
                                                        <div id="divCelijaOdabirUpita" runat="server">
                                                            <asp:DropDownList ID="DropDownListOdabirUpita" CssClass="dropDownSelectUpita"
                                                                runat="server"
                                                                DataSourceID="upitiSrc"
                                                                DataTextField="naziv"
                                                                DataValueField="id"
                                                                AutoPostBack="True"
                                                                celijaID='<%#Eval("id") %>'
                                                                OnDataBound="DropDownListOdabirUpita_DataBinding"
                                                                OnSelectedIndexChanged="DropDownListOdabirUpita_SelectedIndexChanged" 
                                                                
                                                                />
                                                            <asp:CompareValidator
                                                                runat="server"
                                                                ID="CompareValidatorListDropDownUpit"
                                                                ControlToValidate="DropDownListOdabirUpita"
                                                                Type="String"
                                                                ValueToCompare="9999"
                                                                Operator="NotEqual"
                                                                ErrorMessage=" Obavezno odabrati"
                                                                Display="Static"
                                                                CssClass="greskaUnos">

                                                            </asp:CompareValidator>

                                                            
                                                        </div>
                                                        <div id="divCelijaOdabirVrsteGrafa" runat="server">
                                                            <asp:DropDownList ID="DropDownListcelijaOdabirVrsteGrafa" CssClass="dropDownSelectGrafa"
                                                                runat="server"
                                                                DataSourceID="grafoviSrc"
                                                                DataTextField="naziv"
                                                                DataValueField="id"
                                                                AutoPostBack="true"
                                                                celijaID='<%#Eval("id")%>'
                                                                OnDataBinding="DropDownListcelijaOdabirVrsteGrafa_DataBinding"
                                                                OnSelectedIndexChanged="DropDownListcelijaOdabirVrsteGrafa_SelectedIndexChanged" />

                                                            <asp:CompareValidator
                                                                runat="server"
                                                                ID="DropDownListcelijaOdabirVrsteGrafaValidator"
                                                                ControlToValidate="DropDownListcelijaOdabirVrsteGrafa"
                                                                Type="String"
                                                                ValueToCompare="9999"
                                                                Operator="NotEqual"
                                                                ErrorMessage=" Obavezno odabrati"
                                                                Display="Dynamic"
                                                                CssClass="greskaUnos">

                                                            </asp:CompareValidator>
                                                            <%--SelectedValue='<%#Bind("grafID")%>'--%>
                                                        </div>


                                                    </div>
                                                </ItemTemplate>

                                            </asp:ListView>

                                        </ItemTemplate>

                                    </asp:ListView>
                                    

                                    

                                    

                                </div>



                            </div>
                        </div>
                       

                    </div>
                        


                    <%--div koji služi za editiranje Upita--%>
                    <div id="editUpit" runat="server" visible="false" class="upitContainer sjena">

                        <p class="maliNavText">
                            <asp:LinkButton ID="LinkButtonBrisiUpit" runat="server" OnClientClick="return confirm('Da li ste sigurni?')">Briši</asp:LinkButton>
                        </p>

                        <table border="0">
                            <tr>
                                <td style="vertical-align:top">


                                    <span id="spanUpitID" runat="server" visible="false">UpitID:</span><asp:Label ID="labelUpitID" runat="server" Text="" visible="false"></asp:Label>

                                    Naziv:
                                </td>
                                <td>

                                    <asp:TextBox ID="textBoxUpitNaziv" runat="server" ToolTip="Naziv upita koji će se koristiti u sustavu." Width="300"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Izvor podataka:
                                </td>
                                <td>
                                    <asp:DropDownList ID="dropDownListUpitOdaberiDatasource" runat="server" DataSourceID="serveriSrc" DataTextField="naziv" DataValueField="id" CssClass="dropDownSelectZaUpit"></asp:DropDownList><br />
                                </td>

                            </tr>
                            <tr>
                                <td style="vertical-align:top;">Upit:
                                </td>
                                <td>
                                    <asp:TextBox ID="textBoxUpitDefinicija" CssClass="textBoxZaUpit" runat="server" TextMode="MultiLine" ToolTip="Definicija upita." AutoCompleteType="Disabled" spellcheck="false"></asp:TextBox>
                                    <asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator1"
                                        runat="server"
                                        ErrorMessage="<br/>Pronađene nedozvoljene komande u upitu."
                                        ValidationExpression="(^((?![Dd][Rr][Oo][Pp]\s)[\s\S])*$)*"
                                        ControlToValidate="textBoxUpitDefinicija"
                                        ForeColor="red" />
                                    <asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator2"
                                        runat="server"
                                        ErrorMessage="Pronađene nedozvoljene komande u upitu."
                                        ValidationExpression="(^((?![Dd][Ee][Ll][Ee][Tt][Ee]\s)[\s\S])*$)*"
                                        ControlToValidate="textBoxUpitDefinicija"
                                        ForeColor="red" />
                                    <asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator3"
                                        runat="server"
                                        ErrorMessage="Pronađene nedozvoljene komande u upitu."
                                        ValidationExpression="(^((?![Tt][Rr][Uu][Nn][Cc]\s)[\s\S])*$)*"
                                        ControlToValidate="textBoxUpitDefinicija"
                                        ForeColor="red" />
                                    <asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator4"
                                        runat="server"
                                        ErrorMessage="Pronađene nedozvoljene komande u upitu."
                                        ValidationExpression="(^((?![Tt][Rr][Uu][Nn][Cc][Aa][Tt][Ee]\s)[\s\S])*$)*"
                                        ControlToValidate="textBoxUpitDefinicija"
                                        ForeColor="red" />
                                    <asp:RegularExpressionValidator
                                        ID="RegularExpressionValidator5"
                                        runat="server"
                                        ErrorMessage="Pronađene nedozvoljene komande u upitu."
                                        ValidationExpression="(^((?![Ii][Nn][Ss][Ee][Rr][Tt]\s)[\s\S])*$)*"
                                        ControlToValidate="textBoxUpitDefinicija"
                                        ForeColor="red" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align: center">
                                    <asp:Button ID="buttonUpitSnimi" runat="server" Text="Snimi" OnClick="buttonUpitSnimi_Click" />
                                    <asp:Button ID="buttonUpitTestiraj" runat="server" Text="Testiraj upit" OnClick="buttonUpitTestiraj_Click" />

                                </td>
                            </tr>
                        </table>


                    </div>


                        

                    <%--div koji služi za editiranje Servera--%> 
                    <div id="editServer" runat="server" visible="false" class="izvorContainer sjena">
                        
                        <p class="maliNavText">
                            <asp:LinkButton ID="LinkButtonBrisiServerDatasource" runat="server" OnClick="LinkButtonBrisiServerDatasource_Click" OnClientClick="return confirm('Da li ste sigurni?')">Briši</asp:LinkButton>
                        </p>
                        <table border="0">
                            <tr>
                                <td>
                        <span ID="spanServerID" runat="server" visible="false">ServerID:</span><asp:Label ID="labelServerID" runat="server" visible="false"></asp:Label>
                        Naziv:
                                </td>
                                <td>
                                    <asp:TextBox ID="textBoxServerNaziv" runat="server" ToolTip="Naziv izvora podataka koji će koristi u sustavu." Width="300"></asp:TextBox>

                                </td>
                            </tr>
                            <tr>
                                <td>ServerString:
                                </td>
                                <td>
                                    <asp:TextBox ID="textBoxServerServerString" runat="server" ToolTip="Naziv SQL server instance na koju se spajamo" Width="300"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Database:
                                </td>
                                <td>
                                    <asp:TextBox ID="textBoxServerDatabaseName" runat="server" ToolTip="Naziv baze na koju se spajamo." Width="300"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Database Attach String:
                                </td>
                                <td>
                                    <asp:TextBox ID="textBoxServerDatabaseAttachString" runat="server" ToolTip="Potrebno unijeti samo ako se radi o LocalDB serveru." Width="300"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:CheckBox ID="checkBoxServerDatabaseIntegratedAuth" runat="server" Text="Integrated authentication" OnCheckedChanged="checkBoxServerDatabaseIntegratedAuth_CheckedChanged" AutoPostBack="true" />
                                </td>
                            </tr>
                            <tr>
                                <td>Korisnik:
                                </td>
                                <td>
                                    <asp:TextBox ID="textBoxServerDatabaseKorisnik" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Lozinka:
                                </td>
                                <td>
                                    <asp:TextBox ID="textBoxServerDatabaseLozinka" runat="server" TextMode="Password"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" style="text-align:center;">


                                    <asp:Button ID="buttonProvjeriServerDatabaseString" runat="server" Text="Provjeri" OnClick="buttonProvjeriServerDatabaseString_Click" />
                                    <asp:Button ID="buttonServerSnimiPostavke" runat="server" Text="Spremi" OnClick="buttonServerSnimiPostavke_Click" Enabled="false" />

                                    <asp:Label ID="labelServerProvjeraStringa" Text="" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>

                    </div>


                    <%--div koji služi za editiranje baza--%>
                    <%--<div id="editBaza" runat="server" visible="false">

                        <asp:Label ID="labelBazaID" runat="server"></asp:Label><br />
                        <asp:TextBox ID="textBoxBazaNaziv" runat="server"></asp:TextBox><br />
                        <asp:TextBox ID="textBoxBazaKorisnik" runat="server"></asp:TextBox><br />
                        <asp:TextBox ID="textBoxBazaLozinka" runat="server" TextMode="password"></asp:TextBox><br />
                        <asp:CheckBox ID="checkBoxBazaIntegratedAuth" runat="server" Text="Integrated authentication" />

                    </div>--%>
                </div>
                

                <div runat="server" id="prikazTestUpita" class="lebdeciDialog sjena" visible="false">



                    <asp:Button runat="server" ID="buttonPrikazTestUpit_OK" OnClick="buttonPrikazTestUpit_OK_Click" Text="OK" />


                </div>



            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>

    </div>



    <div runat="server" id="modalEditori">

        <div runat="server" id="modalBackground" class="modalBackground" visible="false">&nbsp;</div>



        <%-- NE KORISTI SE TRENUTNO dialog koji koristmo za razna pitanja. Imamo labelu sa pitanjem, gumbe OK i CANCEL, te skriveni odgovor u koji spremamo odgovor--%>
        <div runat="server" id="lebdeciDialog" class="lebdeciDialog sjena" style="display: none;">

            <asp:Label ID="labelLebdeciDialogPitanje" runat="server" Text=""></asp:Label>
            <asp:Label ID="labelLebdeciDialogOdgovor" runat="server" Text="NE" Style="display: none;"></asp:Label><br />
            <asp:Button ID="buttonLebdeciDialogOK" runat="server" Text="Da" OnClick="buttonLebdeciDialogOK_Click" />
            &nbsp;
            <asp:Button ID="buttonLebdeciDialogCANCEL" runat="server" Text="Ne" OnClick="buttonLebdeciDialogCANCEL_Click" />


            <br />


        </div>

    </div>



</asp:Content>
