<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="WapXzone_VNM.Wap.Main" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>.: Vietnamobile - Trang chu :.</title>
    <link rel="stylesheet" href="/Content/asset/Plugin/bootstrap-3.0.3/dist/css/bootstrap.min.css" />
    <link rel="stylesheet" href="/Content/asset/Plugin/mmenu/css/jquery.mmenu.all.css" />
    <link rel="stylesheet" href="/Content/asset/Css/style.css" />
    <script type="text/javascript" src="/assets/jquery/jquery-2.1.4.min.js"></script>
    <script type="text/javascript" src="/Content/asset/Plugin/mmenu/js/jquery.mmenu.min.all.js"></script>
    <script type="text/javascript" src="/Content/asset/Javascript/app.js"></script>
    <script type="text/javascript" src="/Script/jquery-ui.js"></script>
    <link rel="stylesheet" type="text/css" href="/css/jquery-ui.css" />
    <link href="/css/braviStyle.css" rel="stylesheet" type="text/css" />
    <script src="/Script/braviPopup.js" type="text/javascript"></script>
    <link href="/assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet">
    <script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/masonry/3.3.2/masonry.pkgd.min.js"></script>    
    <script type="text/javascript" src="/assets/plugins/bootstrap/js/bootstrap.js"></script>   
    <%--<script type="text/javascript">
        $(document).ready(function () {           
            $("#popup-login").modal();
        });
    </script>--%>
    <style>
        
        #fof{display:block; width:100%; padding:150px 0; line-height:1.6em; text-align:center;}
        #fof .hgroup{margin-bottom:15px;}
        #fof .hgroup h1, #fof .hgroup h2{margin:0; padding:0; text-transform:uppercase;}
        #fof .hgroup h1{margin-bottom:15px; font-size:35px;}
        #fof .hgroup h2{display:inline-block; padding:0 0 15px 0; font-size:80px; border:solid #CCCCCC; border-width:1px 0; text-transform:lowercase;}
        #fof p{display:block; margin:15px 0 0 0; padding:0; font-size:16px;}
        #fof p:first-child{margin-top:0;}
    </style>
</head>
<body>

    <%--<form id="form1" runat="server">--%>
    <asp:Label runat="server" ID="lblStatus" ForeColor="Red"></asp:Label>
    <asp:Literal runat="server" ID="litScript"></asp:Literal>
    <div class="wrapper row2">
  <div id="container" class="clear">
    
    <section id="fof" class="clear">
     
      <div class="hgroup">
        
          <h1>Có lỗi xảy ra trong quá trình truy cập !</h1>
        <h2>404 Error</h2>
      </div>
    
        <p>For Some Reason The Page You Requested Could Not Be Found On Our Server</p>
     
   
    </section>
  
  </div>
</div>
    

    <div class="modal fade" id="popup-login">
        <div class="modal-dialog" role="document">
            <div class="modal-content">
              <div class="modal-header">
                <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
                <h4 class="modal-title">Thông báo</h4>
              </div>
              <div class="modal-body">
                <asp:Label runat="server" ID="lblAlert"></asp:Label>
              </div>
              <div class="modal-footer">
                <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>                
              </div>
            </div><!-- /.modal-content -->
          </div><!-- /.modal-dialog -->
    <%--</form>--%>
</body>
</html>
