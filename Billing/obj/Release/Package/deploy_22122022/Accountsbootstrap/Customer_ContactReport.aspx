<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Customer_ContactReport.aspx.cs" Inherits="Billing.Customer_ContactReport" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="en">

<head>
<style type="text/css">
		a img{border: none;}
		ol li{list-style: decimal outside;}
		div#container{width: 780px;margin: 0 auto;padding: 1em 0;}
		div.side-by-side{width: 100%;margin-bottom: 1em;}
		div.side-by-side > div{float: left;width: 50%;}
		div.side-by-side > div > em{margin-bottom: 10px;display: block;}
		.clearfix:after{content: "\0020";display: block;height: 0;clear: both;overflow: hidden;visibility: hidden;}
		
	</style>
	
    <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Customer Grid Master - bootsrap</title>
    
   <!-- Bootstrap Core CSS -->
   <link rel="stylesheet" href="../Styles/chosen.css" />
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
   <form runat="server" id="form1">
   <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
   <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Customer Contact Report</h1>
	    </div>
              
         
                        <div class="panel-body">
                      
            <%--<asp:DropDownList ID="ddsrchby" Width="150px" CssClass="form-control" runat="server">
           
            </asp:DropDownList>--%>
                   <div class="row">
                <div class="col-lg-3">
              <div class="form-group has-feedback">
            <asp:TextBox ID="txtser" Visible="true" placeholder="Search Name / Mobile No." runat="server" CssClass="form-control" ></asp:TextBox>
             <span class="glyphicon glyphicon-search form-control-feedback"></span>
             </div>
             </div>
            <div class="col-lg-9 text-left">
            <asp:Button ID="btnsearch" runat="server" CssClass="btn btn-success pos-btn1"  Text="Search" Width="100px" 
                    onclick="btnsearch_Click" />
                                &nbsp; &nbsp; &nbsp;<asp:Button ID="btn_Reset" runat="server" Width="150px" 
                    class="btn btn-secondary"  Text="Reset" onclick="btn_Reset_Click" 
                     />
                      &nbsp; &nbsp; &nbsp; <asp:Button ID="btnexcel" runat="server" Text="Export To Excel" 
                                        CssClass="btn btn-success" onclick="btnexcel_Click" />
                                 
            </div>
              
         <div class="col-lg-12">
          <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="gvcust"  ShowHeaderWhenEmpty="true" EmptyDataText="No Records Found"  runat="server" AllowPaging="true" PageSize="10" 
                                        AllowSorting="true" CssClass="table table-striped pos-table" OnPageIndexChanging="Page_Change" padding="0" spacing="0" border="0"
                                        AutoGenerateColumns="false" onrowcommand="gvcust_RowCommand" 
                                        onsorting="gvcust_Sorting">
                                        <PagerStyle cssclass="pos-paging" />
                                <%-- <HeaderStyle BackColor="#3366FF" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast" NextPageText="Next" PreviousPageText="Previous" />--%>
                            <Columns>
                            <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
                            <asp:BoundField HeaderText="Customer Name" DataField="CustomerName"   />
                            <asp:BoundField HeaderText="Mobile No" DataField="MobileNo" />
                            <asp:BoundField HeaderText="Area" DataField="Area" />
                            <asp:BoundField HeaderText="Email" DataField="Email" />
                             <asp:TemplateField HeaderText="View Detail" ItemStyle-Width="150px">
                             <ItemTemplate>
                             <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("CustomerID") %>' CommandName="edit">
                             <asp:Image ID="img" runat="server" ImageUrl="~/images/info_button.png" visible="false"/>
                             <button type="button" class="btn btn-primary btn-md">
						                            <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
					                            </button>
                                                </asp:LinkButton>
      
                             </ItemTemplate>
    
     
     
                             </asp:TemplateField>
   
                           </Columns><%--<FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                           <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                           </asp:GridView>
                               
                                </div>
                                </div>
                                    
                                </div>
                                
                                <!-- /.col-lg-6 (nested) -->
                            </div>
                            <!-- /.row (nested) -->
                        </div>
                     
            </div>
            </div>
            </div>
            </div>
<script src="../Scripts/jquery.min.js" type="text/javascript"></script>
		<script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
		<script type="text/javascript">		    $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
</form>
</body>

</html>
