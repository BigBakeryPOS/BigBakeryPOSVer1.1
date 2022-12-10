<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Closing_report.aspx.cs"
    EnableEventValidation="false" Inherits="Billing.Accountsbootstrap.Closing_report" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1">
    <link rel="stylesheet" type="text/css" href="css/mGrid.css" />
    <style type="text/css" re>
        .table-striped1 > tbody > tr:nth-child(even)
        {
            background-color: #81d8d0;
        }
        .table-striped1 > tbody > tr:nth-child(odd)
        {
            background-color: #81d8d0;
        }
        /* Background Gradient for Analagous Colors */
        .gradient2
        {
            background-color: #08D0AA; /* For WebKit (Safari, Chrome, etc) */
            background: #08D0AA -webkit-gradient(linear, left top, left bottom, from(#0871D0), to(#08D0AA)) no-repeat; /* Mozilla,Firefox/Gecko */
            background: #08D0AA -moz-linear-gradient(top, #0871D0, #08D0AA) no-repeat; /* IE 5.5 - 7 */
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#0871D0, endColorstr=#08D0AA) no-repeat; /* IE 8 */
            -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr=#0871D0, endColorstr=#0871D0)" no-repeat;
        }
        .table caption {
            background: #007aff;
            color: #fff;
            padding: 10px;
            font-weight: bold;
        }
    </style>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <title>Day Close Report</title>
    <!-- Bootstrap Core CSS -->
    <link rel="stylesheet" href="http://code.jquery.com/mobile/1.4.5/jquery.mobile-1.4.5.min.css">
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
    <style>
        .messagepop
        {
            border: 1px solid #999999;
            cursor: default;
            display: none;
            margin-top: 15px;
            position: absolute;
            text-align: left;
            width: 394px;
            height: 100px;
            z-index: 50;
            padding: 25px 25px 20px;
            border-radius: 7px;
            background: #e84c3d;
            margin: 30px auto 0;
            padding: 6px;
            color: White;
            top: 50%;
            left: 50%;
            margin-left: -400px;
            margin-top: -40px;
        }
    </style>
    <script language="javascript">
        function shw() {
            var sub = document.getElementById("popup");
            sub.style.display = 'block';
        }

       
    </script>
    <script>
        function klose() {
            var sub = document.getElementById("popup");

            sub.style.display = 'none';

        }
    </script>
    <script language="javascript">


        function hide() {
            var sub = document.getElementById("popup");
            if (document.getElementById("txtnam").value == "") {
                alert('Pleae enter your name');
            }
            else {

                sub.style.display = 'none';
            }
        }


     
    </script>
    <script type="text/javascript">
        function ClientSideClick(myButton) {
            // Client side validation
            if (typeof (Page_ClientValidate) == 'function') {
                if (Page_ClientValidate() == false)
                { return false; }
            }

            //make sure the button is not of type "submit" but "button"
            if (myButton.getAttribute('type') == 'button') {
                // disable the button
                myButton.disabled = true;
                myButton.className = "btn-inactive";
                myButton.value = "processing...";
            }
            return true;
        }
    </script>
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= A4.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();
            var sub = document.getElementById("btnSubmit");
            var send = document.getElementById("Button1");
            var print = document.getElementById("Button2");

          //  sub.style.display = "none";
          //  send.style.display = "none";
          //  print.style.display = "none";

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
    <script type="text/javascript">
        function Denomination() {


            var gridData = document.getElementById('<%= deno.ClientID %>');


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
        function alertMessage() {
            alert('Email Sent Sucessfully !');
        }



    </script>
    <script type="text/javascript">
        function Closed() {
            alert('Email Sent Sucessfully!!!.Thank You !');
        }
    </script>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <div class="clearfix"></div>
    <form runat="server" id="form1" method="post" style="margin-top: 0px">
    <div class="container-fluid">
        <div class="row panel panel-custom1">
            <div class="col-md-12 form-inline" style="padding-top: 15px;">
                <asp:Label runat="server" ID="lblWelcome">Welcome : </asp:Label>
                <asp:Label runat="server" ID="lblUser" >Welcome: </asp:Label>
                <asp:Label runat="server" ID="lblUserID" Visible="false"> </asp:Label>
                <asp:Label ID="chkhour" runat="server" Visible="false" Text="01"></asp:Label>
                <asp:Label ID="chkminu" runat="server" Visible="false" Text="30"></asp:Label>
                <asp:Label ID="lbltotexpense" runat="server" Visible="false"></asp:Label>
                <asp:Label ID="lbldefaultcur" runat="server" Visible="false" Text="INR"></asp:Label>
                <%--nknavaneethan4U@gmail.com--%>
                <asp:TextBox ID="txtemail" Visible="false" runat="server" Text="nknavaneethan4U@gmail.com" class="form-control"></asp:TextBox>
                <asp:TextBox ID="txtdelorderemail" runat="server" Text="blaackforestonline@gmail.com" class="form-control"></asp:TextBox>
                <asp:Label ID="lblpaymode" runat="server" Visible="false" Text="s.ipaymode <> ('15')"></asp:Label>
                <asp:Label ID="lblinvmail" runat="server" Visible="false" Text="nknavaneethan4U@gmail.com"></asp:Label>
                <asp:Label ID="lbldays" runat="server" Visible="false" Text="7"></asp:Label>
            </div>
        </div>
 <asp:Label ID="lblbactpaytm" runat="server" Visible="false" Text="Actual Acc.Trans. Amount"></asp:Label>
    <asp:Label ID="lblbdiffactpaytm" runat="server" Visible="false" Text="Difference in Acc.Trans. Amount +/-"></asp:Label>
        <asp:UpdatePanel ID="Updatepnel" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
               
        <div class="row panel panel-custom1">
            <div class="col-md-12" style="padding-top: 15px;">
                <div id="A4" runat="server" title="">
                    <div>
                        <div class="row">
                            <div class="col-md-12">
                                <div class="col-md-2">
                                    <br />
                                    <asp:CheckBox ID="chkdatetime" runat="server" text="Daily View Report" />
                                </div>
                                <div class="col-md-2">
                                    Select Store:
                                    <asp:DropDownList class="form-control" ID="DDlbranch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDlbranch_SelectedIndexChanged">
                                    </asp:DropDownList>
                                </div>
                                <div class="col-md-2">
                                    Select Date: 
                                    <asp:TextBox ID="date" runat="server" CssClass="form-control cal_Theme1"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="date" Format="yyyy-MM-dd" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender >
                                    
                                </div>
                                <div class="col-md-2">
                                    <br />
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary pos-btn1" OnClick="btnSubmit_Click" />
                                    <asp:Button ID="Button1" runat="server" Visible="false" Text="Send Mail" CssClass="btn btn-primary pos-btn1"
                                        OnClick="btnMail_Click" />
                                    <asp:Button ID="Button2" runat="server" Text="Print" CssClass="btn btn-primary pos-btn1" OnClientClick=" printGrid()" />
                                </div>
                                <div class="col-md-4 form-inline">
                                    <asp:RequiredFieldValidator ErrorMessage="Name is Required " ForeColor="Red" ControlToValidate="txtName"
                                        ID="val" runat="server" ValidationGroup="val1" style="display: block;"></asp:RequiredFieldValidator>
                                    <asp:Button ID="btnsession" runat="server" Text="Close Day" UseSubmitBehavior="false"
                                        OnClientClick="ClientSideClick(this)" Visible="false" CssClass="btn btn-danger" OnClick="btnsession_Click" />
                                    <asp:TextBox ID="txtName" runat="server" Placeholder="Enter Your Name" class="form-control"></asp:TextBox>
                                    <asp:Button ID="Button3" runat="server" Text="Close Session" UseSubmitBehavior="false"
                                        OnClientClick="ClientSideClick(this)" CssClass="btn btn-primary pos-btn1" OnClick="Button3_Click"
                                        ValidationGroup="val1" />
                                    <asp:Button ID="btnSendMail" runat="server" Text="Send As Mail" OnClick="btnSendMailReport_Click"  CssClass="btn btn-primary pos-btn1"
                                        Visible="false" />
                                    <asp:Button ID="Print" runat="server" Text="Print" CssClass="btn btn-primary pos-btn1" OnClick="Print_Click"
                                        Style="display: none" />
                                </div>
                                <br />
                                <h4>
                                    <label id="lblvil" runat="server">
                                    </label>
                                </h4>
                                <br />
                            </div>
                        </div>
                        <!-- /.col-lg-12 -->
                    </div>
                    <div class="col-md-12">
                        <table class="table" id="Table1" border="0" width="100%" align="center" runat="server" visible="true">
                            <tr>
                                <td valign="top" width="30%">
                                    <table class="table" id="Table2" width="100%" border="1" runat="server" visible="true">
                                        <thead>
                                            <tr>
                                                <th colspan="2" style="background-color: #007aff; color: white">
                                                    Cash Flow Table
                                                </th>
                                            </tr>
                                        </thead>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gridcashflowdetails" CssClass="mGrid" ShowHeader="false" runat="server"
                                                    AutoGenerateColumns="false" HeaderStyle-CssClass="disabled" Width="100%">
                                                    <Columns>
                                                        <asp:BoundField DataField="Nametype" HeaderStyle-CssClass="disabled" />
                                                        <asp:BoundField DataField="Total" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"
                                                            HeaderStyle-CssClass="disabled" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <thead>
                                            <tr>
                                                <th colspan="2" style="background-color: #007aff; color: white">
                                                    Summary Details Flow Table
                                                </th>
                                            </tr>
                                        </thead>
                                        <tr>
                                            <td style="background-color: #72fa8f">
                                                <asp:Label ID="lbl_Total_Sales" runat="server">Total Sales</asp:Label>
                                            </td>
                                            <td style="background-color: #72fa8f" align="right">
                                                <asp:Label ID="lbl_Total_Sales_Amt" runat="server">0.00</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: #72fa8f">
                                                <asp:Label ID="Label4" runat="server">Total Online Sales</asp:Label>
                                            </td>
                                            <td style="background-color: #72fa8f" align="right">
                                                <asp:Label ID="lblonlinesales" runat="server">0.00</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: #72fa8f">
                                                <asp:Label ID="Label9" runat="server">Total Credit Sales</asp:Label>
                                            </td>
                                            <td style="background-color: #72fa8f" align="right">
                                                <asp:Label ID="lblcreditsales" runat="server">0.00</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: #72fa8f">
                                                <asp:Label ID="Label8" runat="server">Total Return Stock</asp:Label>
                                                <%--<asp:Label ID="lblSales_deductions" runat="server">Stock Wastage</asp:Label>--%>
                                            </td>
                                            <td style="background-color: #72fa8f" align="right">
                                                <asp:Label ID="lblSales_deductions_amt" runat="server">0.00</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: #72fa96">
                                                <asp:Label ID="Label6" runat="server">Total Cash Sales</asp:Label>
                                            </td>
                                            <td style="background-color: #72fa96" align="right">
                                                <asp:Label ID="lbltotalcashsales" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: #72fa8f">
                                                <asp:Label ID="Label7" runat="server">Total Cash Refund</asp:Label>
                                                <%--<asp:Label ID="lblSales_deductions" runat="server">Stock Wastage</asp:Label>--%>
                                            </td>
                                            <td style="background-color: #72fa8f" align="right">
                                                <asp:Label ID="lbltotcshrefund" runat="server">0.00</asp:Label>
                                            </td>
                                        </tr>
                                        <%--<tr>
                                        <td style="background-color: #fa8072">
                                            <asp:Label ID="Label7" runat="server">Balance Cash Sales(Total Cash Sales + OP CASH - Office To Cash - Total Expense)</asp:Label>
                                        </td>
                                        <td style="background-color: #fa8072" align="right">
                                            <asp:Label ID="Label8" runat="server" ></asp:Label>
                                        </td>
                                    </tr>--%>
                                        <tr>
                                            <td style="background-color: #72fa8f">
                                                <asp:Label ID="Label1" runat="server">Total Cash </asp:Label>
                                            </td>
                                            <td style="background-color: #72fa8f" align="right">
                                                <asp:Label ID="lbltotoverallcash" Visible="false" runat="server">0.00</asp:Label>
                                                <asp:Label ID="lblcashsalescolumn1" Visible="false" runat="server">0.00</asp:Label>
                                                <asp:Label ID="lblopcashsales" Visible="false" runat="server">0.00</asp:Label>
                                                <asp:Label ID="lblcurrentcash" runat="server">0.00</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: #72fa8f">
                                                <asp:Label ID="Label3" runat="server">Closing Cash</asp:Label>
                                            </td>
                                            <td style="background-color: #72fa8f" align="right">
                                                <asp:TextBox ID="txtopcash" Enabled="false" runat="server">0</asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td style="background-color: #72fa8f">
                                                <asp:Label ID="Label5" runat="server">Cash Taken </asp:Label>
                                            </td>
                                            <td style="background-color: #72fa8f" align="right">
                                                <asp:Label ID="lblcashtaken" runat="server">0</asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="background-color: #72fa8f">
                                                <asp:Label ID="Label2" runat="server">+/-</asp:Label>
                                            </td>
                                            <td style="background-color: #72fa8f" align="right">
                                                <asp:Label ID="lbldifferencevaluecolumn1" runat="server">0.00</asp:Label>
                                            </td>
                                        </tr>
                                        <thead>
                                            <tr>
                                                <th colspan="2" style="background-color: #007aff; color: white">
                                                    Total Details Expense
                                                </th>
                                            </tr>
                                        </thead>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gridexpense" CssClass="mGrid" ShowHeader="false" runat="server"
                                                    FooterStyle-BackColor="#d8ff00" ShowFooter="true" OnRowDataBound="gridexpense_rowdatabound"
                                                    AutoGenerateColumns="false" HeaderStyle-CssClass="disabled" Width="100%">
                                                    <Columns>
                                                        <asp:BoundField DataField="ledgername" HeaderStyle-CssClass="disabled" />
                                                        <asp:BoundField DataField="amount" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"
                                                            HeaderStyle-CssClass="disabled" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                            <td runat="server" visible="false" colspan="2">
                                                <asp:GridView ID="gridsummarydetails" CssClass="mGrid" ShowHeader="false" runat="server"
                                                    FooterStyle-BackColor="#d8ff00" AutoGenerateColumns="false" HeaderStyle-CssClass="disabled"
                                                    Width="100%">
                                                    <Columns>
                                                        <asp:BoundField DataField="Name" HeaderStyle-CssClass="disabled" />
                                                        <asp:BoundField DataField="value" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"
                                                            HeaderStyle-CssClass="disabled" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top"  width="30%" id="salespart" runat="server">
                                    <table border="1" width="100%" id="part3" runat="server" class="table">
                                        <thead>
                                            <tr>
                                                <th colspan="2" style="background-color: #007aff; color: white">
                                                    Sales/Order Flow Table
                                                </th>
                                            </tr>
                                        </thead>
                                        <thead>
                                            <tr>
                                                <th colspan="2" style="background-color: #007aff; color: white">
                                                    Normal Sales
                                                </th>
                                            </tr>
                                        </thead>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gvnormalsales" CssClass="mGrid" ShowHeader="false" runat="server"
                                                    FooterStyle-BackColor="#d8ff00" ShowFooter="true" OnRowDataBound="gvnormalsales_rowdatabound"
                                                    AutoGenerateColumns="false" HeaderStyle-CssClass="disabled" Width="100%">
                                                    <Columns>
                                                        <%--<asp:BoundField DataField="paymenttype" HeaderStyle-CssClass="disabled" />--%>
                                                        <asp:BoundField DataField="SalesType" HeaderStyle-CssClass="disabled" />
                                                        <asp:BoundField DataField="Total" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"
                                                            HeaderStyle-CssClass="disabled" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <thead>
                                            <tr>
                                                <th colspan="2" style="background-color: #007aff; color: white">
                                                    Order Form sales
                                                </th>
                                            </tr>
                                        </thead>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gvOrder" CssClass="mGrid" ShowHeader="false" runat="server" AutoGenerateColumns="false"
                                                    FooterStyle-BackColor="#d8ff00" ShowFooter="true" HeaderStyle-CssClass="disabled"
                                                    Width="100%">
                                                    <Columns>
                                                        <asp:BoundField DataField="Paymode" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="disabled" />
                                                        <asp:BoundField DataField="Total" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"
                                                            HeaderStyle-CssClass="disabled" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <thead>
                                            <tr>
                                                <th colspan="2" style="background-color: #007aff; color: white">
                                                    Credit Sales
                                                </th>
                                            </tr>
                                        </thead>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gvcredit" CssClass="mGrid" ShowHeader="false" runat="server" AutoGenerateColumns="false"
                                                    FooterStyle-BackColor="#d8ff00" ShowFooter="true" OnRowDataBound="gvcredit_rowdatabound"
                                                    HeaderStyle-CssClass="disabled" Width="100%">
                                                    <Columns>
                                                        <asp:BoundField DataField="SalesType" HeaderStyle-CssClass="disabled" />
                                                        <asp:BoundField DataField="Total" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"
                                                            HeaderStyle-CssClass="disabled" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <thead>
                                            <tr>
                                                <th colspan="2" style="background-color: #007aff; color: white">
                                                    Cancel Order/Refund Details
                                                </th>
                                            </tr>
                                        </thead>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gvcancelorder" EmptyDataText="No Record Found" CssClass="mGrid"
                                                    ShowHeader="false" runat="server" AutoGenerateColumns="false" FooterStyle-BackColor="#d8ff00"
                                                    ShowFooter="true" OnRowDataBound="gvcancelorder_rowdatabound" HeaderStyle-CssClass="disabled"
                                                    Width="100%">
                                                    <Columns>
                                                        <asp:BoundField DataField="Paymode" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="disabled" />
                                                        <asp:BoundField DataField="Total" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"
                                                            HeaderStyle-CssClass="disabled" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <thead>
                                            <tr>
                                                <th colspan="2" style="background-color: #007aff; color: white">
                                                    Online sales
                                                </th>
                                            </tr>
                                        </thead>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gvonlinesales" CssClass="mGrid" ShowHeader="false" runat="server"
                                                    ShowFooter="true" FooterStyle-BackColor="#d8ff00" OnRowDataBound="gvonlinesales_rowdatabound"
                                                    AutoGenerateColumns="false" HeaderStyle-CssClass="disabled" Width="100%">
                                                    <Columns>
                                                        <asp:BoundField DataField="salestype" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="disabled" />
                                                        <asp:BoundField DataField="paymenttype" HeaderStyle-CssClass="disabled" />
                                                        <asp:BoundField DataField="Total" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"
                                                            HeaderStyle-CssClass="disabled" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <thead>
                                            <tr>
                                                <th colspan="2" style="background-color: #007aff; color: white">
                                                    Sales Return / Deduction Table
                                                </th>
                                            </tr>
                                        </thead>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="gvsalesreturn" CssClass="mGrid" ShowHeader="false" runat="server"
                                                    ShowFooter="true" FooterStyle-BackColor="#d8ff00" OnRowDataBound="gvsalesreturn_rowdatabound"
                                                    AutoGenerateColumns="false" HeaderStyle-CssClass="disabled" Width="100%">
                                                    <Columns>
                                                        <asp:BoundField DataField="reason" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="disabled" />
                                                        <asp:BoundField DataField="Total" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"
                                                            HeaderStyle-CssClass="disabled" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top" rowspan="2" width="100%">
                                    <table class="table" border="1" width="100%" style="border-color: Maroon;" id="deno" runat="server">
                                        <thead>
                                            <tr>
                                                <th colspan="2" style="background-color: #007aff; color: white">
                                                    Over All Denomination Table
                                                    <label id="datetime" runat="server">
                                                    </label>
                                                </th>
                                                <th colspan="2" style="background-color: #007aff; color: white">
                                                    Over Summary View
                                                </th>
                                            </tr>
                                        </thead>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView cssClass="table table-striped table-condensed" ID="griddenomination" Width="100%" runat="server" AutoGenerateColumns="false">
                                                    <Columns>
                                                        <asp:BoundField DataField="Name" HeaderText="" />
                                                        <asp:TemplateField HeaderText="No's">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblnos" Visible="true" runat="server" Text='<%#Eval("Nos")%>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Total">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbltotal" Text='<%#Eval("Total1","{0:f}")%>' runat="server"></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <RowStyle CssClass="RowStyleBackGroundColor" ForeColor="Black" />
                                                    <AlternatingRowStyle CssClass="RowAlternateStyleBackGroundColor" />
                                                </asp:GridView>
                                                <div>
                                                    <label>
                                                        Total Amount :</label>
                                                    <asp:Label ID="lblDenototal" Font-Size="25px" ForeColor="Red" runat="server" Font-Bold="true"></asp:Label>
                                                </div>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lbloverallcard" runat="server" Visible="false">0</asp:Label>
                                                <asp:Label ID="lbloverallpaytm" runat="server" Visible="false">0</asp:Label>
                                                <asp:Label ID="lbloverallphonepe" runat="server" Visible="false">0</asp:Label>
                                                <asp:Label ID="lblcreditamount" runat="server" Visible="false">0</asp:Label>
                                                <asp:GridView cssClass="table table-striped table-condensed" ID="GridsummaryView" Width="100%" runat="server" AutoGenerateColumns="false"
                                                    OnRowDataBound="gridsummary_rowdatabound">
                                                    <Columns>
                                                        <asp:BoundField DataField="Name" HeaderText="" />
                                                        <asp:BoundField DataField="value" HeaderText="" />
                                                    </Columns>
                                                    <RowStyle CssClass="RowStyleBackGroundColor" ForeColor="Black" />
                                                    <AlternatingRowStyle CssClass="RowAlternateStyleBackGroundColor" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="lblErr" runat="server" ForeColor="Red"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr runat="server" visible="false">
                                            <td colspan="4">
                                                <asp:LinkButton ID="linkprint" runat="server" Text="Print" OnClick="linkprint_Click"></asp:LinkButton>
                                            </td>
                                        </tr>
                                        <thead>
                                            <tr>
                                                <th colspan="2" style="background-color: #007aff; color: white">
                                                    Cash To Office
                                                </th>
                                                <th colspan="2" style="background-color: #007aff; color: white">
                                                    Closing Petty Cash
                                                </th>
                                            </tr>
                                        </thead>
                                        <tr>
                                            <td colspan="2">
                                                <div class="form-group">
                                                    <label>
                                                        Select Session Type</label>
                                                    <asp:DropDownList ID="drpsessiontype1" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="table-responsive">
                                                    <asp:GridView cssClass="table table-striped table-condensed" ID="gvdenominationoffice" Width="50%" runat="server" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:BoundField DataField="Name" HeaderText="" />
                                                            <asp:TemplateField HeaderText="No's">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDenominationid" Visible="false" runat="server" Text='<%#Eval("Denominationid")%>'></asp:Label>
                                                                    <asp:Label ID="lblname" Visible="false" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                                    <asp:Label ID="lblvalue" Visible="false" runat="server" Text='<%#Eval("Value")%>'></asp:Label>
                                                                    <asp:TextBox ID="lblnos" runat="server" Enabled="false" onBlur="ResetColor()" onFocus="ChangeColor()"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Total">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <RowStyle CssClass="RowStyleBackGroundColor" ForeColor="Black" />
                                                        <AlternatingRowStyle CssClass="RowAlternateStyleBackGroundColor" />
                                                    </asp:GridView>
                                                </div>
                                                <div>
                                                    <label>
                                                        Total Amount :</label>
                                                    <asp:Label ID="Label10" Font-Size="25px" ForeColor="Red" runat="server" Font-Bold="true"></asp:Label>
                                                </div>
                                            </td>
                                            <td colspan="2">
                                                <div class="form-group">
                                                    <label>
                                                        Select Session Type</label>
                                                    <asp:DropDownList ID="drpsessiontype" runat="server" CssClass="form-control">
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="table-responsive">
                                                    <asp:GridView cssClass="table table-striped table-condensed" ID="gvdenominationcloseing" Width="50%" runat="server" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:BoundField DataField="Name" HeaderText="" />
                                                            <asp:TemplateField HeaderText="No's">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblDenominationid" Visible="false" runat="server" Text='<%#Eval("Denominationid")%>'></asp:Label>
                                                                    <asp:Label ID="lblname" Visible="false" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                                    <asp:Label ID="lblvalue" Visible="false" runat="server" Text='<%#Eval("Value")%>'></asp:Label>
                                                                    <asp:TextBox ID="lblnos" runat="server" Enabled="false" onBlur="ResetColor()" onFocus="ChangeColor()"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Total">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <RowStyle CssClass="RowStyleBackGroundColor" ForeColor="Black" />
                                                        <AlternatingRowStyle CssClass="RowAlternateStyleBackGroundColor" />
                                                    </asp:GridView>
                                                </div>
                                                <div>
                                                    <label>
                                                        Total Amount :</label>
                                                    <asp:Label ID="lblgrandtotalDenomin" Font-Size="25px" ForeColor="Red" runat="server"
                                                        Font-Bold="true"></asp:Label>
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>
                </div>
                <label>
                </label>
                
            </div>
            <div class="col-md-12">
                <div class="table-responsive" id="divPrint" runat="server" visible="false">
                    <table class="table table-bordered table-striped">
                        <tr>
                            <td>
                                <asp:Label ID="lblCaption" runat="server" ForeColor="Red"></asp:Label>
                                <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                <asp:GridView ID="gvCustsales" runat="server" AllowPaging="false" CssClass="" DataKeyNames="BillNo,typeid"
                                    ShowFooter="true" OnRowDataBound="gvCustsales_RowDataBound" AutoGenerateColumns="false"
                                    EmptyDataText="No data found!" ShowHeaderWhenEmpty="True">
                                    <Columns>
                                        <asp:BoundField HeaderText="Bill No" DataField="BillNo" />
                                        <asp:BoundField HeaderText="Bill No" DataField="BillNo" Visible="false" />
                                        <asp:BoundField HeaderText="Branch" DataField="Branch" Visible="false" />
                                        <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" Visible="false" />
                                        <asp:BoundField HeaderText="Bill Date" DataField="BillDate" DataFormatString='{0:dd/MM/yyyy}' />
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
                                    <HeaderStyle BackColor="#428bca" ForeColor="White" />
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Total Net amount:<label id="lblTotal" runat="server"></label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Total Disc amount:<label id="disc" runat="server"></label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Total amount:<label id="gndtotal" runat="server"></label>
                            </td>
                        </tr>
                    </table>
                    <div id="orderformsales" runat="server">
                        <asp:Label ID="lblordermail" runat="server" Text="nknavaneethan4U@gmail.com"></asp:Label>
                        <asp:GridView ID="BankGrid" runat="server" DataKeyNames="billno,Branchcode" Width="100%"
                            AllowSorting="true" Font-Names="Calibri" OnRowDataBound="GridView1_OnRowDataBound"
                            EmptyDataText="No Records Found" AutoGenerateColumns="false">
                            <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                HorizontalAlign="Center" ForeColor="White" />
                            <%--  <HeaderStyle BackColor="#3366FF" />--%>
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
                            <Columns>
                                <asp:BoundField HeaderText="BranchCode" DataField="Branchcode" HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText="Customer Name" DataField="customername" />
                                <asp:BoundField HeaderText="Mobile No" DataField="mobileno" />
                                <asp:BoundField HeaderText="BookNo" DataField="BookNo" />
                                <asp:BoundField HeaderText="OrderNo" DataField="OrderNo" />
                                <asp:BoundField HeaderText="OrderDate" DataField="OrderDate" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField HeaderText="Delivery Date" DataField="deliverydate" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:BoundField HeaderText="Delivery Time" DataField="Deliverytime" HeaderStyle-HorizontalAlign="Center" />
                                <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50%" HeaderText="Item Details"
                                    HeaderStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <a href="javascript:switchViews('dv<%# Eval("BookNo") %>');" style="text-decoration: none;">
                                            <%--<img id="imdiv<%# Eval("BookNo") %>" alt="Show" runat="server"  border="0" src="../images/plus.gif" />--%>
                                        </a>
                                        <div id="dv<%# Eval("BookNo") %>">
                                            <asp:GridView ID="GridView11" runat="server" ShowFooter="true" AutoGenerateColumns="false"
                                                Font-Names="Calibri" EmptyDataText="No Records Found" Width="550px">
                                                <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                                    HorizontalAlign="Center" ForeColor="White" />
                                                <Columns>
                                                    <asp:BoundField DataField="definition" HeaderText="Item Name" />
                                                    <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                                    <asp:BoundField DataField="rate" HeaderText="Rate" DataFormatString='{0:f}' />
                                                    <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString='{0:f}' />
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                        </asp:GridView>
                    </div>
                </div>
                <table>
                    <tr>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvorderinfo" EmptyDataText="Sorry!! No Records Found" runat="server"
                                AutoGenerateColumns="false" Visible="false" cssClass="table table-striped table-hover">
                                <Columns>
                                    <asp:BoundField HeaderText="Delivery Date" DataField="Delivery Date" />
                                    <asp:BoundField HeaderText="Book No" DataField="Book No" />
                                    <asp:BoundField HeaderText="Order No" DataField="Order No" />
                                    <asp:BoundField HeaderText="Order Date" DataField="Order Date" />
                                    <asp:BoundField HeaderText="Customer Name" DataField="Customer Name" />
                                    <asp:BoundField HeaderText="Mobile No" DataField="Mobilno" />
                                    <asp:TemplateField HeaderText="Item">
                                        <ItemTemplate>
                                            <%# Eval("Item").ToString().Replace(",", "<br />")%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString='{0:f2}' />
                                    <asp:BoundField HeaderText="Delivery Status" DataField="Dstatus" />
                                </Columns>
                                <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr runat="server" visible="true">
                        <td>
                            <asp:GridView ID="gvSalesValue" runat="server" AutoGenerateColumns="false" 
                                OnRowDataBound="gvSalesValue_OnRowDataBound" EmptyDataText="No Record found"
                                Width="100%" ShowFooter="true"  cssClass="table table-striped table-hover">
                                <Columns>
                                    <asp:BoundField HeaderText="Branch Code" DataField="Bcode" />
                                    <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString='{0:dd/MM/yyyy}' />
                                    <asp:BoundField HeaderText="GRN Source" DataField="grnsource" />
                                    <asp:BoundField HeaderText="Category" DataField="Category" />
                                    <asp:BoundField HeaderText="Item Name" DataField="Itemname" />
                                    <asp:BoundField HeaderText="GST%" DataField="GST" />
                                    <asp:BoundField HeaderText="Qty" DataField="Qty" DataFormatString="{0:f}" />
                                    <asp:BoundField HeaderText="Rate" DataField="rate" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="Total Rate" DataField="TotalRate" DataFormatString='{0:f}'
                                        ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="Margin%" DataField="Margin" DataFormatString='{0:f}'
                                        ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="Margin Value" DataField="Marginvalue" DataFormatString='{0:f}'
                                        ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="Basic Cost After Margin" DataField="BasicCostAfterMargin"
                                        DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="GST Value" DataField="GSTvalue" DataFormatString='{0:f}'
                                        ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="Net Amount" DataField="NetAmount" DataFormatString='{0:f}'
                                        ItemStyle-HorizontalAlign="Right" />
                                </Columns>
                                <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gvorder_rpt" runat="server" AutoGenerateColumns="false"  cssClass="table table-striped table-hover"
                                OnRowDataBound="gvorder_OnRowDataBound" EmptyDataText="No Record found" Width="100%"
                                ShowFooter="true">
                                <Columns>
                                    <asp:BoundField HeaderText="Branch Code" DataField="Bcode" />
                                    <asp:BoundField HeaderText="Bill No" DataField="BillNo" />
                                    <asp:BoundField HeaderText="Order No" DataField="OrderNo" />
                                    <asp:BoundField HeaderText="Book No" DataField="BookNo" />
                                    <asp:BoundField HeaderText="Order Date" DataField="OrderDate" DataFormatString='{0:dd/MMM/yyyy}' />
                                    <asp:BoundField HeaderText="Payment Date" DataField="Billdate" DataFormatString='{0:dd/MMM/yyyy}' />
                                    <asp:BoundField HeaderText="Order AMOUNT" DataField="NetAmount" DataFormatString="{0:f}" />
                                    <asp:BoundField HeaderText="COST" DataField="COST" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="GST %" DataField="GST" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="Pay Type" DataField="paytype" />
                                    <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="Margin%" DataField="marginvalue" DataFormatString='{0:f}'
                                        ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="Margin Value" DataField="Margin" DataFormatString='{0:f}'
                                        ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="Basic Cost After Margin" DataField="castbeforemargin"
                                        DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="GST Value" DataField="GSTV" DataFormatString='{0:f}'
                                        ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="Net Amount" DataField="NetamountV" DataFormatString='{0:f}'
                                        ItemStyle-HorizontalAlign="Right" />
                                </Columns>
                                <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td colspan="4" align="right">
                            Sales Exempted :
                            <asp:Label ID="lblsalesexempted" runat="server">0.00</asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td colspan="4" align="right">
                            Taxable Sales :
                            <asp:Label ID="lbltaxablesales" runat="server">0.00</asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td colspan="4" align="right">
                            GST :
                            <asp:Label ID="lblcgst" runat="server">0.00</asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td colspan="4" align="right">
                            SGST :
                            <asp:Label ID="lblsgst" runat="server">0.00</asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td colspan="4" align="right">
                            NET AMOUNT :
                            <asp:Label ID="lblnetamount" runat="server">0.00</asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td colspan="4" align="right">
                            Round Off :
                            <asp:Label ID="lblroundoff" runat="server">0.00</asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td colspan="4" align="right">
                            FINAL AMOUNT :
                            <asp:Label ID="lblfinalamount" runat="server">0.00</asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td>
                            <asp:GridView ID="gvorder1" runat="server" AutoGenerateColumns="false"  cssClass="table table-striped table-hover"
                                EmptyDataText="No Record found" Width="100%" ShowFooter="true">
                                <Columns>
                                    <asp:BoundField HeaderText="Branch Code" DataField="Bcode" />
                                    <asp:BoundField HeaderText="Bill No" DataField="BillNo" />
                                    <asp:BoundField HeaderText="Order No" DataField="OrderNo" />
                                    <asp:BoundField HeaderText="Book No" DataField="BookNo" />
                                    <asp:BoundField HeaderText="Order Date" DataField="OrderDate" DataFormatString='{0:dd/MM/yyyy}' />
                                    <asp:BoundField HeaderText="Payment Date" DataField="Billdate" DataFormatString='{0:dd/MM/yyyy}' />
                                    <asp:BoundField HeaderText="Order AMOUNT" DataField="NetAmount" DataFormatString="{0:f}" />
                                    <asp:BoundField HeaderText="COST" DataField="COST" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="GST %" DataField="GST" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="Pay Type" DataField="paytype" />
                                    <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="Margin%" DataField="marginvalue" DataFormatString='{0:f}'
                                        ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="Margin Value" DataField="Margin" DataFormatString='{0:f}'
                                        ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="Basic Cost After Margin" DataField="castbeforemargin"
                                        DataFormatString='{0:f}' ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="GST Value" DataField="GSTV" DataFormatString='{0:f}'
                                        ItemStyle-HorizontalAlign="Right" />
                                    <asp:BoundField HeaderText="Net Amount" DataField="NetamountV" DataFormatString='{0:f}'
                                        ItemStyle-HorizontalAlign="Right" />
                                </Columns>
                                <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td colspan="4" align="right">
                            Taxable Sales :
                            <asp:Label ID="lbltaxablesalesorder" runat="server">0.00</asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td colspan="4" align="right">
                            GST :
                            <asp:Label ID="lblcgstorder" runat="server">0.00</asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td colspan="4" align="right">
                            SGST :
                            <asp:Label ID="lbl6" runat="server">0.00</asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td colspan="4" align="right">
                            NET AMOUNT :
                            <asp:Label ID="lblnetamountorder" runat="server">0.00</asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td colspan="4" align="right">
                            Round Off :
                            <asp:Label ID="lblroundofforder" runat="server">0.00</asp:Label>
                        </td>
                    </tr>
                    <tr runat="server" visible="false">
                        <td colspan="4" align="right">
                            FINAL AMOUNT :
                            <asp:Label ID="lblfinalamountorder" runat="server">0.00</asp:Label>
                        </td>
                    </tr>
                </table>
                <div title="What's Your Name" id="popup" class="messagepop">
                    <a onclick="klose();" class="ui-btn ui-corner-all ui-shadow ui-btn ui-icon-delete ui-btn-icon-notext ui-btn-right">
                        Close</a> Enter Your Name
                    <asp:TextBox ID="txtnam" runat="server" Style="background-color: White; color: #e84c3d"></asp:TextBox>
                    <a onclick="hide();" style="color: White">OK</a>
                    <p>
                        Fill your Name Press Ok and Click Day Close Button</p>
                </div>
            </div>
        </div>
      
            </ContentTemplate>
            <Triggers>
            </Triggers>
        </asp:UpdatePanel>
    </div>    
    </form>
</body>
</html>
