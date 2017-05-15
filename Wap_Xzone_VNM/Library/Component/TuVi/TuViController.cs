using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Data;
using System.Web.Configuration;
using WapXzone_VNM.Library.SQLHelper;
using System.Data.SqlClient;
using WapXzone_VNM.Library.Utilities;

using WapXzone_VNM.Library.Cache;

namespace WapXzone_VNM.Library.Component.TuVi
{
    public class TuViController
    {
        public static DataTable Horoscope_Get4Wap(int CategoryID, string Birthday)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Horoscope_Get4Wap", CategoryID, Birthday);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }

        public static DataTable Horoscope_GetItemByID(int ID)
        {
            DataSet ds = SqlHelper.ExecuteDataset(WebConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString, "Horoscope_GetItemByID", ID);
            if (ds != null && ds.Tables.Count > 0)
                return ds.Tables[0];
            return null;
        }
    }
}
