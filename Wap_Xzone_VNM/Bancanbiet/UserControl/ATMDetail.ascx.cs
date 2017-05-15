using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WapXzone_VNM.Library.Utilities;
using WapXzone_VNM.Library.Component.Bancanbiet;
using System.Data;
using WapXzone_VNM.Library.UrlProcess;

namespace WapXzone_VNM.Bancanbiet.UserControl
{
    public partial class ATMDetail1 : System.Web.UI.UserControl
    {
        private int lang;
        private string width;
        private int bankid;
        private int zoneid;        
        protected void Page_Load(object sender, EventArgs e)
        {
            lang = ConvertUtility.ToInt32(Request.QueryString["lang"]);
            width = Request.QueryString["w"];
            bankid = ConvertUtility.ToInt32(Request.QueryString["catid"]);
            zoneid = ConvertUtility.ToInt32(Request.QueryString["id"]);            
            DataTable dtdetail = BCBController.GetAllDetailByBankIDAndZoneID(bankid,zoneid);
            
            if (dtdetail.Rows.Count > 0)
            {                
                if (lang == 1)
                {
                    lnkAtm.Text = "<span class=\"trang\">" + dtdetail.Rows[0]["BankName"].ToString().ToUpper() + "</span>";
                    lnkTitle.Text = "<span class=\"trang\">" + dtdetail.Rows[0]["ZoneName"].ToString().ToUpper() + "</span>";
                    lblBankRelation.Text = "CÁC NGÂN HÀNG LIÊN MINH";
                }
                else
                {
                    lnkAtm.Text = "<span class=\"trang\">" + dtdetail.Rows[0]["BankNameKD"].ToString().ToUpper() + "</span>";
                    lnkTitle.Text = "<span class=\"trang\">" + dtdetail.Rows[0]["ZoneNameKD"].ToString().ToUpper() + "</span>";                    
                }
                lnkAtm.NavigateUrl = UrlProcess.GetBankUrl(lang.ToString(), "listatm", width, bankid.ToString());
            }
            
            //get relation bank
            rptbankRelation.DataSource = BCBController.GetAllBankNameRelation(ConvertUtility.ToInt32(BCBController.GetBankNameByID(bankid).Rows[0]["link_id"]));
            rptbankRelation.ItemDataBound += new RepeaterItemEventHandler(rptbankRelation_ItemDataBound); ;
            rptbankRelation.DataBind();
            //Get Detail of ATM
            if (dtdetail.Rows.Count > 0)
            {                
                rptATMdetail.DataSource = dtdetail;
                rptATMdetail.ItemDataBound += new RepeaterItemEventHandler(rptATMdetail_ItemDataBound); ;
                rptATMdetail.DataBind();
            }
            else {
                lblThongbao.Visible = true;                
                if (lang == 1)
                {
                    lblBankRelation.Text = "CÁC NGÂN HÀNG LIÊN MINH";
                    lblThongbao.Text = "Không có máy ATM nào tại khu vực bạn tìm kiếm.<br />Bạn có thể tham khảo máy ATM của các ngân hàng liên minh";
                }
            }   
        }
        protected void rptbankRelation_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            HyperLink lnkBankRelation = (HyperLink)e.Item.FindControl("lnkBankRelation");
            if (lang == 1)
            {
                lnkBankRelation.Text = curData["name"].ToString();
            }
            else
            {
                lnkBankRelation.Text = curData["name_kd"].ToString();// UnicodeUtility.UnicodeToKoDau(curData["name"].ToString());
            }
            lnkBankRelation.NavigateUrl = UrlProcess.GetBankUrl(lang.ToString(), "listatm", width, curData["bank_id"].ToString());
        }

        protected void rptATMdetail_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemIndex < 0) return;
            DataRowView curData = (DataRowView)e.Item.DataItem;
            Literal ltrDetail = (Literal)e.Item.FindControl("ltrDetail");
            if (lang == 1)
            {
                ltrDetail.Text = curData["address"].ToString();
            }
            else
            {
                ltrDetail.Text = UnicodeUtility.UnicodeToKoDau(curData["address_kd"].ToString());
            }
        }
    }
}