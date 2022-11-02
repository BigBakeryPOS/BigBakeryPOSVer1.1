<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SemiRawSetting.aspx.cs"
    Inherits="Billing.Accountsbootstrap.SemiRawSetting" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Create Semi Raw-Material Setting</title>
    <script src="../js/jquery-1.7.2.js" type="text/javascript"></script>
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <link href="../css/Header.css" rel="stylesheet" type="text/css" />
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
    <link href="Styles/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Styles/bootstrap.css" rel="stylesheet" type="text/css" />
    <link href="../css/submenu1.css" rel="stylesheet" type="text/css" />
    <link href="../Accountsbootstrap/css/mGrid.css" rel="stylesheet" type="text/css" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
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
    <style>
        .chkChoice input
        {
            margin-left: -30px;
        }
        .chkChoice td
        {
            padding-left: 45px;
        }
        
        .chkChoice1 input
        {
            margin-left: -20px;
        }
        .chkChoice1 td
        {
            padding-left: 20px;
        }
    </style>
    <script type="text/javascript" language="javascript">
        function valchk() {
            if (blankchk(document.getElementById('txtcategory'), "Category")) {
                alert("true");
            }
            else {
                alert("false");
                return false;
            }
        }
    </script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" type="text/css" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../css/TableCSSCode.css" rel="stylesheet" type="text/css" />
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style type="text/css"> 
         blink, .blink {
            animation: blinker 1s linear infinite;
        }

       @keyframes blinker { 
            50% { opacity: 0; }
       }
      </style>
</head>
<body style="">
    <asp:Label runat="server" Visible="false" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" Visible="false" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
    <form id="form" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12">
        </div>
    
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="col-lg-4 ">
                                <div class="form-group">
                                    <label>
                                        Upload Data From Excel
                                    </label>
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:FileUpload ID="FileUpload1" runat="server" />
                                            <asp:Button ID="btnAsyncUpload" Visible="false" runat="server" Text="Async_Upload"
                                                OnClick="Async_Upload_File" />
                                            <asp:Button ID="btnUpload" CssClass="btn btn-danger" runat="server" Text="Upload"
                                                OnClick="Upload_File" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="btnAsyncUpload" EventName="Click" />
                                            <asp:PostBackTrigger ControlID="btnUpload" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                    <asp:GridView ID="GridView2" runat="server">
                                    </asp:GridView>
                                </div>
                                <div class="form-group" align="center">
                                    <div class="panel panel-default">
                                        <div class="panel-heading" style="background-color: #0071BD; color: White">
                                            <b>Recipe Setting Details</b>
                                        </div>
                                        <div class="panel-body">
                                            <%-- <h2 align="center">
                                        Receipe Setting Details
                                    </h2>--%>
                                        </div>
                                        <asp:GridView ID="gridview" runat="server" PagerStyle-CssClass="pager" Width="100%" Font-Names="Calibri"
                                            HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="false" PageSize="20"
                                            AutoGenerateColumns="false" AllowSorting="true" OnRowCommand="gvcat_RowCommand">
                                             <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> 
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                NextPageText="Next" PreviousPageText="Previous" />
                                            <Columns>
                                                <%--<asp:BoundField HeaderText="Category ID" DataField="CategoryID" />--%>
                                                <asp:BoundField HeaderText="Item Name" DataField="definition" />
                                                <asp:TemplateField HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnedit" ForeColor="White" CommandName="et" CommandArgument='<%#Eval("SettingId") %>'
                                                            runat="server">
                                                            <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server"  width="55px"/></asp:LinkButton>
                                                        <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="true" HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btndel" CommandArgument='<%#Eval("SettingId") %>' CommandName="Del"
                                                            runat="server">
                                                            <asp:Image ID="Image1" ImageUrl="~/images/delete.png" runat="server" /></asp:LinkButton>
                                                        <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                            CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btndel"
                                                            PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                                        </ajaxToolkit:ModalPopupExtender>
                                                        <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                            TargetControlID="btndel" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                        <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <div runat="server" id="listitem" visible="false" class="col-lg-3">
                                <div class="panel panel-default">
                                    <div class="panel-heading" style="background-color: #0071BD; color: White">
                                        <b>Details</b>
                                    </div>
                                    <div class="panel-body">
                                        <label>
                                            Item List:
                                            <asp:Label ID="lblsettingname" runat="server"></asp:Label>
                                        </label>
                                        <label>
                                            Measurement Used Per Qty:
                                            <%-- Prepared for this Receipe Setting: --%>
                                            <asp:Label ID="lblqty" runat="server"></asp:Label></label>
                                        <asp:GridView ID="gridview1" runat="server" PagerStyle-CssClass="pager"
                                            HeaderStyle-CssClass="header" GridLines="Both" RowStyle-CssClass="rows" AllowPaging="false"
                                            PageSize="20" HeaderStyle-BackColor="#428bca" HeaderStyle-ForeColor="white" AutoGenerateColumns="false"
                                            AllowSorting="true">
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                NextPageText="Next" PreviousPageText="Previous" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Raw Item Name" DataField="item" />
                                                <asp:BoundField HeaderText="Rec Qty" DataField="recqty" DataFormatString='{0:f}' />
                                                <asp:BoundField HeaderText="UOM" DataField="uom" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-5">
                                <asp:Label ID="lblerrorr" runat="server"></asp:Label>
                                <%--  <blink> <label  style="color:Green; font-size:12px">Hint: Configure Required Raw material Quantity for Receipe.</label></blink>--%>
                                <div class="panel panel-default">
                                    <div class="panel-heading" style="background-color: #0071BD; color: White">
                                        <b>Recepie Setting Creation </b>
                                    </div>
                                    <div class="panel-body">
                                        <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                                        <div class="col-lg-12">
                                            <div class="col-lg-6">
                                                <label>
                                                    Select Item Name</label><br />
                                                <asp:DropDownList ID="drpitem" runat="server" CssClass="chzn-select" Width="200px">
                                                </asp:DropDownList>
                                                <label id="lblRawID" visible="false" runat="server">
                                                </label>
                                                <label style="padding-top: 10px">
                                                    Per Qty Recipe Setting</label>
                                                <asp:TextBox ID="txtprepareqty" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="col-lg-6">
                                                <label>
                                                    Production hours(In MIN)</label>
                                                <asp:TextBox ID="txtproductionhours" runat="server" CssClass="form-control"></asp:TextBox>
                                                <label>
                                                    Select Raw Item List</label>
                                                <asp:TextBox ID="txtsearching" runat="server" placeholder="Search Raw Material .."
                                                    onkeyup="Search_Gridview(this, 'gridsemiitem')" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-12">
                                            <br />
                                            <div class="panel panel-default" style="height: 400px; overflow: scroll">
                                                <asp:GridView ID="gridsemiitem" Width="100%" AutoGenerateColumns="false" runat="server" Font-Names="Calibri">
                                                 <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> 
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Raw Item Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblsemiitemid" Visible="false" runat="server" Text='<%#Eval("IngridID") %>'></asp:Label>
                                                                <asp:Label ID="Label1" Visible="true" runat="server" Text='<%#Eval("IngredientName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Required Qty">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtrecqty" runat="server"></asp:TextBox>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="UOM">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lbluom" Visible="true" runat="server" Text='<%#Eval("uom") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField>
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chklist" runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                                <br />
                                            </div>
                                            <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Save" OnClick="Add_Click"
                                                ValidationGroup="val1" AccessKey="s" />
                                            <asp:Button ID="btnexit" runat="server" class="btn btn-warning" Text="Exit" OnClick="Exit_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.col-lg-6 (nested) -->
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">        $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    </form>
</body>
</html>
