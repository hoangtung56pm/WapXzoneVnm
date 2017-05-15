<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Boivui_Boqua.ascx.cs" Inherits="WapXzone_VNM.Hoangdao.UserControl.Boivui_Boqua" %>
<div class="roundcont">
   <div class="roundtop">
	 <img height="12" width="12" style="display: none" class="corner" alt="" src="img/ts_tl.png">
   </div>
   <p style="text-align:center; font-size:12px; font-weight:bold;"><asp:Literal ID="ltrTieude" runat="server" EnableViewState="False">BỎ QUA BÓI VUI</asp:Literal></p> 
   <div class="roundbottom">
	 <img height="12" width="12" style="display: none" class="corner" alt="" src="img/ts_bl.png">
   </div>
</div>
<div style="margin: 5px; padding: 5px; border:#eb0069 solid 1px;">
    <asp:Literal ID="ltrHuongdan" runat="server" EnableViewState="False">    
	    • Bấm về trang chủ để sử dụng dịch vụ khác<br>
	    • Bấm Bỏ qua để rời khỏi mục Bói vui
	</asp:Literal>
</div>
<div class="pink"><asp:HyperLink ID="lnkTrangchu" runat="server"><span class="bold">VỀ TRANG CHỦ</span></asp:HyperLink></div>
<div class="grey"><asp:LinkButton ID="btnBoqua" runat="server" onclick="btnBoqua_Click"><span class="bold">BỎ QUA</span></asp:LinkButton></div>