<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SearchResult.ascx.cs"
    Inherits="WapXzone.Thugian.UserControl.SearchResult" %>
<%@ Register Src="Pagging.ascx" TagName="Pagging" TagPrefix="uc3" %>
<%@ Register Src="Category.ascx" TagName="Category" TagPrefix="uc2" %>
<%@ Register Src="QuickMenu.ascx" TagName="QuickMenu" TagPrefix="uc1" %>
<%@ Register src="Paging.ascx" tagname="Paging" tagprefix="uc4" %>
<div class="home_box_title">
    <asp:Label ID="lblTitle" runat="server" EnableViewState="False">Ket qua tim kiem</asp:Label>
    <%--<div style="float: right;">
        <img src="../images/mobifone_home_box_title_right.jpg" height="23" width="13" /></div>--%>
</div>
<div class="clear10px">
</div>
<div class="ketqua-timkiem">
    <asp:Literal ID="ltrCount" runat="server" EnableViewState="False"></asp:Literal>
</div>
<div class="content-news-list">
    <asp:Repeater ID="rptResult" runat="server" EnableViewState="False">
       <ItemTemplate>
            <div class="content-row0">
                <div class="row-title">
                    <asp:HyperLink ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink>
                    <div class="clear0px">
                    </div>
                    <i>
                        <asp:Label ID="lblCreatedOn" runat="server" EnableViewState="False"></asp:Label></i>
                </div>
                <div class="clear5px">
                </div>
            </div>
        </ItemTemplate>
        <AlternatingItemTemplate>
            <div class="content-row1">
                <div class="row-title">
                    <asp:HyperLink ID="lnkTitle" runat="server" EnableViewState="False"></asp:HyperLink>
                    <div class="clear0px">
                    </div>
                    <i>
                        <asp:Label ID="lblCreatedOn" runat="server" EnableViewState="False"></asp:Label></i>
                </div>
                <div class="clear5px">
                </div>
            </div>
        </AlternatingItemTemplate>
    </asp:Repeater>
</div>
<div class="clear5px">
</div>
<div class="clear10px">
</div>
<%--start Category--%>
<uc2:Category ID="Category1" runat="server" EnableViewState="False" />
<%--end Category--%>
<div class="clear10px">
</div>
<uc4:Paging ID="Paging1" runat="server" EnableViewState="False" />
