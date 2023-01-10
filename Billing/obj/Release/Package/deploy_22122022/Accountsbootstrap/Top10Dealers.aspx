<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Top10Dealers.aspx.cs" Inherits="Billing.Accountsbootstrap.Top10Dealers" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>

    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Top 10 Dealers </title>

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
                    <h1 class="page-header">Top 10 REVIEWS</h1>
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
                                            <label>Search By</label>
                                         

                                             
                                                <asp:DropDownList ID="ddlBranch" CssClass="form-control" runat="server" style="width:273px;">
                                                <asp:ListItem Text="Select Branch" Value="0"></asp:ListItem>
                                                <asp:ListItem Text="Branch 1" Value="co1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Branch 2" Value="co2"></asp:ListItem>
                                                <asp:ListItem Text="Branch 3" Value="co3"></asp:ListItem>
                                                </asp:DropDownList>
                                                <label style="color:Red" id="lblError" runat="server"></label><br />
                                                 
                                                  

                                               
                                        <asp:Button ID="btnsearch" runat="server" class="btn btn-success" Text="Search"  
                                                style="margin-top: 10px;" onclick="btnsearch_Click"   /> 
                                        <asp:Button ID="btnrefresh" runat="server" class="btn btn-warning" Text="Reset"  
                                                style="margin-top: 10px;" onclick="btnrefresh_Click"   /> 
                                          
                                        </div> 
                               
                               <table width="100%">
                                <tr >
                                
                                
                                  
                                <td  class="col-lg-4" align="center">
                                    <label>Top 10 Dealers</label>

                                
                                <asp:GridView ID="gvDealer" EmptyDataText="No data found!"  Width="400px" ShowHeaderWhenEmpty="True" runat="server"  AllowPaging="true" PageSize="5"  
                                        AutoGenerateColumns="false" CssClass="myGridStyle" 
                                          >
                                 <HeaderStyle BackColor="#3366FF" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NextPreviousFirstLast" NextPageText="Next" PreviousPageText="Previous" />
    <Columns>
    <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
    <asp:BoundField HeaderText="Dealer Name" DataField="CustomerName" />
     <asp:BoundField HeaderText="MobileNo" DataField="MobileNo" />
     <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:f}" />
    
   </Columns>
     <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   </asp:GridView>
                                </td>
                                
                                 
                                
                                
                                </tr></table>



                                     
                                   
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
