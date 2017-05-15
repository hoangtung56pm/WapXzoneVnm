<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.Hot100.UserControl.List" %>
<%@ Register Src="Pagging.ascx" TagName="Pagging" TagPrefix="uc3" %>
<div class="khung">
    <asp:Repeater ID="rptlstCategory" runat="server" EnableViewState="false">
        <ItemTemplate>
            <div class="item1">
                <asp:HyperLink  ID="lnkDL" runat="server"><img src="img/dl.gif" border="0" class="dl" EnableViewState="false" /></asp:HyperLink>            
                <div>
                    <p><asp:Literal ID="ltrStt" runat="server" EnableViewState="false"></asp:Literal>
                    <asp:Label ID="lblTen" CssClass="bold" runat="server" EnableViewState="false"></asp:Label></p>
                    <p><span class="casy"><asp:Literal ID="ltrCasy" runat="server" EnableViewState="false"></asp:Literal></span></p>
                </div>
            </div>
            <div class="clearfix"></div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="item0">
                <asp:HyperLink  ID="lnkDL" runat="server"><img src="img/dl.gif" border="0" class="dl" EnableViewState="false" /></asp:HyperLink>            
                <div>
                    <p><asp:Literal ID="ltrStt" runat="server" EnableViewState="false"></asp:Literal>
                    <asp:Label ID="lblTen" CssClass="bold" runat="server" EnableViewState="false"></asp:Label></p>
                    <p><span class="casy"><asp:Literal ID="ltrCasy" runat="server" EnableViewState="false"></asp:Literal></span></p>
                </div>
            </div>
            <div class="clearfix"></div>
        </AlternatingItemTemplate>
    </asp:Repeater>
    <div class="clearfix"></div>
    <div style="text-align:center; padding: 5px;"><uc3:Pagging ID="Pagging1" runat="server" EnableViewState="false" /></div>    
</div>
<div class="clearfix"></div>