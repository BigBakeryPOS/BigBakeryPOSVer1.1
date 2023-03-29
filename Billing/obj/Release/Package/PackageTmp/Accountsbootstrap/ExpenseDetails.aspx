<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExpenseDetails.aspx.cs"
    Inherits="Billing.Accountsbootstrap.ExpenseDetails" EnableEventValidation="true" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <link rel="stylesheet" href="../Styles/chosen.css" />
    <%--<link href="../Accountsbootstrap/css/chosen.min.css" rel="stylesheet" type="text/css" />--%>
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Expenses Report</title>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript">
        function alertMessage() {

            alert('This Bill Not Allow To Cancel.Please Contact Administrator!!!');
        }

        function alertMessagee() {

            alert('This Bill Not Allow To Cancel.Please Select Valid Reason Or Contact Administrator!!!');
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
        function Denomination123() {


            var gridData = document.getElementById('gvsales');


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

 function Denomination1234() {


            var gridData = document.getElementById('gvsummary');


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
        function Search_Gridview(strKey, strGV) {
            var strData = strKey.value.toLowerCase().split(" ");
            var tblData = document.getElementById(strGV);
            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)
                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        }    
    </script>
    <script type="text/javascript" src="../js/jquery-1.7.2.js"></script>
    <script type="text/javascript">

        function alertorder() {
            alert('Are You Sure, You want to cancel This Customer sales!');
        }
    </script>
</head>
<body>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false">  </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12">
                <div class="row panel-custom1">
                    <div class="panel-header">
                        <h1 class="page-header">
                            Expense Report</h1>
                    </div>
                    <div class="panel-body">
                        <form runat="server" id="form1" >
                        <asp:ScriptManager ID="script" runat="server">
                        </asp:ScriptManager>
                        <div id="Div1" class="row">
                            <div class="col-lg-3">
                                <label>
                                    From Date</label>
                                <asp:TextBox ID="txtfromdate" CssClass="form-control" runat="server"></asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtfromdate"
                                    runat="server" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                            </div>
                            <div class="col-lg-3">
                                <label>
                                    To Date</label>
                                <asp:TextBox ID="txttodate" CssClass="form-control" runat="server"> </asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txttodate"
                                    runat="server" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                            </div>
                            <div class="col-lg-3">
                                <br />
                                <asp:RadioButton ID="rdodetailed" Text="Detailed Report" runat="server" Checked="true"
                                    GroupName="rpt" />
                                <asp:RadioButton ID="rdosummary" Text="Summary Report" runat="server" GroupName="rpt" />
                            </div>
                            <%-- <div class="col-lg-2">
                            <label>Select Department</label>
                            <asp:DropDownList ID="drpdept" runat="server" CssClass="form-control"  ></asp:DropDownList>
                            </div>--%>
                            <div class="col-lg-3" style="display: none">
                                <label>
                                    Type
                                </label>
                                <br />

                                <asp:DropDownList runat="server" ID="ddltype" CssClass="chzn-select" Width="150px"
                                    OnSelectedIndexChanged="ddltype_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Text="Summary" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="Detailed" Selected="True" Value="2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                          <%--  <div class="col-lg-3" id="entry" runat="server">
                                <label>
                                    Entry No
                                </label>
                                <br />
                                <asp:DropDownList runat="server" ID="ddldcno" CssClass="chzn-select">
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-3" id="cat" runat="server">
                                <label>
                                    Category
                                </label>
                                <br />
                                <asp:DropDownList runat="server" ID="ddlCategory" CssClass="chzn-select">
                                </asp:DropDownList>
                            </div>--%>
                            <div class="col-lg-3"  runat="server">
                                <label>
                                    LedgerName
                                </label>
                                <asp:DropDownList runat="server" ID="ddlExpense" CssClass="form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <br />
                        <div class="row">
                            <div class="col-lg-3">
                                <asp:Label ID="Label2" runat="server"></asp:Label>
                                <asp:Button ID="btnsearch" runat="server" Text="Search" Visible="true" CssClass="btn btn-info pos-btn1"
                                    OnClick="btnsearch_Click" />
                                <asp:Label ID="Label1" runat="server"></asp:Label>
                                <asp:Button ID="btnexcel" runat="server" Text="Export Excel" Visible="true" CssClass="btn btn-success"
                                    OnClick="btnexcel_Click" />
                                <asp:Button ID="btnPrintDetails" runat="server" Text="Print" Visible="true" CssClass="btn btn-secondary"
                                    OnClientClick="Denomination123()" />
                                  <asp:Button ID="btnPrintSummary" runat="server" Text="Print" Visible="false" CssClass="btn btn-secondary"
                                    OnClientClick="Denomination1234()" />
                            </div>

                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                  <div id="Details" runat="server" class="table-responsive panel-grid-left">
                              
                                    <asp:GridView ID="gvsales" align="center" EmptyDataText="No Records Found" runat="server"
                                        PageIndex="10" Caption="Expense Detailed Report" OnRowDataBound="gvsales_OnRowDataBound"
                                        ShowFooter="true" AutoGenerateColumns="false" padding="0" spacing="0" border="0"
                                        CssClass="table table-striped pos-table">
                                        <PagerStyle CssClass="pos-paging" />
                                        <%--<HeaderStyle BackColor="#990000" />
                                <PagerSettings FirstPageText="1" Mode="Numeric" />--%>
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No" ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Expenses" DataField="LedgerName" />
                                             <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString="{0:dd/MMM/yyyy}" />
                                            <asp:BoundField HeaderText="Description" DataField="Description" />
                                           
                                            <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:f}" />
                                           
                                        </Columns>
                                    </asp:GridView>
                                    </div>
                                 <div id="Summary" runat="server" class="table-responsive panel-grid-left">
                              
                                    <asp:GridView ID="gvsummary" align="center" EmptyDataText="No Records Found" runat="server"
                                        PageIndex="10" Caption="Expense Summary Report" ShowFooter="true" OnRowDataBound="gvs_OnRowDataBound"
                                        AutoGenerateColumns="false" padding="0" spacing="0" border="0" CssClass="table table-striped pos-table">
                                        <%-- <HeaderStyle BackColor="#990000" />
                                <PagerSettings FirstPageText="1" Mode="Numeric" />--%>
                                        <PagerStyle CssClass="pos-paging" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No" ItemStyle-Width="10%">
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:BoundField HeaderText="Expenses" DataField="LedgerName" />
                                            <%-- <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString="{0:dd/MMM/yyyy}" />--%>
                                         
                                           
                                            <asp:BoundField HeaderText="Amount" DataField="TotalAmount" DataFormatString="{0:f}" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                           
                                </div>
                        </div>
                        <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
                        <script type="text/javascript">
                            window.onload = function () {
                                $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true });
                            }
                        </script>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</body>
</html>
