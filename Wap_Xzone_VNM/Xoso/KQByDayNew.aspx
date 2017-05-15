<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KQByDayNew.aspx.cs" Inherits="WapXzone_VNM.Xoso.KQByDayNew" %>

<%@ Register Src="../Wap/UserControlNew/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="../Wap/UserControlNew/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="../Wap/UserControlNew/TimKiem.ascx" TagName="TimKiem" TagPrefix="uc3" %>

<%@ Register Src="../Game/UserControlNew/TruyCapNhanh.ascx" TagName="TruyCapNhanh"
    TagPrefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>.: Wap Vietnamobile - Xo so - Soi cau :.</title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server" EnableViewState="False"></asp:Literal>
    <style media="screen" type="text/css">
        @import "../css/mainnew.css";
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <%--Header--%>
    <uc1:Header ID="Header1" runat="server" EnableViewState="False" />
    <uc3:TimKiem ID="TimKiem1" runat="server" EnableViewState="False" />
    <%--End Header--%>
    <%--Content--%>
          <asp:Panel ID="pnlSMS" runat="server" Visible="false">
        <div class="rbroundbox">
	        <div class="rbtop"><div><asp:Literal ID="ltrHuongdan" runat="server">HƯỚNG DẪN</asp:Literal></div></div>
        </div>
        <div style="text-align: center;" class="boxcontent">
	        <p><asp:Literal ID="ltrSMS" runat="server">Soạn tin nhắn theo cú pháp</asp:Literal></p>            
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlThongBao" runat="server" Visible="false">
        <div class="rbroundbox">
	        <div class="rbtop"><div><asp:Literal ID="ltrTitle" runat="server">THÔNG BÁO</asp:Literal></div></div>
        </div>
        <div style="text-align: center;" class="boxcontent">
	        <p><asp:Literal ID="ltrThongBao" runat="server">THÔNG BÁO</asp:Literal></p>
            <asp:Button ID="btnCo" runat="server" onclick="btnCo_Click" /> 
            <asp:Button ID="btnKhong" runat="server" onclick="btnKhong_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlNoiDung" runat="server" Visible="false">
        <div class="rbroundbox">
	        <div class="rbtop"><div><asp:Literal ID="ltrTieuDe" runat="server">NỘI DUNG</asp:Literal></div></div>
        </div>
        <div class="boxcontent">
            <asp:Label ID="lblTen" runat="server" CssClass="blue bold"></asp:Label>
	        <p><asp:Literal ID="ltrNoiDung" runat="server"></asp:Literal></p>
	        <div id="detail" runat="server">
                <div id="g1" class="itemlist" runat="server">
                    <p><asp:Label ID="lbldb6" runat="server" CssClass="blue bold">Dac Biet DB6</asp:Label>                    
                    <asp:Literal ID="ltrgdb6" runat="server"></asp:Literal></p>
                </div>
                <div class="itemlist">
                    <p><asp:Label ID="lbldb" runat="server" CssClass="blue bold">Dac Biet</asp:Label>                    
                    <asp:Literal ID="ltrdb" runat="server"></asp:Literal></p>
                </div>
                <div class="itemlist">
                    <p><asp:Label ID="lblg1" runat="server" CssClass="blue bold">Nhat</asp:Label>                    
                    <asp:Literal ID="ltrg1" runat="server"></asp:Literal></p>
                </div>
                <div class="itemlist">
                    <p><asp:Label ID="lblg2" runat="server" CssClass="blue bold">Nhi</asp:Label>
                    <asp:Literal ID="ltrg2" runat="server"></asp:Literal></p>
                </div>
                <div class="itemlist">
                    <p><asp:Label ID="lblg3" runat="server" CssClass="blue bold">Ba</asp:Label>
                    <asp:Literal ID="ltrg3" runat="server"></asp:Literal></p>
                </div>
                <div class="itemlist">
                    <p><asp:Label ID="lblg4" runat="server" CssClass="blue bold">Tu</asp:Label>
                    <asp:Literal ID="ltrg4" runat="server"></asp:Literal></p>
                </div>
                <div class="itemlist">
                    <p><asp:Label ID="lblg5" runat="server" CssClass="blue bold">Nam</asp:Label>
                    <asp:Literal ID="ltrg5" runat="server"></asp:Literal></p>
                </div>
                <div class="itemlist">
                    <p><asp:Label ID="lblg6" runat="server" CssClass="blue bold">Sau</asp:Label>
                    <asp:Literal ID="ltrg6" runat="server"></asp:Literal></p>
                </div>
                <div class="itemlist">
                    <p><asp:Label ID="lblg7" runat="server" CssClass="blue bold">Bay</asp:Label>
                    <asp:Literal ID="ltrg7" runat="server"></asp:Literal></p>
                </div>
                <div id="g8" runat="server" class="itemlist">
                    <p><asp:Label ID="lblg8" runat="server" CssClass="blue bold">Tam</asp:Label>
                    <asp:Literal ID="ltrg8" runat="server"></asp:Literal></p>
                </div>
            </div>
        </div>
        <%--<div class="rbroundbox">
            <div class="rbtop"><div><asp:Label ID="lblOthersService" runat="server">CAC DICH VU</asp:Label></div></div>
        </div>
        <div class="boxcontent">            
            <div class="item">
                ♥
                <div class="item-info">
                    <asp:HyperLink ID="lnksoicau" runat="server">Soi cau</asp:HyperLink>                      
                </div>
                <div class="clearfix"></div>
            </div>
            <div class="item">
                ♥
                <div class="item-info">
                    <asp:HyperLink ID="lnktructiep" runat="server">Ket qua truc tiep</asp:HyperLink>                     
                </div>
                <div class="clearfix"></div>
            </div>
            <div class="item">
                ♥
                <div class="item-info">
                    <asp:HyperLink ID="lnk20day" runat="server">Ket qua 30 ngay lien tiep</asp:HyperLink>
                </div>
                <div class="clearfix"></div>
            </div>--%>
        </div>
       <%-- <div class="rbroundbox">
	        <div class="rbtop"><div><asp:Literal ID="lblOther" runat="server">XEM TIEP</asp:Literal></div></div>
        </div>
        <div class="boxcontent">
            <asp:Repeater ID="rptOther" runat="server">
                <ItemTemplate>
                <div class="listlink">
                    <p>♥ <asp:HyperLink ID="lnkother" NavigateUrl="#" runat="server"></asp:HyperLink></p>
                </div>
                </ItemTemplate>  
            </asp:Repeater>
        </div>--%>
    </asp:Panel>
    <%--End Content--%>

    <uc5:TruyCapNhanh ID="TruyCapNhanh1" runat="server" EnableViewState="False" />
    <%--Footer--%>
    <uc2:Footer ID="Footer1" runat="server" EnableViewState="False" />
    <%--End Footer--%>

    <img src="<%= "../" + GoogleAnalyticsGetImageUrl() %>" />

    </form>
</body>
</html>
