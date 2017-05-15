using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Xoso;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Xoso
{
    public partial class KetQua : BasePage
    {
        private int width;
        private string lang;
        private int id;
        private DataTable info;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);

            id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            info = XosoController.GetInfobyCompanyID(ConvertUtility.ToInt32(id));

            if (!Page.IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                pnlSMS.Visible = true;

                string code = info.Rows[0]["Company_Comment"].ToString().ToUpper();

                if (Session["msisdn"] != null)
                {
                    string subCode = "DK " + code.Trim();

                    string value = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK", subCode);//ANDY Service S2_94x
                    string[] res = value.Split('|');
                    if (res.Length > 0)
                    {
                        ltrHuongdan.Text = lang == "1" ? "Xổ Số" : "Xo So";
                        if (res[0] == "1")//DK THANH CONG
                        {
                            ltrSMS.Text = lang == "1" 
                                ? "Bạn đã đăng ký thành công. Kết quả xổ số <b> " + info.Rows[0]["company_name"].ToString().Replace("XS", "") + " </b> sẽ trả về vào những ngày quay thưởng. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY " + info.Rows[0]["company_comment"].ToString().Replace("XS", "") + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                                : "Ban da dang ky thanh cong. Ket qua xo so <b>" + AppEnv.CheckLang(info.Rows[0]["company_name"].ToString().Replace("XS", "")) + " </b> se tra ve vao nhung ngay quay thuong. <br/> De huy dich vu vui long soan: <b> HUY " + info.Rows[0]["company_comment"].ToString().Replace("XS", "") + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                        }
                        else
                        {
                            if (res[1].Trim() == "DoubleRegister")
                            {
                                ltrSMS.Text = lang == "1" 
                                    ? "Bạn đã là thuê bao của dịch vụ kết quả xổ số hàng ngày. Xin cảm ơn <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY " + info.Rows[0]["company_comment"].ToString().Replace("XS", "") + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>"
                                    : "Ban da la thue bao cua dich vu ket qua xo so hang ngay. Xin cam on <br/> De huy dich vu vui long soan: <b> HUY " + info.Rows[0]["company_comment"].ToString().Replace("XS", "") + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                            }
                            else
                            {
                                ltrSMS.Text = AppEnv.GetSetting("VNM_DangKyThatBai_Mt");
                            }
                        }
                    }
                }
                else
                {
                    ltrHuongdan.Text = lang == "1" ? "Giới Thiệu" : "Gioi Thieu";
                    ltrSMS.Text = lang == "1"
                                      ? "Cung cấp kết quả xổ số nhanh chóng và hiệu quả. Đăng ký một lần nhận tin mãi mãi <br/> Để đăng ký soạn tin: <b> DK " + code + " </b> gửi <b> 949 </b>"
                                      : "Cung cap ket qua xo so nhanh chong va hieu qua. Dang ky mot lan nhan tin mai mam <br/> De dang ky soan tin: <b> DK " + code + " </b> gui <b> 949 </b>";
                }
            }
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }
    }
}