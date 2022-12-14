<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchasePaymentGrid.aspx.cs" Inherits="Billing.Accountsbootstrap.PurchasePaymentGrid" %>
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
    <title>Purchase Payment Grid</title>

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
                    <h1 class="page-header">Purchase Payment Grid</h1>
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
                                        <label>Select Vendor</label>
                                        <asp:DropDownList ID="ddlVendor" runat="server" CssClass="form-control" 
                                                AutoPostBack="true" 
                                                onselectedindexchanged="ddlVendor_SelectedIndexChanged1" ></asp:DropDownList>
                                        </div>
          <div class="form-group">
                                        <label>Filter By</label>
                                        <asp:DropDownList ID="ddlPaid" runat="server" CssClass="form-control" 
                                                AutoPostBack="true" onselectedindexchanged="ddlPaid_SelectedIndexChanged" >
                                                 <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                                 <asp:ListItem Text="Completed Bills" Value="1"></asp:ListItem>
                                                 <asp:ListItem Text="Pending Bills" Value="2"></asp:ListItem>
                                                 
                                                 </asp:DropDownList>
                                        </div>

                               <div class="table-responsive">
                                                                                 
                                <table class="table table-bordered table-striped">
                                <tr>
                                <td>
                                <asp:GridView ID="gvPurchasePayment" Visible="false" runat="server" 
                                        CssClass="myGridStyle" AutoGenerateColumns="false" 
                                        EmptyDataText="No Datas Found" onrowcommand="gvPurchasePayment_RowCommand">
                                
                                <Columns>
                                <asp:BoundField HeaderText="VendorID" DataField="VendorID" Visible="false" />
                                <asp:BoundField HeaderText="Bill No" DataField="Bill_NO" />
                                <asp:BoundField HeaderText="Bill Date" DataField="Bill_date" />
                                <asp:BoundField HeaderText="Vendor Name" DataField="CustomerName" />
                                <asp:BoundField HeaderText="Purchase Amount" DataField="TotalAmount" DataFormatString='{0:f}' />
                                <asp:BoundField HeaderText="Pending Amount" DataField="Balance"  DataFormatString='{0:f}' />
                            <asp:TemplateField HeaderText="Pay Amount">
                            <ItemTemplate >
                            <asp:LinkButton ID="btnPay"   CommandArgument='<%#Eval("Bill_NO") %>' CommandName="pay" runat="server" >Pay </asp:LinkButton>
                            </ItemTemplate>
                            </asp:TemplateField>
                                </Columns>
                                               <HeaderStyle BackColor="#3366FF" />
                               
    <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                </asp:GridView>
                                </td>
                                </tr>
                                
                                </table>  
                                             
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
