using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.UrlProcess;
using System.Configuration;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Component.Tintuc;

namespace WapXzone_VNM.Tintuc.UserControl
{
    public partial class Detail : System.Web.UI.UserControl
    {
        private int pagesize = 8;
        private int pagenumber = 3;
        private int curpage = 1;
        private int lang;
        private string width;
        private static string preurl;
        private int catID;
        private int id;
        private string price;
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
                DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(catID);
                //end detail
                if (lang == 1)
                {
                    lnkCatName.Text = catInfo.Rows[0]["Zone_Name"].ToString().ToUpper();
                    lblCat.Text = "TIN ĐÃ ĐĂNG";
                    lblHeadline.Text = dtDetail.Rows[0]["Content_Headline"].ToString();
                    ltrBody.Text = ReplaceImageLink(dtDetail.Rows[0]["Content_Body"].ToString());
                    lnkHomeChannel.Text = "TIN TỨC";

                }
                else
                {
                    lblHeadline.Text = dtDetail.Rows[0]["Content_HeadlineKD"].ToString();
                    ltrBody.Text = ReplaceImageLink(dtDetail.Rows[0]["Content_BodyKD"].ToString());
                    lnkCatName.Text = catInfo.Rows[0]["Zone_Alias"].ToString().ToUpper();
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
                lnkCatName.NavigateUrl = UrlProcess.GetNewsCategoryUrl(lang.ToString(), width, catID.ToString());
                lnkHomeChannel.NavigateUrl = UrlProcess.GetNewsHomeUrl(lang.ToString(), width);
            }
            //start Older News
            DataTable dtCat = TintucController.GetTopNewsOlderByCategoryHasCache(catID,id,4);
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
            lnkTitle.NavigateUrl = UrlProcess.GetNewsDetailUrl(lang.ToString(), "detail", width, curData["Distribution_ID"].ToString());
        }

        public string ReplaceImageLink(string body)
        {
            string urlData = AppEnv.GetSetting("urldata");
            body = body.Replace("/Upload/", urlData + "/Upload/");

            return body;
        }
    }
}