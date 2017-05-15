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
    public partial class N1D3 : BasePage
    {
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
                ltrDichvu.Text = "NHẮN 1 ĐƯỢC 3";
            }
            else
            {
                ltrDichvu.Text = "NHAN 1 DUOC 3";
            }

            price = ConfigurationSettings.AppSettings.Get("diemthi15price");            
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
                        ltrSoBaoDanh.Text = "Nhập số báo danh";
                        ltrGia.Text = Resources.Resource.wGiaTai + price + Resources.Resource.wDonViTien;
                    }
                    else
                    {
                        ltrSoBaoDanh.Text = "Nhap so bao danh";
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
            chitietGiaodich += " -- newtransactionid: " + ConvertUtility.ToString(Session["transactionid"]) + " -- old tranid: " + ConvertUtility.ToString(Session["transactionid_old"]);
            lblTen.Text = txtSoBaoDanh.Text.Trim();
            if (cuphapDung)
            {
                if (thanhToan)
                {                    
                    if (lang == "1")
                    {
                        ltrNoiDung.Text = noiDung.Replace("De tra dap an de thi,soan: DAN", "").Replace(" gui 8579.DTHT:19001255", "").Replace("<ma doi tac>", "").Replace("<ma khoi>", "").Replace("<ma mon>", "").Replace("<ma de>", "").Replace("_", "");
                    }
                    else
                    {
                        ltrNoiDung.Text = noiDung.Replace("De tra dap an de thi,soan: DAN", "").Replace(" gui 8579.DTHT:19001255", "").Replace("<ma doi tac>", "").Replace("<ma khoi>", "").Replace("<ma mon>", "").Replace("<ma de>", "").Replace("_", "");
                    }                    
                    Transaction.Success(Session["telco"].ToString(), Session["msisdn"].ToString(), price, Request.Url.ToString(), "0", chitietGiaodich, 17);
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
            logger.Debug("Diem thi: 1_3 - parameter: " + price + " - " + txtSoBaoDanh.Text.Trim() + " " + txtSoBaoDanh.Text.Trim());            
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
                    ltrSMS.Text = "Soạn tin <b>DXC " + " " + (txtSoBaoDanh.Text.Trim().Length > 0 ? txtSoBaoDanh.Text.Trim() : "&lt;Số báo danh&gt;") + "</b> gửi <b>" + ConfigurationSettings.AppSettings.Get("diemthi15commandcode") + "</b> để nhận ngay điểm, xếp hạng và điểm chuẩn" + Resources.Resource.wChon3G;
                }
                else
                {
                    ltrSMS.Text = "Soan tin <b>DXC " + (txtSoBaoDanh.Text.Trim().Length > 0 ? txtSoBaoDanh.Text.Trim().ToUpper() : "&lt;So bao danh&gt;") + "</b> gui <b>" + ConfigurationSettings.AppSettings.Get("diemthi15commandcode") + "</b> de nhan ngay diem, xep hang va diem chuan" + Resources.Resource.wChon3G_KD;
                }
            }
            else
            {
                DT_TSDHService.ServiceController objMbox = new DT_TSDHService.ServiceController();
                DT_TSDHService.ResultData objResulnInfo = new DT_TSDHService.ResultData();
                objResulnInfo = objMbox.QueryAll(Session["msisdn"].ToString(), txtSoBaoDanh.Text.Trim().ToUpper(), "1", "DXC", "8779", "1");

                chitietGiaodich = "Nhan 1 duoc 3: ";
                if (objResulnInfo.ErrorCode == 1 || objResulnInfo.ErrorCode == 2)
                {
                    //trường hợp đúng hết mã tỉnh và số báo danh - sẽ trả về cho khách hàng Message do đối tác trả lại
                    chitietGiaodich += string.Format("Gọi sang WS cua doi tac thanh cong voi gia tri tra ve la  {0}", objResulnInfo.ErrorCode);
                    noiDung = objResulnInfo.Message;
                    switch (Session["telco"].ToString())
                    {
                        case "Vietnamobile":
                            WapXzone_VNM.Library.VNMCharging.VNMChargingGW charging = new WapXzone_VNM.Library.VNMCharging.VNMChargingGW();
                            messageReturn = charging.PaymentVNM(Session["msisdn"].ToString(), price, "D", "DiemThi", Request.QueryString["id"].ToString());
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
                else if (objResulnInfo.ErrorCode == 0)
                {
                    //Sai so bao danh
                    chitietGiaodich += string.Format("Sai cu phap (truong hop sai so bao danh) voi Message la  {0}", txtSoBaoDanh.Text.Trim());
                    noiDung = "Số báo danh sai.<br>Bạn vui lòng kiểm tra, nhập đúng số báo danh và thực hiện lại";
                    HienThiNoiDung(false, false);
                }
                else if (objResulnInfo.ErrorCode == 3)
                {
                    //Sai mã tỉnh
                    chitietGiaodich += string.Format("Sai cu phap (truong hop sai ma tinh) voi Message la  {0}", txtSoBaoDanh.Text.Trim());
                    noiDung = "Mã tỉnh sai.<br>Bạn vui lòng kiểm tra, nhập đúng mã tỉnh và thực hiện lại";
                    HienThiNoiDung(false, false);
                }
                else
                {
                    //trường hợp gọi sang ws đối tác giá trị trả về là -1
                    noiDung = "Sai mã tỉnh và số báo danh. Vui lòng liên hệ với số 19001255 hỗ trợ";
                    chitietGiaodich += "Loi khi goi sang WS doi tac gia tri tra ve la -1";
                    HienThiNoiDung(false, false);
                }                  
            }            
        }
    }
}
