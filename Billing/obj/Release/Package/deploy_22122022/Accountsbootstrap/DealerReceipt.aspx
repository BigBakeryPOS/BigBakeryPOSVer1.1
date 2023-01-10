<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DealerReceipt.aspx.cs" Inherits="Billing.Accountsbootstrap.DealerReceipt" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head id="Head1" runat="server">

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <title>Dealer Receipt and Pending</title>

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
                    <h1 class="page-header">Dealer Receipt and Pending</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>


          <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-6">
                                   
                                   
                           
                                     
                                 
                                       
                                          </div>
                                          
                                             <div class="col-lg-12">

      
                               <div class="table-responsive">
                                                                                 
                                <table class="table table-bordered table-striped">
                                                               
                                <tr>
                                <td>
                                <label>Dealer Receipt and Outstanding History</label>
                                </td>
                                </tr>
                             <tr>
                                <td>
                                <asp:GridView ID="gvReceiptReport" runat="server" CssClass="myGridStyle" 
                                        AutoGenerateColumns="false" onrowcommand="gvReceiptReport_RowCommand" >
                                
                                <Columns>
                                <asp:BoundField HeaderText ="Branch" DataField="Branch" />
                                <asp:BoundField HeaderText ="Bill No" DataField="Billno" />
                                <asp:BoundField HeaderText ="Receipt Date" DataField="ReceiptDate" />
                                <asp:BoundField HeaderText ="Name" DataField="CustomerName" />
                                <asp:BoundField HeaderText ="Bill Amount" DataField="BillAmount" DataFormatString='{0:f}' />
                                <asp:BoundField HeaderText ="Paid Amoount" DataField="PaidAmount"  DataFormatString='{0:f}'/>
                                <asp:BoundField HeaderText ="Balance" DataField="Balance" DataFormatString='{0:f}' />
                                <asp:TemplateField>
                                <ItemTemplate>
                                
                                <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("Billno") %>' CommandName="view"><asp:Image ID="img" runat="server" ImageUrl="~/images/info_button.png" /></asp:LinkButton></ItemTemplate>
                                </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                </asp:GridView>
                                </td>
                                <td>
                                <asp:GridView ID="gvReceipt"   runat="server" AllowPaging="true" PageSize="10"  
                                         AutoGenerateColumns="false" 
                                        CssClass="myGridStyle" AllowSorting="true"
                                         >
                                  <HeaderStyle BackColor="#3366FF" />
                                <PagerSettings FirstPageText="1"  Mode="Numeric" />
    <Columns>
    <%--<asp:BoundField HeaderText="Receipt ID" DataField="ReceiptID" />--%>
      <asp:BoundField HeaderText="Receipt No" DataField="ReceiptNo" />
        <asp:BoundField HeaderText="Receipt Date" DataField="ReceiptDate" SortExpression="ReceiptDate" />
            <asp:BoundField HeaderText="Bill No" DataField="BillNo" />
    <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" SortExpression="CustomerName" />
     
      <asp:BoundField HeaderText="Bill Amount" DataField="BillAmount" DataFormatString="{0:f}" />    
    <asp:BoundField HeaderText="Amount Paid" DataField="Amount"  DataFormatString="{0:f}"/>
    <asp:BoundField HeaderText="Balance" DataField="Balance" DataFormatString="{0:f}" Visible="false" />
        <asp:BoundField HeaderText="Payment By" DataField="Payment_ID" />

     
    
    <%--<asp:BoundField HeaderText="Amount" DataField="Amount" />--%>
     <asp:TemplateField HeaderText="GetDetails" Visible ="false">
     <ItemTemplate>
     <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("ReceiptID") %>' CommandName="edit"><asp:Image ID="img" runat="server" ImageUrl="~/images/info_button.png" /></asp:LinkButton>
      
     </ItemTemplate>
    
     
     
     </asp:TemplateField>
     
   </Columns>
   <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   </asp:GridView>
                                </td>
                                </tr>
                                </table>
                             
                                </div>
                                  <div style="color: Green; font-weight: bold" class="form-group">
                                           <label id="lblNoRecords" style=" color:Red" runat="server"></label>
            <br />
            
        </div> 
                                <asp:Button ID="btnexcel" runat="server" CssClass="btn btn-danger" Text="Export" 
                                          />


                                   
                                   
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
