<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseReturn.aspx.cs" Inherits="Billing.PurchaseReturn" %>
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
	<script src="../jqueryCalendar/script.js" type="text/javascript"></script>
	<script type="text/javascript" src="../jqueryCalendar/jquery-1.6.2.min.js"></script>
<script type="text/javascript" src="../jqueryCalendar/jquery-ui-1.8.15.custom.min.js"></script>
<link rel="stylesheet" href="../jqueryCalendar/jqueryCalendar.css"/>
<script type="text/javascript">
    jQuery(function () {
        jQuery("#inf_custom_someDateField").datepicker();
    });
                </script>
                <style type="text/css">
	.TFtable{
		width:100%; 
		border-collapse:collapse; 
	}
	.TFtable td{ 
		padding:7px; border:#4e95f4 1px solid;
	}
	/* provide some minimal visual accomodation for IE8 and below */
	.TFtable tr{
		background: #b8d1f3;
	}
	/*  Define the background color for all the ODD background rows  */
	.TFtable tr:nth-child(odd){ 
		background: #b8d1f3;
	}
	/*  Define the background color for all the EVEN background rows  */
	.TFtable tr:nth-child(even){
		background: #dae5f4;
	}
</style>
                <script type="text/javascript">
                @{ 
var db = Database.Open("SmallBakery"); 
var dbdata = db.Query("select c.Definition,a.UnitPrice from tblStock a,tblcategory  b,tblCategoryUser c where a.CategoryID=b.categoryid and a.SubCategoryID=c.CategoryUserID"); 
var myChart = new Chart(width: 600, height: 400) 
  .AddTitle("Product Sales") 
  .DataBindTable(dataSource: dbdata, xField: "c.Definition") 
  .Write();
}
                </script>
                <script language="javascript" type="text/javascript">

                    function NumberOnly() {
                        var AsciiValue = event.keyCode
                        if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
                            event.returnValue = true;
                        else

                            event.returnValue = false;
                    }

</script>
    
    <title>CashSales Page - bootsrap</title>

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
    <script type="text/javascript">
        function myFunction() {
            window.open("http://localhost:49197/Accountsbootstrap/itempage.aspx?Mode=Sales", "Popup", 'height=300,width=500,resizable=yes,modal=yes,center=yes');
        }
</script>
 <script type="text/javascript">
     function AddVendor() {
         window.open("http://localhost:49197/Accountsbootstrap/customermaster.aspx?Mode=Sales", "Popup", 'height=300,width=500,resizable=yes,modal=yes,center=yes');
     }
</script>
</head> 
<body>

  <usc:Header ID="Header" runat="server" />  
  <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                   <form id="Form1" runat="server" >
                      
                                 
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
<div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header" style="margin-top:100px">Purchase Return</h1>
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
                                            <label>Returing</label>
											<asp:TextBox CssClass="form-control"  Width="50px" ID="txtbillno" Enabled="false" runat="server"></asp:TextBox>
                                            
                                            
                                        </div>
                                       
                                        <div class="form-group">
                                            <label>Bill Date</label>
                                            <asp:TextBox CssClass="form-control" ID="txtsdate1" runat="server" Text="-----Select Date-----" Width="150px"  ></asp:TextBox>
                                        </div>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtdate1" PopupButtonID="txtsdate1" EnabledOnClient="true"  runat="server" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                                        


                                       
                                        

                                        <div class="col-lg-4" >


                                    

                                        <div class="form-group">
                                            <label>Production Name</label>
                                            <asp:TextBox CssClass="form-control" ID="txtProduction" runat="server" ></asp:TextBox>
                                        </div>
                                        
                                         <asp:Label ID="Label2" runat="server"  style="color:Red"></asp:Label>
                                        
										<div class="form-group">
                                            <label>Request No</label>
                                            <asp:TextBox CssClass="form-control" ID="txtRequestNo" runat="server" ></asp:TextBox>
                                        </div>
                                        
                                        
                                        
										
                                    
                                </div>

                                <div class="col-lg-2" >
                                <div class="form-group">
                                           
                                            <label>Enter DC No</label>

                                       
                                         <asp:TextBox ID="txtCustname"  Width="150px"   CssClass="form-control"  TabIndex="1" runat="server"></asp:TextBox>
                                         <asp:Button id="btncheck" runat="server" Text="Enter" onclick="btncheck_Click1"  />
                                        <asp:Label ID="lblerrorname" runat="server" ForeColor="Red"></asp:Label>
                                        </div>
										
										<div  class="form-group">
                                            
                                           <asp:TextBox Visible="false" CssClass="form-control" ID="txtcity" runat="server" TabIndex="4" Width="150px" ></asp:TextBox>
                                        </div>
                                        

                                </div>

                                <div class="col-lg-4">
                                <div class="form-group">
                                            <
                                            <asp:TextBox Visible="false" CssClass="form-control" ID="txtaddress" TabIndex="2" runat="server" Width="350px"></asp:TextBox>
                                        </div>
                                          <div class="form-group">
                                            
                                             <asp:TextBox Visible="false" CssClass="form-control" ID="txtpincode" runat="server" TabIndex="5" Width="100px" ></asp:TextBox>
                                             <asp:LinkButton Visible="false" ID="LinkButton1" Text="Add-Contacts" runat="server" AccessKey="N" OnClientClick="return AddVendor()"></asp:LinkButton>
                                        </div>
                                 
                                </div>


                              
                                       
                                       <div class="col-lg-4" >
                                      
										<div class="form-group">
                                           
                                            <asp:TextBox CssClass="form-control"   Width="50px" ID="txtcustomername" runat="server" Enabled="false" Visible="false"></asp:TextBox>
                                        </div>
                                      
                                        
                                      
                                           <div class="form-group" >
                                           
                                      
                                           
                                      
                                        <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                                        </div>
                                       
                                        
										<div class="form-group">
                                            <label></label>
                                            <asp:TextBox CssClass="form-control" ID="txtcuscode" runat="server" Visible="false"></asp:TextBox>
                                            <%--<asp:TextBox CssClass="form-control" ID="txtsalesID" runat="server" Visible="false"></asp:TextBox>--%>
                                        </div>

                                        
                                        </div>
										
                                    <div class="col-lg-4" >
                                      
									

                                        
                                        </div>
                                
                                <div id="row" runat="server">
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
                                
                                <table class="TFtable" id="dataTables-example">
                                    <thead>
                                        <tr>
                                       
                                        <asp:LinkButton Visible="false" ID="btnsales" Text="Add New Item" runat="server" AccessKey="N" OnClientClick="return myFunction()"></asp:LinkButton>
                                        
                                        </tr>
                                        <tr>
                                            
                                            <th>Category</th>
                                            <th>Item</th>
                                            <th>Returning Qty</th>
                                           <th>Units</th>
                                           <th>Reason</th>
                                            <th>Cancel</th>
                                            <th visible="false">Date</th>
                                         
                                          
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr class="odd gradeX">
                                            <td><asp:DropDownList runat="server" ID="ddlcategory" Width="200px" class="form-control"
                                                    AutoPostBack="true" 
                                                    onselectedindexchanged="ddlcategory_SelectedIndexChanged">
                                           
                                             </asp:DropDownList></td>
                                             <td><asp:DropDownList runat="server" ID="ddldef" Width="150px" CssClass="form-control"
                                                     onselectedindexchanged="ddldef_SelectedIndexChanged"  AutoPostBack="true"></asp:DropDownList></td>
                                            <%--<td><asp:TextBox CssClass="form-control" ID="txtdef" runat="server"></asp:TextBox></td>--%>
                                        
                                                    <td><asp:TextBox CssClass="form-control" Width="150px" ID="txtqty" 
                                                    style="text-align:right" runat="server"  >0</asp:TextBox></td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator3" ControlToValidate="txtqty" runat="server"  ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                           <td> <asp:DropDownList ID="ddlUnits" runat="server" CssClass="form-control">
                                           <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                           <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                           <asp:ListItem Text="No" Value="3"></asp:ListItem>
                                           <asp:ListItem Text="Mos" Value="4"></asp:ListItem>
                                           </asp:DropDownList></td>
                                           <td><asp:DropDownList ID="ddlReasons" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                           <asp:ListItem Text="Excess Return" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="Damaged" Value="2"></asp:ListItem>
                                           <asp:ListItem Text="Complimentry" Value="3"></asp:ListItem>
                                         
                                           
                                           </asp:DropDownList></td>
                                                   
                                                  <td class="center"><asp:ImageButton ID="ImageButton5" runat="server"  
                                                          ImageUrl="~/images/cancel-circle.png" onclick="ImageButton5_Click"  /></td>
                                                          <td> <asp:TextBox ID="txtDate" runat="server"></asp:TextBox></td>
											
                                        </tr>
                                    </tbody>
                                    <tbody>
                                        <tr class="odd gradeX">
                                            <td><asp:DropDownList runat="server" ID="ddlcategory1" Width="200px" class="form-control" AutoPostBack="true" onselectedindexchanged="ddlcategory1_SelectedIndexChanged">
                                                                                       
                                            </asp:DropDownList></td>
                                            <td><asp:DropDownList runat="server" Width="150px" ID="ddldef1" CssClass="form-control"   AutoPostBack="true" 
                                                    onselectedindexchanged="ddldef1_SelectedIndexChanged" ></asp:DropDownList></td>
                                            <%--<td><asp:TextBox CssClass="form-control" ID="ddldef1" runat="server"></asp:TextBox></td>--%>
                                            <td><asp:TextBox Width="150px" CssClass="form-control" ID="txtqty1"  
                                                    style="text-align:right" runat="server" >0</asp:TextBox></td>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtqty1" runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                            
                                            <td> <asp:DropDownList ID="ddlUnits1" runat="server" CssClass="form-control">
                                             <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                           <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                           <asp:ListItem Text="No" Value="3"></asp:ListItem>
                                           <asp:ListItem Text="Mos" Value="4"></asp:ListItem></asp:DropDownList></td>
                                           <td><asp:DropDownList ID="ddlReasons1" runat="server" CssClass="form-control">
                                             <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                           <asp:ListItem Text="Excess Return" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="Damaged" Value="2"></asp:ListItem>
                                           <asp:ListItem Text="Complimentry" Value="3"></asp:ListItem>
                                           </asp:DropDownList></td>
                                            
                                                     <td class="center"><asp:ImageButton ID="imgClear1" runat="server" OnClick="imgClear1_Click1" ImageUrl="~/images/cancel-circle.png"  /></td>
											 <td> <asp:TextBox ID="txtDate1" runat="server"></asp:TextBox></td>
                                       
                                        </tr>
                                    </tbody>
                                    <tbody>
                                        <tr class="odd gradeX">
                                            <td><asp:DropDownList Width="200px" runat="server" ID="ddlcategory2" class="form-control" AutoPostBack="true" onselectedindexchanged="ddlcategory2_SelectedIndexChanged">
                                                                                       
                                            </asp:DropDownList></td>
                                            <td><asp:DropDownList Width="150px" runat="server" ID="ddldef2" CssClass="form-control"  
                                                    onselectedindexchanged="ddldef2_SelectedIndexChanged"  AutoPostBack="true"></asp:DropDownList></td>
                                            <td><asp:TextBox CssClass="form-control" ID="txtqty2"  Width="150px" 
                                                    style="text-align:right" runat="server"  >0</asp:TextBox></td>
                                             

                                             <td> <asp:DropDownList ID="ddlUnits2" runat="server" CssClass="form-control">
                                              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                           <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                           <asp:ListItem Text="No" Value="3"></asp:ListItem>
                                           <asp:ListItem Text="Mos" Value="4"></asp:ListItem>
                                             </asp:DropDownList></td>
                                           <td><asp:DropDownList ID="ddlReasons2" runat="server" CssClass="form-control">
                                             <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                           <asp:ListItem Text="Excess Return" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="Damaged" Value="2"></asp:ListItem>
                                           <asp:ListItem Text="Complimentry" Value="3"></asp:ListItem>
                                           </asp:DropDownList></td>
                                              
                                          
                                                     <td class="center"><asp:ImageButton ID="ImageButton1" runat="server" OnClick="ImageButton1_Click"  ImageUrl="~/images/cancel-circle.png"  /></td>
										 <td> <asp:TextBox ID="txtDate2" runat="server"></asp:TextBox></td>
                                        
                                        </tr>
                                    </tbody>
                                    <tbody>
                                        <tr class="odd gradeX">
                                            <td><asp:DropDownList runat="server" ID="ddlcategory3" Width="200px" class="form-control" AutoPostBack="true" onselectedindexchanged="ddlcategory3_SelectedIndexChanged">
                                                                                       
                                            </asp:DropDownList></td>
                                            <td><asp:DropDownList runat="server" ID="ddldef3" Width="150px" CssClass="form-control"  
                                                    onselectedindexchanged="ddldef3_SelectedIndexChanged" ></asp:DropDownList></td>
                                            <td><asp:TextBox CssClass="form-control" ID="txtqty3"  Width="150px"   AutoPostBack="true" 
                                                    style="text-align:right" runat="server" >0</asp:TextBox></td>

                                             <td> <asp:DropDownList ID="ddlUnits3" runat="server" CssClass="form-control">
                                              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                           <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                           <asp:ListItem Text="No" Value="3"></asp:ListItem>
                                           <asp:ListItem Text="Mos" Value="4"></asp:ListItem>
                                             </asp:DropDownList></td>
                                           <td><asp:DropDownList ID="ddlReasons3" runat="server" CssClass="form-control">
                                             <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                           <asp:ListItem Text="Excess Return" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="Damaged" Value="2"></asp:ListItem>
                                           <asp:ListItem Text="Complimentry" Value="3"></asp:ListItem>
                                           </asp:DropDownList></td>
                                              
                                              
                                              <td><asp:ImageButton ID="ImageButton3" 
                                                            runat="server"   OnClick="ImageButton2_Click"                                                    
    ImageUrl="~/images/cancel-circle.png"  /></td>
     <td> <asp:TextBox ID="txtDate3" runat="server"></asp:TextBox></td>
                                            </tr>
                                               </tbody>
                                               <tbody>
                                        <tr class="odd gradeX">
                                            <td><asp:DropDownList runat="server" ID="ddlcategory4" class="form-control" AutoPostBack="true" onselectedindexchanged="ddlcategory4_SelectedIndexChanged" Width="200px">
                                                                                       
                                            </asp:DropDownList></td>
                                            <td><asp:DropDownList runat="server" ID="ddldef4" CssClass="form-control"  Width="150px"  
                                                    onselectedindexchanged="ddldef4_SelectedIndexChanged" ></asp:DropDownList></td>
                                            <td><asp:TextBox CssClass="form-control" ID="txtqty4"   Width="150px" AutoPostBack="true"
                                                    style="text-align:right" runat="server" >0</asp:TextBox></td>
                                            
                                            <td> <asp:DropDownList ID="ddlUnits4" runat="server" CssClass="form-control">
                                             <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                           <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                           <asp:ListItem Text="No" Value="3"></asp:ListItem>
                                           <asp:ListItem Text="Mos" Value="4"></asp:ListItem>
                                            </asp:DropDownList></td>
                                           <td><asp:DropDownList ID="ddlReasons4" runat="server" CssClass="form-control">
                                             <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                           <asp:ListItem Text="Excess Return" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="Damaged" Value="2"></asp:ListItem>
                                           <asp:ListItem Text="Complimentry" Value="3"></asp:ListItem>
                                           </asp:DropDownList></td>
                                            
                                            <td>
                                            <asp:ImageButton ID="ImageButton2" 
                                                            runat="server"   OnClick="ImageButton3_Click"                                                    
    ImageUrl="~/images/cancel-circle.png"  /></td> <td> <asp:TextBox ID="txtDate4" runat="server"></asp:TextBox></td>
                                              
                                            </tr>
                                               </tbody>
                                               <tbody>
                                        <tr class="odd gradeX">
                                            <td><asp:DropDownList runat="server" ID="ddlcategory5" class="form-control" AutoPostBack="true" onselectedindexchanged="ddlcategory5_SelectedIndexChanged" Width="200px">
                                                                                       
                                            </asp:DropDownList></td>
                                            <td><asp:DropDownList runat="server" ID="ddldef5" CssClass="form-control" Width="150px" 
                                                    onselectedindexchanged="ddldef5_SelectedIndexChanged" ></asp:DropDownList></td>
                                            <td><asp:TextBox CssClass="form-control" ID="txtqty5" 
                                                    style="text-align:right" runat="server"   AutoPostBack="true" Width="150px">0</asp:TextBox></td>
                                         
                                          <td> <asp:DropDownList ID="ddlUnits5" runat="server" CssClass="form-control">
                                           <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                           <asp:ListItem Text="Kg" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="Kgs" Value="2"></asp:ListItem>
                                           <asp:ListItem Text="No" Value="3"></asp:ListItem>
                                           <asp:ListItem Text="Mos" Value="4"></asp:ListItem>
                                          </asp:DropDownList></td>
                                           <td><asp:DropDownList ID="ddlReasons5" runat="server" CssClass="form-control">
                                             <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                           <asp:ListItem Text="Excess Return" Value="1"></asp:ListItem>
                                           <asp:ListItem Text="Damaged" Value="2"></asp:ListItem>
                                           <asp:ListItem Text="Complimentry" Value="3"></asp:ListItem>
                                           </asp:DropDownList></td>
                                            <td class="center"><asp:ImageButton ID="ImageButton4" 
                                                            runat="server"   OnClick="ImageButton4_Click"                                                    
    ImageUrl="~/images/cancel-circle.png"  /></td> <td> <asp:TextBox ID="txtDate5" runat="server"></asp:TextBox></td>
                                              
                                            </tr>
                                            </tbody>
                                            <tbody>
                                               <tr class="odd gradeX">
                                                    <td valign="middle" align="right" colspan="5">
                                                     <label  >Total Qty</label>
                                                   
                                                         <asp:TextBox CssClass="form-control" ID="txtgrandtotal"  runat="server" style="width: 150px; text-align:right" ></asp:TextBox>
                                                     </td>
                                                    </tr>
                                            </tbody>
                                            <tbody>
                                                   

                                            
                                               
                                                     <tr class="odd gradeX">
                                                    <td valign="middle" align="right" colspan="6">
                                                                                    <asp:Button ID="btncalc" runat="server" Text="Calc" CssClass="btn btn-success" style="width: 45px;margin-left: 10px; margin-top:-4px;"  onclick="btncalc_Click" />
                                                 <asp:RequiredFieldValidator ID="txtgt" ValidationGroup="val1" ControlToValidate="txtgrandtotal" ErrorMessage="Please calculate your Grand Total" runat="server"></asp:RequiredFieldValidator>    
                         
                                                    </td>
                                                    </tr>
                                                <tr id="trTax" runat="server" class="odd gradeX">
                                             <td align="right" colspan="6">
                                             
                                       
                                       <table>
                                       <tr>
                                       <td>
                                       
                                       </td>

                                       <td>
                                       <asp:TextBox CssClass="form-control" ID="txtdiscount" Visible="false"   runat="server" style="width: 110px;margin-left: 46px; margin-top:11px; text-align:right" >0</asp:TextBox>
                                       
                                       </td>

                                       <td>
                                        <asp:TextBox CssClass="form-control" ID="txtDiscamt" Visible="false"  Enabled="false" runat="server" style="width: 110px;margin-left: 43px; margin-top:17px; text-align:right" >0</asp:TextBox>
                                      <%-- <asp:Label ID="lblDisc" runat="server" ></asp:Label>--%>
                                       </td>
                                       </tr>
                                       
                                       </table>

                                    
                                        
                                        
                                        
                                         
                                         
                                       
                                       
                                       
                                       
                                        
                                                     
                                                   
                                                    </td>
                                                   
                                                    </tr>
                                                    
                                                    
                                        <tr>
                                        <td id="advance" runat="server" style="margin-top:100px">
                                        <label ></label>
                                        <asp:TextBox ID="txtadvance" runat="server" Visible="false" CssClass="form-control">0</asp:TextBox>
                                        </td>
                                        </tr>
                                    </tbody>

                                </table>
               
								
                                        
                                        
                                         
                                        
                            </div>
							<asp:Button ID="btnadd" runat="server" class="btn btn-success" ValidationGroup="val1"  OnClick="Add_Click" />
                                        <asp:Label ID="lblError" runat="server" style="color:Red"></asp:Label>
                            <!-- /.table-responsive -->
                                <!-- /.col-lg-6 (nested) -->
                            </div>
                            </form>
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
        </ContentTemplate>
</asp:UpdatePanel>
</form>
</body>

</html>
