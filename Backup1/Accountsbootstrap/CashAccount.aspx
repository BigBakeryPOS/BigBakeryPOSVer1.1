<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CashAccount.aspx.cs" Inherits="Billing.Accountsbootstrap.CashAccount" %>

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
    <title>Cash Account Page - bootsrap</title>
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
    <link href="../css/Header.css" rel="stylesheet" type="text/css" />
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
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    
        <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
            <form id="Form2" runat="server" role="form">
                 
        <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Cash Account Report</h1>
	    </div>
              <div class="panel-body">
                        <div class="row">
                
                <div class="col-lg-3">
                    <div class="form-group">
                        <label>
                            From Date</label>
                        <asp:TextBox CssClass="form-control" ID="txtfrmdate" runat="server" Text="Select Date"></asp:TextBox>
                    </div>
                    <ajaxToolkit:CalendarExtender ID="txtfrmdate1" TargetControlID="txtfrmdate" Format="dd/MM/yyyy"
                        runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label>
                            To Date</label>
                        <asp:TextBox CssClass="form-control" ID="txttodate" runat="server" Text="Select Date"></asp:TextBox>
                    </div>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txttodate"
                        Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                </div>
                <div class="col-lg-3">
                    <div class="form-group">
                        <label>
                            Select Company</label>
                        <asp:DropDownList ID="ddloutlet" runat="server" CssClass="form-control">
                            <%--<asp:ListItem Text="select" Value="0"></asp:ListItem>--%>
                            <asp:ListItem Text="CO1" Value="CO1"></asp:ListItem>
                            <asp:ListItem Text="CO2" Value="CO2"></asp:ListItem>
                            <asp:ListItem Text="CO3" Value="CO3"></asp:ListItem>
                            <asp:ListItem Text="All" Value="All"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <br />
                <div class="col-lg-3">
                    <asp:Button ID="btnreport" runat="server" class="btn btn-info pos-btn1" Text="Generate Report"
                        OnClick="btnreport_Click" />
                        &nbsp;&nbsp;&nbsp;<asp:button id="btnprint" runat="server" cssclass="btn btn-secondary" text="Print"
                            width="100px" onclientclick="javascript:CallPrint('bill');" xmlns:asp="#unknown" />
                </div>
          
         
          
       
                     
                       
                          <div class="col-lg-12" id="bill">
                          <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
                                            ID="val1" ShowMessageBox="true" ShowSummary="false" />
                                        <h2 align="center">
                                            <asp:Label ID="lblMessage" Style="color: #007aff;" runat="server"></asp:Label></h2>
                               <div class="table-responsive panel-grid-left">
                                <div class="row" id="idt" visible="false" runat="server">
                                   
                                    
                                        
                                        
                                            <!-- /.panel-heading -->
                                           <%-- <table id="Table1" runat="server" style="border: 1px solid Grey; height: 15px; background-color: #59d3b4;
                                                text-transform: uppercase" width="100%">
                                                <tr>
                                                    <td align="center" style="font-size: small1; width: 70px">
                                                        Date
                                                    </td>
                                                    <td align="center" style="font-size: small1; width: 350px">
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
                                                        Debit
                                                    </td>
                                                </tr>
                                            </table>--%>
                                           
                                                <asp:GridView runat="server" ID="gvCash" Width="100%"  cssClass="table table-striped pos-table"
                                                    AutoGenerateColumns="false"  ShowFooter="true" AllowPrintPaging="true" padding="0" spacing="0" border="0"
                                                    OnRowDataBound="gvCash_RowDataBound">
                                                    <Columns>
                                                        <asp:BoundField DataField="Date" ItemStyle-Width="100px" HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Date"
                                                            DataFormatString="{0:dd/MM/yyyy}" />
                                                        <asp:BoundField DataField="Particulars"  HeaderText="Ledger Name" ItemStyle-Width="100px" />
                                                        <asp:BoundField DataField="Type"  HeaderText="Voucher Type" ItemStyle-Width="100px" />
                                                        <asp:BoundField DataField="Narration"  HeaderText="Narration" ItemStyle-Width="100px" />
                                                        <asp:BoundField DataField="BranchCode" HeaderText="BranchCode" Visible="false" />
                                                        <asp:BoundField DataField="Debit" HeaderText="Debit" ItemStyle-Width="60px"
                                                            DataFormatString="{0:f2}" />
                                                        <asp:BoundField DataField="Credit" HeaderText="Debit" ItemStyle-Width="60px"
                                                            DataFormatString="{0:f2}"  />
                                                    </Columns>
                                                    <PagerTemplate>
                                                    </PagerTemplate>
                                                </asp:GridView>
                                            
                                            <br />
                                            <table style="width: 100%">
                                                <tr runat="server" visible="false">
                                                    <td width="66%" align="right">
                                                        Opening Balance
                                                    </td>
                                                    <td width="11%" align="right">
                                                        <asp:Label ID="lblOBDR" runat="server" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td width="11%" align="right">
                                                        <asp:Label ID="lblOBCR" runat="server" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td width="7%" align="right">
                                                    </td>
                                                </tr>
                                                <tr runat="server" visible="false">
                                                    <td width="60%" align="right">
                                                        Total
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblDebitSum" runat="server" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblCreditSum" runat="server" Font-Bold="true"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr runat="server" visible="false">
                                                    <td width="60%" align="right">
                                                        Closing Balance
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblDebitDiff" runat="server" Font-Bold="true"></asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblCreditDiff" runat="server" Font-Bold="true"></asp:Label>
                                                    </td>
                                                </tr>
                                            </table>
                                           
                                        </div>
                                      
                                    </div>
                                    
                                </div>
                               
     </div>
   </div>
    </form>
    </div>
    </div>
    </div>
    <!-- jQuery -->
</body>
</html>
