<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BangXepHang.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControlNew.BangXepHang" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1">
            <asp:HyperLink CssClass="link-non-white" ID="lnkTheThao" runat="server" EnableViewState="False"></asp:HyperLink> » <asp:Literal ID="ltrBangxephang" runat="server" EnableViewState="False"></asp:Literal>
        </td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
      
    </table>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td width="11" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/sport-soccer-icon.png" width="16" height="16" /></td>
          <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td align="left" valign="middle" bgcolor="dedbd6" class="style15"><asp:Label ID="lblCompetitonName" runat="server" EnableViewState="False">Giải</asp:Label><asp:Literal ID="ltrRoundName" runat="server" EnableViewState="False"></asp:Literal></td>
        </tr>
      </table>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">

        <tr>
          <td width="8" bgcolor="#FFCC00"><img alt="" src="/imagesnew/blank.gif" width="1" height="15" /></td>
          <td width="30" align="center" valign="middle" bgcolor="#FFCC00" class="style15">TT</td>
          <td align="center" valign="middle" bgcolor="#FFCC00" class="style15"><asp:Label ID="lblDoi" runat="server" EnableViewState="False">Doi</asp:Label></td>
          <td align="center" valign="middle" bgcolor="#FFCC00" class="style15">T</td>
          <td align="center" valign="middle" bgcolor="#FFCC00" class="style15">H</td>
          <td align="center" valign="middle" bgcolor="#FFCC00" class="style15">B</td>
          <td width="50" align="center" valign="middle" bgcolor="#FFCC00" class="style15"><asp:Label ID="lblDiem" runat="server" EnableViewState="False">Diem</asp:Label></td>
        </tr>

        <asp:Repeater ID="rptbxh" runat="server" EnableViewState="False">
            <ItemTemplate>
                <tr>
                  <td width="8">&nbsp;</td>
                  <td width="30" align="center" valign="middle" class="style10"><asp:Literal ID="lblstt" runat="server" EnableViewState="False"></asp:Literal></td>
                  <td align="center" valign="middle" class="style10"><asp:Literal ID="lblCode" runat="server" EnableViewState="False"></asp:Literal></td>
                  <td align="center" valign="middle" class="style10"><asp:Literal ID="lblwin" runat="server" EnableViewState="False"></asp:Literal></td>
                  <td align="center" valign="middle" class="style10"><asp:Literal ID="lblDraw" runat="server" EnableViewState="False"></asp:Literal></td>
                  <td align="center" valign="middle" class="style10"><asp:Literal ID="lblLost" runat="server" EnableViewState="False"></asp:Literal></td>
                  <td width="50" align="center" valign="middle" class="style10"><asp:Literal ID="lblPoint" runat="server" EnableViewState="False"></asp:Literal></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>

      </table>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td><img alt="" src="/imagesnew/blank.gif" width="8" height="20" /></td>
          <td width="125%" align="left" valign="middle"><span class="style11">
            <asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>    
          </span></td>
        </tr>
      </table>
      <table width="100%" border="0" cellpadding="0" cellspacing="0">
        <tr>
          <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
        </tr>
      </table>
    </td>
  </tr>
</table>