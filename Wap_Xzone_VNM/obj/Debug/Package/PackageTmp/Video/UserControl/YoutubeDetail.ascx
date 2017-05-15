<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YoutubeDetail.ascx.cs" Inherits="WapXzone_VNM.Video.UserControl.YoutubeDetail" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<div class="rbroundbox">
	<div class="rbtop"><div><asp:HyperLink ID="lnkHomeChannel" runat="server" EnableViewState="False">VIDEO</asp:HyperLink> » <asp:HyperLink ID="lnkCateChannel" runat="server" EnableViewState="False"></asp:HyperLink></div></div>
</div>
<div class="boxcontent">
    <div class="item">
        
        <asp:Repeater runat="server" ID="rptDetail">
            <ItemTemplate>
                <div id='jwplayer-1'></div>

                <script src="/jwplayer/jwplayer.js"></script>
                <script type="text/javascript">jwplayer.key = "5qMQ1qMprX8KZ79H695ZPnH4X4zDHiI0rCXt1g==";</script>
                                    
                <script type="text/javascript">
                    jwplayer('jwplayer-1').setup({
                        "flashplayer": '/jwplayer/jwplayer.flash.swf',
                        "file": '<%# Eval("Video_Url") %>',
                        "width": '98%',
                        "height": '336',
                        "autostart": 'true',
                        "primary": 'html5',
                        "repeat": true,
                        "autoplay": 'true',
                        "startparam": 'start',
                        'controlbar.idlehide': 'false',
                        'image': '',
                        'abouttext': 'Wap Vietnamobile.com.vn',
                        'aboutlink': 'http://wap.vietnamobile.com.vn',
                    });
                </script>

        <br/>
        <h1 style="font-size:10px;">
            <%# Eval("Title")%>
        </h1>
        
        <div class="clearfix"></div>
            </ItemTemplate>
        </asp:Repeater>

    </div>
</div>


<div class="clearfix"></div>
<div class="rbroundbox">
	<div class="rbtop"><div><asp:Literal ID="ltrCungTheLoai" runat="server" EnableViewState="False">PHIM KHÁC</asp:Literal></div></div>
</div>
<div class="boxcontent">
    <asp:Repeater ID="rptCungTheLoai" runat="server" EnableViewState="False">
        <ItemTemplate>            
            
            <div class="item">
                <a href="<%# UrlProcess.GetVideoDetailUrlYoutube(lang.ToString(),width,Eval("Id").ToString()) %>" class="thumb-b">
                    <img style="width:60px;border-width:0px;" src="<%# AppEnv.GetSetting("urldata") + Eval("Avatar").ToString().Replace("~/Upload","/Upload") %>"/>
                </a>
                <div class="item-info">
                    <a href="<%# UrlProcess.GetVideoDetailUrlYoutube(lang.ToString(),width,Eval("Id").ToString()) %>">
                        <span class="bold">
                            <%# Eval("Title")%>
                        </span>
                    </a>
                    <p>Thể loại: Phim hot</p>
                    <p></p>
                    
                    <a href="<%# UrlProcess.GetVideoDetailUrlYoutube(lang.ToString(),width,Eval("Id").ToString()) %>">
                        <span class="orange bold">Xem</span>
                    </a>

                </div>
                <div class="clearfix"></div>
            </div>
                     
        </ItemTemplate>        
    </asp:Repeater>
    
</div>