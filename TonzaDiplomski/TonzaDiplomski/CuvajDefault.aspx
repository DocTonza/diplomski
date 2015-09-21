<%@ Page Title="Test 123" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TonzaDiplomski._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<div class="jumbotron">
        Ovo je jumbotron klasa
        <p>&nbsp;</p>
    </div>--%>

    <div runat="server" class="row" id="PrviRed">
        <!-- tu će doći kod iz PageLoad metode -->
    </div>
    <div class="row">
        <div runat="server" id="DrugiRedPrvi" class="col-lg-4 col-md-6">
            
           

        </div>
        <div runat="server" id="DrugiRedDrugi"  class="col-lg-4 col-md-6">
            <svg width="500" height="400" style="border:dotted;">
                <g id="NaslovStupci">
                    <text x="225" y="40" class="grafNaslov">Naslov stupčanog grafa</text>

                </g>
                
                <g id="koordinatniSustav" zIndex="6">
                    <line x1="30" y1="250" x2="30" y2="50" fill="black" stroke="white" stroke-width="2" ></line>
                    <line x1="30" y1="350" x2="370" y2="350" fill="black" stroke="white" stroke-width="2"></line>
                </g>
                <g id="nasloviKoordinatnogSustava" >
                    <text alignment-baseline="middle" x="195" y="390" 
                        class="naslovKoordinatnogSustavaStupci">Naslov X osi</text>
                    <text alignment-baseline="middle" x="20" y="155" 
                        transform="rotate(-90,20,150)"
                        class="naslovKoordinatnogSustavaStupci">Naslov Y osi</text>
                </g>
            </svg>
        </div>
        <div runat="server" id="DrugiRedTreci"  class="col-lg-4 col-md-6">
            
            <svg width="500" height="400" style="border:dotted;">
                <g id="NaslovStupci1">
                    <text x="225" y="40" class="grafNaslov">Naslov stupčanog grafa</text>

                </g>
                
                <g id="koordinatniSustav1" zIndex="6">
                    <line id="osX" x1="30" y1="350" x2="30" y2="150" fill="black" stroke="white" stroke-width="2" ></line>
                    <line id="osY" x1="30" y1="350" x2="370" y2="350" fill="black" stroke="white" stroke-width="2"></line>
                </g>
                <g id="nasloviKoordinatnogSustava1" >
                    <text alignment-baseline="middle" x="195" y="390" 
                        class="naslovKoordinatnogSustavaStupci">Naslov X osi u zadnjem</text>
                    <text alignment-baseline="middle" x="20" y="155" 
                        transform="rotate(-90,20,150)"
                        class="naslovKoordinatnogSustavaStupci">Naslov Y osi</text>
                </g>


            </svg>
        </div>
    </div>

</asp:Content>
