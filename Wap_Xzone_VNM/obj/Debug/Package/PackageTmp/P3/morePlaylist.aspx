<%@ Page Language="C#" AutoEventWireup="true" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="WapXzone_VNM.P3.UserControl" %>
<script runat="server">
    void Page_Load(object sender, EventArgs e)
    {
        int limit = Convert.ToInt32(Request.QueryString["start"]);

        System.Collections.Generic.List<Data> lstData = null;


        string type = Convert.ToString(Request.QueryString["type"]);
        if (type == "new")
        {
            lstData = Controller.GetDataNew(limit, 5);
        }
        else if (type == "top")
        {
            lstData = Controller.GetDataTop(limit, 5);
        }
        else if (type == "hot")
        {
            lstData = Controller.GetDataHot(limit, 5);
        }
        else 
        {
            lstData = Controller.GetDataRandom(limit, 5);
        }
        string temp = "";

        foreach (Data item in lstData)
        {
            temp += "<div class=\"a-item\">";
            temp += "<div class=\"icon\">";
            temp += "<a href=\"" + GetLinkDetail(item.id) + "\">";
            temp += "<img width=\"115\" height=\"70\" border=\"0\" align=\"middle\" src=\"" + item.image + "\">";
            temp += "</a>";
            temp += "</div> ";
            temp += "<div class=\"title\" style=\"margin-left:135px\">";
            temp += "<a href=\"" + GetLinkDetail(item.id) + "\">" + item.name + "</a>";
            temp += "<br><span>" + item.views + " lượt xem";
            temp += "</span>";
            temp += "<br />";
            temp += "<span>Time " + item.time;
            temp += "</span>";
            temp += "<br />";
            temp += "<span>";
            temp += "<img alt=\"\" src=\"images/icon_streaming.gif\">";
            temp += "<a href=\"#\">Xem <span style=\"font-size: 11px; color: #FF0000; font-style: italic;\">(3000đ)</span></a> </span>";
            temp += "</div>";
            temp += "</div>";
        }

        Response.Write(temp);
    }

    protected string GetLinkDetail(object id)
    {
        return "/P3/default.aspx?display=detail&id=" + id;
    }
</script>
