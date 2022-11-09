<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StockAuditReport.aspx.cs" Inherits="Billing.Accountsbootstrap.StockAuditReport" %>


<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <title>Stock Audit Detailed Report </title>
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
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
        function printGrid() {
            var gridData = document.getElementById("tbl");
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');

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
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
     <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Stock Audit Detailed Report</h1>
	    </div>
   
                <div class="panel-body">
                    <div class="row">

                            <div class="form-group" id="admin" runat="server">
                                <legend>Filter By Branch</legend>
                                <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                            <div id="Div1" runat="server" visible="true" class="col-lg-3">
                                <label>
                                    From Date</label>
                                <asp:TextBox runat="server" ID="txtFrom" CssClass="form-control"  AutoPostBack="true"
                                    OnTextChanged="txttodate_TextChanged">
                                </asp:TextBox>
                                <asp:RangeValidator ID="RangeValidator1" runat="server"
                                          ControlToValidate="txtFrom" ErrorMessage="Please Select valid Date Thank You!!!"
                                          Type="Date">
                                </asp:RangeValidator>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txttodate"
                                    runat="server" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                            </div>
                            <div class="col-lg-3">
                                <label>
                                    To Date</label>
                                <asp:TextBox runat="server" ID="txttodate" CssClass="form-control">
                                </asp:TextBox>
                                 <asp:RangeValidator ID="RangeValidator2" runat="server"
                                  ControlToValidate="txttodate" ErrorMessage="Please Select valid Date Thank You!!!"
                                  Type="Date">
                        </asp:RangeValidator>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtFrom"
                                    runat="server" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                            </div>
                            <div class="col-lg-3">
                                    <label>
                                        Item</label>
                                    <asp:DropDownList ID="ddlSubCategory" runat="server" class="form-control"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                    <asp:Label ID="lblsuberror" runat="server" Style="color: Red"></asp:Label>
                            </div>
                            <div class="col-lg-3">
                            <br />
                                <asp:Button ID="Button1" runat="server" class="btn btn-primary pos-btn1" Text="Search" 
                                    OnClick="Button1_Click" />
                            
                               &nbsp; &nbsp;&nbsp;<asp:Button ID="Button2" runat="server" class="btn btn-secondary" Text="Print" 
                                    OnClick="Button2_Click" />
                               &nbsp;&nbsp;&nbsp; <asp:Button ID="btnexp" runat="server" Visible="false"  CssClass="btn-btn-Success "
                                    Text="Export" OnClick="btnexp_Click" />
                            </div>
                        </div>
                    
                    
                       
                            <div id="div2" runat="server">
                                
                                            <label id="caption" runat="server" visible="true">
                                            </label>
                                              <div class="table-responsive panel-grid-left">
                                            <asp:GridView ID="GVStockAlert" Width="100%" runat="server" cssClass="table table-striped pos-table" AutoGenerateColumns="false"
                                                EmptyDataText="No Records Found" Caption="Stock Audit Detailed Report" padding="0" spacing="0" border="0">
                                                <Columns>
                                                    <asp:BoundField HeaderText="Category" DataField="category" />
                                                    <asp:BoundField HeaderText="Item Name" DataField="definition"/>
                                                    <asp:BoundField HeaderText="Screen" DataField="screen" />
                                                    <asp:BoundField HeaderText="Qty" DataField="qty" DataFormatString="{0:###,##0}" />
                                                    <asp:BoundField HeaderText="Stock Sign" DataField="sign"/>
                                                    <asp:BoundField HeaderText="Entry Date" DataField="qtydate" DataFormatString='{0:dd/MMM/yyyy HH:mm tt}' />
                                                    <asp:BoundField HeaderText="REFID" DataField="RefId" />
                                                </Columns>
                                               <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                                    HorizontalAlign="Center" ForeColor="White" />--%>
                                            </asp:GridView>
                                            </div>
                            </div>
                       
                 
           
    </div>
    </div>
    </div>
    </div>
    </div>
    </form>
</body>
</html>

