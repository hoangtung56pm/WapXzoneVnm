<%@ OutputCache Duration="333" VaryByParam="*" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Category.ascx.cs" Inherits="WapXzone_VNM.Thugian.UserControl.Category" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<asp:Repeater ID="rptZoneList" runat="server" EnableViewState="False">
    <ItemTemplate>
        <div class="rbroundbox">
	        <div class="rbtop"><div><asp:Label ID="lblCatetoryName" runat="server" EnableViewState="False">Chuyen muc tin</asp:Label></div></div>
        </div>
        <div class="boxcontent">
            <asp:Repeater ID="rptCategory" runat="server" EnableViewState="False">
                <ItemTemplate>
                    <div class="listlink">
                        <img src="../img/b-fun1.gif"> <asp:HyperLink ID="lnkCatName" runat="server" EnableViewState="False"></asp:HyperLink>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <asp:Panel ID="pnlDangKy" Visible="false" runat="server">
            <div class="clear5px"></div>

            <div align="center">
               <%-- <a class="link-non-orange" href="/HinhNen/DangKy.aspx?lang=1&w=320">
                    <span class="orange bold"> Trải nghiệm miễn phí Hình Nền HOT </span>
                 </a>--%>
                 <asp:Literal ID="litContent" runat="server"></asp:Literal>
            </div>

            <div class="clear5px"></div>

            </asp:Panel>

        </div>
    </ItemTemplate>
</asp:Repeater>
