using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using WapXzone_VNM.Library.SQLHelper;
using System.Web.Configuration;
using System.Data.SqlClient;
using WapXzone_VNM.Library.Utilities;
using System.Configuration;
using WapXzone_VNM.Library.Cache;

namespace WapXzone_VNM.Library.Component.Phanmem
{
    public class PhanmemController
    {
        public PhanmemController() { 
        }
        private static double GetExpire()
        {
            return ConvertUtility.ToDouble(ConfigurationSettings.AppSettings.Get("timeexpired"));
        }

        //Lay app moi nhat
        public static DataTable GetAppLastestHasCache(string telCo, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_App.GetAppLastest";
            string param = "telCo=" + telCo + "&cp=" + pageindex;
            string totalRcKey = "W4A_Wap_App.GetAppLastest_TotalRecord_" + "_" + telCo;
            Object dataTotalRecord = data.GetHashCache(totalRcKey, telCo);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetAppLastest(telCo, pagesize, pageindex, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, telCo, GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable GetAppLastest(string telCo, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_App_GetItemLastest", dbConn);
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

        //Lay tat ca chuyen muc App va order theo thu tu
        public static DataTable GetAllCategoryExeptCatIDHasCache(string telCo, int displayType, int catID)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_App.GetAllCategoryExeptCatID";
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
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_App_CategoryAll", telCo, displayType, catID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay thong tin chuyen muc
        public static DataTable GetCategoryByCatIDHasCache(int ID)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_App.GetCategoryByCatID";
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
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_App_Category_GetInfo", catID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay App theo cau hinh va chuyen muc va sap xep theo thu tu
        public static DataTable GetAllAppByCategoryAndDisplayTypeHasCache(string telCo, int catID, int displayType, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_App.GetAllAppByCategoryAndDisplayType";
            string param = "telCo=" + telCo + "Catid=" + catID + "&display=" + displayType + "&cp=" + pageindex + "&pagesize=" + pagesize; ;
            string totalRcKey = "W4A_Wap_App.GetAllAppByCategoryAndDisplayType_TotalRecord_" + displayType + "_" + catID;
            Object dataTotalRecord = data.GetHashCache(totalRcKey, catID);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetAllAppByCategoryAndDisplayType(telCo, catID, displayType, pagesize, pageindex, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, catID, GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable GetAllAppByCategoryAndDisplayType(string telCo, int catID, int displayType, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_App_GetItemByCategoryAndDisplayType", dbConn);
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

        //Lay APP HO TRO theo cau hinh va chuyen muc va sap xep theo thu tu
        public static DataTable GetAllAppByCateTypeAndAgent(string telCo, int catID, int displayType, User_AgentInfo _info, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_App.GetAllAppByCateTypeAndAgent";
            string param = "telCo=" + telCo + "&catID=" + catID + "&info=" + _info.model_name;

            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval == null || dtRetval.Rows.Count == 0)
            {
                DataTable dtCat = GetAllAppByCategoryAndDisplayTypeHasCache(telCo, catID, displayType, 9999, 1, out totalrecord);
                //Xoá những game không hỗ trợ
                for (int i = 0; i < totalrecord; i++)
                {
                    if (!MobileUtils.CheckValidModel(dtCat.Rows[i]["ModelSupport"].ToString(), _info))
                    {
                        dtCat.Rows[i].Delete();
                    }
                }
                dtCat.AcceptChanges();
                //Ghi vào cache
                data.SetHashCache(key, param, GetExpire(), dtCat);
                dtRetval = dtCat;
            }
            totalrecord = dtRetval.Rows.Count;

            //
            int vFrom = ((pageindex - 1) * pagesize);
            int vTo = pageindex * pagesize;
            if (vTo > totalrecord) vTo = totalrecord;
            DataTable dtReturn = dtRetval.Clone();
            for (int i = vFrom; i < vTo; i++)
            {
                dtReturn.ImportRow(dtRetval.Rows[i]);
            }
            return dtReturn;
        }

        //Lay thong tin APP
        public static DataTable GetAPPDetailByIDHasCache(string telCo, int ID)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_App.GetAPPDetailByID";
            string param = "telCo=" + telCo + "&id=" + ID;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetAPPDetailByID(telCo, ID);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetAPPDetailByID(string telCo, int ID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_App_Item_GetInfo", telCo, ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Search App
        public static DataTable GetAllApp_ItemByKey(string telCo, string strKeySearch, int pagesize, int pageIndex, out int totalRecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_App_ItemSearchByKey", dbConn);
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

        //Search App Agent
        public static DataTable GetAllApp_ItemByKeyAndAgent(string telCo, string strKeySearch, User_AgentInfo _info, int pagesize, int pageIndex, out int totalRecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_App.GetAllApp_ItemByKeyAndAgent";
            string param = "telCo=" + telCo + "&KeySearch=" + strKeySearch + "&info=" + _info.model_name;

            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval == null || dtRetval.Rows.Count == 0)
            {
                DataTable dtCat = GetAllApp_ItemByKey(telCo, strKeySearch, 9999, 1, out totalRecord);
                //Xoá những game không hỗ trợ
                for (int i = 0; i < totalRecord; i++)
                {
                    if (!MobileUtils.CheckValidModel(dtCat.Rows[i]["ModelSupport"].ToString(), _info))
                    {
                        dtCat.Rows[i].Delete();
                    }
                }
                dtCat.AcceptChanges();
                //Ghi vào cache
                data.SetHashCache(key, param, GetExpire(), dtCat);
                dtRetval = dtCat;
            }
            totalRecord = dtRetval.Rows.Count;

            //
            int vFrom = ((pageIndex - 1) * pagesize);
            int vTo = pageIndex * pagesize;
            if (vTo > totalRecord) vTo = totalRecord;
            DataTable dtReturn = dtRetval.Clone();
            for (int i = vFrom; i < vTo; i++)
            {
                dtReturn.ImportRow(dtRetval.Rows[i]);
            }
            return dtReturn;
        }

        //Tăng số lần download
        public static void SetDownloadCounter(string telCo, int ID)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_App_SetDownloadCounter", telCo, ID);
        }   
    }
}
