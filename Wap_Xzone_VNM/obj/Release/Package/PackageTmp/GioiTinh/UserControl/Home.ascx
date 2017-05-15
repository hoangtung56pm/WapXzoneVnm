<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="WapXzone_VNM.GioiTinh.UserControl.Home" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="/GioiTinh/UserControl/Category.ascx" TagName="Category" TagPrefix="uc1" %>
<%@ Register Src="/TinHot/UserControl/Msisdn.ascx" TagName="Msisdn" TagPrefix="uc2" %>

<!-- Begin .wapper -->
<div class="wapper">
<div class="content">

<uc2:Msisdn ID="Msisdn1" runat="server" EnableViewState="False" />

<ul class="detail-gioitinh">
                <li><a href="<%= AppEnv.GetSetting("WapDefault") %>"><i class="icon-home"></i><span>Home</span></a></li>
                <li><a href="<%= UrlProcess.GioiTinhHome() %>"><i class="icon-caret-right"></i><span>Giới tính</span></a></li>
            </ul>

<!-- begin tin tuc -->
<div class="newsCat">

    <!-- Begin chuyen muc -->
    <div class="gioitinh-head">
        <h2 class="active"><a href="#" title="Tin hot">Mới nhất</a></h2>
        <%--<h2><a href="#" title="Tin hot">Hay nhất</a></h2>--%>
    </div>

    <div class="newsCat-content">
            
            <asp:Repeater ID="rptTop" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="gioi-tinh">
                <a href="<%# UrlProcess.GioiTinhChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID")),Eval("Content_Headline").ToString()) %>">
                    <img src="<%# AppEnv.GetAvatarByPath(Eval("Content_Avatar").ToString(),125,94) %>" alt=""/>
                </a>
                <div class="info-gioitinh">
                    <h3>
                        <a href="<%# UrlProcess.GioiTinhChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID")),Eval("Content_Headline").ToString()) %>">
                            <%# Eval("Content_Headline")%>
                        </a>
                    </h3>
                    <div>Lượt xem: <%# Eval("Distribution_View")%></div>
                    <div><%# ConvertUtility.ToDateTime(Eval("Content_CreateDate").ToString()).ToString("dd/MM hh:mm")%></div>
                </div>
            </div>
                </ItemTemplate>
            </asp:Repeater>


        <div class="news-late">

            <h3><a href="#">Tin cùng chuyên mục</a></h3>

            <ul class="news-lis">
                
                <asp:Repeater ID="rptBottom" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <li>
                            <a href="<%# UrlProcess.GioiTinhChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID")),Eval("Content_Headline").ToString()) %>">
                                <%# Eval("Content_Headline") %>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>

            </ul>

        </div>
    </div>
    <!-- End chuyen muc -->
</div>
<!-- end tin tuc -->


    <uc1:Category ID="Category1" runat="server" EnableViewState="False" />

</div>
</div>
<!-- End .wapper-->