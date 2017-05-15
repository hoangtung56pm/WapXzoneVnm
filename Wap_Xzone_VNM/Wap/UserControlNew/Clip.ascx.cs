using System;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Wap.UserControlNew
{
    public partial class Clip : System.Web.UI.UserControl
    {
        protected int lang;
        private int hotro;
        protected string width;

        protected void Page_Load(object sender, EventArgs e)
        {

            width = Request.QueryString["w"];
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            hotro = ConvertUtility.ToInt32(Request.QueryString["hotro"]);

            int totalrecord = 0;
            //DataTable dtLatest = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(Session["telco"].ToString(), 1, -1, (int)Constant.Video.Lastest, 15, 1, out totalrecord);

            DataTable dtLatest = VideoController.GetAllVideoByCategoryAndDisplayType(Session["telco"].ToString(), 1, -1, (int)Constant.Video.Lastest, 15, 1, out totalrecord);

            if(dtLatest != null && dtLatest.Rows.Count > 0)
            {

                string gameLink = UrlProcess.GetVideoHomeUrlNew(lang.ToString(), width);

                lnkXemThem.NavigateUrl = gameLink;

                Random rnd = new Random();
                while (dtLatest.Rows.Count > 3)
                {
                    dtLatest.Rows.RemoveAt(rnd.Next(0, dtLatest.Rows.Count));
                    dtLatest.AcceptChanges();
                }

                rptVideo.DataSource = dtLatest;
                rptVideo.ItemDataBound += rptlastest_ItemDataBound;
                rptVideo.DataBind();
            }
        }

        protected void rptlastest_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 2)
            {
                Literal lit = (Literal)e.Item.FindControl("litTable");
                if(lit != null)
                {
                    lit.Text = "<table width=\"100%\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\" bgcolor=\"#FFFFFF\"><tr><td align=\"left\" valign=\"top\"><img alt=\"\" src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr></table>";
                }
            }
        }
    }
}