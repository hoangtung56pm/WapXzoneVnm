<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ThongKeDacBiet.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControlHigh.ThongKeDacBiet" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<div class="tonghop-video">
            <div class="title-video">
                <ul class="nav-ketqua">
                    <li><a href="<%= UrlProcess.TheThaoHome() %>" class="active">Bóng đá »</a></li>
                    <li><a href="javascript:void(0)">Các giải đấu</a></li>
                </ul>
                <div class="border-color">
                    <div></div>
                </div>
            </div>
            <ul class="list-video-tonghop">

                <asp:Repeater ID="rptList" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <li>
                            <asp:HyperLink ID="lnkCatName" runat="server" EnableViewState="False"></asp:HyperLink>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>

            </ul>
        </div>