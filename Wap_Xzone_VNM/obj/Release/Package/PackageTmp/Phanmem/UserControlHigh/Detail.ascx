<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.Phanmem.UserControlHigh.Detail" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>
        
       <asp:Repeater ID="rptDetail" runat="server" EnableViewState="false">
            <ItemTemplate>
                <div class="game-detail">

                    <div class="thumbnail-game">
                        <img src="<%# AppEnv.GetAvatar(Eval("Avatar").ToString(),75,74) %>" alt=""/>
                    </div>

                    <div class="info-game">
                        <h5><%# Eval("AppNameUnicode")%></h5>
                        <%--<span>Gamefoft</span>--%>
                        <span><%# Eval("Title_Unicode")%></span>
                        <div>
                            <a class="btn-price-game" href="javascript:void(0)"><%= price %>đ</a>
                            <a class="btn-download-game" href="<%# UrlProcess.PhanMemDowload(Eval("W_AppItemID").ToString()) %>">Download</a>
                        </div>
                    </div>

                </div>
            </ItemTemplate>
        </asp:Repeater>

        <!-- Nav tabs -->
        <ul class="nav nav-tabs nav-detail-game" id="nav-game">
            <li class="active"><a href="#detail-game" data-toggle="tab">Chi tiết phần mềm</a></li>
            <%--<li><a href="#comment-game" data-toggle="tab">Đánh giá phần mềm</a></li>--%>
        </ul>

        <!-- Tab panes -->
        <div class="tab-content tab-content-game">

            <div class="tab-pane active" id="detail-game">
               
               <asp:Repeater ID="rptDes" runat="server" EnableViewState="false">
                    <ItemTemplate>

                         <div class="swiper-container-custom swiper-container banners-container border-gradient">
                            <div class="swiper-wrapper">

                            <div class="swiper-slide">
                            <img  src="<%# AppEnv.GetAvatar(Eval("Avatar").ToString(),221,165) %>" alt=""/>
                        </div>

                            </div>
                        </div>

                         <div class="content-game-detail">
                            <p>
                                <%# Eval("DescriptionUnicode")%>
                            </p>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>

            </div>

        </div>

        <ul class="nav nav-tabs nav-detail-game">
            <li class="active"><a href="javascript:">Phần mềm liên quan</a></li>
        </ul>

        <div class="list-game">

           <asp:Repeater ID="rptList" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                        <div class="border">
                            <a href="<%# UrlProcess.PhanMemChiTiet(ConvertUtility.ToInt32(Eval("W_AppItemID")),Eval("AppName").ToString()) %>">
                                <img class="img-radius" alt="" src="<%# AppEnv.GetAvatar(Eval("Avatar").ToString(),75,74) %>">
                            </a>
                            <p class="phanmem-height">
                                <%# AppEnv.TrimLength(Eval("AppNameUnicode").ToString(), 30)%>
                            </p>
                            <p class="price"><%= price %>đ</p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>