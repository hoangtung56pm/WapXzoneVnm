using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.UserControlNew
{
    public partial class TinTuc : System.Web.UI.UserControl
    {
        protected int lang;
        private int hotro;
        protected string width;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                width = Request.QueryString["w"];
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                hotro = ConvertUtility.ToInt32(Request.QueryString["hotro"]);

                DataTable dt = TintucController.GetTopNewsHasCache(ConvertUtility.ToInt32(AppEnv.GetSetting("news_zoneid")), 2);
                if(dt != null && dt.Rows.Count > 0)
                {
                    string newsLink = UrlProcess.GetNewsHomeUrlNew(lang.ToString(), width);

                    lnkXemThem.NavigateUrl = newsLink;

                    rptTinTuc.DataSource = dt;
                    rptTinTuc.DataBind();
                }
            }
        }
    }
}