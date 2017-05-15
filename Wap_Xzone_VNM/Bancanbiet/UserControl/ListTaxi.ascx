
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ListTaxi.ascx.cs" Inherits="WapXzone_VNM.Bancanbiet.UserControl.ListTaxi" %>
<div class="rbroundbox">
	<div class="rbtop"><div>TAXI » <asp:Label ID="lblTitle" runat="server" EnableViewState="False"></asp:Label></div></div>
</div>
<div class="clearfix"></div>
<div class="boxcontent">
    <%--start detail--%>    
    <asp:Repeater ID="rptTaxidetail" runat="server" EnableViewState="False">
        <ItemTemplate>
            <div class="listlink">
                ♥ <asp:Literal ID="ltrTaxiName" runat="server" EnableViewState="False"></asp:Literal>
            </div>            
        </ItemTemplate>
    </asp:Repeater>
</div>
<div class="clearfix"></div>