<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Event_Video.ascx.cs" Inherits="WapXzone_VNM.Video.UserControl.Event_Video" %>
<%--<%@ Register Src="../../Wap/UserControl/Paging.ascx" TagName="Paging" TagPrefix="uc1" %>--%>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrTieude" runat="server" EnableViewState="False">Noel bên nhau</asp:Literal></div></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False">
        <ItemTemplate>            
            <div class="item">
                <asp:HyperLink ID="lnkAvatar" runat="server" EnableViewState="False" CssClass="thumb-b">
                    <asp:Image ID="imgAvatar" runat="server" EnableViewState="False" Width="60" />
                </asp:HyperLink>
                <div class="item-info">
                    <asp:HyperLink ID="lnkTenAnh" runat="server" EnableViewState="False"></asp:HyperLink>
                    <p></p>
                    <p><asp:Literal ID="ltrLuottai" runat="server" EnableViewState="False"></asp:Literal></p>
                    <asp:HyperLink ID="lnkTai" runat="server" EnableViewState="False"><span class="orange bold">Tải</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkXem" runat="server" EnableViewState="False"><span class="orange bold">Xem</span></asp:HyperLink>&nbsp;|&nbsp;<asp:HyperLink ID="lnkTang" runat="server" EnableViewState="False"><span class="orange bold">Tặng</span></asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>         
        </ItemTemplate>       
    </asp:Repeater>
    <%--<uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />--%>
</div>
<div class="clearfix"></div>
<div class="listlink" style="font-style:italic;">
    <asp:HyperLink ID="lnkXemthem" runat="server">Xem thêm »</asp:HyperLink><br />
    <%--<asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>   --%> 
</div>
<div class="clearfix"></div>