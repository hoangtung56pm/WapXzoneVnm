using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using WapXzone.Library.Utilities;
using WapXzone.Library.UrlProcess;
using WapXzone.Library.Component.Transaction;
using WapXzone.Library;

using WapXzone.Library.Component.TuVi;

namespace WapXzone.TuVi.UserControl
{
    public partial class Detail : System.Web.UI.UserControl
    {        
        private string width;
        private string lang;        
        private int id;        
        private string price;
        private TransactionInfo trans;
        private string msisdn = string.Empty;
        private string cpid = string.Empty;
        private string transaction_oldid = string.Empty;
        private string transaction_newid = string.Empty;
        private string content_id = string.Empty;
        private string content_price = string.Empty;
        private string debit_status = string.Empty;
        private string cipher;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = Request.QueryString["lang"];
            width = Request.QueryString["w"];            
            id = ConvertUtility.ToInt32(Request.QueryString["id"]);
            price = ConfigurationSettings.AppSettings.Get("tuviprice");
            cipher = Request.QueryString["link"];
            MobileUtils.GetDetailCharging(EAS.DecryptData(cipher, ConfigurationSettings.AppSettings.Get("vmskey")), ref msisdn, ref cpid, ref transaction_oldid, ref transaction_newid, ref content_id, ref content_price, ref debit_status);
            if (!IsPostBack)
            {
                if (lang == "1") { lnkBack.Text = "Quay lại"; }
                if (debit_status == "0")
                {
                    //luu giao dich
                    trans = new TransactionInfo();
                    trans.Wap_Transaction_Link = "";
                    trans.Wap_Transaction_Mobile = msisdn;
                    trans.Wap_Transaction_Operator = "Mobifone";
                    trans.Wap_Transaction_Portal = "Mobifone";
                    trans.Wap_TransactionDetail = "Tu vu: id:" + id.ToString() + " -- newtransactionid: " + transaction_newid + " -- old tranid: " + transaction_oldid;
                    trans.Wap_Transaction_Amount = ConvertUtility.ToDouble(price);
                    trans.Wap_TransactionName = content_id;
                    trans.Wap_TransactionOn = DateTime.Now;
                    trans.Wap_TransactionType = 18;//thu gian
                    TransactionController.Insert_Transaction(trans);
                    //end luu giao dich 
                    //DateTime vTime = DateTime.Now;
                    DataTable dtDetail = null;
                    
                    dtDetail = TuViController.Horoscope_GetItemByID(id);                    
                    if (lang == "1")
                    {
                        ltrTieude.Text = "TỬ VI";                        
                        if (dtDetail.Rows.Count > 0) { lblNoidung.Text = dtDetail.Rows[0]["MT5"].ToString(); }
                    }
                    else
                    {
                        ltrTieude.Text = "TU VI";
                        if (dtDetail.Rows.Count > 0) { lblNoidung.Text = dtDetail.Rows[0]["MT_KD5"].ToString(); }
                    }; 
                    divthongbao.Visible = false;
                }
                else
                {
                    TransactionLogInfo _log = new TransactionLogInfo();
                    string thongbao = "Thanh toán không thành công hoặc tài khoản không đủ tiền.";
                    ltrthongbao.Text = thongbao;
                    //Luu vao bang transaction log truong hop giao dich that bai
                    _log.Wap_Transaction_Link = "";
                    _log.Wap_Transaction_Mobile = msisdn;
                    _log.Wap_Transaction_Operator = "Mobifone";
                    _log.Wap_Transaction_Portal = "Mobifone";
                    _log.Wap_TransactionDetail = "Tu vi: id:" + id.ToString() + " -- newtransactionid: " + transaction_newid + " -- old tranid: " + transaction_oldid;
                    _log.Wap_Transaction_Amount = ConvertUtility.ToDouble(price);
                    _log.Wap_TransactionName = content_id;
                    _log.Wap_TransactionOn = DateTime.Now;
                    _log.Wap_TransactionType = 18;
                    _log.ErrorCode = 1;//That bai
                    TransactionController.Insert_TransactionLog(_log);
                };
            }; 

        }
    }
}