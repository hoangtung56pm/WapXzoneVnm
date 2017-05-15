using System;
using System.Configuration;
using System.Data;
using System.Web;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thugian
{
    public partial class DownloadNew : BasePage
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
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            price = ConfigurationSettings.AppSettings.Get("relaxprice");
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            telCo = Session["telco"].ToString();

            DataTable dtDetail = TintucController.GetNewsDetailHasCache(id);
            catID = ConvertUtility.ToInt32(dtDetail.Rows[0]["Distribution_ZoneID"]);
            DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(catID);
            parentCatID = ConvertUtility.ToInt32(catInfo.Rows[0]["Zone_ParentID"]);
            chitietGiaodich = "Thu gian: " + catInfo.Rows[0]["Zone_Name"].ToString() + " -- id: " + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            linkStr = "<a href=\"../" + UrlProcess.GetRelaxHomeUrlNew(lang, width.ToString()).Replace("~/", "") + "\" >THƯ GIÃN<a>";
            linkStr_KD = "<a href=\"../" + UrlProcess.GetRelaxHomeUrlNew(lang, width.ToString()).Replace("~/", "") + "\" >THU GIAN<a>";

            switch (parentCatID.ToString())
            {
                case "258"://Cẩm nang tư vấn
                    if (catID == 264)//Sex và cuộc sống
                    {
                        price = ConfigurationSettings.AppSettings.Get("relaxsexprice");
                        ProductId = "RELAXADVISESEX";
                        Keyword = "ADVISE_SEX";
                    }
                    else
                    {
                        price = ConfigurationSettings.AppSettings.Get("relaxtuvanprice");
                        ProductId = "RELAXADVISEBOOK";
                        Keyword = "ADVISE_BOOK";
                    }
                    break;
                case "121"://Gửi lời yêu thương
                    price = ConfigurationSettings.AppSettings.Get("relaxtuvanprice");
                    ProductId = "RELAXLOVER";
                    Keyword = "LOVER";
                    break;
                case "268"://Địa điểm ăn chơi
                    price = ConfigurationSettings.AppSettings.Get("relaxanchoiprice");
                    ProductId = "RELAXPLACE";
                    Keyword = "PLACE";
                    break;
                case "255"://Đọc truyện
                    price = ConfigurationSettings.AppSettings.Get("relaxprice");
                    ProductId = "LOTOLASTRESULT";
                    Keyword = "LAST_RESULT";
                    break;
                default:
                    price = ConfigurationSettings.AppSettings.Get("relaxprice");
                    ProductId = "HOROSCOPE";
                    Keyword = "HOROSCOPE";
                    break;
            }

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
                        ltrSMS.Text = "Bạn vui lòng" + Resources.Resource.wChon3G.Remove(0, 10);
                    }
                    else
                    {
                        ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                        ltrSMS.Text = "Ban vui long" + Resources.Resource.wChon3G_KD.Remove(0, 10);
                    }
                }
                else
                {
                    if (parentCatID.ToString() == "255" && WapController.W4A_Subscriber_IsActive(Session["msisdn"].ToString(), 1))
                    {
                        HienThiNoiDung(true, false);
                    }
                    else
                    {
                        pnlThongBao.Visible = false;
                        switch (Session["telco"].ToString())
                        {
                            case "Vietnamobile":
                                WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                                //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "RELAX", Request.QueryString["id"].ToString());
                                //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), ProductId, Keyword);

                                messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), ProductId, Keyword, price, "D", "RELAX", Request.QueryString["id"]);

                                if (messageReturn == "1")
                                {// Thanh toán thành công >> trả nội dung                                    
                                    HienThiNoiDung(true, true);
                                }
                                else
                                {// Thanh toán không thành công >> thông báo lỗi
                                    HienThiNoiDung(false, true);
                                }
                                break;
                        }
                    }
                }
            }
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            pnlThongBao.Visible = false;
            switch (Session["telco"].ToString())
            {
                case "Vietnamobile":
                    WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();

                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "RELAX", Request.QueryString["id"].ToString());
                    //messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), ProductId, Keyword);

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), ProductId, Keyword, price, "D", "RELAX", Request.QueryString["id"]);

                    if (messageReturn == "1")
                    {// Thanh toán thành công >> trả nội dung                                    
                        HienThiNoiDung(true, true);
                    }
                    else
                    {// Thanh toán không thành công >> thông báo lỗi
                        HienThiNoiDung(false, true);
                    }
                    break;
            }
        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
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
                    ltrTieuDe.Text = linkStr + " » " + "THƯ GIÃN";
                    lblTen.Text = dtDetail.Rows[0]["Content_Headline"].ToString();
                    if (dtDetail.Rows.Count > 0) { ltrNoiDung.Text = dtDetail.Rows[0]["Content_Body"].ToString().Replace("href=\"Upload", "href=\"" + ConfigurationSettings.AppSettings.Get("urldata") + "/Upload"); }
                }
                else
                {
                    ltrTieuDe.Text = linkStr_KD + " » " + "THU GIAN";
                    lblTen.Text = dtDetail.Rows[0]["Content_HeadlineKD"].ToString();
                    if (dtDetail.Rows.Count > 0) { ltrNoiDung.Text = dtDetail.Rows[0]["Content_BodyKD"].ToString().Replace("href=\"Upload", "href=\"" + ConfigurationSettings.AppSettings.Get("urldata") + "/Upload"); }
                };
                if (log) Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 13);
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
    }
}