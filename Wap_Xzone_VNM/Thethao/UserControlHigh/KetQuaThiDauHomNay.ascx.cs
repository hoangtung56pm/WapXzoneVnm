using System;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.Constant;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thethao.UserControlHigh
{
    public partial class KetQuaThiDauHomNay : System.Web.UI.UserControl
    {

      
        private int pagesize = 2;
        //private int pagenumber = 3;
        private int curpage = 1;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int totalrecord = 0;
                DataTable dt = ThethaoController.AllCompetitionKQToDayHasCache((int)Constant.DefaultPortal.Mobifone, pagesize, curpage, out totalrecord);
                if(dt != null && dt.Rows.Count > 0)
                {
                    rptCategory.DataSource = dt;
                    rptCategory.ItemDataBound += rptCategory_ItemDataBound;
                    rptCategory.DataBind();
                }
            }
        }

        protected void rptCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal ltrGiaiDau = (Literal)e.Item.FindControl("ltrGiaiDau");
            Repeater rptLichThiDau = (Repeater)e.Item.FindControl("rptLichThiDau");
            int totalrecord;
            DataTable dtItem = ThethaoController.GetAllGameToDayByCompetitionID_KQ_Live(ConvertUtility.ToInt32(curData["W_CompetitionID"]), 20, 1, out totalrecord);

            ltrGiaiDau.Text = curData["NameUnicode"].ToString();
            
            if (dtItem.Rows.Count > 0)
            {
                rptLichThiDau.DataSource = dtItem;
                rptLichThiDau.ItemDataBound += rptlist_ItemDataBound;
                rptLichThiDau.DataBind();
            }
        }

        protected void rptlist_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Label ltrGame = (Label)e.Item.FindControl("ltrGame");
            Literal ltrTime = (Literal)e.Item.FindControl("ltrTime");
            if (curData["Status"].ToString() == "1")
            {
                ltrGame.Text = curData["Team_Name1"] + " ? - ? " + curData["Team_Name2"];
                ltrTime.Text = ConvertUtility.ToDateTime(curData["StartTime"]).ToString("dd/MM/yyyy HH:mm");
            }
            else
            {
                ltrGame.Text = curData["Team_Name1"] + " " + curData["Team1Score"] + " - " + curData["Team2Score"] + " " + curData["Team_Name2"];
                ltrTime.Text = ConvertUtility.ToDateTime(curData["StartTime"]).ToString("dd/MM/yyyy HH:mm");
            }
        }
    }
}