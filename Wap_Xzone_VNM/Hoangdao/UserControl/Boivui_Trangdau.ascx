<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Boivui_Trangdau.ascx.cs" Inherits="WapXzone_VNM.Hoangdao.UserControl.Boivui_Trangdau" %>
<asp:Panel ID="pnlTrangdau" runat="server">        
    <div class="roundcont">
       <div class="roundtop">
         <img height="12" width="12" style="display: none" class="corner" alt="" src="img/ts_tl.png">
       </div>
       <p>
        <asp:Literal ID="ltrTieude" runat="server" EnableViewState="False">Bạn sẽ vui thật là vui, hay buồn ơi là sầu? Sẽ thất bại hay thành công rực rỡ? Relax một tẹo với <b>Bói Vui</b> của <b>XFUN</b> bạn nhé</asp:Literal>   
       </p>  
       <div class="roundbottom">
         <img height="12" width="12" style="display: none" class="corner" alt="" src="img/ts_bl.png">
       </div>
    </div>
    <div style="padding:5px;">
        <i><asp:Literal ID="ltrHuongdan" runat="server" EnableViewState="False">Nhập ngày sinh theo mẫu, rồi bấm nút bói theo Ngày - Tuần - Tháng</asp:Literal></i>
    </div>
</asp:Panel>
<asp:Panel ID="pnlNoidung" runat="server" Visible="false">        
    <div class="roundcont">
       <div class="roundtop">
	     <img height="12" width="12" style="display: none" class="corner" alt="" src="img/ts_tl.png">
       </div>
       <p style="text-align:center; font-size:12px; font-weight:bold;"><asp:Literal ID="ltrKieuboi" runat="server" EnableViewState="False"></asp:Literal></p> 
       <div class="roundbottom">
	     <img height="12" width="12" style="display: none" class="corner" alt="" src="img/ts_bl.png">
       </div>
    </div>
    <div style="margin: 5px; padding: 5px; border:#eb0069 solid 1px;">
	    <asp:Literal ID="ltrNoidung" runat="server" EnableViewState="False"></asp:Literal>
    </div>    
</asp:Panel>
<asp:Panel ID="pnlXacnhan" runat="server" Visible="false">
    <div style="margin: 5px; padding: 5px; border:#eb0069 solid 1px;">
	    <asp:Literal ID="ltrXacnhan" runat="server" EnableViewState="False"></asp:Literal>
	    <p>
            <asp:Button ID="btnXacnhan" runat="server" Text="Xác nhận" 
                onclick="btnXacnhan_Click" />
            <asp:HyperLink ID="lnkHuy" runat="server"> Huỷ </asp:HyperLink>
        </p>
    </div> 
</asp:Panel>
<div class="sfrm">
  <div class="sfrmtop">
    <div>
        <asp:TextBox ID="txtNgay" runat="server" Text="Ngay" CssClass="sfrminput" onfocus="if (this.value=='Ngay') { this.value=''; }" onblur="if (this.value=='') { this.value='Ngay'; }"></asp:TextBox>
        <asp:TextBox ID="txtThang" runat="server" Text="Thang" CssClass="sfrminput"  onfocus="if (this.value=='Thang') { this.value=''; }" onblur="if (this.value=='') { this.value='Thang'; }"></asp:TextBox>        
    </div>  
  </div>
</div>
<div class="pink"><asp:ImageButton ID="btnNgay" ImageUrl="~/img/btnNgay.jpg" runat="server" onclick="btnNgay_Click" /></div>
<div class="pink"><asp:ImageButton ID="btnTuan" ImageUrl="~/img/btnTuan.jpg" runat="server" onclick="btnTuan_Click" /></div>
<div class="pink"><asp:ImageButton ID="btnThang" ImageUrl="~/img/btnThang.jpg" runat="server" onclick="btnThang_Click" /></div>
<%--<div class="grey"></div>--%><asp:HyperLink ID="lnkBoqua" Visible="false" runat="server"><span><b>BỎ QUA</b></span></asp:HyperLink>
<div style="padding:5px; font-size:10px;">
    <i><asp:Literal ID="ltrGia" runat="server" EnableViewState="False">Phí dịch vụ: Bói ngày 1000, bói tuần 2000, bói tháng 5000</asp:Literal></i>
</div>