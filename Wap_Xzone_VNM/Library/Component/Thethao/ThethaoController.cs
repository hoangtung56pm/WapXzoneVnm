using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using WapXzone_VNM.Library.SQLHelper;
using System.Web.Configuration;
using System.Data.SqlClient;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Cache;

namespace WapXzone_VNM.Library.Component.Thethao
{
    public class ThethaoController
    {

        private const string Key = "Wap_VNM_TheThao";

        public ThethaoController()
        {
        }
        private static double GetExpire()
        {
            return ConvertUtility.ToDouble(System.Configuration.ConfigurationSettings.AppSettings.Get("timeexpired")) * 2;
        }
        //Lay tat giai dau va order theo thu tu
        public static DataTable GetAllCategoryExeptCatID(int portalID, int catID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "VNM_Wap_CompetitionGetAll", portalID, catID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay tat giai dau va order theo thu tu trừ giải đấu truyền vào
        public static DataTable GetCompetitionGetByWID(int W_CompetitionID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "VNM_Wap_CompetitionGetByWID", W_CompetitionID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        //public static DataTable GetAllGameByTipFinish(int pagesize, int pageindex, out int totalrecord)
        //{
        //    DataTable retVal = null;
        //    SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //    SqlCommand dbCmd = new SqlCommand("VNM_Wap_GamesHaveTipGetAll_Finish", dbConn);
        //    dbCmd.Parameters.AddWithValue("@from", DateTime.Now.AddDays(-1));
        //    dbCmd.Parameters.AddWithValue("@to", DateTime.Now);
        //    dbCmd.Parameters.AddWithValue("@PageNumber", pageindex);
        //    dbCmd.Parameters.AddWithValue("@PageSize", pagesize);
        //    dbCmd.Parameters.Add(new SqlParameter("@totalRows", SqlDbType.Int));
        //    dbCmd.Parameters["@totalRows"].Direction = ParameterDirection.Output;
        //    dbCmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        retVal = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(dbCmd);
        //        da.Fill(retVal);
        //        totalrecord = ConvertUtility.ToInt32(dbCmd.Parameters["@totalRows"].Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dbConn.Close();
        //    }
        //    return retVal;
        //}
        public static DataTable GetAllGameByTip(int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("VNM_Wap_GamesHaveTipGetAll", dbConn);
            dbCmd.Parameters.AddWithValue("@from", DateTime.Now);
            dbCmd.Parameters.AddWithValue("@to", DateTime.Now.AddDays(1));
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
        public static DataTable GetAllGameByCompetitionID_LTD(int catid, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("VNM_Wap_GetAll_ByCompetitionID_LTD", dbConn);
            dbCmd.Parameters.AddWithValue("@CatID", catid);
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
        public static DataTable GetAllGameByCompetitionID_KQ(int catid, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("VNM_Wap_GetAll_ByCompetitionID_KQ", dbConn);
            dbCmd.Parameters.AddWithValue("@CatID", catid);
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
        //public static DataTable GetAllGameByCompetitionID(int catid, int pagesize, int pageindex, out int totalrecord)
        //{
        //    DataTable retVal = null;
        //    SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //    SqlCommand dbCmd = new SqlCommand("VNM_Wap_GetAll_ByCompetitionID", dbConn);
        //    dbCmd.Parameters.AddWithValue("@CatID", catid);
        //    dbCmd.Parameters.AddWithValue("@PageNumber", pageindex);
        //    dbCmd.Parameters.AddWithValue("@PageSize", pagesize);
        //    dbCmd.Parameters.Add(new SqlParameter("@totalRows", SqlDbType.Int));
        //    dbCmd.Parameters["@totalRows"].Direction = ParameterDirection.Output;
        //    dbCmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        retVal = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(dbCmd);
        //        da.Fill(retVal);
        //        totalrecord = ConvertUtility.ToInt32(dbCmd.Parameters["@totalRows"].Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dbConn.Close();
        //    }
        //    return retVal;
        //}
        //Lay ten giai dau, danh sach cac tran cua giai dau do tai vong actived
        public static DataSet GetAll_CompetitionRelationInfo(int catid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "VNM_Wap_GetAll_CompetitionRelationInfo", catid);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
            return null;
        }
        //Lay ra cac dich vu 87
        public static DataTable GetAll_Sport87()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "VNM_Wap_GetAll_Sport87");
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay ra chi tiet dich vu 87
        public static DataTable GetAll_Sport87DetailByGame87ID(int game87id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "VNM_Wap_GetDetail_Sport87", game87id);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay Thong tin dich vu tu van dac biet
        public static DataSet GetAll_Sport87_DetailBy_PK_Game87ID(string game87id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "VNM_Wap_GetAll_Sport87_DetailByGame87ID", game87id);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
            return null;
        }
        //Lay Thong tin y kien chuyen gia cua tran dau
        public static DataTable GetDetail_YKCG_ByGameID(string gameid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "VNM_Wap_GetYKCG_DetailByGameID", gameid);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay Thong tin Tip cua tran dau
        public static DataTable GetDetail_Tip_ByGameID(string gameid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "VNM_Wap_GetTip_DetailByGameID", gameid);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay ra thong tin tran dau
        public static DataTable GetSport_GameDetailByID(string gameid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Sport_Game_GetInfo", gameid);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay ra thong tin tran dau theo Sport_id
        //public static DataTable GetSport_GameDetailBySportID(int sportid)
        //{
        //    DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Sport_Game_GetInfoBySportID", sportid);
        //    if (ds != null && ds.Tables.Count > 0)
        //        return ds.Tables[0];
        //    return null;
        //}

        //public static DataTable AllCompetitionLTDToDayHasCache(int portalID, int pagesize, int pageindex, out int totalrecord)
        //{
        //    DataCaching data = new DataCaching();
        //    string key = "BongDa.AllCompetitionLTDToDay";
        //    string param = "portalID=" + portalID + "&pagesize=" + pagesize.ToString() + "&pageindex=" + pageindex.ToString();
        //    string totalRcKey = "BongDa.AllCompetitionLTDToDay_TotalRecord_" + portalID.ToString();
        //    Object dataTotalRecord = data.GetHashCache(totalRcKey, portalID);
        //    if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
        //    else totalrecord = 0;
        //    DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
        //    if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
        //    else
        //    {
        //        DataTable dtPortals = AllCompetitionLTDToDay(portalID, pagesize, pageindex, out totalrecord);
        //        data.SetHashCache(key, param, GetExpire(), dtPortals);
        //        data.SetHashCache(totalRcKey, portalID, GetExpire(), totalrecord);
        //        return dtPortals;
        //    }
        //}
        public static DataTable AllCompetitionLTDToDayHasCache_Live(int portalID, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "BongDa.AllCompetitionLTDToDay_Live";
            string param = "portalID=" + portalID + "&pagesize=" + pagesize.ToString() + "&pageindex=" + pageindex.ToString();
            string totalRcKey = "BongDa.AllCompetitionLTDToDay_Live_TotalRecord_" + portalID.ToString();
            Object dataTotalRecord = data.GetHashCache(totalRcKey, portalID);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = AllCompetitionLTDToDay_Live(portalID, pagesize, pageindex, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, portalID, GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable AllCompetitionLTDToDay_Live(int PortalID, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("VNM_Wap_CompetitionToDay_LTD_Live", dbConn);
            dbCmd.Parameters.AddWithValue("@PortalID", PortalID);
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

        //public static DataTable AllCompetitionLTDToDay(int PortalID, int pagesize, int pageindex, out int totalrecord)
        //{            
        //    DataTable retVal = null;
        //    SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //    SqlCommand dbCmd = new SqlCommand("VNM_Wap_CompetitionToDay_LTD", dbConn);
        //    dbCmd.Parameters.AddWithValue("@PortalID", PortalID);
        //    dbCmd.Parameters.AddWithValue("@PageNumber", pageindex);
        //    dbCmd.Parameters.AddWithValue("@PageSize", pagesize);
        //    dbCmd.Parameters.Add(new SqlParameter("@totalRows", SqlDbType.Int));
        //    dbCmd.Parameters["@totalRows"].Direction = ParameterDirection.Output;
        //    dbCmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        retVal = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(dbCmd);
        //        da.Fill(retVal);
        //        totalrecord = ConvertUtility.ToInt32(dbCmd.Parameters["@totalRows"].Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dbConn.Close();
        //    }
        //    return retVal;
        //}

        public static DataTable AllCompetitionKQToDayHasCache(int portalID, int pagesize, int pageindex, out int totalrecord)
        {
            DataCaching data = new DataCaching();
            string key = "BongDa.AllCompetitionKQToDay";
            string param = "portalID=" + portalID + "&pagesize=" + pagesize.ToString() + "&pageindex=" + pageindex.ToString();
            string totalRcKey = "BongDa.AllCompetitionKQToDay_TotalRecord_" + portalID.ToString();
            Object dataTotalRecord = data.GetHashCache(totalRcKey, portalID);
            if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
            else totalrecord = 0;
            DataTable dtRetval = (DataTable)data.GetHashCache(key, param);
            if (dtRetval != null && dtRetval.Rows.Count > 0) return dtRetval;
            else
            {
                DataTable dtPortals = AllCompetitionKQToDay(portalID, pagesize, pageindex, out totalrecord);
                data.SetHashCache(key, param, GetExpire(), dtPortals);
                data.SetHashCache(totalRcKey, portalID, GetExpire(), totalrecord);
                return dtPortals;
            }
        }
        public static DataTable AllCompetitionKQToDay(int PortalID, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("VNM_Wap_CompetitionToday_KQ", dbConn);
            dbCmd.Parameters.AddWithValue("@PortalID", PortalID);
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


        public static DataTable GetAllGameToDayByCompetitionID_KQ(int catid, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("VNM_Wap_Today_ByCompetitionID_KQ", dbConn);
            dbCmd.Parameters.AddWithValue("@CatID", catid);
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

        public static DataTable GetAllGameToDayByCompetitionID_KQ_Live(int catid, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("VNM_Wap_Today_ByCompetitionID_KQ_Live", dbConn);
            dbCmd.Parameters.AddWithValue("@CatID", catid);
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

        public static DataTable GetAllGameToDayByCompetitionID_LTD_Live(int catid, int pagesize, int pageindex, out int totalrecord)
        {
            DataTable retVal = null;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("VNM_Wap_Today_ByCompetitionID_LTD_Live", dbConn);
            dbCmd.Parameters.AddWithValue("@CatID", catid);
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

        //Thống kê đặc biệt theo giải đấu
        //public static DataTable GetAllGameToDayByCompetitionID_LTD(int catid, int pagesize, int pageindex, out int totalrecord)
        //{
        //    DataTable retVal = null;
        //    SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString);
        //    SqlCommand dbCmd = new SqlCommand("VNM_Wap_Today_ByCompetitionID_LTD", dbConn);
        //    dbCmd.Parameters.AddWithValue("@CatID", catid);
        //    dbCmd.Parameters.AddWithValue("@PageNumber", pageindex);
        //    dbCmd.Parameters.AddWithValue("@PageSize", pagesize);
        //    dbCmd.Parameters.Add(new SqlParameter("@totalRows", SqlDbType.Int));
        //    dbCmd.Parameters["@totalRows"].Direction = ParameterDirection.Output;
        //    dbCmd.CommandType = CommandType.StoredProcedure;
        //    try
        //    {
        //        retVal = new DataTable();
        //        SqlDataAdapter da = new SqlDataAdapter(dbCmd);
        //        da.Fill(retVal);
        //        totalrecord = ConvertUtility.ToInt32(dbCmd.Parameters["@totalRows"].Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        dbConn.Close();
        //    }
        //    return retVal;
        //}

        //Thống kê đặc biệt theo giải đấu
        public static DataTable ThongKeDacBiet(string CompetitionID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "W4A_Competition_ThongKeByID", CompetitionID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        //Lấy video clip
        public static int Clip4Bongda(string gameID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "W4A_Video_VTT_GetByGameID", gameID);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
                return (int)ds.Tables[0].Rows[0]["wapVideoID"];
            return 0;
        }


        #region LAY TIN BEN WAP_THATHAOSO

        public static DataTable GetHomeNews()
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Wap_TheThaoSo_GetHomeNews_ForVnm");
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }

        public static DataTable GetHomeNewsHasCache()
        {
            DataCaching dataCaching = new DataCaching();
            string param = Key + "GetHomeNews_TheThao";
            var ds = (DataTable)dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = GetHomeNews();
            dataCaching.SetHashCache(Key, param, ConvertUtility.ToInt32(AppEnv.GetSetting("news_expired")), ds);
            return ds;
        }

        public static DataTable GetLastestNewsFromTheThaoSo(int pageindex,int pagesize, out int totalrecord)
        {
            DataTable retVal;
            SqlConnection dbConn = new SqlConnection(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString);
            SqlCommand dbCmd = new SqlCommand("Wap_TheThaoSo_GetLastestNews_ForVnm", dbConn);
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

        public static DataTable GetLastestNewsFromTheThaoSoHasCache(int pageindex, int pagesize, out int totalrecord)
        {
            DataCaching dataCaching = new DataCaching();
            string param = Key + "GetLastestNewsFromTheThaoSoHasCache?pageIndex=" + pageindex;
            string totalRcKey = "GetLastestNewsFromTheThaoSoHasCache_TotalRecord_" + pageindex;

            var ds = (DataTable)dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                Object dataTotalRecord = dataCaching.GetHashCache(totalRcKey, pageindex);
                if (dataTotalRecord != null) totalrecord = (int)dataTotalRecord;
                else totalrecord = 0;
                return ds;
            }
            ds = GetLastestNewsFromTheThaoSo(pageindex,pagesize,out totalrecord);

            dataCaching.SetHashCache(Key, param, ConvertUtility.ToInt32(AppEnv.GetSetting("news_expired")), ds);
            dataCaching.SetHashCache(totalRcKey, pageindex, ConvertUtility.ToInt32(AppEnv.GetSetting("news_expired")), totalrecord);

            return ds;
        }

        public static DataSet GetNewsDetail(int id)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString_TheThaoSo"].ConnectionString, "Wap_TheThaoSo_GetNewsDetail_ForVnm", id);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds;
            }
            return null;
        }

        public static DataSet GetNewsDetailHasCache(int id)
        {
            DataCaching dataCaching = new DataCaching();
            string param = Key + "GetNewsDetailHasCache?id=" + id;
            var ds = (DataSet)dataCaching.GetHashCache(Key, param);
            if (ds != null)
            {
                return ds;
            }
            ds = GetNewsDetail(id);
            dataCaching.SetHashCache(Key, param, ConvertUtility.ToInt32(AppEnv.GetSetting("news_expired")), ds);
            return ds;
        }

        #endregion

    }
}
