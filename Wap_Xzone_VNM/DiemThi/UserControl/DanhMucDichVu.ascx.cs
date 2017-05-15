using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Component.HoangDao;
using WapXzone_VNM.Library.Constant;


namespace WapXzone_VNM.DiemThi.UserControl
{
    public partial class DanhMucDichVu : System.Web.UI.UserControl
    {
        private string width;
        private string lang;
        private static string preurl;
        private string cipher;
        private string cpid = string.Empty;
        private string vmstransactionid = string.Empty;
        private string msisdn = string.Empty;        
        private string price;
        private int type;

        protected void Page_Load(object sender, EventArgs e)
        {              
            lang = Request.QueryString["lang"];
            width = Request.QueryString["w"];
            lnkDT_THCS.NavigateUrl = UrlProcess.GetDiemthi_DT_THCSUrl(lang, width);
            lnkXH_THCS.NavigateUrl = UrlProcess.GetDiemthi_XH_THCSUrl(lang, width);
            
            lnkDT_PTTH.NavigateUrl = UrlProcess.GetDiemthi_DT_PTTHUrl(lang, width);
            lnkXH_PTTH.NavigateUrl = UrlProcess.GetDiemthi_XH_PTTHUrl(lang, width);

            lnkDT_DH.NavigateUrl = UrlProcess.GetDiemthi_DT_DHUrl(lang, width);
            lnkXH.NavigateUrl = UrlProcess.GetDiemthi_XH_DHUrl(lang, width);
            lnkDiemChuan.NavigateUrl = UrlProcess.GetDiemthi_DiemchuanUrl(lang, width);
            lnkTiLeChoi.NavigateUrl = UrlProcess.GetDiemthi_TilechoiUrl(lang, width);
            lnkDD_DoTruot.NavigateUrl = UrlProcess.GetDiemthi_DauTruotUrl(lang, width);
            lnk1_3.NavigateUrl = UrlProcess.GetDiemthi_1_3Url(lang, width);
            lnkDapAn.NavigateUrl = UrlProcess.GetDiemthi_DapanUrl(lang, width);
            //
            lnkMaTinh_THCS.NavigateUrl = lnkMaTinh_PTTH.NavigateUrl = UrlProcess.GetDiemthi_MaTinhUrl(lang, width);
            lnkMaTruong.NavigateUrl = UrlProcess.GetDiemthi_MaTruongUrl(lang, width);


            if (lang == "1")
            {
                ltrTHCS.Text = "TỐT NGHIỆP THCS 2011";
                lnkDT_THCS.Text = "Tra cứu điểm thi tốt nghiệp THCS";
                lnkXH_THCS.Text="Xếp hạng THCS";
                lnkMaTinh_THCS.Text = "Danh sách mã tỉnh";

                ltrPTTH.Text = "TỐT NGHIỆP PTTH 2011";
                lnkDT_PTTH.Text="Tra cứu điểm thi tốt nghiệp PTTH";
                lnkXH_PTTH.Text = "Xếp hạng PTTH";
                lnkMaTinh_PTTH.Text = "Danh sách mã tỉnh";

                ltrDaiHoc.Text = "THI ĐẠI HỌC 2011";
                lnkDT_DH.Text="Tra cứu điểm thi đại học";
                lnkDiemChuan.Text="Tra điểm chuẩn";
                lnkXH.Text="Tra vị trí xếp hạng trong trường";
                lnkDD_DoTruot.Text="Tra thông tin hỗ trợ dự đoán ĐẬU hay TRƯỢT";
                lnkTiLeChoi.Text = "Tra tỷ lệ chọi";
                lnk1_3.Text="Nhắn 1 được 3 (1 tin nhắn nhận cả điểm thi, xếp hạng và điểm chuẩn)";
                lnkDapAn.Text = "Đáp án đề thi";
                lnkMaTruong.Text="Danh sách mã trường";
                lnkMaNganh.Text="Danh sách mã ngành";
                lnkMaKhoi.Text="Danh sách mã khối ";
                lnkMaDe.Text = "Danh sách mã đề";
            }
            else
            {
                ltrTHCS.Text = "TOT NGHIEP THCS";
                lnkDT_THCS.Text = "Tra cuu diem thi tot nghiep THCS";
                lnkXH_THCS.Text = "Xep hang THCS";
                lnkMaTinh_THCS.Text = "Danh sach ma tinh";

                ltrPTTH.Text = "TOT NGHIEP PTTH";
                lnkDT_PTTH.Text = "Tra cuu diem thi tot nghiep PTTH";
                lnkXH_PTTH.Text = "Xep hang PTTH";
                lnkMaTinh_PTTH.Text = "Danh sach ma tinh";

                ltrDaiHoc.Text = "THI DAI HOC";
                lnkDT_DH.Text = "Tra cuu diem thi dai hoc";
                lnkDiemChuan.Text = "Tra diem chuan";
                lnkXH.Text = "Tra vi tri xep hang trong truong";
                lnkDD_DoTruot.Text = "Tra thong tin ho tro du doan DAU hay TRUOT";
                lnkTiLeChoi.Text = "Tra ty le choi";
                lnk1_3.Text = "Nhan 1 duoc 3 (1 tin nhan nhan ca diem thi, xep hang va diem chuan)";
                lnkDapAn.Text = "Dap an de thi";
                lnkMaTruong.Text = "Danh sach ma truong";
                lnkMaNganh.Text = "Danh sach ma nganh";
                lnkMaKhoi.Text = "Danh sach ma khoi";
                lnkMaDe.Text = "Danh sach ma de";
            }            
        }
    }
}