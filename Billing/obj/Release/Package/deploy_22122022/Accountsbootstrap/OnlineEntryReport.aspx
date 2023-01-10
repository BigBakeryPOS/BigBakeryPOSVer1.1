<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineEntryReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.OnlineEntryReport" %>

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
    <title>Online Entry Report</title>
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
          <h1 class="page-header">Online Order Report</h1>
	    </div>

                        <div class="panel-body">
                            <div class="row">
                              
                                    <div class="col-lg-3">
                                        <label>
                                            Filter By Branch</label>
                                        <asp:DropDownList CssClass="form-control" ID="drpbranch"  runat="server">
                                        </asp:DropDownList>
                                        <br />
                                    </div>
                                    <div class="col-lg-3">
                                        <label>
                                            From date</label>
                                        <asp:TextBox runat="server" Visible="false" ID="txtCustomerName">
                                        </asp:TextBox>
                                        <asp:TextBox runat="server" ID="txtfromdate" class="form-control">
                                        </asp:TextBox>
                                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtfromdate"
                                            ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                                        </asp:RangeValidator>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtfromdate"
                                            runat="server" CssClass="cal_Theme1">
                                        </ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="col-lg-3">
                                        <label>
                                            To date</label>
                                        <br />
                                        <asp:TextBox runat="server" ID="txttodate" class="form-control">
                                        </asp:TextBox>
                                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txttodate"
                                            ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                                        </asp:RangeValidator>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txttodate"
                                            runat="server" CssClass="cal_Theme1">
                                        </ajaxToolkit:CalendarExtender>
                                        <br />
                                    </div>
                                    <div class="col-lg-3">
                                    <br />
                                        <asp:RadioButtonList ID="radbtn" runat="server" RepeatColumns="2">
                                            <asp:ListItem Text="Normal Report" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Summary Report" Value="2"></asp:ListItem>
                                            <%--<asp:ListItem Text="Detail Report" Value="3"></asp:ListItem>--%>
                                        </asp:RadioButtonList>
                                    </div>
                                    </div>
                                     <div class="row">
                                    <div class="col-lg-3">
                                        <label>
                                            Sales Type</label>
                                        <asp:DropDownList ID="drpsalestype" runat="server" CssClass="form-control">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-lg-3">
                                    <br />
                                        <asp:Button ID="btnall" runat="server" Text="Generate Report" CssClass="btn btn-primary pos-btn1"
                                            OnClick="btnall_Click" />
                                        &nbsp; &nbsp; &nbsp;
                                        <asp:Button ID="btnExport" Text="Export to Excel" runat="server" CssClass="btn btn-success"
                                            OnClick="btnExport_Click" />
                                        <asp:Button ID="btnViewAll" runat="server" Visible="false" Text="Print" CssClass="btn btn-success"
                                            OnClick="Button2_Click" />
                                    </div>
                                </div>
                                
                                    
                                        <asp:Label ID="lblbranch" runat="server" Font-Bold="true" Text="Store :" ForeColor="Black"
                                            Visible="false"></asp:Label>
                                        <asp:Label ID="Label123" runat="server" Font-Bold="true" Text="" ForeColor="Black"
                                            Visible="false"></asp:Label>
                                   
                                    <div class="table-responsive panel-grid-left" id="divPrint" runat="server">
                                     
                                                    <asp:Label ID="lblCaption" runat="server" ForeColor="Red"></asp:Label>
                                                    <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                                    <div class="table-responsive" id="divdetails">
                                                        <asp:GridView ID="gvdetailed" runat="server" AllowPaging="false" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                                            ShowFooter="true" OnRowDataBound="gvdetailed_rowdatabound" AutoGenerateColumns="false"
                                                            EmptyDataText="No data found!" ShowHeaderWhenEmpty="True">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="Branch Code" DataField="branchcode" />
                                                                <asp:BoundField HeaderText="Sales Type" DataField="paymenttype" />
                                                                <asp:BoundField HeaderText="Online No." DataField="onlinenumber" />
                                                                <asp:BoundField HeaderText="Entry by" DataField="entryby" />
                                                                <asp:BoundField HeaderText="Entry Date" DataField="entrydate" DataFormatString='{0:d}' />
                                                                <asp:BoundField HeaderText="Bill No" DataField="kotno" />
                                                                <asp:BoundField HeaderText="Bill Date" DataField="kotdate" DataFormatString='{0:d}' />
                                                                <asp:BoundField HeaderText="Item Details" DataField="itemnarration" />
                                                                <asp:BoundField HeaderText="Status" DataField="Status" />
                                                                <asp:BoundField HeaderText="Hold No" DataField="Hkotno" />
                                                                <asp:BoundField HeaderText="Hold Date" DataField="Hkotdate" DataFormatString='{0:d}' />
                                                                <asp:BoundField HeaderText="Hold Status" DataField="Hstatus" />
                                                                <asp:BoundField HeaderText="Req.Type" DataField="Requesttype" />
                                                                <asp:BoundField HeaderText="C.Status" DataField="Cstatus" />
                                                                <asp:BoundField HeaderText="Cancel Date" DataField="Cdate" DataFormatString='{0:d}' />
                                                                <asp:BoundField HeaderText="Reason By Store" DataField="reason" />
                                                                <asp:BoundField HeaderText="Reason By Self" DataField="Cnotes" />
                                                            </Columns>
                                                            <PagerStyle CssClass="pos-paging" />
                                                            <%--<HeaderStyle BackColor="#990000" />
                                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                                NextPageText="Next" PreviousPageText="Previous" />--%>
                                                        </asp:GridView>
                                                        <asp:GridView ID="gvsummary" runat="server" AllowPaging="false" cssClass="table table-striped pos-table" Width="150%"
                                                            ShowFooter="true" OnRowDataBound="gvsummary_rowdatabound" AutoGenerateColumns="false" padding="0" spacing="0" border="0"
                                                            EmptyDataText="No data found!" ShowHeaderWhenEmpty="True">
                                                            <Columns>
                                                                <asp:BoundField HeaderText="S.No" DataField="Rown" />
                                                                <asp:BoundField HeaderText="Month" DataField="MonthName" />
                                                                <asp:BoundField HeaderText="week" DataField="week" />
                                                                <asp:BoundField HeaderText="Vendor Type" DataField="paymenttype" />
                                                                <asp:BoundField HeaderText="Payment Source" DataField="PayMode" />
                                                                <asp:BoundField HeaderText="Store Location" DataField="city" />
                                                                <asp:BoundField HeaderText="Store Area" DataField="brancharea" />
                                                                <asp:BoundField HeaderText="Sender Name" DataField="sendername" />
                                                                <asp:BoundField HeaderText="Sender No" DataField="senderno" />
                                                                <asp:BoundField HeaderText="Receiver Name" DataField="receivername" />
                                                                <asp:BoundField HeaderText="Receiver No" DataField="receiverno" />
                                                                <asp:BoundField HeaderText="Order date" DataField="orderdate" DataFormatString='{0:dd/MMM/yyyy}' />
                                                                <asp:BoundField HeaderText="Delivery Date" DataField="deliverydate" DataFormatString='{0:dd/MMM/yyyy}' />
                                                                <asp:BoundField HeaderText="DayName" DataField="DayName" />
                                                                <asp:BoundField HeaderText="Online No." DataField="onlinenumber" />
                                                                <asp:BoundField HeaderText="Item Details" DataField="itemnarration" />
                                                                <asp:BoundField HeaderText="Total Qty" DataField="TotalQty" />
                                                                <asp:BoundField HeaderText="Order Value" DataField="NetAmount" />
                                                                
                                                                <asp:BoundField HeaderText="GST" DataField="gstamount" />
                                                                <asp:BoundField HeaderText="Total Value" DataField="TotalAmount" />
                                                                <asp:BoundField HeaderText="Order date" DataField="orderdate" DataFormatString='{0:hh:mm tt}' />
                                                                <asp:BoundField HeaderText="Status" DataField="Status" />
                                                                <asp:BoundField HeaderText="Discount" DataField="Discountamount" />
                                                                <asp:BoundField HeaderText="Delivery charges" DataField="Deliverycharge" />
                                                                <asp:BoundField HeaderText="Actual Total" DataField="ActualtotalAmount" />
                                                                <asp:BoundField HeaderText="Entry by" DataField="entryby" />

                                                                <asp:BoundField HeaderText="Branch Code" DataField="branchcode" Visible="false" />
                                                                <asp:BoundField HeaderText="Entry Date" DataField="entrydate" DataFormatString='{0:d}' Visible="false" />
                                                                <asp:BoundField HeaderText="Bill No" DataField="kotno" Visible="false" />
                                                                <asp:BoundField HeaderText="Bill Date" DataField="kotdate" DataFormatString='{0:d}' Visible="false" />
                                                                <asp:BoundField HeaderText="Hold No" DataField="Hkotno" Visible="false" />
                                                                <asp:BoundField HeaderText="Hold Date" DataField="Hkotdate" DataFormatString='{0:d}' Visible="false" />
                                                                <asp:BoundField HeaderText="Hold Status" DataField="Hstatus" Visible="false" />
                                                                <asp:BoundField HeaderText="Req.Type" DataField="Requesttype" Visible="false" />
                                                                <asp:BoundField HeaderText="C.Status" DataField="Cstatus" Visible="false" />
                                                                <asp:BoundField HeaderText="Cancel Date" DataField="Cdate" DataFormatString='{0:d}' Visible="false" />
                                                                <asp:BoundField HeaderText="Reason By Store" DataField="reason" Visible="false" />
                                                                <asp:BoundField HeaderText="Reason By Self" DataField="Cnotes" Visible="false" />
                                                            </Columns>
                                                            <PagerStyle CssClass="pos-paging" />
                                                            <%--<HeaderStyle BackColor="#990000" />
                                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                                NextPageText="Next" PreviousPageText="Previous" />--%>
                                                        </asp:GridView>
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
