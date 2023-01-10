<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerBillReport.aspx.cs" Inherits="Billing.Accountsbootstrap.CustomerBillReport" %>
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
    <title>Sales Grid Master - bootsrap</title>

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
             <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
   <usc:Header ID="Header" runat="server" />
    <div class="row">
                <div class="col-lg-12" style="margin-top:100px">
                    <h1 class="page-header">Customer Bill Report</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>


          <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6">
                                    <form runat="server" id="form1" method="post">
                                     <div class="form-group">
                                            <label>Select Branch</label>
											<asp:DropDownList ID="ddBranch" runat="server"  Width="150px"  AutoPostBack="true"
                                            CssClass="form-control" >
                                   <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                   <asp:ListItem Text="Branch 1" Value="1"></asp:ListItem>
                                   <asp:ListItem Text="Branch 2" Value="2"></asp:ListItem>
                                   <asp:ListItem Text="Branch 3" Value="3"></asp:ListItem>
                                    </asp:DropDownList>
                                                                                       
                                        </div>
                                     <div class="form-group">
                                            <label>From Date</label>
											<asp:TextBox CssClass="form-control" ID="txtfrmdate" runat="server" Text="--Select Date--"></asp:TextBox>
                                                                                       
                                        </div>
                                        <ajaxToolkit:CalendarExtender ID="txtfrmdate1" TargetControlID="txtfrmdate"  runat="server" CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                                         <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
										<div class="form-group">
                                            <label>To Date</label>
											<asp:TextBox CssClass="form-control" ID="txttodate" runat="server" Text="--Select Date--"></asp:TextBox>
                                                                                       
                                        </div>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txttodate" runat="server"  CssClass="cal_Theme1"></ajaxToolkit:CalendarExtender>
                                          <asp:Button ID="btnGenerate" runat="server" CssClass="btn btn-success" 
                                         Text="Generate Report" onclick="btnGenerate_Click"/>
                                          </div>
                                           <div class="col-lg-12">
                                           <div style="color: Green; font-weight: bold">
            <br />
          
        </div>
                               <div class="table-responsive">
                                        
                                <table class="table table-bordered table-striped">
                                <tr>
                                <td>
                                <asp:GridView ID="gvsales"   runat="server"  
                                        CssClass="myGridStyle"  AutoGenerateColumns="false" 
                                        onrowdatabound="gvsales_RowDataBound" onrowcommand="gvsales_RowCommand" >
                                <HeaderStyle BackColor="#3366FF" />
                               
    <Columns>
    <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
    
    
    <asp:BoundField HeaderText="Bill No" DataField="BillNo" SortExpression="BillNo" />
    
    <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" />
      <asp:BoundField HeaderText="Bill Amount" DataField="BillAmount"  DataFormatString="{0:f}"/>
    <asp:BoundField HeaderText="Paid Amount" DataField="PaidAmount"  DataFormatString="{0:f}"/>
     <asp:BoundField HeaderText="Balance Amount" DataField="Balance"  DataFormatString="{0:f}"/>
  <asp:BoundField HeaderText="No of Pending Days"  DataField="PendingDays" />
    
    
     
     

   <asp:TemplateField>
   <ItemTemplate>
   
   <asp:LinkButton ID="btnview" CommandName="view" CommandArgument='<%#Eval("billno") %>' runat="server"><asp:Image ID="imgview" runat="server" ImageUrl="~/images/info_button.png" /></asp:LinkButton>
   </ItemTemplate>
   </asp:TemplateField>  
   </Columns>
   
   <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   </asp:GridView>
   
                                </td>
                                <td>
                                <asp:GridView ID="gvSplitUp" runat="server" AutoGenerateColumns="false" CssClass="myGridStyle" >
                                <Columns>
                                <asp:BoundField HeaderText="Bill No" DataField="BillNo" SortExpression="BillNo" />
       
    <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" />
    <asp:BoundField HeaderText="Paid Date" DataField="ReceiptDate" SortExpression="BillNo" />
      <asp:BoundField HeaderText="Bill Amount" DataField="BillAmount"  DataFormatString="{0:f}"/>
    <asp:BoundField HeaderText="Paid Amount" DataField="PaidAmount"  DataFormatString="{0:f}"/>
    <asp:BoundField HeaderText="No of Pending Days"  DataField="PendingDays" />
                                </Columns><FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
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
