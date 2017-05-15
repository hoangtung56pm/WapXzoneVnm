<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KQXSNew.aspx.cs" Inherits="WapXzone_VNM.Xoso.KQXSNew" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>

<%@ Register Src="../Wap/UserControlNew/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Wap/UserControlNew/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="../Wap/UserControlNew/TimKiem.ascx" TagName="TimKiem" TagPrefix="uc3" %>

<%@ Register Src="../Xoso/UserControlNew/KetQuaTheoNgay.ascx" TagName="KetQuaTheoNgay" TagPrefix="uc4" %>

<%@ Register Src="../Game/UserControlNew/TruyCapNhanh.ascx" TagName="TruyCapNhanh"
    TagPrefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Wap Vietnamobile - Xo so :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server" EnableViewState="False"></asp:Literal>
    <style media="screen" type="text/css">
        @import "../css/mainnew.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <%--Header--%>
    <uc1:Header ID="Header1" runat="server" EnableViewState="False" />
    <uc3:TimKiem ID="TimKiem1" runat="server" EnableViewState="False" />
    <%--End Header--%>
    <%--Content--%>
    <asp:Panel ID="pnlSMS" runat="server" Visible="false">
        <div class="rbroundbox">
	        <div class="rbtop"><div><asp:Literal ID="ltrHuongdan" runat="server">HƯỚNG DẪN</asp:Literal></div></div>
        </div>
        <div style="text-align: center;" class="boxcontent">
	        <p><asp:Literal ID="ltrSMS" runat="server">Soạn tin nhắn theo cú pháp</asp:Literal></p>            
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlThongBao" runat="server" Visible="false">
        <div class="rbroundbox">
	        <div class="rbtop"><div><asp:Literal ID="ltrTitle" runat="server">THÔNG BÁO</asp:Literal></div></div>
        </div>
        <div style="text-align: center;" class="boxcontent">
	        <p><asp:Literal ID="ltrThongBao" runat="server">THÔNG BÁO</asp:Literal></p>
            <asp:Button ID="btnCo" runat="server" onclick="btnCo_Click" /> 
            <asp:Button ID="btnKhong" runat="server" onclick="btnKhong_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlNoiDung" runat="server" Visible="false">
        <div class="rbroundbox">
	        <div class="rbtop"><div><asp:Literal ID="ltrTieuDe" runat="server">NỘI DUNG</asp:Literal></div></div>
        </div>
        <div class="boxcontent">
            <asp:Label ID="lblTen" runat="server" CssClass="blue bold"></asp:Label>
	        <p><asp:Literal ID="ltrNoiDung" runat="server"></asp:Literal></p>
	        <div id="detail" runat="server">
                <div id="g1" class="itemlist" runat="server">
                    <asp:Label ID="lbldb6" runat="server" CssClass="blue bold">Dac Biet DB6</asp:Label>                    
                    <asp:Literal ID="ltrgdb6" runat="server"></asp:Literal>
                </div>
                <div class="itemlist">
                    <asp:Label ID="lbldb" runat="server" CssClass="blue bold">Dac Biet</asp:Label>                    
                    <asp:Literal ID="ltrdb" runat="server"></asp:Literal>
                </div>
                <div class="itemlist">
                    <asp:Label ID="lblg1" runat="server" CssClass="blue bold">Nhat</asp:Label>                    
                    <asp:Literal ID="ltrg1" runat="server"></asp:Literal>
                </div>
                <div class="itemlist">
                    <asp:Label ID="lblg2" runat="server" CssClass="blue bold">Nhi</asp:Label>
                    <asp:Literal ID="ltrg2" runat="server"></asp:Literal>
                </div>
                <div class="itemlist">
                    <asp:Label ID="lblg3" runat="server" CssClass="blue bold">Ba</asp:Label>
                    <asp:Literal ID="ltrg3" runat="server"></asp:Literal>
                </div>
                <div class="itemlist">
                    <asp:Label ID="lblg4" runat="server" CssClass="blue bold">Tu</asp:Label>
                    <asp:Literal ID="ltrg4" runat="server"></asp:Literal>
                </div>
                <div class="itemlist">
                    <asp:Label ID="lblg5" runat="server" CssClass="blue bold">Nam</asp:Label>
                    <asp:Literal ID="ltrg5" runat="server"></asp:Literal>
                </div>
                <div class="itemlist">
                    <asp:Label ID="lblg6" runat="server" CssClass="blue bold">Sau</asp:Label>
                    <asp:Literal ID="ltrg6" runat="server"></asp:Literal>
                </div>
                <div class="itemlist">
                    <asp:Label ID="lblg7" runat="server" CssClass="blue bold">Bay</asp:Label>
                    <asp:Literal ID="ltrg7" runat="server"></asp:Literal>
                </div>
                <div id="g8" runat="server" class="itemlist">
                    <asp:Label ID="lblg8" runat="server" CssClass="blue bold">Tam</asp:Label>
                    <asp:Literal ID="ltrg8" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </asp:Panel>
    <%--End Content--%>

     <%--Ket Qua Theo Ngay--%>

     <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><%= AppEnv.CheckLang("Kết quả theo ngày")%></td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
      <tr>
        <td colspan="3" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
      </tr>
    </table>
        
        <asp:Repeater ID="rptOther" runat="server" EnableViewState="false">
            <ItemTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="8" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="5" /></td>
            <td width="16" align="left" valign="top"><img alt="" src="/imagesnew/iconxoso.png" width="16" height="16" /></td>
            <td width="8" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="5" /></td>
            <td align="left" valign="middle"><span class="style10"><asp:HyperLink CssClass="link-non-black" ID="lnkother" NavigateUrl="#" runat="server"></asp:HyperLink></span></td>
          </tr>
          <tr>
            <td colspan="4" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="3" /></td>
          </tr>
          <tr>
            <td colspan="4" align="left" valign="top" bgcolor="#CCCCCC"><img alt="" src="/imagesnew/blank.gif" width="8" height="1" /></td>
          </tr>
          <tr>
            <td colspan="4" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="3" /></td>
          </tr>
        </table>
            </ItemTemplate>
        </asp:Repeater>



     </td>
  </tr>
</table>

     <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><img alt="" src="/imagesnew/blank.gif" width="8" height="20" /></td>
    <td width="125%" align="left" valign="middle" class="style11"> (<%= AppEnv.CheckLang("Giá") %>: <%= AppEnv.CheckLang("KQ chờ") %> <%= AppEnv.GetSetting("kqchoxsprice")%> đ, <%= AppEnv.CheckLang("Soi cầu") %> <%= AppEnv.GetSetting("xssoicauprice")%> đ, <%= AppEnv.CheckLang("Kết quả") %> <%= AppEnv.GetSetting("kqxsprice")%> đ) </td>
  </tr>
</table>

    <%--End Ket Qua Theo Ngay--%>

    <uc5:TruyCapNhanh ID="TruyCapNhanh1" runat="server" EnableViewState="False" />
    <%--Footer--%>
    <uc2:Footer ID="Footer1" runat="server" EnableViewState="False" />
    <%--End Footer--%>

    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />

    </form>
</body>
</html>