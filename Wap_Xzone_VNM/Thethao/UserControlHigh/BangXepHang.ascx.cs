using System;
using System.Data;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thethao.UserControlHigh
{
    public partial class BangXepHang : System.Web.UI.UserControl
    {
        private static int catid;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
                DataSet ds = ThethaoController.GetAll_CompetitionRelationInfo(catid);
                if(ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    ltrGiaiDau.Text = ds.Tables[0].Rows[0]["NameUnicode"].ToString();
                    if (ds.Tables.Count > 3 && ds.Tables[3].Rows.Count > 0)
                    {
                        if (ConvertUtility.ToString(ds.Tables[3].Rows[0]["Name"].ToString()) != "")
                        {
                            ltrRoundName.Text = " - " + ds.Tables[3].Rows[0]["Name"];
                        }
                    }

                    if (ds.Tables.Count >= 4)
                    {
                        DataTable dtbxh = ds.Tables[2];
                        rptbxh.DataSource = dtbxh;
                        rptbxh.DataBind();
                    }
                }
            }
        }
    }
}