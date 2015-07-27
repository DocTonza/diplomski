<%@ Page Title="Test 123" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TonzaDiplomski._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%--<div class="jumbotron">
        Ovo je jumbotron klasa
        <p>&nbsp;</p>
    </div>--%>

    <div class="row">
        <div class="col-lg-4">
            
            <div runat="server" id="PrviOdTri"></div>

        </div>
        <div runat="server" id="DrugiOdTri" class="col-lg-4">
            Naslov grafa u retku 1 stupcu 2
            <br />

            

        </div>
        <div runat="server" id="TreciOdTri" class="col-lg-4">
            
           
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4">
            Tu radimo na ruke kao priprema za dinamički
            <br />
            <svg width="450" height="300" style="border:dotted">
                <g>
                    <path d="M350 50 L370 50 L370 70 L350 70 Z" style="fill:red"></path>
                    <text x="375" y="65"">Prvi item</text>
                </g>
                <g>
                    <path d="M350 80 L370 80 L370 100 L350 100 Z" style="fill:yellow"></path>
                    <text x="375" y="95" transform="translate(20,20)" zIndex="6">Drugi item</text>
                </g>

            </svg>

        </div>
        <div class="col-lg-4">
            Naslov grafa u retku 2 stupcu 2
            <br />
            <canvas id="kanvas_2-2" style="border: 1px solid #000000; background-color: white; width: 100%"></canvas>
        </div>
        <div class="col-lg-4">
            Naslov grafa u retku 2 stupcu 3
            <br />
            <canvas id="kanvas_2-3" style="border: 1px solid #000000; background-color: white; width: 100%"></canvas>
        </div>
    </div>

</asp:Content>
