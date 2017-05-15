using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WapXzone_VNM.Library.UrlProcess;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Component.Tintuc;

namespace WapXzone_VNM.Music.UserControl
{
    public partial class NewsDetail : System.Web.UI.UserControl
    {        
        private int lang;
        private string width;
        private static string preurl;
        private int catID;
        private int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            preurl = ConfigurationSettings.AppSettings.Get("urldata");
            width = Request.QueryString["w"];

            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                //Detail
                DataTable dtDetail = TintucController.GetNewsDetailHasCache(id);
                catID = ConvertUtility.ToInt32(dtDetail.Rows[0]["Distribution_ZoneID"]);                
                //end detail
                if (lang == 1)
                {                    
                    lblCat.Text = "TIN ĐÃ ĐĂNG";
                    lblHeadline.Text = dtDetail.Rows[0]["Content_Headline"].ToString();
                    ltrBody.Text = dtDetail.Rows[0]["Content_Body"].ToString();

                }
                else
                {
                    lblHeadline.Text = dtDetail.Rows[0]["Content_HeadlineKD"].ToString();
                    ltrBody.Text = dtDetail.Rows[0]["Content_BodyKD"].ToString();
                }
                if (!string.IsNullOrEmpty(dtDetail.Rows[0]["Content_Avatar"].ToString()))
                {
                    WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
                    ws.GenerateAvatarThumnail(dtDetail.Rows[0]["Content_Avatar"].ToString(), 60, 60);
                    imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(dtDetail.Rows[0]["Content_Avatar"].ToString(), 60, 60).Replace("~", "");
                }
                else
                {
                    imgAvatar.Visible = false;
                }

                lblCreatedOn.Text = ConvertUtility.ToDateTime(dtDetail.Rows[0]["Content_CreateDate"]).ToString("dd/MM/yyyy");                
            }
            //start Older News
            DataTable dtCat = TintucController.GetTopNewsOlderByCategoryHasCache(catID ,id, 5);
            rptlstCategory.DataSource = dtCat;
            rptlstCategory.ItemDataBound += new RepeaterItemEventHandler(rptlstCategory_ItemDataBound);
            rptlstCategory.DataBind();
            //start Older News
        }
        protected void rptlstCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkTitle = (HyperLink)e.Item.FindControl("lnkTitle");
            if (lang == 1)
            {
                lnkTitle.Text = curData["Content_Headline"].ToString();
            }
            else
            {
                lnkTitle.Text = curData["Content_HeadlineKD"].ToString();
            }
            lnkTitle.NavigateUrl = UrlProcess.GetMusicNewsDetailUrl(lang.ToString(), width, curData["Distribution_ID"].ToString());
        }
    }
}