<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RTDownloadNew.aspx.cs" Inherits="WapXzone_VNM.Wap.RTDownloadNew" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>

<%@ Register src="UserControlNew/Footer.ascx" tagname="Footer" tagprefix="uc2" %>
<%@ Register src="UserControlNew/Header.ascx" tagname="Header" tagprefix="uc1" %>
<%@ Register Src="../Wap/UserControlNew/TimKiem.ascx" TagName="TimKiem" TagPrefix="uc3" %>
<%@ Register src="../Music/UserControlNew/RTHot.ascx" tagname="RTHot" tagprefix="uc4" %>
<%@ Register Src="UserControlNew/DichVu.ascx" TagName="DichVu" TagPrefix="uc5" %>
<%@ Register src="../Game/UserControlNew/GameHot.ascx" tagname="GameHot" tagprefix="uc6" %>
<%@ Register src="../Tintuc/UserControlNew/HotNews.ascx" tagname="HotNews" tagprefix="uc7" %>

<%@ Register Src="UserControlNew/LienKet.ascx" TagName="LienKet" TagPrefix="uc8" %>



<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile - Nhac Chuong Free Download :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server" EnableViewState="False"></asp:Literal>
    <style media="screen" type="text/css">
        @import "../css/mainnew.css";
    </style>
</head>
<body>
    <form id="form2" runat="server">
    
<uc1:Header ID="Header1" runat="server" EnableViewState="False" /> <%--Header--%>


<uc3:TimKiem ID="TimKiem1" runat="server" EnableViewState="False" /> <%--Tim kiem--%>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><%= AppEnv.CheckLang("Nhạc chuông miễn phí")%></td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
    </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">

          <asp:Repeater ID="rptRingTone" runat="server">

            <ItemTemplate>
                <tr>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td width="11" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/iconnhac.jpg" width="15" height="14" /></td>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle" bgcolor="dedbd6" class="style10" style="height:45px;" ><strong>
                <asp:HyperLink CssClass="link-non-black" runat="server" ID="lnkFile"></asp:HyperLink>
            </strong></td>
          </tr>


            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
            <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle"><img alt="" src="/imagesnew/iconnhac.jpg" width="15" height="14" /></td>
            <td width="8" align="left" valign="middle">&nbsp;</td>
            <td align="left" valign="middle" class="style7" style="height:45px;"><span class="style10"><strong>
                <asp:HyperLink CssClass="link-non-black" runat="server" ID="lnkFile"></asp:HyperLink>
            </strong></span></td>
          </tr>

            </AlternatingItemTemplate>

          </asp:Repeater>

      </table></td>
  </tr>
</table> <%--Nhac chuong Down free--%>

<uc4:RTHot ID="RTHot1" runat="server" EnableViewState="False" /> <%--Nhac Hot--%>

<uc6:GameHot ID="GameHot1" runat="server" EnableViewState="False" /> <%--Game Hot--%>

<uc5:DichVu ID="DichVu1" runat="server" EnableViewState="False" /> <%--Dich vu--%>

<uc7:HotNews ID="HotNews1" runat="server" EnableViewState="False" /> <%--TIn tuc--%>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="center" valign="top">
        <%--<img src="/imagesnew/banner2.jpg" width="314" height="73" />--%>
        <asp:Literal ID="litAds1" runat="server" EnableViewState="False"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td align="left" valign="top"><img src="/imagesnew/blank.gif" width="5" height="9" /></td>
  </tr>
</table> <%--Quang cao--%>

<uc8:LienKet ID="LienKet1" runat="server" EnableViewState="False" /> <%--Lien ket--%>

<uc2:Footer ID="Footer1" runat="server" EnableViewState="False" /> <%--Footer--%>
    
    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />

    </form>
    
</body>
</html>
