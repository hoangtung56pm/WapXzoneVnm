<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Hot.ascx.cs" Inherits="WapXzone_VNM.P3.UserControl.Hot" %>
<div id="pnVideoList">
    <div class="headline">
        <a href="#">Clip Hot 18+</a></div>
    <div class="a-list clear">
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <div class="a-item">
                    <div class="icon">
                        <a href="#">
                            <img alt="" src="<%# Eval("image") %>" align="middle" border="0" width="115">
                        </a>
                    </div>
                    <div class="title" style="margin-left: 135px">
                        <a href="<%# GetLinkDetail(Eval("id")) %>">
                            <%# Eval("name")%></a> <span>
                                <img alt="HOT" src="images/icon-hot.gif"></span><br>
                        <span>
                            <%# Eval("views")%>
                            lượt xem</span>
                        <br>
                        <span>Time
                            <%# Eval("time")%>
                        </span>
                        <br>
                        <span>
                            <img alt="" src="images/icon_streaming.gif">
                            <a href="<%# GetLinkDetail(Eval("id")) %>">Xem <span style="font-size: 11px; color: #FF0000;
                                font-style: italic;">(<%= WapXzone_VNM.Library.AppEnv.GetSetting("VideoPriceForP3")%>đ)</span></a> </span>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    <div style="height: 27px; position: relative; text-align: center;" class="bar1 row_last group_btn"
        id="pn_more">
        <a href="javascript:loadmore('btnxemthem','pnVideoList','/P3/morePlaylist.aspx?type=hot&amp;start=',5)"
            style="display: inline; margin-top: 67px; padding-top: 0px; width: 90px;" class="download_3 download_11"
            id="btnxemthem"><span>Xem thêm</span></a>
    </div>
</div>
