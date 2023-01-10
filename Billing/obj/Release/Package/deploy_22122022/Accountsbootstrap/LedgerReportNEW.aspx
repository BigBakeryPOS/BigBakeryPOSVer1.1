<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LedgerReportNEW.aspx.cs" EnableEventValidation="false"
    Inherits="Billing.Accountsbootstrap.LedgerReportNEW" %>

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
    <title>Ledger Report</title>
     <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <link href="../css/Header.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="../Styles/date.css" />
    <link href="../css/Header.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="../Styles/style1.css" />
    <link rel="stylesheet" href="../Styles/chosen.css" />
    <%--<script type="text/javascript" src="../jquery-1.6.2.min.js"></script>
<script type="text/javascript" src="../jquery-ui-1.8.15.custom.min.js"></script>
<link rel="stylesheet" href="../jqueryCalendar.css"/>--%>
 <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />
    <!-- Bootstrap Core CSS -->
    <link href="../Styles/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../Styles/metisMenu.min.css" rel="stylesheet" />
    <link href="../css/Pos_style.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../Styles/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../Styles/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />
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
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
    <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
        ID="val1" ShowMessageBox="true" ShowSummary="false" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
             <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
              
             
        <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Ledger Report</h1>
	    </div>
            
                
                        <div class="panel-body" id="bill">
                        <div class="row">
                        <div class="col-lg-3">  
                        <div id="from" runat="server">
                            <label>
                                From Date</label>
                            <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator4"
                                Text="*" ControlToValidate="txtfrmdate" ErrorMessage="Please enter From date!"
                                Style="color: Red" />
                            <asp:TextBox CssClass="form-control" ID="txtfrmdate" runat="server" Text="--Select Date--"></asp:TextBox>
                        </div>
                        <ajaxToolkit:CalendarExtender ID="txtfrmdate1" TargetControlID="txtfrmdate" Format="dd/MM/yyyy"
                            runat="server" CssClass="cal_Theme1">
                        </ajaxToolkit:CalendarExtender>
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        </div>


                    <div class="col-lg-3">
                        <div  id="to" runat="server">
                            <label>
                                To Date</label>
                            <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator1"
                                Text="*" ControlToValidate="txttodate" ErrorMessage="Please enter To date!" Style="color: Red" />
                            <asp:TextBox CssClass="form-control" ID="txttodate" runat="server" Text="--Select Date--"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txttodate"
                                Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                            </ajaxToolkit:CalendarExtender>
                        </div>
                    </div>

                    <div class="col-lg-3">
                    <div id="Div2"  runat="server" visible="false">
                        
                            <label>
                                Heading</label>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="val1"
                                Text="*" Style="color: Red" InitialValue="0" ControlToValidate="DropHeading"
                                ValueToCompare="Select" Operator="NotEqual" Type="String" ErrorMessage="Please Select Heading"></asp:CompareValidator>
                            <asp:DropDownList ID="DropHeading" runat="server" CssClass="form-control" AutoPostBack="true"
                                OnSelectedIndexChanged="DropHeading_SelectedIndexChanged">
                            </asp:DropDownList>
                     </div>  
                    </div>

                    <div class="col-lg-3">
                    <div id="Div3"  runat="server" visible="false">
                        
                            <label>
                                Group</label>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ValidationGroup="val1"
                                Text="*" Style="color: Red" InitialValue="0" ControlToValidate="ddlGroup" ValueToCompare="Select"
                                Operator="NotEqual" Type="String" ErrorMessage="Please Select Group"></asp:CompareValidator>
                            <asp:DropDownList ID="ddlGroup" runat="server" CssClass="form-control" AutoPostBack="true"
                                OnSelectedIndexChanged="ddlGroup_SelectedIndexChanged">
                            </asp:DropDownList>
                    </div>   
                    </div>

                   
                       <div class="col-lg-3">
                            <label>
                                Ledger Name</label>
                            <asp:CompareValidator ID="CompareValidator3" runat="server" ValidationGroup="val1" 
                                Text="*" Style="color: Red" InitialValue="0" ControlToValidate="ddLedger" ValueToCompare="Select"
                                Operator="NotEqual" Type="String" ErrorMessage="Please Select Ledger Name"></asp:CompareValidator>
                            <asp:DropDownList ID="ddLedger" runat="server" CssClass="form-control " OnSelectedIndexChanged="ddLedger_SelectedIndexChanged" >
                            </asp:DropDownList>
                            <%--<asp:Button ID="btnfind" runat="server" Text="Find" CssClass="btn btn-success" 
                                                onclick="btnfind_Click" />--%>
                            
                     
                    </div>

                   
                     
                    

                    <div class="col-lg-3">
                    <div id="Div4"  runat="server" visible="true">
                       
                            <label>
                                Select Company</label>
                            <asp:DropDownList ID="ddloutlet" runat="server" CssClass="form-control">
                                <asp:ListItem Text="CO1" Value="CO1"></asp:ListItem>
                                <asp:ListItem Text="CO2" Value="CO2"></asp:ListItem>
                                <asp:ListItem Text="CO3" Value="CO3"></asp:ListItem>
                                <asp:ListItem Text="All" Value="All"></asp:ListItem>
                            </asp:DropDownList>
                       
                        </div>
                      </div> 
                       </div>
                       <br />
                      <div class="row">
                      <div class="col-lg-3">
                            <asp:Button ID="Button1" runat="server" Text="Generate Report" 
                                 ValidationGroup="val1" CssClass="btn btn-info pos-btn1" OnClick="btnSearch_Click" />
                              &nbsp;&nbsp;&nbsp;  <asp:button id="Button2" runat="server" cssclass="btn btn-outline-secondary" text="Print" width="100px"
                                 onclientclick="javascript:CallPrint('bill');" xmlns:asp="#unknown" />
                        </div>
                        </div>
                        <%--<div class="form-group">
                            <asp:Button ID="btnSearch" runat="server" Text="Generate Report" ValidationGroup="val1"
                                CssClass="btn btn-info" OnClick="btnSearch_Click" />
                        </div>--%>
                    
                    <%-- <div class="col-lg-2">
                                        <div class="form-group">
                                     <label>Select Company</label>
                                            <asp:DropDownList ID="DropDownList4" runat="server" CssClass="form-control">
                                            <asp:ListItem Text="CO1" Value="CO1"></asp:ListItem>
                                              <asp:ListItem Text="CO2" Value="CO2"></asp:ListItem>
                                               <asp:ListItem Text="CO3" Value="CO3"></asp:ListItem>
                                               <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                            </asp:DropDownList>
                                       
                                   
                                           
                                        </div>
                                       
                                        </div>--%>
                                    
                                     <div class="row">  
                                <div class="col-lg-12">
                                    <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
                                        ID="ValidationSummary1" ShowMessageBox="true" ShowSummary="false" />
                                    <h2 align="center">
                                        <asp:Label ID="lblMessage" Style="color: #007aff;" runat="server"></asp:Label></h2>
                                    <!-- /.row -->
                                    <%-- <div  class="row" style="margin-left:10px"> <asp:RadioButton ID="rbBranch1" runat="server" Text="Branch1" 
               GroupName="Branch" oncheckedchanged="rbBranch1_CheckedChanged" AutoPostBack="true" />
        <asp:RadioButton ID="rbBranch2" runat="server" Text="Branch2" GroupName="Branch" 
               oncheckedchanged="rbBranch2_CheckedChanged" AutoPostBack="true" />
        <asp:RadioButton ID="rbBranch3" runat="server" Text="Branch3" GroupName="Branch" 
               oncheckedchanged="rbBranch3_CheckedChanged" AutoPostBack="true"/>
        <asp:RadioButton ID="rbAll" runat="server" Text="All" GroupName="Branch" 
               oncheckedchanged="rbBranch4_CheckedChanged" AutoPostBack="true" /></div>--%>
                                    <%--<table id="Table1" runat="server" style="border: 1px solid Grey; height: 15px; background-color: #59d3b4;
                            text-transform: uppercase" width="100%">
                            <tr>
                            <td align="center" style="font-size: small">
                                    BRANCH
                                </td>
                                <td align="center" style="font-size: small1; width: 70px">
                                    Date
                                </td>
                                <td align="center" style="font-size: small1; width: 350px">
                                    Particulars
                                </td>
                                <td align="center" style="font-size: small">
                                    Narration
                                </td>
                                 
                                <td align="center" style="font-size: small">
                                    Type
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
                        <div class="table-responsive panel-grid-left">
                                    <div class="row" id="dd" runat="server" visible="false">
                                        <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                          <asp:GridView ID="gvdaybook" runat="server"  cssClass="table table-striped pos-table" AllowPaging="false" 
                                    Width="100%" EmptyDataText="Oops! No Activity Performed." OnRowDataBound="gvdaybook_RowDataBound" 
                                    AutoGenerateColumns="false" padding="0" spacing="0" border="0">
                                            
                                                <Columns>
                                               
                                                    <asp:BoundField DataField="Branchname"   HeaderText="&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Branch Name" />
                                                    <asp:BoundField DataField="Date"  HeaderText="Date"
                                                        DataFormatString="{0:dd/MM/yyyy}" />
                                                    <asp:BoundField DataField="Particulars"  HeaderText="Particulars" />
                                                    <asp:BoundField DataField="Narration"  HeaderText="Narration" />
                                                    <asp:BoundField DataField="Type" HeaderText="Type" />
                                                    <asp:BoundField DataField="Debit" 
                                                        DataFormatString="{0:f2}" HeaderText="Debit"  />
                                                    <asp:BoundField DataField="Credit" 
                                                        DataFormatString="{0:f2}" HeaderText="Credit"  />
                                                    <asp:TemplateField  HeaderText="Balance" 
                                                        >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblBalance" runat="server" CssClass="lblFont" Font-Bold="true" ForeColor="Blue"
                                                                Text="0.00"> </asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:BoundField ItemStyle-Width="10%" DataField="LedgerID" Visible="false" />
                                                </Columns>
                                            </asp:GridView>
                                           
                                        <asp:Label ID="lblDebitTotal" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblCreditTotal" runat="server" Visible="false"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblDebitClosingTotal" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblCreditClosingTotal" runat="server" Visible="false"></asp:Label>
                                        <br />
                                        <asp:Label ID="lblNetDebit" runat="server" Visible="false"></asp:Label>
                                        <asp:Label ID="lblNetCredit" runat="server" Visible="false"></asp:Label>
                                        <table border="0" cellspacing="0">
                                            <tr id="Tr1" runat="server" visible="false">
                                                <td width="670px">
                                                    &nbsp;
                                                </td>
                                                <td align="right" width="260px">
                                                    <b>Opening Balance :</b>
                                                </td>
                                                <td width="30px">
                                                    &nbsp;
                                                </td>
                                                <td align="right" width="100px">
                                                    <asp:Label ID="lblOBDR" runat="server"></asp:Label>
                                                </td>
                                                <td align="right" width="100px">
                                                    <asp:Label ID="lblOBCR" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr id="Tr2" runat="server" visible="false">
                                                <td width="670px">
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                    <b>Total :</b>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblDebitSum" runat="server"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblCreditSum" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <div id="Div1" runat="server" visible="false">
                                                <tr>
                                                    <td width="670px">
                                                        &nbsp;
                                                    </td>
                                                    <td align="right" width="260px">
                                                        <b>Current Balance :</b>
                                                    </td>
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblDebitDiff" runat="server"></asp:Label>
                                                    </td>
                                                    <td align="right">
                                                        <asp:Label ID="lblCreditDiff" runat="server"></asp:Label>
                                                    </td>
                                                </tr>
                                            </div>
                                            <tr id="Tr3" runat="server" visible="false">
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                    <b>Closing Balance :</b>
                                                </td>
                                                <td>
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblClosDr" runat="server"></asp:Label>
                                                </td>
                                                <td align="right">
                                                    <asp:Label ID="lblClosCr" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                   
                                    <!-- /#page-wrapper -->
                                </div>
                            </div>
                        </div>
                   
            </div>
            </div>
           
            
            </div>
            </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        window.onload = function () {
            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
        }
    </script>
    </form>
</body>
</html>
