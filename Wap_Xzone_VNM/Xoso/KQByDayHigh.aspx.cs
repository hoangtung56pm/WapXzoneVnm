using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Xoso;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Xoso
{
    public partial class KQByDayHigh : BasePage
    {

        private int width;
        private string lang;
        private int id;
        private string price;
        private string telCo;
        private string linkStr, linkStr_KD;
        private string messageReturn = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            price = ConfigurationSettings.AppSettings.Get("kqxsprice");
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);

            telCo = AppEnv.CheckFreeContentTelco();

            linkStr = "<a href=\"../" + UrlProcess.XoSoHome() + "\" >XỔ SỐ</a>";
            //linkStr_KD = "<a href=\"../" + UrlProcess.GetXosoHomeUrl(lang, width.ToString()).Replace("~/", "") + "\" >XO SO<a>";

            if (!IsPostBack)
            {
                //if (width == 0)
                //    width = (int)Constant.DefaultScreen.Standard;
                //ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                #region Free Content

                if (AppEnv.GetSetting("FreeContent") == "1")
                {
                    HienThiNoiDung(true, false);
                    return;
                }

                #endregion

                #region OLD

                DataSet ds = XosoController.GetDetail_LotAndOtherLotByIdAndTop(id, 6);

                // Nếu có transactionid_old >> thuê bao mobifone đã thực hiện thanh toán
                if (Session["transactionid_old"] != null)
                {
                    messageReturn = ConvertUtility.ToString(Session["debit_status"]);
                    if (ConvertUtility.ToString(Session["debit_status"]) == "0")
                    {// Thanh toán thành công >> trả nội dung                        
                        HienThiNoiDung(true, true);
                    }
                    else
                    {// Thanh toán không thành công >> thông báo lỗi
                        HienThiNoiDung(false, true);
                    }
                    Session["transactionid_old"] = null;
                }
                else
                {
                    if (telCo == Constant.T_Mobifone)
                    {
                        string content = Session["cpid"].ToString() + "&" + Constant.xoso + id.ToString() + "&" + price + "&" + Session["transactionid"].ToString();
                        Response.Redirect(ConfigurationSettings.AppSettings.Get("vms3g") + "?link=" + Server.UrlEncode(EAS.EncryptData(content, ConfigurationSettings.AppSettings.Get("vmskey"))));
                    }
                    //                
                    if (telCo == "Undefined")
                    {
                        pnlSMS.Visible = true;
                        //if (lang == "1")
                        //{
                        ltrHuongdan.Text = linkStr + " » " + Resources.Resource.wHuongDan;
                        ltrSMS.Text = "Soạn tin <b>" + ConfigurationSettings.AppSettings.Get("kqxscode") + " " + ds.Tables[0].Rows[0]["company_comment"].ToString() + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("kqxscommandcode") + "</b> để nhận kết quả xổ số mới nhất" + Resources.Resource.wChon3G;
                        //}
                        //else
                        //{
                        //    ltrHuongdan.Text = linkStr_KD + " » " + Resources.Resource.wHuongDan_KD;
                        //    ltrSMS.Text = "Soan tin <b>" + ConfigurationSettings.AppSettings.Get("kqxscode") + " " + ds.Tables[0].Rows[0]["company_comment"].ToString() + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("kqxscommandcode") + "</b> de nhan ket qua xo so moi nhat" + Resources.Resource.wChon3G_KD;
                        //}
                    }
                    else
                    {
                        pnlThongBao.Visible = false;
                        switch (Session["telco"].ToString())
                        {
                            case "Vietnamobile":
                                var charging = new Library.VNMCharging.VNMChargingGW();

                                messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "LOTOLASTRESULT", "LAST_RESULT", price, "D", "KQXS", Request.QueryString["id"]);

                                if (!string.IsNullOrEmpty(messageReturn) && messageReturn == "1")
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

                #endregion
            }
        }

        protected void btnCo_Click(object sender, EventArgs e)
        {
            pnlThongBao.Visible = false;
            switch (Session["telco"].ToString())
            {
                case "Vietnamobile":
                    var charging = new Library.VNMCharging.VNMChargingGW();

                    messageReturn = charging.NavigatePaymentVnm(Session["msisdn"].ToString(), "LOTOLASTRESULT", "LAST_RESULT", price, "D", "KQXS", Request.QueryString["id"]);

                    if (!string.IsNullOrEmpty(messageReturn) && messageReturn == "1")
                    {// Thanh toán thành công >> trả nội dung                                    
                        HienThiNoiDung(true,true);
                    }
                    else
                    {// Thanh toán không thành công >> thông báo lỗi
                        HienThiNoiDung(false,true);
                    }
                    break;
            }
        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }

        protected void HienThiNoiDung(Boolean thuchien,Boolean isLog)
        {
            pnlNoiDung.Visible = true;

            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            DataSet ds = XosoController.GetDetail_LotAndOtherLotByIdAndTop(id, 6);

            //string chitietGiaodich = "KQXS: " + ds.Tables[0].Rows[0]["company_name"].ToString() + " ngày " + ConvertUtility.ToDateTime(ds.Tables[0].Rows[0]["lot_time"]).ToString("dd/MM/yyyy") + " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);

            string chitietGiaodich = "KQXS: " + ds.Tables[0].Rows[0]["company_name"].ToString() + " ngày " +
                                     ConvertUtility.ToDateTime(ds.Tables[0].Rows[0]["lot_time"]).ToString("dd/MM/yyyy");

            if (thuchien)
            {
                //
                //if (lang == "1")
                //{
                    ltrTieuDe.Text = "XỔ SỐ";
                    lblTen.Text = ds.Tables[0].Rows[0]["company_name"].ToString() + " ngày " + ConvertUtility.ToDateTime(ds.Tables[0].Rows[0]["lot_time"]).ToString("dd/MM/yyyy");
                    //ltrNoiDung.Text = "Bạn đã đăng ký thành công dịch vụ lấy kết quả trực tiếp từ trường quay xổ số.<br />Cảm ơn bạn đã sử dụng dịch vụ!";
                    lbldb6.Text = "Đặc Biệt DB6";
                    lbldb.Text = "Đặc Biệt";
                    lblg1.Text = "Nhất";
                    lblg2.Text = "Nhì";
                    lblg3.Text = "Ba";
                    lblg4.Text = "Tư";
                    lblg5.Text = "Năm";
                    lblg6.Text = "Sáu";
                    lblg7.Text = "Bảy";
                    lblg8.Text = "Tám";
                    lblOther.Text = "XEM TIẾP";
                //}
                //else
                //{
                //    ltrTieuDe.Text = "XO SO";
                //    lblTen.Text = UnicodeUtility.UnicodeToKoDau(ds.Tables[0].Rows[0]["company_name"].ToString()) + " ngay " + ConvertUtility.ToDateTime(ds.Tables[0].Rows[0]["lot_time"]).ToString("dd/MM/yyyy"); ;
                //};
                // Nội dung KQXS
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["lot_prize16"].ToString()))
                {
                    g1.Visible = false;
                }
                else
                {
                    g1.Visible = true;
                    ltrgdb6.Text = ds.Tables[0].Rows[0]["lot_prize16"].ToString();

                }
                if (string.IsNullOrEmpty(ds.Tables[0].Rows[0]["lot_prize08"].ToString()))
                {
                    g8.Visible = false;
                }
                else
                {
                    g8.Visible = true;
                    ltrg8.Text = ds.Tables[0].Rows[0]["lot_prize08"].ToString();
                }
                ltrg1.Text = ds.Tables[0].Rows[0]["lot_prize01"].ToString();
                ltrg2.Text = ds.Tables[0].Rows[0]["lot_prize02"].ToString();
                ltrg3.Text = ds.Tables[0].Rows[0]["lot_prize03"].ToString();
                ltrg4.Text = ds.Tables[0].Rows[0]["lot_prize04"].ToString();
                ltrg5.Text = ds.Tables[0].Rows[0]["lot_prize05"].ToString();
                ltrg6.Text = ds.Tables[0].Rows[0]["lot_prize06"].ToString();
                ltrg7.Text = ds.Tables[0].Rows[0]["lot_prize07"].ToString();
                ltrdb.Text = ds.Tables[0].Rows[0]["lot_prize15"].ToString();
                //
                if(isLog)
                {
                    Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 9);
                }
                //                    
                rptOther.DataSource = ds.Tables[1];
                rptOther.ItemDataBound += rptOther_ItemDataBound; ;
                rptOther.DataBind();
            }
            else
            {
                detail.Visible = false;
                //Thông báo lỗi thanh toán
                //if (lang == "1")
                //{
                    ltrTieuDe.Text = Resources.Resource.wThongBao;
                    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan;
                //}
                //else
                //{
                //    ltrTieuDe.Text = Resources.Resource.wThongBao_KD;
                //    ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                //}
                if(isLog)
                {
                    Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), id.ToString(), chitietGiaodich, 9, messageReturn);
                }
                //--Thông báo lỗi thanh toán
            }

            if(isLog)
            {
                //log charging                                 
                ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
                logger.Debug("--------------------------------------------------");
                logger.Debug("MSISDN:" + Session["msisdn"].ToString());
                logger.Debug("Dich vu: Xo so - Ket qua - parameter: " + price + " - id: " + id);
                logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
                logger.Debug("Error:" + messageReturn);
                logger.Debug("Current Url:" + Request.RawUrl);
                //end log
            }

        }

        protected void rptOther_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkother = (HyperLink)e.Item.FindControl("lnkother");
            //if (lang == "1")
            //{
                lnkother.Text = "Kết quả ngày " + ConvertUtility.ToDateTime(curData["lot_time"]).ToString("dd/MM/yyyy");
            //}
            //else
            //{
            //    lnkother.Text = "Ket qua ngay " + ConvertUtility.ToDateTime(curData["lot_time"]).ToString("dd/MM/yyyy");
            //}
            //lnkother.NavigateUrl = UrlProcess.GetXosoByCityDetailUrl(lang.ToString(), "byday", width, curData["lot_id"].ToString(),companyid.ToString());
            //string content = cpid + "&" + Constant.xoso + curData["lot_id"].ToString() + "&" + kqxsprice + "&" + transaction_newid;

            //lnkother.NavigateUrl = "KQByDay.aspx?id=" + curData["lot_id"].ToString() + "&lang=" + lang + "&w=" + width;
             lnkother.NavigateUrl = UrlProcess.XoSoChiTiet(ConvertUtility.ToInt32(curData["lot_id"].ToString()),
                                                              Constant.XoSo_KqbyDay_Rewrite);


        }

    }
}