using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library;

using System.Configuration;
using System.Data;
using WapXzone_VNM.Library.Component.HoangDao;
using WapXzone_VNM.Library.Component.Transaction;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Component.Wap;
using log4net;

namespace WapXzone_VNM.TinTuc247
{
    public partial class Download : BasePage
    {
        private int width;
        private string lang;
        private int id;
        private int catID;
        private int parentCatID;
        private string price;
        private string telCo;
        private string chitietGiaodich;
        private string messageReturn = string.Empty;
        private string linkStr, linkStr_KD;

        private string ProductId;
        private string Keyword;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                lang = Request.QueryString["lang"];
                width = ConvertUtility.ToInt32(Request.QueryString["w"]);
                price = ConfigurationSettings.AppSettings.Get("relaxsexprice");
                id = ConvertUtility.ToInt32(Request.QueryString["id"]);
                telCo = Session["telco"].ToString();

                DataTable dtDetail = TintucController.GetNewsDetailHasCache(id);
                catID = ConvertUtility.ToInt32(dtDetail.Rows[0]["Distribution_ZoneID"]);
                DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(catID);
                parentCatID = ConvertUtility.ToInt32(catInfo.Rows[0]["Zone_ParentID"]);
                chitietGiaodich = "Thu gian: " + catInfo.Rows[0]["Zone_Name"].ToString() + " -- id: " + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
                linkStr = "<a href=\"../" + UrlProcess.GetTinTucNewHomeUrl(lang, width.ToString()).Replace("~/", "") + "\" >TIN TỨC<a>";
                linkStr_KD = "<a href=\"../" + UrlProcess.GetTinTucNewHomeUrl(lang, width.ToString()).Replace("~/", "") + "\" >TIN TUC<a>";

                if (!IsPostBack)
                {
                    if (width == 0)
                        width = (int)Constant.DefaultScreen.Standard;
                    ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                    //                
                    if (telCo == "Undefined")
                    {
                        pnlSMS.Visible = true;
                        if (lang == "1")
                        {
                            ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                            ltrSMS.Text = "Bạn vui lòng soạn tin theo cú pháp <b>TTHN</b> gửi <b>8579</b>";
                        }
                        else
                        {
                            ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                            ltrSMS.Text = "Ban vui long soan tin theo cu phap <b>TTHN</b> gửi <b>8579</b>";
                        }
                    }
                    else
                    {
                        if (IsCharging(Session["msisdn"].ToString()) == false)
                        {
                            WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                            messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), ProductId, Keyword, price, "D", "RELAX", Request.QueryString["id"]);

                            if (messageReturn == "1")
                            {// Thanh toán thành công >> trả nội dung                                    
                                HienThiNoiDung(true, true);
                            }
                            else
                            {
                                TintucController.Cancel(Session["msisdn"].ToString());
                                // Thanh toán không thành công >> thông báo lỗi
                                HienThiNoiDung(false, true);
                            }
                        }
                        else
                        {
                            HienThiNoiDung(true, true);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ILog logger = log4net.LogManager.GetLogger("File");
                logger.Debug("--------------------------------------------------");
                logger.Debug("ex:" + ex.Message);
            }
            
        }

        private bool IsCharging(string msisdn)
        {
            return TintucController.CheckIsCharging(msisdn);
        }


        protected void HienThiNoiDung(Boolean thuchien, Boolean log)
        {
            pnlNoiDung.Visible = true;

            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            DataTable dtDetail = TintucController.GetNewsDetail(id);
            catID = ConvertUtility.ToInt32(dtDetail.Rows[0]["Distribution_ZoneID"]);
            DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(catID);

            if (thuchien)
            {
                if (lang == "1")
                {
                    ltrTieuDe.Text = linkStr + " » " + "TIN TỨC";
                    lblCat.Text = "TIN ĐÃ ĐĂNG";
                    lblTen.Text = dtDetail.Rows[0]["Content_Headline"].ToString();
                    if (dtDetail.Rows.Count > 0) { ltrNoiDung.Text = dtDetail.Rows[0]["Content_Body"].ToString().Replace("href=\"Upload", "href=\"" + ConfigurationSettings.AppSettings.Get("urldata") + "/Upload"); }
                }
                else
                {
                    ltrTieuDe.Text = linkStr_KD + " » " + "TIN TUC";
                    lblTen.Text = dtDetail.Rows[0]["Content_HeadlineKD"].ToString();
                    if (dtDetail.Rows.Count > 0) { ltrNoiDung.Text = dtDetail.Rows[0]["Content_BodyKD"].ToString().Replace("href=\"Upload", "href=\"" + ConfigurationSettings.AppSettings.Get("urldata") + "/Upload"); }
                };
                if (log) Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 13);

                //start Older News
                DataTable dtCat = TintucController.GetTopNewsOlderByCategoryHasCache(catID, id, 4);
                rptlstCategory.DataSource = dtCat;
                rptlstCategory.ItemDataBound += new RepeaterItemEventHandler(rptlstCategory_ItemDataBound);
                rptlstCategory.DataBind();
            }
            else
            {
                //Thông báo lỗi thanh toán
                if (lang == "1")
                {
                    ltrTieuDe.Text = linkStr + " » " + Resources.Resource.wThongBao;
                    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan;
                }
                else
                {
                    ltrTieuDe.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
                    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                }
                //--Thông báo lỗi thanh toán
                if (log) Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 13, messageReturn);
            }
            if (log)
            {
                //log charging                                 
                ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
                logger.Debug("--------------------------------------------------");
                logger.Debug("MSISDN:" + Session["msisdn"].ToString());
                logger.Debug("Dich vu: Thu gian - parameter: " + price + " - Ten: " + dtDetail.Rows[0]["Content_HeadlineKD"].ToString() + " - id: " + id);
                logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                logger.Debug("Error:" + messageReturn);
                logger.Debug("Current Url:" + Request.RawUrl);
                //end log
            }
        }

        protected void rptlstCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkTitle = (HyperLink)e.Item.FindControl("lnkTitle");
            if (lang == "1")
            {
                lnkTitle.Text = curData["Content_Headline"].ToString();
            }
            else
            {
                lnkTitle.Text = curData["Content_HeadlineKD"].ToString();
            }
            lnkTitle.NavigateUrl = "/TinTuc247/Download.aspx?id=" + curData["Distribution_ID"].ToString() + "&lang=" + lang + "&w=" + width;
        }
    }
}
