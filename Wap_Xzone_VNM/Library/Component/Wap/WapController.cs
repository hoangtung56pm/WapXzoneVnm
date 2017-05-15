using System;
using System.Collections.Generic;

using System.Web;
using System.Web.Configuration;
using System.Data;
using System.Data.SqlClient;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.SQLHelper;
using System.Configuration;
using WapXzone_VNM.Library.Cache;

namespace WapXzone_VNM.Library.Component.Wap
{
    public class WapController
    {
        public WapController()
        {
        }
        private static double GetExpire()
        {
            return ConvertUtility.ToDouble(ConfigurationSettings.AppSettings.Get("timeexpired"));
        }
        //Lay thong tin chuyen muc
        public static DataTable CPConfig_GetByWap_IDHasCache(int wap_ID)
        {
            DataCaching data = new DataCaching();
            string key = "Wap_CPConfig.GetByWap_ID";
            string param = "wap_ID=" + wap_ID.ToString();
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = CPConfig_GetByWap_ID(wap_ID);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable CPConfig_GetByWap_ID(int wap_ID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_CPConfig_GetByWap_ID", wap_ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //
        public static DataTable Setting_Category_GetAllByParentIDHasCache(int parentID, int portalID)
        {
            DataCaching data = new DataCaching();
            string key = "Wap_Setting.Category_GetAllByParentID";
            string param = "parentID=" + parentID.ToString() + "&portalID=" + portalID.ToString();
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = Setting_Category_GetAllByParentID(parentID, portalID);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable Setting_Category_GetAllByParentID(int parentID, int portalID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_Setting_Category_GetAllByParentID", parentID, portalID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static Boolean W4A_Subscriber_IsActive(string PhoneNumber, int ServiceID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Subscriber_GetInfo", PhoneNumber, ServiceID);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                return true;
            return false;
        }

        public static DataTable W4A_Subscriber_GetInfo(string PhoneNumber, int ServiceID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Subscriber_GetInfo", PhoneNumber, ServiceID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable WapVnmGetGiftCodeByMsisdn(string msisdn)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TTND_Services"].ConnectionString, "Wap_Vnm_GetGiftCodeByMsisdn_New", msisdn);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static void W4A_Subscriber_Insert(string PhoneNumber, int ServiceID, int DayAdd, string Info)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Subscriber_Insert", PhoneNumber, ServiceID, DayAdd, Info);
        }

        public static void AlertVnmCharging(string userId, string message, string serviceId, string commandCode, string messageType, string requestId, int totalMessage, int messageIndex, int isMore, int contentType, int serviceType, string partnerId, string opera)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "SMS_MT_Insert_AlertVNMCharging", userId, message, serviceId, commandCode,
                                                                messageType, requestId, totalMessage, messageIndex, isMore, contentType, serviceType, partnerId, opera);
        }

        public static DataTable WapVnmGetAdvByPosId(int posId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_GetAdv_ByPosId", posId);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        #region VOTE METHODS

        public static DataTable VoteRegisterInsert(VoteRegisteredInfo entity)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Vote_Registered_Users_Insert"
                , entity.User_ID
                , entity.Request_ID
                , entity.Service_ID
                , entity.Command_Code
                , entity.Service_Type
                , entity.Charging_Count
                , entity.FailedChargingTime
                , entity.RegisteredTime
                , entity.ExpiredTime
                , entity.Registration_Channel
                , entity.Status
                , entity.Operator
                , entity.Vote_Count
                , entity.Vote_PersonId
                , entity.IsDislike

                );

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static DataTable VoteRegisterDislikeInsert(VoteRegisteredInfo entity)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Vote_Registered_Users_Dislike_Insert"

                , entity.User_ID
                , entity.Request_ID
                , entity.Service_ID
                , entity.Command_Code
                , entity.Service_Type
                , entity.Charging_Count
                , entity.FailedChargingTime
                , entity.RegisteredTime
                , entity.ExpiredTime
                , entity.Registration_Channel
                , entity.Status
                , entity.Operator
                , entity.Dislike_Count
                , entity.Dislike_PersonId

                );

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static void VoteChargedUserLogInsert(VoteChargedUserLogInfo entity)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Vote_Charged_Users_Log_Insert"
                                         , entity.User_ID
                                         , entity.Request_ID
                                         , entity.Service_ID
                                         , entity.Command_Code
                                         , entity.Service_Type
                                         , entity.Charging_Count
                                         , entity.FailedChargingTime
                                         , entity.RegisteredTime
                                         , entity.ExpiredTime
                                         , entity.Registration_Channel
                                         , entity.Status
                                         , entity.Operator
                                         , entity.Reason
                                         , entity.Price
                                         , entity.Vote_PersonId
                                     );
        }

        public static DataSet GetTopUserVote(int personId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Wap_Vnm_GetTopUser_ByPersonId_New", personId);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public static DataSet NewGetTopUserVote()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Vote_New_GetTopUser");
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public static DataTable VoteGetCount(string userId, string commandCode)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Vote_GetCount_Info", userId, commandCode);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static DataTable VoteGetCountByPersonId(string userId, int personId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Vote_GetCount_Info_ByPersonId", userId, personId);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static DataTable SecretRegisterInsert(VoteRegisteredInfo entity)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Secret_Registered_Users_Insert"
                , entity.User_ID
                , entity.Request_ID
                , entity.Service_ID
                , entity.Command_Code
                , entity.Service_Type
                , entity.Charging_Count
                , entity.FailedChargingTime
                , entity.RegisteredTime
                , entity.ExpiredTime
                , entity.Registration_Channel
                , entity.Status
                , entity.Operator
                , entity.Vote_Count
                , entity.Vote_PersonId
                , entity.IsDislike

                );

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static DataTable NewVoteRegisterInsert(VoteRegisteredInfo entity)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Vote_New_Registered_Users_Insert"
                , entity.User_ID
                , entity.Request_ID
                , entity.Service_ID
                , entity.Command_Code
                , entity.Service_Type
                , entity.Charging_Count
                , entity.FailedChargingTime
                , entity.RegisteredTime
                , entity.ExpiredTime
                , entity.Registration_Channel
                , entity.Status
                , entity.Operator
                , entity.Vote_Count
                , entity.Vote_PersonId
                , entity.IsDislike

                );

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static DataTable NewVoteGetUserInfo(string userId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Vote_New_Registered_Users_GetInfo", userId);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static DataTable SecretRegisterInsertForWapVnm(VoteRegisteredInfo entity)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Secret_Registered_Users_Insert_ForWapVnm"
                , entity.User_ID
                , entity.Request_ID
                , entity.Service_ID
                , entity.Command_Code
                , entity.Service_Type
                , entity.Charging_Count
                , entity.FailedChargingTime
                , entity.RegisteredTime
                , entity.ExpiredTime
                , entity.Registration_Channel
                , entity.Status
                , entity.Operator
                , entity.Vote_Count
                , entity.Vote_PersonId
                , entity.IsDislike

                );

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static void SecretChargedUserLogInsert(VoteChargedUserLogInfo entity)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Secret_Charged_Users_Log_Insert"
                                         , entity.User_ID
                                         , entity.Request_ID
                                         , entity.Service_ID
                                         , entity.Command_Code
                                         , entity.Service_Type
                                         , entity.Charging_Count
                                         , entity.FailedChargingTime
                                         , entity.RegisteredTime
                                         , entity.ExpiredTime
                                         , entity.Registration_Channel
                                         , entity.Status
                                         , entity.Operator
                                         , entity.Reason
                                         , entity.Price
                                         , entity.Vote_PersonId
                                     );
        }

        public static void NewVoteChargedUserLogInsert(VoteChargedUserLogInfo entity)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Vote_New_Charged_Users_Log_Insert"
                                         , entity.User_ID
                                         , entity.Request_ID
                                         , entity.Service_ID
                                         , entity.Command_Code
                                         , entity.Service_Type
                                         , entity.Charging_Count
                                         , entity.FailedChargingTime
                                         , entity.RegisteredTime
                                         , entity.ExpiredTime
                                         , entity.Registration_Channel
                                         , entity.Status
                                         , entity.Operator
                                         , entity.Reason
                                         , entity.Price
                                         , entity.Vote_PersonId
                                     );
        }

        public static DataSet SecretGetTopUserVote(int personId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Secret_GetTopUser_ByPersonId_New", personId);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public static DataTable SecretGetCountByPersonId(string userId, int personId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Secret_GetCount_Info_ByPersonId", userId, personId);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static DataTable VnmS294XConfigGetByStatus()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Vnm_S294x_Config_GetByStatus");
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static DataTable VnmPartnerConfigGetByStatus()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Vnm_Partner_Definitions_GetActive");
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static DataTable VnmAdvanceConfigGetByStatus()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Vnm_Advance_Config_GetByStatus");
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }


        public static DataTable VnmS294XConfigGetInfo(string message)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Vnm_S294x_Config_GetByMessage", message);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static DataTable VnmCheckBlackList(string msisdn)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Vnm_CheckBlackList", msisdn);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static DataTable VnmGetUrl()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Sport_Game_Hero_GetUrl");
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static void VnmUrlUpdate(int isLog)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Sport_Game_Hero_GetUrl", isLog);
        }

        public static void Transaction_Online_Delete(string msisdn)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionStringPayment"].ConnectionString, CommandType.Text, "DELETE FROM Transaction_Online WHERE MSISDN='" + msisdn + "'");
        }

        public static void WapUserLog(string userId,int? categoryId,string path,int type)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_User_Log_Add", userId, categoryId, path, type);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public static DataTable BigPromotionGetCode(string userId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Thanh_Nu_GetCodeByUserId", userId);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        public static string PortalSettingGetbyKey(string key)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Portal_PortalSettings_GetSettingsByKey", key);
            DataTable tblVal = null;
            if (ds != null && ds.Tables.Count > 0)
            {
                tblVal =  ds.Tables[0];
            }
            if (tblVal != null && tblVal.Rows.Count > 0)
            {
                return ConvertUtility.ToString(tblVal.Rows[0]["SettingValue"]);
            }
            return "";
        }

        public static DataTable S2_94xGetServiceInfo(int serviceid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TTND_Services"].ConnectionString, "S2_TTND_Subscription_Services_GetByID", serviceid);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }


        public static DataTable S2_1119GetServiceInfo(int serviceid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_1119"].ConnectionString, "S2_1119_Subscription_Services_GetByID", serviceid);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        #endregion

        public static bool IsRightServiceID(string template, string input)
        {
            string[] templateItems = template.Split('|');

            foreach (string item in templateItems)
            {
                string keyword = item.Trim();

                if (keyword != String.Empty && keyword.ToUpper() == input.ToUpper()) return true;
            }

            return false;
        }
        #region RegisterConfirm
        public static void WapRegisterConfirm_Insert(string TransactionID,string User_ID,int Type,int Service_ID,string ServiceName,string Description)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString_TTND_Services"].ConnectionString, "WapRegisterConfirm_Insert"
                                         , TransactionID, User_ID, Type, Service_ID, ServiceName, Description
                                     );
        }
        public static DataTable WapRegisterConfirm_GetInfo(string TransactionID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TTND_Services"].ConnectionString, "WapRegisterConfirm_GetInfo", TransactionID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static Int32 UnixTimeStampUTC()
        {
            Int32 unixTimeStamp;
            DateTime currentTime = DateTime.Now;
            DateTime zuluTime = currentTime.ToUniversalTime();
            DateTime unixEpoch = new DateTime(1970, 1, 1);
            unixTimeStamp = (Int32)(zuluTime.Subtract(unixEpoch)).TotalSeconds;
            return unixTimeStamp;
        }
        #endregion
        public static void VmgAds94x_Log_Insert
            (
                string UserAgent,
                string ModelName,
                string BrandName,
                string DeviceOS,
                string MobileBrowser,
                string ResolutionWidth,
                string ResolutionHeight,
                string Telco,
                int IsWifi,
                int IsMobileDevice,
                string UrlReferer,
                string link,
                string IP,
                string Type,
                string CMD,
                string Msisdn,                
                string requestType,
                int status,
                int Service_ID
            )
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString_TTND_Services"].ConnectionString, "VmgAds94x_Log_Insert",
                UserAgent,
                ModelName,
                BrandName,
                DeviceOS,
                MobileBrowser,
                ResolutionWidth,
                ResolutionHeight,
                Telco,
                IsWifi,
                IsMobileDevice,
                UrlReferer,
                link,
                IP,
                Type,
                CMD,
                Msisdn,                
                requestType,
                status,
                Service_ID
                );
        }
        private static string Get_ClientIp
        {
            get
            {
                var _ip = HttpContext.Current.Request.UserHostAddress;
                return _ip;
            }
        }
    }
}
