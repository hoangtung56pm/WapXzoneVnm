<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="List.ascx.cs" Inherits="WapXzone_VNM.Thugian.UserControlHigh.List" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<%@ Register Src="Paging.ascx" TagName="Paging" TagPrefix="uc1" %>

<div class="box-thugian">
                <h4>
                    <asp:Label ID="lblCatetoryName" runat="server" EnableViewState="False"></asp:Label>
                </h4>
                <ul class="list-truyen">

                    <asp:Repeater ID="rptCategory" runat="server" EnableViewState="false">
                        <ItemTemplate>
                            <li>
                                <%--<a href="<%# UrlProcess.ThuGianChiTiet(ConvertUtility.ToInt32(Eval("Distribution_ID").ToString()),Eval("Content_HeadlineKD").ToString()) %>">--%>
                                <a href="<%# UrlProcess.ThuGianDowload(Eval("Distribution_ID").ToString()) %>">
                                    <%# Eval("Content_Headline")%>
                                </a>
                            </li>
                        </ItemTemplate>
                    </asp:Repeater>

                </ul>
            </div>

<uc1:Paging ID="Paging1" runat="server" EnableViewState="False" />

