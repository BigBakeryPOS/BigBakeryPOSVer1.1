<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Statement.aspx.cs" Inherits="Billing.Accountsbootstrap.Statement" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html>
<html lang="en">
<head id="Head1">
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <link href="../css/Header.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <title>Statement Page - bootsrap</title>
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
    <%-- <style type="text/css">
        .FixedHeader {
            position: absolute;
            font-weight: bold;
        }     
    </style>--%>
    <script type="text/javascript" src="http://code.jquery.com/jquery-2.1.1.min.js"></script>
    <script language="javascript">
        $(document).ready(function () {
            /*Code to copy the gridview header with style*/
            var gridHeader = $('<%#gvCash.ClientID%>').clone(true);
            /*Code to remove first ror which is header row*/
            $(gridHeader).find("tr:gt(0)").remove();
            $('<%#gvCash.ClientID%> tr th').each(function (i) {
                /* Here Set Width of each th from gridview to new table th */
                $("th:nth-child(" + (i + 1) + ")", gridHeader).css('width', ($(this).width()).toString() + "px");
            });
            $("#controlHead").append(gridHeader);
            $('#controlHead').css('position', 'absolute');
            $('#controlHead').css('top', $('<%#gvCash.ClientID%>').offset().top);

        });
    </script>
    <script language="javascript" type="text/javascript">
        function CallPrint(strid) {
            var prtContent = document.getElementById(strid);
            //        var prtContent = document.getElementById(gridOpening);
            var WinPrint = window.open('', '', 'letf=100,top=100,width=1000,height=1000,toolbar=0,scrollbars=0,status=0');
            WinPrint.document.write(prtContent.innerHTML);
            WinPrint.document.close();
            WinPrint.focus();
            WinPrint.print();
            WinPrint.close();
            prtContent.innerHTML = strOldOne;
        }
    </script>
    <link href="../css/Header.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <form id="Form1" runat="server" role="form">
     <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
     <div class="panel-header">
          <h1 class="page-header">Bank Statement Report</h1>
	    </div>
       <div class="panel-body">
                        <div class="row">
            <div class="col-lg-3">
                <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
                    ID="val1" ShowMessageBox="true" ShowSummary="false" />
                
                    <label>
                        From Date</label>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator1"
                        Text="*" ControlToValidate="txtfrmdate" ErrorMessage="Please enter from date!"
                        Style="color: Red" />
                    <asp:TextBox CssClass="form-control" ID="txtfrmdate" runat="server" Text="Select Date"></asp:TextBox>
               
                <ajaxToolkit:CalendarExtender ID="txtfrmdate1" TargetControlID="txtfrmdate" Format="dd/MM/yyyy"
                    runat="server" CssClass="cal_Theme1">
                </ajaxToolkit:CalendarExtender>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </div>
            <div class="col-lg-3">
               
                    <label>
                        To Date</label>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator4"
                        Text="*" ControlToValidate="txttodate" ErrorMessage="Please enter To date!" Style="color: Red" />
                    <asp:TextBox CssClass="form-control" ID="txttodate" runat="server" Text="Select Date"></asp:TextBox>
               
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txttodate"
                    Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                </ajaxToolkit:CalendarExtender>
            </div>
            <div class="col-lg-3">
                
                    <label>
                        Select Bank</label>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="val1"
                        Text="*" Style="color: Red" InitialValue="0" ControlToValidate="ddlBank" ValueToCompare="Select Bank"
                        Operator="NotEqual" Type="String" ErrorMessage="Please Select Bank"></asp:CompareValidator>
                    <asp:DropDownList ID="ddlBank" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                
            </div>
            <div class="col-lg-3">
               
                    <label>
                        Select Company</label>
                    <asp:DropDownList ID="ddloutlet" runat="server" CssClass="form-control">
                        <%--<asp:ListItem Text="select" Value="0"></asp:ListItem>--%>
                        <%--<asp:ListItem Text="CO1" Value="CO1"></asp:ListItem>
                                              <asp:ListItem Text="CO2" Value="CO2"></asp:ListItem>
                                               <asp:ListItem Text="CO3" Value="CO3"></asp:ListItem>
                                               <asp:ListItem Text="All" Value="All"></asp:ListItem>--%>
                    </asp:DropDownList>
              
            </div>
          </div>
          <br />
          <div class="row">
            <div class="col-lg-3" >
                <asp:Button ID="btnreport" runat="server" class="btn btn-info pos-btn1" ValidationGroup="val1"
                    Text="Generate Report"   OnClick="btnreport_Click" />
                    &nbsp;&nbsp;&nbsp;<asp:button id="btnprint" runat="server" cssclass="btn btn-secondary" text="Print"
                           width="100px" onclientclick="javascript:CallPrint('bill');" xmlns:asp="#unknown" />
            </div>
           </div>
          
      
               
                       <div class="row">
                            <div class="col-lg-12" id="bill">
                                <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
                                    ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" />
                                <h2 align="center">
                                    <asp:Label ID="lblMessage" Style="color: #007aff;" runat="server"></asp:Label></h2>
                                    <div class="table-responsive panel-grid-left">
                                <div class="row" id="idt" visible="false" runat="server">
                                       
                                       <%-- <table id="Table1" runat="server" style="border: 1px solid Grey; height: 30px; background-color: #cccccc;
                                            margin-left: 121px;">
                                        </table>--%>
                                        <%--<table id="Table2" runat="server" style="border: 1px solid Grey; height: 15px; background-color: #59d3b4;
                                            text-transform: uppercase" width="100%">
                                            <tr>
                                                <td align="center" style="font-size: small1; width: 70px">
                                                    Date
                                                </td>
                                                <td align="center" style="font-size: small1; width: 250px">
                                                    Ledger Name
                                                </td>
                                                <td align="center" style="font-size: small">
                                                    Voucher Type
                                                </td>
                                                <td align="center" style="font-size: small">
                                                    Narration
                                                </td>
                                                <td align="center" style="font-size: small">
                                                    Debit
                                                </td>
                                                <td align="center" style="font-size: small">
                                                    Credit
                                                </td>
                                                <td align="center" style="font-size: small">
                                                    Balance
                                                </td>
                                            </tr>
                                        </table>--%>
                                       
                                           
                                                <table runat="server" visible="false" width="100%">
                                                    <tr>
                                                        <td width="56%" align="right">
                                                            Opening Balance
                                                        </td>
                                                        <td width="15%" align="right">
                                                            <asp:Label ID="lblOBDR" runat="server" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td width="15%" align="right">
                                                            <asp:Label ID="lblOBCR" runat="server" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td width="4%" align="right">
                                                        </td>
                                                    </tr>
                                                </table>
                                                <asp:GridView runat="server" ID="gvCash" Width="100%" AutoGenerateColumns="false" cssClass="table table-striped pos-table"
                                                    AllowPrintPaging="true" ShowFooter="true" padding="0" spacing="0" border="0"
                                                    OnRowDataBound="gvCash_RowDataBound">
                                                    
                                                    <Columns>
                                                        <asp:BoundField DataField="Date"  HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Date" ItemStyle-Width="100px"
                                                            DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="Particulars"  HeaderText="Ledger Name" ItemStyle-Width="100px" />
                                                        <asp:BoundField DataField="Type"  HeaderText="Voucher Type" ItemStyle-Width="100px" />
                                                        <asp:BoundField DataField="Narration"  HeaderText="Narration" ItemStyle-Width="100px" />
                                                        <asp:BoundField DataField="BranchCode"  HeaderText="BranchCode" Visible="false" />
                                                        <asp:BoundField DataField="Debit"  HeaderText="Debit" ItemStyle-Width="60px"
                                                            DataFormatString="{0:f2}"  />
                                                        <asp:BoundField DataField="Credit"  HeaderText="Credit" ItemStyle-Width="60px"
                                                            DataFormatString="{0:f2}"  />
                                                        <asp:TemplateField ItemStyle-Width="60px" HeaderText="Balance">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblBalance" runat="server" CssClass="lblFont" Font-Bold="true" ForeColor="Blue"
                                                                    Text="0.00"> </asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <PagerTemplate>
                                                    </PagerTemplate>
                                                </asp:GridView>
                                                <div runat="server" visible="false">
                                                    <tr>
                                                        <td width="60%" align="right">
                                                            Total
                                                        </td>
                                                        <td align="right" width="11%">
                                                            <asp:Label ID="lblDebitSum" runat="server" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td align="right" width="11%">
                                                            <asp:Label ID="lblCreditSum" runat="server" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td width="7%" align="right">
                                                        </td>
                                                    </tr>
                                                </div>
                                                <div runat="server" visible="false">
                                                    <tr>
                                                        <td width="60%" align="right">
                                                            Closing Balance
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="lblDebitDiff" runat="server" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="lblCreditDiff" runat="server" Font-Bold="true"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="lblClosDr" runat="server"></asp:Label>
                                                        </td>
                                                        <td align="right">
                                                            <asp:Label ID="lblClosCr" runat="server"></asp:Label>
                                                        </td>
                                                    </tr>
                                                </div>
                                                
                                           
                                </div>
                               </div>
                            </div>
                          </div> 
                    
           
    
    </div>
    </div>
      </div>
        </div>
    </div>
    </form>
    <!-- jQuery -->
</body>
</html>
