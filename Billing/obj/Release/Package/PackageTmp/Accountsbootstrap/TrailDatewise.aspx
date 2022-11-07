<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TrailDatewise.aspx.cs"
    Inherits="Billing.Accountsbootstrap.TrailDatewise" %>

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
    <link rel="Stylesheet" type="text/css" href="../Styles/style1.css" />
    <link href="../css/Header.css" rel="stylesheet" type="text/css" />
    <title>Trail Page - bootsrap</title>
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
    <script language="javascript" type="text/javascript">
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
</head>
<body>
    <usc:Header ID="Header" runat="server" />
   
        <form id="Form1" runat="server" role="form">
          <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
        <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Trail Balance Report</h1>
	    </div>
           <div class="panel-body">
                        <div class="row">
            <div class="col-lg-3">
                <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
                    ID="val1" ShowMessageBox="true" ShowSummary="false" />
                <div class="form-group" runat="server" visible="true">
                    <label>
                        From Date</label>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator1"
                        Text="*" ControlToValidate="txtfrmdate" ErrorMessage="Please enter From date!"
                        Style="color: Red" />
                    <asp:TextBox CssClass="form-control" ID="txtfrmdate" runat="server" Text="Select Date"></asp:TextBox>
                </div>
                <ajaxToolkit:CalendarExtender ID="txtfrmdate1" TargetControlID="txtfrmdate" Format="dd/MM/yyyy"
                    runat="server" CssClass="cal_Theme1">
                </ajaxToolkit:CalendarExtender>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </div>
            <div class="col-lg-3">
               
                    <label>
                        To Date</label>
                    <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator2"
                        Text="*" ControlToValidate="txttodate" ErrorMessage="Please enter To date!" Style="color: Red" />
                    <asp:TextBox CssClass="form-control" ID="txttodate" runat="server" Text="Select Date"></asp:TextBox>
                
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txttodate"
                    Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                </ajaxToolkit:CalendarExtender>
            </div>
            <div class="col-lg-3">
               
                    <label>
                        Select Company</label>
                    <asp:DropDownList ID="ddloutlet" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                
            </div>
            <br />
            <div class="col-lg-3">
               
                    <asp:Button ID="btnreport" runat="server" ValidationGroup="val1" class="btn btn-info pos-btn1"
                        Text="Generate Report" OnClick="btnreport_Click" />
                        &nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button3" runat="server" CssClass="btn btn-secondary" Text="Print"
                                                Width="100px" OnClick="Button3_Click" />
                
            </div>
        </div>
                            <div class="table-responsive panel-grid-left">
                        <div class="row" id="idt" visible="false" runat="server">
                            <div class="col-lg-12">
                                
                                    
                                      <%--  <table id="Table1" runat="server" style="border: 1px solid Grey; height: 15px; background-color: #59d3b4;
                                            text-transform: uppercase" width="100%">
                                            <tr>
                                                <td align="center" style="font-size: small1; width: 1050px">
                                                    Particulars
                                                </td>
                                                <td align="center" style="font-size: small">
                                                    Debit(Rs)
                                                </td>
                                                <td align="center" style="font-size: small">
                                                    Credit(Rs)
                                                </td>
                                            </tr>
                                        </table>--%>
                                        
                                            <asp:GridView runat="server" Width="100%" cssClass="table table-striped pos-table" ID="gvTrailBalance"
                                                AutoGenerateColumns="false" DataKeyNames="GroupID" OnRowDataBound="gvTrailBalance_RowDataBound"
                                                ShowFooter="true" padding="0" spacing="0" border="0">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Particulars"  ItemStyle-Width="400px" HeaderStyle-HorizontalAlign="Center">
                                                        <ItemTemplate>
                                                            <a href="javascript:switchViews('dv<%# Eval("GroupID") %>', 'imdiv<%# Eval("GroupID") %>');"
                                                                style="text-decoration: none;">
                                                                <img id="imdiv<%# Eval("GroupID") %>" alt="Show" border="0" src="../images/plus.gif" />
                                                            </a>
                                                            <%# Eval("GroupName") %>
                                                            <div id="dv<%# Eval("GroupID") %>" style="display: none; position: relative;">
                                                                <asp:GridView runat="server" ID="gvLiaLedger" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0" GridLines="Both" Width="50%"
                                                                    AutoGenerateColumns="false" DataKeyNames="LedgerID">
                                                                    <Columns>
                                                                        <%--<asp:BoundField DataField="Folionumber" HeaderText="LNO"  />--%>
                                                                        <asp:BoundField DataField="LedgerName" HeaderText="Ledger Name" />
                                                                        <%--<asp:BoundField DataField="Branch" HeaderText="Branch"  />--%>
                                                                        <asp:BoundField DataField="Debit"  DataFormatString="{0:f2}" ItemStyle-Width="100px"
                                                                            HeaderText="Debit"  />
                                                                        <asp:BoundField DataField="Credit" DataFormatString="{0:f2}" ItemStyle-Width="100px"
                                                                            HeaderText="Credit"  />
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField   HeaderText="Debit(Rs)" ItemStyle-Width="60px">
                                                        <ItemTemplate>
                                                            <asp:Label  ID="lblDebit" runat="server"
                                                                Text='<%# Eval("Debit","{0:f2}") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField  ItemStyle-Width="60px" HeaderText="Credit(Rs)" >
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCredit" runat="server"
                                                                Text='<%# Eval("Credit","{0:f2}") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                       
                                        <table>
                                            <tr>
                                                <td >
                                                    &nbsp;
                                                </td>
                                                <td width="60px" align="right">
                                                    <asp:Label ID="lblDebitTotal" runat="server" Visible="false"></asp:Label>
                                                </td>
                                                <td  width="60px" align="right">
                                                    <asp:Label ID="lblCreditTotal" runat="server" Visible="false"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                   
                            </div>
                        </div>
                       
               
    
    </div>
    </div>
    </div>
    </div>
    </div>
        </form>
       
   
   
    
   
</body>
</html>
