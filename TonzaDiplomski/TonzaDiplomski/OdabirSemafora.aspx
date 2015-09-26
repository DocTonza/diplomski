<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OdabirSemafora.aspx.cs" Inherits="TonzaDiplomski.OdabirSemafora" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        body {
            background-color: #e6e6e6;
            color:black;
        }

        .naslov {
            font-family: 'Arial Unicode MS';
            font-size:22px;
            color:black;

        }
        a {
            color:black;
            text-decoration:none;

        }

        table a:not(.btn){
            color:black;
            text-decoration:none;
            font-family: 'Arial Unicode MS';
            font-size:16px;

        }

        .OdaberiSemafor {
            position:relative;
            background-color:white;
            border:none;
            width:460px;
            height:60px;
            margin-left:auto;
            margin-right:auto;
            padding-top:20px;
            padding-bottom:5px;
            text-align:center;
            
           
        }

        .glavni{
            position:relative;
            text-align:center;
            margin-left:auto;
            margin-right:auto;
            width:80%;
            align-content:center;
            border:none;
        }
        
        table {
            width:100%
        }

        


    </style>

    <asp:LinqDataSource ID="LinqDataSourceSemafori" runat="server" ContextTypeName="TonzaDiplomski.SemaforiDataContext" EntityTypeName="" OrderBy="naziv" Select="new (Id, naziv)" TableName="tblSemafors">
        </asp:LinqDataSource>


         <div runat="server" class="glavni">

             <br />
             <span class=naslov> Odaberite semafor koji želite prikazati:</span>

            <br /><br /><br />
            <span class="naslov" Odaberite jedan od semafora koji će se prikazivati:<br /></span>
            <asp:DataList ID="DataListSemafori" runat="server" DataSourceID="LinqDataSourceSemafori" CellSpacing="10">
                <ItemTemplate>



                    <div id="odabirServera" runat="server" class="OdaberiSemafor sjena">
                        <asp:LinkButton CommandArgument='<%# Eval("ID") %>' ID="nazivLabel" runat="server" OnClick="nazivLabel_Click" Text='<%# Eval("naziv") %> ' />
                    </div>

                    
                </ItemTemplate>
            </asp:DataList>
            <br />

        </div>



</asp:Content>
