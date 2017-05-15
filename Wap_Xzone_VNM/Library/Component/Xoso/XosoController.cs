using System;
using System.Collections.Generic;

using System.Web;
using System.Data;
using WapXzone_VNM.Library.SQLHelper;
using System.Web.Configuration;

namespace WapXzone_VNM.Library.Component.Xoso
{
    public class XosoController
    {
        public XosoController() { 
        }
        //Lay tat ca cac tinh
        public static DataTable GetAllCityByRegion(int typeid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "VNM_Wap_CityOfLot_GetAllByTypeID",typeid);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay ra 1 kqxs moi nhat theo tinh
        public static DataTable GetKQXSLastestDetailbyCompanyID(int companyid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "VNM_Wap_Lot_GetLastestDetailByCompanyID", companyid);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay ra kqxs moi nhat theo tinh
        public static DataTable GetKQXSDetailbyCompanyID(int companyid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "VNM_Wap_Lot_GetAllDetailByCompanyID", companyid);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay ra kqxs theo ngay ung voi tung tinh
        public static DataTable GetKQXSDetailbyCompanyID(int companyid,DateTime date)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "VNM_Wap_Lot_GetAllDetailByCompanyIDAndDate", companyid,Convert.ToDateTime(date.ToShortDateString()));
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Lay ra kqxs moi nhat theo tinh
        public static DataSet GetDetail_LotAndOtherLot(int id,int companyid,int top)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "VNM_Wap_Lot_DetailAndOtherLot", id, companyid,top);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
            return null;
        }
        //Lay ra kqxs theo id
        //Lay ra kqxs moi nhat theo tinh va top kqxs cac ngay khac
        public static DataSet GetDetail_LotAndOtherLotByIdAndTop(int id, int top)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "VNM_Wap_Lot_DetailAndOtherLotByIDAndTop", id, top);
            if (ds != null && ds.Tables.Count > 0)
                return ds;
            return null;
        }
        //Lay ra thong tin cua tinh mo thuong
        public static DataTable GetInfobyCompanyID(int companyid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "VNM_Wap_GetInfoByCompanyID", companyid);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
        //Soi cau
        public static DataTable GetSoicauInfoBycompanyID(int companyid)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "VNM_Wap_GetSoicauByCompanyID", companyid);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
    }
}
