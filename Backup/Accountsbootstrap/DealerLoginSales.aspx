<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DealerLoginSales.aspx.cs" Inherits="Billing.Accountsbootstrap.DealerLoginSales" %>
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
    <title>Dealer Sales</title>

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
                    <h1 class="page-header">Dealer Sales</h1>
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
                                <label>Dealer Sales </label>
                                </td>
                                </tr>
                                <tr>
                                <td>
                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                <asp:GridView ID="gvDealersales"   runat="server" AllowPaging="true" PageSize="50" 
                                        CssClass="myGridStyle"                                        AutoGenerateColumns="false" 
                                        EmptyDataText="No data found!" ShowHeaderWhenEmpty="True">

                                        <Columns>
                                      
                                        <asp:BoundField  HeaderText="Dealer Name" DataField="CustomerName" />
                                        <asp:BoundField  HeaderText="Bill No" DataField="BillNo" />
                                        <asp:BoundField  HeaderText="Bill Date" DataField="BillDate" />
                                        <asp:BoundField  HeaderText="Net-Amount" DataField="NetAmount" DataFormatString='{0:f}' />
                                        
                                        </Columns>
                                <HeaderStyle BackColor="#3366FF" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="Next" PreviousPageText="Previous" />
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
            <i>You are viewing page
                <%=gvDealersales.PageIndex + 1%>
                of
                <%=gvDealersales.PageCount%>
            </i>
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
