<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MusicDetail.ascx.cs" Inherits="WapXzone_VNM.Music.UserControlNew.MusicDetail" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1">
            <asp:Literal ID="ltrAmNhac" runat="server">ÂM NHẠC</asp:Literal>
        </td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
      <tr>
        <td colspan="3" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
      </tr>
    </table>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td colspan="3" align="left" valign="middle">
            <strong class="style10"><asp:Literal ID="ltrTenAnh" runat="server"></asp:Literal></strong>- 
            <span class="style10"><asp:Literal ID="ltrCasy" runat="server"></asp:Literal><br />
            <asp:Literal ID="ltrLuottai" runat="server"></asp:Literal><br />
            <asp:Literal ID="ltrGiaTai" runat="server"></asp:Literal><br />
            <asp:HyperLink CssClass="link-non-black" ID="lnkTai" runat="server"><span class="bold">Tải về</span></asp:HyperLink>
</span></td>
        </tr>
        <tr>
          <td colspan="4" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="5" /></td>
        </tr>
      </table>
    </td>
  </tr>
</table>