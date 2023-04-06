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
     <script type="text/javascript">
        function ClientSideClick(myButton) {
            // Client side validation

            if (typeof (Page_ClientValidate) == 'function') {
                if (Page_ClientValidate() == false)
                { return false; }
            }

            //make sure the button is not of type "submit" but "button"
            if (myButton.getAttribute('type') == 'button') {
                // disable the button
                myButton.disabled = true;
                myButton.className = "btn-inactive";
                myButton.value = "processing...";

            }
            return true;
        }
     </script>
    <style>
        .chkChoice input {
            margin-left: -30px;
        }

        .chkChoice td {
            padding-left: 45px;
        }

        .chkChoice1 input {
            margin-left: -20px;
        }

        .chkChoice1 td {
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
            50% {
                opacity: 0;
            }
        }
    </style>
    
    <style type="text/css">
        .overlay {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }

        .GridviewDiv {
            font-size: 100%;
            font-family: 'Lucida Grande', 'Lucida Sans Unicode', Verdana, Arial, Helevetica, sans-serif;
            color: #303933;
        }

        .headerstyle {
            color: #FFFFFF;
            border-right-color: #abb079;
            border-bottom-color: #abb079;
            background-color: #df5015;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }
    </style>
     <script type="text/javascript">
 function isDecimal(evt)
    {
       var charCode = (evt.which) ? evt.which : event.keyCode
       var parts = evt.srcElement.value.split('.');
       if(parts.length > 1 && charCode==46)
          return false;
       else
       {
          if (charCode == 46 || (charCode >= 48 && charCode <= 57))
             return true;
          return false;
       }
    }
    
        function isNumberKey(evt) {
            var charCode = (evt.which) ? evt.which : evt.keyCode;
            if (charCode != 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
                return false;

            return true;
        }
       
      </script>
    <script type="text/javascript">
        function ClientSideClick(myButton) {
            // Client side validation

            if (typeof (Page_ClientValidate) == 'function') {
                if (Page_ClientValidate() == false)
                { return false; }
            }

            //make sure the button is not of type "submit" but "button"
            if (myButton.getAttribute('type') == 'button') {
                // disable the button
                myButton.disabled = true;
                myButton.className = "btn-inactive";
                myButton.value = "processing...";

            }
            return true;
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
</head>
<body style="">
    <asp:Label runat="server" Visible="false" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" Visible="false" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
    <form id="form" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-12">
                    <div class="col-lg-6">
                        <div class="row panel-custom1">
                            <div class="panel-header">
                                <h1 class="page-header">Recipe Setting Details</h1>
                            </div>
                            <div class="panel-body">
                                <div class="row">
                                    <div class="col-lg-6 ">
                                        <label>
                                            Upload Data From Excel
                                        </label>
                                        <asp:UpdatePanel ID="UpdatePanela" runat="server">
                                            <ContentTemplate>
                                                <asp:FileUpload ID="FileUpload1" runat="server" Style="display: inline" Width="50%" />
                                                <asp:Button ID="btnAsyncUpload" Visible="false" runat="server" Text="Async_Upload"
                                                    OnClick="Async_Upload_File" />
                                                <asp:Button ID="btnUpload" CssClass="btn btn-danger pos-btn1" runat="server" Text="Upload"
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
                                    <div class="col-lg-6"><br />
                                         <asp:Button ID="Button1" Text="Reset" CssClass="btn btn-secondary"  runat="server"  OnClick="btnReset_Click" />

                                    </div>
                                    <div class="col-lg-12">
                                        <div class="table-responsive panel-grid-left">
                                            <asp:GridView ID="gridview" runat="server" PagerStyle-CssClass="pager" Width="100%" CssClass="table table-striped pos-table"
                                                HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="false" PageSize="20"
                                                AutoGenerateColumns="false" AllowSorting="true" OnRowCommand="gvcat_RowCommand" padding="0" spacing="0" border="0">
                                                <PagerStyle CssClass="pos-paging" />
                                                <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> 
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                NextPageText="Next" PreviousPageText="Previous" />--%>
                                                <Columns>
                                                    <%--<asp:BoundField HeaderText="Category ID" DataField="CategoryID" />--%>
                                                    <asp:BoundField HeaderText="Item Name" DataField="definition" />
                                                     <asp:TemplateField HeaderText="View">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnView" ForeColor="White" CommandName="view" CommandArgument='<%#Eval("SettingId") %>'
                                                                runat="server" CssClass="btn btn-primary btn-md">
                                                                <asp:Image ID="imdedit1" ImageUrl="~/images/edit.png" runat="server" Width="55px" Visible="false" />
                                                                <span class="glyphicon glyphicon-eye-open" aria-hidden="true"></span>
                                                            </asp:LinkButton>
                                                            <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Edit">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btnedit" ForeColor="White" CommandName="et" CommandArgument='<%#Eval("SettingId") %>'
                                                                runat="server" CssClass="btn btn-warning btn-md">
                                                                <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" Width="55px" Visible="false" />
                                                                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                            </asp:LinkButton>
                                                            <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField Visible="true" HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="btndel" CommandArgument='<%#Eval("SettingId") %>' CommandName="Del"
                                                                runat="server">
                                                                <asp:Image ID="Image1" ImageUrl="~/images/delete.png" runat="server" Visible="false" />
                                                                <button type="button" class="btn btn-danger btn-md">
                                                                    <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                                                </button>
                                                            </asp:LinkButton>
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
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-6" id="d1" runat="server" visible="true">
                        <div class="panel panel-custom1">
                            <div class="panel-header">
                                <h1 class="page-header">Add Recipe Setting</h1>
                            </div>
                            <div class="panel-body panel-form-right">
                                <div class="col-lg-12">
                                    <div class="list-group">

                                        <asp:Label ID="lblerrorr" runat="server"></asp:Label>
                                        <%--  <blink> <label  style="color:Green; font-size:12px">Hint: Configure Required Raw material Quantity for Receipe.</label></blink>--%>
                                        <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>

                                        <div class="col-lg-6">
                                            <label>Select Item Name</label>
                                            <asp:DropDownList ID="drpitem" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-3">
                                            <label id="lblRawID" visible="false" runat="server">
                                            </label>
                                            <label>Per Qty Recipe</label>
                                            <asp:TextBox ID="txtprepareqty" runat="server" CssClass="form-control" placeholder="Eg:100" onkeypress="return isDecimal(event)"></asp:TextBox>
                                             <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server" TargetControlID="txtprepareqty"
                                                                FilterType="Custom,Numbers"  />
                                        </div>
                                        <div class="col-lg-3">
                                            <label>
                                                Duration(Mins)</label>
                                            <asp:TextBox ID="txtproductionhours" runat="server" CssClass="form-control" placeholder="Eg:45" onkeypress="return isDecimal(event)"></asp:TextBox>
                                        </div>

                                        <div class="col-lg-12">
                                            <label>
                                                Select Raw Item List</label>
                                            <asp:TextBox ID="txtsearching" runat="server" placeholder="Search Raw Material .."
                                                onkeyup="Search_Gridview(this, 'gridsemiitem')" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-12">

                                            <div class="table-responsive panel-grid-left">
                                                <asp:GridView ID="gridsemiitem" AutoGenerateColumns="false" runat="server" CssClass="table table-striped pos-table" padding="0" spacing="0" border="0">
                                                    <%--  <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> --%>
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Raw Item Name">
                                                            <ItemTemplate>
                                                                <asp:Label ID="lblsemiitemid" Visible="false" runat="server" Text='<%#Eval("IngridID") %>'></asp:Label>
                                                                <asp:Label ID="Label1" Visible="true" runat="server" Text='<%#Eval("IngredientName") %>'></asp:Label>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Required Qty">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtrecqty" runat="server" onkeypress="return isDecimal(event)"></asp:TextBox>
                                                                  <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" TargetControlID="txtrecqty"
                                                                FilterType="Custom,Numbers"  />
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
                                            </div>
                                        </div>
                                         <div class="col-lg-12"> <div class="col-lg-4">
                                 <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                                   <asp:Button ID="btnCheck" runat="server" class="btn btn-lg btn-primary pos-btn1" Text="Check" OnClick="Check_Click" Width="150px" />
                            <asp:LinkButton ID="lnkbtn" Text="" runat="server"></asp:LinkButton>
                            <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                CancelControlID="btnClose1" TargetControlID="btnCheck" PopupControlID="DivDeleteConfirmation"
                                BackgroundCssClass="ModalPopup">
                            </ajaxToolkit:ModalPopupExtender>
                            <asp:Panel ScrollBars="Auto"  ID="DivDeleteConfirmation"
                                CssClass="ModalPopup" runat="server">



                                <div id="Div19" runat="server" class="table-responsive panel-grid-left">
                                    <asp:GridView ID="gvCheck" runat="server" Width="100%" CssClass="table table-striped pos-table" Visible="true"
                                        HeaderStyle-CssClass="header" RowStyle-CssClass="rows" AllowPaging="false" PageSize="20" EmptyDataText="No Details"
                                        AutoGenerateColumns="false" AllowSorting="true" OnRowCommand="gvcat_RowCommand" padding="0" spacing="0" border="0">
                                        <Columns>
                                            <asp:BoundField HeaderText="Item Name" DataField="Itemname" />
                                            <asp:BoundField HeaderText="Req Qty" DataField="Qty" DataFormatString='{0:f}' />
                                        </Columns>
                                    </asp:GridView>
                                </div>


                                <div align="center">
                                    <%--<asp:Button ID="btnadd1" runat="server" class="btn btn-lg btn-primary pos-btn1" Text="Save" OnClick="Add_Click" OnClientClick="ClientSideClick(this)"  width="150px" />--%>
                                    <asp:Button ID="btnPreview1" runat="server" CssClass="btn btn-danger"
                                        UseSubmitBehavior="false" Text="Ok" OnClick="Add_Click" />
                                     <asp:Button ID="btnClose1" runat="server" Text="Close" />
                                </div>

                            </asp:Panel>

                          <!--  <asp:Button ID="btnShow" runat="server" Text="Show Modal Popup" />

                            
                            <ajaxToolkit:modalpopupextender id="mp1" runat="server" popupcontrolid="Panel1" targetcontrolid="btnShow"
                                cancelcontrolid="btnClose" backgroundcssclass="modalBackground">
                            </ajaxToolkit:modalpopupextender>
                            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" align="center" Style="display: none">
                                This is an ASP.Net AJAX ModalPopupExtender Example<br />
                                <asp:Button ID="btnClose" runat="server" Text="Close" />
                            </asp:Panel>-->

                        </ContentTemplate>
                    </asp:UpdatePanel>
                                             </div>
                                              <div class="col-lg-4">
                                        <asp:Button ID="btnadd" runat="server" class="btn btn-lg btn-primary pos-btn1" Text="Save" OnClick="Add_Click" Width="150px"
                                            ValidationGroup="val1" AccessKey="s" /></div>
                                              <div class="col-lg-4">
                                        <asp:Button ID="btnexit" runat="server" class="btn btn-lg btn-link" Text="Clear" OnClick="Exit_Click" Width="150px" /></div></div>

                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>




                    


                     <div class="col-lg-6">
                    <div runat="server" id="listitem" visible="false">
                        <div class="row panel-custom1">
                            <div class="panel-header">
                                <h1 class="page-header">Details</h1>
                            </div>

                            <div class="panel-body">
                                <label>
                                    Item List:
                                            <asp:Label ID="lblsettingname" runat="server"></asp:Label>
                                </label>
                                <br />
                                <label>
                                    Measurement Used Per Qty:
                                            <%-- Prepared for this Receipe Setting: --%>
                                    <asp:Label ID="lblqty" runat="server"></asp:Label></label>
                                <asp:GridView ID="gridview1" runat="server" PagerStyle-CssClass="pager"
                                    CssClass="table table-striped pos-table" AllowPaging="false"
                                    PageSize="20" padding="0" spacing="0" border="0" AutoGenerateColumns="false"
                                    AllowSorting="true">
                                    <%--<PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                NextPageText="Next" PreviousPageText="Previous" />--%>
                                    <Columns>
                                        <asp:BoundField HeaderText="Raw Item Name" DataField="item" />
                                        <asp:BoundField HeaderText="Rec Qty" DataField="recqty" DataFormatString='{0:f}' />
                                        <asp:BoundField HeaderText="UOM" DataField="uom" />
                                    </Columns>
                                </asp:GridView>
                                <asp:Button ID="btnReset" Text="Reset" CssClass="btn secondary"  runat="server"  OnClick="btnReset_Click" />
                            </div>
                        </div>
                    </div>
                         </div>

                </div>
            </div>
        </div>
        <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
        <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
        <script type="text/javascript">        $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    </form>
</body>
</html>
