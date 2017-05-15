using System;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thethao.UserControlHigh
{
    public partial class ThongKeDacBiet : System.Web.UI.UserControl
    {
        private string tab;
        private static int catid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack)
            {
                catid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
                tab = ConvertUtility.ToString(Request.QueryString["tab"]);

                DataTable dt = ThethaoController.GetAllCategoryExeptCatID((int)Constant.DefaultPortal.Mobifone, catid);
                if(dt != null && dt.Rows.Count > 0)
                {
                    rptList.DataSource = dt;
                    rptList.ItemDataBound += rptCategory_ItemDataBound;
                    rptList.DataBind();
                }

            }
        }

        protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkCatName = (HyperLink)e.Item.FindControl("lnkCatName");
            //if (lang == 1)
            //{
                lnkCatName.Text = curData["NameUnicode"].ToString();
            //}
            //else
            //{
            //    lnkCatName.Text = curData["Name"].ToString();
            //}
            switch (tab.ToLower())
            {
                case "bxh":
                    //lnkCatName.NavigateUrl = UrlProcess.GetCompetitionBXHUrl("1", "320", curData["W_CompetitionID"].ToString());
                    lnkCatName.NavigateUrl = UrlProcess.TheThaoBangXepHangChiTiet(curData["W_CompetitionID"].ToString(), curData["Name"].ToString());
                    break;
                case "ltd":
                    //lnkCatName.NavigateUrl = UrlProcess.GetCompetitionLTDUrl(1.ToString(), "320", curData["W_CompetitionID"].ToString());
                    lnkCatName.NavigateUrl = UrlProcess.TheThaoLichThiDauChiTiet(curData["W_CompetitionID"].ToString(),
                                                                                 curData["Name"].ToString(),
                                                                                 1.ToString());
                    break;
                case "kqtd":
                    //lnkCatName.NavigateUrl = UrlProcess.GetCompetitionKQTDUrl(1.ToString(), "320", curData["W_CompetitionID"].ToString());
                    lnkCatName.NavigateUrl = UrlProcess.TheThaoKetQuaThiDauChiTiet(curData["W_CompetitionID"].ToString(), "ket-qua-thi-dau", "1");
                    break;
                case "tkdb":
                    DataTable dtTKDB = ThethaoController.ThongKeDacBiet(ConvertUtility.ToString(curData["W_CompetitionID"]));

                    lnkCatName.NavigateUrl = "";
                    if (dtTKDB.Rows.Count > 0)
                        if (dtTKDB.Rows[0]["WapContent"].ToString().Trim().Length > 0)
                            //lnkCatName.NavigateUrl = UrlProcess.GetCompetitionTKDBUrl(1.ToString(), "320", curData["W_CompetitionID"].ToString());
                            lnkCatName.NavigateUrl =
                                UrlProcess.TheThaoThongKeDacBietChiTiet(curData["W_CompetitionID"].ToString(), curData["Name"].ToString());
                    break;
            }

        }

    }
}