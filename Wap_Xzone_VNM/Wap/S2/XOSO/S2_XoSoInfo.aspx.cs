using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Xoso;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.S2.XOSO
{
    public partial class S2_XoSoInfo : BasePage
    {
        protected int width;
        protected string lang;

        private string[] city;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);

            if (!IsPostBack)
            {
                if (width == 0)
                {
                    width = ConvertUtility.ToInt32(Constant.DefaultScreen.Standard.ToString());
                }

                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
            }

            city = ConfigurationSettings.AppSettings.Get(DateTime.Now.AddDays(0).DayOfWeek.ToString()).Split(',');
            rptlst.DataSource = city;
            rptlst.ItemDataBound += rptlst_ItemDataBound;
            rptlst.DataBind();
        }

        protected void rptlst_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            string curData = (string) e.Item.DataItem;

            Literal litCityName = (Literal)e.Item.FindControl("litCityName");
            Literal litCityCode = (Literal)e.Item.FindControl("litCityCode");
            Literal litLink = (Literal)e.Item.FindControl("litLink");

            DataTable info = XosoController.GetInfobyCompanyID(ConvertUtility.ToInt32(curData));

            if (lang == "1")
            {
                string code = info.Rows[0]["company_comment"].ToString();
                litCityName.Text = info.Rows[0]["company_name"].ToString().Replace("XS","");
                litCityCode.Text = code;
                litLink.Text = "<a style=\"color:Orange;font-weight:bold;\" href=\"S2_DangKy.aspx?lang=" + lang + "&w=" + width + "&id=" + info.Rows[0]["company_id"] + "\">Đăng ký</a>";
            }
            else
            {
                string code = info.Rows[0]["company_comment"].ToString();
                litCityName.Text = AppEnv.CheckLang(info.Rows[0]["company_name"].ToString().Replace("XS", ""));
                litCityCode.Text = code;
                litLink.Text = "<a style=\"color:Orange;font-weight:bold;\" href=\"S2_DangKy.aspx?lang=" + lang + "&w=" + width + "&id=" + info.Rows[0]["company_id"] + "\">Dang Ky</a>";
            }
        }
    }
}