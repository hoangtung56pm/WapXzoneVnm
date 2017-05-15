using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Web.Configuration;
using WapXzone_VNM.Library.SQLHelper;
using System.Data.SqlClient;
using WapXzone_VNM.Library.Utilities;
using System.Configuration;
using WapXzone_VNM.Library.Cache;

namespace WapXzone_VNM.Library.Component.Nhacchuong
{
    public class RTController
    {
        public RTController()
        {
        }
        private static double GetExpire()
        {
            return ConvertUtility.ToDouble(ConfigurationSettings.AppSettings.Get("timeexpired"));
        }
        //Lay thong tin ring tone
        public static DataTable GetRingToneDetailByIDHasCache(string telCo, int ID)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Ringtone.GetRingToneDetailByID";
            string param = "telCo=" + telCo + "&id=" + ID;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetRingToneDetailByID(telCo, ID);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetRingToneDetailByID(string telCo, int ID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Ringtone_Item_GetInfo", telCo, ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay ngau nhien 1 bai khac bai theo ID
        public static DataTable GetRingToneDetailRandom(string telCo, int ID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Ringtone_Item_Random", telCo, ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay thong tin chuyen muc
        public static DataTable GetCategoryByCatIDHasCache(int ID)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Ringtone_Category.GetCategoryByCatID";
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
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Ringtone_Category_GetInfo", catID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay tat ca chuyen muc nhac chuong va order theo thu tu
        public static DataTable GetAllCategoryExeptCatIDHasCache(string telCo, int displayType, int catID)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Ringtone.GetAllCategoryExeptCatID";
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
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Ringtone_CategoryAll", telCo, displayType, catID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        //Lay ringtone theo cau hinh va chuyen muc va sap xep theo thu tu
        public static DataTable GetAllRingToneByCategoryAndDisplayTypeHasCache(string telCo, int catID, int displayType, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Ringtone.GetAllRingToneByCategoryAndDisplayType";
            string param = "telCo=" + telCo + "&Catid=" + catID + "&display=" + displayType + "&cp=" + pageindex;
            string totalRcKey = "W4A_Wap_Ringtone.GetAllRingToneByCategoryAndDisplayType_TotalRecord_" + displayType + "_" + catID;
            Object dataTotalRecord = data.GetHashCache(totalRcKey, catID);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetAllRingToneByCategoryAndDisplayType(telCo, catID, displayType, pagesize, pageindex, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, catID, GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable GetAllRingToneByCategoryAndDisplayType(string telCo, int catID, int displayType, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Ringtone_GetItemByCategoryAndDisplayType", dbConn);
            dbCmd.Parameters.AddWithValue("@telCo", telCo);
            dbCmd.Parameters.AddWithValue("@CatID", catID);
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

        //Lay ringtone theo cau hinh va chuyen muc va sap xep theo thu tu
        public static DataTable VNM_GetAllRingToneByCategoryAndDisplayTypeHasCache(int catID, int displayType, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "VNM_RingTone.GetAllRingToneByCategoryAndDisplayType";
            string param = "Catid=" + catID + "&display=" + displayType + "&cp=" + pageindex;
            string totalRcKey = "VNM_RingTone.GetAllRingToneByCategoryAndDisplayType_TotalRecord_" + displayType + "_" + catID;
            Object dataTotalRecord = data.GetHashCache(totalRcKey, catID);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = VNM_GetAllRingToneByCategoryAndDisplayType(catID, displayType, pagesize, pageindex, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, catID, GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable VNM_GetAllRingToneByCategoryAndDisplayType(int catID, int displayType, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("VNM_Wap_RingTone_GetItemByCategoryAndDisplayType", dbConn);
            dbCmd.Parameters.AddWithValue("@CatID", catID);
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

        //Lay video moi nhat
        public static DataTable GetRingtoneLastestHasCache(string telCo, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Ringtone.GetVideoLastest";
            string param = "telCo=" + telCo + "&cp=" + pageindex;
            string totalRcKey = "W4A_Wap_Ringtone.GetRingtoneLastest_TotalRecord_" + "_" + telCo;
            Object dataTotalRecord = data.GetHashCache(totalRcKey, telCo);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetRingtoneLastest(telCo, pagesize, pageindex, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, telCo, GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable GetRingtoneLastest(string telCo, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Ringtone_GetItemLastest", dbConn);
            dbCmd.Parameters.AddWithValue("@Telco", telCo);
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

        //Search RingTone

        public static DataTable GetAllWap_RingTone_ItemByKey(string telCo, string strKeySearch, int pagesize, int pageIndex, out int totalRecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Ringtone_ItemSearchByKey", dbConn);
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

        //Tăng số lần download
        public static void SetDownloadCounter(string telCo, int ID)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Ringtone_SetDownloadCounter", telCo, ID);
        }

        public static DataTable GetAllWap_RingTone_ByPackageID(int packageId)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("VNMDownloadByPackageID", dbConn);
            dbCmd.Parameters.AddWithValue("@PackageId", packageId);
            dbCmd.CommandType = CommandType.StoredProcedure;
            try
            {
                retVal = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(dbCmd);
                da.Fill(retVal);
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
    }
}
