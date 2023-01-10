<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Synchronization.aspx.cs"
    Inherits="Billing.Accountsbootstrap.Synchronization" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <title>Synchronization</title>
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
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
    <style>
         blink, .blink {
            animation: blinker 1s linear infinite;
        }

       @keyframes blinker {  
            50% { opacity: 0; }
       }
      </style>
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
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body style="font-family: Calibri; font-size: medium;">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Synchronization</h1>
	    </div>

                    <div class="panel-body">
                        <div class="row">
                         
                                <div id="Div1" class="col-lg-3" runat="server">
                                    <label>Employee Name</label>
                                    <asp:TextBox ID="txtempname" runat="server" CssClass="form-control"></asp:TextBox>
                                </div>
                                <div class="col-lg-3" runat="server" visible="true">
                                    <label>Select Type</label>
                                    <asp:DropDownList ID="drptype" runat="server" Enabled="true" CssClass="form-control"
                                        OnSelectedIndexChanged="Type_chnaged" AutoPostBack="true">
                                        <asp:ListItem Text="Get Only New Item" Value="1"> </asp:ListItem>
                                        <asp:ListItem Text="Get Only Update Items" Value="2"> </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="Div2" class="col-lg-3" runat="server" visible="false">
                                    <label>
                                        Select Date</label>
                                    <asp:TextBox ID="txtdate" runat="server" CssClass="form-control"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy/MM/dd" TargetControlID="txtdate"
                                        runat="server" CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                              <br />
                                   <asp:CheckBox ID="chkgetitem" runat="server" Text="Get Item List" OnCheckedChanged="chkitem"
                                        AutoPostBack="true" />
                                </div>
                            </div>
                            <asp:UpdatePanel ID="Updatepanel" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                <br />
                                                <div class="row">
                                                    <div class="col-lg-2">
                                                        <div class="list-group">
                                                            <label>
                                                                Sync.Ingr.</label>
                                                            <asp:Button ID="btning" runat="server" class="btn btn-primary pos-btn1" Text="Sync.Ingr."
                                                                Width="100%" OnClick="btnsyncingclick_OnClick" />
                                                        <br /><br />
                                                            <label>
                                                                Sync.Item</label>
                                                            <asp:Button ID="btnitemsync" runat="server" class="btn btn-primary pos-btn1" Text="Sync.Item"
                                                                Width="100%" OnClick="btnsyncclick" />
                                                       <br /><br />
                                                            <label>
                                                                Branch</label>
                                                            <asp:Button ID="Button2" runat="server" class="btn btn-primary pos-btn1" Text="Sync.Branch" Width="100%"
                                                                OnClick="Branch_Sync" />
                                                      
                                                           
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="list-group">
                                                         <label>
                                                                Sales Type</label>
                                                            <asp:Button ID="Button5" runat="server" class="btn btn-primary pos-btn1" Text="Sync.Sales Type"
                                                                Width="100%" OnClick="SalesType_Sync" />
                                                        <br /><br />
                                                            <label>
                                                                Sync.UOM.</label>
                                                            <asp:Button ID="btnuom" runat="server" class="btn btn-primary pos-btn1" Text="Sync.UOM." OnClick="btnsyncinguom_OnClick"
                                                                Width="100%" />
                                                       <br /><br />
                                                            <label>
                                                                Sync.HSNCODE</label>
                                                            <asp:Button ID="btnhsnsync" runat="server" class="btn btn-primary pos-btn1" Text="Sync.HSNCODE"
                                                                Width="100%" OnClick="btnsyncclick_HSNCODE" />
                                                        </div>
                                                    </div>
                                                    <div class="col-lg-2">
                                                        <div class="list-group">
                                                        <label>
                                                                Branch-Production Setting</label>
                                                            <asp:Button ID="Button3" runat="server" class="btn btn-primary pos-btn1" Text="Sync.Branch-Production Setting"
                                                                Width="100%" OnClick="BranchSetting_sync" />
                                                         <br /><br />
                                                            <label>
                                                                Request Stock Setting</label>
                                                            <asp:Button ID="Button6" runat="server" class="btn btn-primary pos-btn1" Text="Sync.Branch-Request Stock Setting"
                                                                Width="100%" OnClick="ReqStockSetting_sync" />
                                                        <br /><br />
                                                            <label>
                                                                Sync.Group</label>
                                                            <asp:Button ID="Button1" runat="server" class="btn btn-primary pos-btn1" Text="Sync.Group"
                                                                Width="100%" Enabled="true" OnClick="btnsyncclick_OnClick" />
                                                   
                                                        </div>
                                                    </div>
                                                
                                                <div runat="server" visible="false" class="col-lg-2">
                                                    <label>
                                                        Sync.Stock</label>
                                                    <asp:Button ID="btnstock" runat="server" class="btn btn-danger" Text="Sync.Stock"
                                                        OnClick="btnstocksyncclick" Width="170px" />
                                                </div>
                                                <div runat="server" visible="false" class="col-lg-2">
                                                    <label>
                                                        Sync.Sales</label>
                                                    <asp:Button ID="btnsalessyn" runat="server" class="btn btn-group" Text="Sync.Sales"
                                                        OnClick="btnsalessyn_OnClick" Width="170px" />
                                                </div>
                                                <div runat="server" visible="false" class="col-lg-2">
                                                    <label>
                                                        Sync.Order</label>
                                                    <asp:Button ID="btnordersyn" runat="server" class="btn btn-toolbar" Text="Sync.Order"
                                                        OnClick="btnordersyn_OnClick" Width="170px" />
                                                </div>
                                                
                                          <div class="col-lg-2">
                                                  <div class="list-group">
                                                   <label>
                                                         Sync.Store To Shop Item</label>
                                                            <asp:Button ID="btnsstsi" runat="server" class="btn btn-primary pos-btn1" Text="Sync.Store To Shop Item"
                                                                Width="100%" OnClick="btnsstsiclick" />
                                                       <br /><br />
                                                            <label>
                                                                Inter-Branch Setting</label>
                                                            <asp:Button ID="Button4" runat="server" class="btn btn-primary pos-btn1" Text="Sync.Inter-Branch Setting"
                                                                Width="100%" OnClick="InterBranch_sync" />
                                                        <br /><br />
                                                            <label>
                                                                Online POS sync</label>
                                                            <asp:Button ID="btnonlinepos" runat="server" class="btn btn-primary pos-btn1" Text="Sync.Online POS"
                                                                Width="100%" OnClick="onlinepos_sync" />
                                               
                                                    </div>
                                                    </div>
                                           <div class="col-lg-2">
                                                  <div class="list-group">
                                                   <label>
                                                    Sync.Sales</label>
                                                <asp:Button ID="btnsynsales" runat="server" class="btn btn-primary pos-btn1" Text="Sync.Sales"
                                                    OnClick="btnsalessyn_OnClick" Width="100%" />
                                           
                                         <br /><br />
                                                <label>
                                                    Sync.Order</label>
                                                <asp:Button ID="btnsynOrder" runat="server" Width="100%" class="btn btn-primary pos-btn1"
                                                    Text="Sync.Order" OnClick="btnordersyn_OnClick1" OnClientClick="showProgress()" />
                                           <br /><br />
                                                <label>
                                                    Sync.Payment</label>
                                                <asp:Button ID="Button8" runat="server" class="btn btn-primary pos-btn1" Text="Sync.Payment"
                                                    OnClick="btnpaymentsyn_onclick" Width="100%" />
                                         
                                               
                                            </div>
                                       </div>
                                        <div class="col-lg-2">
                                                  <div class="list-group">
                                                   <label>
                                                    Sync.GRN</label>
                                                <asp:Button ID="Button9" runat="server" class="btn btn-primary pos-btn1" Text="Sync.GRN" OnClick="btnGRNsyn_onclick"
                                                    Width="100%" />
                                            <br /><br />
                                                <label>
                                                    Sync.Return</label>
                                                <asp:Button ID="Button10" runat="server" class="btn btn-primary pos-btn1" Text="Sync.Return"
                                                    OnClick="btnReturnsyn_onclick" Width="100%" />
                                                  </div>
                                                  </div>
                                       </div>
                                        <div class="row">
                                                <div id="grdlist" runat="server" visible="false">
                                                 <div class="col-lg-4">
                                                    <label>
                                                        Category List</label>
                                                         <div class="table-responsive panel-grid-left">
                                                    <asp:GridView ID="gridview" runat="server" AllowPaging="false" AutoGenerateColumns="false" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                                        Width="100%" Font-Names="Calibri">
                                                       <%-- <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                            NextPageText="Next" PreviousPageText="Previous" />
                                                        <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                                            HorizontalAlign="Center" ForeColor="White" />--%>
                                                              <PagerStyle CssClass="pos-paging" />
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Category Name" DataField="category" />
                                                            <asp:BoundField HeaderText="Print Category Name" DataField="Printcategory" />
                                                        </Columns>
                                                    </asp:GridView>
                                                    </div>
                                                    </div>
                                                    <div class="col-lg-4">
                                                    <label>
                                                        Item List
                                                    </label>
                                                     <div class="table-responsive panel-grid-left">
                                                    <asp:GridView ID="gridview1" runat="server" AllowPaging="false" Width="100%" AutoGenerateColumns="false"
                                                        Font-Names="Calibri" EmptyDataText="No Records Found" AllowSorting="true" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0">
                                                     <%--   <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" Height="24px"
                                                            BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" />--%>
                                                        <%-- <HeaderStyle BackColor="#990000" ForeColor="White" />--%>
                                                         <PagerStyle CssClass="pos-paging" />
                                                       <%-- <PagerSettings FirstPageText="1" Mode="Numeric" />--%>
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Group" DataField="category" />
                                                            <asp:BoundField HeaderText="Item" DataField="Definition" />
                                                            <asp:BoundField HeaderText="Print Item Name" DataField="PrintItem" />
                                                            <asp:BoundField HeaderText="GST" DataField="Tax" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="Rate" DataField="Rate" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="SGST" DataField="SGST" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="CGST" DataField="CGST" DataFormatString='{0:f}' />
                                                            <asp:BoundField HeaderText="Total" DataField="Rate1" DataFormatString='{0:f}' />
                                                        </Columns>
                                                    </asp:GridView>
                                                   </div>
                                                   </div>
                                                    <div class="col-lg-4">
                                                    <label>
                                                        Store To shop Item List</label>
                                                         <div class="table-responsive panel-grid-left">
                                                    <asp:GridView ID="gridview2" runat="server" AllowPaging="false" AutoGenerateColumns="false"
                                                        Width="100%" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0">
                                                         <PagerStyle CssClass="pos-paging" />
                                                       <%-- <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                            NextPageText="Next" PreviousPageText="Previous" />
                                                        <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                                            HorizontalAlign="Center" ForeColor="White" />--%>
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Ingrident Name" DataField="IngredientName" />
                                                            <asp:BoundField HeaderText="Branch Item Name" DataField="Printitem" />
                                                            <asp:BoundField HeaderText="Is Active" DataField="IsActive" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                </div>
                                            </div>
                                        </div>
                                   
                                </ContentTemplate>
                                <%-- <Triggers>
            <asp:AsyncPostBackTrigger ControlID="btnsynOrder" EventName="Click" />
        </Triggers>--%>
                            </asp:UpdatePanel>
                        </div>
                    </div>
     
    <asp:Panel class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none"
        runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    Category List</div>
                <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    Are you sure want to delete?
                    <blink> <label  style="color:Red; font-size:12px">If you Delete This Category It Will Affect Your Branchs!!!</label> </blink>
                </p>
            </div>
            <div class="popup_Buttons">
                <input id="ButtonDeleleOkay" type="button" value="Yes" />
                <input id="ButtonDeleteCancel" type="button" value="No" />
            </div>
        </div>
    </asp:Panel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel">
        <ProgressTemplate>
            <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                right: 0; left: 0; z-index: 9999999; opacity: 0.7;">
                <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="~/images/loading.gif"
                    AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed;
                    top: 45%; left: 50%;" />
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </div>
    </div>
   </div>
    </form>
</body>
</html>
