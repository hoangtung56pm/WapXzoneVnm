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

namespace WapXzone_VNM.Library.Component.Tintuc
{
    public class TintucController
    {
        public TintucController() { }
        private static double GetExpire()
        {
            return ConvertUtility.ToDouble(ConfigurationSettings.AppSettings.Get("news_expired"));
        }
        //Lay tat ca chuyen muc nhac chuong va order theo thu tu
        public static DataTable GetAllCategoryExeptCatIDHasCache(int parentID, int catID)
        {
            DataCaching data = new DataCaching();
            string key = "VMS_NEWs.GetAllCategoryExeptCatID";
            string param = "parentid=" + parentID + "&catid=" + catID;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetAllCategoryExeptCatID(parentID, catID);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetAllCategoryExeptCatID(int parentID, int catID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_CMS_Zones_GetByParentID", parentID, catID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay top nhung tin moi nhat cua trang tin tuc
        public static DataTable GetTopNewsHasCache(int parentID, int top)
        {
            DataCaching data = new DataCaching();
            string key = "VMS_NEWs.GetTopNews";
            string param = "catid=" + parentID + "&top=" + top;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetTopNews(parentID, top);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetTopNews(int parentID, int top)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "VNM_Wap_CMS_Get_Top_New_ByZoneID", parentID, top);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay thong tin chuyen muc
        public static DataTable GetCategoryByCatIDHasCache(int catID)
        {
            DataCaching data = new DataCaching();
            string key = "VMS_NEWs.GetCategoryByCatID";
            string param = "&catid=" + catID;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetCategoryByCatID(catID);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }

        public static DataTable GetCategoryForHotNewsHomeCache()
        {
            DataCaching data = new DataCaching();
            string key = "VMS_NEWs.GetCategoryForHotNewsHomeCache";
            string param = "GetCategoryForHotNewsHomeCache";
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) 
                return dtRetval;

            DataTable dtPortals = GetCategoryForHotNewsHome();
            data.SetHashCache(key, param, GetExpire(), dtPortals);
            return dtPortals;
        }

        public static DataTable GetCategoryForHotNewsHome()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_GetCategoryForHotNewsHome");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetCategoryByCatID(int catID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_CMS_Zones_GetInfo", catID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataSet GetAudioBookByCategoryCache(string catId, int pageNumber, int pageSize)
        {
            DataCaching data = new DataCaching();
            string key = "VMS_NEWs.GetAudioBookByCategoryCache";
            string param = "catid=" + catId + "&index=" + pageNumber;
            DataSet dtRetval = (DataSet)data.GetHashCache(key, param);

            if (dtRetval != null && dtRetval.Tables.Count > 0) return dtRetval;

            DataSet dtPortals = GetAudioBookByCategory(catId, pageNumber, pageSize);
            data.SetHashCache(key, param, GetExpire(), dtPortals);
            return dtPortals;
        }

        public static DataSet GetAudioBookByCategory(string catId,int pageNumber,int pageSize)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_GetAudioBookByCategory", catId,pageNumber,pageSize);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
            return null;
        }

        //Lay top tin tuc có phân trang
        public static DataTable GetTopNewsWithPaggingHasCache(int catID, int pagesize, int pageindex, int top, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "VMS_NEWs.GetTopNewsWithPagging";
            string param = "Catid=" + catID + "&cp=" + pageindex + "&top=" + top;
            string totalRcKey = "VMS_NEWs.GetTopNewsWithPagging_TotalRecord_" + catID;
            Object dataTotalRecord = data.GetHashCache(totalRcKey, catID);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetTopNewsWithPagging(catID, pagesize, pageindex, top, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, catID, GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable GetTopNewsWithPagging(int catID, int pagesize, int pageindex, int top, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Wap_CMS_Get_TopWPG_New_ByZoneID", dbConn);
            dbCmd.Parameters.AddWithValue("@ZoneID", catID);
            dbCmd.Parameters.AddWithValue("@PageNumber", pageindex);
            dbCmd.Parameters.AddWithValue("@PageSize", pagesize);
            dbCmd.Parameters.Add(new SqlParameter("@totalRows", SqlDbType.Int));
            dbCmd.Parameters["@totalRows"].Direction = ParameterDirection.Output;
            dbCmd.Parameters.AddWithValue("@Top", top);
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


        //Lay Tin tuc theo chuyen muc
        public static DataTable GetAllNewsByCategoryHasCache(int catID, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "VMS_NEWs.GetAllNewsByCategory";
            string param = "Catid=" + catID + "&cp=" + pageindex + "&pageSize=" + pagesize;
            string totalRcKey = "VMS_NEWs.GetAllNewsByCategory_TotalRecord_" + catID;
            Object dataTotalRecord = data.GetHashCache(totalRcKey, catID);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetAllNewsByCategory(catID, pagesize, pageindex, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, catID, GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable GetAllNewsByCategory(int catID, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Wap_CMS_Get_NewsByZoneID", dbConn);
            dbCmd.Parameters.AddWithValue("@PageNumber", pageindex);
            dbCmd.Parameters.AddWithValue("@PageSize", pagesize);
            dbCmd.Parameters.Add(new SqlParameter("@totalRows", SqlDbType.Int));
            dbCmd.Parameters["@totalRows"].Direction = ParameterDirection.Output;
            dbCmd.Parameters.AddWithValue("@ZoneID", catID);
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


        public static DataTable GetAllNewsByCategoryHasCacheVnm(int catID, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "VMS_NEWs.GetAllNewsByCategoryHasCacheVnm";
            string param = "Catid=" + catID + "&cp=" + pageindex + "&pageSize=" + pagesize;
            string totalRcKey = "VMS_NEWs.GetAllNewsByCategory_TotalRecord_" + catID;
            Object dataTotalRecord = data.GetHashCache(totalRcKey, catID);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetAllNewsByCategoryVnm(catID, pagesize, pageindex, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, catID, GetExpire(), totalrecord);
                return dtPortals;
            }
        }

        public static DataTable GetAllNewsByCategoryVnm(int catID, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Wap_CMS_Get_NewsByZoneID_Vnm", dbConn);
            dbCmd.Parameters.AddWithValue("@PageNumber", pageindex);
            dbCmd.Parameters.AddWithValue("@PageSize", pagesize);
            dbCmd.Parameters.Add(new SqlParameter("@totalRows", SqlDbType.Int));
            dbCmd.Parameters["@totalRows"].Direction = ParameterDirection.Output;
            dbCmd.Parameters.AddWithValue("@ZoneID", catID);
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


        //Lay Tin tuc da dang cung chuyen muc
        public static DataTable GetTopNewsOlderByCategoryHasCache(int catID, int disid, int Top)
        {
            DataCaching data = new DataCaching();
            string key = "VMS_NEWs.GetTopNewsOlderByCategory";
            string param = "&catid=" + catID + "&disid=" + disid + "&top=" + Top;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetTopNewsOlderByCategory(catID, disid, Top);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetTopNewsOlderByCategory(int catID, int disid,int Top)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Wap_CMS_GetOther_NewsByZoneID", dbConn);
            dbCmd.Parameters.AddWithValue("@ZoneID", catID);
            dbCmd.Parameters.AddWithValue("@DisID", disid);
            dbCmd.Parameters.AddWithValue("@Top", Top);
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
        //Search tin tuc
        public static DataTable GetAllNewsByKey(string key, int pagesize, int pageindex, out int totalrecord,int zoneid)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Wap_CMS_Get_NewsByKey", dbConn);
            dbCmd.Parameters.AddWithValue("@PageNumber", pageindex);
            dbCmd.Parameters.AddWithValue("@PageSize", pagesize);
            dbCmd.Parameters.Add(new SqlParameter("@totalRows", SqlDbType.Int));
            dbCmd.Parameters["@totalRows"].Direction = ParameterDirection.Output;
            dbCmd.Parameters.AddWithValue("@Key", key);
            dbCmd.Parameters.AddWithValue("@ZoneID", zoneid);
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
        //Lay chi tiet tin
        public static DataTable GetNewsDetailHasCache(int disid)
        {
            DataCaching data = new DataCaching();
            string key = "VMS_NEWs.GetNewsDetail";
            string param = "&disid=" + disid;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetNewsDetail(disid);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }

        public static DataTable GetNewsDetail(int disid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_CMS_Get_NewsDetail", disid);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetAudioBookDetailCache(string id)
        {
            DataCaching data = new DataCaching();
            string key = "VMS_NEWs.GetAudioBookDetailCache";
            string param = "&id=" + id;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) 
                return dtRetval;

            DataTable dtPortals = GetAudioBookDetail(id);
            data.SetHashCache(key, param, GetExpire(), dtPortals);
            return dtPortals;
        }

        public static DataTable GetAudioBookDetail(string id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_GetAudioBookDetail", id);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetRandomForSmile()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_GetRamdomForRelax");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetRandomForNews()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_GetRamdomForNews");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetTopRandomForSmile()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_GetTopRamdomForRelax");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetTopRandomForDissipated()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_GetTopRamdomForDissipated");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetTopRandomForDtr()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_GetTopRamdomForDTR");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetRandomForHoangDao()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_GetRamdomForHoangDao");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetTopRandomForHoangDao()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_GetTopRamdomForHoangDao");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetTopRandomForSexAndLife()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_GetTopRamdomForSexAndLife");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetGioiTinhHomeCache()
        {
            DataCaching data = new DataCaching();
            string key = "VMS_NEWs.GetGioiTinhHomeCache";
            string param = "GetGioiTinhHomeCache";
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0)
                return dtRetval;

            DataTable dtPortals = GetGioiTinhHome();
            data.SetHashCache(key, param, GetExpire(), dtPortals);
            return dtPortals;
        }

        public static DataSet GetTruyenOnlineHomeCache()
        {
            DataCaching data = new DataCaching();
            string key = "VMS_NEWs.GetTruyenOnlineHomeCache";
            string param = "GetTruyenOnlineHomeCache";
            DataSet dtRetval = (DataSet)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Tables.Count > 0)
                return dtRetval;

            DataSet dtPortals = GetTruyenOnlineHome();
            data.SetHashCache(key, param, GetExpire(), dtPortals);
            return dtPortals;
        }

        public static DataTable GetGioiTinhHome()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_GioiTinhHome");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetNewsChargingCache()
        {
            DataCaching data = new DataCaching();
            string key = "VMS_NEWs.GetNewsCharging";
            string param = "GetNewsCharging";
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0)
                return dtRetval;

            DataTable dtPortals = GetNewsCharging();
            data.SetHashCache(key, param, GetExpire(), dtPortals);
            return dtPortals;
        }

        public static DataTable GetNewsCharging()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_GetNewsCharging");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetCategoryTruyenAudioCache()
        {
            DataCaching data = new DataCaching();
            string key = "VMS_NEWs.GetCategoryTruyenAudioCache";
            string param = "GetCategoryTruyenAudioCache";
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0)
                return dtRetval;

            DataTable dtPortals = GetCategoryTruyenAudio();
            data.SetHashCache(key, param, GetExpire(), dtPortals);
            return dtPortals;
        }

        public static DataTable GetCategoryTruyenAudio()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_GetCategoryForAudioBook");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataSet GetTruyenOnlineHome()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_TruyenOnlineHome");
            if (ds != null && ds.Tables.Count > 0)
                return ds;
            return null;
        }

        public static DataSet GetTruyenAudioHome()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_Vnm_GetAudioBookHome");
            if (ds != null && ds.Tables.Count > 0)
                return ds;
            return null;
        }

        public static DataSet GetTruyenAudioHomeCache()
        {
            DataCaching data = new DataCaching();
            string key = "VMS_NEWs.GetTruyenAudioHomeCache";
            string param = "GetTruyenAudioHomeCache";
            DataSet dtRetval = (DataSet)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Tables.Count > 0)
                return dtRetval;

            DataSet dtPortals = GetTruyenAudioHome();
            data.SetHashCache(key, param, GetExpire(), dtPortals);
            return dtPortals;
        }

        public static DataSet WebGetNewsCategory()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Vnm_Wap_News_GetByParentId",0);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
            return null;
        }

        public static DataSet WebGetNewsCategoryCache()
        {
            var data = new DataCaching();
            string key = "VMS_NEWs.WebGetNewsCategoryCache";
            string param = "WebGetNewsCategoryCache";
            var dtRetval = (DataSet)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Tables.Count > 0)
                return dtRetval;

            DataSet dtPortals = WebGetNewsCategory();
            data.SetHashCache(key, param, GetExpire(), dtPortals);
            return dtPortals;
        }


        public static DataSet WebGetNewsByCatId(int catId)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Vnm_Wap_News_GetByCatId", catId);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
            return null;
        }

        public static DataSet WebGetNewsByCatIdCache(int catId)
        {
            var data = new DataCaching();
            string key = "VMS_NEWs.WebGetNewsByCatIdCache";
            string param = "WebGetNewsByCatIdCache&catId=" + catId;
            var dtRetval = (DataSet)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Tables.Count > 0)
                return dtRetval;

            DataSet dtPortals = WebGetNewsByCatId(catId);
            data.SetHashCache(key, param, GetExpire(), dtPortals);
            return dtPortals;
        }


        public static DataSet WebGetNewsInfo(int id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Vnm_Wap_News_GetInfo", id);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
            return null;
        }

        public static DataSet WebGetNewsInfoCache(int id)
        {
            var data = new DataCaching();
            string key = "VMS_NEWs.WebGetNewsInfoCache";
            string param = "WebGetNewsInfoCache&id=" + id;
            var dtRetval = (DataSet)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Tables.Count > 0)
                return dtRetval;

            DataSet dtPortals = WebGetNewsInfo(id);
            data.SetHashCache(key, param, GetExpire(), dtPortals);
            return dtPortals;
        }


        public static bool CheckIsCharging(string msisdn)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_CMS_CheckIsCharging", msisdn,"VNM");
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ConvertUtility.ToInt32(ds.Tables[0].Rows[0]["IsCharging"]) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public static void Cancel(string msisdn)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_CMS_DeleteMSISDN", msisdn);
        }
    }
}
