<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TwoReports.aspx.cs" Inherits="Billing.Accountsbootstrap.TwoReports" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Sales Report </title>
    <style type="text/css">
        .GroupHeaderStyle
        {
            background-color: #afc3dd;
            color: Black;
            font-weight: bold;
            text-transform: uppercase;
        }
        .SubTotalRowStyle
        {
            background-color: #cccccc;
            color: Black;
            font-weight: bold;
        }
        .GrandTotalRowStyle
        {
            background-color: #000000;
            color: white;
            font-weight: bold;
        }
        .align1
        {
            text-align: right;
        }
        
        .mGrid1 tr th
        {
            padding: 8px;
            color: #afc3dd;
            background-color: #000000;
            border: 1px solid gray;
            font-family: Arial;
            font-weight: bold;
            text-align: center;
            text-transform: uppercase;
        }
        
        
        
        
        
        .mGrid1 tr:nth-child(even)
        {
            background-color: #ffffff;
        }
        
        
        
        .mGrid1 tr:nth-child(odd)
        {
            background-color: #ffffff;
        }
        
        
        
        .mGrid1 td
        {
            border: 1px solid gray;
            padding: 8px;
        }
    </style>
    <!-- Start Styles. Move the 'style' tags and everything between them to between the 'head' tags -->
    <script type="text/javascript">
        function Denomination() {


            var gridData = document.getElementById('<%=readingreport.ClientID %>');


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
        function Denomination1() {


            var gridData = document.getElementById('<%=consilidated.ClientID %>');


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
          function Denomination2() {


              var gridData = document.getElementById('<%=divDepartment.ClientID %>');


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


    

    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!--<link href="../Styles/style1.css" rel="stylesheet"/>-->
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
</head>
<body>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header" style="text-align: center">
                Report Grid</h1>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <form id="form1" runat="server">
                            <asp:UpdatePanel ID="update" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="row">
                                        <div class="col-lg-4">
                                        </div>
                                        <div class="col-lg-2">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                            <div class="form-group">
                                                <asp:Label ID="lblFromDate" runat="server">From Date</asp:Label>
                                                <asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="true" CssClass="form-control center-block"
                                                    OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="MM/dd/yyyy" TargetControlID="txtFromDate"
                                                    runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <asp:Label ID="lblToDate" runat="server">To Date</asp:Label>
                                                <asp:TextBox ID="txtToDate" runat="server" AutoPostBack="true" CssClass="form-control center-block"
                                                    OnTextChanged="txtToDate_TextChanged"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="MM/dd/yyyy" TargetControlID="txtToDate"
                                                    runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="col-lg-4">
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div id="Div1" runat="server" visible="false" class="col-lg-2">
                                            <div id="Div2" runat="server" visible="false" class="form-group">
                                                <asp:RadioButton ID="rdbCustomer" runat="server" Text="Reading Report" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rdbCustomer_CheckedChanged" />
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div id="Div3" runat="server" visible="false" class="form-group">
                                                <asp:RadioButton ID="rbdPayMode" runat="server" Text="Payment Mode" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdPayMode_CheckedChanged" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <asp:RadioButton ID="rbproqty" runat="server" Text="Reading Report" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="reading_checked" />
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="form-group">
                                                <asp:RadioButton ID="rbdcatqty" runat="server" Text="Consoildated Report" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="consoildated_Checked" />
                                            </div>
                                        </div>

                                            <div class="col-lg-3">
                                            <div id="Div6" runat="server" visible="true" class="form-group">
                                                <asp:RadioButton ID="rbdepartment" runat="server" Text="Category Wise Report" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdepartment_CheckedChanged" />
                                            </div>
                                        </div>

                                        <div class="col-lg-2" style=" display:none">

                                            <div runat="server" visible="false" class="form-group">
                                                <asp:RadioButton ID="rbdCtry" runat="server" Text="Category" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdCtry_CheckedChanged" />
                                            </div>
                                        </div>
                                        <div class="col-lg-2" style=" display:none">
                                            <div runat="server" visible="true" class="form-group">
                                                <asp:RadioButton ID="rbdProduct" runat="server" Text="Product" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdProduct_CheckedChanged" />
                                            </div>
                                        </div>
                                        <div runat="server" visible="false" class="col-lg-2">
                                            <div id="Div4" runat="server" visible="false" class="form-group">
                                                <asp:RadioButton ID="rbdBrnd" runat="server" Text="Brand" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdBrnd_CheckedChanged" />
                                            </div>
                                        </div>
                                    
                                    </div>
                                    <div id="readingreport" visible="false" runat="server" class="row">
                                    <div id="Div5" runat="server" align="center">
                                    <asp:Label ID="lblcompanyname" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblcompanyarea" runat="server">Golden Shopping Mall,</asp:Label><br />
                                    <asp:Label ID="lblcompanyaddress" runat="server">Mandapam Road,Ramanad</asp:Label><br />
                                    -----------------------------------------------------------------------------<br />
                                    <asp:Label ID="Label23" runat="server" >*** Sales Report ***</asp:Label><br />
                                    ----------------------------------------------------------------------------- <br />
                                    From date :<asp:label ID="llbfrmdt" runat="server"></asp:label> to <asp:label ID="llbtodt" runat="server"></asp:label>
                                    </div>
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                Cashier Name :
                                                <asp:Label ID="lbluse" runat="server"></asp:Label><br />
                                                X-Readings Report <br /> Mode : Shift END <br /> Bill Range :
                                                <asp:Label ID="lblstart" runat="server"></asp:Label>
                                                To
                                                <asp:Label ID="lblend" runat="server"></asp:Label>
                                                <br />
                                                ------------------------------------------------------------------------------------- <br />
                                                Opening Balance: 0.00 <br /> -------------------------------------------------------------------------------------<br />
                                                Income <br /> Baisc Sales (Excl of Tax) :
                                                <asp:Label ID="lblamount" runat="server"></asp:Label><br />
                                                (-) Discount:<label id="lblDiscount" runat="server"></label><br />
                                                (+) CGST :<label id="lblTax" runat="server"></label><br />
                                                (+) SGST :<label id="lblserviceTax" runat="server"></label><br />
                                                ---------------------------------------------------------------------------<br /> NetSales
                                                (Incl Tax) :
                                                <asp:Label ID="lblbtotal" runat="server"></asp:Label><br />
                                                --------------------------------------------------------------------------- <br />
                                                (-) Expense :<asp:Label ID="lblexpense" runat="server">0.00</asp:Label> <br /> (+) Total Receipts : 0.00 <br /> --------------------------------------------------------------------------
                                                --------------------------------------------------------------------------<br />
                                                 Balance: <asp:Label ID="lbltotalbal" runat="server"></asp:Label><br />
                                                Declared : <asp:Label ID="lbldenodeclared" runat="server"></asp:Label><br />
                                                
                                                --------------------------------------------------------------------------------------------------------------------------------------------------<br />
                                                Collection Short By :
                                                <asp:Label ID="lblshortbal" runat="server"></asp:Label><br />
                                                Closing Balance :
                                                <asp:Label ID="lblclosingbal" runat="server"></asp:Label><br />
                                                ----------------------------------------------------------------------------------------------------------------------------------------------------------<br />
                                                                                                            
                                                                                                            *** Currency Declaration ***<br />
                                                -----------------------------------------------------------------------------------------------------------------------------------------------------------<br />
                                                <table border="1" width="30%" style="border-color: Maroon;">
                                                    <thead>
                                                        <tr>
                                                            <th colspan="3" style="background-color: #5bc0de; color: white">
                                                                Denomination Table
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
                                                            <asp:Label ID="lblTotal_Denominations" runat="server">xxxxx</asp:Label>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td colspan="3">
                                                            <asp:Label ID="lblErr" runat="server" ForeColor="Red"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </table>
                                                ---------------------------------------------------------------------------------
                                                Current Shift PaymentWise Sales
                                                ---------------------------------------------------------------------------------
                                                 <asp:GridView ID="gridpayment" Width="100%" runat="server" EmptyDataText="Sorry Data Not Found!"
                                                                CssClass="mGrid1" AutoGenerateColumns="false" >
                                                                <Columns>
                                                                   <asp:BoundField DataField="Paycode" HeaderText="PAY CODE" />
                                                                   <asp:BoundField DataField="Name" HeaderText=" Name" />
                                                                   <asp:BoundField DataField="Bills" HeaderText="Bills" />
                                                                   <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:n}" />
                                                                </Columns>
                                                            </asp:GridView>
                                                            <div id="DivAllShiftDetails" runat="server" visible="false">
                                             ---------------------------------------------------------------------------------------
                                             All Shifts PaymentWise Sales
                                             ---------------------------------------------------------------------------------------
                                             <asp:GridView ID="gridAllpayment" Width="100%" runat="server" EmptyDataText="Sorry Data Not Found!"
                                                                CssClass="mGrid1" AutoGenerateColumns="false" >
                                                                <Columns>
                                                                   <asp:BoundField DataField="Paycode" HeaderText="PAY CODE" />
                                                                   <asp:BoundField DataField="Name" HeaderText=" Name" />
                                                                   <asp:BoundField DataField="Bills" HeaderText="Bills" />
                                                                   <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:f}" />
                                                                </Columns>
                                                            </asp:GridView>
                                                            </div>
                                            </div>
                                        </div>
                                        <asp:Button ID="btnprint" runat="server" Text="Print" Style="background-color: Teal;
                                                    color: White; width: 100px; height: 40px" OnClientClick="Denomination() ;" />
                                    </div>



                                     <div id="consilidated" visible="false" runat="server" class="row">
                                      <div id="dd" runat="server" align="center">
                                    <asp:Label ID="lblcompanyname1" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblcompanyarea1" runat="server"></asp:Label><br />
                                    <asp:Label ID="lblcompanyaddress1" runat="server"></asp:Label><br />
                                    -----------------------------------------------------------------------------<br />
                                    <asp:Label ID="Label6" runat="server" >*** Sales Report ***</asp:Label><br />
                                    ----------------------------------------------------------------------------- <br />
                                    From date :<asp:label ID="lblfromdt" runat="server"></asp:label> to <asp:label ID="lbltodt" runat="server"></asp:label>
                                    </div>
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                Cashier Name :
                                                <asp:Label ID="lblcasherr" runat="server"></asp:Label><br />
                                                Z-Consolidated Report <br />
                                                 Mode : Day END<br />
                                                ------------------------------------------------------------------------------------- <br />
                                                CASH AND SALE SUMMARY<br />
                                                (+) Float (Day OB) 0.00 <br />
                                                
                                                Baisc Sales (Excl of Tax) :
                                                <asp:Label ID="lblbasic1" runat="server"></asp:Label><br />
                                                 (-) Return:<label id="lblreturn1"  runat="server"></label><br />
                                                (-) Discount:<label id="lbldiscount1" runat="server"></label><br />
                                                (+) CGST Amount:<label id="lbltax1" runat="server"></label><br />
                                                (+) SGST Amount:<label id="lblservice1" runat="server"></label><br />
                                                ---------------------------------------------------------------------------<br /> NetSales
                                                (Incl Tax) :
                                                <asp:Label ID="lblnet1" runat="server"></asp:Label><br />
                                                --------------------------------------------------------------------------- <br />
                                                (-) Expense : <asp:label id="lblconsuldateexpense" runat="server"></asp:label> <br /> (+) Total Receipts : 0.00 <br /> --------------------------------------------------------------------------
                                                --------------------------------------------------------------------------<br />
                                               
                                               
                                                Total Collection :
                                                <asp:Label ID="lbltot1" runat="server"></asp:Label><br />
                                                 --------------------------------------------------------------------------------------------------------------------------------------------------<br />

                                                Closing Total :
                                                <asp:Label ID="lblclose1" runat="server"></asp:Label><br />
                                                ----------------------------------------------------------------------------------------------------------------------------------------------------------<br />
                                                No . of Item Sold : <asp:Label ID="lblItemsold" runat="server"></asp:Label><br />
                                                No . of Bills Made : <asp:Label ID="lblbillmade" runat="server"></asp:Label><br />
                                                No . of Void Items : <asp:Label ID="Label8" Text="0" runat="server"></asp:Label><br />
                                                No . of No-Sale Done : <asp:Label ID="Label10" Text="0" runat="server"></asp:Label><br />
                                                No . of Price OverRides : <asp:Label ID="Label12" Text="0" runat="server"></asp:Label><br />
                                                No . of Line Discount : <asp:Label ID="Label14" Text="0" runat="server"></asp:Label><br />
                                                No . of Customers : <asp:Label ID="Label16" Text="0" runat="server"></asp:Label><br />
                                                ---------------------------------------------------------------------------------<br />
                                                Shift Details<br />
                                                ---------------------------------------------------------------------------------<br />
                                                Cashier Name : <asp:Label ID="lblUname1" runat="server"></asp:Label><br />
                                                -----------------------<br />
                                                Starting Time : <asp:Label ID="lblstarttime" runat="server"></asp:Label><br />
                                                Ending Time : <asp:Label ID="lblendtime" runat="server"></asp:Label><br />
                                                Opening Balance : <asp:Label id="lblopbal" Text="0" runat="server"></asp:Label><br />
                                                Total Income : <asp:Label ID="lbltotals1" runat="server"></asp:Label><br />
                                                Expense : <asp:Label ID="lblexp" Text="0" runat="server"></asp:Label><br />
                                                Receipts : <asp:Label ID="Label21" Text="0" runat="server"></asp:Label><br />
                                                Net Income : <asp:Label ID="lblnett2" runat="server"></asp:Label><br />
                                                Declaration : <asp:Label ID="lbldeclar" runat="server"></asp:Label><br />
                                                Closing Balance : <asp:Label ID="lblclos" runat="server"></asp:Label><br />
                                                Difference : <asp:Label ID="lbldiff" runat="server"></asp:Label><br />
                                             ---------------------------------------------------------------------------------------<br />
                                                Bill Range :<br />
                                                <asp:Label ID="lblstrt1" runat="server"></asp:Label><br />
                                                To
                                                <asp:Label ID="lbllast1" runat="server"></asp:Label><br />
                                                <br />
                                             ---------------------------------------------------------------------------------------<br />
                                             All Shifts PaymentWise Sales<br />
                                             ---------------------------------------------------------------------------------------<br />
                                             <asp:GridView ID="gridlastpyament" Width="100%" runat="server" EmptyDataText="Sorry Data Not Found!"
                                                                CssClass="mGrid1" AutoGenerateColumns="false" >
                                                                <Columns>
                                                                   <asp:BoundField DataField="Paycode" HeaderText="PAY CODE" />
                                                                   <asp:BoundField DataField="Name" HeaderText=" Name" />
                                                                   <asp:BoundField DataField="Bills" HeaderText="Bills" />
                                                                   <asp:BoundField DataField="Amount" HeaderText="Amount" DataFormatString="{0:f}" />
                                                                </Columns>
                                                            </asp:GridView>
                                            </div>
                                        </div>
                                        <asp:Button ID="Button1" runat="server" Text="Print" Style="background-color: Teal;
                                                    color: White; width: 100px; height: 40px" OnClientClick="Denomination1() ;" />
                                    </div>





                                    <div runat="server" id="divDepartment" visible="false" class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive">
                                                <table class="table table-bordered table-striped">
                                                    <tr>
                                                        <td>
                                                            <asp:GridView ID="gridPurchase" Width="100%" runat="server" EmptyDataText="Sorry Data Not Found!"
                                                                CssClass="mGrid1" AutoGenerateColumns="false" OnRowCreated="gridPurchase_RowCreated"
                                                                OnRowDataBound="gridPurchase_RowDataBound">
                                                                <Columns>
                                                                    <asp:BoundField DataField="BillNo" Visible="false" />
                                                                    <asp:BoundField DataField="BillNo" HeaderText="Bill No" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField DataField="BillDate" HeaderText="Bill Date" ItemStyle-HorizontalAlign="Center"
                                                                        DataFormatString="{0:MM-dd-yyyy}" />
                                                                    <asp:BoundField DataField="LedgerName" HeaderText="Customer" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField DataField="Payment_Mode" HeaderText="Payment Mode" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField DataField="category" HeaderText="Category" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField DataField="Definition" HeaderText="Item" ItemStyle-HorizontalAlign="Center" />
                                                                    <%-- <asp:BoundField DataField="BrandName" HeaderText="Brand Name" ItemStyle-HorizontalAlign="Center" />--%>
                                                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" ItemStyle-HorizontalAlign="Right" />
                                                                    <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:###,##0.00}"
                                                                        Visible="false" ItemStyle-HorizontalAlign="Right" />
                                                                    <asp:BoundField DataField="NetAmount" HeaderText="Amount" ItemStyle-HorizontalAlign="Right" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </td>
                                                    </tr>
                                                </table>
                                                 <label>Item Wise</label>
                                                <asp:GridView ID="gridcatqty" Width="100%" runat="server" OnRowDataBound="gridcatqty_RowDataBound" EmptyDataText="Sorry Data Not Found!"
                                                    CssClass="mGrid1" AutoGenerateColumns="false">
                                                    <Columns>
                                                         <asp:BoundField DataField="item" HeaderText="ItemName" />
                                    
                                    <asp:BoundField DataField="Qty" HeaderText="Quantity" ItemStyle-HorizontalAlign="Right" />
                                     <asp:BoundField DataField="rec" HeaderText="Actual Qty" ItemStyle-HorizontalAlign="Right" />
                                                    </Columns>
                                                </asp:GridView>
                                                <div id="printss" runat="server">
                                               
                                                    <asp:GridView ID="gvdepartment" Width="100%" runat="server" EmptyDataText="Sorry Data Not Found!"
                                                        CssClass="mGrid1" AutoGenerateColumns="false" OnRowDataBound="gvdepartment_RowDataBound"
                                                        OnRowCreated="gvdepartment_RowCreated">
                                                        <Columns>
                                                            <asp:BoundField DataField="Item" HeaderStyle-Width="20%" HeaderText="ItemName" />
                                                            <asp:BoundField DataField="Qty" HeaderStyle-Width="10%" HeaderText="Quantity" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField DataField="Rate" HeaderText="Rate" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:f}" />
                                                            <asp:BoundField DataField="Amount" HeaderText="Amount" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="left" DataFormatString="{0:f}" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    <label>
                                                        *** Sales Contribution Percentage ***</label>
                                                    <asp:GridView ID="gridcontribution" Width="100%" OnRowDataBound="gridContri_RowDataBound"
                                                        runat="server" EmptyDataText="Sorry Data Not Found!" ShowFooter="true" CssClass="mGrid1"
                                                        AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:BoundField DataField="Department" HeaderStyle-Width="20%" HeaderText="ItemName" />
                                                            <asp:BoundField DataField="Total" HeaderStyle-Width="10%" HeaderText="Quantity" ItemStyle-HorizontalAlign="Center" />
                                                            <asp:BoundField DataField="Perc" HeaderText="Perc (%)" HeaderStyle-Width="10%" ItemStyle-HorizontalAlign="Center" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    <tr>
                                                        <td visible="false" id="Td1" runat="server">
                                                            Total Sales:<label id="lblTotal" runat="server"></label><br />
                                                            Total Sales(Incl of Tax):<label id="lblgndtot" runat="server"></label>
                                                        </td>
                                                    </tr>
                                                </div>
                                            </div>
                                        </div>
                                         <asp:Button ID="Button2" runat="server" Text="Print" Style="background-color: Teal;
                                                    color: White; width: 100px; height: 40px" OnClientClick="Denomination2() ;" />
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-lg-4">
                                                <asp:Button ID="btn" runat="server" Text="Export To Excel" Visible="false" CssClass="btn btn-success"
                                                    OnClick="btnExport_Click" />
                                                
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gridPurchase" EventName="RowDataBound" />
                                    <asp:AsyncPostBackTrigger ControlID="gridcatqty" EventName="RowDataBound"></asp:AsyncPostBackTrigger>
                                </Triggers>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gridcatqty" EventName="RowDataBound" />
                                </Triggers>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btn" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="update">
                                <%-- <ProgressTemplate>
            <div class="overlay">
                <div style="z-index: 100; margin-left: 50px; margin-top: 50px; opacity: 1; -moz-opacity: 1;">
                    <img alt="" src="../images/Preloader_10.gif" />
                </div>
            </div>
        </ProgressTemplate>--%>
                                <%-- for text <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <span style="border-width: 0px; position: fixed; padding: 50px; background-color: #FFFFFF; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
        </div>
    </ProgressTemplate>--%>
                                <ProgressTemplate>
                                    <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                                        right: 0; left: 0; z-index: 9999999; opacity: 0.7;">
                                        <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="../images/Preloader_10.gif"
                                            AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed;
                                            top: 45%; left: 50%;" />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            </form>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
