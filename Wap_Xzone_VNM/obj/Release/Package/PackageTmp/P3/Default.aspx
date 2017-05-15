<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WapXzone_VNM.P3.Default" %>

<%@ Register Src="UserControl/Footer.ascx" TagName="Footer" TagPrefix="uc2" %>
<%@ Register Src="UserControl/Header.ascx" TagName="Header" TagPrefix="uc1" %>
<%@ Register Src="UserControl/Link.ascx" TagName="Link" TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta content="noindex,nofollow" name="robots" />
    <meta content="noindex,nofollow,noarchive" name="Googlebot" />
    <asp:Literal ID="ltrWidth" runat="server" EnableViewState="False"></asp:Literal>
    <style media="screen" type="text/css">
        @import "style/style.css";
    </style>
    <script type="text/javascript" src="style/jquery-1.7.1.min.js"></script>
    <script type="text/javascript">
        function loadmore(element, divid, url, pageIndex) {
            nextPageIndex = pageIndex + 5;
            $.post(url + pageIndex,
            function (data) {
                if (data != "" && data.length > 100) {
                    $("#" + divid).find('.a-list').first().append(data);
                    var href = $('#' + element).attr("href");
                    href = href.replace(',' + pageIndex, ',' + nextPageIndex);
                    pageIndex = nextPageIndex;
                    $('#' + element).attr("href", href);
                }
                else {
                    $('#pn_more').hide();
                }
            });
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="wrapper">
        <uc1:Header ID="Header1" runat="server" EnableViewState="False" />
        <%--Content here--%>
        <asp:PlaceHolder runat="server" EnableViewState="False" ID="plContent"></asp:PlaceHolder>
        <%--end Content here--%>
        <uc3:Link ID="Link1" runat="server" EnableViewState="False" />
        <uc2:Footer ID="Footer4" runat="server" EnableViewState="False" />
    </div>
    </form>
</body>
</html>
