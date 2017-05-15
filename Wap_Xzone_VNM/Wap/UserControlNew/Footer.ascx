<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControlNew.Footer" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>

<table width="100%" border="0" cellpadding="0" cellspacing="0" bgcolor="f79720">
  <tr>
    <td align="left" valign="top"><img alt="" src="/imagesnew/blank.gif" width="3" height="37" /></td>
    <td width="125%" align="center" valign="middle" class="style1">
    
    <img alt="" src="/imagesnew/icon/top.png" /><a class="link-non-white" href="#"><%= AppEnv.CheckLang("Đầu trang")%></a> 
     
    <img alt="" src="/imagesnew/icon/kodau.png" /><asp:Literal ID="litNgonNgu" runat="server" EnableViewState="false"></asp:Literal> 
    
    <img alt="" src="/imagesnew/icon/2g.png" />
    <a class="link-non-white" href="http://wap.vietnamobile.com.vn/Wap/Default.aspx?lang=<%= lang %>&w=<%= width %>">Wap 2G </a>
    
    <br />
    <%= AppEnv.CheckLang("Bản quyền Vietnamobile")%></td>
  </tr>
</table>


