<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OdaberiSemafor.aspx.cs" Inherits="TonzaDiplomski.OdaberiSemafor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:LinqDataSource ID="LinqDataSourceSemafori" runat="server" ContextTypeName="TonzaDiplomski.SemaforiDataContext" EntityTypeName="" OrderBy="naziv" Select="new (Id, naziv)" TableName="tblSemafors">
        </asp:LinqDataSource>
    <div>
    
        <br />
        Odaberite jedan od semafora koji će se prikazivati:<br />
        <asp:DataList ID="DataListSemafori" runat="server" DataSourceID="LinqDataSourceSemafori">
            <ItemTemplate>
               
                <br />
                
                <asp:LinkButton CommandArgument='<%# Eval("ID") %>' ID="nazivLabel" runat="server" OnClick="nazivLabel_Click" Text='<%# Eval("naziv") %>' />
                <br />
<br />
            </ItemTemplate>
        </asp:DataList>
        <br />
    
    </div>
    </form>
</body>
</html>
