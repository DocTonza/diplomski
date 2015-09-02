<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="editSemafora.aspx.cs" Inherits="TonzaDiplomski.editSemafora" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:SemaforiDBContext %>" DeleteCommand="DELETE FROM [tblSemafor] WHERE [Id] = @Id" InsertCommand="INSERT INTO [tblSemafor] ([naziv]) VALUES (@naziv)" SelectCommand="SELECT * FROM [tblSemafor]" UpdateCommand="UPDATE [tblSemafor] SET [naziv] = @naziv WHERE [Id] = @Id">
            <DeleteParameters>
                <asp:Parameter Name="Id" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="naziv" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="naziv" Type="String" />
                <asp:Parameter Name="Id" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
        <asp:ListView ID="ListView1" runat="server" DataKeyNames="Id" DataSourceID="SqlDataSource1" InsertItemPosition="LastItem">
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Obriši" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Promijeni" />
                    </td>
                    
                    <td>
                        <asp:Label ID="nazivLabel" runat="server" Text='<%# Eval("naziv") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color:#008A8C;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Promijeni" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Odustani" />
                    </td>
                    <td>
                        nbsp;
                    </td>
                    <td>
                        <asp:TextBox ID="nazivTextBox" runat="server" Text='<%# Bind("naziv") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr runat="server">
                        <td runat="server">Nema podataka</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Novi" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Očisti" />
                    </td>
                    
                    <td>
                        <asp:TextBox ID="nazivTextBox" runat="server" Text='<%# Bind("naziv") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Obriši" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Promijeni" />
                    </td>
                   
                    <td>
                        <asp:Label ID="nazivLabel" runat="server" Text='<%# Eval("naziv") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                    <th runat="server"></th>
                                    
                                    <th runat="server">naziv</th>
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;"></td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                   
                    
                    <td>
                        <asp:Label ID="nazivLabel" runat="server" Text='<%# Eval("naziv") %>' />
                    </td>
                     <td>
                        <asp:Button ID="DeleteButton" runat="server" CommandName="Delete" Text="Briši" />
                        <asp:Button ID="EditButton" runat="server" CommandName="Edit" Text="Promijeni" />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>

        <div>
            <asp:DetailsView ID="DetailsView1" runat="server" Height="50px" Width="125px" AutoGenerateRows="False" DataKeyNames="Id" DataSourceID="SqlDataSource1">
                <Fields>
                    <asp:BoundField DataField="Id" HeaderText="Id" InsertVisible="False" ReadOnly="True" SortExpression="Id" />
                    <asp:BoundField DataField="naziv" HeaderText="naziv" SortExpression="naziv" />
                </Fields>
            </asp:DetailsView>
        </div>
    </form>
</body>
</html>
