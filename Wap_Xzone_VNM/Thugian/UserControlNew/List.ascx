<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.Thugian.UserControlNew.List" %>

<%@ Register src="Pagging.ascx" tagname="Paging" tagprefix="uc1" %>
<%@ Register src="Category.ascx" tagname="Category" tagprefix="uc2" %>

<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1">

            <asp:Label ID="lblCatName" runat="server" EnableViewState="False"></asp:Label>
            
            <span class="style5"></span></td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
      <tr>
        <td colspan="3" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
      </tr>
    </table>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        
        <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False">
            <ItemTemplate>
                <tr>
                    <asp:Literal ID="litwidth5" runat="server" EnableViewState="false"></asp:Literal>
                    <td width="11" align="left" valign="top"><img alt="" src="/imagesnew/dot2.png" width="11" height="15" /></td>
                    <asp:Literal ID="litwidth6" runat="server" EnableViewState="false"></asp:Literal>
                    <td width="125%">
                        <span class="style4">
                            <asp:HyperLink ID="lnkTitle" CssClass="link-non-orange" runat="server" EnableViewState="False"></asp:HyperLink>
                        </span>
                        <br />
                    <span class="style13_XoSo"><asp:Literal ID="ltrLuotxem" runat="server" EnableViewState="False"></asp:Literal></span></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>

      </table>
     </td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><img alt="" src="/imagesnew/blank.gif" width="8" height="20" /></td>
    <td width="125%" align="left" valign="middle" class="style11"> <asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal> </td>
  </tr>
</table>

<uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />
<uc2:Category ID="Category" runat="server" EnableViewState="False" />