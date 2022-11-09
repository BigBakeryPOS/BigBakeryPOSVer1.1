<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DispatchPrint.aspx.cs"
    Inherits="Billing.Accountsbootstrap.DispatchPrint" %>
    <%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head >
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <script src="../jqueryCalendar/script.js" type="text/javascript"></script>
    <script type="text/javascript" src="../jqueryCalendar/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../jqueryCalendar/jquery-ui-1.8.15.custom.min.js"></script>
    <link rel="stylesheet" href="../jqueryCalendar/jqueryCalendar.css" />
    <script type="text/javascript">
        jQuery(function () {
            jQuery("#inf_custom_someDateField").datepicker();
        });
                

	    
                            
    </script>
    <script type="text/javascript">
        function fixform() {
            if (opener.document.getElementById("aspnetForm").target != "_blank") return;
            opener.document.getElementById("aspnetForm").target = "";
            opener.document.getElementById("aspnetForm").action = opener.location.href;
        }
    </script>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
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
    
    <style type="text/css">
        @media print
        {
            body
            {
                background-color: #FFFFFF;
                background-image: none;
                color: #000000;
            }
            #ad
            {
                display: none;
            }
            #leftbar
            {
                display: none;
            }
            #contentarea
            {
                width: 100%;
            }
        }
    </style>
    <script type="text/javascript">
        function printdataDC() {
            var gridData = document.getElementById("PRINTIDRec");
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
<body >
<usc:Header ID="Header" runat="server" />
    <form id="Form1" runat="server" role="form">
    <asp:Panel ID="pnlContents" runat="server">
      <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
        <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Dispatch Print</h1>
	    </div>
         <div class="panel-body">
            <div class="row">
                <div class="col-lg-3">
                    <label>
                        From Date</label>
                    <asp:TextBox ID="txtDate" OnTextChanged="dispatchload" AutoPostBack="true" runat="server" class="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtDate"
                        runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                </div>
               <div class="col-lg-3">
                    <label>
                        To Date</label>
                    <asp:TextBox ID="txtToDate" OnTextChanged="dispatchload" AutoPostBack="true" runat="server" class="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txtToDate"
                        runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                </div>
                <div class="col-lg-3">
                    <label>
                        Select Dispatch No</label>
                    <asp:DropDownList ID="drpdispatchno" runat="server" OnSelectedIndexChanged="dispatch_checked"
                        AutoPostBack="true" CssClass="form-control">
                    </asp:DropDownList>
                </div>
               <div class="col-lg-3">
                    <label>
                        Select Branch</label>
                    <asp:DropDownList ID="drpbranch" runat="server" CssClass="form-control" OnSelectedIndexChanged="Branch_select"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </div>
            </div>
            <br />
             <div class="row">
              <div class="col-lg-3">
                    <label>
                        Select DC No</label>
                    <asp:CheckBoxList ID="chkdclist" runat="server">
                    </asp:CheckBoxList>
                </div>
               <div class="col-lg-3">
               <br />
                    <asp:Button ID="btnsearch" runat="server" class="btn btn-primary pos-btn1" Text="Search" 
                        OnClick="btnsearch_Click" />
                    &nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" class="btn btn-secondary" Text="Print" OnClientClick="printdataDC()" />
                   &nbsp;&nbsp;&nbsp; <asp:Button ID="btnrefresh" runat="server" class="btn btn-secondary" PostBackUrl="~/Accountsbootstrap/Dispatch_report.aspx"
                        Text="Reset"  />
                </div>
            </div>
            <div id="PRINTIDRec" runat="server" align="center">
            <table width="500px" style="font-size: x-large; font-family: Calibri; font-weight: bold">
                <tr>
                    <td colspan="2" align="center" style="font-size: x-large;">
                        <br />
                        <img width="200px" height="121px" src="../images/BlackForrest.png" />
                        <br />
                        <asp:Label ID="lblstore" runat="server" Style="font-weight: bold; font-size: x-large;"></asp:Label>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td visible="true" align="left" style="font-size: medium; font-weight: bold">
                        <label>
                            Dispatch No:&nbsp;&nbsp;
                        </label>
                        <asp:Label ID="lbldispatchno" runat="server"></asp:Label>
                    </td>
                    <td visible="true" align="left" style="font-size: medium; font-weight: bold">
                        <label>
                            Dispatch Date:&nbsp;&nbsp;
                        </label>
                        <asp:Label ID="lbldispatchdate" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td visible="true" align="left" style="font-size: medium; font-weight: bold">
                        <label>
                            Vehicle No:&nbsp;&nbsp;
                        </label>
                        <asp:Label ID="lblvehicelno" runat="server"></asp:Label>
                    </td>
                    <td visible="true" align="left" style="font-size: medium; font-weight: bold">
                        <label>
                            Employee Name:&nbsp;&nbsp;
                        </label>
                        <asp:Label ID="lblempname" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="padding-left: 5px">
                        <div >
                            <asp:GridView ID="Griddc" runat="server" AutoGenerateColumns="false" cssClass="table table-striped pos-table"
                                OnRowCreated="Griddc_RowCreated" OnRowDataBound="Griddc_RowDataBound" padding="0" spacing="0" border="0">
                              <%--  <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                    HorizontalAlign="Center" ForeColor="White" />--%>
                                <Columns>
                                    <asp:BoundField HeaderText="Category" DataField="Category" />
                                    <asp:BoundField HeaderText="Item" DataField="Definition" />
                                    <asp:BoundField HeaderText="Order Qty" DataField="Oqty" />
                                    <asp:BoundField HeaderText="Sent Qty" DataField="Qty" />
                                    <asp:TemplateField HeaderText="Unit">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUOM" Text='<%# Eval("UOM")%>' runat="server"></asp:Label>
                                            <asp:HiddenField ID="hdCategoryid" runat="server" Value='<%# Eval("Categoryid")%>' />
                                            <asp:HiddenField ID="hdCategoryUserID" runat="server" Value='<%# Eval("CategoryUserID")%>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <%--<FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                            </asp:GridView>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 3px dotted black;">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="right">
                        <br />
                        <br />
                        <label style="font-size: large">
                            Check Out Signature</label><br />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="font-size: large; text-decoration: none; border-bottom: 3px dotted black;">
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center" style="display: none">
                        <label style="font-size: small">
                            For any FeedBack/Queries Kindly Call 8489955500 www.Facebook.com/blaackforestcakes</label>
                    </td>
                </tr>
                <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label"> </asp:Label>
                <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
                <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
            </table>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            </div>
          </div>
          </div>
          </div>
          </div>
          </div>
    </asp:Panel>
    </form>
</body>
</html>
