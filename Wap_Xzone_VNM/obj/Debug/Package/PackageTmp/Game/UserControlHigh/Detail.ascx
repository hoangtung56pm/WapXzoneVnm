<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.Game.UserControlHigh.Detail" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>
        
        <%@ Register Src="Category.ascx" TagName="Category1" TagPrefix="uc1" %>

        <asp:Repeater ID="rptDetail" runat="server" OnItemCommand="rptDetail_ItemCommand" >
            <ItemTemplate>
                <div class="game-detail">

                    <div class="thumbnail-game">
                        <img src="<%# AppEnv.GetAvatar(Eval("Avatar").ToString(),75,74) %>" alt=""/>
                    </div>

                    <div class="info-game">
                        <h5><%# Eval("GameNameUnicode")%></h5>
                        <%--<span>Gamefoft</span>--%>
                        <span><%# Eval("Title_Unicode")%></span>
                        <div>
                            <a class="btn-price-game" href="javascript:void(0)"><%= price %>đ</a>
                            <%--<a class="btn-download-game" href="<%# UrlProcess.GameDownload(ConvertUtility.ToInt32(Eval("W_GameItemID"))) %>">Download</a>--%>
                             <asp:LinkButton CssClass="btn-download-game" runat="server" CommandName="download" CommandArgument='<%# Eval("W_GameItemID") %>'
                Text="Download"/>
                            <%--<asp:Button ID="btnEdit" runat="server" CommandName="Confirm" Text="Test" />--%>
                            <%--<asp:LinkButton runat="server" ID="lnk_Download" class="btn-download-game">Download</asp:LinkButton>--%>
                        </div>
                    </div>

                </div>
            </ItemTemplate>
        </asp:Repeater>

        <!-- Nav tabs -->
        <ul class="nav nav-tabs nav-detail-game" id="nav-game">
            <li class="active"><a href="#detail-game" data-toggle="tab">Chi tiết game</a></li>
            <%--<li><a href="#comment-game" data-toggle="tab">Đánh giá game</a></li>--%>
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
                            <%--<p>Terraria, bản Sandbox adventure bán chạy nhất theo phong cách Minecraft đã có cho Androi. Với các yếu tố nhập vai, Terraria là game có giá trị sống vĩnh viễn cuối cùng đã có mặt và được thiết kế riêng cho di động.</p>
                            <p>Kết hợp hoàn hảo các thể loại</p>
                            <p>Terraria gồm nhiều thể loại: Hành động, kiến trúc, nhập vai… Các trò chơi phong phú và bạn sẽ tốn nhiều giờ để thành thạo. Luật chơi rất đơn giản: Bạn tạo nhân vật (với vô số các tùy chọn) sẽ xuất hiện tình cờ ở 1 thế giới ngẫu nhiên, người bạn duy nhất của bạn là hướng dẫn viên sẽ giúp bạn tồn tại trong thế giới nguy hiểm đó. Bạn được tự xây nhà, chế dụng cụ và đào đất để kiếm nguyên liệu hay đánh quái. Khác với Minecraft, chú trọng nhiều hơn tới hành động trên mặt đất và các khu vực bí mật.</p>--%>

                            <p>
                                <%# Eval("DescriptionUnicode")%>
                            </p>

                        </div>

                    </ItemTemplate>
                </asp:Repeater>

            </div>

            <%--<div class="tab-pane" id="comment-game">
                <div class="input-comment-game">
                    <a href="#">Đăng nhập để đánh giá</a> <img src="/Content/asset/Images/sao.png" alt="" style="width: auto"/> <br/>
                    <input type="text" placeholder="Tiêu đề"/>
                    <textarea placeholder="Nội dung đánh giá"></textarea>
                    <div class="btn-send-comment">
                        <input class="" type="button" value="Gửi đánh giá"/>
                    </div>
                </div>
                <ul class="list-comment">
                    <li><h5 class="total-comment">30 đánh giá</h5></li>
                    <li>
                        <span class="name">corgipie</span>
                        <p class="comment">Đúng là quá nhiều game hay mà lại miễn phí rất tốt</p>
                    </li>
                    <li>
                        <span class="name">corgipie</span>
                        <p class="comment">Đúng là quá nhiều game hay mà lại miễn phí rất tốt</p>
                    </li>
                    <li>
                        <span class="name">corgipie</span>
                        <p class="comment">Đúng là quá nhiều game hay mà lại miễn phí rất tốt</p>
                    </li>
                    <li>
                        <span class="name">corgipie</span>
                        <p class="comment">Đúng là quá nhiều game hay mà lại miễn phí rất tốt</p>
                    </li>
                    <li>
                        <span class="name">corgipie</span>
                        <p class="comment">Đúng là quá nhiều game hay mà lại miễn phí rất tốt</p>
                    </li>
                    <li>
                        <span class="name">corgipie</span>
                        <p class="comment">Đúng là quá nhiều game hay mà lại miễn phí rất tốt</p>
                    </li>
                    <li>
                        <span class="name">corgipie</span>
                        <p class="comment">Đúng là quá nhiều game hay mà lại miễn phí rất tốt</p>
                    </li>
                    <li>
                        <span class="name">corgipie</span>
                        <p class="comment">Đúng là quá nhiều game hay mà lại miễn phí rất tốt</p>
                    </li>
                </ul>

            </div>--%>

        </div>

        <ul class="nav nav-tabs nav-detail-game">
            <li class="active"><a href="javascript:">Game liên quan</a></li>
        </ul>
        <div class="list-game">

            <asp:Repeater ID="rptList" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                        <div class="border">
                            <a href="<%# UrlProcess.GameChiTiet(ConvertUtility.ToInt32(Eval("W_GameItemID")),Eval("GameName").ToString()) %>">
                                <img class="img-radius" alt="" src="<%# AppEnv.GetAvatar(Eval("Avatar").ToString(),75,74) %>">
                            </a>
                            &nbsp;&nbsp;<p class="name">
                                <%# AppEnv.TrimLength(Eval("GameNameUnicode").ToString(), 15)%>
                            </p>
                            <p class="price"><%= price %>đ</p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

        </div>


        <uc1:Category1 ID="Category1" runat="server" EnableViewState="False" />