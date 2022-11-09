<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DAYCloseSTock.aspx.cs"
    Inherits="Billing.Accountsbootstrap.DAYCloseSTock" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stock Flow Report</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <link href="../Styles/chosen.css" rel="Stylesheet" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="preconnect" href="https://fonts.googleapis.com">
     <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
     <link href="https://fonts.googleapis.com/css2?family=Lato:wght@400;700;900&display=swap" rel="stylesheet">
     <link href="../css/Pos_style.css" rel="stylesheet" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%# gvDetails.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');

            prtWindow.document.write(gridData.outerHTML);

            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }

       
    </script>
    <script language="javascript" type="text/javascript">

$("[id$=myButtonControlID]").click(function(e) {
    window.open('data:application/vnd.ms-excel,' + encodeURIComponent( $('div[id$=Excel]').aspx()));
    e.preventDefault();
});​

    </script>
    <script type="text/javascript">
        function Closed() {
            alert('Thank You.Day Closed Successfully!!!');
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
</head>
<body>
    <%--<usc:Header ID="Header" runat="server" />--%>
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
     <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
    <form id="form1" runat="server">
     <div class="panel-header">
          <h1 class="page-header">Day Close Stock</h1>
	    </div>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div class="panel-body">
      
    <div class="row">
    <div class="col-lg-2">
        <label>
            Branch</label>
            <br />
        <asp:Label ID="lblbranch" runat="server" Font-Bold="true" ForeColor="Red"></asp:Label>
        </div>
        <div class="col-lg-3" runat="server" visible="true" >
           <label> Stock Closing Name</label>
            <asp:TextBox ID="txtnam" runat="server" class="form-control"></asp:TextBox>
        </div>
        <div class="col-lg-3" runat="server" visible="false">
            <label>Filter Items</label>
            <asp:TextBox ID="txtserch" runat="server" CssClass="form-control" placeholder="Filter Items"
                onkeyup="Search_Gridview(this, 'gvDetails')"></asp:TextBox>
        </div>
        <div class="col-lg-3">
            <label>Date Selection</label>
            <asp:TextBox ID="txttodate" runat="server" CssClass="form-control" 
                placeholder="Select Date" AutoPostBack="true" OnTextChanged="txttodate_TextChanged"></asp:TextBox>
            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txttodate"
                runat="server" CssClass="cal_Theme1">
            </ajaxToolkit:CalendarExtender>
        </div>
        <div class="col-lg-3">
        <br />
            <asp:Button ID="btnser" runat="server" Text="Close Day " OnClick="btnser_Click" CssClass="btn btn-primary pos-btn1" />
            &nbsp;&nbsp;&nbsp;<asp:Button ID="Button2" runat="server" Text="Billing Screen " PostBackUrl="~/Accountsbootstrap/NewButton.aspx"
                CssClass="btn btn-success" />
            <asp:Button ID="Button1" runat="server" Text="Print" Visible="false" OnClick="Button1_Click"
                CssClass="btn btn-success" />
            <asp:Button ID="myButtonControlID" runat="server" Text="Export" CssClass="btn btn-warning"
                Visible="false" />
        </div>
    </div>
    <div id="Excel" runat="server">
        <asp:GridView ID="gvDetails" runat="server" CssClass="mGrid" EmptyDataText="No Records Found"
            Caption="Grn Qty" AutoGenerateColumns="false" Width="70%">
            <Columns>
                <asp:BoundField HeaderText="Group" DataField="Group" />
                <asp:BoundField HeaderText="Item" DataField="Item" />
                <asp:BoundField HeaderText="OP-Stock" DataField="OpeningStock" DataFormatString="{0:N0}" />
                <asp:BoundField HeaderText="GrnQty" DataField="GRNQty" DataFormatString="{0:n0}" />
                <asp:BoundField HeaderText="Available Qty" DataField="Available_Qty" DataFormatString="{0:n0}" />
                <asp:BoundField HeaderText="SalesQty" DataField="SalesQty" DataFormatString="{0:n}" />
                <asp:BoundField HeaderText="Return" DataField="Return" DataFormatString="{0:n}" />
                <asp:BoundField HeaderText="ClosingStock" DataField="ClosingStock" DataFormatString="{0:n}" />
            </Columns>
        </asp:GridView>
    </div>
    </div>
   
   
   
    </form>
     </div>
     </div>
    </div>
    </div>
</body>
</html>
