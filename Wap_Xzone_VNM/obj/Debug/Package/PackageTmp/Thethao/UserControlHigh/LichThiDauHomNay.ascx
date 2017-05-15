<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LichThiDauHomNay.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControlHigh.LichThiDauHomNay" %>

<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<%@ Register src="DuLieuBongDa.ascx" tagname="DuLieuBongDa" tagprefix="uc2" %>

<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<div class="tonghop-video">
            <div class="title-video">
                <ul class="nav-ketqua">
                    <li><a href="<%= UrlProcess.TheThaoHome() %>" class="active">Bóng đá »</a></li>
                    <li><a href="#"> Lịch thi đấu hôm nay</a></li>
                </ul>
                <div class="border-color">
                    <div></div>
                </div>
            </div>

            <asp:Repeater ID="rptCategory" runat="server" EnableViewState="false">
                <ItemTemplate>

                    <div class="boxcontent">
                        <div class="bold">
                            <asp:Literal ID="ltrGiaiDau" runat="server" EnableViewState="False"></asp:Literal>
                        </div>
                    </div>

                    <ul class="list-video-tonghop ketqua-thidau">
                        <asp:Repeater ID="rptLichThiDau" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <li>

                                    <a href="javascript:void(0)">
                                        <asp:Label ID="ltrGame" runat="server" EnableViewState="False"></asp:Label>
                                    </a>

                                    <span class="date-time">
                                        <asp:Literal ID="ltrTime" runat="server" EnableViewState="False"></asp:Literal>
                                    </span>

                                    <span>
                                        <asp:HyperLink ID="lnkTuVan" runat="server" EnableViewState="False" Text="Tu van"></asp:HyperLink>
                                        <%--&nbsp;|&nbsp;--%>
                                        <asp:HyperLink ID="lnkThongke" runat="server" EnableViewState="False" Text="Thong ke"></asp:HyperLink>
                                        <%--&nbsp;|&nbsp;--%>
                                        <asp:HyperLink ID="lnkKQCho" runat="server" EnableViewState="False" Text="KQ cho"></asp:HyperLink> 
                                    </span>     

                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>

                </ItemTemplate>
            </asp:Repeater>

            
            <%--<uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />--%>


        </div>

<div class="listlink" style="font-style:italic;">
    <asp:Literal ID="ltrGia" runat="server" EnableViewState="False"></asp:Literal>    
</div>

<uc2:DuLieuBongDa ID="DuLieuBongDa1" runat="server" EnableViewState="False" />  