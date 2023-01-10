<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemsReturnReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.ItemsReturnReport" %>

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
    <title>Home</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <!-- Bootstrap Core CSS -->
    <link href="../Styles/style1.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= gvReturns.ClientID %>');
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
    <style type="text/css">
        .blink
        {
            text-decoration: blink;
        }
    </style>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
     <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Stock Return Report</h1>
	    </div>
   <div class="panel-body">
   
        
        <div class="row">
            <div class="col-lg-3">
              
                    <label>
                        Branch</label>
                    <asp:DropDownList ID="ddlBranch" runat="server" CssClass="form-control">
                    </asp:DropDownList>
               
            </div>
            <div class="col-lg-3">
               
                    <label>
                        From date</label>
                    <asp:TextBox runat="server" ID="txtfromdate" CssClass="form-control" >
                    </asp:TextBox>
                    <%--<asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtfromdate"
                        ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                    </asp:RangeValidator>--%>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfromdate"
                        Format="MM/dd/yyyy" runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
               
            </div>
            <div class="col-lg-3">
               
                    <label>
                        To date</label>
                    <asp:TextBox runat="server" ID="txttodate" CssClass="form-control" >
                    </asp:TextBox>
                    <%--<asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txttodate"
                        ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                    </asp:RangeValidator>--%>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txttodate"
                        Format="MM/dd/yyyy" runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                
            </div>
            <div class="col-lg-3">
                
                    <label>
                        Reasons</label>
                    <asp:DropDownList ID="ddlreason" runat="server" CssClass="form-control" >
                    </asp:DropDownList>
               
            </div>
            <div class="col-lg-6">
                
                    <br />
                    <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-success pos-btn1" Text="Search" Width="100px"
                        OnClick="btnSearch_Click" />
               
    
                   &nbsp; &nbsp; &nbsp; <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-secondary" Width="100px"
                        OnClick="btnPrint_Click" />
                
          
                   &nbsp; &nbsp; &nbsp;  <asp:Button ID="btnExp" runat="server" Text="Export" CssClass="btn btn-success" Width="100px"
                        OnClick="btnExp_Click1" />
                
            </div>
          </div>
       
       
        <div class="col-lg-12">
        <div class="row">
        <div id="div1" runat="server">
            <div class="table-responsive panel-grid-left">
                <asp:GridView ID="gvReturns"  runat="server" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                    AutoGenerateColumns="false"  EmptyDataText="No Records Found"
                    Width="100%">
                    <Columns>
                        <asp:BoundField HeaderText="Return No" DataField="RetNo" Visible="false" />
                        <asp:BoundField HeaderText="DATEPART" DataField="DATEPART" DataFormatString="{0:dd/MMM/yyyy}" />
                        <asp:BoundField HeaderText="TIMEPART" DataField="TIMEPART" />
                        <asp:BoundField HeaderText="ReturnDate" DataField="ReturnDate" DataFormatString="{0:dd/MMM/yyyy}" />
                        <asp:BoundField HeaderText="Branch" DataField="LocalBranch" />
                        <asp:BoundField HeaderText="BranchRetNo" DataField="LocalRetNo" />
                        <asp:BoundField HeaderText="Group" DataField="category" />
                        <asp:BoundField HeaderText="Item" DataField="Definition" />
                        <asp:BoundField HeaderText="Qty" DataField="Quantity" />
                        <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:N2}" />
                        <asp:BoundField HeaderText="Reason" DataField="Reason" />
                        <asp:BoundField HeaderText="Sub Reason" DataField="SubReasons" />
                        <asp:BoundField HeaderText="Name" DataField="Name" />
                        <asp:BoundField HeaderText="SaveTime" DataField="saveDateTime" />
                    </Columns>
                    <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                    <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                </asp:GridView>
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
</body>
</html>
