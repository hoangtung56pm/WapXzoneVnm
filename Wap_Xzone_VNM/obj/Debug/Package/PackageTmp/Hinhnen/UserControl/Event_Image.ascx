<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Event_Image.ascx.cs" Inherits="WapXzone_VNM.Hinhnen.UserControl.Event_Image" %>
<%--<%@ Register Src="../../Wap/UserControl/Paging.ascx" TagName="Paging" TagPrefix="uc1" %>--%>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrTieude" runat="server" EnableViewState="False">Noel sắc màu</asp:Literal></div></div>
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
    <%--<uc1:Paging ID="Paging1" runat="server" />--%>
</div>
<div class="listlink" style="font-style:italic;">
    <asp:HyperLink ID="lnkXemthem" runat="server">Xem thêm »</asp:HyperLink>
    <%--<asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>    --%>
</div>