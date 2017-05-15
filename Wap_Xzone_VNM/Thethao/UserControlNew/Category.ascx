<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControlNew.Category" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1">
            <asp:HyperLink CssClass="link-non-white" ID="lnkTheThao" runat="server" EnableViewState="False"></asp:HyperLink> » <asp:Literal ID="ltrCacGiaiDau" runat="server" EnableViewState="False"></asp:Literal>
        </td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
      
    </table>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        
        <asp:Repeater ID="rptCategory" runat="server" EnableViewState="False">
            <ItemTemplate>
                <tr>
          <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td width="11" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/sport-soccer-icon.png" width="16" height="16" /></td>
          <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td align="left" valign="middle" bgcolor="dedbd6" class="style10">
	            <asp:HyperLink CssClass="link-non-black" ID="lnkCatName" runat="server" EnableViewState="False"></asp:HyperLink>
          </td>
        </tr>
            </ItemTemplate>

            <AlternatingItemTemplate>
                <tr>
          <td width="8" align="left" valign="middle"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td align="left" valign="middle"><img alt="" src="/imagesnew/sport-soccer-icon.png" width="16" height="16" /></td>
          <td width="8" align="left" valign="middle">&nbsp;</td>
          <td align="left" valign="middle" class="style7">
            <span class="style10">
                <asp:HyperLink CssClass="link-non-black" ID="lnkCatName" runat="server" EnableViewState="False"></asp:HyperLink>
            </span>
          </td>
        </tr>
            </AlternatingItemTemplate>

        </asp:Repeater>

      </table>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        <tr>
          <td><img alt="" src="/imagesnew/blank.gif" width="8" height="20" /></td>
          <td width="125%" align="left" valign="middle"><span class="style11"><asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>    </span></td>
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