<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RawMaterialStockReport.aspx.cs" Inherits="Billing.Accountsbootstrap.RawMaterialStockReport" %>

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
    <title>Raw Material Stock Report </title>
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
            var gridData = document.getElementById("BankGrid");
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
    <style>
        .chkChoice input
        {
            margin-left: -30px;
        }
        .chkChoice td
        {
            padding-left: 45px;
        }
        
        .chkChoice1 input
        {
            margin-left: -60px;
        }
        .chkChoice1 td
        {
            padding-left: 100px;
        }
    </style>
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $("[id*=chkAll]").bind("click", function () {
                if ($(this).is(":checked")) {
                    $("[id*=chkcategorylist] input").attr("checked", "checked");
                } else {
                    $("[id*=chkcategorylist] input").removeAttr("checked");
                }
            });
            $("[id*=chkcategorylist] input").bind("click", function () {
                if ($("[id*=chkcategorylist] input:checked").length == $("[id*=chkcategorylist] input").length) {
                    $("[id*=chkAll]").attr("checked", "checked");
                } else {
                    $("[id*=chkAll]").removeAttr("checked");
                }
            });
        });
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
          <h1 class="page-header">Raw Material Stock Report</h1>
	    </div>
         <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12">
                                    <div class="row">
                                        <div class="col-lg-3">

                                            <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="phono" ControlToValidate="txtsearch"
                                                ErrorMessage="Please enter your searching Data!" Text="*" Style="color: White" />
                                            <asp:TextBox CssClass="form-control" Enabled="true" ID="txtsearch" runat="server"
                                                placeholder="Search Text"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                FilterType="LowercaseLetters, UppercaseLetters,Numbers,Custom" ValidChars=" "
                                                TargetControlID="txtsearch" />

                                        </div>
                                        <div class="col-lg-3">

                                            <label>
                                                From date</label>
                                            <asp:TextBox runat="server" ID="txtfromdate" CssClass="form-control" AutoPostBack="true"
                                               > 
                                            </asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfromdate"
                                                Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>

                                        </div>
                                      
                                        <div class="col-lg-3" runat="server" visible="false">

                                            <label>
                                                Supplier</label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlsuplier" AutoPostBack="true"
                                                 runat="server">
                                            </asp:DropDownList>

                                        </div>

                                    </div>
                                    <br />
                                    <div class="row">
                                        <div class="col-lg-3" runat="server" visible="false">
                                            <label>
                                                Select Company</label>
                                            <asp:DropDownList ID="drpsubcompany" runat="server" AutoPostBack="true"
                                                TabIndex="1" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-3">

                                            <label>
                                                RawMaterials</label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlraw" AutoPostBack="true"
                                                MaxLength="150" runat="server">
                                            </asp:DropDownList>

                                        </div>
                                        <div class="col-lg-3">

                                            <br />
                                            <asp:Button ID="btnPrint" runat="server" OnClick="Button1_Click" CssClass="btn btn-info pos-btn1"
                                                Text="Search"  Width="100px" />
                                            &nbsp;&nbsp;&nbsp; 
                                            <asp:Button ID="btnpdf" runat="server" Text="PDF" OnClick="Button2_Click" CssClass="btn btn-info"  Width="100px" />

                                        </div>
                                        <div id="Div2" class="col-lg-1" runat="server" visible="true">
                                            <div class="form-group">
                                                <br />
                                                <asp:Button ID="btnExport" OnClick="Button3_Click" Text="Export to Excel" runat="server" Width="110px" CssClass="btn btn-success"
                                                     />
                                            </div>
                                        </div>

                                    </div>
                                </div>
                            </div>
                            <br />
                            <div class="row">

                                <div class="col-lg-12">

                                    <div id="Div1" runat="server" class="table-responsive panel-grid-left">
                                        <asp:GridView ID="BankGrid" runat="server" CssClass="table table-striped pos-table" padding="0" spacing="0" border="0" Width="100%" AllowSorting="true"
                                            EmptyDataText="No Records Found" AutoGenerateColumns="false">
                                            <PagerStyle CssClass="pos-paging" />
                                            <%-- <HeaderStyle BackColor="#3366FF" />
                                    <EmptyDataRowStyle HorizontalAlign="Center" BackColor="#59d3b4" ForeColor="Black" />
                                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                        NextPageText="Next" PreviousPageText="Previous" />--%>
                                            <Columns>
                                                <asp:BoundField HeaderText="Product" DataField="Product" />
                                                <asp:BoundField HeaderText="OpeningStock" DataField="OpeningStock"  DataFormatString='{0:f}'/>
                                                <asp:BoundField HeaderText="Purchased Qty" DataField="Purchased Qty" HeaderStyle-HorizontalAlign="Center"  DataFormatString='{0:f}'/>
                                                <asp:BoundField HeaderText="Rate" DataField="Rate" DataFormatString='{0:f}'/>
                                                 <asp:BoundField HeaderText="Amount" DataField="PurchaseAmount" DataFormatString='{0:f}' />
                                                <asp:BoundField HeaderText="Kitchen Issued Qty" DataField="KitchenIssued Qty" DataFormatString='{0:f}' />
                                                <asp:BoundField HeaderText="Kitchen Amount" DataField="KitchenAmount" DataFormatString='{0:f}' />
                                                  <asp:BoundField HeaderText="Branch Issued Qty" DataField="BranchIssued Qty" DataFormatString='{0:f}' />
                                                <asp:BoundField HeaderText="Branch Amount" DataField="BranchAmount" DataFormatString='{0:f}' />
                                                <asp:BoundField HeaderText="ClosingStockQty" DataField="ClosingStockQty" DataFormatString='{0:f}' />
                                                <asp:BoundField HeaderText="ClosingStockAmount" DataField="ClosingStockAmount" DataFormatString='{0:f}' />

                                            </Columns>
                                            <%--<FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                    <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
    </div>
    </div>
    </form>
</body>
</html>

