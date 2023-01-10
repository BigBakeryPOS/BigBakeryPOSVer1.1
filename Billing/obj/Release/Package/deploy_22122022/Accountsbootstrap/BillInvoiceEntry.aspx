<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillInvoiceEntry.aspx.cs"
    Inherits="Billing.Accountsbootstrap.BillInvoiceEntry" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1">
    <title>Bill Invoice Entry</title>
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
    <title>Bill Invoice Entry</title>
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
          <h1 class="page-header">Bill Invoice Entry</h1>
	    </div>
            <div class="panel-body">
                <div class="row">
                                <%--   <blink> <label  style="color:Green; font-size:12px">Screen Show Detail as Per Your Goods  To Your raw Material Request Store.Please Be Carefull While Sending Stock Entry.Thank You!!!</label></blink>--%>
                                    <div class="col-lg-3">
                                       
                                            <asp:Label runat="server" ID="Label2"><label>Select Branch</label></asp:Label>
                                            <asp:DropDownList ID="ddlbranch" runat="server" CssClass="form-control"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlbranch_OnSelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-3">
                                            <asp:Label runat="server" ID="Label3"><label>Tally/Full BillNo</label></asp:Label>
                                            <asp:TextBox ID="txtfullbillno" runat="server" CssClass="form-control"  ></asp:TextBox>
                                        </div>
                                   
                                    <div class="col-lg-3">
                                            <asp:Label runat="server" ID="lblDcNo"><label>Invoice No.</label></asp:Label>
                                            <asp:TextBox ID="txtDCNo"  runat="server" CssClass="form-control" onkeypress="return NumberOnly()"
                                                Enabled="false"></asp:TextBox>
                                            <asp:TextBox ID="txtcompanyname" Visible="false" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                       <div class="col-lg-3">
                                            <asp:Label runat="server" ID="lblDCDate"><label>Invoice Date</label></asp:Label>
                                            <asp:TextBox ID="txtDCDate" runat="server" CssClass="form-control"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDCDate"
                                                Format="dd/MM/yyyy" Enabled="false" runat="server" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                                    
                                    <div class="col-lg-3">
                                            <asp:Label runat="server" ID="Label1"><label>GRN Date</label></asp:Label>
                                            <asp:TextBox ID="txtgrndate" runat="server" CssClass="form-control" 
                                                OnTextChanged="grn_date"  Enabled="false" AutoPostBack="true"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtgrndate"
                                                Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                                       <div class="col-lg-3">
                                            <label>
                                                Prepared By</label>
                                            <asp:TextBox ID="txtAccepted" runat="server" CssClass="form-control" ></asp:TextBox>
                                        </div>
                                    
                                   <div class="col-lg-3">
                                            <label>
                                                Vehicle No</label>
                                            <asp:TextBox ID="txtvehicleno" runat="server" CssClass="form-control" ></asp:TextBox>
                                        </div>

                                    <div class="col-lg-3">
                                        <label>
                                            Select GRN NO</label>
                                        <asp:TextBox ID="txtsearching" runat="server" onkeyup="SearchEmployees(this,'#chkpono');"
                                            placeholder="Search PO Nos." CssClass="form-control"></asp:TextBox>
                                        </div>
                                            <div class="col-lg-3">
                                            <br />
                                        <div style="overflow-y: scroll; height: 130px">
                                            <div class="form-group">
                                                <asp:CheckBoxList ID="chkpono" AutoPostBack="false" CssClass="chkChoice" RepeatColumns="4"
                                                    Width="15pc"  runat="server">
                                                </asp:CheckBoxList>
                                            </div>
                                        </div>
                                        </div>
                                        <div class="col-lg-3">
                                        <br />
                                        <asp:Button ID="btnprocess" cssClass="btn btn-primary pos-btn1" runat="server" Text="Process" OnClick="Process_Click"  />
                                    </div>
                                </div>
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>

                                    <label>Item Details</label>
                               <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="gridsummary" AutoGenerateColumns="False" ShowFooter="True" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                        GridLines="Both" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                             <%-- <asp:TemplateField HeaderText="Branch Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblbranch" runat="server" Text='<%#Eval("branch") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="DC NO">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldcno" runat="server" Text='<%#Eval("DC_NO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="DC Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldcdate" runat="server" Text='<%#Eval("DC_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>--%>

                                            <asp:TemplateField HeaderText="Item Name">
                                                <ItemTemplate>
                                                    
                                                    <asp:Label ID="lblCategoryUserID" runat="server" Visible="false" Text='<%#Eval("CategoryUserID") %>'></asp:Label>
                                                    <asp:Label ID="lblDefinition" runat="server" Text='<%#Eval("Definition") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="HSN Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblhsncode" runat="server" Text='<%#Eval("hsncode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UOM">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbluom" runat="server" Text='<%#Eval("UOM") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblqty" runat="server" Text='<%#Eval("Received_Qty") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rate">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtrate" runat="server" Text='<%#Eval("Rate") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTaxVal" Enabled="false" runat="server" Visible="false" Text='<%#Eval("TaxVal") %>'></asp:TextBox>
                                                    <asp:TextBox ID="txtGST" Enabled="false" runat="server" Text='<%#Eval("GST") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txttax" Enabled="false" runat="server" ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txttotal" runat="server" Enabled="false" ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <%--<asp:GridView ID="gridbinditem" AutoGenerateColumns="False" ShowFooter="True" Visible="false" CssClass="chzn-container"
                                        GridLines="Both" Width="80%" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                              <asp:TemplateField HeaderText="Branch Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblbranch" runat="server" Text='<%#Eval("branch") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="DC NO">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldcno" runat="server" Text='<%#Eval("DC_NO") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="DC Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbldcdate" runat="server" Text='<%#Eval("DC_date") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Item Name">
                                                <ItemTemplate>
                                                    
                                                    <asp:Label ID="lblCategoryUserID" runat="server" Text='<%#Eval("CategoryUserID") %>'></asp:Label>
                                                    <asp:Label ID="lblDefinition" runat="server" Text='<%#Eval("Definition") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="HSN Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblhsncode" runat="server" Text='<%#Eval("hsncode") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="UOM">
                                                <ItemTemplate>
                                                    <asp:Label ID="lbluom" runat="server" Text='<%#Eval("UOM") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblqty" runat="server" Text='<%#Eval("Received_Qty") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Rate">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtrate" runat="server" Text='<%#Eval("Rate") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtTaxVal" Enabled="false" runat="server" Visible="false" Text='<%#Eval("TaxVal") %>'></asp:TextBox>
                                                    <asp:TextBox ID="txtGST" Enabled="false" runat="server" Text='<%#Eval("GST") %>'></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tax Amount">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txttax" Enabled="false" runat="server" ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Total">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txttotal" runat="server" Enabled="false" ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>--%>
                                    </div>
                                    <asp:Label ID="lblError" runat="server" Style="color: Red"></asp:Label>
             
                <div class="row">
                        <div class="col-lg-3">
                            <label>
                                CGST
                            </label>
                            <asp:TextBox CssClass="form-control" ID="txtcgst" runat="server" Enabled="false">0</asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label>
                                SGST</label>
                            <asp:TextBox CssClass="form-control" ID="txtsgst" runat="server" Enabled="false">0</asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label>
                                IGST</label>
                            <asp:TextBox CssClass="form-control" ID="txtigst" runat="server" Enabled="false">0</asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label>
                                Grand Total</label>
                            <asp:TextBox ID="txtgrandtotal" runat="server" CssClass="form-control" Enabled="false">0</asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                            <label>
                                Round Off</label>
                            <asp:TextBox ID="txtroundoff" runat="server" CssClass="form-control" Enabled="false">0</asp:TextBox>
                        </div>
                        <div class="col-lg-3">
                           
                                <label>
                                    Narration</label>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender22" runat="server"
                                    FilterType="LowercaseLetters, UppercaseLetters,Numbers,Custom" ValidChars="@ -."
                                    TargetControlID="txtNarration" />
                                <asp:TextBox CssClass="form-control" ID="txtNarration" runat="server" placeholder="Enter Narration"
                                    TextMode="MultiLine"></asp:TextBox>
                          
                        </div>
                        <div class="col-lg-3">
                            <br />
                            <asp:Button ID="btnSave" runat="server" class="btn btn-lg btn-primary pos-btn1" Text="Save" 
                                 Width="150px" OnClick="Save_click" />
                       
                            <asp:Button ID="btnexit" runat="server" class="btn btn-lg btn-link" Text="Exit" Width="100px" PostBackUrl="~/Accountsbootstrap/BillInvoiceGrid.aspx"
                                 />
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
