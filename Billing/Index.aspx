<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="AdminBVKPropertyApp.Index" %>

 
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<!--<![endif]-->
<!-- BEGIN HEAD -->
<head>
    <meta charset="utf-8" />
    <title>Swastik Property</title>
    <link rel="icon" href="http://bigdbiz.com/../assets/images/favicon.ico">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="Preview page of Metronic Admin Theme #2 for supports searching, remote data sets, and infinite scrolling of results"
        name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all"
        rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/simple-line-icons/simple-line-icons.min.css"
        rel="stylesheet" type="text/css" />
    <link href="../assets/global/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet"
        type="text/css" />
    <link href="../assets/global/plugins/bootstrap-switch/css/bootstrap-switch.min.css"
        rel="stylesheet" type="text/css" />
   
    
</head>
<!-- END HEAD -->
<%--<body class="page-container-bg-solid page-header-fixed page-sidebar-closed-hide-logo page-md page-sidebar-closed">--%>
<%--<body class="page-sidebar-closed-hide-logo page-container-bg-solid page-md">--%>
<body>
    
    <div class="clearfix">
    </div>
    <div class="page-container">
       
        <!-- BEGIN CONTENT -->
        <form id="f1" runat="server">
        <asp:ScriptManager ID="SM" runat="server">
        </asp:ScriptManager>
        <div class="page-content-wrapper">
            <!-- BEGIN CONTENT BODY -->
            <div class="page-content">
             <div class="portlet light ">
                 <div class="row">
                 <div class="col-md-12" style="margin-top:7%">
                   <div class="col-md-2" >
                   </div>
                <div class="col-md-3" >
                    <div class="card product-card">
                        <div >
                            <img src="Admin.png" alt="product image" style="width:250px; height:250px;margin-left: 40px;">
                            <h2 class="title" style="text-align: center;">Admin Master</h2>

                            <a href="../Admin/BuildingMasterGrid.aspx" class="btn btn-sm btn-success btn-block" >Proceed</a>
                        </div>
                    </div>
                </div>
                 <div class="col-md-2" >
                   </div>
                <div class="col-md-3" >
                    <div class="card product-card">
                        <div >
                            <img src="MISReports.png"   alt="product image" style="width:250px; height:250px;margin-left: 40px;">
                            <h2 class="title" style="text-align: center;">MIS Reports</h2>

                            <a href="../Reports/Dashboard.aspx" class="btn btn-sm btn-success btn-block" >Proceed</a>
                        </div>
                    </div>
                </div>

                  <div class="col-md-2" >
                   </div>
                </div>
            </div>
            </div>
            </div>
            <!-- END CONTENT BODY -->
        </div>
        <!-- END CONTENT -->
    </div>
    <!-- END CONTAINER -->
    <!-- BEGIN FOOTER -->
    <div class="page-footer">
        
        <!-- END FOOTER -->
        <!-- BEGIN QUICK NAV -->
        <!-- END QUICK NAV -->
        <!--[if lt IE 9]>
<script src="../../assets/global/plugins/respond.min.js"></script>
<script src="../../assets/global/plugins/excanvas.min.js"></script> 
<script src="../../assets/global/plugins/ie8.fix.min.js"></script> 
<![endif]-->
    </div>
    </form>
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script src="../assets/global/plugins/jquery.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/js.cookie.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/jquery-slimscroll/jquery.slimscroll.min.js"
        type="text/javascript"></script>
    <script src="../assets/global/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="../assets/global/plugins/bootstrap-switch/js/bootstrap-switch.min.js"
        type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    
    <script>
        $(document).ready(function () {
            $('#clickmewow').click(function () {
                $('#radio1003').attr('checked', 'checked');
            });
        })
            </script>
</body>
</html>
