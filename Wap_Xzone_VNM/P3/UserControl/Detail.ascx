<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.P3.UserControl.Detail" %>
<div class="clear" id="content" itemprop="video" itemscope="" itemtype="http://schema.org/VideoObject">
    <div class="subline" itemprop="name">
        <%= title %></div>
    <meta itemprop="thumbnail" content="<%= image %>">
    <meta itemprop="contentURL" content="<%= link %>">
    <div class="a-detail clear">
        <table border="0" cellpadding="0" cellspacing="0">
            <tbody>
                <tr id="trConfirm" runat="server" visible="false">
                    <td>
                        <div style="text-align: center; width:300px;">
                            <p>
                                <asp:Literal ID="ltrThongBao" runat="server"></asp:Literal></p>
                            <br />
                            <asp:Button ID="btnOK" Text="Đồng ý" runat="server" OnClick="btnOK_Click" />
                            <asp:Button ID="btnKhong" Text="Hủy bỏ" runat="server" OnClick="btnKhong_Click" /><br />
                        </div>
                    </td>
                </tr>
                <tr valign="top" id="trContent" runat="server" visible="false">
                    <td class="left">
                        <img src="<%= image %>" width="115">
                    </td>
                    <td class="right">
                        <p>
                            Thời gian:
                            <%= time %></p>
                        <p>
                            Xem,Tải:
                            <%= view %></p>
                        <p>
                            <asp:HyperLink ID="hplTai" runat="server" Text="Click vào link để xem" ForeColor="Blue"></asp:HyperLink>
                        </p>
                        <p>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td height="10px">
                        <p>
                        </p>
                    </td>
                </tr>
            </tbody>
        </table>
    </div>
    <div class="headline">
        Có thể bạn quan tâm</div>
    <div class="a-list clear">
        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <div class="a-item">
                    <div class="icon">
                        <a href="#">
                            <img alt="" src="<%# Eval("image") %>" align="middle" border="0" width="115">
                        </a>&nbsp;</div>
                    <div class="title" style="margin-left: 135px">
                        <a href="<%# GetLinkDetail(Eval("id")) %>">
                            <%# Eval("name") %></a> <span>
                                <img alt="HOT" src="images/icon-hot.gif"></span><br />
                        <span>Thời gian:
                            <%# Eval("time")%>
                        </span>
                        <br />
                        <span>
                            <%# Eval("views")%>
                            lượt xem/tải </span>
                        <br />
                        <span>
                            <img alt="" src="images/icon_streaming.gif">
                            <a href="<%# GetLinkDetail(Eval("id")) %>">Xem <span style="font-size: 11px; color: #FF0000;
                                font-style: italic;">(<%= WapXzone_VNM.Library.AppEnv.GetSetting("VideoPriceForP3")%>đ)</span></a> </span>&nbsp;</div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
