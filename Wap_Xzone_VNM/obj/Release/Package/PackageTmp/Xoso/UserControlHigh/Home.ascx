<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="WapXzone_VNM.Xoso.UserControlHigh.Home" %>
<%@ Import Namespace="WapXzone_VNM.Library.Constant" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<%@ Register src="SelectDate.ascx" tagname="SelectDate" tagprefix="uc1" %>


<uc1:SelectDate ID="SelectDate1" runat="server" />

            
        <div class="box-thugian">
            <h4>
                <a href="<%= UrlProcess.XoSoChiTietNew(1,day.ToString(),Constant.XoSo_Kqxs_Rewrite) %>">
                    XS Thủ Đô
                </a>
            </h4>
            <ul class="list-truyen list-xoso">
                <li><a href="<%= UrlProcess.XoSoChiTiet(1,Constant.XoSo_KqCho_Rewrite) %>">Kết quả chờ</a></li>
                <li><a href="<%= UrlProcess.XoSoChiTiet(1,Constant.XoSo_ThongKe_Rewrite) %>">Thống kê cặp số</a></li>
                <li><a href="<%= UrlProcess.XoSoChiTietNew(1,day.ToString(),Constant.XoSo_Kqxs_Rewrite) %>">Kết quả (<%= Ngay %>)</a></li>
                <%--<li><a href="#">Nhận KQXS hàng ngày </a></li>--%>
            </ul>
        </div>

        <asp:Repeater ID="rptList" runat="server">
            <ItemTemplate>
                <div class="box-thugian">
                    <h4>
                        <asp:HyperLink ID="lnkCity" NavigateUrl="#" runat="server" EnableViewState="False"></asp:HyperLink>
                    </h4>
                    <ul class="list-truyen list-xoso">

                        <li>
                            <asp:HyperLink ID="lnkkqc" runat="server" EnableViewState="False" Text="KQ cho"></asp:HyperLink>
                        </li>

                        <li>
                            <asp:HyperLink ID="lnksc" runat="server" EnableViewState="False" Text="Thong ke cap so"></asp:HyperLink>
                        </li>

                        <li>
                            <asp:HyperLink ID="lnkxkq" runat="server" EnableViewState="False" Text="KQ"></asp:HyperLink>
                        </li>

                        <%--<li>
                            <a href="#">Nhận KQXS hàng ngày </a>
                        </li>--%>

                    </ul>
                </div>
            </ItemTemplate>
        </asp:Repeater>


        