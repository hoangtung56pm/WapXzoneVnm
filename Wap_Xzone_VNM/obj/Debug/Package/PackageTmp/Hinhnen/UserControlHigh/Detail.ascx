<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Detail.ascx.cs" Inherits="WapXzone_VNM.Hinhnen.UserControlHigh.Detail" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>

<%@ Register Src="Category.ascx" TagName="Category1" TagPrefix="uc1" %>

<div class="anh-nen-2">
            <div class="slider-img">
                <div id="slider-img" class="carousel slide" data-ride="carousel">
                    <!-- Indicators -->
                    <%--<div class="box-indicators">
                        <ol class="carousel-indicators">
                            <li data-target="#slider-img" data-slide-to="0" class="active"></li>
                            <li data-target="#slider-img" data-slide-to="1"></li>
                            <li data-target="#slider-img" data-slide-to="2"></li>
                        </ol>


                        <a class="btn-prev control-slider" href="#slider-img" data-slide="prev">
                            <img src="/Content/asset/Images/arrow-prev.png" alt=""/>
                        </a>
                        <a class="btn-next control-slider" href="#slider-img" data-slide="next">
                            <img src="/Content/asset/Images/arrow-next.png" alt=""/>
                        </a>
                    </div>--%>

                    <!-- Wrapper for slides -->
                    <div class="carousel-inner">
                        
                        <asp:Repeater ID="rptDetail" runat="server" EnableViewState="false">
                            <ItemTemplate>
                                <div class="item active">
                                    <a href="#"></a>
                                    <img src="<%# AppEnv.GetTrueAvatarPath(Eval("WThumnail").ToString().Replace("thumb_","")) %>" alt="" />
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>

                        

                        <%--<div class="item">
                            <a href="#"></a>
                            <img src="/Content/asset/Images/img-slider.png" alt="">
                        </div>

                        <div class="item">
                            <a href="#"></a>
                            <img src="/Content/asset/Images/img-slider.png" alt="">
                        </div>--%>

                    </div>


                </div>
                <div class="box-download-img">
                    <span class="price-img">
                        <asp:Label ID="lblPrice" runat="server" EnableViewState="false"></asp:Label>Đ
                    </span>
                    <a class="btn-download" href="<%= UrlProcess.HinhNenDowload(id,catid) %>">
                        <img src="/Content/asset/Images/btn-dow-img.png" alt=""/>
                    </a>
                </div>

            </div>
        </div>

<uc1:Category1 ID="Category1" runat="server" EnableViewState="False" />
