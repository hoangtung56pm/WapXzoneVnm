using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Cache;
using WapXzone_VNM.Library.SQLHelper;

namespace WapXzone_VNM.VClip.Library
{
    public class VideoController
    {
        private static double GetExpire()
        {
            return ConvertUtility.ToDouble(ConfigurationSettings.AppSettings.Get("timeexpired"));
        }

        public static DataTable GetAllVideoByCategoryAndDisplayTypeHasCache(string telCo, int catID, int exceptID, int displayType, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Video.GetAllVideoByCategoryAndDisplayType";
            string param = "telCo=" + telCo + "&Catid=" + catID + "&display=" + displayType + "&cp=" + pageindex + "&pagesize=" + pagesize + "&exceptID=" + exceptID;
            string totalRcKey = "VMS_Video.GetAllVideoByCategoryAndDisplayType_TotalRecord_" + displayType + "_" + catID;
            Object dataTotalRecord = data.GetHashCache(totalRcKey, catID);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetAllVideoByCategoryAndDisplayType(telCo, catID, exceptID, displayType, pagesize, pageindex, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, catID, GetExpire(), totalrecord);
                return dtPortals;
            }
        }

        public static DataTable GetAllVideoByCategoryAndDisplayType(string telCo, int catID, int exceptID, int displayType, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Video_GetItemByCategoryAndDisplayType", dbConn);
            dbCmd.Parameters.AddWithValue("@Telco", telCo);
            dbCmd.Parameters.AddWithValue("@CatID", catID);
            dbCmd.Parameters.AddWithValue("@exceptID", exceptID);
            dbCmd.Parameters.AddWithValue("@DisplayType", displayType);
            dbCmd.Parameters.AddWithValue("@PageNumber", pageindex);
            dbCmd.Parameters.AddWithValue("@PageSize", pagesize);
            dbCmd.Parameters.Add(new SqlParameter("@totalRows", SqlDbType.Int));
            dbCmd.Parameters["@totalRows"].Direction = ParameterDirection.Output;
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
                totalrecord = ConvertUtility.ToInt32(dbCmd.Parameters["@totalRows"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static DataTable GetAllCategoryExeptCatIDHasCache(string telCo, int displayType, int catID)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Video.GetAllCategoryExeptCatID";
            string param = "telCo=" + telCo + "&display=" + displayType + "&catid=" + catID;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetAllCategoryExeptCatID(telCo, displayType, catID);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }

        public static DataTable GetAllCategoryExeptCatID(string telCo, int displayType, int catID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Video_CategoryAll", telCo, displayType, catID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetCategoryByCatIDHasCache(int ID)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Video_Category.GetCategoryByCatID";
            string param = "id=" + ID;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetCategoryByCatID(ID);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }

        public static DataTable GetCategoryByCatID(int catID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Video_Category_GetInfo", catID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetAllWap_Video_ItemByKey(string telCo, string strKeySearch, int pagesize, int pageIndex, out int totalRecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Video_ItemSearchByKey", dbConn);
            dbCmd.Parameters.AddWithValue("@Telco", telCo);
            dbCmd.Parameters.AddWithValue("@KeySeach", strKeySearch);
            dbCmd.Parameters.AddWithValue("@PageNumber", pageIndex);
            dbCmd.Parameters.AddWithValue("@PageSize", pagesize);
            dbCmd.Parameters.Add(new SqlParameter("@totalRows", SqlDbType.Int));
            dbCmd.Parameters["@totalRows"].Direction = ParameterDirection.Output;
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
                totalRecord = ConvertUtility.ToInt32(dbCmd.Parameters["@totalRows"].Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dbConn.Close();
            }
            return retVal;
        }

        public static DataTable GetVideoDetailByIDHasCache(string telCo, int ID)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Video.GetVideoDetailByID";
            string param = "telCo=" + telCo + "&id=" + ID;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetVideoDetailByID(telCo, ID);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetVideoDetailByID(string telCo, int ID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Video_Item_GetInfo_New", telCo, ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetMsisdnInfo(string msisdn, string serviceId, DateTime expiryTime)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString139"].ConnectionString, "VClip_Subscription_GetAll", msisdn, expiryTime, serviceId);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static DataTable GetMsisdnInfoHashCache(string msisdn)
        {    
            DataTable dtPortals = GetMsisdnInfo(msisdn, "VCLIP", DateTime.Now);
            return dtPortals;
        }

        public static bool UpdateMsisdnExpiryTime(string id, DateTime expiryTime)
        {
            try
            {
                SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_VNClip_UpdateMsisdnExpiryTime", id, expiryTime);
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static DataTable GetMsisdnInfo(string msisdn)
        {
            DataSet ds =
                SqlHelper.ExecuteDataset(
                    WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString,
                    "Wap_VNClip_GetMsisdnInfo", msisdn);

            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }

            return null;
        }
    }
}