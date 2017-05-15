<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="BangXepHang.ascx.cs" Inherits="WapXzone_VNM.Thethao.UserControlHigh.BangXepHang" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<%@ Register src="DuLieuBongDa.ascx" tagname="DuLieuBongDa" tagprefix="uc1" %>

<div class="box-bxh">
            <div class="title-video">
                <ul class="nav-ketqua">
                    <li><a class="active" href="<%= UrlProcess.TheThaoHome() %>">Bóng đá »</a></li>
                    <li><a href="javascript:void(0)">Bảng xếp hạng</a></li>
                </ul>
                <div class="border-color">
                    <div></div>
                </div>
            </div>

            <div class="boxcontent">
                        <div class="bold">
                            <asp:Literal ID="ltrGiaiDau" runat="server" EnableViewState="False"></asp:Literal>
                            <asp:Literal ID="ltrRoundName" runat="server" EnableViewState="False"></asp:Literal>
                        </div>
                    </div>

            <table class="table-bxh">
                <thead>
                    <tr>
                        <th>No.</th>
                        <th>Đội</th>
                        <th>T</th>
                        <th>H</th>
                        <th>B</th>
                        <th>Điểm</th>
                    </tr>
                </thead>
                <tbody>
                    
                    <asp:Repeater ID="rptbxh" runat="server" EnableViewState="false">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("Position")%></td>
                                <td><%# Eval("TeamCode")%></td>
                                <td><%# Eval("Total_Won")%></td>
                                <td><%# Eval("Total_Draw")%></td>
                                <td><%# Eval("Total_Lost")%></td>
                                <td><%# Eval("Point")%></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>

                  <%--  <tr>
                        <td>1</td>
                        <td>Che</td>
                        <td>19</td>
                        <td>3</td>
                        <td>3</td>
                        <td>60</td>
                    </tr>

                    <tr>
                        <td>1</td>
                        <td>Che</td>
                        <td>19</td>
                        <td>3</td>
                        <td>3</td>
                        <td>60</td>
                    </tr>

                    <tr>
                        <td>1</td>
                        <td>Che</td>
                        <td>19</td>
                        <td>3</td>
                        <td>3</td>
                        <td>60</td>
                    </tr>

                    <tr>
                        <td>1</td>
                        <td>Che</td>
                        <td>19</td>
                        <td>3</td>
                        <td>3</td>
                        <td>60</td>
                    </tr>

                    <tr>
                        <td>1</td>
                        <td>Che</td>
                        <td>19</td>
                        <td>3</td>
                        <td>3</td>
                        <td>60</td>
                    </tr>

                    <tr>
                        <td>1</td>
                        <td>Che</td>
                        <td>19</td>
                        <td>3</td>
                        <td>3</td>
                        <td>60</td>
                    </tr>

                    <tr>
                        <td>1</td>
                        <td>Che</td>
                        <td>19</td>
                        <td>3</td>
                        <td>3</td>
                        <td>60</td>
                    </tr>--%>

                </tbody>
            </table>

        </div>

<uc1:DuLieuBongDa ID="DuLieuBongDa1" runat="server" EnableViewState="False" />   