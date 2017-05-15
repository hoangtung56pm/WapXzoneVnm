<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VideoDownloadNew.aspx.cs" Inherits="WapXzone_VNM.Wap.VideoDownloadNew" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Register Src="UserControlNew/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="UserControlNew/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Wap/UserControlNew/TimKiem.ascx" TagName="TimKiem" TagPrefix="uc3" %>
<%@ Register Src="../Music/UserControlNew/RTHot.ascx" TagName="RTHot" TagPrefix="uc4" %>
<%@ Register Src="UserControlNew/DichVu.ascx" TagName="DichVu" TagPrefix="uc5" %>
<%@ Register Src="../Game/UserControlNew/GameHot.ascx" TagName="GameHot" TagPrefix="uc6" %>
<%@ Register Src="../Tintuc/UserControlNew/HotNews.ascx" TagName="HotNews" TagPrefix="uc7" %>
<%@ Register Src="UserControlNew/LienKet.ascx" TagName="LienKet" TagPrefix="uc8" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Vietnamobile - Video Free Download :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server" EnableViewState="False"></asp:Literal>
    <style media="screen" type="text/css">
        @import "../css/mainnew.css";
    </style>
</head>
<body>
    <form id="form2" runat="server">
    <uc1:Header ID="Header1" runat="server" EnableViewState="False" />
    <%--Header--%>
    <uc3:TimKiem ID="TimKiem1" runat="server" EnableViewState="False" />
    <%--Tim kiem--%>

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
            <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1">
                <%= AppEnv.CheckLang("Video miễn phí")%>
            </td>
            <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
          </tr>
          <tr>
            <td colspan="3" align="left" valign="top" bgcolor="#F5F5F5"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
          </tr>
        </table>

        <asp:Repeater ID="rptItem" runat="server" EnableViewState="False">
            <ItemTemplate>

                    <table width="100%" border="0" cellpadding="0" cellspacing="0" background="/imagesnew/bgrclip.gif">
          <tr>
            <td width="8" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="90" /></td>
            <td width="82" align="left" valign="top"><table width="90" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td align="left" valign="top" bgcolor="c6c6c6"><table width="100%" border="0" cellspacing="1" cellpadding="1">
                      <tr>
                        <td bgcolor="#EDEDED">
                            <%--<img alt="" src="/imagesnew/im2.jpg" width="82" height="66" hspace="3" vspace="3" />--%>
                            <asp:HyperLink ID="lnkAvatar" runat="server" EnableViewState="False">
                                <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" Width="82" />
                            </asp:HyperLink>
                         </td>
                      </tr>
                  </table></td>
                </tr>
            </table></td>
            <td width="20" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="20" height="10" /></td>
            <td width="125%" align="left" valign="top" class="style2">
                <span class="style4">
                    <asp:HyperLink CssClass="link-non-orange" ID="lnkTen" runat="server" EnableViewState="False"></asp:HyperLink>
                </span>
                <br />

            </td>
            <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="90" /></td>
          </tr>
        </table>

                    
                    <asp:Literal ID="litBlank" runat="server" EnableViewState="false"></asp:Literal>

            </ItemTemplate>
        </asp:Repeater>

       </td>
  </tr>
</table>
    <%--Video Down free--%>

    <uc4:RTHot ID="RTHot1" runat="server" EnableViewState="False" />
    <%--Nhac Hot--%>
    <uc6:GameHot ID="GameHot1" runat="server" EnableViewState="False" />
    <%--Game Hot--%>
    <uc5:DichVu ID="DichVu1" runat="server" EnableViewState="False" />
    <%--Dich vu--%>
    <uc7:HotNews ID="HotNews1" runat="server" EnableViewState="False" />
    <%--TIn tuc--%>
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
</table>
    <%--Quang cao--%>
    <uc8:LienKet ID="LienKet1" runat="server" EnableViewState="False" />
    <%--Lien ket--%>
    <uc2:Footer ID="Footer1" runat="server" EnableViewState="False" />

    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />

    <%--Footer--%>
    </form>
</body>
</html>
