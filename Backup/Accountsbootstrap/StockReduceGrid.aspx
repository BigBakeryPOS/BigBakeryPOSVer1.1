<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockReduceGrid.aspx.cs" Inherits="Billing.Accountsbootstrap.StockReduceGrid" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head>

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Stock Reduce Grid </title>

   <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
        <link href="../Styles/style1.css" rel="stylesheet"/>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
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
<body style="">
             <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false" > </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
   <usc:Header ID="Header" runat="server" />
    <div class="row" style="">
                <div class="col-lg-12" style="">
                    <h1 class="page-header">Stock Reduce Details</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>


          <div class="row" style="">
                <div class="col-lg-12" style="">
                    <div class="panel panel-default" style="">
                        
                        <div class="panel-body" style="">
                            <div class="row" style="">
                                <div style="">
                                
                                    <form runat="server" id="form1" method="post">
                                   
                                    <asp:scriptmanager id="ScriptManager1" runat="server">
                                              </asp:scriptmanager>
                                    <div class="form-group"  align="center">
                                          
                                            <asp:DropDownList ID="ddlbillno" v CssClass="form-control" Visible="false" style="width:150px;" 
                                                runat="server">
                                            <%--<asp:ListItem Text="Bill No" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Customer Name" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Area" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="City" Value="4"></asp:ListItem>--%>

                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlVendor" CssClass="form-control" Visible="false" runat="server" style="width:273px;"></asp:DropDownList>
                                                 
                                                  

                                               
                                        <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search" Visible="false"  
                                                style="margin-top: 10px;"   /> 
                                        <asp:Button ID="btnrefresh" runat="server" class="btn btn-warning" Text="Reset"  Visible="false" 
                                                style="margin-top: 10px;"  /> 
                                        <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Add"  
                                                style="margin-top: 10px;"  PostBackUrl="~/Accountsbootstrap/productionstock.aspx" />  
                                                <asp:Button ID="Button1" runat="server" class="btn btn-warning" Text="Export to Excel"  
                                                style="margin-top: 10px;" onclick="btnexp_Click" />  
                                                 
                                        </div> 
                               

                               <div class="table-responsive" align="center">
                                        
                                <table class="table table-bordered table-striped" align="center">
                                <tr>
                                
                                <td style="">
                                <asp:GridView Caption="Current Production Stock" ID="gvPurchaseReqDetails" runat="server" AutoGenerateColumns="false" CssClass="mGrid" Width="50%">
                                <Columns>
                                <asp:BoundField  HeaderText="Category" DataField="Category" />
                                <asp:BoundField  HeaderText="Item Name" DataField="Definition" />
                                <asp:BoundField  HeaderText="Production Qty" DataField="Prod_Qty" />
                                <asp:BoundField  HeaderText="Units" DataField="units" />
                                  <asp:BoundField  HeaderText="Date" DataField="Proddate" />
                               
                                 </Columns>
                                  
  
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