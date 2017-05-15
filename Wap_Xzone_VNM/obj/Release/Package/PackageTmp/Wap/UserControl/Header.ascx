<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControl.Header" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%--<table style="width:100%;" border="0" cellpadding="0" cellspacing="0" background="/img/h_vl_bg.jpg" >--%>
<table style="width:100%; background-color:#EBE9E6;" border="0" cellpadding="0" cellspacing="0" >
    <tbody>
        <tr>
            <td colspan="2"><asp:Literal ID="ltrXinChao" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <%--<td style="width:70px; height:40px; margin-left:10px">
            <img src="/img/logo.png" style="margin-left:5px" />
            </td>--%>
            <td style="height:40px" align="center">
            
            <%--<a class="noelbanner" href="http://kqtt.vn"><img width="193" height="37" src="/imagesnew/banner.gif" border="0" /></a>--%>

            <asp:Literal ID="litAdvTop" runat="server"></asp:Literal>

            </td>
        </tr>
        <tr>
            <td colspan="2">
            <%--<div class="runtext" style="color:White">--%>
            <div class="runtext" style="color:#FF6600">
                <p><marquee direction="left" scrolldelay="90">  
                    <asp:Repeater ID="rptHotnews" runat="server">
                        <ItemTemplate>
                            <%--<asp:HyperLink ID="lnkHotnews" runat="server" style="color:White">--%>
                            <asp:HyperLink ID="lnkHotnews" runat="server" style="color:#FF6600">
                            </asp:HyperLink>
                            <asp:Literal ID="ltrSeprator" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:Repeater>
                </marquee></p>
            </div></td>
        </tr>            
    </tbody>
</table>
<div class="clearfix"></div>
<div class="mainmenu">
    <asp:HyperLink ID="lnkTrangChu" runat="server">Trang chủ</asp:HyperLink> | 
    <asp:HyperLink ID="lnkGame" runat="server">Game</asp:HyperLink> | 
    <asp:HyperLink ID="lnkNhac" Visible="false" runat="server">Nhạc</asp:HyperLink> <%--| --%>

    <%--<asp:HyperLink ID="lnkKetQua" runat="server">Bóng đá</asp:HyperLink> --%>
    <%--<a href="http://wap.vietnamobile.com.vn/bi-mat-hot-girl/mai-tho.aspx"><%= AppEnv.CheckLang("Hẹn Hò") %></a>--%>
    
    <%--| --%>

    <a href="/trangnhaccho/index.html">Nhạc chờ</a> |

    <a href="/Wap/DailyInfo.aspx?lang=<%= lang %>&w=<%= width %>">DailyInfo</a>

    <%--|--%><asp:HyperLink ID="lnkWap3g" Visible="false" runat="server">Wap 3G</asp:HyperLink>
</div>
<div class="clearfix"></div>
<div class="sfrm" style="display:none;">
	<div class="sfrmtop">
	    <div>
            <asp:TextBox ID="txtKeyword" CssClass="sfrminput inputx" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddlDataType" CssClass="sfrminput input60" runat="server">
                <asp:ListItem Value="1" Text="Nhạc"></asp:ListItem>
                <asp:ListItem Value="2" Text="Hình nền"></asp:ListItem>
                <asp:ListItem Value="3" Text="Game"></asp:ListItem>
                <asp:ListItem Value="4" Text="Ứng dụng"></asp:ListItem>
                <asp:ListItem Value="5" Text="Video"></asp:ListItem>
            </asp:DropDownList>    	
            <asp:ImageButton ID="btnSearch" ImageUrl="../../img/sfrm-icon.png" 
                CssClass="sfrmsubmit" runat="server" onclick="btnSearch_Click" 
                CausesValidation="False" />        
        </div>
    </div>
</div>