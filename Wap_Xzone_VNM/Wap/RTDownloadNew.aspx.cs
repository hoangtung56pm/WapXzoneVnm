using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Modules.Adsvertising;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Nhacchuong;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap
{
    public partial class RTDownloadNew : BasePage
    {
        private int width;
        private string display;
        private string lang;   
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["LastPage"] = Request.RawUrl;
            lang = Request.QueryString["lang"];
            if (!IsPostBack)
            {
                width = ConvertUtility.ToInt32(Request.QueryString["w"]);
                if (width == 0)
                {
                    width = (int)Constant.DefaultScreen.Standard;
                }
                ltrWidth.Text = "<meta content=\"width=" + width + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";
                //

                //var advertisement = new Advertisement { Channel = "Home", Position = "HomeCenter", Param = 0, Lang = lang, Width = width.ToString() };
                //litAds.Text = advertisement.GetAds();

                var advertisement1 = new Advertisement { Channel = "Home", Position = "UnderLinks", Param = 0, Lang = lang, Width = width.ToString() };
                litAds1.Text = advertisement1.GetAds();

                DataTable dtMusic = RTController.GetAllWap_RingTone_ByPackageID(ConvertUtility.ToInt32(AppEnv.GetSetting("packageId")));
                if(dtMusic.Rows.Count > 0)
                {
                    rptRingTone.DataSource = dtMusic;
                    rptRingTone.ItemDataBound += rptRingTone_ItemDataBound;
                    rptRingTone.DataBind();
                }
            }
        }

        protected void rptRingTone_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkFile = (HyperLink)e.Item.FindControl("lnkFile");
            if (lnkFile != null)
            {
                if (lang == "1")
                {
                    lnkFile.Text = curData["SongName"].ToString();
                }
                else
                {
                    lnkFile.Text = UnicodeUtility.UnicodeToKoDau(curData["SongName"].ToString());
                }

                lnkFile.NavigateUrl = AppEnv.GetSetting("urldata") + curData["Path"].ToString().Replace("~/", "");
            }
        }
    }
}