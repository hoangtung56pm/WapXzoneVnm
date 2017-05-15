<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.TinHot.UserControl.Detail" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="/TinHot/UserControl/Category.ascx" TagName="Category" TagPrefix="uc1" %>
<%@ Register Src="/TinHot/UserControl/Msisdn.ascx" TagName="Msisdn" TagPrefix="uc2" %>

<!-- Begin .wapper -->
<div class="wapper">
<div class="content">

    <uc2:Msisdn ID="Msisdn1" runat="server" EnableViewState="False" />

            <ul class="detail-gioitinh">
                <li><a href="<%= AppEnv.GetSetting("WapDefault") %>"><i class="icon-home"></i><span>Home</span></a></li>
                <li><a href="<%= UrlProcess.TinTucHome() %>"><i class="icon-caret-right"></i><span>Tin Tức</span></a></li>
                <li>
                    <a href="<%= UrlProcess.TinTucChuyenMuc(ConvertUtility.ToInt32(catID.ToString()),1,CatName) %>">
                        <i class="icon-caret-right"></i><span><%= CatName %></span>
                    </a>
                </li>
            </ul>

<!-- begin tin tuc -->
<div class="newsCat">
    <div class="newsCat-head">
        <h2><a href="<%= UrlProcess.TinTucChuyenMuc(ConvertUtility.ToInt32(catID.ToString()),1,CatName) %>"><%= CatName%></a></h2>
    </div>
    <div class="newsCat-content">

        <div class="news-detail">
            
             <h3><a href="javascript:void(0)"><%= DetailName %></a></h3>


            <asp:Panel ID="pnlContent" runat="server" Visible="false">
                 <ul class="news-lis">
                        
                        
                        <asp:Repeater ID="rptNewsCharging" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <li>
                                    <a href="<%# UrlProcess.TinTucChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID").ToString()),Eval("Content_Headline").ToString()) %>">
                                        <%# Eval("Content_Headline") %>
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>


                    </ul>

                <asp:Repeater ID="rptDetail" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <%# ReplaceImageLink(Eval("Content_Body").ToString())%>
                </ItemTemplate>
            </asp:Repeater>
            </asp:Panel>

            <asp:Panel ID="pnlNotContent" runat="server" Visible="false">
                <%--Bạn vui lòng lựa chọn kết nối EDGE hay 3G để sử dụng dịch vụ này. Lưu ý, hãy ngắt kết nối wifi bạn nhé--%>

                <asp:Literal ID="litNotContentError" runat="server" EnableViewState="false"></asp:Literal>

            </asp:Panel>

        </div>

        <div class="news-late">
            <h3>
                <a href="<%= UrlProcess.TinTucChuyenMuc(ConvertUtility.ToInt32(catID.ToString()),1,CatName) %>">Tin cùng chuyên mục</a>
            </h3>
            <ul class="news-lis">
                
                <asp:Repeater ID="rptOlderNews" runat="server">
                    <ItemTemplate>
                        <li>
                            <a href="<%# UrlProcess.TinTucChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID").ToString()),Eval("Content_Headline").ToString()) %>">
                                <%# Eval("Content_Headline")%>
                            </a>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>

            </ul>
        </div>
    </div>


    <!-- Begin chuyen muc -->
    <uc1:Category ID="Category1" runat="server" EnableViewState="False" />
    <!-- End chuyen muc -->

</div>
<!-- end tin tuc -->

</div>
</div>
<!-- End .wapper-->