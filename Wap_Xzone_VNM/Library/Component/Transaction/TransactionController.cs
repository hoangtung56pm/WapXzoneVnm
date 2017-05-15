using System;
using System.Collections.Generic;
using System.Web;
using WapXzone_VNM.Library.SQLHelper;
using System.Web.Configuration;
using System.Configuration;
using System.IO;
using System.Text;
using System.Data;

namespace WapXzone_VNM.Library.Component.Transaction
{
    public class TransactionController
    {
        public TransactionController() { 
        }
        #region bỏ ghi log vào DB
        public static int Insert_Transaction(TransactionInfo obj)
        {
            //return (int)SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Transaction_Insert_vnm", obj.Wap_TransactionName, obj.Wap_TransactionType, obj.Wap_TransactionDetail, obj.Wap_TransactionOn, obj.Wap_Transaction_Mobile, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Link, obj.Wap_Transaction_Amount, obj.Is3g);
            return 1;
        }
        public static int Insert_TransactionLog(TransactionLogInfo obj)
        {
            //return (int)SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Transaction_Insert_Log_vnm", obj.Wap_TransactionName, obj.Wap_TransactionType, obj.Wap_TransactionDetail, obj.Wap_TransactionOn, obj.Wap_Transaction_Mobile, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Link, obj.Wap_Transaction_Amount, obj.ErrorCode, obj.ErrorDetail, obj.Is3g);
            return 1;
        }

        public static int Insert_Transaction_New(TransactionInfo obj)
        {
            //return (int)SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Transaction_Insert_New", obj.Wap_TransactionName, obj.Wap_TransactionType, obj.Wap_TransactionDetail, obj.Wap_TransactionOn, obj.Wap_Transaction_Mobile, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Link, obj.Wap_Transaction_Amount);
            return 1;
        }
        public static int Insert_TransactionLog_New(TransactionLogInfo obj)
        {
            //return (int)SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Transaction_Insert_Log_New", obj.Wap_TransactionName, obj.Wap_TransactionType, obj.Wap_TransactionDetail, obj.Wap_TransactionOn, obj.Wap_Transaction_Mobile, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Link, obj.Wap_Transaction_Amount, obj.ErrorCode, obj.ErrorDetail);
            return 1;
        }


        static log4net.ILog log = log4net.LogManager.GetLogger("File");

        public static int Insert_Transaction_Log(Transaction_LogInfo obj)
        {
            return 1;
        }

        //public static int Insert_Transaction(TransactionInfo obj)
        //{
        //    return (int)SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Transaction_Insert_vnm", obj.Wap_TransactionName,obj.Wap_TransactionType,obj.Wap_TransactionDetail,obj.Wap_TransactionOn,obj.Wap_Transaction_Mobile,obj.Wap_Transaction_Portal,obj.Wap_Transaction_Portal,obj.Wap_Transaction_Link,obj.Wap_Transaction_Amount,obj.Is3g);
        //}
        //public static int Insert_TransactionLog(TransactionLogInfo obj)
        //{
        //    return (int)SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Transaction_Insert_Log_vnm", obj.Wap_TransactionName, obj.Wap_TransactionType, obj.Wap_TransactionDetail, obj.Wap_TransactionOn, obj.Wap_Transaction_Mobile, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Link, obj.Wap_Transaction_Amount, obj.ErrorCode, obj.ErrorDetail, obj.Is3g);
        //}

        //public static int Insert_Transaction_New(TransactionInfo obj)
        //{
        //    return (int)SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Transaction_Insert_New", obj.Wap_TransactionName, obj.Wap_TransactionType, obj.Wap_TransactionDetail, obj.Wap_TransactionOn, obj.Wap_Transaction_Mobile, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Link, obj.Wap_Transaction_Amount);
        //}
        //public static int Insert_TransactionLog_New(TransactionLogInfo obj)
        //{
        //    return (int)SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Transaction_Insert_Log_New", obj.Wap_TransactionName, obj.Wap_TransactionType, obj.Wap_TransactionDetail, obj.Wap_TransactionOn, obj.Wap_Transaction_Mobile, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Link, obj.Wap_Transaction_Amount, obj.ErrorCode, obj.ErrorDetail);
        //}


        //static log4net.ILog log = log4net.LogManager.GetLogger("File");

        //public static int Insert_Transaction_Log(Transaction_LogInfo obj)
        //{
        //    string folderName = ConfigurationManager.AppSettings.Get("LogCDR") + DateTime.Now.ToString("yyyyMMdd") + "/";
        //    string fileName = "ErrorCDR_" + DateTime.Now.ToString("yyyyMMdd") + ".txt";
        //    string path = folderName + fileName;
        //    if (!Directory.Exists(folderName))
        //    {
        //        Directory.CreateDirectory(folderName);
        //    }
        //    try
        //    {
        //        return (int)SqlHelper.ExecuteScalar(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Transaction_Insert_Log", obj.Wap_TransactionName, obj.Wap_TransactionType, obj.Wap_TransactionDetail, obj.Wap_TransactionOn, obj.Wap_Transaction_Mobile, obj.Wap_Transaction_Portal, obj.Wap_Transaction_Operator, obj.Wap_Transaction_Link, obj.Wap_Transaction_Amount, obj.ErrorCode, obj.ErrorDetail);
        //    }
        //    catch
        //    {
        //        WriteFileLogCdrToHardDisk(path, obj, fileName);
        //        return 1;
        //    }
        //}
        #endregion
        private static void WriteFileLogCdrToHardDisk(string path, Transaction_LogInfo obj, string fileName)
        {
            try
            {
                FileStream texlog = null;
                if (!File.Exists(path))
                {
                    texlog = File.Create(path);
                }
                else
                {
                    texlog = new FileStream(path, FileMode.Append);
                }
                AddText(texlog, obj.Wap_TransactionName + "|");
                AddText(texlog, obj.Wap_TransactionType + "|");
                AddText(texlog, obj.Wap_TransactionDetail.Replace("\r\n", "").Replace("\n", "").Replace("\r", "") + "|");
                AddText(texlog, obj.Wap_TransactionOn + "|");
                AddText(texlog, obj.Wap_Transaction_Mobile + "|");
                AddText(texlog, obj.Wap_Transaction_Portal + "|");
                AddText(texlog, obj.Wap_Transaction_Operator + "|");
                AddText(texlog, obj.Wap_Transaction_Link + "|");
                AddText(texlog, obj.Wap_Transaction_Amount + "|");
                AddText(texlog, obj.ErrorCode + "|");
                AddText(texlog, obj.ErrorDetail);
                AddText(texlog, Environment.NewLine);

                texlog.Close();
                texlog.Dispose();
            }
            catch (Exception ex)
            {
                log.Debug("Happen error when write file:" + fileName + Environment.NewLine + ex.Message);
            }
        }

        private static void AddText(FileStream fs, string value)
        {
            byte[] info = new UTF8Encoding(true).GetBytes(value);
            fs.Write(info, 0, info.Length);
        }

        public static void Delete_Transaction(int transactionid)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Transaction_Delete", transactionid);
        }

        public static bool CheckExistedBuyItem(string msisdn, string Portal, DateTime sentTime, string type)
        {
            int _type = 0;
            switch (type)
            {
                case "WALLPAPER":
                    _type = (int)WapXzone_VNM.Library.Constant.Constant.Chancel.WALLPAPER;
                    break;
                case "RINGTONE":
                    _type = (int)WapXzone_VNM.Library.Constant.Constant.Chancel.RINGTONE;
                    break;
                case "GAME":
                    _type = (int)WapXzone_VNM.Library.Constant.Constant.Chancel.GAME;
                    break;
                case "APPLICATION":
                    _type = (int)WapXzone_VNM.Library.Constant.Constant.Chancel.APP;
                    break;
                case "VIDEO":
                    _type = (int)WapXzone_VNM.Library.Constant.Constant.Chancel.VIDEO;
                    break;
                case "YKCG":
                    _type = (int)WapXzone_VNM.Library.Constant.Constant.Chancel.YKCG;
                    break;
                case "TIP":
                    _type = (int)WapXzone_VNM.Library.Constant.Constant.Chancel.TIP;
                    break;
                case "KQCHO":
                    _type = (int)WapXzone_VNM.Library.Constant.Constant.Chancel.KQCHO;
                    break;
                case "KQXS":
                    _type = (int)WapXzone_VNM.Library.Constant.Constant.Chancel.KQXS;
                    break;
                case "SOICAU":
                    _type = (int)WapXzone_VNM.Library.Constant.Constant.Chancel.SOICAU;
                    break;
                case "XSKQCHO":
                    _type = (int)WapXzone_VNM.Library.Constant.Constant.Chancel.XSKQCHO;
                    break;
                case "XOSO20":
                    _type = (int)WapXzone_VNM.Library.Constant.Constant.Chancel.XS20;
                    break;
                case "RELAX":
                    _type = (int)WapXzone_VNM.Library.Constant.Constant.Chancel.THUGIAN;
                    break;
                case "GAME87":
                    _type = (int)WapXzone_VNM.Library.Constant.Constant.Chancel.GAME87;
                    break;
                case "THUPHAP":
                    _type = (int)WapXzone_VNM.Library.Constant.Constant.Chancel.THUPHAP;
                    break;
                case "DIEMTHI":
                    _type = (int)WapXzone_VNM.Library.Constant.Constant.Chancel.DIEMTHI;
                    break;
            }
            //DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_CheckExistedTransactionInSecond", msisdn, sentTime, "Viettel", _type);
            //if (ds != null && ds.Tables.Count > 0)
            //{
            //    DataTable dt = ds.Tables[0];
            //    if (dt != null && dt.Rows.Count > 0)
            //    {
            //        return false;
            //    }

            //    return true;
            //}
            return true;
        }
    }
}
