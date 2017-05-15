<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="showpopup.aspx.cs" Inherits="WapXzone_VNM.showpopup" %>
<%@ Import Namespace="WapXzone_VNM.Library" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
  
    <title id="Title" enableviewstate="false" runat="server">WAP.VIETNAMOBILE.COM.VN</title>
    <meta name="Keywords" content="" id="KEYWORDS" runat="server" enableviewstate="false" />
    <meta name="Description" content="" runat="server" id="description" enableviewstate="false" />
    <meta charset="UTF-8" />
    <meta name="viewport" content="width=device-width; initial-scale=1.0; maximum-scale=1.0; user-scalable=0;" />  
    <script type="text/javascript" src="/Script/jquery.min.js"></script>

  <script runat="server" > 
      
      
      protected void Page_Load(object sender, EventArgs e)
      {
          if (!AppEnv.isMobileBrowser())
          {
              Response.Redirect("/Wap/Default.aspx?lang=1&w=320");
          }
      }
          
      
  </script>

  <script language="javascript" type="text/javascript">

      function disp_confirm() {
          var r = confirm("Bạn có cơ hội trúng thưởng 3 SAMSUNG GALAXY S4 liên tục trong 3 tháng với dịch vụ clip hot ngày của Vietnamobile. Hãy đăng ký ngay để nhận mã dự thưởng của chương trình (miễn phí sử dụng 7 ngày đầu tiên)")
          if (r == true) {
              window.location = '/Video/DangKy.aspx?lang=1&w=320';
          }
          else {
              window.location = '/Wap/Default.aspx?lang=1&w=320';
          }
      }

      $(window).load(function () {
          disp_confirm();
      });      
		
</script>

</head>
<body>
    <form id="form1" runat="server">
    <div></div>
    </form>
</body>
</html>
