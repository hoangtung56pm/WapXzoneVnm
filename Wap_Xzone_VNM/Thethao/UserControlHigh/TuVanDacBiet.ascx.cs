using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Component.Thethao;
using WapXzone_VNM.Library.UrlProcess;
using WapXzone_VNM.Library.Utilities;

namespace WapXzone_VNM.Thethao.UserControlHigh
{
    public partial class TuVanDacBiet : System.Web.UI.UserControl
    {

        private int lang;
        private string width;
        private string price;
        private string cpid = string.Empty;
        private string vmstransactionid = string.Empty;
        private string msisdn = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            width = Request.QueryString["w"];
            price = ConfigurationSettings.AppSettings.Get("goldprice");

            if (!IsPostBack)
            {
                lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
                //if (lang == 0)
                //{
                //    ltrtvdb.Text = "TU VAN DAC BIET";
                //    lnkTheThao.Text = "BONG DA";
                //    ltrGia.Text = "(" + Resources.Resource.wThongBaoGia_KD + ConfigurationSettings.AppSettings.Get("sangprice") + Resources.Resource.wDonViTien_KD + ")";
                //}
                //else
//                    ltrGia.Text = "(" + Resources.Resource.wThongBaoGia + ConfigurationSettings.AppSettings.Get("sangprice") + Resources.Resource.wDonViTien + ")";
                lnkTheThao.NavigateUrl = UrlProcess.TheThaoHome();
                DataTable dt = ThethaoController.GetAll_Sport87();
                rptdv87.DataSource = dt;
                rptdv87.ItemDataBound += rptdv87_ItemDataBound;
                rptdv87.DataBind();
            }
        }
        protected void rptdv87_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkdv87 = (HyperLink)e.Item.FindControl("lnkdv87");
            Literal ltrDangCapNhat = (Literal)e.Item.FindControl("ltrDangCapNhat");

            DataSet dtcheck = ThethaoController.GetAll_Sport87_DetailBy_PK_Game87ID(curData["PK_Game87_ID"].ToString());
            if (ConvertUtility.ToBoolean(dtcheck.Tables[0].Rows[0]["IsFull"]))
            {
                //if (lang == 1)
                //{
                    lnkdv87.Text = "<span class=\"blue\">" + curData["Name"].ToString() + "</span>";
                //}
                //else
                //{
                //    lnkdv87.Text = "<span class=\"blue\">" + UnicodeUtility.UnicodeToKoDau(curData["Name"].ToString()) + "</span>";
                //}
                
                //lnkdv87.NavigateUrl = "../TuVanDacBiet.aspx?id=" + curData["Game87_Id"].ToString() + "&lang=" + lang + "&w=" + width;
                lnkdv87.NavigateUrl = UrlProcess.TheThaoTranCauVang(curData["Game87_Id"].ToString());
            }
            else
            {

                //if (lang == 1)
                //{
                    lnkdv87.Text = curData["Name"].ToString();
                    ltrDangCapNhat.Text = "(đang cập nhật)";
                //}
                //else
                //{
                //    ltrDangCapNhat.Text = "(dang cap nhat)";
                //    lnkdv87.Text = UnicodeUtility.UnicodeToKoDau(curData["Name"].ToString());
                //}
                lnkdv87.NavigateUrl = null;
            }

        }

    }
}