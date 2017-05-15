using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using System.Data.SqlClient;
using WapXzone_VNM.Library.Utilities;
using System.Web.Configuration;
using WapXzone_VNM.Library.SQLHelper;
using System.Configuration;
using WapXzone_VNM.Library.Cache;

namespace WapXzone_VNM.Library.Component.Game
{
    public class GameController
    {
        private static double GetExpire()
        {
            return ConvertUtility.ToDouble(ConfigurationSettings.AppSettings.Get("timeexpired"));
        }

        private static double GetGameExpire()
        {
            return ConvertUtility.ToDouble(ConfigurationSettings.AppSettings.Get("game_expired"));
        }
        //Lay Game theo cau hinh va chuyen muc va sap xep theo thu tu
        public static DataTable GetAllGameByCategoryAndDisplayTypeHasCache(string telCo, int catID, int displayType, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Game.GetItemByCategoryAndDisplayType";
            string param = "telCo=" + telCo + "&catID=" + catID + "&display=" + displayType + "&cp=" + pageindex + "&pagesize=" + pagesize;
            string totalRcKey = "W4A_Wap_Game.GetItemByCategoryAndDisplayType_TotalRecord_" + displayType + "_" + catID;
            Object dataTotalRecord = data.GetHashCache(totalRcKey, catID);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;

            DataTable dtPortals = GetAllGameByCategoryAndDisplayType(telCo, catID, displayType, pagesize, pageindex, out totalrecord);
            data.SetHashCache(key, param, GetExpire(), dtPortals);
            data.SetHashCache(totalRcKey, catID, GetExpire(), totalrecord);
            return dtPortals;
        }
        public static DataTable GetAllGameByCategoryAndDisplayType(string telCo, int catID, int displayType, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Game_GetItemByCategoryAndDisplayType", dbConn);
            dbCmd.Parameters.AddWithValue("@Telco", telCo);
            dbCmd.Parameters.AddWithValue("@CatID", catID);
            dbCmd.Parameters.AddWithValue("@DisplayType", displayType);
            dbCmd.Parameters.AddWithValue("@PageNumber", pageindex);
            dbCmd.Parameters.AddWithValue("@PageSize", pagesize);
            dbCmd.Parameters.Add(new SqlParameter("@totalRows", SqlDbType.Int));
            dbCmd.Parameters["@totalRows"].Direction = ParameterDirection.Output;
            dbCmd.Parameters.AddWithValue("@PortalID", 74);
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

        //Lay GAME HO TRO theo cau hinh va chuyen muc va sap xep theo thu tu
        public static DataTable GetAllGameByCateTypeAndAgent(string telCo, int catID, int displayType, User_AgentInfo _info, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Game.GetItemByCatTypeAndAgent";
            string param = "telCo=" + telCo + "&catID=" + catID + "&info=" + _info.model_name;

            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval == null || dtRetval.Rows.Count == 0)
            {
                DataTable dtCat = GetAllGameByCategoryAndDisplayTypeHasCache(telCo, catID, displayType, 9999, 1, out totalrecord);
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

        public static DataTable GetAllGameByCateTypeAndAgentNoCache(string telCo, int catID, int displayType, User_AgentInfo _info, int pagesize, int pageindex, out int totalrecord)
        {
            var dtRetval = new DataTable();

            if (dtRetval.Rows.Count == 0)
            {
                DataTable dtCat = GetAllGameByCategoryAndDisplayType(telCo, catID, displayType, 9999, 1, out totalrecord);
                //Xoá những game không hỗ trợ
                for (int i = 0; i < totalrecord; i++)
                {
                    if (!MobileUtils.CheckValidModel(dtCat.Rows[i]["ModelSupport"].ToString(), _info))
                    {
                        dtCat.Rows[i].Delete();
                    }
                }
                dtCat.AcceptChanges();
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

        //Lay game moi nhat
        public static DataTable GetItemLastestHasCache(string telCo, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Game.GetWallpaperLastest";
            string param = "telCo=" + telCo + "&cp=" + pageindex;
            string totalRcKey = "W4A_Wap_Game.GetWallpaperLastest_TotalRecord_" + "_" + telCo;
            Object dataTotalRecord = data.GetHashCache(totalRcKey, telCo);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            DataTable dtPortals = GetGameLastest(telCo, pagesize, pageindex, out totalrecord);
            data.SetHashCache(key, param, GetExpire(), dtPortals);
            data.SetHashCache(totalRcKey, telCo, GetExpire(), totalrecord);
            return dtPortals;
        }
        public static DataTable GetGameLastest(string telCo, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Game_GetItemLastest", dbConn);
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

        //Lay tat ca chuyen muc Game va order theo thu tu
        public static DataTable GetAllCategoryExeptCatIDHasCache(string telCo, int displayType, int catID)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Game.CategoryAll";
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
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Game_CategoryAll", telCo, displayType, catID, 74);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay thong tin chuyen muc
        public static DataTable GetCategoryByCatIDHasCache(int ID)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Game.Category_GetInfo";
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
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Game_Category_GetInfo", catID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay thong tin Game
        public static DataTable GetGameDetailByIDHasCache(string telCo, int ID)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Game.Item_GetInfo";
            string param = "telCo=" + telCo + "&id=" + ID;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetGameDetailByID(telCo, ID);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetGameDetailByID(string telCo, int ID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Game_Item_GetInfo", telCo, ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }


        //Search Game
        public static DataTable GetAllGame_ItemByKey(string telCo, string strKeySearch, int pagesize, int pageIndex, out int totalRecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Game_ItemSearchByKey", dbConn);
            dbCmd.Parameters.AddWithValue("@Telco", telCo);
            dbCmd.Parameters.AddWithValue("@KeySeach", strKeySearch);
            dbCmd.Parameters.AddWithValue("@PageNumber", pageIndex);
            dbCmd.Parameters.AddWithValue("@PageSize", pagesize);
            dbCmd.Parameters.Add(new SqlParameter("@totalRows", SqlDbType.Int));
            dbCmd.Parameters["@totalRows"].Direction = ParameterDirection.Output;
            dbCmd.Parameters.AddWithValue("@PortalID", 74);
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
        //Search Game Agent
        public static DataTable GetAllGame_ItemByKeyAndAgent(string telCo, string strKeySearch, User_AgentInfo _info, int pagesize, int pageIndex, out int totalRecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Wap_Game.GetAllGame_ItemByKeyAndAgent";
            string param = "telCo=" + telCo + "&KeySearch=" + strKeySearch + "&info=" + _info.model_name;

            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval == null || dtRetval.Rows.Count == 0)
            {
                DataTable dtCat = GameController.GetAllGame_ItemByKey(telCo, strKeySearch, 9999, 1, out totalRecord);
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
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Game_SetDownloadCounter", telCo, ID);
        }

        public static void SetGamePrice(string msisdn, string urlReturn,string serviceDetail,int price)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Vnm_Wap_GameReport_UpdatePrice", msisdn, urlReturn, serviceDetail, price);
        }

        public static DataTable GetAllGame_ByPackageID(int packageId)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("VNMGetAllGameByPackageID", dbConn);
            dbCmd.Parameters.AddWithValue("@PackageID", packageId);
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

        public static DataTable GetAllGameJavaHasCache()
        {
            DataCaching data = new DataCaching();
            string key = "GetAllGameJavaHasCache";
            string param = "GetAllGameJavaHasCachePartner";
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0)
                return dtRetval;

            DataTable dtPortals = GetAllGameJava();
            data.SetHashCache(key, param, GetGameExpire(), dtPortals);
            return dtPortals;
        }

        public static DataTable GetAllGameJava()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_VNM_GetJavaGameDownload");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetAllGameJavaVnmHasCache()
        {
            DataCaching data = new DataCaching();
            string key = "GetAllGameJavaVnmHasCache";
            string param = "GetAllGameJavaVnmHasCachePartner";
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0)
                return dtRetval;

            DataTable dtPortals = GetAllGameJavaVnm();
            data.SetHashCache(key, param, GetGameExpire(), dtPortals);
            return dtPortals;
        }

        public static DataTable GetAllGameJavaVnm()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Wap_VNM_GetJavaGameDownload_Vnm");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static int GetFreeGame(string msisdn)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TTND_Services"].ConnectionString, "VNMS2CountFreeGame", msisdn);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return Convert.ToInt32(ds.Tables[0].Rows[0]["Charged_Count"]);
                }
                else
                {
                    return 0;
                }
            }
            else
            {
                return 0;
            }
        }


        public static DataTable Getuserinfo(string username, int service_id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TTND_Services"].ConnectionString, "S2TTND_Getuserinfo", username, service_id);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
    }
}
