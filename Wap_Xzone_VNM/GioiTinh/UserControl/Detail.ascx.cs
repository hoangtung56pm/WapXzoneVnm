using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.GioiTinh.UserControl
{
    public partial class Detail : System.Web.UI.UserControl
    {

        private int width;
        private string lang;
        private int id;
        protected int catID;
        protected string catName;
        private int parentCatID;

        private string price;
        private string logPrice;

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
            price = AppEnv.GetSetting("relaxprice");
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            telCo = AppEnv.CheckFreeContentTelco();

            DataTable dtDetail = TintucController.GetNewsDetailHasCache(id);
            if(dtDetail != null && dtDetail.Rows.Count > 0)
            {
                litName.Text = dtDetail.Rows[0]["Content_Headline"].ToString();
                catID = ConvertUtility.ToInt32(dtDetail.Rows[0]["Distribution_ZoneID"]);
                DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(catID);

                catName = catInfo.Rows[0]["Zone_Name"].ToString();

                parentCatID = ConvertUtility.ToInt32(catInfo.Rows[0]["Zone_ParentID"]);
                //chitietGiaodich = "Thu gian: " + catInfo.Rows[0]["Zone_Name"] + " -- id: " + id + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
                chitietGiaodich = "Thu gian: " + catInfo.Rows[0]["Zone_Name"] + " -- id: " + id;

                int totalrecord = 0;
                DataTable dtCat = new DataTable();
                dtCat = TintucController.GetAllNewsByCategoryHasCache(catID, 8, 1, out totalrecord);
                if(dtCat != null && dtCat.Rows.Count > 0)
                {
                    IList<DataRow> contentTop = dtCat.Select().Skip(0).Take(3).ToList();
                    IList<DataRow> contentBottom = dtCat.Select().Skip(3).Take(7).ToList();

                    rptTop.DataSource = contentTop.CopyToDataTable();
                    rptTop.DataBind();

                    rptBottom.DataSource = contentBottom.CopyToDataTable();
                    rptBottom.DataBind();
                }
            }
            
            switch (parentCatID.ToString())
            {
                case "258"://Cẩm nang tư vấn
                    if (catID == 264)//Sex và cuộc sống
                    {
                        price = AppEnv.GetSetting("relaxsexprice");
                        ProductId = "RELAXADVISESEX";
                        Keyword = "ADVISE_SEX";
                    }
                    else
                    {
                        price = AppEnv.GetSetting("relaxtuvanprice");
                        ProductId = "RELAXADVISEBOOK";
                        Keyword = "ADVISE_BOOK";
                    }
                    break;
            }

            if(!Page.IsPostBack)
            {
                #region Free Content

                if (AppEnv.GetSetting("FreeContent") == "1")
                {
                    HienThiNoiDung(true, false);
                    return;
                }

                #endregion

                #region Old Content

                if (AppEnv.GetSetting("TestFlag") == "1")
                {
                    HienThiNoiDung(true, false);
                }
                else if (parentCatID.ToString() == "255" && WapController.W4A_Subscriber_IsActive(Session["msisdn"].ToString(), 1))
                {
                    HienThiNoiDung(true, false);
                }
                else
                {
                    if (Session["msisdn"] != null)
                    {
                        var charging = new Library.VNMCharging.VNMChargingGW();
                        messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), ProductId, Keyword, price, "D", "RELAX", Request.QueryString["id"]);

                        if (messageReturn == AppEnv.GetSetting("NotEnoughMoney"))//Not Enough Money
                        {
                            messageReturn = AppEnv.VnmChargingOptimizeNotEnoughMoney(Session["msisdn"].ToString(), ProductId, Keyword, price, "D", "RELAX", Request.QueryString["id"], out logPrice);
                            price = logPrice;
                        }

                        if (messageReturn == AppEnv.GetSetting("SystemOverload")) //System Over Load
                        {
                            messageReturn = AppEnv.VnmChargingSystemOverload(Session["msisdn"].ToString(), ProductId, Keyword, price, "D", "RELAX", Request.QueryString["id"]);
                        }

                        if (messageReturn == "1")
                        {// Thanh toán thành công >> trả nội dung                                    
                            HienThiNoiDung(true, true);
                        }
                        else
                        {// Thanh toán không thành công >> thông báo lỗi
                            HienThiNoiDung(false, true);
                        }
                    }
                    else
                    {
                        pnlContentError.Visible = true;
                        litContentError.Text = "Bạn vui lòng lựa chọn kết nối EDGE hay 3G để sử dụng dịch vụ này. Lưu ý, hãy ngắt kết nối wifi bạn nhé";
                    }
                }

                #endregion
            }
        }

        protected string ReplaceImageLink(string body)
        {
            string urlData = AppEnv.GetSetting("urldata");
            body = body.Replace("/Upload/", urlData + "/Upload/");
            body = body.Replace("<img", "<img width=\"250\"");
            body = body.Replace("<ul class=\"ul_reset\">", "<ul class=\"ul_reset\" style=\"display:none\">");

            return body;
        }

        protected void HienThiNoiDung(Boolean thuchien, Boolean log)
        {
            

            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            DataTable dtDetail = TintucController.GetNewsDetailHasCache(id);
            catID = ConvertUtility.ToInt32(dtDetail.Rows[0]["Distribution_ZoneID"]);
            //DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(catID);

            if (thuchien)
            {
                pnlContent.Visible = true;
                if (dtDetail.Rows.Count > 0)
                {
                    litContent.Text = ReplaceImageLink(dtDetail.Rows[0]["Content_Body"].ToString());
                }
                if (log)
                {
                    Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 23);
                }
            }
            else
            {
                pnlContentError.Visible = true;
                //Thông báo lỗi thanh toán
                litContentError.Text = Resources.Resource.wThongBaoLoiThanhToan;
                
                //--Thông báo lỗi thanh toán
                if (log) Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 23, messageReturn);
            }


            if (log)
            {
                //log charging                                 
                ILog logger = LogManager.GetLogger(Session["telco"].ToString());
                logger.Debug("--------------------------------------------------");
                logger.Debug("MSISDN:" + Session["msisdn"]);
                logger.Debug("Dich vu: Thu gian - parameter: " + price + " - Ten: " + dtDetail.Rows[0]["Content_HeadlineKD"] + " - id: " + id);
                logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                logger.Debug("Error:" + messageReturn);
                logger.Debug("Current Url:" + Request.RawUrl);
                //end log
            }
        }  
    }
}