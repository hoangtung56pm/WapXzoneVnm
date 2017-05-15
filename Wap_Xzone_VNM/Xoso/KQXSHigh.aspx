<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="KQXSHigh.aspx.cs" Inherits="WapXzone_VNM.Xoso.KQXSHigh" %>

<%@ Register src="/Wap/UserControlHigh/Footer.ascx" tagname="Footer" tagprefix="uc1" %>
<%@ Register src="/Wap/UserControlHigh/Header.ascx" tagname="Header" tagprefix="uc2" %>
<%@ Register src="/Wap/UserControlHigh/Menu.ascx" tagname="Menu" tagprefix="uc3" %>
<%@ Register src="/Wap/UserControlHigh/Filter.ascx" tagname="Filter" tagprefix="uc4" %>

<%@ Register src="/XoSo/UserControlHigh/Category.ascx" tagname="Category" tagprefix="uc5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>.: Vietnamobile - Xo So :.</title>
    <link rel="stylesheet" href="/Content/asset/Plugin/bootstrap-3.0.3/dist/css/bootstrap.min.css"/>
    <link rel="stylesheet" href="/Content/asset/Plugin/mmenu/css/jquery.mmenu.all.css"/>
    <link rel="stylesheet" href="/Content/asset/Css/style.css"/>
    <script type="text/javascript" src="/Content/asset/Javascript/jquery.min.js"></script>
    <%--<script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.hammer.min.js"></script>--%>
    <script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.mmenu.min.all.js"></script>
    <script type="text/javascript" src="/Content/asset/Javascript/app.js"></script>

</head>
<body>
    
    <uc3:Menu ID="Menu1" runat="server" EnableViewState="true" />   

<div class="wrapper">

    <!--begin header-->
    <uc2:Header ID="Header1" runat="server" EnableViewState="true" />   

    <!--begin body-->
    <div class="body">

        <%--<form id="form1" runat="server">
            <asp:PlaceHolder runat="server" EnableViewState="true" ID="plContent"></asp:PlaceHolder>
       </form>--%>

       <%--Content here--%>
    <asp:Panel ID="pnlSMS" runat="server" Visible="false">
        <div class="rbroundbox">
	        <div class="rbtop">
                <div class="download-style">
                    <asp:Literal ID="ltrHuongdan" runat="server">HƯỚNG DẪN</asp:Literal>
                </div>
            </div>
        </div>
        <div style="text-align: center;" class="boxcontent">
	        <p><asp:Literal ID="ltrSMS" runat="server">Soạn tin nhắn theo cú pháp</asp:Literal></p>            
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlThongBao" runat="server" Visible="false">
        <div class="rbroundbox">
	        <div class="rbtop"><div class="download-style"><asp:Literal ID="ltrTitle" runat="server">THÔNG BÁO</asp:Literal></div></div>
        </div>
        <div style="text-align: center;" class="boxcontent">
	        <p><asp:Literal ID="ltrThongBao" runat="server">THÔNG BÁO</asp:Literal></p>
            <asp:Button ID="btnCo" runat="server" onclick="btnCo_Click" /> 
            <asp:Button ID="btnKhong" runat="server" onclick="btnKhong_Click" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlNoiDung" runat="server" Visible="false">
        <div class="rbroundbox">
	        <div class="rbtop"><div class="download-style"><asp:Literal ID="ltrTieuDe" runat="server">NỘI DUNG</asp:Literal></div></div>
        </div>
        <div class="boxcontent">
            <asp:Label ID="lblTen" runat="server" CssClass="blue bold"></asp:Label>
	        <p><asp:Literal ID="ltrNoiDung" runat="server"></asp:Literal></p>
	        <div id="detail" runat="server">
                <div id="g1" class="itemlist" runat="server">
                    <asp:Label ID="lbldb6" runat="server" CssClass="blue bold">Dac Biet DB6</asp:Label>                    
                    <asp:Literal ID="ltrgdb6" runat="server"></asp:Literal>
                </div>
                <div class="itemlist">
                    <asp:Label ID="lbldb" runat="server" CssClass="blue bold">Dac Biet</asp:Label>                    
                    <asp:Literal ID="ltrdb" runat="server"></asp:Literal>
                </div>
                <div class="itemlist">
                    <asp:Label ID="lblg1" runat="server" CssClass="blue bold">Nhat</asp:Label>                    
                    <asp:Literal ID="ltrg1" runat="server"></asp:Literal>
                </div>
                <div class="itemlist">
                    <asp:Label ID="lblg2" runat="server" CssClass="blue bold">Nhi</asp:Label>
                    <asp:Literal ID="ltrg2" runat="server"></asp:Literal>
                </div>
                <div class="itemlist">
                    <asp:Label ID="lblg3" runat="server" CssClass="blue bold">Ba</asp:Label>
                    <asp:Literal ID="ltrg3" runat="server"></asp:Literal>
                </div>
                <div class="itemlist">
                    <asp:Label ID="lblg4" runat="server" CssClass="blue bold">Tu</asp:Label>
                    <asp:Literal ID="ltrg4" runat="server"></asp:Literal>
                </div>
                <div class="itemlist">
                    <asp:Label ID="lblg5" runat="server" CssClass="blue bold">Nam</asp:Label>
                    <asp:Literal ID="ltrg5" runat="server"></asp:Literal>
                </div>
                <div class="itemlist">
                    <asp:Label ID="lblg6" runat="server" CssClass="blue bold">Sau</asp:Label>
                    <asp:Literal ID="ltrg6" runat="server"></asp:Literal>
                </div>
                <div class="itemlist">
                    <asp:Label ID="lblg7" runat="server" CssClass="blue bold">Bay</asp:Label>
                    <asp:Literal ID="ltrg7" runat="server"></asp:Literal>
                </div>
                <div id="g8" runat="server" class="itemlist">
                    <asp:Label ID="lblg8" runat="server" CssClass="blue bold">Tam</asp:Label>
                    <asp:Literal ID="ltrg8" runat="server"></asp:Literal>
                </div>
            </div>
        </div>
    </asp:Panel>
    <div class="clearfix"></div>    
    <div class="rbroundbox">
        <div class="rbtop"><div class="download-style"><asp:Literal ID="lblOther" runat="server">XEM TIEP</asp:Literal></div></div>
    </div>
    <div class="boxcontent">
        <asp:Repeater ID="rptOther" runat="server">
            <ItemTemplate>
            <div class="listlink">
                <p>♥ <asp:HyperLink ID="lnkother" NavigateUrl="#" runat="server"></asp:HyperLink></p>
            </div>
            </ItemTemplate>  
        </asp:Repeater>
    </div>
    <div class="clearfix"></div>

    <uc5:Category ID="Category1" runat="server" EnableViewState="true" />   

    </div>

    <uc1:Footer ID="Footer1" runat="server" EnableViewState="true" />   

</div>

</body>
</html>
