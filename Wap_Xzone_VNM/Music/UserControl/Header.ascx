<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Header.ascx.cs" Inherits="WapXzone_VNM.Music.UserControl.Header" %>

<%--<div class="userinfo">
    <asp:Literal ID="ltrXinChao" runat="server"></asp:Literal>
</div>
<table style="width:99%;">
    <tbody>
        <tr>
            <td><img src="../img/logo.png"></td>
            <td align="right"><img src="img/m-adv-top.gif" class="adv-top"></td>
        </tr>
    </tbody>
</table>--%>

<table style="width:100%; background-color:#EBE9E6;" border="0" cellpadding="0" cellspacing="0" >
    <tbody>
        <tr>
            <td colspan="2"><asp:Literal ID="ltrXinChao" runat="server"></asp:Literal></td>
        </tr>
        <tr>
            <td style="width:70px; height:40px; margin-left:10px">
            <%--<img src="/img/logo.png" style="margin-left:5px" />--%>
            </td>
            <td style="height:40px" align="center">

            <%--<a class="noelbanner" href="http://tdhv.net/"><img src="/images/193 x 37.jpg" border="0"></a>--%>

            <a class="noelbanner" href="http://wap.vietnamobile.com.vn"><img width="193" height="37" src="/imagesnew/banner.gif" border="0"></a>

            </td>
        </tr>
        <%--<tr>
            <td colspan="2">
            <div class="runtext" style="color:#FF6600">
                <p><marquee direction="left" scrolldelay="90">  
                    <asp:Repeater ID="rptHotnews" runat="server">
                        <ItemTemplate>
                            <asp:HyperLink ID="lnkHotnews" runat="server" style="color:#FF6600">
                            </asp:HyperLink>
                            <asp:Literal ID="ltrSeprator" runat="server"></asp:Literal>
                        </ItemTemplate>
                    </asp:Repeater>
                </marquee></p>
            </div></td>
        </tr>--%>            
    </tbody>
</table>

<div class="clearfix"></div>
<div class="mainmenu"> 
    <asp:HyperLink ID="lnkTrangChu" runat="server">Trang chủ</asp:HyperLink>
     » <asp:HyperLink ID="lnkAmNhac" runat="server">Âm nhạc</asp:HyperLink><asp:Literal ID="ltrLienKet" runat="server"></asp:Literal>
</div>
<div class="clearfix"></div>
<div class="sfrm">
	<div class="sfrmtop">
	    <div>
            <asp:TextBox ID="txtKeyword" CssClass="sfrminput input80" runat="server"></asp:TextBox>
            <asp:DropDownList ID="ddlDataType" CssClass="sfrminput input90" runat="server">
                <asp:ListItem Value="0" Text="Tìm theo tất cả"></asp:ListItem>
                <asp:ListItem Value="1" Text="Tên bài hát"></asp:ListItem>
                <asp:ListItem Value="2" Text="Tên ca sỹ"></asp:ListItem>
            </asp:DropDownList>    	
            <asp:ImageButton ID="btnSearch" ImageUrl="../../img/sfrm-icon.png" 
                CssClass="sfrmsubmit" runat="server" onclick="btnSearch_Click" 
                CausesValidation="False" />        
        </div>
    </div>
</div>