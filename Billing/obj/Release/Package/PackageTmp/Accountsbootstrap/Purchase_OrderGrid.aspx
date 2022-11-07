<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchase_OrderGrid.aspx.cs"
    Inherits="Billing.Accountsbootstrap.Purchase_OrderGrid" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <style type="text/css">
        a img
        {
            border: none;
        }
        ol li
        {
            list-style: decimal outside;
        }
        div#container
        {
            width: 780px;
            margin: 0 auto;
            padding: 1em 0;
        }
        div.side-by-side
        {
            width: 100%;
            margin-bottom: 1em;
        }
        div.side-by-side > div
        {
            float: left;
            width: 50%;
        }
        div.side-by-side > div > em
        {
            margin-bottom: 10px;
            display: block;
        }
        .clearfix:after
        {
            content: "\0020";
            display: block;
            height: 0;
            clear: both;
            overflow: hidden;
            visibility: hidden;
        }
    </style>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Bank Grid Master - bootsrap</title>
    <!-- Bootstrap Core CSS -->
    <link rel="stylesheet" href="../Styles/chosen.css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../js/jquery-1.7.2.js"></script>
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
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript">
        function alertMessage() {
            alert('Are You Sure, You want to delete This Customer!');
        }
    </script>
    <link href="../css/Header.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {

            //         Client Side Search (Autocomplete)
            //         Get the search Key from the TextBox
            //         Iterate through the 1st Column.
            //         td:nth-child(1) - Filters only the 1st Column
            //         If there is a match show the row [$(this).parent() gives the Row]
            //         Else hide the row [$(this).parent() gives the Row]

            $('#txtsearch').keyup(function (event) {
                var searchKey = $(this).val().toLowerCase();
                $("#BankGrid tr td:nth-child(1)").each(function () {
                    var cellText = $(this).text().toLowerCase();
                    if (cellText.indexOf(searchKey) >= 0) {
                        $(this).parent().show();
                    }
                    else {
                        $(this).parent().hide();
                    }
                });
            });
        });

    </script>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
     <form runat="server" id="form1">
     <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Purchase Order Entry
          <span class="pull-right">
          <asp:LinkButton ID="addbtn" runat="server" onclick="Add_Click">
            <button type="button" class="btn btn-primary btn-md pos-btn1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD
			</button>
           </asp:LinkButton>
                </span>
                </h1>
	    </div>
  
            <div class="panel-body">
    
    <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
        ID="val1" ShowMessageBox="true" ShowSummary="false" />
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
  
                <div class="row">
                    <div class="col-lg-3">
                        <div class="form-group ">
                            <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="phono" ControlToValidate="txtsearch"
                                ErrorMessage="Please enter your searching Data!" Text="*" Style="color: White" />
                            <asp:TextBox CssClass="form-control" Enabled="true" ID="txtsearch" runat="server"
                                placeholder="Search Text" ></asp:TextBox>
                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                FilterType="LowercaseLetters, UppercaseLetters,Numbers,Custom" ValidChars=" "
                                TargetControlID="txtsearch" />
                        </div>
                    </div>
                    <div class="col-lg-3">
                       
                            <label>
                                From date</label>
                            <asp:TextBox runat="server" ID="txtfromdate" CssClass="form-control" AutoPostBack="true"
                                OnTextChanged="txtfromdate_TextChanged"> 
                            </asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfromdate"
                                Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                            </ajaxToolkit:CalendarExtender>
                        
                    </div>
                    <div class="col-lg-3">
                        
                            <label>
                                To date</label>
                            <asp:TextBox runat="server" ID="txttodate" CssClass="form-control" AutoPostBack="true"
                                OnTextChanged="txtfromdate_TextChanged">
                            </asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txttodate"
                                Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                            </ajaxToolkit:CalendarExtender>
                        
                    </div>
                    <div class="col-lg-3">
                       
                            <label>
                                Supplier</label>
                            <asp:DropDownList CssClass=" form-control" ID="ddlsuplier"  AutoPostBack="true"
                                OnSelectedIndexChanged="ddlsuplier_OnSelectedIndexChanged"   runat="server">
                            </asp:DropDownList>
                        
                    </div>
                   
                
                <div class="col-lg-12">

                            <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="BankGrid" runat="server" Width="100%" AllowSorting="true" OnSelectedIndexChanged="BankGrid_SelectedIndexChanged"  cssClass="table table-striped pos-table"
                                    EmptyDataText="No Records Found" AutoGenerateColumns="false" OnRowCommand="BankGrid_RowCommand" OnRowDataBound="gridview_OnRowDataBound" padding="0" spacing="0" border="0">
                                   <%-- <HeaderStyle BackColor="#3366FF" />--%>
                                  <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> 
                                    <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                        NextPageText="Next" PreviousPageText="Previous" />--%>
                                    <Columns>
                                        <asp:BoundField HeaderText="LedgerID" DataField="Purchaseid" Visible="false" />
                                        <asp:BoundField HeaderText="OrderNo" DataField="OrderNo" />
                                        <asp:BoundField HeaderText="SupplierName" DataField="CustomerName" HeaderStyle-HorizontalAlign="Center" />                                      
                                        <asp:BoundField HeaderText="OrderDate" DataField="OrderDate" DataFormatString="{0:dd/MM/yyyy}" />
                                        <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString='{0:f}' />
                                        <asp:BoundField HeaderText="Payment" DataField="Paymentmode" />
                                        <asp:BoundField HeaderText="Order Status" DataField="Status" />


                                          <asp:TemplateField HeaderText="Print"  Visible="true">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnPrint" runat="server" CommandArgument='<%#Eval("OrderNo") %>'
                                                    CommandName="Print">
                                                    <asp:Image ID="img1" runat="server" ImageUrl="~/images/print%20(1).png" Width="44px" visible="false" />
                                                    <button type="button" class="btn btn-default btn-md">
						                                <span class="glyphicon glyphicon-print" aria-hidden="true"></span>
					                                </button>
                                                    </asp:LinkButton>
                                                <asp:ImageButton ID="imgdisable2" ImageUrl="~/images/edit.png"  width="55px"  runat="server" Visible="false"
                                                    Enabled="false" ToolTip="Not Allow To Delete" />
                                               
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Edit"  Visible="true">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("OrderNo") %>' cssclass="btn btn-warning btn-md"
                                                   CommandName="Select" >
                                                    <asp:Image ID="img" runat="server" ImageUrl="~/images/edit.png" width="55px" Visible="false"  />
                                                    <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                    </asp:LinkButton>
                                                <asp:ImageButton ID="imgdisable" ImageUrl="~/images/edit.png" runat="server" Visible="false"
                                                    Enabled="false" ToolTip="Not Allow To Delete" width="55px"/>
                                                <asp:HiddenField ID="ldgID" runat="server" Value='<%# Bind("OrderNo") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField HeaderText="Delete"  Visible="true">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("OrderNo") %>'
                                                    CommandName="delete" OnClientClick="alertMessage()">
                                                    <asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/delete.png" Visible="false"/>
                                                    <button type="button" class="btn btn-danger btn-md">
												<span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
												</button>
                                                </asp:LinkButton>
                                                <asp:ImageButton ID="imgdisable1" ImageUrl="~/images/delete.png" runat="server" Visible="false"
                                                    Enabled="false" ToolTip="Not Allow To Delete" />
                                                <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                    CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btndelete"
                                                    PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                                </ajaxToolkit:ModalPopupExtender>
                                                <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                    TargetControlID="btndelete" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                                </ajaxToolkit:ConfirmButtonExtender>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                   <%-- <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                </asp:GridView>
                            </div>
                     
        <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
        <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
        <script type="text/javascript">            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
    </div>
    </div>
    <asp:Panel class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none"
        runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    Delete Purchase Order</div>
                <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    Are you sure want to delete?
                </p>
            </div>
            <div class="popup_Buttons">
                <input id="ButtonDeleleOkay" type="button" value="Yes" />
                <input id="ButtonDeleteCancel" type="button" value="No" />
            </div>
        </div>
    </asp:Panel>
    </div>
    
    </div>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
