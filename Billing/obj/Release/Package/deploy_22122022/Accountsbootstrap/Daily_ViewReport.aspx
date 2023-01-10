<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Daily_ViewReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.Daily_ViewReport" %>

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
    </style>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <title>Daily Report</title>
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

            sub.style.display = "none";
            send.style.display = "none";
            print.style.display = "none";

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
            alert('Thank You !');
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
            <div id="A4" runat="server" title="">
                <div>
                    <div class="row">
                        <div class="col-lg-12">
                            <label>
                                Daily View Report</label>
                            <h4>
                                <label id="lblvil" runat="server">
                                </label>
                            </h4>
                        </div>
                        <div class="col-lg-12">
                            <div class="col-lg-4">
                                Select Store:
                                <asp:DropDownList ID="DDlbranch" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DDlbranch_SelectedIndexChanged">
                                    <%--<asp:ListItem Selected="True" Text="KK nagar" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Bye Pass" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="BBKulam" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Narayanapuram" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Nellai" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Maduravayol" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="Purasavakkam" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="Chennai Pothys" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="Thirunelveli" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="Periyar" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="Palayam" Value="11"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-8">
                                Select Date:<asp:TextBox ID="date" runat="server" AutoPostBack="true" CssClass="cal_Theme1"
                                    OnTextChanged="date_TextChanged"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="date" Format="yyyy-MM-dd">
                                </ajaxToolkit:CalendarExtender>
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-info" OnClick="btnSubmit_Click" />
                                <asp:Button ID="Button1" runat="server" Text="Send Mail" CssClass="btn btn-info"
                                    OnClick="btnMail_Click" />
                                <asp:Button ID="Button2" runat="server" Text="Print" CssClass="btn btn-info" OnClientClick=" printGrid()" />
                                <asp:Button ID="btnsession" runat="server" Text="Close Day" UseSubmitBehavior="false"
                                    OnClientClick="ClientSideClick(this)" Visible="false" CssClass="btn-danger" OnClick="btnsession_Click" />
                                <div class="box">
                                    <asp:TextBox ID="txtName" runat="server" Placeholder="Enter Your Name"></asp:TextBox>
                                    <asp:RequiredFieldValidator ErrorMessage="Name is Required " ForeColor="Red" ControlToValidate="txtName"
                                        ID="val" runat="server" ValidationGroup="val1"></asp:RequiredFieldValidator>
                                    <asp:Button ID="Button3" runat="server" Text="Close Session" UseSubmitBehavior="false"
                                        OnClientClick="ClientSideClick(this)" CssClass="btn-info" OnClick="Button3_Click"
                                        ValidationGroup="val1" />
                                </div>
                            </div>
                            <asp:Button ID="Print" runat="server" Text="Print" CssClass="btn btn-info" OnClick="Print_Click"
                                Style="display: none" /></div>
                    </div>
                    <!-- /.col-lg-12 -->
                </div>
                <table border="1" align="center" runat="server" visible="true">
                    <tr>
                        <td valign="top" width="30%">
                            <table width="100%" border="1" runat="server" visible="true">
                                <thead>
                                    <tr>
                                        <th colspan="2" style="background-color: #5bc0de; color: white">
                                            Cash Flow Table
                                        </th>
                                    </tr>
                                </thead>
                                <tr>
                                    <td>
                                        Cash to Office
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblCash_handover_amt" runat="server" CssClass="form-control" placeholder="0.00"
                                            Text="0.00" Width="88px" OnTextChanged="lblCash_handover_amt_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                    <%--   <td><asp:Label ID="lblCash_handover_amt" runat="server">0</asp:Label><td><--%>
                                </tr>
                                <tr id="petty" runat="server">
                                    <td>
                                        <asp:Label ID="lblCash_Closing" runat="server">Closing Petty Cash</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCash_Closing_Amt" runat="server">0.00</asp:Label><%--(Denomination-C.H.O.)--%>
                                    </td>
                                </tr>
                                <tr id="exp" runat="server">
                                    <td>
                                        <asp:Label ID="lblTotal_Exp" runat="server">Total Expenses</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblTotal_Exp_Amt" runat="server">0.00</asp:Label><%--(Expense Table)--%>
                                    </td>
                                </tr>
                                <tr id="cardsales" runat="server">
                                    <td>
                                        <asp:Label ID="lblCredit_Sales" runat="server">Card Sales</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCreditcard_Sales" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr id="grosstot" runat="server">
                                    <td style="background-color: #fa8072">
                                        <asp:Label ID="lblSales_Gross" runat="server">Gross Total</asp:Label>
                                    </td>
                                    <td style="background-color: #fa8072">
                                        <asp:Label ID="lblSales_Gross_amt" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblOP_Cash" runat="server">OP Cash</asp:Label>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="lblOP_Cash_Amt" runat="server" CssClass="form-control" placeholder="Enter Amt"
                                            Text="0.00" Width="88px" AutoPostBack="true" OnTextChanged="lblOP_Cash_Amt_TextChanged"></asp:TextBox>
                                    </td>
                                    <%-- <td><asp:Label ID="lblOP_Cash_Amt" runat="server">0</asp:Label></td>--%>
                                </tr>
                                <tr id="crSale" runat="server">
                                    <td>
                                        <label>
                                            Credit Sales</label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCredit_Sales_Amt" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr id="nsales" runat="server">
                                    <td style="background-color: #fa8072">
                                        <asp:Label ID="lblNet_Sales" runat="server">Net Sales</asp:Label>
                                    </td>
                                    <td style="background-color: #fa8072">
                                        <asp:Label ID="lblNet_Sales_Amt" runat="server">0.00</asp:Label><%--(Gross-OP Cash)--%>
                                    </td>
                                </tr>
                                <tr id="hens" runat="server">
                                    <td>
                                        <asp:Label ID="lblSales_Result" runat="server">Hence sales Diffrence +/-</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSales_Result_amt" runat="server">0.00</asp:Label><%--(Gross Sales-Net Sales)--%>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" style="padding-left: 10px" width="30%" id="salespart" runat="server">
                            <table border="1" width="80%" id="part3" runat="server">
                                <thead>
                                    <tr>
                                        <th colspan="2" style="background-color: #5bc0de; color: white">
                                            Sales Flow Table
                                        </th>
                                    </tr>
                                </thead>
                                <tr>
                                    <td colspan="2" style="background-color: Green; color: White">
                                        <label style="font-weight: bolder">
                                            Normal sales</label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCash_sales" runat="server">Cash Sales</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCash_sales_Amt" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="gvnormalsales" CssClass="mGrid" ShowHeader="false" runat="server"
                                            AutoGenerateColumns="false" HeaderStyle-CssClass="disabled" Width="100%">
                                            <Columns>
                                            
                                            <asp:BoundField DataField="paymenttype" HeaderStyle-CssClass="disabled" />
                                                <asp:BoundField DataField="SalesType" HeaderStyle-CssClass="disabled" />
                                                <asp:BoundField DataField="Total" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"
                                                    HeaderStyle-CssClass="disabled" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: Red; color: White" colspan="2">
                                        <label style="font-weight: bolder">
                                            Order Form sales</label>
                                    </td>
                                </tr>
                                <tr runat="server" visible="false">
                                    <td>
                                        <asp:Label ID="lblOrder_sales" runat="server">Order Form Sales</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblOrder_sales_amt" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr runat="server" visible="false">
                                    <td>
                                        <asp:Label ID="Label4" runat="server">Order Form Card Sales</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblordercard" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr runat="server" visible="false">
                                    <td>
                                        <asp:Label ID="Label6" runat="server">Order Form Add Amount</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblAdd" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr runat="server" visible="false">
                                    <td>
                                        <asp:Label ID="Label8" runat="server">Order Form Less Amount</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblLess" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <asp:GridView ID="gvOrder" CssClass="mGrid" ShowHeader="false" runat="server" AutoGenerateColumns="false"
                                            HeaderStyle-CssClass="disabled" Width="100%">
                                            <Columns>
                                                <asp:BoundField DataField="Paymode" ItemStyle-HorizontalAlign="Right" HeaderStyle-CssClass="disabled" />
                                                <asp:BoundField DataField="PayType" HeaderStyle-CssClass="disabled" />
                                                <asp:BoundField DataField="Total" DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right"
                                                    HeaderStyle-CssClass="disabled" />
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #fa8072">
                                        <asp:Label ID="lbl_Total_Sales" runat="server">Total Sales</asp:Label>
                                    </td>
                                    <td style="background-color: #fa8072" align="right">
                                        <asp:Label ID="lbl_Total_Sales_Amt" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblSales_deductions" runat="server">Stock Wastage</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblSales_deductions_amt" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td style="background-color: #fa8072">
                                        <asp:Label ID="lblGross_sales" runat="server"></asp:Label>
                                    </td>
                                    <td style="background-color: #fa8072">
                                        <asp:Label ID="lblGross_sales_amt" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td valign="top" rowspan="2" width="30%">
                            <table border="1" width="70%" style="border-color: Maroon;" id="deno" runat="server">
                                <thead>
                                    <tr>
                                        <th colspan="3" style="background-color: #5bc0de; color: white">
                                            Denomination Table
                                            <label id="datetime" runat="server">
                                            </label>
                                        </th>
                                    </tr>
                                </thead>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label1" runat="server">2000</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl2000_no" runat="server">0.00</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl2000s" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label3" runat="server">500</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl500s_no" runat="server">0.00</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl500s" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                 <tr>
                                    <td>
                                        <asp:Label ID="Label10" runat="server">200</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl200s_no" runat="server">0.00</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl200s" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label5" runat="server">100</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl100s_no" runat="server">0.00</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl100s" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label7" runat="server">50</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl50s_no" runat="server">0.00</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl50s" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label9" runat="server">20</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl20s_no" runat="server">0.00</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl20s" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label11" runat="server">10</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl10s_no" runat="server">0.00</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl10s" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label13" runat="server">5</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl5s_no" runat="server">0.00</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl5s" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label15" runat="server">2</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl2s_no" runat="server">0.00</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl2s" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label17" runat="server">1</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl1s_no" runat="server">0.00</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbl1s" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="Label19" runat="server">Coins(50p)</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblcoinss_no" runat="server">0.00</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblcoinss" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #fa8072">
                                        <asp:Label ID="Label2" runat="server">Total</asp:Label>
                                    </td>
                                    <td>
                                    </td>
                                    <td style="background-color: #fa8072">
                                        <asp:Label ID="lblTotal_Denominations" runat="server">0</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="lblErr" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:LinkButton ID="linkprint" runat="server" Text="Print" OnClick="linkprint_Click"></asp:LinkButton>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td valign="top" id="part1" runat="server">
                            <table>
                                <thead>
                                    <tr>
                                        <th colspan="2" style="background-color: #5bc0de; color: white">
                                            Expenses Table
                                        </th>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Panel ID="pnlTextBoxes" runat="server" Width="186px">
                                            </asp:Panel>
                                        </td>
                                        <td>
                                            <asp:Panel ID="pnlTextBoxes1" Width="186px" runat="server">
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="background-color: #fa8072">
                                            <asp:Label ID="lblTotal_Exp1" runat="server">Total</asp:Label>
                                        </td>
                                        <td style="background-color: #fa8072">
                                            <asp:Label ID="lblTotal_Exp_Amt1" runat="server">0.00</asp:Label>
                                        </td>
                                    </tr>
                                </thead>
                            </table>
                        </td>
                        <td valign="top" style="padding-left: 10px" id="part2" runat="server">
                            <table border="1" width="80%">
                                <thead>
                                    <tr>
                                        <th colspan="2" style="background-color: #5bc0de; color: #e84c3d">
                                            Sales Deduction Table
                                        </th>
                                    </tr>
                                </thead>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDate_Bar" runat="server">Date Bar</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDate_Bar_amt" runat="server">0.0000</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblMissing" runat="server">Missing</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblMissing_amt" runat="server">0.0000</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblCompliment" runat="server">Compliment</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblCompliment_salesdeduction_amt" runat="server">0.0000</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblWastage" runat="server">Wastage</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblWastage_amt" runat="server">0.0000</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="labelexves" runat="server">Excess</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblExcess" runat="server">0.00</asp:Label>
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td>
                                        <asp:Label ID="lblNP_Byepass" runat="server">NP to Byepass</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblNP_Byepass_amt" runat="server">0.0000</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblDamage" runat="server">Damage</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblDamage_amt" runat="server">0.0000</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblProduct_change" runat="server">Product Change</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblProduct_change_amt" runat="server">0.0000</asp:Label>
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td>
                                        <asp:Label ID="lblBNP_Byepass" runat="server">BNP to Byepass</asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="lblBNP_Byepass_amt" runat="server">0.0000</asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="bbkulamm" Text="" runat="server"> </asp:Label>
                                    </td>
                                    <td>
                                        <asp:Label ID="bbkulamamount" runat="server">0.0000 </asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="background-color: #fa8072">
                                        <asp:Label ID="lblSales_Deduction1" runat="server">Total</asp:Label>
                                    </td>
                                    <td style="background-color: #fa8072">
                                        <asp:Label ID="lblSales_Deduction_amt1" runat="server">0.0000</asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div title="What's Your Name" id="popup" class="messagepop">
                <a onclick="klose();" class="ui-btn ui-corner-all ui-shadow ui-btn ui-icon-delete ui-btn-icon-notext ui-btn-right">
                    Close</a> Enter Your Name
                <asp:TextBox ID="txtnam" runat="server" Style="background-color: White; color: #e84c3d"></asp:TextBox>
                <a onclick="hide();" style="color: White">OK</a>
                <p>
                    Fill your Name Press Ok and Click Day Close Button</p>
            </div>
            <div>
            </div>
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
