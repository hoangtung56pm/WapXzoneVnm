using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Sub
{
    public partial class DangKyS2_94x : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                return;
                if (AppEnv.GetSetting("TestFlag") == "1")
                {
                    Session["telco"] = Constant.T_Vietnamobile;
                    Session["msisdn"] = "0987765522";
                }

                if (Session["msisdn"] == null)
                {
                    int is3g = 0;
                    string msisdn = MobileUtils.GetMSISDN(out is3g);
                    if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
                    {
                        Session["telco"] = Constant.T_Vietnamobile;
                        Session["msisdn"] = msisdn;
                    }
                    else
                    {
                        Session["msisdn"] = null;
                        Session["telco"] = Constant.T_Undefined;
                    }
                }

                pnlNoiDung.Visible = true;
                string madichvu = Request.QueryString["t"];
                madichvu = madichvu.Trim().ToUpper();

                string dangkyThanhCong = string.Empty;
                string doubleDangKy = string.Empty;
                //string dangkyThatBai = string.Empty;
                string tenDichVu = string.Empty;

                string regisSystax = "DK " + madichvu;
                if (madichvu == "HTCLIP")
                {
                    regisSystax = "HT CLIP";
                }
                else if (madichvu == "HTFUNNY")
                {
                    regisSystax = "HT FUNNY";
                }
                else if (madichvu == "DAVIP")
                {
                    regisSystax = "VIP";
                }
                else if (madichvu == "CPIC")
                {
                    regisSystax = "DK PIC";
                }
                else if (madichvu == "CANH2")
                {
                    regisSystax = "DK ANH2";
                }
                else if (madichvu == "F8CLIP")
                {
                    regisSystax = "DK F8 CLIP";
                }
                if (Session["msisdn"] != null && Session["msisdn"].ToString() != "")
                {
                    if(madichvu == "VDH")
                    {
                        ltrTieuDe.Text = "Đăng ký dịch vụ VIDEO hàng ngày";
                        tenDichVu = "VIDEO Hàng Ngày";

                        dangkyThanhCong = "Quý khách đã DK thành công DV VIDEO HOT của VNM(5000đ/ngày).<br />VIDEO HOT sẽ được gửi về vào 10h30 hàng ngày.<br />Để tải về máy cần hỗ trợ GPRS.<br />Soạn GPRS gửi 223.<br />Để hủy DK, soạn : HUY VDH gửi 949";
                        doubleDangKy = "Quý khách đã là thuê bao của DV này.<br />QK sẽ nhận được VIDEO HOT vào 10h30 hàng ngày.<br />Chi tiết <a href='http://wap.vietnamobile.com.vn/Wap/DailyInfo.aspx'>http://wap.vietnamobile.com.vn/Wap/DailyInfo.aspx</a> HT 19001255";
                    }
                    else if(madichvu == "CHD")
                    {
                        ltrTieuDe.Text = "Đăng ký dịch vụ Xem Cung Hoàng Đạo";
                        tenDichVu = "Xem Cung Hoàng Đạo";

                        dangkyThanhCong = "Quý khách đã DK thành công DV XEM CUNG HOÀNG ĐẠO của VNM(2000đ/ngày).<br />Thông tin CUNG HOÀNG ĐẠO sẽ được gửi về vào 8h hàng ngày.<br />Để hủy DK, soạn HUY CHD gửi 949.<br />Chi tiết <a href='http://wap.vietnamobile.com.vn/Wap/DailyInfo.aspx'>http://wap.vietnamobile.com.vn/Wap/DailyInfo.aspx</a> HT 19001255";
                        doubleDangKy = "Quý khách đã là thuê bao của DV này.<br />QK sẽ nhận được thông tin cung hoàng đạo vào 8h hàng ngày.<br />Chi tiết http://wap.vietnamobile.com.vn/Wap/DailyInfo.aspx HT 19001255";
                    }
                    else if(madichvu == "TIP")
                    {
                        ltrTieuDe.Text = "TIP(Trận cầu đinh)";
                        dangkyThanhCong = "Chuc mung ban da dk d/v TIP(Tran cau dinh) mien phi ngay dau tien su dung dv.<br /> Tu ngay thu 2 gia cuoc 15000VND/tuan.<br /> Huy dv soan HUY TIP gui 949";
                        doubleDangKy = "Ban dang ky goi dvu TIP(Tran cau dinh) khong thanh cong do dang ky thue bao da ton tai.<br /> Cam on ban da su dung goi dich vu. HT: 19001255";
                    }
                    else if (madichvu == "VE")
                    {
                        ltrTieuDe.Text = "Tư vấn kết quả xổ số Toàn quốc";
                        dangkyThanhCong = "Chuc mung ban da dk d/v tu van KQXS TOAN QUOC, mien phi ngay dau tien su dung dv.<br /> Tu ngay thu 2 gia cuoc 5000VND/ngay.<br /> Huy dv soan HUY VE gui 949";
                        doubleDangKy = "Ban dang ky goi dvu tu van KQXS TOAN QUOC khong thanh cong do dang ky thue bao da ton tai.<br /> Cam on ban da su dung goi dich vu. HT: 19001255";
                    }
                    else if (madichvu == "G1")
                    {
                        ltrTieuDe.Text = "TOP GAME HOT";
                        dangkyThanhCong = "Chuc mung ban da dk d/v TOP GAME HOT, mien phi ngay dau tien su dung dv.<br /> Tu ngay thu 2 gia cuoc 10000VND/tuan.<br /> Huy dv soan HUY G1 gui 949";
                        doubleDangKy = "Ban dang ky goi dvu TOP GAME HOT khong thanh cong do dang ky thue bao da ton tai.<br /> Cam on ban da su dung goi dich vu. HT: 19001255";
                    }
                    else if (madichvu == "C1")
                    {
                        ltrTieuDe.Text = "TOP CLIP HOT";
                        dangkyThanhCong = "Chuc mung ban da dk d/v TOP CLIP HOT, mien phi ngay dau tien su dung dv.<br /> Tu ngay thu 2 gia cuoc 10000VND/tuan.<br /> Huy dv soan HUY C1 gui 949";
                        doubleDangKy = "Ban dang ky goi dvu TOP CLIP HOT khong thanh cong do dang ky thue bao da ton tai.<br /> Cam on ban da su dung goi dich vu. HT: 19001255";
                    }
                    else if (madichvu == "FUN")
                    {
                        ltrTieuDe.Text = "TRUYEN CUOI HOT";
                        dangkyThanhCong = "Quý khách đã đăng kí thành công dịch vụ truyện cười, miễn phí 7 ngày sử dụng, hết thời gian miễn phí sẽ tính phí 1000đ/ngày.<br /> Để hủy dịch vụ soạn tin HUY FUN gửi 949";
                        doubleDangKy = "Ban dang ky goi dvu TRUYEN CUOI khong thanh cong do dang ky thue bao da ton tai.<br /> Cam on ban da su dung goi dich vu. HT: 19001255";
                    }
                    else if (madichvu == "VIDEO3")
                    {
                        ltrTieuDe.Text = "VIDEO HOT";
                        dangkyThanhCong = "Quý khách đã DK thành công DV VIDEO HOT của VNM(5000đ/ngày).<br />VIDEO HOT sẽ được gửi về vào 10h30 hàng ngày.<br />Để tải về máy cần hỗ trợ GPRS.<br />Soạn GPRS gửi 223.<br />Để hủy DK, soạn : HUY VIDEO3 gửi 949";
                        doubleDangKy = "Ban dang ky goi dvu VIDEO HOT khong thanh cong do dang ky thue bao da ton tai.<br /> Cam on ban da su dung goi dich vu. HT: 19001255";
                    }
                    else if (madichvu == "F8CLIP")
                    {
                        ltrTieuDe.Text = "DK F8 CLIP";
                        dangkyThanhCong = "Chúc mừng bạn đã đăng ký dịch vụ TOP CLIP HOT thành công, bạn có 1 tuần miễn phí sử dụng dịch vụ.<br />Từ tuần thứ 2 giá cước 10000VND/tuần.<br />Bạn sẽ nhận được 10 clip hot nhất vào lúc 15h thứ 4 hàng tuần.<br />Để hủy DK, soạn : HUY F8 CLIP gửi 949";
                        doubleDangKy = "Ban dang ky goi dvu TOP CLIP HOT khong thanh cong do dang ky thue bao da ton tai.<br /> Cam on ban da su dung goi dich vu. HT: 19001255";
                        madichvu = "DK F8 CLIP";
                    }
                    else if(madichvu == "KPOP")
                    {
                        ltrTieuDe.Text = "KPOP";
                        dangkyThanhCong = "Chuc mung Quy Khach da dang ky thanh cong goi dvu Kpop va Fan Gia cuoc 5000d/ngay.<br />Goi dich vu se duoc tu dong gia han hang ngay<br />Tra loi cau hoi de tich diem  va co hoi trung giai thuong Iphone 5<br />De huy dang ky, Quy Khach soan HUY Kpop gui  949. HT: 19001255";
                        doubleDangKy = "Quy Khach dang ky goi dvu Kpop va Fan khong thanh cong do thue bao dang ky da ton tai<br />Cam on Quy Khach da su dung goi dich vu.";
                    }
                    else if (madichvu == "GB")
                    {
                        ltrTieuDe.Text = "GAME DK GB";
                        dangkyThanhCong = "Chuc mung QK da DK tai game(15000/tuan).<br />Tong dai ho tro 19001255. Dich vu tu dong gia han va mien phi 7 ngay su dung.<br /> De huy DK, soan: HUY GB gui 949";
                        doubleDangKy = "QK da dang ky dv Tai game.<br /> Vui long lien he tong dai 19001255 de biet chi tiet";
                    }
                    else if (madichvu == "NHAC")
                    {
                        ltrTieuDe.Text = "NHAC DK NHAC";
                        dangkyThanhCong = "Chuc mung QK da DK tai nhac(15000/tuan).<br />Tong dai ho tro 19001255. Dich vu tu dong gia han va mien phi 7 ngay su dung.<br /> De huy DK, soan: HUY NHAC gui 949";
                        doubleDangKy = "QK da dang ky dv Tai nhac. Vui long lien he tong dai 19001255 de biet chi tiet";
                    }
                    else if (madichvu == "HTCLIP")
                    {
                        ltrTieuDe.Text = "Dich vu nhan Clip hot hang ngay";
                        dangkyThanhCong = "Vietnamobile thuc hien CTKM tang 3 ngay nhan Clip Hot mien phi cho 1 khach hang may man dang ky dich vu nhan Clip Hot hang ngay.<br />" +
                                          "Sau 3 ngay, he thong se tu dong gia han dich vu" +
                                          ".<br /> De huy dich vu vui long soan; HUY HT Clip gui 949";
                        doubleDangKy = "Quy khach da dang ky dich vu Clip Hot.<br /> Vui long lien he tong dai 19001255 de biet chi tiet";
                    }
                    else if (madichvu == "HTFUNNY")
                    {
                        ltrTieuDe.Text = "Dich vu truyen Funny";
                        dangkyThanhCong = "(092) Vietnamobile thuc hien CTKM tang 3 ngay nhan truyen funny mien phi cho 1 khach hang may man dang ky dich vu nhan truyen funny hang ngay.<br />" +
                                          "Sau 3 ngay, he thong se tu dong gia han dich vu." +
                                          ".<br /> De huy dich vu vui long soan; HUY HT Funny gui 949";
                        doubleDangKy = "Quy khach da dang ky dich vu Clip Hot.<br /> Vui long lien he tong dai 19001255 de biet chi tiet";
                    }
                    else if (madichvu == "DAVIP")
                    {
                        ltrTieuDe.Text = "Dich vu dia diem an choi";
                        dangkyThanhCong = "(092) Chuc mung QK da DK thanh cong DV DIA DIEM AN CHOI (1000d/ngay). Qkhach duoc MIEN PHI nhan noi dung ngay dau tien trong lan dau dang ky. Thong tin dia diem an choi se duoc gui ve vao 15h hang ngay. De huy DK, soan HUY VIP gui 949.HT: 19001255.<br />";
                        doubleDangKy = "QK da dang ky DV DIA DIEM AN CHOI. Vui long lien he tong dai 19001255 de biet chi tiet";
                    }

                    else if (madichvu == "9GAME")
                    {
                        ltrTieuDe.Text = "Dich vu tai game";
                        dangkyThanhCong = "(092) Chung mung ban da dang ky thanh cong goi dich vu 9GAME gia cuoc 2000d/ngay. Goi dich vu se duoc tu dong gia han hang ngay. De huy dv, soan HUY 9GAME gui 949. HT: 19001255.<br />";
                        doubleDangKy = "QK da dang ky Dich vu tai game. Vui long lien he tong dai 19001255 de biet chi tiet";
                    }
                    else if (madichvu == "PIC")
                    {
                        ltrTieuDe.Text = "Dich vu anh hot";
                        dangkyThanhCong = "(092) Chuc mung. QKhach da Dky thanh cong DV Anh Hot(2000d/ngay). QKhach duoc MIEN PHI 1lan tra KQ dau tien trong lan dau dang ky. Hang ngay KQ se duoc gui ve vao 10h. De huy DK, soan: Huy PIC1 gui 949. HT: 19001255.<br />";
                        doubleDangKy = "QK da dang ky Dich vu anh hot. Vui long lien he tong dai 19001255 de biet chi tiet";
                    }
                    else if (madichvu == "CANH2")
                    {
                        ltrTieuDe.Text = "Dich vu anh hot";
                        dangkyThanhCong = "(092) Chuc mung. QKhach da Dky thanh cong DV DV Anh Hot(2000d/ngay). QKhach duoc MIEN PHI 1lan tra KQ dau tien trong lan dau dang ky. Hang ngay KQ se duoc gui ve vao 10h. De huy DK, soan: Huy ANH2 gui 949. HT: 19001255.<br />";
                        doubleDangKy = "QK da dang ky Dich vu anh hot. Vui long lien he tong dai 19001255 de biet chi tiet";
                    }
                    //string result = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK","DK " + madichvu);//Andy Service S2_94x   
                    string result = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK", regisSystax);//Andy Service S2_94x   

                    string[] arrResult = result.Split('|');

                    if (arrResult[0] == "1")//DK THANH CONG
                    {
                        ltrNoiDung.Text = dangkyThanhCong;
                    }
                    else if (arrResult[0] == "0")//DOUBE DK
                    {
                        ltrNoiDung.Text = doubleDangKy;
                    }
                    else if (arrResult[0] == "-1")//DK THAT BAI - SAI CU PHAP
                    {
                        ltrNoiDung.Text = "Đăng ký không thành công. Vui lòng thử lại <br /> Hoặc soạn tin <b> " + regisSystax + "</b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                    }

                }
                else
                {
                    if(madichvu == "F8")
                    {
                        regisSystax = "DK F8 CLIP";
                    }
                    ltrNoiDung.Text = "Hệ thống không xác định được số điện thoại của bạn <br /> Vui lòng truy cập bằng 3G/GPRS <br /> Hoặc soạn tin <b> " + regisSystax + "</b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                }
            }
        }
    }
}