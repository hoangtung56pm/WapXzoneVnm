using System;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Game
{
    public partial class S2_DangKy : BasePage
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

                if (Session["msisdn"] != null)
                {
                    pnlThongBao.Visible = true;
                    if (lang == "1")
                    {
                        ltrThongBao.Text = "Giới Thiệu";
                        ltrThongBaoNoiDung.Text =
                            "Cung cấp cho quý khách những game mới và hấp dẫn nhất. Hàng tuần, hệ thống sẽ gửi cho bạn 2 game được nhiều người tải nhất vào thứ 2 và thứ 4. (10000đ/tuần) <br/> Miễn phí trải nghiệm 2 Game HOT đầu tiên";

                    }
                    else
                    {
                        ltrThongBao.Text = "Gioi Thieu";
                        ltrThongBaoNoiDung.Text =
                            "Cung cap cho quy khach nhung game moi va hap dan nhat. Hang tuan, he thong se gui cho ban 2 game duoc nhieu nguoi tai nhat vao thu 2 va thu 4. (10000d/tuan) <br/> Mien phi trai nghiem 2 Game HOT dau tien";
                    }
                }
                else
                {
                    pnlSMS.Visible = true;
                    if (lang == "1")
                    {
                        ltrSMS.Text = "Hệ thống không xác định được số điện thoại của bạn. Vui lòng truy cập bằng <b> 3G/GPRS </b> hoặc : <br/> SOẠN TIN :  <b> DK GAME </b> gửi <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                    }
                    else
                    {
                        ltrSMS.Text = "He thong khong xac dinh duoc so dien thoai cua ban. Vui long truy cap bang <b> 3G/GPRS </b> hoac : <br/> SOAN TIN : <b> DK GAME </b> gui <b>" + AppEnv.GetSetting("S2ShortCode") + "</b>";
                    }
                }

            }
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            if (AppEnv.GetSetting("S2Test") == "1")
            {
                Session["S2Result"] = "1";
                Response.Redirect(UrlProcess.GetGameS2RegisterSuccessUrl(lang,width.ToString()));
            }
            else
            {
                string shortCode = AppEnv.GetSetting("S2ShortCode"); //223
                string requestId = AppEnv.GetSetting("S2RequestID");
                string commandCode = AppEnv.GetSetting("S2Commandcode");//DK
                string message = AppEnv.GetSetting("S2DK_Game");
                string msisdn = Session["msisdn"].ToString();

                string reResult = AppEnv.RegisterService(shortCode, requestId, msisdn, commandCode, message);
                string[] arrResult = reResult.Split('|');

                if (arrResult.Length > 0)
                {
                    if (arrResult[0] == "1")
                    {
                        Session["S2Result"] = "1";
                    }
                    else if (arrResult[0] == "0")
                    {
                        Session["S2Result"] = "0";
                    }
                    Response.Redirect(UrlProcess.GetGameS2RegisterSuccessUrl(lang, width.ToString()));
                }
            }

        }

        protected void HienThiNoiDung(Boolean thuchien)
        {
            pnlNoiDung.Visible = true;
            if (thuchien)
            {
                if (lang == "1")
                {
                    ltrNoiDung.Text = "Bạn đã đăng ký thành công. Game HOT sẽ được gửi đến điện thoại của bạn vào 15h thứ 2 và thứ 4 hàng tuần.";
                }
                else
                {
                    ltrNoiDung.Text = "Ban da dang ky thanh cong. Game HOT se duoc gui den dien thoai cua ban vao 15h thu 2 vaf thu 4 hang tuan.";
                }
            }
        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }

        protected void btnQuayLai_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }
    }
}