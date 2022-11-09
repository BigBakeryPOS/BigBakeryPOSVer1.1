<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseReport.aspx.cs" Inherits="Billing.Accountsbootstrap.PurchaseReport" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Purchase Report </title>

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
                <div class="col-lg-12" style="padding-top:70px">
                    <h1 class="page-header">Purchase Report</h1>
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
                                    <div class="form-group">
                                            <label>Filter By</label>
                                            <asp:DropDownList ID="ddlbillno" CssClass="form-control" Visible="false" style="width:150px;" 
                                                runat="server">
                                            <%--<asp:ListItem Text="Bill No" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Customer Name" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Area" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="City" Value="4"></asp:ListItem>--%>

                                                </asp:DropDownList>
                                                <asp:DropDownList ID="ddlVendor" CssClass="form-control" runat="server" style="width:273px;"></asp:DropDownList>
                                                 
                                                  

                                               
                                        <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search"  
                                                style="margin-top: 10px;" onclick="btnsearch_Click"  /> 
                                        <asp:Button ID="btnrefresh" runat="server" class="btn btn-warning" Text="Reset"  
                                                style="margin-top: 10px;" onclick="btnrefresh_Click"  /> 
                                          
                                        </div> 
                               

                               <div class="table-responsive">
                                        
                                <table class="table table-bordered table-striped">
                                <tr>
                                <td>

                                
                                <asp:GridView ID="gvPurchaseEntry" runat="server" AllowPaging="true" PageSize="50"  
                                        AutoGenerateColumns="false" CssClass="myGridStyle" onrowcommand="gvPurchaseEntry_RowCommand"  
                                          >
                                 <HeaderStyle BackColor="#3366FF" />
                                <PagerSettings  Mode="Numeric"   />
    <Columns>
    <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
    
      
    <asp:BoundField HeaderText="Vendor Name" DataField="CustomerName" />
    <asp:BoundField HeaderText="Purchase Amount" DataField="TotalAmount" DataFormatString="{0:f}" />
   

    <asp:TemplateField>
    <ItemTemplate>
    <asp:LinkButton runat="server" ID="brnview" CommandName="view" CommandArgument='<%#Eval("CustomerName") %>'><asp:Image ID="img" runat="server" ImageUrl="~/images/info_button.png" /></asp:LinkButton>
   
    </ItemTemplate>
    </asp:TemplateField>
   </Columns>
     <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   </asp:GridView>
                                </td>
                                <td>
                                <asp:GridView ID="gvPurchaseDetails"  runat="server" CssClass="myGridStyle" AutoGenerateColumns="false">
                                 <HeaderStyle BackColor="#778899" />

                                 <Columns>
                                 <asp:BoundField HeaderText="Name"  DataField="CustomerName"   />
                                 <asp:BoundField HeaderText="Bill No" DataField="Bill_NO"    />
                                 <asp:BoundField HeaderText="Bill Date" DataField="Bill_date"   />
                                 <asp:BoundField HeaderText="Category"  DataField="Category"   />
                                 <asp:BoundField HeaderText="Description" DataField="Definition"   />
                                 <asp:BoundField HeaderText="Purchase Qty" DataField="Qty"   />
                                 <asp:BoundField HeaderText="Purchase Rate" DataField="Rate"   />
                                 <asp:BoundField HeaderText="Purchase Amount" DataField="TotalAmount" />
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
