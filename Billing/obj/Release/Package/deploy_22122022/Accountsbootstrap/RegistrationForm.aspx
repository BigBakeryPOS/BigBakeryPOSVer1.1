<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegistrationForm.aspx.cs" Inherits="Billing.Accountsbootstrap.RegistrationForm" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html lang="en">

<head >

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <title>Registration Form - bootsrap</title>

    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->

</head> 
<body>

    


     <usc:Header ID="Header" runat="server" />
 <div>
 
 
 <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="true"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false  "> </asp:Label>
          
          <div class="container-fluid">
	<div class="row">
                <div class="col-lg-12">
                    <div class="row panel-custom1">
                     <div class="panel-header">
                          <h1 class="page-header">Dealer Registration Form</h1>
	                    </div>
                             
                        <div class="panel-body">
                            <div class="row">
                            <form id="Form1" runat="server">
                                <div class="col-lg-4" >
                                    <div class="list-group">
                                        
                                            <label>Vendor Code</label>
											<asp:TextBox CssClass="form-control" ID="txtvendorcode" runat="server" Enabled="false"></asp:TextBox>
                                            
                                            <br />
                                       
                                            <label>Dealer Name</label>
                                            <asp:TextBox CssClass="form-control" ID="txtvendorname" MaxLength="50" runat="server"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" id="vend" controltovalidate="txtvendorname" errormessage="Please enter your Dealer Name!" style="color:Red" />
                                       <br />
                                            <label>Address</label>
                                            <asp:TextBox CssClass="form-control" ID="txtrateQty" MaxLength="150" runat="server"></asp:TextBox>
											 <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" id="RequiredFieldValidator1" controltovalidate="txtrateQty" errormessage="Please enter your Area!" style="color:Red" />
                                            
                                        <br />
                                            <label>Area</label>
                                            <asp:TextBox CssClass="form-control" ID="txtarea" MaxLength="50" runat="server"></asp:TextBox>
											 
                                          </div>  
                                        </div>
                                       
                                          <div class="col-lg-4" >
                                        
                                        <div class="list-group">
                                            <label>City</label>
                                            <asp:TextBox CssClass="form-control" ID="txtcity" MaxLength="50" runat="server"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" id="city" controltovalidate="txtcity" errormessage="Please enter your City!" style="color:Red" />
                                         <br />
                                            <label>Pincode</label>
                                            <asp:TextBox CssClass="form-control" MaxLength="6" ID="txtpincode" runat="server"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" id="pincode" controltovalidate="txtpincode" errormessage="Please enter your Pincode!" style="color:Red" />
                                         <br />
                                            <label>TIN No</label>
                                            <asp:TextBox CssClass="form-control" ID="txttinno" MaxLength="50" runat="server"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" id="RequiredFieldValidator2" controltovalidate="txttinno" errormessage="Please enter your TIN NO!" style="color:Red" />
                                        <br />
                                            <label>CST No</label>
                                            <asp:TextBox CssClass="form-control" ID="txtcstno" MaxLength="50" runat="server"></asp:TextBox>
                                             
                                        </div>
								
                                </div>
                               
                                <div class="col-lg-4" >
                                        <div class="list-group">
                                         <label>Mobile No</label>
                                        <div class=" input-group">
                                           <span class="input-group-addon">+91</span>
                                            <asp:TextBox CssClass="form-control" ID="txtmobileno" MaxLength="10" runat="server"></asp:TextBox>
                                        </div>
                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" id="RequiredFieldValidator4" controltovalidate="txtmobileno" errormessage="Please enter your Mobile No!" style="color:Red" />
                                        <br />
                                            <label>UserName</label>
                                            <asp:TextBox CssClass="form-control" ID="txtUserName" MaxLength="15" runat="server"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" id="RequiredFieldValidator5" controltovalidate="txtUserName" errormessage="Please enter UserName" style="color:Red" />
                                         <br />
                                            <label>Password</label>
                                            <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server"></asp:TextBox>
                                             <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" id="RequiredFieldValidator6" controltovalidate="txtPassword" errormessage="Please enter Password" style="color:Red" />
                                        
                                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                        
										<br /><br />
                                       <asp:Button ID="btnadd" runat="server" class="btn btn-lg btn-primary pos-btn1" Text="Save" width="150px" OnClick="Add_Click" ValidationGroup="val1" /> 
                                       <asp:Button ID="btnexit" runat="server" class="btn btn-lg btn-link" Text="Clear" OnClick="Exit_Click" />
                                </div>
                               </div>
                                
                                </form>
                                <!-- /.col-lg-6 (nested) -->
                                <!-- /.col-lg-6 (nested) -->
                            </div>
                            <!-- /.row (nested) -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
            </div>
            </div>    
		
		<!-- jQuery -->
    <script type="text/javascript" src="../js/jquery.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script type="text/javascript"  src="../js/bootstrap.min.js"></script>

    <!-- Metis Menu Plugin JavaScript -->
    <script type="text/javascript" src="../js/plugins/metisMenu/metisMenu.min.js"></script>

    <!-- Custom Theme JavaScript -->
    <script type="text/javascript" src="../js/sb-admin-2.js"></script>

</body>

</html>
