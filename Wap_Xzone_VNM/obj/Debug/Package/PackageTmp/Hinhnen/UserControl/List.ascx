﻿
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.Hinhnen.UserControl.List" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:HyperLink ID="lnkHomeChannel" runat="server">ANH</asp:HyperLink> » <asp:HyperLink ID="lnkCateChannel" runat="server"></asp:HyperLink></div></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptlstCategory" runat="server">
        <ItemTemplate>            
            <div class="item">
                <asp:HyperLink ID="lnkAvatar" runat="server" CssClass="thumb-b">
                    <asp:Image ID="imgAvatar" runat="server" Width="60" />
                </asp:HyperLink>
                <div class="item-info">
                    <asp:HyperLink ID="lnkTenAnh" runat="server"></asp:HyperLink>
                    <p><asp:Literal ID="ltrTheloai" runat="server"></asp:Literal></p>
                    <p><asp:Literal ID="ltrLuottai" runat="server"></asp:Literal></p>
                    <asp:HyperLink ID="lnkTai" runat="server"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server"><span class="orange bold">Tặng</span></asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>         
        </ItemTemplate>        
    </asp:Repeater>
    <uc1:Paging ID="Paging1" runat="server" />

    <asp:Panel ID="pnlS2DkGame2" runat="server">
            <div class="clear5px"></div>
    <%--    //Sửa bỏi Bình Trần - 25/11/2016  --%>
          <%--  <div align="center">
                <a class="link-non-orange" href="/HinhNen/DangKy.aspx?lang=<%= lang %>&w=<%= width %>">
                    <span class="orange bold"> <%= AppEnv.CheckLang("Trải nghiệm miễn phí Hình Nền HOT") %> </span>
                 </a>
            </div>--%>

            <div class="clear5px"></div>

            </asp:Panel>

</div>
<div class="clearfix"></div>