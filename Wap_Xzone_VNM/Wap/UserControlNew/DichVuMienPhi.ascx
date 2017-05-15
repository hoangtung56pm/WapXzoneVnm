<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DichVuMienPhi.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControlNew.DichVuMienPhi" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
    <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><%= AppEnv.CheckLang("Dịch vụ miễn phí") %></td>
    <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
  </tr>
  <tr>
    <td colspan="3" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
  </tr>
</table>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>

    <td width="15" rowspan="2" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="15" height="10" /></td>
    <td align="center" valign="top">
        <a class="link-non-black" href="/Free/NhacChuong.aspx">
            <img alt="" src="/imagesnew/icon_ring.png" width="46" height="46" />
        </a>
    </td>

    <td rowspan="2" align="center" valign="top">&nbsp;</td>
    <td align="center" valign="top">
        <a class="link-non-black" href="/Free/Video.aspx">
            <img alt="" src="/imagesnew/bigicon9.png" width="47" height="46" />
        </a>
        </td>
    <td rowspan="2" align="center" valign="top">&nbsp;</td>
    <td align="center" valign="top">
        <%--<a class="link-non-black" href="<%= UrlProcess.GetGameFreeDownloadUrlNew(lang.ToString(),width) %>" >--%>
        <a class="link-non-black" href="/Free/Game.aspx" >
            <img alt="" src="/imagesnew/icon_games.png" width="47" height="46" />
        </a>
    </td>
    <td rowspan="2" align="center" valign="top">&nbsp;</td>
    <td align="center" valign="top">
        <a class="link-non-black" href="/Free/HinhNen.aspx">
            <img alt="" src="/imagesnew/icon_wall.png" width="46" height="47" />
        </a>
    </td>
    <td width="15" rowspan="2" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="15" height="10" /></td>
  </tr>
  <tr>
    <td align="center" valign="middle" class="style2"><a class="link-non-black" href="/Free/NhacChuong.aspx"><%= AppEnv.CheckLang("Nhạc chuông") %></a> </td>
    <td align="center" valign="middle"><span class="style2"><a class="link-non-black" href="/Free/Video.aspx"><%= AppEnv.CheckLang("Video") %></a> </span></td>
    <td align="center" valign="middle"><span class="style2"><a class="link-non-black" href="/Free/Game.aspx" >Game</a></span></td>
    <td align="center" valign="middle"><span class="style2"><a class="link-non-black" href="/Free/HinhNen.aspx"><%= AppEnv.CheckLang("Hình nền") %></a></span></td>
  </tr>
  <tr>
    <td colspan="9"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
  </tr>
</table>
