<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WapXzone_VNM.Wap.Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>.: Vietnamobile - Dang Nhap :.</title>
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

    <form id="form1" runat="server">
    <asp:Label runat="server" ID="lblStatus" ForeColor="Red"></asp:Label>
    <asp:Literal runat="server" ID="litScript"></asp:Literal>
  <%--  <div class="wrapper row2">
  <div id="container" class="clear">
    
    <section id="fof" class="clear">
     
      <div class="hgroup">
        
          <h1>Có lỗi xảy ra trong quá trình truy cập !</h1>
        <h2>404 Error</h2>
      </div>
    
        <p>For Some Reason The Page You Requested Could Not Be Found On Our Server</p>
     
   
    </section>
  
  </div>
</div>--%>
    <div class="container">    
        <div id="loginbox" style="margin-top:50px;" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">                    
            <div class="panel panel-info" style="border-color:#ff8400">
                    <div class="panel-heading">
                        <div class="panel-title">Đăng nhập</div>                        
                    </div>     

                    <div style="padding-top:30px" class="panel-body" >

                        <div style="display:none" id="login-alert" class="alert alert-danger col-sm-12"></div>
                            
                        <div class="form-horizontal">
                                    
                            <div class="input-group">
                                        <span class="input-group-addon"><i class="glyphicon glyphicon-user"></i></span>                                        
                                        <asp:TextBox runat="server" ID="txtSDT" CssClass="form-control"  placeholder="Số điện thoại"></asp:TextBox> 
                                                                  
                                    </div>
                            <div class="col-sm-12">
                                <asp:Label runat="server" ID="lblsdt" ForeColor="Red"></asp:Label> 
                            </div>
                                <div style="margin-top:10px" class="form-group">
                                    <!-- Button -->

                                    <div class="col-sm-12 controls">                                         
                                        <asp:Button runat="server" ID="btnLogin" CssClass="btn btn-success" Text="Đăng nhập" OnClick="btnLogin_Click" />                                

                                    </div>
                                </div>


                                <div class="form-group">
                                    <div class="col-md-12 control">
                                        <div style="border-top: 1px solid#888; padding-top:15px; font-size:85%" >
                                            <p>Nếu Quý khách đã đăng ký dịch vụ, vui lòng đăng nhập số điện thoại đã đăng ký dịch vụ !</p>
                                       
                                        </div>
                                    </div>
                                </div>    
                            </div>    



                        </div>                     
                    </div>  
        </div>
        <div id="signupbox" style="display:none; margin-top:50px" class="mainbox col-md-6 col-md-offset-3 col-sm-8 col-sm-offset-2">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <div class="panel-title">Sign Up</div>
                            <div style="float:right; font-size: 85%; position: relative; top:-10px"><a id="signinlink" href="#" onclick="$('#signupbox').hide(); $('#loginbox').show()">Sign In</a></div>
                        </div>  
                        <div class="panel-body" >
                             <div class="form-horizontal" >
                            
                                
                                <div id="signupalert" style="display:none" class="alert alert-danger">
                                    <p>Error:</p>
                                    <span></span>
                                </div>
                                    
                                
                                  
                                <div class="form-group">
                                    <label for="email" class="col-md-3 control-label">Email</label>
                                    <div class="col-md-9">
                                        <input type="text" class="form-control" name="email" placeholder="Email Address">
                                    </div>
                                </div>
                                    
                                <div class="form-group">
                                    <label for="firstname" class="col-md-3 control-label">First Name</label>
                                    <div class="col-md-9">
                                        <input type="text" class="form-control" name="firstname" placeholder="First Name">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="lastname" class="col-md-3 control-label">Last Name</label>
                                    <div class="col-md-9">
                                        <input type="text" class="form-control" name="lastname" placeholder="Last Name">
                                    </div>
                                </div>
                                <div class="form-group">
                                    <label for="password" class="col-md-3 control-label">Password</label>
                                    <div class="col-md-9">
                                        <input type="password" class="form-control" name="passwd" placeholder="Password">
                                    </div>
                                </div>
                                    
                                <div class="form-group">
                                    <label for="icode" class="col-md-3 control-label">Invitation Code</label>
                                    <div class="col-md-9">
                                        <input type="text" class="form-control" name="icode" placeholder="">
                                    </div>
                                </div>

                                <div class="form-group">
                                    <!-- Button -->                                        
                                    <div class="col-md-offset-3 col-md-9">
                                        <button id="btn-signup" type="button" class="btn btn-info"><i class="icon-hand-right"></i> &nbsp Sign Up</button>
                                        <span style="margin-left:8px;">or</span>  
                                    </div>
                                </div>                             
                                
                               </div>
                                
                                
                            
                         </div>
                    </div>

               
               
                
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
    </form>
</body>
</html>
