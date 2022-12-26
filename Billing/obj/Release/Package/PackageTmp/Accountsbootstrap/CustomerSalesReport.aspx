<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomerSalesReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.CustomerSalesReport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1">
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <title>Customer Sales Report</title>
    <!-- Bootstrap Core CSS -->
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />
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

        function switchViews(obj, imG) {
            var div = document.getElementById(obj);
            var img = document.getElementById(imG);
            if (div.style.display == "none") {
                div.style.display = "inline";


                img.src = "../images/minus.gif";

            }
            else {
                div.style.display = "none";
                img.src = "../images/plus.gif";

            }
        }
    </script>
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById("divPrint");
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important; size: landscape;">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();

            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <form runat="server" id="form1" method="post" style="margin-top: 0px">
        <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
        <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
        <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
        <asp:UpdatePanel ID="Updatepnel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row panel-custom1">
                                <div class="panel-header">
                                    <h1 class="page-header">Customer Sales Report</h1>
                                </div>

                                <div class="panel-body">
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <label>
                                                Filter By Branch</label>
                                            <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server" AutoPostBack="true"
                                                OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                            </asp:DropDownList>

                                            <label>
                                                Payment Mode</label>
                                            <asp:DropDownList ID="drpPayment" runat="server" OnSelectedIndexChanged="drppayment_selectedindex"
                                                AutoPostBack="true" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-3">
                                            <label>
                                                From Date</label></br>
                                    <asp:TextBox runat="server" CssClass="form-control" Visible="false" ID="txtCustomerName">
                                    </asp:TextBox>
                                            <asp:TextBox runat="server" CssClass="form-control" ID="txtfromdate">
                                            </asp:TextBox>
                                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtfromdate"
                                                ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                                            </asp:RangeValidator>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtfromdate"
                                                runat="server" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                            </br>
                                              <label>
                                                  To Date</label>
                                            <asp:TextBox runat="server" ID="txttodate" CssClass="form-control" AutoPostBack="true"
                                                OnTextChanged="txttodate_TextChanged">
                                            </asp:TextBox>
                                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txttodate"
                                                ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                                            </asp:RangeValidator>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txttodate"
                                                runat="server" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                        </div>

                                        <div class="col-lg-3">
                                            <label>
                                                Over All Sales</label>
                                            <asp:RadioButtonList ID="chkbutton" runat="server" OnSelectedIndexChanged="rad_chaked"
                                                AutoPostBack="true" RepeatColumns="2">
                                                <asp:ListItem Text="Detailed" Value="0" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Summary" Value="1"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:GridView ID="gvnormalsales"
                                                ShowHeader="false" runat="server" AutoGenerateColumns="false" CssClass="table table-striped pos-table" padding="0" spacing="0" border="0">
                                                <Columns>
                                                    <asp:BoundField DataField="bnch" />
                                                    <asp:BoundField DataField="paymenttype" />
                                                    <asp:BoundField DataField="SalesType" HeaderStyle-BackColor="#428bca" />
                                                    <asp:BoundField DataField="Total" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"
                                                        HeaderStyle-CssClass="disabled" />
                                                </Columns>
                                            </asp:GridView>
                                            <br />

                                            <br />
                                            <asp:CheckBox ID="chkDiscout" runat="server" Text="Check Discount Sales" />
                                        </div>
                                        <div class="col-lg-3">
                                            <label>Payment Flow Details :</label>
                                            <br />
                                            <asp:GridView ID="gvpaymentflowwise"
                                                ShowHeader="false" runat="server" AutoGenerateColumns="false" CssClass="table table-striped pos-table" padding="0" spacing="0" border="0">
                                                <Columns>
                                                    <asp:BoundField DataField="bnch" />
                                                    <asp:BoundField DataField="paymenttype" />
                                                    <asp:BoundField DataField="SalesType" HeaderStyle-BackColor="#428bca" />
                                                    <asp:BoundField DataField="Total" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"
                                                        HeaderStyle-CssClass="disabled" />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div class="col-lg-9">
                                            <asp:Button ID="btnall" runat="server" Text="Generate Report"
                                                CssClass="btn btn-success pos-btn1" OnClick="btnall_Click" />
                                            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnViewAll" runat="server" Text="Print"
                                                CssClass="btn btn-secondary" OnClick="Button2_Click" />
                                            &nbsp;&nbsp;&nbsp;<asp:Button ID="btnExport" Text="Export to Excel" runat="server" CssClass="btn btn-success"
                                                OnClick="btnExport_Click" />
                                            <asp:Button ID="btnSendMail" runat="server" Text="Send Gridview As Mail" OnClick="btnSendMail_Click"
                                                Visible="false" />
                                            <br />
                                            <br />

                                        </div>
                                        <div class="col-lg-12">


                                            <asp:Label ID="lblbranch" runat="server" Font-Bold="true" Text="Store :" ForeColor="Black"
                                                Visible="false"></asp:Label>
                                            <asp:Label ID="Label123" runat="server" Font-Bold="true" Text="" ForeColor="Black"
                                                Visible="false"></asp:Label>
                                            <asp:Label ID="lblCaption" runat="server"></asp:Label>
                                            <asp:Label ID="lblError" runat="server"></asp:Label>
                                            <div class="table-responsive panel-grid-left" id="divPrint" runat="server">


                                                <asp:GridView ID="gvCustsales" runat="server" AllowPaging="false"
                                                    CssClass="table table-striped pos-table" DataKeyNames="BillNo,typeid,Branch" ShowFooter="true" OnRowDataBound="gvCustsales_RowDataBound"
                                                    AutoGenerateColumns="false" EmptyDataText="No data found!" ShowHeaderWhenEmpty="True" padding="0" spacing="0" border="0">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Branch" DataField="Branch" Visible="true" />
                                                        <asp:TemplateField HeaderText="BillNo.">
                                                            <ItemTemplate>
                                                                <a href="javascript:switchViews('dv<%# Eval("salesid") %>', 'imdiv<%# Eval("salesid") %>');"
                                                                    style="text-decoration: none;">
                                                                    <img id="imdiv<%# Eval("salesid") %>" alt="Show" border="0" src="../images/plus.gif" />
                                                                </a>
                                                                <%# Eval("BillNo")%>
                                                                <div id="dv<%# Eval("salesid") %>" style="display: none; position: relative;">
                                                                    <asp:GridView runat="server" ID="gvLiaLedger"
                                                                        CssClass="table table-striped pos-table" GridLines="Both" AutoGenerateColumns="false"
                                                                        DataKeyNames="SalesID" ShowFooter="true" padding="0" spacing="0" border="0">
                                                                        <Columns>
                                                                            <asp:BoundField HeaderText="Transid" Visible="false" DataField="SalesID" />
                                                                            <asp:BoundField HeaderText="Product" DataField="Definition" />
                                                                            <asp:BoundField HeaderText="Qty" DataField="Quantity" DataFormatString='{0:f3}' />
                                                                            <asp:BoundField HeaderText="UnitPrice" DataField="UnitPrice" DataFormatString='{0:f}' />
                                                                            <asp:BoundField HeaderText="Total Amount" DataField="Amount" DataFormatString='{0:f}' />
                                                                            <asp:BoundField HeaderText="Sales Type" DataField="SalesType" DataFormatString='{0:f}' />
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField HeaderText="Bill No" DataField="BillNo" Visible="false" />
                                                        <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" Visible="false" />
                                                        <asp:BoundField HeaderText="Bill Date" DataField="BillDate" DataFormatString='{0:dd/MMM/yyyy}' />
                                                        <asp:BoundField HeaderText="Tax" DataField="Tax" DataFormatString='{0:f}' />
                                                        <asp:BoundField HeaderText="Sales Type" DataField="SalesType" DataFormatString='{0:f}' />
                                                        <asp:BoundField HeaderText="Bill Type" DataField="type" DataFormatString='{0:f}' />
                                                        <asp:BoundField HeaderText="Net-Amount" DataField="NetAmount" DataFormatString='{0:f}' />
                                                        <asp:BoundField HeaderText="Discount-Amount" DataField="Discount" DataFormatString='{0:f}' />
                                                        <asp:BoundField HeaderText="Total Amount" DataField="Total" DataFormatString='{0:f}' />
                                                        <asp:BoundField HeaderText="Billed By" Visible="false" DataField="Provider" />
                                                        <asp:BoundField HeaderText="Approved by" Visible="false" DataField="Approved" />
                                                        <asp:BoundField HeaderText="Name" DataField="Customername" />
                                                        <asp:BoundField HeaderText="No" DataField="mobileno" />
                                                    </Columns>
                                                    <%-- <HeaderStyle BackColor="#428bca" ForeColor="White" />
                                                        <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                            NextPageText="Next" PreviousPageText="Previous" />--%>
                                                </asp:GridView>
                                                Total Net amount:<label id="lblTotal" runat="server" align="left"></label><br />
                                                <br />

                                                Total Disc amount:<label id="disc" runat="server" align="left"></label><br />
                                                <br />

                                                Total amount:<label id="gndtotal" runat="server" align="left"></label>

                                            </div>


                                            <%--<div style="color: Green; font-weight: bold" class="form-group">
                                        <label id="lblNoRecords" style="color: Red" runat="server">
                                        </label>
                                        <br />
                                        <i>You are viewing page
                                            <%=gvCustsales.PageIndex + 1%>
                                            of
                                            <%=gvCustsales.PageCount%>
                                        </i>
                                    </div>--%>
                                        </div>
                                    </div>
                                    <!-- /.col-lg-6 (nested) -->
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gvCustsales" EventName="RowDataBound" />
            </Triggers>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="Updatepnel">
            <%--<ProgressTemplate>
<div class="overlay">
<div style=" z-index: 1000; margin-left: 350px;margin-top:200px;opacity: 1;-moz-opacity: 1;">
<img alt="" src="../images/Preloader_10.gif" />
</div>
</div>
</ProgressTemplate>--%>
            <ProgressTemplate>
                <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; opacity: 0.7;">
                    <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/Fancy pants.gif"
                        AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed; top: 45%; left: 50%;" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </form>
</body>
</html>
