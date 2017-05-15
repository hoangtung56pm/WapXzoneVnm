using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Entity;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thugian
{
    public partial class CungHoangDao : BasePage
    {
        private int width;
        private string lang;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);

            if (!Page.IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                pnlSMS.Visible = true;
                //Sửa bỏi Bình Trần - 25/11/2016 
                //if (Session["msisdn"] != null)
                //{
                //    string value = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK", "DK XEMHD");//ANDY Service S2_94x
                //    string[] res = value.Split('|');
                //    if (res.Length > 0)
                //    {
                //        ltrHuongdan.Text = lang == "1" 
                //                ? "Hoàng Đạo" 
                //                : "Hoang Dao";

                //        if (res[0] == "1")//DK THANH CONG
                //        {
                //            ltrSMS.Text = lang == "1"
                //                       ? "Bạn đã đăng ký thành công. Miễn phí trong 7 ngày đầu đăng kí. Thong tin Cung Hoàng Đạo se được gửi về vào 8h hàng ngày <br/> Để hủy dịch vụ soạn: <b> HUY XEMHD </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                //                       : "Ban da dang ky thanh cong. Mien phi trong 7 ngay dau dang ki. Thong tin Cung Hoang Dao se duoc gui ve vao 8h hang ngay <br/> De huy dich vu soan: <b> HUY XEMHD </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                //        }
                //        else
                //        {
                //            if (res[1].Trim() == "DoubleRegister")
                //            {
                //                ltrSMS.Text = lang == "1"
                //                    ? "Bạn đã là thuê bao của dịch vụ Cung Hoàng Đạo. Xin cảm ơn <br/> Để hủy dịch vụ soạn tin : <b> HUY XEMHD </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>"
                //                    : "Ban da la thue bao cua dich vu Cung Hoang Dao. Xin cam on <br/> De huy dich vu soan tin : <b> HUY XEMHD </b> gui <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                //            }
                //            else
                //            {
                //                ltrSMS.Text = AppEnv.GetSetting("VNM_DangKyThatBai_Mt");
                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    ltrHuongdan.Text = lang == "1"
                //                           ? "Giới Thiệu"
                //                           : "Gioi Thieu"; 

                //    ltrSMS.Text = lang == "1"
                //                      ? "Cung hoàng đạo cực HOT. Đăng ký một lần nhận tin mãi mãi <br/> Để đăng ký soạn tin: <b> DK XEMHD </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                //                      : "Cung hoang dao cuc HOT. Dang ky mot lan nhan tin mai mai <br/> De dang ky soan tin: <b> DK XEMHD </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                //}
            }
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }
    }
}