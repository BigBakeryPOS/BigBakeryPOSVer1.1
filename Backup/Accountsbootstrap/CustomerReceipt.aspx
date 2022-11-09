<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerReceipt.aspx.cs" Inherits="Billing.Accountsbootstrap.CustomerReceipt" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head id="Head1" runat="server">

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <title>Customer Receipt</title>

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
    



 
  


          <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
        <form id="Form1" runat="server" role="form">
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
            <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Receipt page</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-2">
                                    
                                       
                                        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                        <div class="form-group">
                                            <label>Date</label>
                                            <asp:TextBox CssClass="form-control" ID="txtreceiptdate" runat="server" Text="--Select Date--"></asp:TextBox>
                                        </div>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtreceiptdate" runat="server" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                                        
                                        
                                        <div class="form-group">
                                            <label>Mobile No.</label>
                                            <asp:TextBox CssClass="form-control" ID="txtMobileNo" runat="server"></asp:TextBox>
                                        </div>

                                       
                                        </div>

                                        <div class="col-lg-4" >


                                        <div class="form-group">
                                            <label>Contact Name</label>
                                        <asp:TextBox ID="txtcustomer" runat="server" CssClass="form-control"></asp:TextBox>
                                       <asp:TextBox ID="txtCustomerID" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                       <asp:TextBox ID="txtAdvAmount" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                        </div>

                                       
                                        <div class="form-group">
                                            <label >Address</label>
                                            <asp:TextBox CssClass="form-control" ID="txtaddress" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                         <asp:Label ID="lblerrorname" runat="server"  style="color:Red"></asp:Label>
                                        
										<div class="form-group">
                                            <label></label>
                                            <asp:TextBox CssClass="form-control" ID="txtcuscode" runat="server" Visible="false"></asp:TextBox>
                                        </div>
                                        
                                        
                                        
										
                                    
                                </div>

                                <div class="col-lg-2" >
                                <div class="form-group">
                                            <label>Area</label>
                                            <asp:TextBox CssClass="form-control" ID="txtarea" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
										
										<div class="form-group">
                                            <label> City</label>
                                            <asp:TextBox CssClass="form-control" ID="txtcity" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                        

                                </div>

                                <div class="col-lg-4">
                                <div class="form-group">
                                            <label>Pincode</label>
                                            <asp:TextBox CssClass="form-control" ID="txtpincode" runat="server" Enabled="false"></asp:TextBox>
                                        </div>
                                 <div class="table-responsive">
                                        
                                        <asp:Label ID="lblerror" runat="server"  style="color:Red"></asp:Label>
                                        </div>
                                </div>
                                <div>
            <div class="row">
                
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <!-- /.panel-heading -->
                        <div class="panel-body">
                            <div class="table-responsive">
                            <asp:Label ID="lblerrortable" runat="server"  style="color:Red"></asp:Label>
                                <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                                    <thead>
                                        <tr>
                                            <th>Bill No</th>
                                           
                                            
                                            <th>Bill Amount</th>
                                            <th>Balance</th>
											<th>Amount</th>
                                           
                                        </tr>
                                    </thead>
                                    <tbody>
                                    
                                        <tr class="odd gradeX">
                                        <td>
                                        <asp:TextBox CssClass="form-control" ID="txtBillNo" runat="server" Width="150px"></asp:TextBox>
                                        </td>
                                           
                                               <td class="center"><asp:TextBox CssClass="form-control" ID="txtbillamount1" runat="server" Width="150px"></asp:TextBox></td>
                                            <td class="center"><asp:TextBox CssClass="form-control" ID="txtbalance1"  Width="150px"
                                                    runat="server" AutoPostBack="true" ></asp:TextBox></td>
											<td class="center"><asp:TextBox CssClass="form-control" ID="txtamount1" runat="server" Width="150px"></asp:TextBox></td>
                                            
                                        </tr>
                                        
                                    </tbody>
                                </table>
								
                            </div>
							<asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Save" 
                                onclick="btnadd_Click" />
                            
                                        
										
                            <!-- /.table-responsive -->
                                <!-- /.col-lg-6 (nested) -->
                            </div>
                            <!-- /.row (nested) -->
                        </div>
                        <!-- /.panel-body -->
                    </div>
                    <!-- /.panel -->
                </div>
                <!-- /.col-lg-12 -->
            </div>
            <!-- /.row -->
            
        </div>
        <!-- /#page-wrapper -->
		</div>
        </div>
        </div>
        </div>
      
		
		
		<!-- jQuery -->
   </ContentTemplate>
</asp:UpdatePanel>
</form>
</body>

</html>
