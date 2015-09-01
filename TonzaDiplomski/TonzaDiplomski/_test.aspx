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
            height:200px;
            background:#FFF;
            margin:40px auto;
            padding:10px;

        }

        .sjena {
            
                 box-shadow: 0 10px 6px -6px #dddddd;
                 
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div id="test" runat="server" class="box sjena">
                tu sad kao nešto piše
            </div>

        </div>
    </form>
</body>
</html>
