<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderBalanceAmount_Report.aspx.cs"
    Inherits="Billing.Accountsbootstrap.OrderBalanceAmount_Report" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <title>Order Balance Report</title>
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
                        Order Balance Report</h1>
                </div>
                <div align="center" style="margin-top: 40px; margin-left: -80px">
                    <div class="col-lg-12">
                        <div class="col-lg-12">
                            <div class="col-lg-3">
                                <label>
                                    Select date</label>
                                <asp:TextBox runat="server" Visible="false" ID="txtCustomerName">
                                </asp:TextBox>
                                <asp:TextBox runat="server" ID="txtfromdate" CssClass="form-control" Width="100px"
                                    AutoPostBack="true" OnTextChanged="txttodate_TextChanged">
                                </asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtfromdate"
                                    runat="server" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                                <asp:Button ID="btnser" runat="server" Text="Generate Report" CssClass="btn btn-success"
                                    Visible="true" OnClick="btnser_Click" />
                                <asp:ScriptManager ID="scr1" runat="server">
                                </asp:ScriptManager>
                            </div>
                            <div class="col-lg-3">
                                <div id="Div1" runat="server">
                                    <label>
                                        Select Branch</label>
                                    <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server">
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div>
                                <asp:GridView ID="gvReport" EmptyDataText="Sorry!! No Records Found" GridLines="Both"
                                    CellPadding="4" ForeColor="#333333" runat="server" AutoGenerateColumns="false"
                                    ShowFooter="True" OnRowDataBound="gvreport_RowDataBound" Font-Size="Small">
                                    <Columns>
                                        <asp:TemplateField HeaderText="S No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:BoundField HeaderText="Branch Name" DataField="bname" SortExpression="OrderNo" />
                                        <asp:BoundField HeaderText="ORDER NO" DataField="OrderNo" SortExpression="OrderNo" />
                                        <asp:BoundField HeaderText="CUSTOMER NAME" DataField="CustomerName" SortExpression="CustomerName" />
                                        <asp:BoundField HeaderText="TOTAL AMOUNT" DataField="Total" SortExpression="Total"
                                            DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField HeaderText="ADVANCE" DataField="Advance" SortExpression="Advance"
                                            DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right" />
                                        <asp:BoundField HeaderText="BALANCE" DataField="Balance" SortExpression="Balance"
                                            DataFormatString="{0:###,##0.00}" ItemStyle-HorizontalAlign="Right" />
                                    </Columns>
                                    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Right" />
                                    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" Font-Names="Comic Sans MS" />
                                </asp:GridView>
                                <br />
                                <br />
                                <br />
                                <div class="col-lg-12" id="divtot" runat="server" visible="false">
                                    Total balance Amount
                                    <asp:Label ID="Lbltotal" runat="server" Font-Bold="true"></asp:Label>
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
