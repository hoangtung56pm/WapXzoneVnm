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

namespace WapXzone_VNM.Library.Component.Video
{
    public class VideoController
    {
        public VideoController()
        {
        }
        private static double GetExpire()
        {
            return ConvertUtility.ToDouble(ConfigurationSettings.AppSettings.Get("timeexpired"));
        }
        //Lay thong tin chuyen muc
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
        //Lay tat ca chuyen muc video va order theo thu tu
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
        //Lay thong tin Video
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
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Video_Item_GetInfo", telCo, ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay video theo cau hinh va chuyen muc va sap xep theo thu tu
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

        //Lay video moi nhat
        public static DataTable GetVideoLastestHasCache(string telCo, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Video.GetVideoLastest";
            string param = "telCo=" + telCo + "&cp=" + pageindex;
            string totalRcKey = "W4A_Wap_Video.GetVideoLastest_TotalRecord_" + "_" + telCo;
            Object dataTotalRecord = data.GetHashCache(totalRcKey, telCo);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetVideoLastest(telCo, pagesize, pageindex, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, telCo, GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable GetVideoLastest(string telCo, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Video_GetItemLastest", dbConn);
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

        //Search video

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
        //Tăng số lần download
        public static void SetDownloadCounter(string telCo, int ID)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Video_SetDownloadCounter", telCo, ID);
        }

        public static DataTable GetAllWap_Video_ByPackageID(int packageId)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("VNMDownloadVideoByPackageID", dbConn);
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

        #region KHO_CLIP

        //Lay thong tin Video
        public static DataTable KhoClipGetTopCache()
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Video.KhoClipGetTopCache";
            string param = "KhoClipGetTopCache";
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            DataTable dtPortals = KhoClipGetTop();
            data.SetHashCache(key, param, GetExpire(), dtPortals);
            return dtPortals;
        }

        public static DataTable KhoClipGetTop()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "KhoClip_Video_WapVnm_GetTop");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }


        public static DataSet KhoClipGetListCache(int pageSize, int currPage)
        {
            var data = new DataCaching();
            string key = "W4A_Wap_Video.KhoClipGetListCache";
            string param = "KhoClipGetListCache&cuPage=" + currPage;
            var dtRetval = (DataSet)data.GetHashCache(key, param);

            if (dtRetval != null && dtRetval.Tables.Count > 0) 
                return dtRetval;

            DataSet dtPortals = KhoClipGetList(pageSize, currPage);
            data.SetHashCache(key, param, GetExpire(), dtPortals);
            return dtPortals;
        }

        public static DataSet KhoClipGetList(int pageSize, int currPage)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "KhoClip_Video_WapVnm_GetList", pageSize, currPage);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
            return null;
        }


        public static DataSet KhoClipSearch(string key,int pageSize, int currPage)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "KhoClip_Video_Search", key, pageSize, currPage);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
            return null;
        }

        public static DataTable KhoClipGetInfoCache(int id)
        {
            var data = new DataCaching();
            string key = "W4A_Wap_Video.KhoClipGetInfoCache";
            string param = "KhoClipGetInfoCache&Id=" + id;
            var dtRetval = (DataTable)data.GetHashCache(key, param);

            if (dtRetval != null && dtRetval.Rows.Count > 0)
                return dtRetval;

            DataTable dtPortals = KhoClipGetInfo(id);
            data.SetHashCache(key, param, GetExpire(), dtPortals);
            return dtPortals;
        }

        public static DataTable KhoClipGetInfo(int id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "KhoClip_Video_GetInfo", id);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        #endregion

    }
}
