using System;
using System.Data;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Video;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Video.UserControlHigh
{
    public partial class Detail : System.Web.UI.UserControl
    {
        private int pagesize = 3;
        private int pagenumber = 3;
        private int tpage = 1;
        private int lang;
        private string width;
        private static string preurl;
        protected int id;
        private string price;

        protected string CatId;
        protected string CatName;

        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                id = ConvertUtility.ToInt32(Request.QueryString["id"]);   
                //Detail
                DataTable dtDetail = VideoController.GetVideoDetailByIDHasCache(AppEnv.CheckSessionTelco(), id);
                //end detail
                if (dtDetail.Rows.Count > 0)
                {
                    rptDetail.DataSource = dtDetail;
                    rptDetail.DataBind();

                    CatId = dtDetail.Rows[0]["W_VCategoryID"].ToString();
                    CatName = dtDetail.Rows[0]["Title"].ToString();
                    int totalrecord = 0;

                    DataTable dtList = VideoController.GetAllVideoByCategoryAndDisplayTypeHasCache(AppEnv.CheckSessionTelco(), ConvertUtility.ToInt32(CatId), -1, (int)Constant.Video.Category, 5, 1, out totalrecord);
                    if(dtList.Rows.Count == 0)
                    {
                        dtList = VideoController.GetAllVideoByCategoryAndDisplayType(AppEnv.CheckSessionTelco(), ConvertUtility.ToInt32(CatId), id, 0, 5, 1, out totalrecord);
                    }

                    foreach (DataRow iRow in dtList.Rows)
                    {
                        if ((int)iRow["W_VItemID"] == id)
                        {
                            iRow.Delete();
                            dtList.AcceptChanges();
                            break;
                        }
                    }
                    rptList.DataSource = dtList;
                    rptList.DataBind();
                }
            }
        }
    }
}