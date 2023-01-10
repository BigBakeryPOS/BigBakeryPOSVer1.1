<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SemiItemMaster.aspx.cs" Inherits="Billing.Accountsbootstrap.SemiItemMaster" %>

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
    <title>Semi Item Grid </title>
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
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
    <style type="text/css"> 
         blink, .blink {
            animation: blinker 1s linear infinite;
        }

       @keyframes blinker { 
            50% { opacity: 0; }
       }
      </style>
</head>
<body style="background-color: ">
    <usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
        <div class="col-lg-8">
        <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Semi Item Master</h1>
	    </div>

                <div class="panel-body">
                    
                        <div class="col-lg-4">
                        <div class="form-group has-feedback">
                            <asp:TextBox ID="txtname" runat="server"  placeholder="Search Semi Item..."
                                onkeyup="Search_Gridview(this, 'Ingredientdrid')" CssClass="form-control"></asp:TextBox>
                        </div>
                        </div>
                        <div class="col-lg-8">
                            <asp:Button ID="btnReset" runat="server" class="btn btn-secondary" Text="Reset"
                                OnClick="btnReset_Click" />
                        </div>
                   
                    <div class="col-lg-12">
                        
                         <div class="table-responsive panel-grid-left">
                            <asp:GridView ID="Ingredientdrid" runat="server" PagerStyle-CssClass="pager" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                ShowHeader="true" Width="100%" AutoGenerateColumns="False" OnRowCommand="Ingredientdrid_RowCommand">
                               <%-- <AlternatingRowStyle></AlternatingRowStyle>
                                <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                    HorizontalAlign="Center" ForeColor="White" />--%>
                                <Columns>
                                    <asp:BoundField DataField="SemiIngridID" HeaderText="ID" ItemStyle-CssClass="hide" HeaderStyle-CssClass="hide" />
                                    <asp:BoundField DataField="SemiCategory" HeaderText="Semi Category" ItemStyle-HorizontalAlign="left"
                                        HeaderStyle-HorizontalAlign="left" />
                                    <asp:BoundField DataField="SemiIngredientCode" HeaderText="Semi Cat.Code" ItemStyle-HorizontalAlign="left" Visible="false"
                                        HeaderStyle-HorizontalAlign="left" />
                                    <asp:BoundField DataField="SemiIngredientName" HeaderText="Semi Item" ItemStyle-HorizontalAlign="left"
                                        HeaderStyle-HorizontalAlign="left" />
                                    <asp:BoundField DataField="UOM" HeaderText="UOM" ItemStyle-HorizontalAlign="Center"
                                        HeaderStyle-HorizontalAlign="left" />
                                        <asp:BoundField DataField="hsncode" HeaderText="HSNCODE" ItemStyle-HorizontalAlign="Center"
                                        HeaderStyle-HorizontalAlign="left" />
                                    <asp:BoundField DataField="Quantity" HeaderText="Min.Qty" ItemStyle-HorizontalAlign="Center"
                                        HeaderStyle-HorizontalAlign="left" />
                                    <asp:BoundField DataField="TaxValue" HeaderText="Tax" ItemStyle-HorizontalAlign="Center"
                                        HeaderStyle-HorizontalAlign="left" />
                                    <asp:TemplateField HeaderText="Edit" >
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnedit" ForeColor="White" CommandName="et" CommandArgument='<%#Eval("SemiIngridID") %>'
                                                runat="server">
                                                <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" width="55px" runat="server" visible="false" />
                                                  <button type="button" class="btn btn-warning btn-md">
												<span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
												</button>
                                                </asp:LinkButton>
                                            <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Delete">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btndel" CommandName="Dl" CommandArgument='<%#Eval("SemiIngridID") %>'
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
                                <%--<FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                <%-- <HeaderStyle BackColor="#428bca" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                               <%-- <PagerStyle CssClass="pgr"></PagerStyle>--%>
                                <PagerStyle CssClass="pos-paging" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
            </div>
        </div>
         <div class="col-lg-4">
        <div class="panel panel-custom1">
		<div class="panel-header">
				<h1 class="page-header">Add Semi Item</h1>
		</div>
                <div class="panel-body panel-form-right">
                <div class="list-group">

                        <label>
                            Select Semi Category</label>
                        <asp:DropDownList ID="ddlsemiIngreCategory" runat="server" CssClass="form-control" Visible="true">
                        </asp:DropDownList>
                        <br />
                        <label>
                            Semi Item Name</label>
                        <asp:TextBox ID="txtsemiingre" runat="server" placeholder="Enter Ingredient Name" CssClass="form-control"></asp:TextBox>
                        <br />
                        <label>
                            Semi Item Code</label>
                        <asp:TextBox ID="txtsemiingreCode" runat="server" placeholder="Enter Ingredient Code"
                            CssClass="form-control"></asp:TextBox>
                         <br />
                             <label>
                            HSN Code</label>
                        <asp:TextBox ID="txthsncode" runat="server" placeholder="Enter HSN Code"
                            CssClass="form-control"></asp:TextBox>
                          <br />
                        <label>
                            Minimum Quantity</label>
                        <asp:TextBox ID="txtQuantity" runat="server" placeholder="Enter Minimum Quantity"
                            CssClass="form-control"></asp:TextBox>
                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtendername" runat="server"
                            FilterType="Custom,Numbers" ValidChars=" ." TargetControlID="txtQuantity" />
                            <br />
                        <label>
                            UOM</label>
                        <asp:DropDownList ID="ddlunits" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        <br />
                        <label>
                            Tax</label>
                        <asp:DropDownList ID="ddltax" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                       <br />
                        <label>
                            Allow Request</label>
                        <asp:CheckBox ID="chkallow" runat="server" />
                           <br /> <br />     
                            <label>
                                Select Primary UOM</label>
                            <asp:CheckBoxList ID="chkprimaryuom" runat="server" RepeatColumns="2" Width="300px">
                            </asp:CheckBoxList>
                       <br />
                            <label>
                                Upload Data From Excel
                            </label>
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:FileUpload ID="FileUpload1" runat="server" style="display:inline" width="190px"/>
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
                        <asp:Button ID="btnSubmit"  runat="server" width="150px"
                            class="btn btn-lg btn-primary pos-btn1" Text="Save" OnClick="btnadd_Click" />
                        <asp:Button ID="btnclaear"  runat="server" width="150px"
                            class="btn btn-lg btn-link" Text="Clear" OnClick="btncancel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    </div>
    </div>
    <asp:Panel Width="30%" class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none;
        background-color: #c7c7c7" runat="server">
        <div class="popup_Container">
            <div style="background-color: #2cbcf0; height: 30px" id="PopupHeader">
                <div align="center" style="color: White; font-weight: bold" class="TitlebarLeft">
                    Warning Message!!!</div>
                <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                </div>
            </div>
            <div align="center" style="color: Black; font-size: medium" class="">
                <p>
                    Are you sure want to Delete
                    <label id="lblpop" runat="server">
                    </label>
                    ?
                </p>
            </div>
            <div align="center" class="popup_Buttons">
                <input id="ButtonDeleleOkay" type="button" class="btn btn-success" value="Yes" />
                <input id="ButtonDeleteCancel" type="button" class="btn btn-danger" value="No" />
            </div>
        </div>
    </asp:Panel>
    </form>
</body>
</html>

