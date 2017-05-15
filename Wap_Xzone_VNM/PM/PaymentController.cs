using System;
using System.Collections.Generic;
using System.Web;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Cache;
using System.Data;
using WapXzone_VNM.Library.SQLHelper;
using System.Web.Configuration;
using WapXzone_VNM.Library;
using System.Configuration;
using log4net;

namespace WapXzone_VNM.PM
{
    public class DBController
    {
        public DBController()
        {
        }
        private static double GetExpire()
        {
            return ConvertUtility.ToDouble(ConfigurationSettings.AppSettings.Get("timeexpired"));
        }

        //Kiểm tra sự tồn tại của Partner
        public static Boolean Partner_CheckExist(int partnerID)
        {
            DataCaching data = new DataCaching();
            string key = "Partner_GetInfo";
            string param = "partnerID=" + partnerID;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null)
            {
                if (dtRetval.Rows.Count > 0) return true;
                else return false;
            }
            else
            {
                dtRetval = Partner_GetInfo(partnerID);
                data.SetHashCache(key, param, GetExpire(), dtRetval);
                if (dtRetval.Rows.Count > 0) return true;
                else return false;
            }
        }

        //Lấy thông tin của Partner theo ID
        public static DataTable Partner_GetInfoHasCache(int partnerID)
        {
            DataCaching data = new DataCaching();
            string key = "Partner_GetInfo";
            string param = "partnerID=" + partnerID;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                dtRetval = Partner_GetInfo(partnerID);
                data.SetHashCache(key, param, GetExpire(), dtRetval);
                return dtRetval;
            }
        }

        //Xác thực Partner theo KeyCode
        public static Boolean Partner_Authenticate(int partnerID, string KeyCode)
        {
            DataCaching data = new DataCaching();
            string key = "Partner_GetInfo";
            string param = "partnerID=" + partnerID;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval == null || dtRetval.Rows.Count == 0)
            {
                dtRetval = Partner_GetInfo(partnerID);
                data.SetHashCache(key, param, GetExpire(), dtRetval);
            }
            if (dtRetval.Rows[0]["KeyCode"].ToString() == KeyCode)
                return true;
            else
                return false;
        }

        public static DataTable Partner_GetInfo(int partnerID)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionStringPayment"].ConnectionString, "Partner_GetInfo", partnerID);
                if (ds != null && ds.Tables.Count > 0)
                    return ds.Tables[0];
                return null;
            }
            catch (Exception ex)
            {
                ILog logger = log4net.LogManager.GetLogger("File");
                logger.Debug("DungLog =" + ex.Message); return null;
            };
        }

        public static string Transaction_Online_Insert(string MSISDN, int Telco, int PartnerID, string vms_TransactionID, string vms_CPID)
        {
            try
            {
                return ConvertUtility.ToString(SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionStringPayment"].ConnectionString, "Transaction_Online_Insert", MSISDN, Telco, PartnerID, vms_TransactionID, vms_CPID));
            }
            catch { return ""; };
        }

        public static string Transaction_Online_Update(decimal TransactionID, string ItemID, string ItemDetail, int ItemType, int Price)
        {
            try
            {
                return (string)SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionStringPayment"].ConnectionString, "Transaction_Online_Update", TransactionID, ItemID, ItemDetail, ItemType, Price);
            }
            catch { return "-1"; };
        }

        public static int Transaction_Online_Delete(decimal TransactionID)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionStringPayment"].ConnectionString, "Transaction_Online_Delete", TransactionID);
                return 1;
            }
            catch { return 0; };
        }

        public static Boolean Transaction_Online_CheckExist(decimal TransactionID, string MSISDN, int PartnerID)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionStringPayment"].ConnectionString, "Transaction_Online_GetInfo", TransactionID, MSISDN, PartnerID);
                if (ds.Tables[0].Rows.Count > 0)
                    return true;
                else return false;
            }
            catch { return false; };
        }

        public static DataTable Transaction_Online_GetInfo(decimal TransactionID, string MSISDN, int PartnerID)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionStringPayment"].ConnectionString, "Transaction_Online_GetInfo", TransactionID, MSISDN, PartnerID);
                if (ds != null && ds.Tables.Count > 0)
                    return ds.Tables[0];
                return null;
            }
            catch
            {
             
                return null;
            };
        }

        public static DataTable Transaction_Online_GetByToken(string TokenKey)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionStringPayment"].ConnectionString, "Transaction_Online_GetByToken", TokenKey);
                if (ds != null && ds.Tables.Count > 0)
                    return ds.Tables[0];
                return null;
            }
            catch (Exception ex)
            {
                ILog logger = log4net.LogManager.GetLogger("File");
                logger.Debug("DungLog =" + ex.Message);
                return null; 
            };
        }

        public static DataTable Transaction_Online_GetByvms_TransactionID(string vms_TransactionID)
        {
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionStringPayment"].ConnectionString, "Transaction_Online_GetByvms_TransactionID", vms_TransactionID);
                if (ds != null && ds.Tables.Count > 0)
                    return ds.Tables[0];
                return null;
            }
            catch { return null; };
        }

        public static int Transaction_Insert(string ItemID, string ItemDetail, int ItemType, string MSISDN, int Telco, int PaidType, int Price, int PartnerID,
            decimal TransactionID, DateTime TransactionIDCreated, string TransactionDetail, int Status)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionStringPayment"].ConnectionString, "Transaction_Insert",
                    ItemID, ItemDetail, ItemType, MSISDN, Telco, PaidType, Price, PartnerID, TransactionID, TransactionIDCreated, TransactionDetail, Status);

                //Ghi log Wap_Transaction để đối soát với Telco                
                if (Status == 0)
                    Transaction.Success("Vietnamobile", MSISDN, Price.ToString(), ItemDetail, ItemID, TransactionDetail, ItemType);
                else
                    Transaction.Failure("Vietnamobile", MSISDN, Price.ToString(), ItemDetail, ItemID, TransactionDetail, ItemType, TransactionDetail);

                //Trả kết quả Transaction_Insert thành công
                return 1;
            }
            catch { return 0; };
        }

        public static int Transaction_Insert_New(string ItemID, string ItemDetail, int ItemType, string MSISDN, int Telco, int PaidType, int Price, int PartnerID,
           decimal TransactionID, DateTime TransactionIDCreated, string TransactionDetail, int Status)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionStringPayment"].ConnectionString, "Transaction_Insert",
                    ItemID, ItemDetail, ItemType, MSISDN, Telco, PaidType, Price, PartnerID, TransactionID, TransactionIDCreated, TransactionDetail, Status);

                //Ghi log Wap_Transaction để đối soát với Telco                
                if (Status == 0)
                    Transaction.SuccessNew("Vietnamobile", MSISDN, Price.ToString(), ItemDetail, ItemID, TransactionDetail, ItemType);
                else
                    Transaction.FailureNew("Vietnamobile", MSISDN, Price.ToString(), ItemDetail, ItemID, TransactionDetail, ItemType, TransactionDetail);

                //Trả kết quả Transaction_Insert thành công
                return 1;
            }
            catch { return 0; };
        }
    }

    public class PaymnetPage : System.Web.UI.Page
    {
        protected override void OnInit(EventArgs e)
        {
            if (HttpContext.Current.Request.UserAgent.ToLower().Contains("midp") && !MobileUtils.IsBlackBerry(HttpContext.Current.Request.UserAgent.ToLower()))
            {
                //Response.CacheControl = "private";
                Response.Charset = "UTF-8";
                //Response.Expires = 0;
                string acceptHeader = Request.ServerVariables["HTTP_ACCEPT"];

                if (acceptHeader.IndexOf("application/vnd.wap.xhtml+xml") != -1)
                {
                    Response.ContentType = "application/vnd.wap.xhtml+xml";
                }
                else if (acceptHeader.IndexOf("application/xhtml+xml") != -1)
                {
                    Response.ContentType = "application/xhtml+xml";
                }
                else
                {
                    Response.ContentType = "text/html";
                }
            }
        }
    }
}