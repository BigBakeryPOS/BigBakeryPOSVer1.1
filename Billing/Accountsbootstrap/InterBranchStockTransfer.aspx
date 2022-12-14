<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterBranchStockTransfer.aspx.cs" Inherits="Billing.Accountsbootstrap.InterBranchStockTransfer" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1">
    <script language="javascript" type="text/javascript">

        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
                event.returnValue = true;
            else

                event.returnValue = false;
        }

    </script>
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
        function printGrid() {
            var gridData = document.getElementById('<%= GridView1.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();

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
    <script type="text/javascript" language="javascript">
        var oldRowColor;

        // this function is used to change the backgound color

        function ChangeColor() {

            var obj = window.event.srcElement;

            if (obj.tagName == "INPUT" && obj.type == "text") {

                obj = obj.parentElement.parentElement;

                oldRowColor = obj.className;

                obj.className = "HighLightRowColor";

            }

        }

        // this function is used to reset the background color 
        function ResetColor() {

            var obj = window.event.srcElement;

            if (obj.tagName == "INPUT" && obj.type == "text") {

                obj = obj.parentElement.parentElement;

                obj.className = oldRowColor;

            }

        }

    </script>
    <style type="text/css">
        
        .RowStyleBackGroundColor
{

background-color:White;

}

.RowAlternateStyleBackGroundColor

{

background-color:White;

}

.HighLightRowColor

{

background-color:Aqua;
font-weight:bold;
font-size:xx-large;
color:White;

}
        </style>
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
    <title>Inter Branch Goods Transfer</title>
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
    <style>
  <%-- .HiddenCol{display:none;}          --%>      
</style>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>

    <form runat="server" id="form1" method="post">
    <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
    <ContentTemplate>     --%>
    <div class="row" style="">
        <div class="col-lg-12" style="">
            <div class="panel panel-primary" style="">
                            <div class="panel-heading">Inter Branch Goods Transfer</div>
                <div class="panel-body" style="">
                    <div class="row" style="">
                        <div class="col-lg-3" style="">
                        </div>
                    </div>
                    <div class="row" style="">
                        <div class="col-lg-12" style="">
                            <div class="panel-body" style="height: 68px">
                                <div style="">
                                    <div class="row" style="">
                                        <div class="col-lg-2" style="">
                                            <div class="form-group" style="">
                                                <asp:Label runat="server" ID="lblDcNo" Enabled="false"><label> Transfer No.</label></asp:Label>
                                                <asp:TextBox ID="txtDCNo" Width="150px" runat="server" CssClass="form-control" Enabled="false"
                                                    onkeypress="return NumberOnly()"></asp:TextBox>
                                                <asp:TextBox ID="txtcompanyname" Visible="false" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-2" style="">
                                            <div class="form-group">
                                                <asp:Label runat="server" ID="lblDCDate"><label> Transfer Date</label></asp:Label>
                                                <asp:TextBox ID="txtDCDate" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDCDate"
                                                    runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                            </div>
                                        </div>
                                        <div class="col-lg-2" style="">
                                            <div class="form-group">
                                                <label>
                                                    Accepted By</label>
                                                <asp:TextBox ID="txtAccepted" runat="server" CssClass="form-control" Width="150px"
                                                    required></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-2">
                                            <div class="form-group">
                                                <label>
                                                    Search </label>
                                                <asp:TextBox ID="txtSearch" runat="server" onkeyup="Search_Gridview(this, 'gvPurchase')"
                                                    CssClass="form-control" placeholder="Search Category/Item.." Width="200px"></asp:TextBox>
                                            </div>
                                        </div>
                                              <div class="col-lg-2"><br />
                                              <asp:Button ID="btnvalue" runat="server" Text="Transfer" CssClass="btn btn-success" />
                                              </div>      
                                    </div>
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                </div>
                            </div>
                        </div>
                    </div>
            
               
                    <div class="col-lg-12">
                   
                     
                                                    <asp:GridView ID="gvPurchase" runat="server" AutoGenerateColumns="false" Width="100%"
                                                        Font-Size="Medium">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="categoryID" DataField="categoryid" Visible="false" />
                                                            <asp:BoundField HeaderText="DespID" DataField="CategoryUserID" Visible="false" />
                                                            <asp:TemplateField HeaderText="Category" HeaderStyle-Width="175px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category")%>'></asp:Label>
                                                                    <asp:HiddenField ID="HDCategoryid" runat="server" Value='<%#Eval("categoryid") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Item Name" HeaderStyle-Width="450px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblProduct" runat="server" Text='<%#Eval("Definition")%>'></asp:Label>
                                                                    <asp:HiddenField ID="HDProductid" runat="server" Value='<%#Eval("CategoryUserID") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Avaliable Qty" HeaderStyle-Width="110px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblStockQty" runat="server" Text='<%#Eval("StockQty")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Branch Requested Qty" HeaderStyle-Width="150px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblOrder_Qty" runat="server" Text='<%#Eval("Order_Qty")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Branch to Branch" HeaderStyle-Width="110px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txttransferQty" onBlur="ResetColor()" onFocus="ChangeColor()" runat="server" Width="110px"></asp:TextBox>
                                                                    <ajaxToolkit:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txttransferQty"
                                                                        FilterType="Custom,Numbers" ValidChars="." />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="Units" DataField="UOM" />
                                                            <asp:BoundField HeaderText="Rate" Visible="false" DataField="Rate" DataFormatString="{0:n}" />
                                                            <asp:TemplateField HeaderText="ExpiryDate" ItemStyle-Width="150px" HeaderStyle-CssClass="hidden"
                                                                ItemStyle-CssClass="hidden">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtExpiryDate"
                                                                        runat="server" CssClass="cal_Theme1">
                                                                    </ajaxToolkit:CalendarExtender>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <RowStyle CssClass="RowStyleBackGroundColor" ForeColor="Black" />
                                                        <AlternatingRowStyle CssClass="RowAlternateStyleBackGroundColor" />
                                                        <FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                                        <%--<HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                                                    </asp:GridView>
                                                
                                               <br />
                                                    <asp:Label ForeColor="Red" ID="lblMsg" runat="server"></asp:Label>
                                              
                                                    <asp:Button ID="btnPreview" runat="server" CssClass="btn btn-danger" Text="preview"
                                                        OnClick="btnPreview_Click" Visible="false" />
                                              
                            <asp:Label ID="lblError" runat="server" Style="color: Red"></asp:Label>
                            </div>                        </div>
                    </div>
                </div>
            </div>
            <!-- /.col-lg-6 (nested) -->
        </div>
        <!-- /.row (nested) -->
    </div>
    <div>
        <asp:LinkButton ID="lnkbtn" Text="" runat="server"></asp:LinkButton>
        <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
            CancelControlID="ButtonDeleteCancel" TargetControlID="lnkbtn" PopupControlID="DivDeleteConfirmation"
            BackgroundCssClass="modalBackground">
        </ajaxToolkit:ModalPopupExtender>
        <asp:Panel ScrollBars="Auto" Height="600px" Width="900px" ID="DivDeleteConfirmation"
            CssClass="modalPopup" runat="server">
            <div>
                <div align="center">
                    <table border="0" cellpadding="0" cellspacing="0">
                        <tr>
                            <td>
                                <div id="Div19" runat="server" style="overflow: auto; height: 450px">
                                    <asp:GridView ID="GridView1" runat="server" AllowPaging="false"
                                        EmptyDataText="No Item Avaliable " AutoGenerateColumns="false" Width="100%">
                                        <PagerSettings FirstPageText="First" LastPageText="Last" NextPageText="Next" PreviousPageText="Previous" />
                                        <Columns>
                                            <asp:BoundField HeaderText="Item Name" DataField="Item" />
                                            <asp:BoundField HeaderText="Qty" DataField="Qty" />
                                        </Columns>
                                        <%--<HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />--%>
                                    </asp:GridView>
                                </div>
                            </td>
                        </tr>
                    </table>
                </div>
                <div align="center">
                <asp:RadioButton ID="radbtn" runat="server" Text="Confirm Request" OnCheckedChanged="btnPrev_Click" AutoPostBack="true"  />
                    <asp:Button ID="btnPreview1" runat="server" Visible="false" CssClass="btn btn-danger" Text="Ok" OnClick="btnPrev_Click" />
                    <input id="ButtonDeleteCancel" type="button" cssclass="btn btn-danger" value="Cancel" />
                </div>
            </div>
        </asp:Panel>
    </div>
    </form>
</body>
</html>

