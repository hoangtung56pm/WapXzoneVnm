<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.Hoangdao.UserControlHigh.List" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<%@ Register Src="Home.ascx" TagName="Home" TagPrefix="uc1" %>

<div class="box-thugian">
                <h4>
                    
                    <a href="<%= UrlProcess.HoangDaoHome() %>">Tử Vi</a> »
                    <asp:Label ID="lblCatetoryName" runat="server" EnableViewState="False"></asp:Label>

                </h4>
                <ul class="list-truyen">

                            <li>
                                <a href="<%= linkNgay %>">
                                    Hoàng đạo theo ngày
                                </a>
                            </li>

                            <li>
                                <a href="<%= linkTuan %>">
                                    Hoàng đạo theo tuần
                                </a>
                            </li>

                            <li>
                                <a href="<%= linkThang %>">
                                    Hoàng đạo theo tháng
                                </a>
                            </li>
                </ul>
            </div>

<%--<uc1:Home ID="Home1" runat="server" EnableViewState="False" />--%>