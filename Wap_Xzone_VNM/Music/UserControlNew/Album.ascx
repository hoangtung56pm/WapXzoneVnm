<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Album.ascx.cs" Inherits="WapXzone_VNM.Music.UserControlNew.Album" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<%@ Register Src="Pagging.ascx" TagName="Paging" TagPrefix="uc1" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><span class="style2"> <%= AppEnv.CheckLang("Album chọn lọc") %> 
         </span></td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
    </table>
        <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#ECECEC">
          <tr>
            <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
          </tr>
        </table>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            
            <asp:Repeater ID="rptAlbum1" runat="server" EnableViewState="false">
                <ItemTemplate>

                    <td rowspan="2" bgcolor="ececec">&nbsp;</td>
                    <td align="center" valign="top" bgcolor="ececec">
            <table width="90" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td align="left" valign="top" bgcolor="c6c6c6"><table width="100%" border="0" cellspacing="1" cellpadding="1">
                      <tr>
                        <td bgcolor="#EDEDED">
                            <a href="<%# UrlProcess.GetMusicByAlbumUrlNew(lang,width,Eval("W_MAlbumID").ToString()) %>">
                                <img alt="" src="<%# AppEnv.GetAvatar(Eval("Avatar").ToString(),85,85) %>" width="85" height="85" hspace="3" vspace="3" />
                            </a>
                        </td>
                      </tr>
                  </table></td>
                </tr>
            </table>
            </td>

                </ItemTemplate>
            </asp:Repeater>


            <td rowspan="2" bgcolor="ececec">&nbsp;</td>

          </tr>
          <tr>
            
            <asp:Repeater ID="rptAlbum11" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <td align="center" valign="middle" bgcolor="ececec" class="style2">
                        <a class="link-non-black" href="<%# UrlProcess.GetMusicByAlbumUrlNew(lang,width,Eval("W_MAlbumID").ToString()) %>">
                            <%# AppEnv.CheckLang(Eval("AlbumNameUnicode").ToString())%>
                         </a>
                     </td>
                </ItemTemplate>
            </asp:Repeater>

          </tr>
          <tr>
            <td colspan="7" align="left" valign="top" bgcolor="c3c3c3"><img alt="" src="/imagesnew/blank.gif" width="16" height="1" /></td>
          </tr>
        </table>
      <table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="#ECECEC">
          <tr>
            <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
          </tr>
        </table>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            
            <asp:Repeater ID="rptAlbum2" runat="server" EnableViewState="false">
                <ItemTemplate>

                    <td rowspan="2" bgcolor="ececec">&nbsp;</td>
                    <td align="center" valign="top" bgcolor="ececec">
            <table width="90" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td align="left" valign="top" bgcolor="c6c6c6"><table width="100%" border="0" cellspacing="1" cellpadding="1">
                      <tr>
                        <td bgcolor="#EDEDED">
                            <a href="<%# UrlProcess.GetMusicByAlbumUrlNew(lang,width,Eval("W_MAlbumID").ToString()) %>">
                                <img alt="" src="<%# AppEnv.GetAvatar(Eval("Avatar").ToString(),85,85) %>" width="85" height="85" hspace="3" vspace="3" />
                            </a>
                        </td>
                      </tr>
                  </table></td>
                </tr>
            </table>
            </td>

                </ItemTemplate>
            </asp:Repeater>

            <td rowspan="2" bgcolor="ececec">&nbsp;</td>

          </tr>
          <tr>

          <asp:Repeater ID="rptAlbum22" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <td align="center" valign="middle" bgcolor="ececec" class="style2">
                        <a class="link-non-black" href="<%# UrlProcess.GetMusicByAlbumUrlNew(lang,width,Eval("W_MAlbumID").ToString()) %>">
                            <%# AppEnv.CheckLang(Eval("AlbumNameUnicode").ToString())%>
                        </a>
                     </td>
                </ItemTemplate>
            </asp:Repeater>

          </tr>
          <tr>
            <td colspan="7" align="left" valign="top" bgcolor="c3c3c3"><img alt="" src="/imagesnew/blank.gif" width="16" height="1" /></td>
          </tr>
      </table></td>
  </tr>
</table> <%--Album--%>

<div class="clear5px"></div>
<uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />

