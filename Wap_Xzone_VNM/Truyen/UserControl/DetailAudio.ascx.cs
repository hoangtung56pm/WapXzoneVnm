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

namespace WapXzone_VNM.Truyen.UserControl
{
    public partial class DetailAudio : System.Web.UI.UserControl
    {

        private int width;
        private string lang;
        private string id;
        protected string catID;
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
            price = AppEnv.GetSetting("ringtoneprice");

            id = ConvertUtility.ToString(Request.QueryString["id"]);

            telCo = AppEnv.CheckFreeContentTelco();

            DataTable dtDetail = TintucController.GetAudioBookDetailCache(id);
            DataSet ds = TintucController.GetTruyenAudioHomeCache();

            if(ds != null)
            {
                DataTable dtMoi = ds.Tables[0];
                IList<DataRow> contentTop = dtMoi.Select().Skip(0).Take(1).ToList();
                IList<DataRow> contentBottom = dtMoi.Select().Skip(1).Take(5).ToList();

                rptTop.DataSource = contentTop.CopyToDataTable();
                rptTop.DataBind();

                rptBottom.DataSource = contentBottom.CopyToDataTable();
                rptBottom.DataBind();
            }

            if(dtDetail != null && dtDetail.Rows.Count > 0)
            {
                litName.Text = dtDetail.Rows[0]["SongName"].ToString();
                catID = dtDetail.Rows[0]["StyleId"].ToString();
                catName = dtDetail.Rows[0]["StyleName"].ToString();
            }

           
            if (!Page.IsPostBack)
            {

                #region FREE CONTENT

                if (AppEnv.GetSetting("FreeContent") == "1")
                {
                    HienThiNoiDung(true, false);
                    return;
                }

                #endregion

                #region OLD

                if (AppEnv.GetSetting("TestFlag") == "1")
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

                DataTable dtOnline = TintucController.GetAllCategoryExeptCatIDHasCache(255, 0);
                DataTable dtAudio = TintucController.GetCategoryTruyenAudioCache();

                rptCateOnline.DataSource = dtOnline;
                rptCateOnline.DataBind();

                rptCateAudio.DataSource = dtAudio;
                rptCateAudio.DataBind();

            }
        }


        protected void HienThiNoiDung(Boolean thuchien, Boolean log)
        {
            id = ConvertUtility.ToString(Request.QueryString["id"]);
            DataTable dtDetail = TintucController.GetAudioBookDetailCache(id);

            chitietGiaodich = "Nghe truyen Audio id : " + id;

            if(dtDetail != null && dtDetail.Rows.Count > 0)
            {
                if (thuchien)
                {
                    pnlContent.Visible = true;
                    if (dtDetail.Rows.Count > 0)
                    {
                        string url = "<p><a href=\"" + AppEnv.GetSetting("urldata") + dtDetail.Rows[0]["SongPathFile"].ToString().Replace("~/Upload/", "/Upload/") + "\" >Nghe chất lượng cao</a></p>";
                        //litContent.Text = dtDetail.Rows[0]["Content_Body"].ToString().Replace("href=\"Upload", "href=\"" + AppEnv.GetSetting("urldata") + "/Upload");
                        litContent.Text = url;
                    }
                    if (log)
                    {
                        Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 24);
                    }
                }
                else
                {

                    pnlContentError.Visible = true;
                    //Thông báo lỗi thanh toán
                    litContentError.Text = Resources.Resource.wThongBaoLoiThanhToan;

                    //--Thông báo lỗi thanh toán
                    if (log)
                    {
                        Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 24, messageReturn);
                    }
                }
                if (log)
                {
                    //log charging                                 
                    ILog logger = LogManager.GetLogger(Session["telco"].ToString());
                    logger.Debug("--------------------------------------------------");
                    logger.Debug("MSISDN:" + Session["msisdn"]);
                    logger.Debug("Dich vu: Audio - parameter: " + price + " - Ten: " + UnicodeUtility.UnicodeToKoDau(dtDetail.Rows[0]["SongName"].ToString()) + " - id: " + id);
                    logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                    logger.Debug("Error:" + messageReturn);
                    logger.Debug("Current Url:" + Request.RawUrl);
                    //end log
                }     
            }
        }  
    }
}