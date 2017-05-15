
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.Thugian.UserControl.List" %>
<%@ Register src="Paging.ascx" tagname="Paging" tagprefix="uc1" %>
<%@ Register src="Category.ascx" tagname="Category" tagprefix="uc2" %>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Label ID="lblCatName" runat="server" EnableViewState="False"></asp:Label></div></div>
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
    <asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>    
</div>
<div class="clearfix"></div>
<uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />
<uc2:Category ID="Category" runat="server" EnableViewState="False" />