<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="User_Agent.aspx.cs" Inherits="WapXzone_VNM.User_Agent" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:100%">
        <div id="left" style="float: left; width: 50%">
            <div style="float: left">
                <asp:TextBox ID="txtUserAgentName" Width="30%" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnSubmit" Text="Submit Now!!!!" runat="server" 
                    onclick="btnSubmit_Click" />
            </div>
        </div>
        <div id="right" style="float:right;width:50%">
            <asp:TextBox ID="txtResult" runat="server" TextMode="MultiLine" Rows="6" Width="40%"></asp:TextBox>
        </div>
    </div>
    </form>
</body>
</html>
