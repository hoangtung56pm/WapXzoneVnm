using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI.WebControls;
using HtmlAgilityPack;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Tintuc.UserControl
{
    public partial class DetailNews : System.Web.UI.UserControl
    {

        private int pagesize = 8;
        private int pagenumber = 3;
        private int curpage = 1;
        private static int lang;
        private static string width;
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
                //DataTable dtDetail = TintucController.GetNewsDetailHasCache(id);
                //catID = ConvertUtility.ToInt32(dtDetail.Rows[0]["Distribution_ZoneID"]);
                //DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(catID);

                DataSet ds = ThethaoController.GetNewsDetailHasCache(id);
                DataTable dtInfor = ds.Tables[0];
                DataTable dtList = ds.Tables[1];

                //end detail

                if (lang == 1)
                {
                    //lnkCatName.Text = catInfo.Rows[0]["Zone_Name"].ToString().ToUpper();
                    lblCat.Text = "TIN ĐÃ ĐĂNG";
                    lblHeadline.Text = dtInfor.Rows[0]["Content_Headline"].ToString();
                    ltrBody.Text = ReplaceImageSource(dtInfor.Rows[0]["Content_Body"].ToString());
                    lnkHomeChannel.Text = "TIN TỨC";
                }
                else
                {
                    lblHeadline.Text = dtInfor.Rows[0]["Content_HeadlineKD"].ToString();
                    ltrBody.Text = ReplaceImageSource(dtInfor.Rows[0]["Content_BodyKD"].ToString());
                    //lnkCatName.Text = catInfo.Rows[0]["Zone_Alias"].ToString().ToUpper();
                }
                if (!string.IsNullOrEmpty(dtInfor.Rows[0]["Content_Avatar"].ToString()))
                {
                    //WapXzone_VNM.CreateAvatar.MOReceiver ws = new WapXzone_VNM.CreateAvatar.MOReceiver();
                    //ws.GenerateAvatarThumnail(dtDetail.Rows[0]["Content_Avatar"].ToString(), 60, 60);
                    //imgAvatar.ImageUrl = preurl + MultimediaUtility.GetAvatarThumnail(dtDetail.Rows[0]["Content_Avatar"].ToString(), 60, 60).Replace("~", "");
                    imgAvatar.ImageUrl = AppEnv.GetAvatarTheThaoSo(dtInfor.Rows[0]["Content_Avatar"].ToString(), 60, 60);
                }
                else
                {
                    imgAvatar.Visible = false;
                }

                lblCreatedOn.Text = ConvertUtility.ToDateTime(dtInfor.Rows[0]["Content_CreateDate"]).ToString("dd/MM/yyyy hh:mm");
                //lnkCatName.NavigateUrl = UrlProcess.GetNewsCategoryUrl(lang.ToString(), width, catID.ToString());
                lnkHomeChannel.NavigateUrl = UrlProcess.GetLastestNewsTheThaoSo(lang.ToString(), width);

                //start Older News
                rptlstCategory.DataSource = dtList;
                rptlstCategory.ItemDataBound += rptlstCategory_ItemDataBound;
                rptlstCategory.DataBind();
                //start Older News
            }

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
            lnkTitle.NavigateUrl = UrlProcess.GetNewsDetailUrlTheThaoSo(lang.ToString(), width, curData["Distribution_ID"].ToString());
        }

        #region Public Methods

        protected string ReplaceImageSource(string body)
        {

            List<string> imgSrc = AppEnv.GetSrc(body);

            foreach (var item in imgSrc)
            {
                string tem = item.Replace("http://media.xzone.vn:9002/", "");
                if (tem.IndexOf("http://") > -1)
                {
                    Match match = Regex.Match(body, "<img.*?src=\"" + item + "\".*?>", RegexOptions.RightToLeft);

                    if (match.Success)
                    {
                        string olgImg = match.Value.Substring(0, match.Value.IndexOf('>') + 1);
                        body = body.Replace(olgImg, "<div  style=\"text-align:center;\"><img src=\"" + item + "\" width=\"300px;\"/></div>");
                    }
                    else
                    {
                        body = body.Replace(item, item + "\" width=\"300px;\"");
                    }
                }
                else
                {

                    string newSrc = AppEnv.GetAvatarWaterMark(tem, ConvertUtility.ToInt32(width));

                    Match match = Regex.Match(body, "<img.*?src=\"" + item + "\".*?>", RegexOptions.RightToLeft);

                    if (match.Success)
                    {
                        string olgImg = match.Value.Substring(0, match.Value.IndexOf('>') + 1);
                        body = body.Replace(olgImg, "<div  style=\"text-align:center;\"><img width=\"310px\" src=\"" + newSrc + "\"/></div>");
                    }
                }
            }

            string temp = ReplaceLinkRelateNew(body).Replace("font-size: small;", "");
            return (temp);
        }

        private static string ReplaceLinkRelateNew(string body)
        {
            var document = new HtmlDocument();
            document.LoadHtml(body);
            var nodes = document.DocumentNode.SelectNodes(@"//a[@href]");
            if (nodes != null)
            {
                foreach (var img in nodes)
                {
                    HtmlAttribute url = img.Attributes["href"];
                    string oldLink = url.Value;

                    string value = url.Value.ToLower().Replace("http://thethaoso.vn", "");

                    if (value.Contains("&amp;key="))
                    {
                        string[] keys = value.Split('=');
                        if (keys.Length > 2)
                        {
                            string key = keys[2];
                            string newLink = "#";

                            body = body.Replace(oldLink, newLink);
                        }
                    }
                    else
                    {
                        string[] arr = value.Split('_');
                        if (arr.Length >= 2)
                        {
                            string id = arr[1].Replace(".html", "");

                            string newLink = UrlProcess.GetNewsDetailUrlTheThaoSo(lang.ToString(),width,id);

                            body = body.Replace(oldLink, newLink);
                        }
                    }
                }
            }

            return body;
        }

        #endregion

    }
}