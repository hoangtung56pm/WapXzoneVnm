<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.GioiTinh.UserControl.Detail" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="/GioiTinh/UserControl/Category.ascx" TagName="Category" TagPrefix="uc1" %>
<%@ Register Src="/TinHot/UserControl/Msisdn.ascx" TagName="Msisdn" TagPrefix="uc2" %>

<!-- Begin .wapper -->
<div class="wapper">
    <!-- begin .content -->
    <div class="content">

        <uc2:Msisdn ID="Msisdn1" runat="server" EnableViewState="False" />

        <!-- begin detail gioi tinh -->
        <div class="newsCat">
            <ul class="detail-gioitinh">
               <li><a href="<%= AppEnv.GetSetting("WapDefault") %>"><i class="icon-home"></i><span>Home</span></a></li>
                <li><a href="<%= UrlProcess.GioiTinhHome() %>"><i class="icon-caret-right"></i><span>Giới tính</span></a></li>
                <li><a href="<%= UrlProcess.GioiTinhChuyenMuc(catID,1,catName) %>"><i class="icon-caret-right"></i><span><%= catName %></span></a></li>
            </ul>
            <div class="newsCat-head">
                <h2>
                    <a href="#">
                        <asp:Literal ID="litName" runat="server" EnableViewState="false"></asp:Literal>
                    </a>
                </h2>
            </div>
            <div class="newsCat-content">
                <div class="news-detail">

                    <asp:Panel ID="pnlContent" runat="server" EnableViewState="false" Visible="false">
                        <%--Content Here--%>
                        <p>
                            <asp:Literal ID="litContent" runat="server" EnableViewState="false"></asp:Literal>
                        </p>
                    </asp:Panel>

                    <asp:Panel ID="pnlContentError" runat="server" EnableViewState="false" Visible="false">
                        <%--Content Here--%>
                        <p>
                            <asp:Literal ID="litContentError" runat="server" EnableViewState="false"></asp:Literal>
                        </p>
                    </asp:Panel>

                    <%--<img class="center" src="/RadioStyle/Content/radio/img/img-news-detail.jpg" alt=""/>
                    <p>Một đám cháy quá lắm chỉ biến toàn Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ad alias consequatur corporis eligendi facilis, laborum magnam molestias quo rerum totam! Eos ipsa labore nostrum numquam quidem rem repellendus, saepe veritatis! Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ab accusamus aliquid aspernatur consectetur debitis, eligendi incidunt iure maiores, molestiae natus officiis rerum veniam, veritatis vero voluptates? Consectetur distinctio rem tempora. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Accusantium aliquid assumenda consequatur corporis dignissimos doloribus ducimus eaque eius incidunt ipsam itaque magnam maiores molestiae nesciunt, officia officiis provident reprehenderit velit? Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ab accusantium aliquam atque debitis dignissimos dolorem dolores ducimus esse, harum illo itaque laboriosam numquam quae repellendus similique tenetur veniam voluptate voluptatum! bộ một sản nghiệp thành tro tàn. Từ đống tro tàn đó vẫn có thể dễ dàng tạo nên một toà lâu đài tráng lệ. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Doloribus eius eveniet illo labore laborum maiores nulla totam. Aut consectetur, eaque error hic illum, incidunt, minima optio quod quos ratione velit. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Est eum fuga harum id labore natus odit praesentium quasi quia repellendus soluta unde, vel velit vero voluptatum. Architecto dicta fugiat sunt?</p>
                    <img class="center" src="/RadioStyle/Content/radio/img/img-news-detail.jpg" alt=""/>
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Consequatur debitis facere totam veniam. Debitis ipsum, itaque laudantium nisi nulla quod reiciendis repellendus repudiandae, rerum soluta, veniam voluptas? Corporis iste, suscipit. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Doloribus, fugit sapiente! Alias autem enim ex expedita fuga fugiat harum ipsam maiores natus nihil perspiciatis, similique unde, vel, veniam vero vitae? Lorem ipsum dolor sit amet, consectetur adipisicing elit. Architecto distinctio dolores dolorum ea, eaque fuga illo in, ipsam iusto perspiciatis placeat porro provident, quod sunt vitae! Amet eaque enim iure.</p>--%>
                </div>

                <!-- begin Co the ban thich -->
                <div class="news-late">
                    <h3><a href="<%= UrlProcess.GioiTinhChuyenMuc(catID,1,catName) %>">Có thể bạn thích</a></h3>
                    <ul class="news-lis">
                        
                        <asp:Repeater ID="rptTop" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <li>
                                    <a href="<%# UrlProcess.GioiTinhChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID").ToString()),Eval("Content_Headline").ToString()) %>">
                                        <%# Eval("Content_Headline") %>
                                    </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
                <!-- end co the ban thich -->

                <!-- begin tin cung chuyen muc-->
                <div class="news-late">
                    <h3><a href="<%= UrlProcess.GioiTinhChuyenMuc(catID,1,catName) %>">Tin cùng chuyên mục</a></h3>
                    <ul class="news-lis">
                        
                        <asp:Repeater ID="rptBottom" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <li>
                                    <a href="<%# UrlProcess.GioiTinhChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID").ToString()),Eval("Content_Headline").ToString()) %>">
                                        <%# Eval("Content_Headline") %>
                                     </a>
                                </li>
                            </ItemTemplate>
                        </asp:Repeater>

                    </ul>
                </div>
                <!-- end tin cung chuyen muc-->

                <a class="newsCat-more" href="<%= UrlProcess.GioiTinhChuyenMuc(catID,1,catName) %>" title="Xem thêm">Xem thêm</a>

            </div>
        </div>
        <!-- end detail gioi tinh -->

       <uc1:Category ID="Category1" runat="server" EnableViewState="False" />

    </div>
    <!-- end .content-->
</div>
<!-- End .wapper-->
