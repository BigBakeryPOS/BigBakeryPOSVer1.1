<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OutStandingPendingReport.aspx.cs" Inherits="Billing.Accountsbootstrap.OutStandingPendingReport" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head>

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Outstanding Pending Payment</title>

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
   <form runat="server" id="form1" method="post">
    <div class="row">
                <div class="col-lg-12">
                    <h1 class="page-header">Outstanding Payment</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>


          <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    
                                    
                                    <div class="form-group">
                                            <label>Select Customer</label>
                              <!--<asp:DropDownList ID="ddcustomerName"  runat="server" style="width:273px; margin-left:46px; margin-top:-34px"></asp:DropDownList>>-->
                              <asp:DropDownList ID="ddcustomer" CssClass="form-control" runat="server" Width="150px"  Enabled="true" AutoPostBack="true"></asp:DropDownList>
                                                 
                                                  

                                              <div>                        
                                              
                                                              <asp:Button ID="btnsearch" OnClick="search" class="btn btn-success"  runat="server" Text="Search"  style="margin-top: -54px;margin-left: 180px;"  />
                                                              <asp:Button ID="btnReset" OnClick="btnReset_Click"  class="btn btn-success"  runat="server" Text="Reset"  style="margin-top: -54px;margin-left: 10px;"  />
                                              </div> 
 
                                        
                                        </div> 
                               
                               
                               <div class="table-responsive">
                                        
                                <table class="table table-bordered table-striped">
                                <tr>
                                <td>
                                <asp:GridView ID="gvpending"   runat="server" AllowPaging="true" PageSize="10"  
                                        CssClass="myGridStyle"  AutoGenerateColumns="false"  AllowSorting="true"
                                        onpageindexchanging="gvpending_PageIndexChanging" 
                                        onsorting="gvpending_Sorting" onrowdatabound="gvpending_RowDataBound" 
                                        onrowcommand="gvpending_RowCommand"  >
                                   <HeaderStyle BackColor="#3366FF" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="Next" PreviousPageText="Previous" />
    <Columns>
    <asp:TemplateField HeaderText="SNo.">
     <itemtemplate>
          <%#Container.DataItemIndex + 1 %>                                                    
     </itemtemplate>
</asp:TemplateField>
    <asp:BoundField HeaderText="Contact Name" DataField="CustomerName" SortExpression="CustomerName" />
    <asp:BoundField HeaderText="Bill No" DataField="BillNo" />
    <asp:BoundField HeaderText="Bill Amount" DataField="BillAmount" DataFormatString="{0:N}" />
    <asp:BoundField HeaderText="Paid Amount" DataField="PaidAmount" DataFormatString="{0:N}" />
    <asp:BoundField HeaderText="Pending Amount" DataField="Balance" DataFormatString="{0:N}" />
   
       
         <asp:TemplateField HeaderText="View" Visible="false">
     <ItemTemplate>
     <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("BillNo") %>' CommandName="view"><asp:Image ID="img" runat="server" ImageUrl="~/images/info_button.png" /></asp:LinkButton>
      
     </ItemTemplate>
    
     
     
     </asp:TemplateField>
   </Columns>
   <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   </asp:GridView>
                                </td>
                                <td>
                                <asp:GridView ID="gvDetails" runat="server" AutoGenerateColumns="false" CssClass="myGridStyle">
                                   <HeaderStyle BackColor="#3366FF" />
                                <Columns>
                                <asp:BoundField HeaderText="Contact Name" DataField="CustomerName" />
                                  <asp:BoundField HeaderText="Bill No" DataField="BillNo" />
                                    <asp:BoundField HeaderText="Bill Date" DataField="BillDate" />
                                      <asp:BoundField HeaderText="Bill Amount" DataField="BillAmount" />
                                        <asp:BoundField HeaderText="Padi Amount" DataField="Amount" />
                                          <asp:BoundField HeaderText="Balance Amount" DataField="Balance" />
                                            <asp:BoundField HeaderText="Receipt No" DataField="ReceiptNo" />
                                            <asp:BoundField HeaderText="Receipt Date" DataField="ReceiptDate" />
                                            <asp:BoundField HeaderText="No of Days Pending" DataField="PendingDays" />
                                </Columns>
                                 <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                </asp:GridView>
                                </td>
                                </tr>
                                </table>
                                </div>
                                <div class="form-group">
                                <label id="lbltotal" runat="server" >Total</label>
                                <label id="lblBillAmt" runat="server"  visible="false" style="margin-left:275px" >BillAmount</label>
                                 <label id="lblPaid" runat="server" visible="false"  style="margin-left:20px">Paid</label>
                                  <label id="lblPending" runat="server" visible="false" style="margin-left:75px" > Pending</label>
                                </div>

                               
                                     <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Export to Excel" 
                                        onclick="btnadd_Click"  />  
                                   
                                    
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
