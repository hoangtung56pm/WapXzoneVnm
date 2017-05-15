<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="YoutubeList.ascx.cs" Inherits="WapXzone_VNM.Video.UserControl.YoutubeList" %>

<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>


<div class="div1">    
	<div>
         <a class="link-non-black logo-vnm" href="#">
            PHIM HOT
        </a>
    </div>
</div>

<div class="boxcontent">
    
    <asp:Repeater ID="rptList" runat="server" EnableViewState="False">
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
    
    <uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />

</div>