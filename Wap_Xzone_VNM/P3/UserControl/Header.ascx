<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="WapXzone_VNM.P3.UserControl.Header" %>
<div>
    <img src="images/banner320x50.gif" height="50" width="320"></div>
<div class="clearfix">
</div>
<div id="header" class="clear">
    <div class="left">
        <a href="#">
            <img src="images/space.gif" height="26" width="70"></a><asp:Literal ID="ltrXinChao"
                runat="server"></asp:Literal></div>
</div>
<div class="clearfix">
</div>
<div id="mainmenu">
    <table cellpadding="0" cellspacing="0" width="100%">
        <tbody>
            <tr style="margin: 0;">
                <td width="33%">
                    <a title="NEW" href="/P3/default.aspx?display=new">NEW</a>
                </td>
                <td width="33%">
                    <a title="TOP" href="/P3/default.aspx?display=top">TOP</a>
                </td>
                <td width="33%">
                    <a title="HOT" href="/P3/default.aspx?display=hot">HOT</a>
                </td>
            </tr>
        </tbody>
    </table>
</div>
