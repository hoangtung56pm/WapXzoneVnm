<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HuongDan.aspx.cs" Inherits="WapXzone_VNM.Wap.HuongDan" %>

<%@ Register Src="UserControlHigh/Footer.ascx" TagName="Footer" TagPrefix="uc1" %>
<%@ Register Src="UserControlHigh/Header.ascx" TagName="Header" TagPrefix="uc2" %>
<%@ Register Src="UserControlHigh/Menu.ascx" TagName="Menu" TagPrefix="uc3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>.: Vietnamobile - Hướng dẫn :.</title>
    <link rel="stylesheet" href="/Content/asset/Plugin/bootstrap-3.0.3/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/Content/asset/Plugin/mmenu/css/jquery.mmenu.all.css" />
    <link rel="stylesheet" href="/Content/asset/Css/style.css" />
    <script type="text/javascript" src="/Content/asset/Javascript/jquery.min.js"></script>
    <%--<script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.hammer.min.js"></script>--%>
    <script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.mmenu.min.all.js"></script>
    <script type="text/javascript" src="/Content/asset/Javascript/app.js"></script>
</head>
<body>
    <%--<div class="dialogBox" style="display: none;">
        <a class="center-parent" id="btnTest" style="display: block; height: 30px; width: 50px; background-color: black; margin-left: 50%;"></a>
    </div>

    <uc3:Menu ID="Menu1" runat="server" EnableViewState="False" />

    <div class="wrapper">

        <uc2:Header ID="Header1" runat="server" EnableViewState="False" />--%>

        <div class="body table-scrollable" style="margin-top: 2px; margin-bottom: 2px">


            <asp:Repeater runat="server" ID="rptNoiDung" EnableViewState="False">

                <HeaderTemplate>
                    <table style="border-color: #FF6600" border="1" cellpadding="0" cellspacing="0" width="100%">
                        <%--<tr>
                            <td colspan="6" align="center">SUBCRIPTION SERVICES trên đầu 949</td>
                        </tr>--%>
                        <tr class="bold" align="center" style="color: Black; height: 25px; background-color: #FF6600;">
                            <th>Tên dịch vụ</th>
                            <th>Đầu số</th>
                            <th>MainCode</th>
                            <th>SubCode</th>
                            <th>Link đăng ký</th>
                            <th>Giá charging(vnd)</th>
                        </tr>
                </HeaderTemplate>

                <ItemTemplate>
                    <tr align="center">
                        <td><%# Eval("Service_Name") %></td>
                        <td><%# Eval("ShortCode") %></td>
                         <td><%# Eval("MainCode") %></td>
                        <td><%# Eval("SubCode") %></td>
                        <td><%# Eval("Link") %></td>
                        <td><%# Eval("Charging_Price") +"d/Ngày"%></td>
                    </tr>
                </ItemTemplate>

                <FooterTemplate>
                    </table>
                </FooterTemplate>

            </asp:Repeater>
        <%--</div>--%>

        <%--<uc1:Footer ID="Footer1" runat="server" EnableViewState="False" />--%>

    </div>

</body>
</html>
