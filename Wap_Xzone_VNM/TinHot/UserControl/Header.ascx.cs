using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.TinHot.UserControl
{
    public partial class Header : System.Web.UI.UserControl
    {
        private int count;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["msisdn"] == null)
                {
                    int is3g = 0;
                    string msisdn = MobileUtils.GetMSISDN(out is3g);
                    if (!string.IsNullOrEmpty(msisdn) && MobileUtils.CheckOperator(msisdn, "vietnammobile"))
                    {
                        Session["telco"] = Constant.T_Vietnamobile;
                        Session["msisdn"] = msisdn;
                        ltrXinChao.Text = msisdn;
                    }
                    else
                    {
                        Session["msisdn"] = null;
                        Session["telco"] = Constant.T_Undefined;
                        ltrXinChao.Text = "Khách";
                    }
                }
                else
                {
                    ltrXinChao.Text = Session["msisdn"].ToString();
                }


                DataTable dtlatest = TintucController.GetTopNewsHasCache(ConvertUtility.ToInt32(System.Configuration.ConfigurationSettings.AppSettings.Get("vnm_zoneid")), 3);
                count = dtlatest.Rows.Count;
                rptHotNews.DataSource = dtlatest;
                rptHotNews.ItemDataBound += rptHotnews_ItemDataBound;
                rptHotNews.DataBind();

                DataTable dtAdv = WapController.WapVnmGetAdvByPosId(ConvertUtility.ToInt32(AppEnv.GetSetting("WapVnm_Top")));
                if (dtAdv != null && dtAdv.Rows.Count > 0)
                {
                    string url = AppEnv.GetSetting("urldata") + dtAdv.Rows[0]["Advertise_Path"];

                    string str = "<a class=\"noelbanner\" href=\"" + dtAdv.Rows[0]["Advertise_RedirectUrl"] + "\">";


                    if (AppEnv.isMobileBrowser())
                    {
                        str += "<img width=\"" + "99%" + "\" height=\"" + dtAdv.Rows[0]["Advertise_Height"] + "\" src=\"" + url + "\" border=\"0\" /></a>";
                    }
                    else
                    {
                        str += "<img width=\"" + dtAdv.Rows[0]["Advertise_Width"] + "\" height=\"" + dtAdv.Rows[0]["Advertise_Height"] + "\" src=\"" + url + "\" border=\"0\" /></a>";
                    }

                    litAdvTop.Text = str;
                }
            }
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

            lnkHotnews.Text = curData["Content_Headline"].ToString();

            lnkHotnews.NavigateUrl =
                UrlProcess.TinTucChiTiet(ConvertUtility.ToInt32(curData["Distribution_ID"].ToString()),
                                         curData["Content_Headline"].ToString());
        }

    }
}