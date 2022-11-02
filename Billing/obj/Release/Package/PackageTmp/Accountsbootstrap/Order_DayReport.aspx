<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Order_DayReport.aspx.cs"
    Inherits="Billing.Accountsbootstrap.Order_DayReport" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <title>Advance/Qty Order Report</title>
    <style type="text/css">
        .button-success, .button-error, .button-warning, .button-secondary
        {
            color: white;
            border-radius: 5px;
            text-shadow: 0 7px 5px rgba(0, 0, 0, 0.2);
        }
        
        .button-success1
        {
            background: rgb(28, 184, 65); /* this is a green */
        }
        
        .button-error
        {
            background: rgb(202, 60, 60); /* this is a maroon */
        }
        
        .button-warning
        {
            background: rgb(223, 117, 20); /* this is an orange */
        }
        
        .button-secondary
        {
            background: rgb(66, 184, 221); /* this is a light blue */
        }
        
        .index1
        {
            text-align: center;
            font-size: 28px;
            font-weight: bold;
            background-color: orange;
            padding-top: 10px;
            padding-bottom: 10px;
            margin-left: 525px;
            margin-right: 525px;
            font-family: Californian FB;
        }
        .buttonhrm
        {
            margin-top: 25px;
        }
        
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=40);
            opacity: 0.4;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            width: 900px;
            text-align: center;
            border: 3px solid #0DA9D0;
        }
        .modalPopup .header
        {
            background-color: #2FBDF1;
            height: 40px;
            color: White;
            line-height: 30px;
            text-align: center;
            font-weight: bold;
        }
        .modalPopup .body
        {
            min-height: 50px;
            line-height: 30px;
            text-align: center;
            padding: 5px;
        }
        .modalPopup .footer
        {
            padding: 3px;
        }
        .modalPopup .button
        {
            height: 23px;
            color: White;
            line-height: 23px;
            text-align: center;
            font-weight: bold;
            cursor: pointer;
            background-color: #9F9F9F;
            border: 1px solid #5C5C5C;
        }
        .modalPopup td
        {
            text-align: left;
        }
        
        .pad
        {
            padding-top: 50px;
        }
    </style>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <script src="../js/Searchjs.js" type="text/javascript"></script>
    <script type="text/javascript">
        function SearchEmployees(txtSearch, cblEmployees) {
            if ($(txtSearch).val() != "") {
                var count = 0;
                $(cblEmployees).children('tbody').children('tr').each(function () {
                    var match = false;
                    $(this).children('td').children('label').each(function () {
                        if ($(this).text().toUpperCase().indexOf($(txtSearch).val().toUpperCase()) > -1)
                            match = true;
                    });
                    if (match) {
                        $(this).show();
                        count++;
                    }
                    else { $(this).hide(); }
                });
                $('#spnCount').html((count) + ' match');
            }
            else {
                $(cblEmployees).children('tbody').children('tr').each(function () {
                    $(this).show();
                });
                $('#spnCount').html('');
            }
        }
    </script>
    <script language="javascript" type="text/javascript">
        function pageLoad() {
            ShowPopup();
            setTimeout(HidePopup, 2000);
        }

        function ShowPopup() {
            $find('modalpopup').show();
            //$get('Button1').click();
        }

        function HidePopup() {
            $find('modalpopup').hide();
            //$get('btnCancel').click();
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
    <link rel="stylesheet" href="../Css/bootstrap.min.css" />
    <script type="text/javascript" src="../jquery/jquery-1.10.2.min.js"></script>
    <script type="text/javascript" src="../jquery/bootstrap.min.js"></script>
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <link href="../Styles/chosen.css" rel="Stylesheet" />
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <usc:Header ID="Header" runat="server" />
    <div class="panel-body">
        <div class="row" align="center">
            .
            <div class="col-lg-10" align="center" style="margin-left: 40px">
                <div class="col-lg-12" style="margin-top: 6px">
                    <h1 class="page-header" style="text-align: center; color: #fe0002; font-size: 20px;
                        font-weight: bold">
                        Todays Order Report</h1>
                </div>
                <div align="center" style="margin-top: 40px; margin-left: -80px">
                    <div class="col-lg-12">
                        <div runat="server" visible="false">
                            <%-- Blaackforestonline@gmail.com--%>
                            <asp:TextBox ID="txtemail" runat="server" Text="online@blaackforestcakes.com"></asp:TextBox>
                        </div>
                        <div class="col-lg-2">
                            <div id="Div1" runat="server">
                                <label>
                                    Select Branch</label>
                                <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <label>
                                From Date</label>
                            <asp:TextBox runat="server" Visible="false" ID="txtCustomerName">
                            </asp:TextBox>
                            <asp:TextBox runat="server" ID="txtfromdate" autocomplete="off" CssClass="form-control">
                            </asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtfromdate"
                                runat="server" CssClass="cal_Theme1">
                            </ajaxToolkit:CalendarExtender>
                            <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtfromdate"
                                ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                            </asp:RangeValidator>
                        </div>
                        <div runat="server" id="idtodate" visible="false" class="col-lg-3">
                            <label>
                                To Date</label>
                            <asp:TextBox runat="server" ID="txttodate" autocomplete="off" CssClass="form-control">
                            </asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txttodate"
                                runat="server" CssClass="cal_Theme1">
                            </ajaxToolkit:CalendarExtender>
                            <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txttodate"
                                ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                            </asp:RangeValidator>
                        </div>
                        <div class="col-lg-3">
                            <asp:RadioButtonList ID="radbtnlist" runat="server" OnSelectedIndexChanged="Radbtn_chnaged"
                                AutoPostBack="true">
                                <asp:ListItem Text="Ordered Detailed Delivery Report" Value="0"> </asp:ListItem>
                                <asp:ListItem Text="Advance" Value="1" Selected="True"> </asp:ListItem>
                                <asp:ListItem Text="Ordered Qty" Value="2"> </asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <asp:Button ID="btnser" runat="server" Text="Generate Report" Style="background-color: #428bca;
                            border: 3px solid #428bca;" CssClass="btn btn-success" Visible="true" OnClick="btnser_Click" />
                        <asp:Button ID="btnemail" runat="server" CssClass="btn btn-default" Text="Email - Order Detailed Report"
                            OnClick="btnSendMail_Click" />
                        <asp:ScriptManager ID="scr1" runat="server">
                        </asp:ScriptManager>
                        <div class="col-lg-12">
                            <div>
                                <asp:GridView ID="gvAdvance" EmptyDataText="Sorry!! No Records Found" runat="server"
                                    AutoGenerateColumns="false" Visible="false">
                                    <HeaderStyle BackColor="Brown" ForeColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Branch Name" DataField="bname" SortExpression="bname" />
                                        <asp:BoundField HeaderText="Customer Name" DataField="CustomerName" SortExpression="CustomerName" />
                                        <asp:BoundField HeaderText="Mobile No" DataField="MobileNo" SortExpression="MobileNo" />
                                        <asp:BoundField HeaderText="Order No" DataField="OrderNo" SortExpression="OrderNo" />
                                        <asp:BoundField HeaderText="Advance" DataField="Advance" SortExpression="Advance" />
                                        <asp:BoundField HeaderText="Order Mode" DataField="type" SortExpression="OrderNo" />
                                    </Columns>
                                </asp:GridView>
                                <asp:GridView ID="gvorderedqty" EmptyDataText="Sorry!! No Records Found" runat="server"
                                    AutoGenerateColumns="false" Visible="false">
                                    <HeaderStyle BackColor="Brown" ForeColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Branch Name" DataField="bname" SortExpression="bname" />
                                        <asp:BoundField HeaderText="Category" DataField="category" SortExpression="category" />
                                        <asp:BoundField HeaderText="Item Name" DataField="Definition" SortExpression="Definition" />
                                        <asp:BoundField HeaderText="Total Qty" DataField="Totalqty" SortExpression="Totalqty" />
                                    </Columns>
                                </asp:GridView>
                                <asp:GridView ID="gvorderinfo" EmptyDataText="Sorry!! No Records Found" runat="server"
                                    AutoGenerateColumns="false" Visible="false">
                                    <Columns>
                                        <asp:BoundField HeaderText="Branch Name" DataField="Branch" />
                                        <asp:BoundField HeaderText="Delivery Date" DataField="Delivery Date" DataFormatString='{0:dd/MMM/yyyy}' />
                                        <asp:BoundField HeaderText="Book No" DataField="Book No" />
                                        <asp:BoundField HeaderText="Order No" DataField="Order No" />
                                        <asp:BoundField HeaderText="Order Date" DataField="Order Date" DataFormatString='{0:dd/MMM/yyyy hh:mm:ss tt}' />
                                        <asp:BoundField HeaderText="Customer Name" DataField="Customer Name" />
                                        <asp:BoundField HeaderText="Mobile No" DataField="Mobilno" />
                                        <asp:TemplateField HeaderText="Item">
                                            <ItemTemplate>
                                                <%# Eval("Item").ToString().Replace(",", "<br />")%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString='{0:f2}' />
                                        <asp:BoundField HeaderText="Delivery Status" DataField="Dstatus" />
                                    </Columns>
                                    <HeaderStyle BackColor="#df5015" Font-Bold="true" ForeColor="White" />
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
