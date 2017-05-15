using System;
using System.Data;
using System.Web;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Tintuc;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thugian.UserControlHigh
{
    public partial class Detail : System.Web.UI.UserControl
    {
        private int id;
        private int catID;
        private int parentCatID;

        private string price;
        private string logPrice;

        private string telCo;
        private string chitietGiaodich;
        private string messageReturn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                id = ConvertUtility.ToInt32(Request.QueryString["id"]);

                DataTable dtDetail = TintucController.GetNewsDetailHasCache(id);
                catID = ConvertUtility.ToInt32(dtDetail.Rows[0]["Distribution_ZoneID"]);
                DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(catID);
                parentCatID = ConvertUtility.ToInt32(catInfo.Rows[0]["Zone_ParentID"]);
                chitietGiaodich = "Thu gian: " + catInfo.Rows[0]["Zone_Name"].ToString() + " -- id: " + id.ToString() + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);

                HienThiNoiDung(true,false);

            }
        }

        protected void HienThiNoiDung(Boolean thuchien, Boolean log)
        {
            //pnlNoiDung.Visible = true;

            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            DataTable dtDetail = TintucController.GetNewsDetail(id);
            catID = ConvertUtility.ToInt32(dtDetail.Rows[0]["Distribution_ZoneID"]);
            DataTable catInfo = TintucController.GetCategoryByCatIDHasCache(catID);

            if (thuchien)
            {
                //if (lang == "1")
                //{
                    //ltrTieuDe.Text = linkStr + " » " + "THƯ GIÃN";
                    lblItemName.Text = dtDetail.Rows[0]["Content_Headline"].ToString();
                    if (dtDetail.Rows.Count > 0)
                    {
                        litContent.Text = dtDetail.Rows[0]["Content_Body"].ToString().Replace("href=\"Upload", "href=\"" + AppEnv.GetSetting("urldata") + "/Upload");
                    }
                //}
                if (log) Transaction.Success(AppEnv.CheckSessionTelco(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 13);
            }
            else
            {
                //Thông báo lỗi thanh toán
                //if (lang == "1")
                //{
                    //ltrTieuDe.Text = linkStr + " » " + Resources.Resource.wThongBao;
                    litContent.Text = Resources.Resource.wThongBaoLoiThanhToan;
                //}
                //else
                //{
                //    ltrTieuDe.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
                //    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                //}
                //--Thông báo lỗi thanh toán
                    if (log) Transaction.Failure(AppEnv.CheckSessionTelco(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 13, messageReturn);
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