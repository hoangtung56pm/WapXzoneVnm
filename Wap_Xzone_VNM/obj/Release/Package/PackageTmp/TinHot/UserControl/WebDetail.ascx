<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebDetail.ascx.cs" Inherits="WapXzone_VNM.TinHot.UserControl.WebDetail" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%--<%@ Register Src="/TinHot/UserControl/Category.ascx" TagName="Category" TagPrefix="uc1" %>
<%@ Register Src="/TinHot/UserControl/Msisdn.ascx" TagName="Msisdn" TagPrefix="uc2" %>--%>

<!-- Begin .wapper -->
<div class="wapper">
<div class="content">

    <%--<uc2:Msisdn ID="Msisdn1" runat="server" EnableViewState="False" />--%>

            <ul class="detail-gioitinh">
                <li><a href="<%= AppEnv.GetSetting("WapDefault") %>"><i class="icon-home"></i><span>Home</span></a></li>
                <%--<li><a href="<%= UrlProcess.TinTucHome() %>"><i class="icon-caret-right"></i><span>Tin Tức</span></a></li>
                <li>
                    <a href="<%= UrlProcess.TinTucChuyenMuc(ConvertUtility.ToInt32(catID.ToString()),1,CatName) %>">
                        <i class="icon-caret-right"></i><span><%= CatName %></span>
                    </a>
                </li>--%>
            </ul>

<!-- begin tin tuc -->
<div class="newsCat">
    <div class="newsCat-head">
        <h2>
            <a href="<%= UrlProcess.WebTinTucChuyenMuc(catID.ToString(),CatName) %>">
                <%= CatName %>
            </a>
        </h2>
    </div>
    <div class="newsCat-content">

        <div class="news-detail">
            
             <h3><a href="javascript:void(0)"><%= DetailName %></a></h3>


            <asp:Panel ID="pnlContent" runat="server" Visible="true">
                <asp:Repeater ID="rptDetail" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <%# Eval("Content").ToString() %>
                    </ItemTemplate>
                </asp:Repeater>
            </asp:Panel>

        </div>

    </div>


    <!-- Begin chuyen muc -->
    <%--<uc1:Category ID="Category1" runat="server" EnableViewState="False" />--%>
    <!-- End chuyen muc -->

</div>
<!-- end tin tuc -->

</div>
</div>
<!-- End .wapper-->