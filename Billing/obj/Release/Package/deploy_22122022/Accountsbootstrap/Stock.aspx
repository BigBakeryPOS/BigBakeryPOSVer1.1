<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stock.aspx.cs" Inherits="Billing.Accountsbootstrap.Stock" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html>
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Stock Master</title>
    <!-- Bootstrap Core CSS -->
    <link href="../Styles/chosen.css" rel="Stylesheet" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .Hide
        {
            display: none;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= gvdaygrn.ClientID %>');
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
    <script type="text/javascript" language="javascript">
        function printGridNew() {
            var gridData = document.getElementById('<%= GridView1.ClientID %>');
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
<body style="">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    

                <form id="Form1" runat="server">
                <asp:ScriptManager ID="script" runat="server">
                </asp:ScriptManager>
                <asp:UpdatePanel ID="upanel" runat="server">
                    <ContentTemplate>
                            <div class="container-fluid">
	                        <div class="row">
                            <div class="col-lg-12">
                             <div class="col-lg-8">
                            <div class="row panel-custom1">
                                <div class="panel-header">
                                  <h1 class="page-header">Search Stock Details</h1>
	                            </div>
                                        <div class="panel-body">
                                            <div class="row">
                                                <div class="col-lg-4">
                                                    <asp:TextBox CssClass="form-control" ID="txttodate" runat="server" 
                                                        Text="--Select Date--"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator1"
                                                        ControlToValidate="txttodate" ErrorMessage="Please enter To Date!" Text="" Style="color: White" />
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txttodate"
                                                        Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                                                    </ajaxToolkit:CalendarExtender>
                                                </div>
                                                <div class="col-lg-2">
                                                    <asp:Button ID="btnsearch" runat="server" class="btn btn-info pos-btn1" Text="Search by Date"
                                                        OnClick="btnsearch_Click" />
                                               </div>
                                               <div class="col-lg-2">
                                                    <asp:Button ID="btnprint" runat="server" class="btn btn-secondary" Text="Print" OnClick="btnprint_Click" Width="100px" />
                                                </div>
                                                <div class="col-lg-4">
                                                    <asp:DropDownList ID="ddldaygrn" runat="server" class="form-control" 
                                                        OnSelectedIndexChanged="ddldaygrn_SelectedIndexChanged" AutoPostBack="true">
                                                    </asp:DropDownList>
                                                </div>
                                            <div class="col-lg-12">
                                            <div class="table-responsive panel-grid-left">
                                                <asp:GridView ID="gvdaygrn" cssClass="table table-striped pos-table" runat="server" Width="100%" AutoGenerateColumns="false" padding="0" spacing="0" border="0"
                                                    OnRowCommand="gvPurchaseEntry_RowCommand">
                                                    <%--<HeaderStyle BackColor="#990000" />--%>
                                                    <Columns>
                                                        <asp:BoundField HeaderText="id" DataField="id" Visible="false" />
                                                        <asp:BoundField HeaderText="GRN No." DataField="GRNNo" Visible="false" />
                                                        <asp:BoundField HeaderText="Today GRNNo" DataField="DayGRN" />
                                                        <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString="{0:MM/dd/yyyy}" />
                                                        <asp:BoundField HeaderText="GRN Time" DataField="GRNTime" />
                                                        <asp:BoundField HeaderText="GRN Qty" DataField="GRN_Qty" />
                                                        <asp:BoundField HeaderText="Name" DataField="Name" />
                                                        <asp:BoundField HeaderText="Category" DataField="Category" />
                                                        <asp:BoundField HeaderText="Item" DataField="Definition" />
                                                        <asp:TemplateField HeaderText="Print" Visible="false">
                                                            <ItemTemplate>
                                                                <asp:LinkButton ID="butPrint" runat="server" CommandArgument='<%#Eval("id") %>' CommandName="Print">
                                                                    <asp:Image ID="imgprint" runat="server" ImageAlign="Middle" ImageUrl="~/images/print (1).png" width="55px" /></asp:LinkButton>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <%--<FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                                <asp:GridView ID="GridView1" cssClass="table table-striped pos-table" runat="server" Width="100%" AutoGenerateColumns="false" padding="0" spacing="0" border="0"
                                                    Visible="true">
                                                    <%--<HeaderStyle BackColor="#990000" />--%>
                                                    <Columns>
                                                        <asp:BoundField HeaderText="GRN No." DataField="GRNNo" Visible="false" />
                                                        <asp:BoundField HeaderText="Today GRNNo" DataField="DayGRN" />
                                                        <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString="{0:MM/dd/yyyy}" />
                                                        <asp:BoundField HeaderText="GRN Time" DataField="GRNTime" />
                                                        <asp:BoundField HeaderText="GRN Qty" DataField="GRN_Qty" />
                                                        <asp:BoundField HeaderText="Name" DataField="Name" />
                                                        <asp:BoundField HeaderText="Category" DataField="Category" />
                                                        <asp:BoundField HeaderText="Item" DataField="Definition" />
                                                    </Columns>
                                                    <%--<FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                    <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                                </asp:GridView>
                                                </div>
                                            </div>
                                        </div>
                                        </div>
                               </div>     
                               </div>
                                <div class="col-lg-4">
                                    <div class="panel panel-custom1">
                                        <div class="panel-header">
				                            <h1 class="page-header">Add Stock
                                             <span class="pull-right">
                                          <asp:LinkButton ID="Button" runat="server"  Text="Add Bulk Entry"  PostBackUrl="~/Accountsbootstrap/BulkStockEntry.aspx">
                                                    <button type="button" class="btn btn-primary btn-md pos-btn1 ">
				                                <span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD BULK ENTRY
			                                </button>
                                            </asp:LinkButton>
                                                </span>
                                            </h1>
		                            </div>
                                       
                                        <div class="panel-body panel-form-right">
                                            <div id="admin" runat="server" visible="false" class="form-group">
                                                <label>
                                                    Store</label>
                                                <asp:DropDownList ID="ddlstore" AutoPostBack="true" runat="server" class="form-control"
                                                    Width="150px">
                                                   
                                                </asp:DropDownList>
                                            </div>
                                            <div class="list-group">
                                             <label>
                                                    GRN No</label>
                                                <asp:TextBox ID="txtgrnno" runat="server" Enabled="false" class="form-control"></asp:TextBox>
                                            <br />
                                                <label>
                                                    Employee Name</label>
                                                <asp:TextBox ID="txtname" runat="server" class="form-control"></asp:TextBox>
                                            <br />
                                                <label>
                                                    Category</label>
                                                <asp:DropDownList ID="ddlcategory" AutoPostBack="true" runat="server" class="form-control"
                                                    OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                                                </asp:DropDownList>
                                           <br />
                                                <label>
                                                    Item</label>
                                                <asp:DropDownList ID="ddlSubCategory" runat="server" class="form-control" OnSelectedIndexChanged="ddlSubCategory_SelectedIndexChanged"
                                                    AutoPostBack="true">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblsuberror" runat="server" Style="color: Red"></asp:Label>
                                            <br />
                                            <label>
                                                Quantity</label>
                                            
                                                <asp:TextBox class="form-control" ID="txtQty" MaxLength="10" runat="server"></asp:TextBox>
                                            </div>
                                            <div id="AdminPurchaseRate" runat="server" class="Hide">
                                                <label>
                                                    Purchase unit Price</label>
                                                <asp:TextBox class="form-control" Enabled="false" ID="txtPurchasePrice" MaxLength="10"
                                                    runat="server">0</asp:TextBox>
                                            </div>
                                            <div class="Hide">
                                                <label>
                                                    Customer Unit Price</label>
                                                <asp:TextBox CssClass="form-control" ID="txtCustUnitPrice" runat="server">0</asp:TextBox>
                                            </div>
                                            <div class="Hide">
                                                <label>
                                                    Dealer Unit Price</label>
                                                <asp:TextBox CssClass="form-control" ID="txtDealerUnitPrice" runat="server">0</asp:TextBox>
                                            </div>
                                            <div class="Hide">
                                                <label>
                                                    Press Unit Price</label>
                                                <asp:TextBox CssClass="form-control" ID="txtPressUnitPrice" runat="server">0</asp:TextBox>
                                            </div>
                                            <div class="Hide">
                                                <label>
                                                    Minimum Quantity for Stock alert</label>
                                                <asp:TextBox CssClass="form-control" ID="txtminimum" runat="server">0</asp:TextBox>
                                            </div>
                                            <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                                            <asp:Button ID="btnAdd" runat="server" class="btn btn-lg btn-primary pos-btn1" Text="Save" OnClick="btnAdd_Click"  Width="150px"/>
                                            <asp:Button ID="btnExit" runat="server" class="btn btn-lg btn-link" Text="Clear" OnClick="btnExit_Click" />
                                        </div>
                                    </div>
                                </div>
                               
                            </div>
                            </div>
                            </div> 
                    </ContentTemplate>
                </asp:UpdatePanel>
                </form>
   
</body>
</html>
