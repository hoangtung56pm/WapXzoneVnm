<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MusicHome.ascx.cs" Inherits="WapXzone_VNM.Music.UserControlNew.MusicHome" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>


<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top">
    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><%= AppEnv.CheckLang("Clip Nhạc") %><span class="style5"> &gt;&gt;
            <a class="link-non-white" href="<%= UrlProcess.GetVideoCategoryUrlNew(lang,width,"6") %>">
                <%= AppEnv.CheckLang("Xem thêm") %>
            </a>
            </span></td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
      <tr>
        <td colspan="3" align="left" valign="top" bgcolor="#FFFFFF"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
      </tr>
    </table>
      
      <asp:Repeater ID="rptClipNhac" runat="server" EnableViewState="false">
        <ItemTemplate>

             <table width="100%" border="0" cellpadding="0" cellspacing="0" background="/imagesnew/bgrclip.gif">
          <tr>
            <td width="8" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="90" /></td>
            <td width="82" align="left" valign="top"><table width="90" border="0" cellpadding="0" cellspacing="0">
                <tr>
                  <td align="left" valign="top" bgcolor="c6c6c6"><table width="100%" border="0" cellspacing="1" cellpadding="1">
                      <tr>
                        <td bgcolor="#EDEDED">
                            <a href="<%# UrlProcess.GetVideoDetailUrlNew(lang,"detail",width,Eval("W_VItemID").ToString()) %>">
                                <img alt="" src="<%# AppEnv.GetAvatar(Eval("VThumnail").ToString(),82,66) %>" width="82" height="66" hspace="3" vspace="3" />
                            </a>
                         </td>
                      </tr>
                  </table></td>
                </tr>
            </table></td>
            <td width="20" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="20" height="10" /></td>
            <td width="125%" align="left" valign="top" class="style2">
                <span class="style4">
                    <a class="link-non-orange" href="<%# UrlProcess.GetVideoDetailUrlNew(lang,"detail",width,Eval("W_VItemID").ToString()) %>">
                        <%# AppEnv.CheckLang(Eval("VTitle_Unicode").ToString())%>
                    </a>
                </span><br />
              <%= AppEnv.CheckLang("Thể loại") %>: <%# AppEnv.CheckLang(Eval("Web_Name").ToString()) %><br />
              <strong>
                <a class="link-non-black" href="<%# UrlProcess.GetVideoDownloadUrlNew(lang,width,Eval("W_VItemID").ToString()) %>">
                    <%= AppEnv.CheckLang("Tải") %> 
                </a>
                I 
                <a class="link-non-black" href="<%# UrlProcess.GetVideoViewUrlNew(lang,width,Eval("W_VItemID").ToString()) %>">
                    Xem 
                </a>
              </strong>
            </td>
            <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="90" /></td>
          </tr>
        </table>

             <asp:Literal ID="litBlank" runat="server" EnableViewState="false"></asp:Literal>

        </ItemTemplate>
      </asp:Repeater>

     </td>
  </tr>
</table> <%--Clip Nhac--%>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><%= AppEnv.CheckLang("Mới nhất") %> </td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
    </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <asp:Repeater ID="rptMusicMoiNhat" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <tr>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td width="11" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/iconnhac.jpg" width="15" height="14" /></td>
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
           </td>
          </tr>
                </ItemTemplate>
            </asp:Repeater>
      </table></td>
  </tr>
</table> <%--Moi Nhat--%>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><%= AppEnv.CheckLang("Hot tháng") %></td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
    </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
            <asp:Repeater ID="rptMusicHotThang" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <tr>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td width="11" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/iconnhac.jpg" width="15" height="14" /></td>
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
           </td>
          </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </td>
  </tr>
</table> <%--Hot Nhat--%>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><span class="style2"> <%= AppEnv.CheckLang("Album chọn lọc") %> &gt;&gt;
            <a class="link-non-white" href="<%= UrlProcess.GeMusicAlbumUrlNew(lang,width) %>">
                <%= AppEnv.CheckLang("Xem thêm") %>
            </a>
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

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><span class="style2"> <%= AppEnv.CheckLang("Bài hát theo thể loại") %> <span class="style13">&gt;&gt;
        <a class="link-non-white" href="<%= UrlProcess.GeMusicStyleUrlNew(lang,width) %>">
            <%= AppEnv.CheckLang("Xem thêm") %>
        </a>
        </span></span></td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
    </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          
          <asp:Repeater ID="rptTheLoai" runat="server" EnableViewState="false">
            <ItemTemplate>
                <tr>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td width="11" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/iconnhac.jpg" width="15" height="14" /></td>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle" bgcolor="dedbd6" class="style10"><strong>
                <a class="link-non-black" href="<%# UrlProcess.GetMusicByStyleUrlNew(lang,width,Eval("StyleID").ToString()) %>">
                    <%# AppEnv.CheckLang(Eval("StyleNameUnicode").ToString())%>
                </a>
            </strong></td>
          </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
            <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle"><img alt="" src="/imagesnew/iconnhac.jpg" width="15" height="14" /></td>
            <td width="8" align="left" valign="middle">&nbsp;</td>
            <td align="left" valign="middle" class="style7"><span class="style10"><strong> 
                <a class="link-non-black" href="<%# UrlProcess.GetMusicByStyleUrlNew(lang,width,Eval("StyleID").ToString()) %>"> 
                    <%# AppEnv.CheckLang(Eval("StyleNameUnicode").ToString())%>
                </a>
            </strong></span></td>
          </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>
      </table></td>
  </tr>
</table> <%--Bai hat theo the loai--%>