<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KetQuaTheoNgay.ascx.cs" Inherits="WapXzone_VNM.Xoso.UserControlNew.KetQuaTheoNgay" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>

   <table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td align="left" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
      <tr>
        <td background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/blank.gif" width="5" height="10" /></td>
        <td width="125%" align="left" valign="middle" background="/imagesnew/bgrtop2.gif" class="style1"><%= AppEnv.CheckLang("Kết quả theo ngày")%></td>
        <td align="left" valign="top" background="/imagesnew/bgrtop2.gif"><img alt="" src="/imagesnew/righttit.jpg" width="65" height="25" /></td>
      </tr>
      <tr>
        <td colspan="3" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="5" height="9" /></td>
      </tr>
    </table>
        
        <asp:Repeater ID="rptOther" runat="server" EnableViewState="false">
            <ItemTemplate>
                <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td width="8" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="5" /></td>
            <td width="16" align="left" valign="top"><img alt="" src="/imagesnew/iconxoso.png" width="16" height="16" /></td>
            <td width="8" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="5" /></td>
            <td align="left" valign="middle"><span class="style10"><asp:HyperLink ID="lnkother" NavigateUrl="#" runat="server"></asp:HyperLink></span></td>
          </tr>
          <tr>
            <td colspan="4" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="3" /></td>
          </tr>
          <tr>
            <td colspan="4" align="left" valign="top" bgcolor="#CCCCCC"><img alt="" src="/imagesnew/blank.gif" width="8" height="1" /></td>
          </tr>
          <tr>
            <td colspan="4" align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="8" height="3" /></td>
          </tr>
        </table>
            </ItemTemplate>
        </asp:Repeater>
     </td>
  </tr>
</table>
<table width="100%" border="0" cellspacing="0" cellpadding="0">
  <tr>
    <td><img alt="" src="/imagesnew/blank.gif" width="8" height="20" /></td>
    <td width="125%" align="left" valign="middle" class="style11"> (<%= AppEnv.CheckLang("Giá") %>: <%= AppEnv.CheckLang("KQ chờ") %> <%= AppEnv.GetSetting("kqchoxsprice")%> đ, <%= AppEnv.CheckLang("Soi cầu") %> <%= AppEnv.GetSetting("xssoicauprice")%> đ, <%= AppEnv.CheckLang("Kết quả") %> <%= AppEnv.GetSetting("kqxsprice")%> đ) </td>
  </tr>
</table>