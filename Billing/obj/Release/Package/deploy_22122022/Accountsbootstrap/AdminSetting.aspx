<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminSetting.aspx.cs" Inherits="Billing.Accountsbootstrap.AdminSetting" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html>
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Customer Registration</title>
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <script type="text/javascript" language="javascript">
        function valchk() {
            if (blankchk(document.getElementById('txtcustomername'), "Customer Name")
            //&& dropdownchk(document.getElementById('ddlgroup'), "Account Group")  
        && phonechk(document.getElementById('txtmobileno'), "MobileNo") && phonechk(document.getElementById('txtphoneno'), "PhoneNo")
        && blankchk(document.getElementById('txtblnce'), "Opening Balance")
        && blankchk(document.getElementById('txtmobileno'), "MobileNo")
        && blankchk(document.getElementById('txtphoneno'), "Phone No") && blankchk(document.getElementById('txtarea'), "Area")
        && blankchk(document.getElementById('txtaddress'), "Address") && blankchk(document.getElementById('txtcity'), "City")
        && emailchk(document.getElementById('txtemail'), "Email")) {
                alert("true");
            }
            else {
                alert("false");
                return false;
            }
        }
    </script>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body style="">
    <form id="from1" runat="server" autocomplete="off">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" Visible="false" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <!--Heading Section Starts-->
    <asp:ScriptManager ID="s1" runat="server" EnablePageMethods="true" EnablePartialRendering="true">
    </asp:ScriptManager>
    <div class="col-lg-12" align="center">
        <h2>
            Setting Details</h2>
    </div>
    <!--Heading Section Ends-->
    <!-- /.row -->
    <!--Add Starts-->
    <div class="col-lg-1">
    </div>
      <div class="col-lg-3" style="">
                  </div>
    <div class="col-lg-4">
        <div class="panel panel-primary">
            <div class="panel-heading">
                Setting</div>
            <div class="panel-body">
                <div class="row" style="">
                 
                    <div class="col-lg-12" style="">
                        <div class="form-group">
                            <label>
                                From Date</label>
                            <asp:TextBox ID="txtFromDate" AutoCompleteType="Disabled" CssClass="form-control"
                                Enabled="true" runat="server" AutoPostBack="true" OnTextChanged="txtFromDate_OnTextChanged"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtFromDate"
                                Format="dd/MM/yyyy" PopupButtonID="txtFromDate" EnabledOnClient="true" runat="server"
                                CssClass="cal_Theme1">
                            </ajaxToolkit:CalendarExtender>
                        </div>
                        <div class="form-group">
                            <label>
                                To Date</label>
                            <asp:TextBox ID="txtToDate" CssClass="form-control" AutoCompleteType="Disabled" Enabled="true"
                                runat="server"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtToDate"
                                Format="dd/MM/yyyy" PopupButtonID="txtToDate" EnabledOnClient="true" runat="server"
                                CssClass="cal_Theme1">
                            </ajaxToolkit:CalendarExtender>
                        </div>
                        <div class="form-group" style="    margin-left: 40%;">
                            <asp:Button ID="btnSubmit" runat="server" class="btn btn-success" OnClick="btnSubmit_OnClick"  Text="Submit"  
                                ValidationGroup="val1" />
                        </div>
                    </div>
                   
                    <!-- /.col-lg-6 (nested) -->
                    <!-- /.col-lg-6 (nested) -->
                    <!-- /.col-lg-6 (nested) -->
                </div>
                <!-- /.row (nested) -->
            </div>
            <!-- /.panel-body -->
        </div>
        <!-- /.panel -->
    </div>
      <div class="col-lg-3" style="">
                  </div>
    <!-- /.col-lg-12 -->
    <div class="col-lg-1">
    </div>
    <!--Add Ends-->
    <!-- /.row -->
    <!-- /#page-wrapper -->
    <!-- jQuery -->
    </form>
</body>
</html>

