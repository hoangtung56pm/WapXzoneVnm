<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Event_Thugian.ascx.cs" Inherits="WapXzone_VNM.Thugian.UserControl.Event_Thugian" %>
<%--<%@ Register Src="../../Wap/UserControl/Paging.ascx" TagName="Paging" TagPrefix="uc1" %>--%>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrTieude" runat="server" EnableViewState="False">Giáng sinh yêu thương</asp:Literal></div></div>
</div>
<div class="boxcontent">    
    <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="item">
            <span class="thumblist">♥</span>
                <div class="item-info"> 
                    <asp:HyperLink ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink><br />
                    <asp:Literal ID="ltrLuotxem" runat="server" EnableViewState="False"></asp:Literal>
                </div>
                <div class="clearfix"></div>
            </div>
        </ItemTemplate> 
    </asp:Repeater>
</div>
<div class="clearfix"></div>
<div class="listlink" style="font-style:italic;">
    <asp:HyperLink ID="lnkXemthem" runat="server">Xem thêm »</asp:HyperLink><br />
    <%--<asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>  --%>  
</div>
<div class="clearfix"></div>
<%--<uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />--%>