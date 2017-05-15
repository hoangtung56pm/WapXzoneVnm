<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TruyCapNhanh.ascx.cs" Inherits="WapXzone_VNM.Game.UserControlNew.TruyCapNhanh" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top">

    <table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"> <%= AppEnv.CheckLang("Truy cập nhanh")%> </td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
    </table>

        <table width="100%" border="0" cellspacing="0" cellpadding="0">

          <%--<tr>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td colspan="3" align="left" valign="middle" bgcolor="dedbd6"><table width="100%" border="0" cellspacing="0" cellpadding="0">
                <tr>
                  <td align="left" valign="top"><strong><img alt="" alt="" src="/imagesnew/home.png" width="23" height="25" /></strong></td>
                  <td width="125%" align="left" valign="middle"><strong class="style10"> <asp:HyperLink CssClass="link-non-black" ID="lnkTrangChu" runat="server"></asp:HyperLink> </strong></td>
                </tr>
            </table></td>
          </tr>--%>

          <tr>
          <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img src="images/blank.gif" width="8" height="25" /></td>
          <td colspan="6" align="left" valign="middle" bgcolor="dedbd6"><table width="100%" border="0" cellspacing="0" cellpadding="0">
            <tr>
              <td align="left" valign="top"><strong><img src="/imagesnew/home.png" width="23" height="25" /></strong></td>
              <td width="125%" align="left" valign="middle"><strong class="style10"><asp:HyperLink CssClass="link-non-black" ID="lnkTrangChu" runat="server"></asp:HyperLink> </strong></td>
            </tr>
          </table></td>
        </tr>

          <asp:Repeater ID="rptTruyCapNhanh" runat="server" Visible="false" EnableViewState="false">
            <ItemTemplate>
                <tr>
            <td width="8" align="left" valign="middle"><img alt="" alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td width="11" align="left" valign="middle"><img alt="" alt="" src="/imagesnew/dot.png" width="11" height="11" /></td>
            <td width="8" align="left" valign="middle">&nbsp;</td>
            <td align="left" valign="middle" class="style7">                
                <asp:Literal ID="ltrDonvi" runat="server" EnableViewState="False"></asp:Literal>
            </td>
          </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle" bgcolor="dedbd6"><img alt="" alt="" src="/imagesnew/dot.png" width="11" height="11" /></td>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6">&nbsp;</td>
            <td align="left" valign="middle" bgcolor="dedbd6" class="style7">                
                <asp:Literal ID="ltrDonvi" runat="server" EnableViewState="False"></asp:Literal>
            </td>
          </tr>
            </AlternatingItemTemplate>
          </asp:Repeater>


           <tr>
          <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td width="11" align="left" valign="middle"><img alt="" src="/imagesnew/dot.png" width="11" height="11" /></td>
          <td width="8" align="left" valign="middle">&nbsp;</td>
          <td align="left" valign="middle" class="style7">
            <a class="link-non-smokeblack" href="/Music/DefaultNew.aspx?display=home&lang=<%= lang %>&w=<%= width %>">
                <%= AppEnv.CheckLang("Nhạc") %>
            </a>
          </td>
          <td width="11" align="left" valign="middle" class="style7"><img alt="" src="/imagesnew/dot.png" width="11" height="11" /></td>
          <td width="5" align="left" valign="middle" class="style7"><img alt="" src="/imagesnew/blank.gif" width="8" height="5" /></td>
          <td align="left" valign="middle" class="style7">
            <a class="link-non-smokeblack" href="/HoangDao/DefaultNew.aspx?display=home&lang=<%= lang %>&w=<%= width %>">
                <%= AppEnv.CheckLang("Tử vi") %>
            </a>
          </td>
        </tr>
        <tr>
          <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/dot.png" width="11" height="11" /></td>
          <td width="8" align="left" valign="middle" bgcolor="dedbd6">&nbsp;</td>
          <td align="left" valign="middle" bgcolor="dedbd6" class="style7">
            <a class="link-non-smokeblack" href="/Game/DefaultNew.aspx?display=home&hotro=0&lang=<%= lang %>&w=<%= width %>">
                Game
            </a>
          </td>
          <td width="11" align="left" valign="middle" bgcolor="dedbd6" class="style7"><img alt="" src="/imagesnew/dot.png" width="11" height="11" /></td>
          <td width="5" align="left" valign="middle" bgcolor="dedbd6" class="style7">&nbsp;</td>
          <td align="left" valign="middle" bgcolor="dedbd6" class="style7">
             <a class="link-non-smokeblack" href="/Thugian/DefaultNew.aspx?display=home&lang=<%= lang %>&w=<%= width %>">
                 <%= AppEnv.CheckLang("Thư giãn") %>
            </a>
          </td>
        </tr>
        <tr>
          <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td align="left" valign="middle"><img alt="" src="/imagesnew/dot.png" width="11" height="11" /></td>
          <td width="8" align="left" valign="middle">&nbsp;</td>
          <td align="left" valign="middle" class="style7">
            <a class="link-non-smokeblack" href="/Hinhnen/DefaultNew.aspx?display=home&lang=<%= lang %>&w=<%= width %>">
                 <%= AppEnv.CheckLang("Hình nền") %>
            </a>
          </td>
          <td width="11" align="left" valign="middle" class="style7"><img alt="" src="/imagesnew/dot.png" width="11" height="11" /></td>
          <td width="5" align="left" valign="middle" class="style7">&nbsp;</td>
          <td align="left" valign="middle" class="style7">
            <a class="link-non-smokeblack" href="/Phanmem/DefaultNew.aspx?display=home&hotro=0&lang=<%= lang %>&w=<%= width %>">
                 <%= AppEnv.CheckLang("Phần mềm") %>
            </a>
          </td>
        </tr>
        <tr>
          <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/dot.png" width="11" height="11" /></td>
          <td width="8" align="left" valign="middle" bgcolor="dedbd6">&nbsp;</td>
          <td align="left" valign="middle" bgcolor="dedbd6" class="style7">
            <a class="link-non-smokeblack" href="/Thethao/DefaultNew.aspx?display=home&lang=<%= lang %>&w=<%= width %>">
                 <%= AppEnv.CheckLang("Bóng đá") %>
            </a>
          </td>
          <td width="11" align="left" valign="middle" bgcolor="dedbd6" class="style7"><img alt="" src="/imagesnew/dot.png" width="11" height="11" /></td>
          <td width="5" align="left" valign="middle" bgcolor="dedbd6" class="style7">&nbsp;</td>
          <td align="left" valign="middle" bgcolor="dedbd6" class="style7">
             <a class="link-non-smokeblack" href="/Tintuc/DefaultNew.aspx?display=home&lang=<%= lang %>&w=<%= width %>">
                 <%= AppEnv.CheckLang("Tin tức") %>
            </a>
          </td>
        </tr>
        <tr>
          <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td align="left" valign="middle"><img alt="" src="/imagesnew/dot.png" width="11" height="11" /></td>
          <td width="8" align="left" valign="middle">&nbsp;</td>
          <td align="left" valign="middle" class="style7">
            <a class="link-non-smokeblack" href="/Xoso/DefaultNew.aspx?display=home&lang=<%= lang %>&w=<%= width %>">
                 <%= AppEnv.CheckLang("Xổ số") %>
            </a>
          </td>
          <td width="11" align="left" valign="middle" class="style7"><img alt="" src="/imagesnew/dot.png" width="11" height="11" /></td>
          <td width="5" align="left" valign="middle" class="style7">&nbsp;</td>
          <td align="left" valign="middle" class="style7">
            <a class="link-non-smokeblack" href="/Video/DefaultNew.aspx?display=home&lang=<%= lang %>&w=<%= width %>">
                 <%= AppEnv.CheckLang("Video") %>
            </a>
          </td>
        </tr>

       <%-- <tr>
          <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/dot.png" width="11" height="11" /></td>
          <td width="8" align="left" valign="middle" bgcolor="dedbd6">&nbsp;</td>
          <td align="left" valign="middle" bgcolor="dedbd6" class="style7">Video</td>
          <td width="11" align="left" valign="middle" bgcolor="dedbd6" class="style7"><img alt="" src="/imagesnew/dot.png" width="11" height="11" /></td>
          <td width="5" align="left" valign="middle" bgcolor="dedbd6" class="style7">&nbsp;</td>
          <td align="left" valign="middle" bgcolor="dedbd6" class="style7">&nbsp;</td>
        </tr>--%>

      </table>
      
      </td>
  </tr>
</table>
