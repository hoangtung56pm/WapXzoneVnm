using System;
using System.Data;
using System.Web.UI.WebControls;
using VmgPortal.Modules.Adsvertising;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Game;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap
{
    public partial class GameDownloadNew : BasePage
    {
        protected int lang;
        protected int width;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);

            Session["LastPage"] = Request.RawUrl;
            if (!IsPostBack)
            {
                width = ConvertUtility.ToInt32(Request.QueryString["w"]);
                if (width == 0)
                {
                    width = (int)Constant.DefaultScreen.Standard;
                }
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                var advertisement1 = new Advertisement { Channel = "Home", Position = "UnderLinks", Param = 0, Lang = lang.ToString(), Width = width.ToString() };
                litAds1.Text = advertisement1.GetAds();

                //
                //var advertisement = new Advertisement { Channel = "Home", Position = "HomeCenter", Param = 0, Lang = lang, Width = width.ToString() };
                //litAds.Text = advertisement.GetAds();

                //var advertisement1 = new Advertisement { Channel = "Home", Position = "UnderLinks", Param = 0, Lang = lang, Width = width.ToString() };
                //litAds1.Text = advertisement1.GetAds();

                DataTable dtGame = GameController.GetAllGame_ByPackageID(ConvertUtility.ToInt32(AppEnv.GetSetting("packageIdGame")));
                if(dtGame.Rows.Count > 0)
                {
                    rptGameFree.DataSource = dtGame;
                    rptGameFree.ItemDataBound += rptGameFree_ItemDataBound;
                    rptGameFree.DataBind();
                }
            }
            //if (string.IsNullOrEmpty(Request.QueryString["display"]))
            //{
            //    display = "home";
            //}
            //else
            //{
            //    display = Request.QueryString["display"];
            //} 
        }

        protected void rptGameFree_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;

            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkFile = (HyperLink) e.Item.FindControl("lnkFile");
            if(lnkFile != null)
            {
                if (lang == 1)
                {
                    lnkFile.Text = curData["Name"].ToString();
                }
                else
                {
                    lnkFile.Text = UnicodeUtility.UnicodeToKoDau(curData["Name"].ToString());
                }

                lnkFile.NavigateUrl = AppEnv.GetSetting("JavaGameDownload") + "?id=" + curData["GameID"] + "&type=3" + "&code=" + SecurityMethod.MD5Encrypt(curData["GameID"].ToString());
            }
        }
    }
}