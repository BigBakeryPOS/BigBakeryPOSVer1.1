<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterStoreGrid.aspx.cs" Inherits="Billing.Accountsbootstrap.InterStoreGrid" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Inter Store Stock Request Entry Grid </title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
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
    <style type="text/css">
         blink, .blink {
            animation: blinker 1s linear infinite;
        }

       @keyframes blinker {  
            50% { opacity: 0; }
       }
      </style>
    <script type="text/javascript" language="javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= gvPurchaseReqDetails.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');
            //prtWindow.document.write('<html><head></head>');
            //prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            //prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>
</head>
<body>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
    <%-- <div class="row" style="">
                <div class="col-lg-12" style="padding-top:10px">
                    <h1 class="page-header">Daily Stock Request Details</h1>
                </div>
                <!-- /.col-lg-12 -->
            </div>--%>
            <form runat="server" id="form1">
             <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Inter Store Stock Request Details
          <span class="pull-right">
          <asp:LinkButton ID="Button1" runat="server" onclick="btnadd_Click">
         <button type="button" class="btn btn-primary btn-md pos-btn1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD
		</button>
       </asp:LinkButton>
           </span>
         </h1>
	    </div>

                <div class="panel-body">
                    
                            
                             <asp:UpdatePanel ID="panel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                          <div class="row">  
                                <div class="col-lg-3">
                                      <%--  <blink> <label  style="color:Green; font-size:12px">Screen Show Detail as Per Your daily Stock Request</label></blink>--%>
                                        <label>
                                            Filter By</label>
                                        <asp:DropDownList ID="ddlbillno" CssClass="form-control" Visible="false" 
                                            runat="server">
                                            <%--<asp:ListItem Text="Bill No" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Customer Name" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Area" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="City" Value="4"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                        <asp:DropDownList ID="ddlVendor" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                    </div>
                            
                                <div class="col-lg-9">
                                <br />
                                        <asp:Button ID="btnsearch" runat="server" class="btn btn-info pos-btn1" Text="Search" />
                                        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnrefresh" runat="server" class="btn btn-secondary" Text="Reset" />
                              </div>   
                            </div>
                           <div class="row">  
                            <div class="col-lg-6">
                            <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="gvPurchaseEntry" runat="server" AllowPaging="true" PageSize="10" CssClass="table table-striped pos-table" 
                                    Width="100%" AutoGenerateColumns="false"  OnRowCommand="gvPurchaseEntry_RowCommand" padding="0" spacing="0" border="0"
                                    OnRowDataBound="gvPurchaseEntry_RowDataBound" OnPageIndexChanging="gvPurchaseEntry_PageIndexChanging">
                                    <%--<HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" />--%> 
                                    <%--<HeaderStyle BackColor="Beige" />--%>
                                    <%--<PagerSettings Mode="Numeric" />--%>
                                    <PagerStyle cssclass="pos-paging" />
                                    <Columns>
                                        <%--<asp:BoundField HeaderText="Customer ID" DataField="CustomerID" />--%>
                                        <asp:BoundField HeaderText="From Branch" DataField="FromBranchCode" />
                                        <asp:BoundField HeaderText="RequestNO" DataField="RequestNO" />
                                        <asp:BoundField HeaderText="Entry Date/Time" DataField="entrytime" />
                                        <asp:BoundField HeaderText="Request Date" DataField="RequestDate" DataFormatString='{0:d}' />
                                        <asp:BoundField HeaderText="Entry Name" DataField="Production_To" />
                                        <asp:BoundField HeaderText="Total Qty" DataField="TotalQty" Visible="false" />
                                        <asp:BoundField HeaderText="Status" DataField="Status" />
                                        <asp:BoundField HeaderText="Request Entry Time" DataField="RequestEntryTime" />
                                        <asp:BoundField HeaderText="To Branch" DataField="ToBranchCode" />
                                        <asp:TemplateField HeaderText="cancel" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("RequestNO")  %>'
                                                    CommandName="edit">
                                                    <asp:Image ID="img" runat="server" ImageUrl="~/images/info_button.png"  Visible="false" />
                                                    <button type="button" class="btn btn-warning btn-md">
						                                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
					                                </button>
                                                    </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Delete">
     <ItemTemplate>
           <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("SalesID") %>' CommandName="delete" OnClientClick="alertMessage()"><asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/delete.png" /></asp:LinkButton>
   </ItemTemplate>
    
     
     
     </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="View">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("RequestNO") + "," + Eval("ToBranchCode") + "," + Eval("RequestDate")+ "," + Eval("RequestEntryTime") %>'
                                                    CommandName="View">
                                                    <asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png" Visible="false" />
                                                    <button type="button" class="btn btn-primary btn-md">
						                                <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
					                                </button>
                                                    </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Print">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="butPrint" runat="server" CommandArgument='<%#Eval("RequestNO") + "," + Eval("ToBranchCode") + "," + Eval("RequestDate")+ "," + Eval("RequestEntryTime") %>'
                                                    CommandName="Print">
                                                    <asp:Image ID="imgprint" runat="server" ImageAlign="Middle" ImageUrl="~/images/print (1).png" width="55px" Visible="false" />
                                                    <button type="button" class="btn btn-default btn-md">
						                            <span class="glyphicon glyphicon-print" aria-hidden="true"></span>
					                            </button>
                                                </asp:LinkButton>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                   <%-- <FooterStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />--%>
                                </asp:GridView>
                                </div>
                                </div>
                                <div class="col-lg-6">
                                <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="gvPurchaseReqDetails"  cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                    runat="server" AutoGenerateColumns="false" Width="100%" >
                                  <%--  <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> --%>
                                    <Columns>
                                        <asp:BoundField HeaderText="Category" DataField="IngreCategory" />
                                        <asp:BoundField HeaderText="Item Name" DataField="IngredientName" />
                                        <asp:BoundField HeaderText="Order Qty" DataField="Order_Qty" />
                                        <asp:BoundField HeaderText="Received Qty" DataField="Received_Qty" />
                                    </Columns>
                                   <%-- <FooterStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />
                                    <HeaderStyle BackColor="#990000" ForeColor="Black" HorizontalAlign="Center" />--%>
                                </asp:GridView>
                                </div>
                                </div>
                                </div>
                          
                            </ContentTemplate>
                        </asp:UpdatePanel>
                            
                   
                </div>

    </div>
    </div>
    </div>
    </div>
    </form>
</body>
</html>

