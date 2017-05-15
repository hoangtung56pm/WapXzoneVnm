<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ATMDetail.ascx.cs" Inherits="WapXzone_VNM.Bancanbiet.UserControl.ATMDetail1" %>
<div class="rbroundbox">
	<div class="rbtop"><div>
	    <asp:HyperLink ID="lnkAtm" runat="server" EnableViewState="False"></asp:HyperLink> » <asp:HyperLink ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink></div></div>
</div>
<div class="clearfix"></div>
<div class="boxcontent">
    <%--start detail--%>    
    <asp:Repeater ID="rptATMdetail" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="listlink">            
                ♥ <asp:Literal ID="ltrDetail" runat="server" EnableViewState="False"></asp:Literal>
            </div>         
        </ItemTemplate>
    </asp:Repeater>
    <asp:Label runat="server" EnableViewState="False" ID="lblThongbao" Visible="false">
        ♥ Khong co may ATM nao tai khu vuc ban tim kiem.<br />
        Ban co the tham khao may ATM cua cac ngan hang lien minh
    </asp:Label>    
    <%--end detail--%>
</div>
<div class="clearfix"></div>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Label ID="lblBankRelation" runat="server" EnableViewState="False">CAC NGAN HANG LIEN MINH</asp:Label></div></div>
</div>
<div class="boxcontent">    
    <asp:Repeater ID="rptbankRelation" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="listlink">
                <asp:HyperLink ID="lnkBankRelation" runat="server" EnableViewState="False"></asp:HyperLink>
            </div> 
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="clearfix"></div>