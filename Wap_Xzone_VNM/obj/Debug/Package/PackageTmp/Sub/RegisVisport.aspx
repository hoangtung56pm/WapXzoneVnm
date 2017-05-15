<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisVisport.aspx.cs" Inherits="WapXzone_VNM.Sub.RegisVisport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width; initial-scale=1.0" />	
    <style>
        #bg
        {
            top:0;
            left:0;
            width:100%;
            height:100%;
            z-index:-1;
        }
        .back_gr
        {        
            height:70px;
            width:50%;
            margin-left:25%;
            margin-bottom:2%;
            float:left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="bg" align="center">
        <a href="/Sub/RegisVisport1.aspx">
            <asp:Literal ID="ltrimg" runat="server"></asp:Literal>
           
        </a> 
    </div>
    </form>
</body>
</html>
