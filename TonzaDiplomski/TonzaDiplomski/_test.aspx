<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="_test.aspx.cs" Inherits="TonzaDiplomski._test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Test za editiranje postavki</title>

    <style>
        body {
            background-color:#eeeeee;
        }


        .container {
            position: relative;
            left: 100px;
            width: 400px;
            height: 400px;
        }

        .box {
            width:70%;
            height:20px;
            background:#FFF;
            margin:0px auto;
            padding:10px;

        }

        .boxIndent {
            position:relative;
            left:20px;
            /*right:0px;*/
            width:75%;
            height:20px;
            background:#FFF;
            margin:0px auto;
            padding:10px;

        }
        .sjena {
            
                 box-shadow: 0 10px 6px -6px #dddddd;
                 
        }
        .glavniContainer {
            background:#4cff00;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="glavniContainer" runat="server" class="glavniContainer"> 

            <div id="test" runat="server" class="box sjena">
                <asp:LinkButton runat="server" OnClick="Unnamed_Click"> sad kao nešto piše</asp:LinkButton>
            </div>

        </div>
    </form>
</body>
</html>
