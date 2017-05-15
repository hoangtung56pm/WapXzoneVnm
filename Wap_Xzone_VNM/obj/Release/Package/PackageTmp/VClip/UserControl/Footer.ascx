<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Footer.ascx.cs" Inherits="WapXzone_VNM.VClip.UserControl.Footer" %>
<%@ Import Namespace="WapXzone_VNM.VClip.Library.UrlProcess" %>

 <footer>
    Copyright @ 2012 Vietnamobile
 </footer>
 
<!-- wrap overlay -->
<div class="overlay-wrap" style="display:none;"></div> 

<!-- overlay category -->
<div class="overlay-conten overlay-category">
    <a class="boxclose"></a>
    <ul class="listCat">
        
        <asp:Repeater ID="rptCategory" runat="server" EnableViewState="true">
            <ItemTemplate>
                <li>
                    <h3>
                        <a href="<%# UrlProcess.GetVideoCategoryUrl(lang.ToString(),width,Eval("W_VCategoryID").ToString()) %>"><%# Eval("Title_Unicode")%></a>
                    </h3>
                </li>
            </ItemTemplate>
        </asp:Repeater>

    </ul>
</div>
 
<!-- overlay category -->
<div class="overlay-conten overlay-register">
    <a class="boxclose"></a>
    <div class="boxRegister clearfix">
        <h4 class="title-popup">Đăng ký</h4>            
        <ul class="form-list">
            <li>
                <label class="field">Số điện thoại</label>
                <input type="text" class="ipForm"/>
            </li>
            <li>
                <label class="field">Mật khẩu</label>
                <input type="password" class="ipForm"/>
            </li>
            <li>
                <input type="submit" value="Đăng nhập" class="button-form"/>
            </li>
        </ul>
        <ul class="form-list">
            <li class="forgotText">
                Quên mật khẩu? Soạn tin nhắn <b>VCLIP MK gửi 9234</b> để lấy mật khẩu, hoặc nhập số điện thoại bên dưới, hệ thống sẽ gửi mật khẩu về máy cho bạn.
            </li>
            <li>
                <input type="text" class="ipForm"/>
            </li>
            <li>
                <input type="submit" value="Gửi đi" class="button-form"/>
            </li>
        </ul>
    </div>
    
</div>