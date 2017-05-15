<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LienKet.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControlNew.LienKet" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>

<%--Quang Cao--%>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="center" valign="top">
        <%--<img alt="" src="/imagesnew/banner3.jpg" width="314" height="74" />--%>
        <asp:Literal ID="litAds1" runat="server" EnableViewState="False"></asp:Literal>
    </td>
  </tr>
  <tr>
    <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
  </tr>
</table>



<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><%= AppEnv.CheckLang("Liên kết")%></td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
      
    </table>
      <table width="100%" border="0" cellspacing="0" cellpadding="0">
        
        <asp:Repeater ID="rptLienKet" runat="server" EnableViewState="false">
            <ItemTemplate>
                <tr>
          <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td width="11" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/dot.png" width="11" height="11" /></td>
          <td width="8" align="left" valign="middle" bgcolor="dedbd6"><img alt="" src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td align="left" valign="middle" bgcolor="dedbd6">
            <span class="style7">
                <strong><asp:Literal ID="ltrNhom" runat="server" EnableViewState="False"></asp:Literal></strong>
                <asp:Literal ID="ltrDonvi" runat="server" EnableViewState="False"></asp:Literal>
            </span>
          </td>
        </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr>
          <td width="8" align="left" valign="middle"><img src="/imagesnew/blank.gif" width="8" height="25" /></td>
          <td align="left" valign="middle"><img src="/imagesnew/dot.png" width="11" height="11" /></td>
          <td width="8" align="left" valign="middle">&nbsp;</td>
          <td align="left" valign="middle" class="style7">
                <strong><asp:Literal ID="ltrNhom" runat="server" EnableViewState="False"></asp:Literal></strong>
                <asp:Literal ID="ltrDonvi" runat="server" EnableViewState="False"></asp:Literal>
          </td>
        </tr>
            </AlternatingItemTemplate>
        </asp:Repeater>

      </table></td>
  </tr>
</table>
