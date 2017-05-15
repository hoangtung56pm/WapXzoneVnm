using System;
using System.Data;
using System.Web;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.HoangDao;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Hoangdao.UserControlHigh
{
    public partial class Detail : System.Web.UI.UserControl
    {

        private int width;
        private string lang;
        private int id;
        private string level;

        private string price;
        private string logPrice;

        private string telCo;

        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;

        private string ProductId;
        private string ProductKey;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                HienThiNoiDung(false,false);
            }
        }

        protected void HienThiNoiDung(Boolean thuchien,Boolean isLog)
        {
            //pnlNoiDung.Visible = true;

            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            level = Request.QueryString["l"];

            if (thuchien)
            {
                int type;
                DateTime vTime = DateTime.Now;
                DataTable dtDetail = null;
                switch (level)
                {
                    case "1":
                        dtDetail = HoangdaoController.GetHodaDateByIDHasCache(id);
                        type = ConvertUtility.ToInt32(dtDetail.Rows[0]["Type"]);
                        //if (lang == "1")
                        //{

                            //ltrTieuDe.Text = linkStr + " » " + "HOÀNG ĐẠO THEO NGÀY";
                            //lblTen.Text = HoangdaoController.CungHoangdao[type, 1] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")";
                            if (dtDetail.Rows.Count > 0)
                            {
                                litContent.Text = dtDetail.Rows[0]["WapContent"].ToString();
                            }

                        //}
                        //else
                        //{
                        //    ltrTieuDe.Text = linkStr_KD + " » " + "HOANG DAO THEO NGAY";
                        //    lblTen.Text = HoangdaoController.CungHoangdao[type, 0] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")";
                        //    if (dtDetail.Rows.Count > 0) { ltrNoiDung.Text = UnicodeUtility.UnicodeToKoDau(dtDetail.Rows[0]["WapContent"].ToString()); }
                        //}
                        break;
                    case "2":
                        dtDetail = HoangdaoController.GetHodaWeekByIDHasCache(id);
                        type = ConvertUtility.ToInt32(dtDetail.Rows[0]["Type"]);
                        //if (lang == "1")
                        //{
                        //    ltrTieuDe.Text = linkStr + " » " + "HOÀNG ĐẠO THEO TUẦN";
                        //    lblTen.Text = HoangdaoController.CungHoangdao[type, 1] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")";
                            if (dtDetail.Rows.Count > 0)
                            {
                                litContent.Text = dtDetail.Rows[0]["WapContent"].ToString();
                            }
                        //}
                        //else
                        //{
                        //    ltrTieuDe.Text = linkStr_KD + " » " + "HOANG DAO THEO TUAN";
                        //    lblTen.Text = HoangdaoController.CungHoangdao[type, 0] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")";
                        //    if (dtDetail.Rows.Count > 0) { ltrNoiDung.Text = UnicodeUtility.UnicodeToKoDau(dtDetail.Rows[0]["WapContent"].ToString()); }
                        //}
                        break;
                    case "3":
                        dtDetail = HoangdaoController.GetHodaMonthByIDHasCache(id);
                        type = ConvertUtility.ToInt32(dtDetail.Rows[0]["Type"]);
                        //if (lang == "1")
                        //{
                        //    ltrTieuDe.Text = linkStr + " » " + "HOÀNG ĐẠO THEO THÁNG";
                        //    lblTen.Text = HoangdaoController.CungHoangdao[type, 1] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")";
                            if (dtDetail.Rows.Count > 0)
                            {
                                litContent.Text = dtDetail.Rows[0]["WapContent"].ToString();
                            }
                        //}
                        //else
                        //{
                        //    ltrTieuDe.Text = linkStr_KD + " » " + "HOANG DAO THEO THANG";
                        //    lblTen.Text = HoangdaoController.CungHoangdao[type, 0] + " (" + HoangdaoController.CungHoangdao[type, 2] + ")";
                        //    if (dtDetail.Rows.Count > 0) { ltrNoiDung.Text = UnicodeUtility.UnicodeToKoDau(dtDetail.Rows[0]["WapContent"].ToString()); }
                        //}
                        break;
                }
                if(isLog)
                {
                    Transaction.Success(AppEnv.CheckSessionTelco(), Session["msisdn"].ToString(), price, Request.Url.ToString(), level + id, "Hoang dao: level:" + level + " -- id:" + id.ToString(), 17);
                }
            }
            else
            {
                //Thông báo lỗi thanh toán
                //if (lang == "1")
                //{
                //    ltrTieuDe.Text = linkStr + " » " + Resources.Resource.wThongBao;
                    litContent.Text = Resources.Resource.wThongBaoLoiThanhToan;
                //}
                //else
                //{
                //    ltrTieuDe.Text = linkStr_KD + " » " + Resources.Resource.wThongBao_KD;
                //    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                //}

                if(isLog)
                {
                    Transaction.Failure(AppEnv.CheckSessionTelco(), Session["msisdn"].ToString(), price, Request.Url.ToString(), level + id.ToString(), "Hoang dao: level:" + level + " -- id:" + id.ToString(), 17, messageReturn);
                }
                    
                //--Thông báo lỗi thanh toán
            }

            if(isLog)
            {
                //log charging                                 
                ILog logger = LogManager.GetLogger(AppEnv.CheckSessionTelco());
                logger.Debug("--------------------------------------------------");
                logger.Debug("MSISDN:" + Session["msisdn"]);
                logger.Debug("Dich vu: Hoang dao - parameter: " + price + " - level: " + level + " - id: " + id);
                logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                logger.Debug("Error:" + messageReturn);
                logger.Debug("Current Url:" + Request.RawUrl);
                //end log
            }

        }
    }
}