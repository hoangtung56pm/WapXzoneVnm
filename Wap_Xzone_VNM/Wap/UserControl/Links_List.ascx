<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Links_List.ascx.cs" Inherits="WapXzone_VNM.Wap.UserControl.Links_List" %>
<asp:Repeater ID="rptLienket" runat="server">
    <ItemTemplate>
        <div class="rbroundbox">
	        <div class="rbtop"><div><asp:Literal ID="ltrNhom" runat="server"></asp:Literal></div></div>
        </div>
        <div style="padding: 0px 5px;">
            <asp:Repeater ID="rptDonvi" runat="server">
                <ItemTemplate>                    
                    <asp:Literal ID="divClass" runat="server"></asp:Literal>
                        <asp:HyperLink ID="lnkIcon" runat="server">
                            <asp:Image ID="imgAvatar" runat="server" AlternateText="thumb" CssClass="thumb" />
                        </asp:HyperLink>                        
                        <asp:HyperLink ID="lnkDonvi" runat="server"></asp:HyperLink>
                        <p><asp:Literal ID="ltrMota" runat="server"></asp:Literal></p>
                        <div class="clearfix"></div>                        
                    </div>
                </ItemTemplate>                
            </asp:Repeater>
        </div>
    </ItemTemplate>
</asp:Repeater>