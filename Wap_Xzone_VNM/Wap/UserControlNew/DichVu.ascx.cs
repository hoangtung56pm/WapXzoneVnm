using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VmgPortal.Modules.Adsvertising;
using WapXzone_VNM.Library;
using WapXzone_VNM.Library.Component.Wap;
using WapXzone_VNM.Library.Constant;

namespace WapXzone_VNM.Wap.UserControlNew
{
    public partial class DichVu : System.Web.UI.UserControl
    {
        private string lang;
        private string width;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lang = Request.QueryString["lang"];
                width = Request.QueryString["w"];
                if (width == "0")
                {
                    width = Constant.DefaultScreen.Standard.ToString();
                }

                var advertisement = new Advertisement { Channel = "Home", Position = "HomeCenter", Param = 0, Lang = lang, Width = width.ToString() };
                litAds.Text = advertisement.GetAds();

                DataTable cpConfig = WapController.CPConfig_GetByWap_IDHasCache(38);

                int count = cpConfig.Rows.Count/3;
                int countDiv = (cpConfig.Rows.Count%3);

                if (countDiv > 0)
                    count = count + 1;

                int rowFirst = 3;
                int rowEnd = 6;

                string litService = string.Empty;

                string urlData = AppEnv.GetSetting("urldata");

                for (int i = 0; i < count;i++ )
                {
                    DataRow[] list;
                    if(i == 0)
                    {
                        list = cpConfig.Select("RowNumber <=" + rowFirst);
                        if(list.Length > 0)
                        {
                            litService = "<tr>";
                            litService += "<td width=\"15\"><img src=\"/imagesnew/blank.gif\" width=\"15\" height=\"10\" /></td>";

                            for (int k = 0; k < list.Length; k++)
                            {
                                if (k != list.Length - 1)
                                {
                                    if (list[k]["CP_Url"].ToString().Contains("Default"))
                                    {
                                        litService += "<td align=\"center\" valign=\"top\"><a href=\" " + list[k]["CP_Url"].ToString().Replace("Default", "DefaultNew") + "&w=" + width + "&lang=" + lang + " \"><img src=\"" + urlData + list[k]["CP_Category_Avatar"].ToString().Replace("~", "") + "\"  /></a></td>";
                                    }
                                    else
                                    {
                                        litService += "<td align=\"center\" valign=\"top\"><a href=\" " + list[k]["CP_Url"] + " \"><img src=\"" + urlData + list[k]["CP_Category_Avatar"].ToString().Replace("~", "") + "\"  /></a></td>";
                                    }
                                    
                                    litService += "<td align=\"center\" valign=\"top\">&nbsp;</td>";
                                }
                                else
                                {
                                    litService += "<td align=\"center\" valign=\"top\"><a href=\" " + list[k]["CP_Url"].ToString().Replace("Default", "DefaultNew") + "&w=" + width + "&lang=" + lang + " \"><img src=\"" + urlData + list[k]["CP_Category_Avatar"].ToString().Replace("~", "") + "\"  /></a></td>";
                                }

                            }

                            litService += "<td width=\"15\"><img src=\"/imagesnew/blank.gif\" width=\"15\" height=\"10\" /></td>";
                            litService += "</tr>";

                            litService += "<tr>";
                            litService += "<td>&nbsp;</td>";

                            for (int k = 0; k < list.Length; k++)
                            {
                                string name;
                                if (lang == "1")
                                {
                                    name = list[k]["CP_CategoryUnicode"].ToString().Replace("Linh Triều Bình Ca","Linh Triều");
                                }
                                else
                                {
                                    name = list[k]["CP_Category"].ToString().Replace("Linh Trieu Binh Ca","Linh Trieu");
                                }
                                if (k != list.Length - 1)
                                {
                                    if (list[k]["CP_Url"].ToString().Contains("Default"))
                                    {
                                        litService += "<td align=\"center\" valign=\"middle\"><span class=\"style2\"><a class=\"link-non-black\" href=\" " + list[k]["CP_Url"].ToString().Replace("Default", "DefaultNew") + "&w=" + width + "&lang=" + lang + " \">" + name + " </a></span></td>";
                                    }
                                    else
                                    {
                                        litService += "<td align=\"center\" valign=\"middle\"><span class=\"style2\"><a class=\"link-non-black\" href=\" " + list[k]["CP_Url"] + " \">" + name + " </a></span></td>";
                                    }
                                    
                                    litService += "<td align=\"center\" valign=\"middle\">&nbsp;</td>";
                                }
                                else
                                {
                                    litService += "<td align=\"center\" valign=\"middle\"><span class=\"style2\"><a class=\"link-non-black\" href=\" " + list[k]["CP_Url"].ToString().Replace("Default", "DefaultNew") + "&w=" + width + "&lang=" + lang + " \">" + name + " </a></span></td>";
                                }
                            }

                            litService += "<td>&nbsp;</td>";
                            litService += "</tr>";

                            litService += "<tr><td colspan=\"7\"><img src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr>";
                        }
                    }
                    else if(i == 1)
                    {
                        rowFirst = rowFirst + 1;
                        list = cpConfig.Select("RowNumber >= "+ rowFirst +" AND RowNumber <=" + rowEnd);

                        if(list.Length > 0)
                        {
                            litService += "<tr>";
                            litService += "<td>&nbsp;</td>";

                            for (int k = 0; k < list.Length; k++)
                            {
                                if (list[k]["CP_Url"].ToString().Contains("Default"))
                                {
                                    litService += "<td align=\"center\"><a href=\"" + list[k]["CP_Url"].ToString().Replace("Default", "DefaultNew") + "&w=" + width + "&lang=" + lang + "\"><img src=\"" + urlData + list[k]["CP_Category_Avatar"].ToString().Replace("~", "") + "\"  /></a></td>";
                                }
                                else
                                {
                                    litService += "<td align=\"center\"><a href=\"" + list[k]["CP_Url"] + "\"><img src=\"" + urlData + list[k]["CP_Category_Avatar"].ToString().Replace("~", "") + "\"  /></a></td>";
                                }
                                
                                litService += "<td>&nbsp;</td>";
                            }

                            litService += "</tr>";
                            litService += "<tr>";
                            litService += "<td>&nbsp;</td>";

                            for (int k = 0; k < list.Length; k++)
                            {
                                string name;
                                if (lang == "1")
                                {
                                    name = list[k]["CP_CategoryUnicode"].ToString().Replace("Bóng đá đặc biệt", "Bóng đá");
                                }
                                else
                                {
                                    name = list[k]["CP_Category"].ToString().Replace("Bong da dac biet", "Bong da");
                                }

                                if (list[k]["CP_Url"].ToString().Contains("Default"))
                                {
                                    litService += "<td align=\"center\" valign=\"middle\"><span class=\"style2\"><a class=\"link-non-black\" href=\"" + list[k]["CP_Url"].ToString().Replace("Default", "DefaultNew") + "&w=" + width + "&lang=" + lang + "\">" + name + "</a></span></td>";
                                }
                                else
                                {
                                    litService += "<td align=\"center\" valign=\"middle\"><span class=\"style2\"><a class=\"link-non-black\" href=\"" + list[k]["CP_Url"] + "\">" + name + "</a></span></td>";
                                }

                                
                                litService += "<td>&nbsp;</td>";
                            }

                            litService += "</tr>";
                            litService += "<tr><td colspan=\"7\"><img src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr>";
   
                        }
                    }
                    else
                    {
                        rowFirst = rowFirst + 3;
                        rowEnd = rowEnd + 3;
                        list = cpConfig.Select("RowNumber >= " + rowFirst + " AND RowNumber <=" + rowEnd);

                        if(list.Length > 0)
                        {
                            litService += "<tr>";
                            litService += "<td>&nbsp;</td>";

                            for (int k = 0; k < list.Length; k++)
                            {
                                if (list[k]["CP_Url"].ToString().Contains("Default"))
                                {
                                    litService += "<td align=\"center\"><a href=\"" + list[k]["CP_Url"].ToString().Replace("Default", "DefaultNew") + "&w=" + width + "&lang=" + lang + "\"><img src=\"" + urlData + list[k]["CP_Category_Avatar"].ToString().Replace("~", "") + "\" /></a></td>";
                                }
                                else
                                {
                                    litService += "<td align=\"center\"><a href=\"" + list[k]["CP_Url"] + "\"><img src=\"" + urlData + list[k]["CP_Category_Avatar"].ToString().Replace("~", "") + "\" /></a></td>";
                                }
                                
                                litService += "<td>&nbsp;</td>";
                            }

                            litService += "</tr>";
                            litService += "<tr>";
                            litService += "<td>&nbsp;</td>";

                            for (int k = 0; k < list.Length; k++)
                            {
                                string name;
                                if (lang == "1")
                                {
                                    name = list[k]["CP_CategoryUnicode"].ToString();
                                }
                                else
                                {
                                    name = list[k]["CP_Category"].ToString();
                                }

                                if (list[k]["CP_Url"].ToString().Contains("Default"))
                                {
                                    litService += "<td align=\"center\" valign=\"middle\"><span class=\"style2\"><a class=\"link-non-black\" href=\"" + list[k]["CP_Url"].ToString().Replace("Default", "DefaultNew") + "&w=" + width + "&lang=" + lang + "\">" + name + "</a></span></td>";
                                }
                                else
                                {
                                    litService += "<td align=\"center\" valign=\"middle\"><span class=\"style2\"><a class=\"link-non-black\" href=\"" + list[k]["CP_Url"] + "\">" + name + "</a></span></td>";
                                }

                                
                                litService += "<td>&nbsp;</td>";
                            }

                            litService += "</tr>";
                            litService += "<tr><td colspan=\"7\" align=\"left\" valign=\"top\"><img alt=\"\" src=\"/imagesnew/blank.gif\" width=\"5\" height=\"9\" /></td></tr>";
                        }
                    }
                }

                litDichVu.Text = litService;

            }
            if (lang == "1")
            {
                ltrDichVu.Text = "Dịch vụ Vietnamobile";
            }
        }
    }
}