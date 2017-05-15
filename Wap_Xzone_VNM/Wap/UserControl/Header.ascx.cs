using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Component.Tintuc;
using System.Data;
using WapXzone_VNM.Library.Component.Game;

namespace WapXzone_VNM.Wap.UserControl
{
    public partial class Header : System.Web.UI.UserControl
    {       
        private int count;
        protected string lang;
        protected string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]).ToString();
            width = ConvertUtility.ToInt32(Request.QueryString["w"]).ToString();

            //lnkWap3g.NavigateUrl = UrlProcess.GetWapHomeUrlNew(lang, width);
            lnkWap3g.NavigateUrl = AppEnv.GetSetting("WapDefault");


            #region GET MSISDN

            if (Session["msisdn"] == null)
            {
                int is3g = 0;
                string msisdn1 = MobileUtils.GetMSISDN(out is3g);
                if (!string.IsNullOrEmpty(msisdn1) && MobileUtils.CheckOperator(msisdn1, "vietnammobile"))
                {
                    Session["telco"] = Constant.T_Vietnamobile;
                    Session["msisdn"] = msisdn1;
                }
                else
                {
                    Session["msisdn"] = null;
                    Session["telco"] = Constant.T_Undefined;
                }
            }

            #endregion


            //if (!IsPostBack)
            //{                
                DataTable dtlatest = TintucController.GetTopNewsHasCache(ConvertUtility.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("vnm_zoneid")), 3);
                count = dtlatest.Rows.Count;
                rptHotnews.DataSource = dtlatest;
                rptHotnews.ItemDataBound += new RepeaterItemEventHandler(rptHotnews_ItemDataBound);
                rptHotnews.DataBind();

                string msisdn = ConvertUtility.ToString(Session["msisdn"]);

                if (lang == "1")
                {
                    if (string.IsNullOrEmpty(msisdn))
                        ltrXinChao.Text = "Xin chào <span class=\"pink bold\">khách</span>";
                    else ltrXinChao.Text = "Xin chào thuê bao <span class=\"pink bold\">" + msisdn + "</span>";
                }
                else
                {
                    if (string.IsNullOrEmpty(msisdn))
                        ltrXinChao.Text = "Xin chao <span class=\"pink bold\">khach</span>";
                    else ltrXinChao.Text = "Xin chao thue bao <span class=\"pink bold\">" + msisdn + "</span>";                    
                    lnkTrangChu.Text = "Trang chu";
                    //lnkGame.Text = lnkGame.Text;
                    lnkNhac.Text = "Nhac";
                    //lnkKetQua.Text = "Hen ho";                
                }

                lnkTrangChu.NavigateUrl = AppEnv.GetSetting("WapDefault");
                lnkGame.NavigateUrl = "http://vmgame.vn/wap/home/s2register";
                lnkNhac.NavigateUrl = UrlProcess.GetMusicHomeUrl(lang, width);
                //lnkKetQua.NavigateUrl = UrlProcess.GetSportHomeUrl(lang, "home", width);
                //lnkKetQua.NavigateUrl = "http://visport.vn/";
                
                string[] Kenh = Request.Url.AbsolutePath.Split(new Char[] { '/' });
                switch (Kenh[1].ToLower())
                {
                    case "music":
                        ddlDataType.SelectedIndex = 0;
                        break;
                    case "hinhnen":
                        ddlDataType.SelectedIndex = 1;
                        break;
                    case "game":
                        ddlDataType.SelectedIndex = 2;
                        break;
                    case "phanmem":
                        ddlDataType.SelectedIndex = 3;
                        break;
                    case "video":
                        ddlDataType.SelectedIndex = 4;
                        break;
                }


            DataTable dtAdv = WapController.WapVnmGetAdvByPosId(ConvertUtility.ToInt32(AppEnv.GetSetting("WapVnm_Top")));
            if(dtAdv != null && dtAdv.Rows.Count > 0)
            {
                string url = AppEnv.GetSetting("urldata") + dtAdv.Rows[0]["Advertise_Path"];

                string str = "<a class=\"noelbanner\" href=\"" + dtAdv.Rows[0]["Advertise_RedirectUrl"] + "\">";
                

                if(AppEnv.isMobileBrowser())
                {
                    str += "<img width=\"" + "99%" + "\" height=\"" + dtAdv.Rows[0]["Advertise_Height"] + "\" src=\"" + url + "\" border=\"0\" /></a>";
                }
                else
                {
                    str += "<img width=\"" + dtAdv.Rows[0]["Advertise_Width"] + "\" height=\"" + dtAdv.Rows[0]["Advertise_Height"] + "\" src=\"" + url + "\" border=\"0\" /></a>";
                }

                litAdvTop.Text = str;
            }

            //}            
        }

        protected void rptHotnews_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkHotnews = (HyperLink)e.Item.FindControl("lnkHotnews");
            Literal ltrSeprator = (Literal)e.Item.FindControl("ltrSeprator");
            if (e.Item.ItemIndex + 1 < count)
            {
                ltrSeprator.Text = "&nbsp;|&nbsp;";
            }

            if (lang == "1")
            {
                lnkHotnews.Text = curData["Content_Headline"].ToString();
            }
            else
            {
                lnkHotnews.Text = curData["Content_HeadlineKD"].ToString();
            }
            lnkHotnews.NavigateUrl = UrlProcess.GetNewsDetailUrl(lang, "detail", width, curData["Distribution_ID"].ToString());
        }

        protected void btnSearch_Click(object sender, ImageClickEventArgs e)
        {
            switch (ddlDataType.SelectedValue)
            {
                case "1":
                    Response.Redirect(UrlProcess.GetMusicSearchResultUrl(lang, width, txtKeyword.Text.Trim(),"0"));
                    break;
                case "2":
                    Response.Redirect(UrlProcess.GetWallpaperSearchResultUrl(lang, width, txtKeyword.Text.Trim()));
                    break;
                case "3":
                    Response.Redirect(UrlProcess.GetGameSearchResultUrl(lang, width, txtKeyword.Text.Trim(), "0"));
                    break;
                case "4":
                    Response.Redirect(UrlProcess.GetAppSearchResultUrl(lang, width, txtKeyword.Text.Trim(), "0"));
                    break;
                case "5":
                    Response.Redirect(UrlProcess.GetVideoSearchResultUrl(lang, width, txtKeyword.Text.Trim()));
                    break;
            }
            
        }
    }
}