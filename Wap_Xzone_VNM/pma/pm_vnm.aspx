<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pm_vnm.aspx.cs" Inherits="WapXzone_VNM.pm_vnm" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Xac nhan giao dich</title>
</head>
<body>
    <form id="form1" runat="server">
     <div style="margin:10px 5px 10px 5px">
        <asp:Literal ID="ltrMSISDN" runat="server" EnableViewState="false"></asp:Literal>
    </div>
    <asp:Panel ID="pnlXacnhan" runat="server" EnableViewState="false" Visible="false">
        <div style="margin:0px 5px 10px 5px">
            <asp:Literal ID="ltrTB" runat="server" EnableViewState="false"></asp:Literal>
        </div>
        <div style="margin-bottom:10px; text-align:center;" runat="server" id="divCMD" EnableViewState="false">
            <p><asp:LinkButton ID="btnDongY" runat="server" onclick="btnDongY_Click">Đồng ý</asp:LinkButton>&nbsp;|&nbsp;<asp:LinkButton 
                    ID="btnHuyBo" runat="server" onclick="btnHuyBo_Click">Huỷ bỏ</asp:LinkButton></p>
        </div>    
    </asp:Panel>
    <asp:Panel ID="pnlThongbao" runat="server" EnableViewState="false" Visible="false">
        <div style="margin:0px 5px 10px 5px">
            <asp:Literal ID="ltrTB1" runat="server" EnableViewState="false"></asp:Literal>
        </div>        
    </asp:Panel>
    </form>
</body>
</html>