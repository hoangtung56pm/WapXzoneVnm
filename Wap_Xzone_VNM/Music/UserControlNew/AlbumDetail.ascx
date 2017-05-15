<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AlbumDetail.ascx.cs" Inherits="WapXzone_VNM.Music.UserControlNew.AlbumDetail" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<%@ Register Src="Pagging.ascx" TagName="Paging" TagPrefix="uc1" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><%= AppEnv.CheckLang("Album") %> >> <asp:Literal ID="ltrAlbumName" runat="server" EnableViewState="False"></asp:Literal> </td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
    </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <asp:Repeater ID="rptMusic" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <tr>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle" bgcolor="dedbd6" class="style10">
            <strong>
                <a class="link-non-black" href="<%# UrlProcess.GetMusicDetailUrlNew(lang,width,Eval("W_MItemID").ToString()) %>">
                <%# AppEnv.CheckLang(Eval("SongNameUnicode").ToString())%>
                </a>
            </strong>
                
            - <a class="link-non-black" href="<%# UrlProcess.GetMusicByArtistUrlNew(lang,width,Eval("ArtistID").ToString()) %>">
                <%# AppEnv.CheckLang(Eval("ArtistNameUnicode").ToString())%>
                </a>

            <br />
            <strong><a class="link-non-orange" href="<%# UrlProcess.GetMusicDownloadUrlNew(lang,width,Eval("W_MItemID").ToString()) %>">
                <%= AppEnv.CheckLang("Tải về") %></a></strong>

           </td>
          </tr>
                </ItemTemplate>
            </asp:Repeater>
      </table></td>
  </tr>
</table> <%--Moi Nhat--%>

<div class="clear5px"></div>
<uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />