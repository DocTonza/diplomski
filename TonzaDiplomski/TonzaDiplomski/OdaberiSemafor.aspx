<%@ Page Language="C#"  MasterPageFile="~/Site.Master"  AutoEventWireup="true" CodeBehind="OdaberiSemafor.aspx.cs" Inherits="TonzaDiplomski.OdaberiSemafor" %>


   

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

 <style>
        body {
            background-color: #e6e6e6;
            font-family: 'Arial Unicode MS';
            font-size:16px;
            color:black;
        }
        a {
            font-size:20px;
            color:black;
            
        }



        .glavni {
            align-content:center;
            margin-left: auto;
            margin-right: auto;
            width: 80%;
            justify-content:center;
      
            
        }



      
        .divZaPrikazOdabira {
            width:100%; 
            background-color:white; 
            height:60px;
            color:black;
            

        }


    </style>


        <asp:LinqDataSource ID="LinqDataSourceSemafori" runat="server" ContextTypeName="TonzaDiplomski.SemaforiDataContext" EntityTypeName="" OrderBy="naziv" Select="new (Id, naziv)" TableName="tblSemafors">
        </asp:LinqDataSource>
        <div runat="server" class="glavni">

            <br />
            Odaberite jedan od semafora koji će se prikazivati:<br />
            <asp:DataList ID="DataListSemafori" runat="server" DataSourceID="LinqDataSourceSemafori" CellSpacing="10">
                <ItemTemplate>



                    <div id="odabirServera" runat="server" class="divZaPrikazOdabira sjena">
                        <asp:LinkButton CommandArgument='<%# Eval("ID") %>' ID="nazivLabel" runat="server" OnClick="nazivLabel_Click" Text='<%# Eval("naziv") %> ' />
                    </div>

                    <br />

                </ItemTemplate>
            </asp:DataList>
            <br />

        </div>
</asp:Content>
