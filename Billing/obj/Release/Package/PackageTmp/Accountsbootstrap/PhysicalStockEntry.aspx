<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PhysicalStockEntry.aspx.cs"
    Inherits="Billing.Accountsbootstrap.PhysicalStockEntry" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
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
    <style type="text/css">
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 140px;
        }
    </style>
    <style>
        table table thead
        {
            display: block;
            position: relative;
        }
    </style>
    <script language="Javascript">

        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
       
    </script>
    <title></title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
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
</head>
<body>
    <form id="form1" runat="server">
    <usc:Header ID="Header" runat="server" />
    <asp:ScriptManager ID="scr" runat="server">
    </asp:ScriptManager>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <div class="container-fluid">
        <div class="row">
            <div class="col-lg-12">
                <div class="row panel-custom1">
                    <div class="panel-header">
                        <h1 class="page-header">
                            Physical Stock Entry</h1>
                    </div>
                    <div class="panel-body">
                        <div class="row">
                            <div class="col-lg-3">
                                <br />
                                <div class="form-group has-feedback">
                                    <asp:TextBox ID="txtSearch" placeholder="Search Table.." MaxLength="50" CssClass="form-control"
                                        runat="server" onkeyup="Search_Gridview(this, 'gvtransfer')"></asp:TextBox>
                                    <span class="glyphicon glyphicon-search form-control-feedback"></span>
                                </div>
                            </div>
                            <div class="col-lg-3">
                                <label>
                                    Upload Data From Excel</label>
                                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <asp:FileUpload ID="FileUpload1" runat="server" Style="display: inline" Width="200px" />
                                        <asp:Button ID="btnAsyncUpload" Visible="false" runat="server" Text="Async_Upload"
                                            OnClick="Async_Upload_File" />
                                        <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload_File" CssClass="btn btn-primary pos-btn1" />
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="btnAsyncUpload" EventName="Click" />
                                        <asp:PostBackTrigger ControlID="btnUpload" />
                                    </Triggers>
                                </asp:UpdatePanel>
                                <asp:GridView ID="GridView2" runat="server">
                                </asp:GridView>
                            </div>
                            <div class="col-lg-4">
                                <label style="color: #007aff">
                                    NOTE : This Missing Item Only For Temporary View Purpose So Please Copy And Paste
                                    in Your Excel Sheet</label><br />
                                <label>
                                    Missing Items</label>
                            </div>
                            <div class="col-lg-2">
                                <asp:Button ID="btnsend" runat="server" Text="Save" CssClass="btn btn-lg btn-primary pos-btn1"
                                    OnClick="btnsend_Click" />
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-6">
                                <div class="table-responsive panel-grid-left">
                                    <asp:GridView ID="gvtransfer" runat="server" AutoGenerateColumns="false" EnableViewState="true"
                                        CssClass="table table-striped pos-table" padding="0" spacing="0" border="0">
                                        <Columns>
                                            <asp:BoundField HeaderText="id" DataField="IngridID" />
                                            <asp:BoundField HeaderText="Category Name" DataField="IngreCategory" />
                                            <asp:BoundField HeaderText="Item Name" DataField="IngredientName" />
                                            <asp:BoundField HeaderText="Op Stock" DataField="Qty" />
                                            <asp:BoundField HeaderText="UOM" DataField="uom" />
                                            <asp:TemplateField HeaderText="Physical Stock">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbluomid" Visible="false" runat="server" Text='<%#Eval("uomid") %>'></asp:Label>
                                                    <asp:TextBox ID="txtphystock" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:RequiredFieldValidator runat="server" ID="txtstock" ControlToValidate="txtphystock"
                                                        ValidationGroup="val2" Text="*" ErrorMessage="Please enter your Category!" Style="color: Red" />
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                        FilterType="Numbers,Custom" ValidChars="-." TargetControlID="txtphystock" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rate">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtrate" runat="server" CssClass="form-control"></asp:TextBox>
                                                    <asp:Label ID="lblbrate" ToolTip="Current Rate" Font-Bold="true" ForeColor="Red"
                                                        Font-Size="X-Large" runat="server" Text='<%#Eval("rate") %>'></asp:Label>
                                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtenderd2" runat="server"
                                                        FilterType="Numbers,Custom" ValidChars="." TargetControlID="txtrate" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Exp date">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtexpireddate" runat="server" Enabled="true" Width="100px" CssClass="form-control">0</asp:TextBox>
                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtexpireddate"
                                                        PopupButtonID="txtexpireddate" EnabledOnClient="true" Format="dd/MM/yyyy" runat="server"
                                                        CssClass="cal_Theme1">
                                                    </ajaxToolkit:CalendarExtender>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                            <div class="col-lg-6">
                                <div class="table-responsive panel-grid-left">
                                    <asp:GridView ID="gridmissitem" runat="server" EmptyDataText="No Missing Data Found"
                                        CssClass="table table-striped pos-table" padding="0" spacing="0" border="0" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:BoundField DataField="Item" HeaderText="Missing Items" />
                                            <asp:BoundField DataField="Qty" HeaderText="OP Qty" DataFormatString='{0:d}' />
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
    </form>
</body>
</html>
