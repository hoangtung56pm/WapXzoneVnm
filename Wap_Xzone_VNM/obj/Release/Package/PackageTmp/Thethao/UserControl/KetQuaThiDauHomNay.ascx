﻿<%@ OutputCache Duration="120" VaryByParam="*" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KetQuaThiDauHomNay.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControl.KetQuaThiDauHomNay" %>
<%@ Register src="Paging.ascx" tagname="Paging" tagprefix="uc1" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:HyperLink ID="lnkTheThao" runat="server" EnableViewState="False"></asp:HyperLink> » <asp:Literal ID="ltrKetQuaThiDauHomNay" runat="server" EnableViewState="False"></asp:Literal></div></div>
</div>
<div class="clearfix"></div>
<asp:Repeater ID="rptCategory" runat="server" EnableViewState="False">
    <ItemTemplate>
        <div class="boxcontent">
            <div class="bold"><asp:Literal ID="ltrGiaiDau" runat="server" EnableViewState="False"></asp:Literal></div>
        </div>
        <div class="boxcontent">
            <asp:Repeater ID="rptLichThiDau" runat="server" EnableViewState="False">
                <ItemTemplate>
                    <div class="item"> 
                        <img src="../../img/b-ball.gif" alt="thumb" class="thumblist">
                        <div class="item-info">
                            <asp:Label ID="ltrGame" runat="server" EnableViewState="False"></asp:Label>                 
                            <p><asp:Literal ID="ltrTime" runat="server" EnableViewState="False"></asp:Literal></p>
                            <asp:Panel ID="pnlDichvu" runat="server" EnableViewState="False" Visible="false">
                            <asp:HyperLink ID="lnkTuVan" runat="server" EnableViewState="False" Text="Tu van"></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkThongke" runat="server" EnableViewState="False" Text="Thong ke"></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkKQCho" runat="server" EnableViewState="False" Text="KQ cho"></asp:HyperLink>
                            </asp:Panel>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </ItemTemplate>        
            </asp:Repeater>
        </div>
    </ItemTemplate>
</asp:Repeater>
<div class="clearfix"></div>
<uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />