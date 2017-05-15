using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Xoso;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Xoso
{
    public partial class ThongKeHigh : BasePage
    {
        //private int width;
        //private string lang;
        private int id;
        private DataTable info;

        protected void Page_Load(object sender, EventArgs e)
        {
            //lang = Request.QueryString["lang"];
            //width = ConvertUtility.ToInt32(Request.QueryString["w"]);

            id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            info = XosoController.GetInfobyCompanyID(ConvertUtility.ToInt32(id));

            if (!Page.IsPostBack)
            {
                //if (width == 0)
                //    width = (int)Constant.DefaultScreen.Standard;
                //ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                pnlSMS.Visible = true;

                if (Session["msisdn"] != null)
                {
                    string subCode = "DK SC " + info.Rows[0]["Company_Comment"];

                    string value = AppEnv.RegisterService(AppEnv.GetSetting("S2ShortCode"), "0", Session["msisdn"].ToString(), "DK", subCode);//ANDY Service S2_94x
                    string[] res = value.Split('|');
                    if (res.Length > 0)
                    {
                        ltrHuongdan.Text = "Thống kê cặp số";
                        if (res[0] == "1")//DK THANH CONG
                        {
                            ltrSMS.Text = "Bạn đã đăng ký thành công. Dự đoán kết quả xổ số <b> " +
                                          info.Rows[0]["company_name"].ToString().Replace("XS", "") +
                                          " </b> sẽ trả về vào những ngày quay thưởng. <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY SC " +
                                          info.Rows[0]["company_comment"].ToString().Replace("XS", "") +
                                          " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + " </b>";
                        }
                        else
                        {
                            if (res[1].Trim() == "DoubleRegister")
                            {
                                ltrSMS.Text =
                                    "Bạn đã là thuê bao của dịch vụ soi cầu hàng ngày. Xin cảm ơn <br/> Để hủy dịch vụ vui lòng soạn: <b> HUY SC " +
                                    info.Rows[0]["company_comment"].ToString().Replace("XS", "") + " </b> gửi <b> " +
                                    AppEnv.GetSetting("S2ShortCode") + " </b>";
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
                    //if (lang == "1")
                    //{
                        ltrHuongdan.Text = "Thống kê cặp số";
                        ltrSMS.Text = "Cung cấp dự đoán kết quả xổ số <b> " + info.Rows[0]["company_name"].ToString().Replace("XS", "") + " </b> nhanh chóng, chính xác, thuận tiện. Tư vấn và nhận định cặp số sẽ về trong ngày hiện tại.Đăng ký một lần nhận tin mãi mãi <br/> Miễn phí 7 lần trả KQ đầu tiên.<br/>Vui lòng truy cập bằng <b> 3G/GPRS </b> hoặc : <br/> SOẠN TIN :  <b> DK SC " + info.Rows[0]["company_comment"] + " </b> gửi <b> " + AppEnv.GetSetting("S2ShortCode") + "</b>";
                    //}
                    //else
                    //{
                    //    ltrHuongdan.Text = "Thong ke cap so";
                    //    ltrSMS.Text = "Cung cap du doan ket qua xo so <b> " + AppEnv.CheckLang(info.Rows[0]["company_name"].ToString().Replace("XS", "")) + " </b> nhanh chong, chinh xac, thuan tien. Ket qua se duoc gui ngay toi khach hang sau khi mo thuong. Dang ky mot lan nhan tin mai mai <br/> Mien phi 7 lan tra KQ dau tien.<br/>Vui long truy cap bang <b> 3G/GPRS </b> hoac : <br/> SOAN TIN : <b> DK SC " + AppEnv.CheckLang(info.Rows[0]["company_comment"].ToString()) + " </b> gui <b> " + AppEnv.GetSetting("S2ShortCode") + "</b>";
                    //}
                }
            }
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }
    }
}