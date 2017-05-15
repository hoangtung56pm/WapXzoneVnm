<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Home.ascx.cs" Inherits="WapXzone_VNM.Phanmem.UserControlHigh.Home" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>
<%@ Import Namespace="WapXzone_VNM.Library.UrlProcess" %>
<%@ Import Namespace="WapXzone_VNM.Library.Utilities" %>

<div class="box-phanmem">
    <h4 class="title-phanmem">
        <a href="<%= UrlProcess.PhanMemChuyenMuc(10,1,"tai-nhieu-nhat") %>">
            TẢI NHIỀU NHẤT
        </a> 
    </h4>
    <div class="box">
        <div class="list-game">
            <asp:Repeater ID="rptHotNhat" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                        <div class="border">
                            <a href="<%# UrlProcess.PhanMemChiTiet(ConvertUtility.ToInt32(Eval("W_AppItemID")),Eval("AppName").ToString()) %>">
                                <img class="img-radius"  alt="" src="<%# AppEnv.GetAvatarByPath(Eval("Avatar").ToString(),70,70) %>">
                            </a>
                            <p class="phanmem-height">
                                <%# AppEnv.TrimLength(Eval("AppNameUnicode").ToString(),50) %>
                            </p>
                            
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>

<div class="box-phanmem">
    <h4 class="title-phanmem">
         <a href="<%= UrlProcess.PhanMemChuyenMuc(9,1,"tai-nhieu-nhat") %>">
            MỚI CẬP NHẬT
         </a>
    </h4>
    <div class="box">
        <div class="list-game">
            <asp:Repeater ID="rptMoiNhat" runat="server" EnableViewState="false">
                <ItemTemplate>
                    <div class="item">
                        <div class="border">
                            <a href="<%# UrlProcess.PhanMemChiTiet(ConvertUtility.ToInt32(Eval("W_AppItemID")),Eval("AppName").ToString()) %>">
                                <img width="74" class="img-radius" alt="" src="<%# AppEnv.GetAvatarByPath(Eval("Avatar").ToString(),70,70) %>">
                            </a>
                            <p class="phanmem-height">
                                <%# AppEnv.TrimLength(Eval("AppNameUnicode").ToString(),50) %>
                            </p>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
    </div>
</div>
