using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.MT;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library;

using System.Configuration;
using System.Data;
using WapXzone_VNM.Library.Component.Xoso;
using WapXzone_VNM.Library.Component.Transaction;
using log4net;

namespace WapXzone_VNM.Diemthi
{
    public partial class DapAn : BasePage
    {
        private MTInfo mt;
        private MTWaittingInfo mtWaittingInfo;
        private int width;        
        private string lang;                
        private string price;
        private string telCo;
        private string noiDung;
        private string chitietGiaodich=string.Empty;
        private string messageReturn = string.Empty;
                
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];            
            width = ConvertUtility.ToInt32(Request.QueryString["w"]);
            if (lang == "1")
            {
                ltrDichvu.Text = "ĐÁP ÁN ĐỀ THI";
            }
            else
            {
                ltrDichvu.Text = "DAP AN DE THI";
            }

            price = ConfigurationSettings.AppSettings.Get("diemthiprice");            
            telCo = Session["telco"].ToString();
            
            
            if (!IsPostBack)
            {
                if (width == 0)
                    width = (int)Constant.DefaultScreen.Standard;
                ltrWidth.Text = "<meta content=\"width=" + width.ToString() + "; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;\" name=\"viewport\" />";

                // Nếu có transactionid_old >> thuê bao mobifone đã thực hiện thanh toán
                if (Session["transactionid_old"] != null)
                {
                    messageReturn = ConvertUtility.ToString(Session["debit_status"]);
                    if (ConvertUtility.ToString(Session["debit_status"]) == "0")
                    {// Thanh toán thành công >> trả nội dung 
                        noiDung = Session["noiDung"].ToString();
                        HienThiNoiDung(true, true);
                    }
                    else
                    {// Thanh toán không thành công >> thông báo lỗi
                        HienThiNoiDung(true, false);
                    }
                    Session["transactionid_old"] = null;
                }
                else
                {
                    if (lang == "1")
                    {                     
                        ltrMaKhoi.Text = "Nhập mã khối";
                        ltrMaMon.Text = "Nhập mã môn";
                        ltrMaDe.Text = "Nhập mã đề";
                        ltrGia.Text = Resources.Resource.wGiaTai + price + Resources.Resource.wDonViTien;
                    }
                    else
                    {
                        ltrMaKhoi.Text = "Nhap ma khoi";
                        ltrMaMon.Text = "Nhap ma mon";
                        ltrMaDe.Text = "Nhap ma de";
                        ltrGia.Text = Resources.Resource.wGiaTai_KD + price + Resources.Resource.wDonViTien_KD;
                    }
                }
            }
        }

        protected void btnKhong_Click(object sender, EventArgs e)
        {
            Response.Redirect(ConvertUtility.ToString(Session["LastPage"]));
        }

        protected void HienThiNoiDung(Boolean cuphapDung, Boolean thanhToan)
        {
            pnlYeuCau.Visible = false;
            pnlNoiDung.Visible = true;            
            chitietGiaodich += "Dap ap: -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            lblTen.Text = txtMaKhoi.Text.Trim() + " " + txtMaMon.Text.Trim() + " " + txtMaDe.Text.Trim();
            if (cuphapDung)
            {
                if (thanhToan)
                {                    
                    ltrNoiDung.Text = noiDung;                    
                    Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), "0", chitietGiaodich, 17);
                    if (noiDung == "Hiện chưa có đáp án đề thi. Hệ thống sẽ gửi đáp án cho ban ngay khi có.")
                    {
                        //Luu MT waiting -                        
                        mtWaittingInfo = new MTWaittingInfo();
                        mtWaittingInfo.User_ID = Session["msisdn"].ToString();
                        mtWaittingInfo.Service_ID = "8579";
                        mtWaittingInfo.Command_Code = "DAN";
                        mtWaittingInfo.Message = "DAN " + lblTen.Text;
                        mtWaittingInfo.Request_ID = DateTime.Now.ToString("ddHHmmss");
                        mtWaittingInfo.ServiceType = 488;
                        //Not necessary
                        mtWaittingInfo.Message_Type = 0;
                        mtWaittingInfo.Total_Message = 1;
                        mtWaittingInfo.Message_Index = 0;
                        mtWaittingInfo.IsMore = 1;
                        mtWaittingInfo.Content_Type = 0;
                        mtWaittingInfo.UniqueId = string.Concat(txtMaKhoi.Text.Trim() + "_" + txtMaMon.Text.Trim() + "_" + txtMaDe.Text.Trim());
                        mtWaittingInfo.PartnerID = "";
                        mtWaittingInfo.ExpiredDate = DateTime.Now;
                        MTController.SMS_MTWaittingInsert(mtWaittingInfo);
                    }                    
                }
                else
                {
                    //Thông báo lỗi thanh toán
                    if (lang == "1")
                    {
                        ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan;
                    }
                    else
                    {
                        ltrNoiDung.Text = Resources.Resource.wThongBaoLoiThanhToan_KD;
                    }
                    Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), "0", chitietGiaodich, 17, messageReturn);
                }
            }
            else
            {
                if (lang == "1")
                {
                    ltrNoiDung.Text = noiDung;
                }
                else
                {
                    ltrNoiDung.Text = UnicodeUtility.UnicodeToKoDau(noiDung);
                }
                Transaction.Failure(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), "0", chitietGiaodich, 17, messageReturn);
                //--Thông báo lỗi thanh toán
            }
            //log charging                                 
            ILog logger = log4net.LogManager.GetLogger(Session["telco"].ToString());
            logger.Debug("--------------------------------------------------");
            logger.Debug("MSISDN:" + Session["msisdn"].ToString());
            logger.Debug("Diem thi: DT_DapAn - parameter: " + price + " - " + " " + lblTen.Text);            
            logger.Debug("IP:" + HttpContext.Current.Request.UserHostAddress);
            logger.Debug("Error:" + messageReturn);
            logger.Debug("Current Url:" + Request.RawUrl);
            //end log
        }

        protected void btnThucHien_Click(object sender, ImageClickEventArgs e)
        {            
            if (telCo == "Undefined")
            {
                pnlYeuCau.Visible = false;
                pnlSMS.Visible = true;
                if (lang == "1")
                {
                    ltrSMS.Text = "Soạn tin <b>DAN " + (txtMaKhoi.Text.Trim().Length > 0 ? txtMaKhoi.Text.Trim() : "&lt;Mã khối&gt;") + " " + (txtMaMon.Text.Trim().Length > 0 ? txtMaMon.Text.Trim() : "&lt;Mã môn&gt;") + " " + (txtMaDe.Text.Trim().Length > 0 ? txtMaDe.Text.Trim() : "&lt;Mã đề&gt;") + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("diemthicommandcode") + "</b> để tra đáp án đề thi" + Resources.Resource.wChon3G;
                }
                else
                {
                    ltrSMS.Text = "Soan tin <b>DAN " + (txtMaKhoi.Text.Trim().Length > 0 ? txtMaKhoi.Text.Trim() : "&lt;Ma khoi&gt;") + " " + (txtMaMon.Text.Trim().Length > 0 ? txtMaMon.Text.Trim() : "&lt;Ma mon&gt;") + " " + (txtMaDe.Text.Trim().Length > 0 ? txtMaDe.Text.Trim() : "&lt;Ma de&gt;") + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("diemthicommandcode") + "</b> de tra dap an de thi" + Resources.Resource.wChon3G_KD;
                }
            }
            else
            {
                DataTable tblData = WapXzone_VNM.Library.Component.DiemThi.DiemThiController.TSDH_Dapans_GetData(txtMaKhoi.Text.Trim(), txtMaMon.Text.Trim(), txtMaDe.Text.Trim());                
                chitietGiaodich = "DT DapAn: ";
                if (tblData != null && tblData.Rows.Count > 0)
                {
                    if (tblData.Rows[0]["MT1"].ToString() != string.Empty)
                    {                        
                        noiDung = "Khoi: " + tblData.Rows[0]["Khoi"].ToString() + ", Mon: " + tblData.Rows[0]["Mon"].ToString() + ", De: " + tblData.Rows[0]["De"].ToString() + "<br>";
                        noiDung += tblData.Rows[0]["MT1"].ToString().Trim() + " " + tblData.Rows[0]["MT2"].ToString().Trim() + " " + tblData.Rows[0]["MT3"].ToString().Trim() + " " + tblData.Rows[0]["MT4"].ToString().Trim() + " " + tblData.Rows[0]["MT5"].ToString().Trim() + " " + tblData.Rows[0]["MT6"].ToString().Trim() + " " + tblData.Rows[0]["MT7"].ToString().Trim();
                    }
                    else
                    {
                        noiDung = "Hiện chưa có đáp án đề thi. Hệ thống sẽ gửi đáp án cho ban ngay khi có.";                        
                    }

                    switch (Session["telco"].ToString())
                    {
                        case "Vietnamobile":
                            WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();
                            messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "DiemThi", txtMaKhoi.Text.Trim() + "_" + txtMaMon.Text.Trim() + "_" + txtMaDe.Text.Trim());
                            if (!string.IsNullOrEmpty(messageReturn) && messageReturn == "1")
                            {// Thanh toán thành công >> trả nội dung                                    
                                HienThiNoiDung(true, true);
                            }
                            else
                            {// Thanh toán không thành công >> thông báo lỗi
                                HienThiNoiDung(true, false);
                            }
                            break;
                    }       
                }
                else
                {
                    //Sai so bao danh
                    chitietGiaodich += "Sai cu phap " +  txtMaKhoi.Text.Trim() + " " + txtMaMon.Text.Trim() + " " + txtMaDe.Text.Trim();
                    noiDung = "Nội dung yêu cầu không đúng.<br>Bạn vui lòng kiểm tra, nhập đúng mã khối, mã môn, mã đề và thực hiện lại";
                    HienThiNoiDung(false, false);
                }                
            }            
        }
    }
}
