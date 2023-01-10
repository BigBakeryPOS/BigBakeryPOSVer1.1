<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DayBookNEW.aspx.cs" Inherits="Billing.Accountsbootstrap.DayBookNEW" %>

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
    <title></title>
    <%-- <link rel="Stylesheet" type="text/css" href="../Styles/date.css" />--%>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <link href="../css/Header.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <%--<script type="text/javascript" src="../jquery-1.6.2.min.js"></script>
<script type="text/javascript" src="../jquery-ui-1.8.15.custom.min.js"></script>
<link rel="stylesheet" href="../jqueryCalendar.css"/>--%>
    <!-- Bootstrap Core CSS -->
    <%--<link href="../Styles/bootstrap.min.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="../Styles/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../Styles/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../Styles/font-awesome.min.css" rel="stylesheet" type="text/css"/>--%>
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
     
    <![endif]-->

      <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <link href="../css/Pos_style.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />

    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />
    <style type="text/css">
        .GroupHeaderStyle
        {
            color: Blue;
            font-weight: bold;
            text-transform: uppercase;
        }
        .SubTotalRowStyle
        {
            color: Blue;
            font-weight: bold;
        }
        .GrandTotalRowStyle
        {
            color: red;
            font-weight: bold;
        }
        .GrandTotalRowStyle1
        {
            background-color: White;
            color: Blue;
            font-weight: bold;
        }
        .align1
        {
            text-align: right;
        }
        
        .myGridStyle1 tr th
        {
            padding: 8px;
            color: White;
            background-color: #cccccc;
            border: 1px solid gray;
            font-family: Arial;
            font-weight: bold;
            text-align: center;
            text-transform: uppercase;
        }
        
        
        
        
        
        .myGridStyle1 tr:nth-child(even)
        {
            background-color: #ffffff;
        }
        
        
        
        .myGridStyle1 tr:nth-child(odd)
        {
            background-color: #ffffff;
        }
        
        
        
        .myGridStyle1 td
        {
            border: 1px solid gray;
            padding: 8px;
        }
    </style>
    <script type="text/javascript">
        function Denomination() {


            var gridData = document.getElementById('gvLedger');


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
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
        <asp:ScriptManager ID="ScriptManager1" ScriptMode="Release" runat="server">
            </asp:ScriptManager>
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
     
        
            
                <%-- <asp:Button ID="Button1"  runat="server" CssClass="btn btn-block center-block" Text="Print" 
                                        Width="125px" onclick="Button1_Click"  />   --%>
            
  
           
        <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">DayBook Report</h1>
	    </div>

            
                <div class="panel-body" id="Div1">
                        <div class="row">
                        <div class="col-lg-3"> 
                    <label>
                        From Date
                    </label>
                    <asp:TextBox CssClass="form-control" ID="txtfromdate" runat="server" Text="Select Date"></asp:TextBox>
                
                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfromdate"
                    PopupButtonID="txtfromdate" EnabledOnClient="true" Format="dd/MM/yyyy" runat="server"
                    CssClass="cal_Theme1">
                </ajaxToolkit:CalendarExtender>
            </div>
            <div class="col-lg-3">
                    <label>
                        TO Date
                    </label>
                    <asp:TextBox CssClass="form-control" ID="txttodate" runat="server" Text="Select Date"></asp:TextBox>
               
                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txttodate"
                    PopupButtonID="txttodate" EnabledOnClient="true" Format="dd/MM/yyyy" runat="server"
                    CssClass="cal_Theme1">
                </ajaxToolkit:CalendarExtender>
           </div>
           <div class="col-lg-3">
                <div id="leg" runat="server">
                    <label>
                        Select Company</label>
                    <asp:DropDownList ID="ddloutlet" runat="server" CssClass="form-control">
                        <%--<asp:ListItem Text="select" Value="0"></asp:ListItem>--%>
                        <asp:ListItem Text="CO1" Value="CO1"></asp:ListItem>
                        <asp:ListItem Text="CO2" Value="CO2"></asp:ListItem>
                        <asp:ListItem Text="CO3" Value="CO3"></asp:ListItem>
                        <%-- <asp:ListItem Text="All" Value="All"></asp:ListItem>--%>
                    </asp:DropDownList>
                </div>
                </div>
                <%-- <asp:Button ID="btnfind" runat="server" Text="Find" CssClass="btn btn-success" 
                                                onclick="btnfind_Click" />

                                                 <asp:Button ID="btnall" runat="server" Text="View All" 
                                                CssClass="btn btn-success" onclick="btnall_Click" 
                                                />--%>
          <br />
          
           <div class="col-lg-3">
                <asp:Button ID="btngen" runat="server" Text="Generate Report" CssClass="btn btn-info pos-btn1" 
                    OnClick="btngen_Click"/>
                   
                    
                    
                   
                    
                <%-- <asp:Button ID="btnreset" runat="server" Text="Reset" 
                                            CssClass="btn btn-success" onclick="btnreset_Click" 
                                                />--%>
                                &nbsp; &nbsp;  &nbsp; &nbsp; <asp:Button ID="btnprint" runat="server" CssClass="btn btn-secondary" Text="Print" Width="100px"
                     onclientclick="javascript:CallPrint('bill');" />
         
           
                <asp:Button ID="btnexcel" runat="server" Text="Export to Excel" CssClass="btn btn-primary"
                    OnClick="btnexcel_Click" Width="150px" Style="margin-top: 24px; margin-left: -30px"
                    Visible="false" />
          
                </div>
     </div>
     
     
               
                 <div class="row">  
              
                   
                        <div class="col-lg-12" id="bill">
                           
                                <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
                                    ID="val1" ShowMessageBox="true" ShowSummary="false" />
                                <h2 align="center">
                                    <asp:Label ID="lblMessage" Style="color: #007aff;" runat="server"></asp:Label></h2>
                                    <div class="table-responsive panel-grid-left">
                                <div  id="idt" visible="false"
                                    runat="server">
                                   
                                   <%-- <table id="Table1" runat="server" style="border: 1px solid Grey; height: 30px; background-color: #cccccc;
                                        text-transform: uppercase" width="100%">
                                        <tr>
                                            <td width="6%" align="center" style="font-size: large">
                                                Date
                                            </td>
                                            <td width="41%" align="center" style="font-size: large">
                                                Particulars
                                                <asp:Label ID="lblOB" Visible="false" runat="server"></asp:Label>
                                            </td>
                                            <td width="13%" align="center" style="font-size: large">
                                                Narration
                                            </td>
                                            <td width="15%" align="center" style="font-size: large">
                                                Debit
                                            </td>
                                            <td width="15%" align="center" style="font-size: large">
                                                Credit
                                            </td>
                                        </tr>
                                    </table>--%>
                                    <asp:Label ID="lblopbal" runat="server"></asp:Label>
                                    
                                        <asp:GridView runat="server" ID="gvLedger" AutoGenerateColumns="false" OnRowCreated="gridPurchase_RowCreated" cssClass="table table-striped pos-table"
                                            AllowPrintPaging="true" OnRowDataBound="gvLedger_RowDataBound" padding="0" spacing="0" border="0">
                                           
                                            <Columns>
                                                <%-- <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="5%">
                        <ItemTemplate>
                            <asp:Label ID="lblTranDate" runat="server" Text='<%# Eval("Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>--%>
                                                <asp:BoundField DataField="Date" HeaderText="Date" ItemStyle-Width="200px" DataFormatString="{0:d}" />
                                                <%-- <asp:BoundField ItemStyle-VerticalAlign="Top" ItemStyle-Width="11%" ItemStyle-HorizontalAlign="Center"
                        DataField="Branchcode" HeaderText="Branch" />--%>
                                                <asp:BoundField DataField="Particulars" HeaderText="Particulars" ItemStyle-Width="300px" />
                                                <asp:BoundField DataField="Narration" HeaderText="Narration" ItemStyle-Width="300px" />
                                                <asp:BoundField ItemStyle-Width="60px" HeaderText="Debit" DataFormatString="{0:n2}" DataField="Debit" />
                                                <asp:BoundField ItemStyle-Width="60px" HeaderText="Credit" DataFormatString="{0:n2}" DataField="Credit" />
                                            </Columns>
                                            <PagerTemplate>
                                            </PagerTemplate>
                                        </asp:GridView>
                                        
                                        
                                        <asp:GridView runat="server" ID="gvLed" Visible="false" AutoGenerateColumns="false" cssClass="table table-striped pos-table"
                                            OnRowCreated="gridPur_RowCreated" AllowPrintPaging="true" OnRowDataBound="gvLed_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField ItemStyle-VerticalAlign="Top" ItemStyle-Width="5%">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblTranDate" runat="server" Text='<%# Eval("Date") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <%-- <asp:BoundField ItemStyle-VerticalAlign="Top" ItemStyle-Width="11%" ItemStyle-HorizontalAlign="Center"
                        DataField="Branchcode" HeaderText="Branch" />--%>
                                                <asp:BoundField DataField="Particulars" HeaderText="Particulars" ItemStyle-Width="300px" />
                                                <asp:BoundField DataField="Narration" HeaderText="Narration" ItemStyle-Width="300px" />
                                                <asp:BoundField ItemStyle-Width="60px" DataFormatString="{0:n}" HeaderText="Debit" DataField="Debit" />
                                                <asp:BoundField ItemStyle-Width="60px" DataFormatString="{0:n}" HeaderText="Credit" DataField="Credit" />
                                            </Columns>
                                            <PagerTemplate>
                                            </PagerTemplate>
                                        </asp:GridView>
                                        
                                        
                                        <table id="Table2" runat="server" width="100%">
                                            <tr id="Tr1" runat="server" visible="false">
                                                <td width="69%" align="right">
                                                    Total :
                                                </td>
                                                <td width="7%" align="right">
                                                    <asp:Label ID="lblSumDebit" runat="server"></asp:Label>
                                                </td>
                                                <td width="7%" align="right">
                                                    <asp:Label ID="lblSumCredit" runat="server"></asp:Label>
                                                </td>
                                                <td width="9%" align="right">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                    </div>
                                    <%--  <asp:Label ID="lblDebitTotal" runat="server" Visible="false"></asp:Label>
    <asp:Label ID="lblCreditTotal" runat="server" Visible="false"></asp:Label>
  
    <table border="1" >
        <tr>
        <td width="890px" align="right">
         <label>Closing balance</label>
        </td>
        <td width="250px" align="right"><asp:Label ID="lblDebitClosingTotal" runat="server"></asp:Label></td>
        <td width="260px" align="right"> <asp:Label ID="lblCreditClosingTotal" runat="server"></asp:Label></td>
        </tr>
         <tr>
        <td style="padding-top:10px" width="880px" align="right">
         <label>Total</label>
        </td>
        <td width="250px" align="right"><asp:Label ID="lblNetDebit" runat="server"></asp:Label></td>
        <td width="260px" align="right"> <asp:Label ID="lblNetCredit" runat="server"></asp:Label></td>
        </tr>
    </table>--%>
                                    <br />
                                </div>
                                <!-- /#page-wrapper -->
                            </div>
                        </div>
                  
               
          
      </div>
   
   </div>
   </div>
   </div>
   </div>
    <!-- /.row -->
    
     </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
