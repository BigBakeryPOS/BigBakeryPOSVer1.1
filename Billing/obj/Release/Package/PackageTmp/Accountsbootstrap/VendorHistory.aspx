<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="VendorHistory.aspx.cs" Inherits="Billing.Accountsbootstrap.VendorHistory" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>GRN Report </title>

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
    <style type="text/css">
    .mydatagrid
{
	width: 80%;
	border: solid 2px black;
	min-width: 80%;
}
.header
{
	background-color: #646464;
	font-family: Arial;
	color: White;
	border: none 0px transparent;
	height: 25px;
	text-align: center;
	font-size: 16px;
}
.rows
{
	background-color: #fff;
	font-family: Arial;
	font-size: 14px;
	color: #000;
	min-height: 25px;
	text-align: left;
	border: none 0px transparent;
}
.rows:hover
{
	background-color: #ff8000;
	font-family: Arial;
	color: #fff;
	text-align: left;
}
.selectedrow
{
	background-color: #ff8000;
	font-family: Arial;
	color: #fff;
	font-weight: bold;
	text-align: left;
}
.mydatagrid a /** FOR THE PAGING ICONS  **/
{
	background-color: Transparent;
	padding: 5px 5px 5px 5px;
	color: #fff;
	text-decoration: none;
	font-weight: bold;
}
.mydatagrid a:hover /** FOR THE PAGING ICONS  HOVER STYLES**/
{
	background-color: #000;
	color: #fff;
}
.mydatagrid span /** FOR THE PAGING ICONS CURRENT PAGE INDICATOR **/
{
	background-color: #c9c9c9;
	color: #000;
	padding: 5px 5px 5px 5px;
}
.pager
{
	background-color: #646464;
	font-family: Arial;
	color: White;
	height: 30px;
	text-align: left;
}
.mydatagrid td
{
	padding: 5px;
}
.mydatagrid th
{
	padding: 5px;
}
    </style>
    <script type="text/javascript">
        function alertMessage() {
            alert('Are You Sure, You want to delete This Customer!');
        }
    </script>
    
</head> 

<body>
             <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
   <usc:Header ID="Header" runat="server" />
    <div class="row">
                <div class="col-lg-12" style="padding-top:70px">
                    <h1 class="page-header">Stock History</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>


          <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <form runat="server" id="form1" method="post">
                                    <div class="col-lg-3">
    <label>Select Branch</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server" Visible="false"  Width="150px" 
                                       >
                                       <asp:ListItem Text="KK Nagar" Value="co1"></asp:ListItem>
                                       <asp:ListItem Text=" Byepass" Value="co2"></asp:ListItem>
                                       <asp:ListItem Text=" BB Kulam" Value="co3"></asp:ListItem>
                                       <asp:ListItem Text="Narayanapuram" Value="co4"></asp:ListItem>
                                       <asp:ListItem Text="Nellai" Value="co5"></asp:ListItem>
                                       <asp:ListItem Text="Maduravayol" Value="co6"></asp:ListItem>
                                       <asp:ListItem Text="Purasavakkam" Value="co7"></asp:ListItem>
                                        <asp:ListItem Text="Chennai Pothys" Value="co8"></asp:ListItem>

                                          <asp:ListItem Text="Thirunelveli" Value="co9"></asp:ListItem>
                                            <asp:ListItem Text="Periyar" Value="co10"></asp:ListItem>
                                              <asp:ListItem Text="Palayam" Value="co11"></asp:ListItem>
                                    </asp:DropDownList>
    </div>
                                    <div class="form-group">
                                            <label>Filter By Slot No</label>
                                        <asp:TextBox ID="txtCustomerName" runat="server" Width="100px" CssClass="form-control"></asp:TextBox>
                                                  

                                               
                                        <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search"  
                                                style="margin-top: 10px;" onclick="btnsearch_Click1"  /> 
                                        <asp:Button ID="btnrefresh" runat="server" class="btn btn-warning" Text="Reset"  
                                                style="margin-top: 10px;" onclick="btnrefresh_Click1"  /> 
                                          
                                        </div> 
                               

                               <div class="table-responsive">
                                        
                                <table class="table table-bordered table-striped">
                                <tr>
                                <td>

                                
                                <asp:GridView ID="gvPurchaseEntry" runat="server" AllowPaging="false"    CssClass=""   GridLines="Both"
                                        AutoGenerateColumns="false"  onrowdatabound="gvPurchaseEntry_RowDataBound" 
                                          >
                                 
                                <PagerSettings  Mode="Numeric"   />
    <Columns>
    <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>  
    <asp:BoundField HeaderText="Group" DataField="category" />
     <asp:BoundField HeaderText="Item" DataField="definition" />
     <asp:BoundField HeaderText="Qty" DataField="grn_qty"  DataFormatString="{0:f0}"  />
      <asp:BoundField HeaderText="Date" DataField="Date" />
       <asp:BoundField HeaderText="Slot No" DataField="GRNNo" />
    <asp:BoundField HeaderText="GRN TYPE" DataField="type" />
    <asp:BoundField HeaderText="Branch Request No" DataField="reqno" />
    <asp:BoundField HeaderText="Goods Received DC No" DataField="dcno" />
   

    
   </Columns>
    <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> 
   </asp:GridView>
                                </td>
                                
                                </tr>
                                
                                </table>
                                </div>



                                     
                                   
                                    </form>
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


</body>
</html>
