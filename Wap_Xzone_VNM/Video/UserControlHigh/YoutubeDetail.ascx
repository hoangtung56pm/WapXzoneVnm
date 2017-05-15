<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YoutubeDetail.ascx.cs" Inherits="WapXzone_VNM.Video.UserControlHigh.YoutubeDetail" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.Constant" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register src="Search.ascx" tagname="Search" tagprefix="uc2" %>

<uc2:Search ID="Search" EnableViewState="True" runat="server" />

<asp:Repeater ID="rptDetail" runat="server" EnableViewState="false">
            <ItemTemplate>
                <div class="video-play">
                    <h4><%# Eval("Title")%></h4>

                   <%-- <a href="#">
                        <img src="<%# AppEnv.GetSetting("urldata") + Eval("VThumnail").ToString().Replace("~/Upload","/Upload") %>" alt=""/>
                    </a>--%>
                    
                    <div id='jwplayer-1'></div>
                    
                
                    
                
                <%--<link rel="media" href="/jwplayer/jwplayer.flash.swf"/>--%>
                        
                <script src="/jwplayer/jwplayer.js"></script>
                <script type="text/javascript">jwplayer.key = "5qMQ1qMprX8KZ79H695ZPnH4X4zDHiI0rCXt1g==";</script>
                                    
                <script type="text/javascript">
                    jwplayer('jwplayer-1').setup({
                    
                        "flashplayer": '/jwplayer/jwplayer.flash.swf',

                    "file": '<%# Eval("Video_Url") %>',
                    "width": '98%',
                    "height": '336',
                    "autostart": 'true',
                    "primary": 'html5',  //"html5"
                    "repeat": true,
                    "autoplay": 'true',
                    "startparam": 'start',
                    //skin: "bekle",
                    'controlbar.idlehide': 'false',
                    'image': '',
                    'abouttext': 'Wap Vietnamobile.com.vn',
                    'aboutlink': 'http://wap.vietnamobile.com.vn',
                });
                </script>

                </div>
            </ItemTemplate>

            <%--<FooterTemplate>
                <p>
                        
                        <a href="<%= UrlProcess.VideoView(id) %>">
                            <span class="bold">Xem trực tuyến</span>
                         </a>

                        <a href="<%= UrlProcess.VideoDownload(id) %>">
                            <span class="bold">Tải về</span>
                        </a>

                 </p>
            </FooterTemplate>--%>

        </asp:Repeater>

        <div class="category-video">
            <div class="title-video">
                <span>PHIM KHÁC</span>
                <div class="border-color">
                    <div></div>
                </div>
            </div>
            <div class="video-download">

                <asp:Repeater ID="rptList" runat="server" EnableViewState="false">
                    <ItemTemplate>
                        <div class="item">
                            <a href="<%# UrlProcess.YoutubeChiTiet(ConvertUtility.ToInt32(Eval("Id")),Eval("Title_Kd").ToString()) %>" class="thumbnail-video">
                                <img width="140" src="<%# AppEnv.GetSetting("urldata") + Eval("Avatar").ToString().Replace("~/Upload","/Upload") %>" alt=""/>
                            </a>
                            <p class="description">
                                <a href="<%# UrlProcess.YoutubeChiTiet(ConvertUtility.ToInt32(Eval("Id")),Eval("Title_Kd").ToString()) %>">
                                    <%# Eval("Title")%>
                                </a>
                            </p>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>

            </div>
            <div class="view-all">
                <a href="<%= UrlProcess.YoutubeChuyenMuc(1,Constant.YoutubeFilmRewriteCatName) %>">
                    <img src="/Content/asset/Images/btn-view-all.png" alt=""/>
                </a>
            </div>
        </div>
<p>
    
