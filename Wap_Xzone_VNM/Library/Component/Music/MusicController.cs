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

namespace WapXzone_VNM.Library.Component.Music
{
    public class MusicController
    {
        public MusicController()
        {
        }
        private static double GetExpire()
        {
            return ConvertUtility.ToDouble(ConfigurationSettings.AppSettings.Get("timeexpired"));
        }

        //Style
        public static DataTable GetStyleTopHasCache(int top)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_Style.GetStyleTop";
            string param = "top=" + top;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetStyleTop(top);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetStyleTop(int top)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Music_Style_GetTop", top);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }


        public static DataTable GetStyleHasCache(int pageindex, int pagesize, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_Style.GetStyle";
            string param = "pageindex=" + pageindex + "pagesize=" + pagesize;
            string totalRcKey = "W4A_Music_Style.GetStyle_TotalRecord_";
            Object dataTotalRecord = data.GetHashCache(totalRcKey, "all");
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetStyle(pageindex, pagesize, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, "all", GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable GetStyle(int pageIndex, int pageSize, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Music_Style_Get", dbConn);
            dbCmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            dbCmd.Parameters.AddWithValue("@PageSize", pageSize);
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

        public static DataTable GetStyleByIDHasCache(string id)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_Style.GetStyleByID";
            string param = "id=" + id;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetStyleByID(id);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetStyleByID(string id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Music_Style_GetInfo", id);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        //Artist
        public static DataTable GetArtistTopHasCache(int top)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_Artist.GetArtistTop";
            string param = "top=" + top;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetArtistTop(top);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetArtistTop(int top)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Music_Artist_GetTop", top);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }


        public static DataTable GetArtistHasCache(int pageindex, int pagesize, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_Artist.GetArtist";
            string param = "pageindex=" + pageindex + "pagesize=" + pagesize;
            string totalRcKey = "W4A_Music_Artist.GetArtist_TotalRecord_";
            Object dataTotalRecord = data.GetHashCache(totalRcKey, "all");
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetArtist(pageindex, pagesize, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, "all", GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable GetArtist(int pageIndex, int pageSize, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Music_Artist_Get", dbConn);
            dbCmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            dbCmd.Parameters.AddWithValue("@PageSize", pageSize);
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

        public static DataTable GetArtistByIDHasCache(string id)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_Artist.GetArtistByID";
            string param = "id=" + id;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetArtistByID(id);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetArtistByID(string id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Music_Artist_GetInfo", id);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }


        //Album        
        public static DataTable GetAlbumHasCache(string telCo, int pageindex, int pagesize, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_Album.GetAlbum";
            string param = "pageindex=" + pageindex + "pagesize=" + pagesize + "telCo=" + telCo;
            string totalRcKey = "W4A_Music_Album.GetAlbum_TotalRecord_";
            Object dataTotalRecord = data.GetHashCache(totalRcKey, telCo);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetAlbum(telCo, pageindex, pagesize, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, telCo, GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable GetAlbum(string telCo, int pageIndex, int pageSize, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Music_Album_Get", dbConn);
            dbCmd.Parameters.AddWithValue("@Telco", telCo);
            dbCmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            dbCmd.Parameters.AddWithValue("@PageSize", pageSize);
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

        public static DataTable GetAlbumHotHasCache(string telCo)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_Album.GetAlbumHot";
            string param = "telCo=" + telCo;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetAlbumHot(telCo);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetAlbumHot(string telCo)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Music_Album_GetHot", telCo);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }



        //Music Item
        public static DataTable GetItemByAlbumHasCache(int albumID, string telCo)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_AlbumItem.GetItemByAlbum";
            string param = "albumID=" + albumID + "&telCo=" + telCo;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetItemByAlbum(albumID, telCo);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetItemByAlbum(int albumID, string telCo)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Music_Item_GetByAlbum", albumID, telCo);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable GetItemWithPagingHasCache(string telCo, int PageIndex, int PageSize, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_Item.GetItemWithPagingHasCache";
            string param = "telCo=" + telCo + "&PageIndex=" + PageIndex + "&PageSize=" + PageSize;
            string totalRcKey = "W4A_Music_Item.GetItemWithPagingHasCache_TotalRecord_" + telCo;
            Object dataTotalRecord = data.GetHashCache(totalRcKey, "itemall");
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetItemWithPaging(telCo, PageIndex, PageSize, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, "itemall", GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable GetItemWithPaging(string telCo, int PageIndex, int PageSize, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Music_Item_GetWithPaging", dbConn);
            dbCmd.Parameters.AddWithValue("@Telco", telCo);
            dbCmd.Parameters.AddWithValue("@PageIndex", PageIndex);
            dbCmd.Parameters.AddWithValue("@PageSize", PageSize);
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

        public static DataTable GetItemTopHasCache(string telCo, int top)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_Item.GetItemTop";
            string param = "telCo=" + telCo + "&top=" + top;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetItemTop(telCo, top);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetItemTop(string telCo, int top)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Music_Item_GetTop", telCo, top);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        //
        //Music Item
        public static DataTable GetItemByAlbumWithPagingHasCache(int albumID, string telCo, int PageIndex, int PageSize, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_AlbumItem.GetItemByAlbumWithPagingHasCache";
            string param = "telCo=" + telCo + "&albumID=" + albumID + "&PageIndex=" + PageIndex + "&PageSize=" + PageSize;
            string totalRcKey = "W4A_Wap_Game.GetItemByCategoryAndDisplayType_TotalRecord_" + telCo + "_" + albumID;
            Object dataTotalRecord = data.GetHashCache(totalRcKey, albumID);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetItemByAlbumWithPaging(albumID, telCo, PageIndex, PageSize, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, albumID, GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable GetItemByAlbumWithPaging(int albumID, string telCo, int PageIndex, int PageSize, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Music_Item_GetByAlbumWithPaging", dbConn);
            dbCmd.Parameters.AddWithValue("@W_MAlbumID", albumID);
            dbCmd.Parameters.AddWithValue("@Telco", telCo);            
            dbCmd.Parameters.AddWithValue("@PageIndex", PageIndex);
            dbCmd.Parameters.AddWithValue("@PageSize", PageSize);
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

        public static DataTable GetRandomItemByAlbumWithPaging(int albumID, string telCo)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Music_Item_GetRandomeByAlbumWithPaging", dbConn);
            dbCmd.Parameters.AddWithValue("@W_MAlbumID", albumID);
            dbCmd.Parameters.AddWithValue("@Telco", telCo);
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
        //
        public static DataTable GetItemTopByAlbumHasCache(int albumID, string telCo, int top)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_AlbumItem.GetItemTopByAlbum";
            string param = "albumID=" + albumID + "&telCo=" + telCo + "&top=" + top;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetItemTopByAlbum(albumID, telCo, top);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetItemTopByAlbum(int albumID, string telCo, int top)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Music_Item_GetTopByAlbum", albumID, telCo, top);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //
        public static DataTable GetItemByArtistHasCache(string telCo, string artistID, int pageindex, int pagesize, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_Artist.GetItemByArtist";
            string param = "pageindex=" + pageindex + "&pagesize=" + pagesize + "&telCo=" + telCo + "&artistID=" + artistID;
            string totalRcKey = "W4A_Music_Artist.GetItemByArtist_TotalRecord_";
            Object dataTotalRecord = data.GetHashCache(totalRcKey, telCo + artistID);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetItemByArtist(telCo, artistID, pageindex, pagesize, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, telCo + artistID, GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable GetItemByArtist(string telCo, string artistID, int pageIndex, int pageSize, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Music_Item_GetByArtist", dbConn);
            dbCmd.Parameters.AddWithValue("@ArtistID", artistID);
            dbCmd.Parameters.AddWithValue("@Telco", telCo);
            dbCmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            dbCmd.Parameters.AddWithValue("@PageSize", pageSize);
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

        //
        public static DataTable GetItemByStyleHasCache(string telCo, string styleID, int pageindex, int pagesize, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_Style.GetItemByStyle";
            string param = "pageindex=" + pageindex + "&pagesize=" + pagesize + "&telCo=" + telCo + "&styleID=" + styleID;
            string totalRcKey = "W4A_Music_Artist.GetItemByArtist_TotalRecord_";
            Object dataTotalRecord = data.GetHashCache(totalRcKey, telCo + styleID);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetItemByStyle(telCo, styleID, pageindex, pagesize, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, telCo + styleID, GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable GetItemByStyle(string telCo, string styleID, int pageIndex, int pageSize, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Music_Item_GetByStyle", dbConn);
            dbCmd.Parameters.AddWithValue("@StyleID", styleID);
            dbCmd.Parameters.AddWithValue("@Telco", telCo);
            dbCmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            dbCmd.Parameters.AddWithValue("@PageSize", pageSize);
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
        //
        public static DataTable SearchMusicItem(string telCo, string keyWord, string type, int pageIndex, int pageSize, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("W4A_Wap_Music_Item_Search", dbConn);
            dbCmd.Parameters.AddWithValue("@Keyword", keyWord);
            dbCmd.Parameters.AddWithValue("@Type", type);
            dbCmd.Parameters.AddWithValue("@Telco", telCo);
            dbCmd.Parameters.AddWithValue("@PageIndex", pageIndex);
            dbCmd.Parameters.AddWithValue("@PageSize", pageSize);
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
        //        /// 
        public static DataTable GetItemDetailHasCache(string telCo, int id)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_Item.GetItemDetail";
            string param = "id=" + id;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetItemDetail(telCo, id);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetItemDetail(string telCo, int id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Music_Item_GetInfo", telCo, id);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay ngau nhien 1 bai khac bai theo ID
        public static DataTable GetItemDetailRandom(string telCo, int ID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Music_Item_Random", telCo, ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //
        public static DataTable GetAlbumByIDHasCache(int albumID)
        {
            DataCaching data = new DataCaching();
            string key = "W4A_Music_AlbumItem.GetAlbumByID";
            string param = "albumID=" + albumID;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = GetAlbumByID(albumID);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                return dtPortals;
            }
        }
        public static DataTable GetAlbumByID(int albumID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Music_Album_GetInfo", albumID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }  

        //Tăng số lần download
        public static void SetDownloadCounter(string telCo, int ID)
        {
            SqlHelper.ExecuteNonQuery(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "W4A_Wap_Music_SetDownloadCounter", telCo, ID);
        }   
    }
}
