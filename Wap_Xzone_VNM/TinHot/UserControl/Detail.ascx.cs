using System;
using System.Data;
using System.Web;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.TinHot.UserControl
{
    public partial class Detail : System.Web.UI.UserControl
    {
        protected int lang;
        protected string width;
        protected string CatName;
        protected int catID;
        private int id;
        protected string DetailName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                width = Request.QueryString["w"];
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);

                id = ConvertUtility.ToInt32(Request.QueryString["id"]);

                string isComment = "0";

                DataTable dtDetail = new DataTable();
                DataTable dtOlder = new DataTable();
                DataTable dtCat = new DataTable();

                dtDetail = TintucController.GetNewsDetailHasCache(id);
                if(dtDetail.Rows.Count == 0)
                {
                    DataSet ds = ThethaoController.GetNewsDetailHasCache(id);
                    dtDetail = ds.Tables[0];
                    dtOlder = ds.Tables[1];
                    catID = 129;
                    CatName = "Thể thao";
                }
                else
                {
                    catID = ConvertUtility.ToInt32(dtDetail.Rows[0]["Distribution_ZoneID"]);
                    DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(catID);
                    if (catInfo != null && catInfo.Rows.Count > 0)
                    {
                        CatName = catInfo.Rows[0]["Zone_Name"].ToString();
                    }
                }

                
                if(dtDetail.Rows.Count > 0)
                {
                    rptDetail.DataSource = dtDetail;
                    rptDetail.DataBind();

                    DetailName = dtDetail.Rows[0]["Content_Headline"].ToString();

                    isComment = dtDetail.Rows[0]["Content_IsComment"].ToString();
                }

                if(dtOlder.Rows.Count > 0)
                {
                    dtCat = dtOlder;
                }
                else
                {
                    dtCat = TintucController.GetTopNewsOlderByCategoryHasCache(catID, id, 10);
                }

                //DataTable dtCat = TintucController.GetTopNewsOlderByCategoryHasCache(catID, id, 4);
                rptOlderNews.DataSource = dtCat;
                rptOlderNews.DataBind();

                DataTable dtNewsCharging = TintucController.GetNewsChargingCache();
                if(dtNewsCharging != null && dtNewsCharging.Rows.Count > 0)
                {
                    rptNewsCharging.DataSource = dtNewsCharging;
                    rptNewsCharging.DataBind();
                }

                if(ConvertUtility.ToBoolean(isComment))
                {
                    #region FREE CONTENT

                    if (AppEnv.GetSetting("FreeContent") == "1")
                    {
                        pnlContent.Visible = true;
                        return;
                    }

                    #endregion

                    #region OLD

                    if (Session["msisdn"] != null)
                    {
                        string price = "2000";

                        var charging = new Library.VNMCharging.VNMChargingGW();
                        string result = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "VIDEOGIFT", "VIDEO_GIFT", price, "D", "VID", "Tin-Hot : id " + Request.QueryString["id"]);
                        if (result == "1")
                        {
                            pnlContent.Visible = true;
                            Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.RawUrl, id.ToString(), "Tin-Hot : id " + Request.QueryString["id"], 22);
                        }
                        else
                        {
                            pnlNotContent.Visible = true;
                            litNotContentError.Text = "Giao dịch không thành công. Hoặc tài khoản không đủ tiền !";
                        }

                        //log charging                                 
                        ILog logger = LogManager.GetLogger(Session["telco"].ToString());
                        logger.Debug("--------------------------------------------------");
                        logger.Debug("MSISDN:" + Session["msisdn"]);
                        logger.Debug("Dich vu: Tin Hot - parameter: " + price + " - Ten: " + "Tin-Hot : id " + Request.QueryString["id"] + " - id: " + id);
                        logger.Debug("Url:" + Request.RawUrl);
                        logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                        logger.Debug("Error:" + result);
                        logger.Debug("Current Url:" + Request.RawUrl);
                        //end log   

                    }
                    else
                    {
                        pnlNotContent.Visible = true;
                        litNotContentError.Text = "Bạn vui lòng lựa chọn kết nối EDGE hay 3G để sử dụng dịch vụ này. Lưu ý, hãy ngắt kết nối wifi bạn nhé";
                    }
                    
                    #endregion

                }
                else
                {
                    pnlContent.Visible = true;
                }
            }
        }

        protected string ReplaceImageLink(string body)
        {
            string urlData = AppEnv.GetSetting("urldata");
            body = body.Replace("/Upload/", urlData + "/Upload/");
            body = body.Replace("<img","<img width=\"250\"");
            body = body.Replace("<ul class=\"ul_reset\">","<ul class=\"ul_reset\" style=\"display:none\">");

            return body;
        }
    }
}