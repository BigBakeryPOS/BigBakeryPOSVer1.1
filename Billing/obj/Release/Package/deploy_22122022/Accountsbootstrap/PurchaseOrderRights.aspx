<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PurchaseOrderRights.aspx.cs"
    Inherits="Billing.Accountsbootstrap.PurchaseOrderRights" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1">
    <title>Accept Raw Materials</title>
    <script language="javascript" type="text/javascript">

        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
                event.returnValue = true;
            else

                event.returnValue = false;
        }

    </script>
    <style type="text/css">
         blink, .blink {
            animation: blinker 1s linear infinite;
        }

       @keyframes blinker {  
            50% { opacity: 0; }
       }
      </style>
    <script type="text/javascript">
        //    function ClientSideClick(myButton) {
        //        // Client side validation
        //        if (typeof (Page_ClientValidate) == 'function') {
        //            if (Page_ClientValidate() == false)
        //            { return false; }
        //        }

        //        //make sure the button is not of type "submit" but "button"
        //        if (myButton.getAttribute('type') == 'button') {
        //            // disable the button
        //            myButton.disabled = true;
        //            myButton.className = "btn-inactive";
        //            myButton.value = "processing...";
        //        }
        //        return true;
        //    }
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
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="../Styles/chosen.css" />
    <style type="text/css">
        #dialog
        {
            display: none;
        }
        
        .ui-dialog-title, .ui-dialog-content, .ui-widget-content
        {
            font-family: "Trebuchet MS" , "Helvetica" , "Arial" , "Verdana" , "sans-serif";
            font-size: 62.5%;
        }
        body
        {
            font-family: Arial;
            font-size: 10pt;
        }
        .GridPager a, .GridPager span
        {
            display: block;
            height: 15px;
            width: 15px;
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
    </style>
    <style type="text/css">
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
    <style type="text/css">
        .overlay
        {
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
        .GridviewDiv
        {
            font-size: 100%;
            font-family: 'Lucida Grande' , 'Lucida Sans Unicode' , Verdana, Arial, Helevetica, sans-serif;
            color: #303933;
        }
        .headerstyle
        {
            color: #FFFFFF;
            border-right-color: #abb079;
            border-bottom-color: #abb079;
            background-color: #df5015;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }
    </style>
    <script type="text/javascript">

    </script>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Accept Raw Materials</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
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
    <script type="text/javascript">
        function myFunction() {
            window.open("http://localhost:57111/Accountsbootstrap/itempage.aspx?Mode=Purchase", "Popup", 'height=300,width=500,resizable=yes,modal=yes,center=yes');
        }
    </script>
    <script type="text/javascript">
        function Showalert() {
            alert('Check Stock !');
        }
    </script>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <form runat="server" id="form1" method="post">
    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>     --%>
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Accept Raw Materials</h1>
	    </div>

            <div class="panel-body">
            <div class="row">
                                <div class="col-lg-3">
                                    <div class="list-group">
                                        <label>
                                            OrderNo</label>
                                        <asp:DropDownList ID="drpPO" runat="server" AutoPostBack="true"  OnSelectedIndexChanged="drpPO_OnSelectedIndexChanged"
                                            CssClass="form-control">
                                        </asp:DropDownList>
                                   <br />
                                        <label>
                                            Supplier</label>
                                        <asp:DropDownList ID="ddlsuplier" runat="server" TabIndex="2" CssClass="form-control">
                                        </asp:DropDownList>
                                    <br />
                                            <asp:Label runat="server" ID="lblDCDate"><label> Rights Date</label></asp:Label>
                                            <asp:TextBox ID="txtDCDate" runat="server" CssClass="form-control"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDCDate"
                                                Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                        <br />
                                    <div class="col-lg-3" runat="server" visible="false">
                                        <asp:RadioButtonList ID="rbdpurchasetype" runat="server" RepeatColumns="2" AutoPostBack="true"
                                            OnSelectedIndexChanged="rbdpurchasetype_OnSelectedIndexChanged">
                                            <asp:ListItem Text="Local Purchase" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Inter-State Purchase" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div class="col-lg-3" runat="server" visible="false">
                                        <label>
                                            Paymode</label>
                                        <asp:DropDownList ID="ddlpaymode" runat="server" AutoPostBack="true" TabIndex="3"
                                            CssClass="form-control" OnSelectedIndexChanged="ddlpaymode_OnSelectedIndexChanged">
                                            <asp:ListItem Text="Select Payment" Value="0" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="Cash" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Credit" Value="2" Enabled="true"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <asp:DropDownList ID="ddlbank" runat="server" AutoPostBack="true" CssClass="form-control"
                                        Visible="false">
                                    </asp:DropDownList>
                                    <asp:TextBox CssClass="form-control" ID="txtcheque" placeholder="Enter Bill No" runat="server"
                                        Visible="false"></asp:TextBox>
                                   
                               </div>
                               </div>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                          
                
                <div class="col-lg-3">
                    <div class="list-group">
                        <label>
                            SubTotal</label>
                        <asp:TextBox ID="txtSubTotal" Enabled="false" runat="server"  CssClass="form-control">0</asp:TextBox>
               <br />
                        <label>
                            CGST</label>
                        <asp:TextBox ID="txtcgst" runat="server" CssClass="form-control"  Enabled="false"
                            AutoPostBack="true" >0</asp:TextBox>
                   <br />
                        <label>
                            SGST</label>
                        <asp:TextBox ID="txtsgst" runat="server" CssClass="form-control" Enabled="false"
                            AutoPostBack="true" >0</asp:TextBox>
                    </div>
                    </div>
                    <div class="col-lg-3">
                    <div class="list-group">
                        <label>
                            IGST</label>
                        <asp:TextBox ID="txtigst" runat="server" CssClass="form-control"  Enabled="false"
                            AutoPostBack="true" >0</asp:TextBox>
                    <br />
                        <label>
                            Total</label>
                        <asp:TextBox ID="txttotal" runat="server" Enabled="false" CssClass="form-control">0</asp:TextBox>
                        <br /><br />
                        <asp:Button ID="Button1" runat="server" CssClass=" btn btn-lg btn-primary pos-btn1" Text="Save"
                            OnClick="btnSave_Click" OnClientClick="SetTarget();" />
                        <asp:Button ID="Button2" runat="server" CssClass="btn btn-lg btn-link" Text="Exit"
                            PostBackUrl="~/Accountsbootstrap/OrderRightsGrid.aspx" />
                     </div>
                </div>
            </div>
                <div class="col-lg-12">
                   <asp:GridView ID="gvcustomerorder" runat="server" AutoGenerateColumns="False" OnRowDeleting="grvStudentDetails_RowDeleting" Font-Names="Calibri"
                           OnRowDataBound="gvcustomerorder_RowDataBound">
                          <%--  <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                Height="20px" Font-Names="arial" Font-Size="Medium" HorizontalAlign="Center" />--%>
                              <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> 
                            <RowStyle BorderColor="Gray" BorderStyle="Solid" BorderWidth="0.5px" />
                            <Columns>
                                <asp:TemplateField ControlStyle-Width="100%" HeaderStyle-ForeColor="white" HeaderStyle-Width="5%"
                                    ItemStyle-HorizontalAlign="Center" HeaderText="S.No" ItemStyle-Width="6%">
                                    <ItemTemplate>
                                        <asp:TextBox Width="50px" Style="text-align: left" class="form-control" TabIndex="4"
                                            ID="txtsno" runat="server">1</asp:TextBox>
                                        <asp:HiddenField ID="TransID" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ingredients" HeaderStyle-Width="350px" HeaderStyle-ForeColor="white"
                                    ItemStyle-Height="30px">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlDef" CssClass="chzn-select" runat="server" TabIndex="5"
                                            Height="50px" Width="350px" AutoPostBack="true" OnSelectedIndexChanged="ddlDef_OnSelectedIndexChanged">
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Units" ControlStyle-Width="10%" HeaderStyle-Width="100px"
                                    HeaderStyle-ForeColor="white" ItemStyle-HorizontalAlign="Left">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlunits" Visible="false" CssClass="form-control" runat="server">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblunits" Width="130px" runat="server"></asp:Label>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Primary Unit" ControlStyle-Width="100%" HeaderStyle-Width="30%"
                                        HeaderStyle-ForeColor="white" >
                                        <ItemTemplate>
                                            <asp:DropDownList ID="ddlprimaryunits" Width="100%" Enabled="false"  CssClass="chzn-select" runat="server" OnSelectedIndexChanged="drpprimary_unit" AutoPostBack="true"
                                                Height="25px">
                                            </asp:DropDownList>
                                            <asp:Label ID="lblprimaryvalue" runat="server" ></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField HeaderText="SubCatID" ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide"
                                    HeaderStyle-ForeColor="white" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDescriptionID" runat="server" CssClass="LabelText"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PO.Qty" HeaderStyle-Width="50px" HeaderStyle-ForeColor="white">
                                    <ItemTemplate>
                                        <asp:Label class="form-control" Width="55px" ID="txtaQty" runat="server" MaxLength="10">0</asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Quantity" HeaderStyle-Width="70px" HeaderStyle-ForeColor="white">
                                    <ItemTemplate>
                                        <asp:TextBox class="form-control" Width="70px" OnTextChanged="txtdefQty_TextChanged"
                                            AutoPostBack="true" ID="txtQty" runat="server" MaxLength="10">0</asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="GST%" ItemStyle-HorizontalAlign="Left" HeaderStyle-Width="50px"
                                    HeaderStyle-ForeColor="white">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtBillNo" runat="server" CssClass="form-control" Width="81px" AutoPostBack="true"
                                            OnTextChanged="txtBillNo_TextChanged">0</asp:TextBox>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rate" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="90px"
                                    HeaderStyle-ForeColor="white">
                                    <ItemTemplate>
                                        <asp:TextBox Width="90px" Style="text-align: right" placeholder="Enter Rate" class="form-control"
                                            ID="txtRate" runat="server" OnTextChanged="txtdefCatID_TextChanged" AutoPostBack="true"
                                            MaxLength="10">0</asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Amount" ItemStyle-HorizontalAlign="left" HeaderStyle-Width="100px"
                                    HeaderStyle-ForeColor="white">
                                    <ItemTemplate>
                                        <asp:TextBox Width="100px" Style="text-align: right" Enabled="false" class="form-control"
                                            ID="txtAmount" runat="server" MaxLength="50">0</asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Purchase Qty" ItemStyle-HorizontalAlign="left" HeaderStyle-Width="150px"
                                        HeaderStyle-ForeColor="white">
                                        <ItemTemplate>
                                            <asp:TextBox Width="150px" Style="text-align: right" Enabled="false" class="form-control"
                                                Height="25px" ID="txtpqty" runat="server" MaxLength="50">0</asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                <asp:TemplateField ControlStyle-Width="100%" HeaderStyle-ForeColor="white" HeaderText="Expired Date"
                                    HeaderStyle-Width="350px">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtexpireddate" runat="server" Enabled="true" Height="30px" Width="350px">0</asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtexpireddate"
                                            PopupButtonID="txtexpireddate" EnabledOnClient="true" Format="dd/MM/yyyy" runat="server"
                                            CssClass="cal_Theme1">
                                        </ajaxToolkit:CalendarExtender>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Supplier" ItemStyle-HorizontalAlign="Left" Visible="false">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddSupplier" class="chzn-select" runat="server" AutoPostBack="true">
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtsupplier" runat="server" placeholder="Enter SupplierName" CssClass="form-control"
                                            Visible="false"></asp:TextBox>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="payMode" ItemStyle-HorizontalAlign="Left" Visible="false">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="ddlPay" CssClass="form-control" runat="server">
                                            <asp:ListItem Value="Select Payment Mode">Select Payment Mode</asp:ListItem>
                                            <asp:ListItem Value="Cash">Cash</asp:ListItem>
                                            <asp:ListItem Value="Credit">Credit</asp:ListItem>
                                            <asp:ListItem Value="Cheque">Cheque</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                    <FooterStyle HorizontalAlign="Right" />
                                    <FooterTemplate>
                                    </FooterTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="add" runat="server" OnClick="btnnew_Click">
                                            <asp:Image ID="img" Width="20px" runat="server" ImageUrl="~/images/edit_add.png" /></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="catid1" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField ButtonType="Image" ShowDeleteButton="true" DeleteImageUrl="~/images/delete.png" />
                            </Columns>
                        </asp:GridView>
                   
                </div>
                </div>
            </div>
 
   
    </div>
    </div>
    </div>
    <!-- /.row (nested) -->
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); 
    </script>
    </form>
</body>
</html>
