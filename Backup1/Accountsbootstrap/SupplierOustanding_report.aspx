<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SupplierOustanding_report.aspx.cs" Inherits="Billing.Accountsbootstrap.SupplierOustanding_report" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Supplier OutStanding</title>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Sales </title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../css/TableCSSCode.css" rel="stylesheet" type="text/css" />
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../css/chosen.css" />
    <script type="text/javascript">
        function Denomination123() {


            var gridData = document.getElementById('IDValues');


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
        $(function () {
            $("[id*=btnShowPopup]").click(function () {
                ShowPopup();
                return false;
            });
        });
        function ShowPopup() {
            $("#dialog").dialog({
                title: "GridView",
                width: 450,
                buttons: {
                    Ok: function () {
                        $(this).dialog('close');
                    }
                },
                modal: true
            });
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
<style type="text/css">
    body
    {
        font-family: Arial;
        font-size: 10pt;
    }
    .GridPager a, .GridPager span
    {
        display: block;
        height: 20px;
        width: 20px;
        font-weight: bold;
        text-align: center;
        text-decoration: none;
    }
    .GridPager a
    {
        background-color: #f5f5f5;
        color: #969696;
        border: 1px solid #969696;
    }
    .GridPager span
    {
        background-color: #A1DCF2;
        color: #000;
        border: 1px solid #3AC0F2;
    }
    
    
    .mGrid
    {
        border-collapse: collapse;
        width: 100%;
        border: 1px solid gray;
        overflow: hidden;
        font-family: Calibri;
        font-size: medium;
        text-align: center;
    }
</style>
<script type="text/javascript">
    function alertMessage() {
        alert('Are You Sure, You want to delete This Customer!');
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


    function Diaplay() {
        var div = document.getElementById("div");

        if (div.style.display == "none") {
            div.style.display = "inline";




        }
        else {
            div.style.display = "none";


        }
    }
</script>
<body>
    <usc:Header ID="Header" runat="server" />
    <form id="f1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
        <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Supplier OutStanding</h1>
	    </div>

        <div class="panel-body">
            <div class="row">
                <div class="col-lg-12">
                    
                    <div  runat="server" visible="false" >
                        
                            <label>
                                Type</label>
                            <asp:DropDownList ID="ddltype" runat="server" CssClass="form-control" Width="110px">
                                <asp:ListItem Text="Summary" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Detailed" Value="2" Selected="True" ></asp:ListItem>
                            </asp:DropDownList>
                      
                    </div>  
                    <div class="col-lg-3">
                        <label>
                             Date</label>
                        <asp:TextBox ID="txtfromdate" CssClass="form-control" runat="server" ></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtfromdate"
                            Format="dd/MM/yyyy" PopupButtonID="txtfromdate" runat="server" CssClass="cal_Theme1">
                        </ajaxToolkit:CalendarExtender>
                    </div>
                  
                    <div class="col-lg-3">
                        <label>
                            Supplier
                        </label>
                        <asp:DropDownList runat="server" ID="ddlcustomerrep" CssClass="form-control" >
                        </asp:DropDownList>
                    </div>
                  
                    <div class="col-lg-6">
                      
                            <br />
                            <asp:Button ID="btnsearch" runat="server" class="btn btn-info pos-btn1" Text="View Report" Width="100px"
                                OnClick="btnsearch_OnClick" />
                 
                       
                            &nbsp;&nbsp;&nbsp;<asp:Button ID="btn" runat="server" Text="Print" Visible="true" CssClass="btn btn-secondary"
                                OnClientClick="Denomination123()" Width="100px" />
                       
                           &nbsp;&nbsp;&nbsp; <asp:Button ID="btnExcel" runat="server" Text="Export To Excel" Visible="true" CssClass="btn btn-success"
                                OnClick="btnexp_Click" />
                        </div>
                    </div>
                   
                </div>
            
            <div class="row">
                <div class="col-lg-12">
                        <div class="col-lg-3">
                            <asp:TextBox placeholder="Search Text" ID="txtsearchmobile" Style="height: 28px;"
                                runat="server" CssClass="form-control" MaxLength="25" Visible="false" onkeyup="Search_Gridview(this, 'gv')"></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtendername" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Custom,Numbers" ValidChars=" ._/-"
                                TargetControlID="txtsearchmobile" />
                        </div>
                </div>
            </div>

            <div id="IDValues" runat="server">
                <div id="div1" runat="server">
                    <div class="col-lg-12">
                      <div class="table-responsive panel-grid-left">
                            <asp:GridView ID="gvreceiptamt" EmptyDataText="Oops! No Activity Performed." cssClass="table table-striped pos-table"
                                Caption="Supplier OutStanding Details" OnRowDataBound="gvreceiptamt_OnRowDataBound"
                                runat="server" AutoGenerateColumns="false" ShowFooter="true" padding="0" spacing="0" border="0">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="DCNo" DataField="DCNo" />
                                    <asp:BoundField HeaderText="BillNo" DataField="BillNo" />
                                    <asp:BoundField HeaderText="BillDate" DataField="BillDate" DataFormatString="{0:dd/MMM/yyyy}" />
                                    <asp:BoundField HeaderText="SupplierName" DataField="CustomerName" />
                                    <asp:BoundField HeaderText="MobileNo" DataField="MobileNo" />
                                    <asp:BoundField HeaderText="NetAmount" DataField="NetAmount" DataFormatString="{0:f}" />
                                    <asp:BoundField HeaderText="Receipt" DataField="Receipt" DataFormatString="{0:f}" />
                                    <asp:BoundField HeaderText="ReturnAmount" DataField="ReturnAmount" DataFormatString="{0:f}" />
                                    <asp:BoundField HeaderText="CloseDiscount" DataField="CloseDiscount" DataFormatString="{0:f}" Visible="false" />
                                    <asp:BoundField HeaderText="Balance" DataField="Balance" DataFormatString="{0:f}" />
                                    <asp:BoundField HeaderText="Days Difference" DataField="DateDiff" />
                                    <asp:BoundField HeaderText="Actual Payment date" DataField="real_dt" DataFormatString="{0:dd/MMM/yyyy}" />
                                    <asp:BoundField HeaderText="Supplier Payment Days" DataField="paymentdays" />
                                </Columns>
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
    <script src="../bower_components/jquery/dist/jquery.min.js"></script>
    <script src="../bower_components/bootstrap/dist/js/bootstrap.min.js"></script>
    <script src="../bower_components/metisMenu/dist/metisMenu.min.js"></script>
    <script src="../bower_components/raphael/raphael-min.js"></script>
    <script src="../bower_components/morrisjs/morris.min.js"></script>
    <script src="../js/morris-data.js"></script>
    <script src="../dist/js/sb-admin-2.js"></script>
    </form>
</body>
</html>

