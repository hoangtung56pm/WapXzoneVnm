<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="KetQuaThiDauHomNay.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControlHigh.KetQuaThiDauHomNay" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<div class="tonghop-video">
            <div class="title-video">
                <ul class="nav-ketqua">
                    <li><a href="<%= UrlProcess.TheThaoHome() %>" class="active">Bóng đá »</a></li>
                    <li><a href="#"> Kết quả thi đấu hôm nay</a></li>
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
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>
                    </ul>
                </ItemTemplate>
            </asp:Repeater>

            



        </div>