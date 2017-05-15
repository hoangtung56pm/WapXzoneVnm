using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM
{
    public partial class hotnews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LastUrl"] = HttpContext.Current.Request.RawUrl;
            int totalrecord1;
            DataTable dtTinTongHop = WapXzone_VNM.Library.Component.Tintuc.TintucController.GetAllNewsByCategory(WapXzone_VNM.Library.Utilities.ConvertUtility.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("tintonghop")), 1, 1, out totalrecord1);
            if (dtTinTongHop.Rows.Count > 0)
            {
                lnkTinTongHop.NavigateUrl = UrlProcess.GetNewsDetailUrl("1", "detail", "240", dtTinTongHop.Rows[0]["Distribution_ID"].ToString()).Replace("~/", "");
                //Response.Redirect(UrlProcess.GetNewsDetailUrl("1", "detail", "240", dtTinTongHop.Rows[0]["Distribution_ID"].ToString()).Replace("~/", ""));
            }
        }

        private string GaAccount;
        private const string GaPixel = "ga.aspx";

        public string GoogleAnalyticsGetImageUrl()
        {
            GaAccount = "MO-30173060-1";
            System.Text.StringBuilder url = new System.Text.StringBuilder();
            url.Append(GaPixel + "?");
            url.Append("utmac=").Append(GaAccount);

            Random RandomClass = new Random();
            url.Append("&utmn=").Append(RandomClass.Next(0x7fffffff));

            string referer = "-";
            if (Request.UrlReferrer != null
                 && "" != Request.UrlReferrer.ToString())
            {
                referer = Request.UrlReferrer.ToString();
            }
            url.Append("&utmr=").Append(HttpUtility.UrlEncode(referer));

            if (HttpContext.Current.Request.Url != null)
            {
                url.Append("&utmp=").Append(HttpUtility.UrlEncode(Request.Url.PathAndQuery));
            }

            url.Append("&guid=ON");

            return url.ToString();
        }
    }
}
