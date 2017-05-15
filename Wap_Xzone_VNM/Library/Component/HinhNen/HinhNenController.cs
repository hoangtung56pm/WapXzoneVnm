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

namespace WapXzone_VNM.Library.Component.HinhNen
{
    public class HinhNenController
    {
        public HinhNenController()
        {
        }
        private static double GetExpire()
        {
            return ConvertUtility.ToDouble(ConfigurationSettings.AppSettings.Get("timeexpired"));
        }
        //Lay tat ca chuyen muc hinh nen va order theo thu tu
        public static DataTable GetAllCategoryExeptCatIDHasCache(string telCo, int displayType, int catID)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Wallpaper.GetAllCategoryExeptCatID";
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
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Wallpaper_CategoryAll", telCo, displayType, catID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay thong tin chuyen muc
        public static DataTable GetCategoryByCatIDHasCache(int ID)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Wallpaper.Category_GetInfo";
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
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wallpaper_Category_GetInfo", catID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay thong tin hinh nen
        public static DataTable GetWallpaperDetailByIDHasCache(string telCo, int ID)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Wallpaper.Item_GetInfo";
            string param = "telCo=" + telCo + "@id=" + ID;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetWallpaperDetailByID(telCo, ID);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetWallpaperDetailByID(string telCo, int ID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Wallpaper_Item_GetInfo", telCo, ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay hinh nen theo cau hinh va chuyen muc va sap xep theo thu tu
        public static DataTable GetAllWallpaperByCategoryAndDisplayTypeHasCache(string telCo, int catID, int displayType, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Wallpaper.GetAllWallpaperByCategoryAndDisplayType";
            string param = "telCo=" + telCo + "&catID=" + catID + "&display=" + displayType + "&cp=" + pageindex;
            string totalRcKey = "W4A_Wallpaper.GetAllWallpaperByCategoryAndDisplayType_TotalRecord_" + displayType + "_" + catID + "_" + telCo;
            Object dataTotalRecord = data.GetHashCache(totalRcKey, catID.ToString() + telCo);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetAllWallpaperByCategoryAndDisplayType(telCo, catID, displayType, pagesize, pageindex, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, catID.ToString() + telCo, GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable GetAllWallpaperByCategoryAndDisplayType(string telCo, int catID, int displayType, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);            
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Wallpaper_GetItemByCategoryAndDisplayType", dbConn);
            dbCmd.Parameters.AddWithValue("@Telco", telCo);
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

        public static DataTable GetRandomWallpaperByCategoryAndDisplayType(string telCo, int catID, int displayType)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Wallpaper_GetRandomItemByCategoryAndDisplayType", dbConn);
            dbCmd.Parameters.AddWithValue("@Telco", telCo);
            dbCmd.Parameters.AddWithValue("@CatID", catID);
            dbCmd.Parameters.AddWithValue("@DisplayType", displayType);
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

        //Lay hinh nen moi nhat
        public static DataTable GetItemLastestHasCache(string telCo, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Wallpaper.GetWallpaperLastest";
            string param = "telCo=" + telCo + "&cp=" + pageindex;
            string totalRcKey = "W4A_Wallpaper.GetWallpaperLastest_TotalRecord_" + "_" + telCo;
            Object dataTotalRecord = data.GetHashCache(totalRcKey, telCo);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetWallpaperLastest(telCo, pagesize, pageindex, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, telCo, GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable GetWallpaperLastest(string telCo, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Wallpaper_GetItemLastest", dbConn);
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
        //Search hinh nen

        public static DataTable GetAllWap_Wallpaper_ItemByKey(string telCo, string strKeySearch, int pagesize, int pageIndex, out int totalRecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Wallpaper_ItemSearchByKey", dbConn);
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
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Wallpaper_SetDownloadCounter", telCo, ID);
        }

        public static DataTable GetAllWap_HinhNen_ByPackageID(int packageId)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("VNMDownloadHinhNenByPackageID", dbConn);
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
