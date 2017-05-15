<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QuickMenu.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControlNew.QuickMenu" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1">
            <asp:Literal ID="ltrDuLieuBongDa" runat="server" EnableViewState="False">DỮ LIỆU BÓNG ĐÁ</asp:Literal>
        </td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
    </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td width="11" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/sport-soccer-icon.png" width="16" height="16" /></td>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle" bgcolor="dedbd6" class="style10">
                <asp:HyperLink ID="lnkThongKeDacBiet" CssClass="link-non-black" runat="server" EnableViewState="False">Thống kê đặc biệt</asp:HyperLink>
            </td>
          </tr>
          <tr>
            <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle"><img alt="" src="/imagesnew/sport-soccer-icon.png" width="16" height="16" /></td>
            <td width="8" align="left" valign="middle">&nbsp;</td>
            <td align="left" valign="middle" class="style7">
                <span class="style10">
                    <asp:HyperLink ID="lnkKQNgay" CssClass="link-non-black" runat="server" EnableViewState="False">Kết quả hôm nay</asp:HyperLink>
                </span>
             </td>
          </tr>
          <tr>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/sport-soccer-icon.png" width="16" height="16" /></td>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6">&nbsp;</td>
            <td align="left" valign="middle" bgcolor="dedbd6" class="style7"><span class="style10">
                <asp:HyperLink ID="lnkLTDNgay" CssClass="link-non-black" runat="server" EnableViewState="False">Lịch thi đấu hôm nay</asp:HyperLink>
            </span></td>
          </tr>
          <tr>
            <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle"><img alt="" src="/imagesnew/sport-soccer-icon.png" width="16" height="16" /></td>
            <td width="8" align="left" valign="middle">&nbsp;</td>
            <td align="left" valign="middle" class="style7"><span class="style10">
                <asp:HyperLink ID="lnkLTD" CssClass="link-non-black" runat="server" EnableViewState="False">Lịch thi đấu</asp:HyperLink>
            </span></td>
          </tr>
          <tr>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/sport-soccer-icon.png" width="16" height="16" /></td>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6">&nbsp;</td>
            <td align="left" valign="middle" bgcolor="dedbd6" class="style10">
                <asp:HyperLink ID="lnkKQTD" CssClass="link-non-black" runat="server" EnableViewState="False">Kết quả thi đấu</asp:HyperLink>
            </td>
          </tr>
          <tr>
            <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle"><img alt="" src="/imagesnew/sport-soccer-icon.png" width="16" height="16" /></td>
            <td width="8" align="left" valign="middle">&nbsp;</td>
            <td align="left" valign="middle" class="style10"><asp:HyperLink ID="lnkBXH" CssClass="link-non-black" runat="server" EnableViewState="False">Bảng xếp hạng</asp:HyperLink></td>
          </tr>
      </table></td>
  </tr>
</table> <%--Du lieu bong da--%>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><asp:Literal ID="ltrGiaiTriBongDa" runat="server" EnableViewState="False">GIẢI TRÍ BÓNG ĐÁ</asp:Literal></td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
    </table>
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td width="11" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/sport-soccer-icon.png" width="16" height="16" /></td>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle" bgcolor="dedbd6" class="style10">
                <asp:HyperLink ID="lnkNhac" runat="server" CssClass="link-non-black" EnableViewState="False">Nhạc chuông</asp:HyperLink>
            </td>
          </tr>
          <tr>
            <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle"><img alt="" src="/imagesnew/sport-soccer-icon.png" width="16" height="16" /></td>
            <td width="8" align="left" valign="middle">&nbsp;</td>
            <td align="left" valign="middle" class="style7"><span class="style10">
                <asp:HyperLink ID="lnkVideo" runat="server" CssClass="link-non-black" EnableViewState="False">Video clip</asp:HyperLink>
            </span></td>
          </tr>
          <tr>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
            <td align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/sport-soccer-icon.png" width="16" height="16" /></td>
            <td width="8" align="left" valign="middle" bgcolor="dedbd6">&nbsp;</td>
            <td align="left" valign="middle" bgcolor="dedbd6" class="style7"><span class="style10">
                <asp:HyperLink ID="lnkAnh" runat="server" CssClass="link-non-black" EnableViewState="False">Hình đẹp thể thao</asp:HyperLink>
            </span></td>
          </tr>
      </table></td>
  </tr>
</table> <%--Giai tri bong da--%>
