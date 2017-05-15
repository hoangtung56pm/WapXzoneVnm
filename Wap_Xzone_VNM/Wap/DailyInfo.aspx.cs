using System;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Wap
{
    public partial class DailyInfo : BasePage
    {
        protected string lang;
        protected string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = Request.QueryString["w"];
            //if (!IsPostBack)
            //{
                if (width == "0")
                {
                    width = Constant.DefaultScreen.Standard.ToString();
                }

                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
            //}
            if (lang == "1")
            {
                ltrDichVu.Text = "Các dịch vụ DailyInfo";
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //if(!string.IsNullOrEmpty(txtMsisdn.Text.Trim()))
            //{
            //    DataTable dt = WapController.WapVnmGetGiftCodeByMsisdn(txtMsisdn.Text.Trim());
            //    if(dt != null && dt.Rows.Count > 0)
            //    {
            //        rptGiftCode.DataSource = dt;
            //        rptGiftCode.DataBind();
            //    }
            //    else
            //    {
            //        lblThongBao.Visible = true;
            //        lblThongBao.Text = AppEnv.CheckLang("Hiện tại bạn không có mã dự thưởng nào");
            //    }
            //}
        }
    }
}