<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchasePaymentEntry.aspx.cs" Inherits="Billing.Accountsbootstrap.PurchasePaymentEntry" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
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
    <title>Purchase Payment Entry</title>

   <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
        <link href="../Styles/style1.css" rel="stylesheet"/>
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
    <script type="text/javascript">
        function alertMessage() {
            alert('Are You Sure, You want to delete This Customer!');
        }
    </script>
    
</head> 
<body> 
<form runat="server" id="form1" method="post" style="margin-top:100px">
             <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
   <usc:Header ID="Header" runat="server" />
    <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Purchase Payment Entry</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>


          <div class="row" id="PurchaseEntry" runat="server" >
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="row">
                             <div class="col-lg-6">
                             <div class="form-group">
                                   <table class="table table-bordered table-striped">
                                   
                                   <tr>
                                   <td>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                                   <label>Entry Date</label>
                                   <asp:TextBox ID="txtDate" runat="server" CssClass="form-control">Select Date</asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDate" PopupButtonID="txtDate" EnabledOnClient="true"  runat="server" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                                   </td>
                                   <td>
                                   <label>Vendor Name</label>
                                   <asp:TextBox ID="txtVendorName" runat="server" CssClass="form-control"></asp:TextBox>
                                   </td>
                                   <td>
                                  
                                   <asp:TextBox ID="txtVendorID" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                   </td>
                                   </tr>
                                   <tr>
                                   <td>
                                   <label>Payment Mode</label>
                                  <asp:DropDownList ID="ddlPaymentMode" runat="server" CssClass="form-control" 
                                           AutoPostBack="true" 
                                           onselectedindexchanged="ddlPaymentMode_SelectedIndexChanged">
                                  <asp:ListItem Text="Select Payment Mode" Value="0"></asp:ListItem>
                                  <asp:ListItem Text="Cash" Value="1"></asp:ListItem>
                                  <asp:ListItem Text="Cheque/DD" Value="2"></asp:ListItem>
                                  <asp:ListItem Text="Online Transcation" Value="3"></asp:ListItem>
                                  </asp:DropDownList>
                                  <label id="lblerror" runat="server"  style="color:Red"></label>
                                   </td>
                                   <td>
                                   <label>Bank Name</label>
                                   <asp:TextBox ID="txtbankName" runat="server" CssClass="form-control"></asp:TextBox>
                                   </td>
                                   <td>
                                   <label>Reference No</label>
                                   <asp:TextBox ID="txtRefNo" runat="server" CssClass="form-control"></asp:TextBox>
                                   </td>
                                   </tr>
                                   
                                   </table>

                                   
                                 </div>
                                 <div class="form-group">
                                  <table class="table table-bordered table-striped">

                                  <tr>
                                  <td>
                                  <label>Bill No</label>
                                   <asp:TextBox ID="txtBillNo" runat="server" CssClass="form-control"></asp:TextBox>
                                  </td>
                                  <td>
                                  <label>Bill Amount</label>
                                   <asp:TextBox ID="txtBillAmt" runat="server" CssClass="form-control"></asp:TextBox>
                                  </td>
                                  <td>
                                  <label>Paying Amount</label>
                                   <asp:TextBox ID="txtPayingAmt" runat="server" CssClass="form-control"  
                                          ontextchanged="txtPayingAmt_TextChanged"></asp:TextBox>
                                  </td>
                                  <td>
                                  <label>Balance</label>
                                   <asp:TextBox ID="txtBalance" runat="server" CssClass="form-control"></asp:TextBox>
                                  </td>
                                  </tr>
                                  <tr>
                                  <td>
                                  <asp:Button ID="btnsave" runat="server" CssClass="btn btn-success" Text="Save" 
                                          onclick="btnsave_Click" />
                                  </td>
                                  </tr>

                                  </table>
                                                                   </div>
                                 </div>
                                </div>
                                
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

  </form>
</body>

</html>
