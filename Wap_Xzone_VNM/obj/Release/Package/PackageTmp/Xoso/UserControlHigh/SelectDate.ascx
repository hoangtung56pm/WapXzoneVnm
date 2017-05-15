<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SelectDate.ascx.cs" Inherits="WapXzone_VNM.Xoso.UserControlHigh.SelectDate" %>


<asp:DropDownList ID="dropDay" runat="server" AutoPostBack="true" CssClass="wap-text" onselectedindexchanged="dropDay_SelectedIndexChanged">
</asp:DropDownList>
&nbsp;
<asp:Button ID="Button1" runat="server" Text="Chon" onclick="Button1_Click" />