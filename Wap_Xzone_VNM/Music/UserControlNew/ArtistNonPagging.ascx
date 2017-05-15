<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ArtistNonPagging.ascx.cs" Inherits="WapXzone_VNM.Music.UserControlNew.ArtistNonPagging" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><span class="style2"> <%= AppEnv.CheckLang("Bài hát theo ca sỹ") %> <span class="style13">&gt;&gt;
            <a class="link-non-white" href="<%= UrlProcess.GeMusicArtistUrlNew(lang,width) %>">
                <%= AppEnv.CheckLang("Xem thêm") %>
            </a>
        </span></span></td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
    </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">

          <asp:Repeater ID="rptTopCaSy" runat="server" EnableViewState="false">
            <ItemTemplate>
                <tr>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td width="11" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/mic.png" width="16" height="17" /></td>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle" bgcolor="dedbd6" class="style10"><strong>
                <a class="link-non-black" href="<%# UrlProcess.GetMusicByArtistUrlNew(lang,width,Eval("ArtistID").ToString()) %>">
                    <%# AppEnv.CheckLang(Eval("ArtistNameUnicode").ToString())%>
                </a>
            </strong></td>
          </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
            <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle"><img alt="" src="/imagesnew/mic.png" width="16" height="17" /></td>
            <td width="8" align="left" valign="middle">&nbsp;</td>
            <td align="left" valign="middle" class="style7"><span class="style10"><strong>
            <a class="link-non-black" href="<%# UrlProcess.GetMusicByArtistUrlNew(lang,width,Eval("ArtistID").ToString()) %>">
                <%# AppEnv.CheckLang(Eval("ArtistNameUnicode").ToString())%>
            </a>
            </strong></span></td>
          </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>
      </table>
    </td>
  </tr>
</table> <%--Bai Hat theo ca sy--%>