<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YoutubePhim.ascx.cs" Inherits="WapXzone_VNM.Video.UserControl.YoutubePhim" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>



<div class="div1">    
	<div>
         <a class="link-non-black logo-vnm" href="<%= UrlProcess.GetVideoCategoryUrlYoutube(lang.ToString(),width) %>">
            PHIM HOT
        </a>
    </div>
</div>

<div class="boxcontent">
    
    <asp:Repeater ID="rptHottest" runat="server" EnableViewState="False">
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
