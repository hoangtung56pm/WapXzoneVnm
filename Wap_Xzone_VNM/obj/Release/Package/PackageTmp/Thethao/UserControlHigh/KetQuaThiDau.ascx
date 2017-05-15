<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KetQuaThiDau.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControlHigh.KetQuaThiDau" %>

<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>
<%@ Register src="DuLieuBongDa.ascx" tagname="DuLieuBongDa" tagprefix="uc2" %>

<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<div class="tonghop-video">
            <div class="title-video">
                <ul class="nav-ketqua">
                    <li><a href="<%= UrlProcess.TheThaoHome() %>" class="active">Bóng đá »</a></li>
                    <li><a href="#"> Kết quả thi đấu</a></li>
                </ul>
                <div class="border-color">
                    <div></div>
                </div>
            </div>

           <%-- <asp:Repeater ID="rptCategory" runat="server" EnableViewState="false">
                <ItemTemplate>--%>

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
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>

                <%--</ItemTemplate>
            </asp:Repeater>--%>

            
            <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />


        </div>

<uc2:DuLieuBongDa ID="DuLieuBongDa1" runat="server" EnableViewState="False" />   