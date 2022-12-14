<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NewTaxReport.aspx.cs" Inherits="Billing.Accountsbootstrap.NewTaxReport" %>

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
    <title>Sales GST Report</title>
    <!-- Bootstrap Core CSS -->
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
        function printGridSummary() {
            var gridData = document.getElementById("divdsummary");
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


        function printGridDetails() {
            var gridData = document.getElementById("divdetails");
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
          <h1 class="page-header">Tax Report</h1>
	    </div>

                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-3">
                                    <label>
                                        Filter By Branch</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlBranch"  runat="server"
                                        AutoPostBack="true" OnSelectedIndexChanged="ddlBranch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    </div>
                                     <div class="col-lg-3">
                                    <label>
                                        From date</label>
                                    <asp:TextBox runat="server" Visible="false" ID="txtCustomerName">
                                    </asp:TextBox>
                                    <asp:TextBox runat="server" ID="txtfromdate" class="form-control" >
                                    </asp:TextBox>
                                    <%--<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtfromdate"
                                        ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                                    </asp:RangeValidator>--%>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtfromdate"
                                        runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                    </div>
                                     <div class="col-lg-3">
                                    <label>
                                        To date</label>
                                    <asp:TextBox runat="server" ID="txttodate" AutoPostBack="true" class="form-control" OnTextChanged="txttodate_TextChanged">
                                    </asp:TextBox>
                                    <%--<asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txttodate"
                                        ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                                    </asp:RangeValidator>--%>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txttodate"
                                        runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                    </div>
                                        <div class="col-lg-3">
                                    <label>
                                        Select Format Type:</label>
                                    <asp:RadioButtonList ID="radbtnlist" runat="server" RepeatColumns="3">
                                        <asp:ListItem Text="Summary" Value="1" ></asp:ListItem>
                                        <asp:ListItem Text="Detailed" Value="2" ></asp:ListItem>
                                        <asp:ListItem Text="GST Filing" Value="3" Selected="True"></asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                                </div>
                                <br />
                                <div class="row">
                                     <div class="col-lg-3">
                                    <asp:Button ID="btnall" runat="server" Text="Generate Report" CssClass="btn btn-info pos-btn1"
                                        OnClick="btnall_Click" />
                                    <asp:CheckBox Visible="false" ID="chkDiscout" runat="server" Text="Check Discount Sales" />
                                    &nbsp;&nbsp;&nbsp;
                                    <asp:Button ID="btnExport" Text="Export to Excel" runat="server" CssClass="btn btn-success"
                                        OnClick="btnExport_Click" />
                                    <asp:Button ID="btnViewAll" runat="server" Visible="false" Text="Print" CssClass="btn btn-success"
                                        OnClick="Button2_Click" />
                                </div>
                            </div>
                            <br />
                            <div class="row">
                                        <asp:Label ID="lblbranch" runat="server" Font-Bold="true" Text="Store :" ForeColor="Black"
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="Label123" runat="server" Font-Bold="true" Text="" ForeColor="Black"
                                            Visible="false"></asp:Label>
                                    <div class="col-lg-12">
                                    
                                        
                                                    <asp:Label ID="lblCaption" runat="server" ForeColor="#0074e7"></asp:Label>
                                                    <asp:Label ID="lblError" runat="server" ForeColor="#0074e7"></asp:Label>
                                                    
                                                    <div class="table-responsive panel-grid-left" id="divPrint" runat="server">
                                                    <div id="divdetails">
                                                        <asp:GridView ID="gvdetailed" runat="server" AllowPaging="false"  cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                                            DataKeyNames="BillNo" ShowFooter="true" OnRowDataBound="gvdetailed_rowdatabound"
                                                            AutoGenerateColumns="false" EmptyDataText="No data found!" ShowHeaderWhenEmpty="True">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Pay Mode" DataField="paymode" />
                                                                <asp:BoundField HeaderText="Sales Type" DataField="paymenttype" />
                                                                <asp:BoundField HeaderText="Order No" DataField="No" />
                                                                <asp:BoundField HeaderText="Bill No" DataField="billno" />
                                                                <asp:BoundField HeaderText="Bill Date" DataField="BillDate" />
                                                                <asp:BoundField HeaderText="Category" DataField="Category" />
                                                                <asp:BoundField HeaderText="Item" DataField="definition" />
                                                                <asp:BoundField HeaderText="Unit Price" DataField="unitprice" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="Qty" DataField="quantity" />
                                                                <asp:BoundField HeaderText="SubTotal" DataField="amount" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="GST 0% " DataField="Z" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="GST 5%" DataField="F" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="GST 12%" DataField="TW" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="GST 18%" DataField="EG" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="GST 28%" DataField="TE" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="disc. Amnt" DataField="disc" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="Total Value" DataField="TotalValue" DataFormatString='{0:f2}' />
                                                            </Columns>
                                                            <%--<HeaderStyle BackColor="#990000" />
                                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                                NextPageText="Next" PreviousPageText="Previous" />--%>
                                                        </asp:GridView>
                                                    </div>
                                                    <div id="divsummary">
                                                        <asp:GridView ID="gvsummary" runat="server" AllowPaging="false" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                                            DataKeyNames="BillNo" ShowFooter="true" OnRowDataBound="gvsummary_rowdatabound"
                                                            AutoGenerateColumns="false" EmptyDataText="No data found!" ShowHeaderWhenEmpty="True">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Pay Mode" DataField="paymode" />
                                                                <asp:BoundField HeaderText="Sales Type" DataField="paymenttype" />
                                                                <asp:BoundField HeaderText="Order No" DataField="No" />
                                                                <asp:BoundField HeaderText="Bill No" DataField="billno" />
                                                                <asp:BoundField HeaderText="Bill Date" DataField="BillDate" />
                                                                <asp:BoundField HeaderText="Unit Price" DataField="unitprice" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="Qty" DataField="quantity" />
                                                                <asp:BoundField HeaderText="SubTotal" DataField="amount" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="GST 0% " DataField="Z" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="GST 5%" DataField="F" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="GST 12%" DataField="TW" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="GST 18%" DataField="EG" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="GST 28%" DataField="TE" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="disc. Amnt" DataField="disc" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="Total Value" DataField="TotalValue" DataFormatString='{0:f2}' />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#990000" />
                                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                                NextPageText="Next" PreviousPageText="Previous" />
                                                        </asp:GridView>
                                                    </div>
                                                    <div  id="divgstfile">
                                                        <asp:GridView ID="Gst" runat="server" AllowPaging="false" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0" ShowFooter="true"
                                                            OnRowDataBound="Gst_onrowdatabound" AutoGenerateColumns="false" EmptyDataText="No data found!"
                                                            ShowHeaderWhenEmpty="True">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="S.No">
                                                                    <ItemTemplate>
                                                                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField HeaderText="Total Bill Count" DataField="cnt" />
                                                                <asp:BoundField HeaderText="From Bill No" DataField="Fbillno" />
                                                                <asp:BoundField HeaderText="To Bill No" DataField="Tbillno" />
                                                                <asp:BoundField HeaderText="Bill Date" DataField="BillDate" />
                                                                <asp:BoundField HeaderText="Qty" DataField="quantity" />
                                                                <asp:BoundField HeaderText="SubTotal" DataField="amount" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="Net GST Amount 0% " DataField="Z" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="GST 0% " DataField="Z1" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="Net GST Amount 5%" DataField="F" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="GST 5%" DataField="F1" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="Net GST Amount 12%" DataField="TW" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="GST 12%" DataField="TW1" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="Net GST Amount 18%" DataField="EG" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="GST 18%" DataField="EG1" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="Net GST Amount 28%" DataField="TE" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="GST 28%" DataField="TE1" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="disc. Amnt" DataField="disc" DataFormatString='{0:f2}' />
                                                                <asp:BoundField HeaderText="Total Value" DataField="TotalValue" DataFormatString='{0:f2}' />
                                                            </Columns>
                                                            <HeaderStyle BackColor="#990000" />
                                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                                NextPageText="Next" PreviousPageText="Previous" />
                                                        </asp:GridView>
                                                    </div>
                                             </div>
                                   
                                    <div>
                                    </div>
                                </div>
                          </div>
                          </div>
                        </div>
                      
            </div>
            </div>
            </div>
           
        </ContentTemplate>
        <Triggers>
            <asp:AsyncPostBackTrigger ControlID="gvdetailed" EventName="RowDataBound" />
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
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                right: 0; left: 0; z-index: 9999999; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/Fancy pants.gif"
                    AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed;
                    top: 45%; left: 50%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>
</html>
