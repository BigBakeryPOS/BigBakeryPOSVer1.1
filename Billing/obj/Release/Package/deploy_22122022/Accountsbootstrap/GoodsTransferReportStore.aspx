<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GoodsTransferReportStore.aspx.cs" Inherits="Billing.Accountsbootstrap.GoodsTransferReportStore" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Goods Transfer Store Grid </title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <link href="../Styles/chosen.css" rel="Stylesheet" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
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
            alert('Your page is Redirected to Transfer page!');
        }
    </script>
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= gvTransfer.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
            'left=100,top=100,width=100,height=100');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>
</head>
<body style="">
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
      <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Goods Transfer Store Details</h1>
	    </div>
                <div class="panel-body">

                            <form runat="server" id="form1" method="post">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                           <div class="row">
                   
                               <%-- <label>
                                    Filter By</label>--%>
                                <asp:DropDownList ID="ddlBranch" CssClass="form-control"  runat="server" Visible="false">
                                    <%--<asp:ListItem Text="Bill No" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Customer Name" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Area" Value="3"></asp:ListItem>
                                            <asp:ListItem Text="City" Value="4"></asp:ListItem>--%>
                                </asp:DropDownList>
                                 <div class="col-lg-3">
                                    <label>
                                        Group</label>
                                    <asp:DropDownList ID="ddlcategory" AutoPostBack="true" runat="server" class="form-control"
                                       OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                               
                            <div class="col-lg-3">
                                <label>
                                    From Date</label>
                                <asp:TextBox ID="txtDate" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtDate" Animated="true"
                                    runat="server" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                            </div>
                            <div class="col-lg-3">
                                <label>
                                    To Date</label>
                                <asp:TextBox ID="txtToDate" runat="server" class="form-control"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txtToDate"
                                    runat="server" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                            </div>
                             <div class="col-lg-3">
                             <br />
                                <asp:Button ID="btnsearch" runat="server" class="btn btn-primary pos-btn1" Text="Search" 
                                    OnClick="btnsearch_Click" />
                               &nbsp;&nbsp;&nbsp; <asp:Button ID="btnrefresh" runat="server" class="btn btn-secondary" Text="Reset"  />
                                &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="btnPrint" runat="server"  onclick="btnPrint_Click">
                                <asp:Image ID="imgprint" runat="server" ImageUrl="~/images/print (1).png"  Width="50px" Height="50px" Visible="false"/>
                                <button type="button" class="btn btn-default btn-md">
						           <span class="glyphicon glyphicon-print" aria-hidden="true"></span>
					            </button>
                                </asp:LinkButton>
                            </div>
                            </div>
                            <br />
                                            <label>
                                                    Goods Transfer/Damage/Missing Details Report
                                            </label>
                                            <div class="table-responsive panel-grid-left">
                                            <asp:GridView ID="gvTransfer" runat="server" EmptyDataText="No Record Found" AutoGenerateColumns="false"
                                                cssClass="table table-striped pos-table"  padding="0" spacing="0" border="0" OnRowCommand="gvTransfer_RowCommand">
                                                <Columns>
                                                    <asp:BoundField HeaderText="DC No" DataField="DC_NO" />
                                                    <asp:BoundField HeaderText="DC_Date" DataField="DC_Date"  DataFormatString="{0:dd/MMM/yyyy}" />
                                                    <asp:BoundField HeaderText="Transferd To" DataField="branchcode" />
                                                    <asp:BoundField HeaderText="Branch Req.No" DataField="BranchReqNo" />
                                                    <asp:BoundField HeaderText="Category" DataField="category" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="Item" />
                                                    <asp:BoundField HeaderText="Requested Qty" DataField="OrderQty" />
                                                    <asp:BoundField HeaderText="Transfer Qty" DataField="SentQty" />
                                                    <asp:BoundField HeaderText="Damage Qty" DataField="damageQty" />
                                                    <asp:BoundField HeaderText="Missing Qty" DataField="MissingQty" />
                                                </Columns>
                                                <%--<FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                <HeaderStyle BackColor="#428bca" ForeColor="White" HorizontalAlign="Center" />--%>
                                            </asp:GridView>
                                       
                                            <asp:GridView ID="grid" runat="server" padding="0" spacing="0" border="0" cssClass="table table-striped pos-table">
                                            </asp:GridView>
                                       </div>
                          
                            </form>
                  
                </div>
             
    </div>
    </div>
    </div>
    </div>
</body>
</html>
