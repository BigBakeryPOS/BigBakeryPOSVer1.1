<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DailyProductionReceiveStoreItem.aspx.cs"
    Inherits="Billing.Accountsbootstrap.DailyProductionReceiveStoreItem" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1">
    <title>Daily Production Receive Item </title>
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
    <title>Receive Raw Materials</title>
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
    <div class="col-lg-12" style="">
        <div class="panel panel-default" style="">
            <div class="panel-heading " style="background-color: #428bca; color: White">
                <b>Daily Production Receive Item</b></div>
            <div class="panel-body" style="">
                <div class="row" style="">
                    <div class="col-lg-3" style="">
                    </div>
                </div>
                <div class="row" style="">
                    <div class="col-lg-12" style="">
                        <div class="panel-body" style="height: 68px">
                            <div style="">
                                <%--   <blink> <label  style="color:Green; font-size:12px">Screen Show Detail as Per Your Goods  To Your raw Material Request Store.Please Be Carefull While Sending Stock Entry.Thank You!!!</label></blink>--%>
                                <div class="row" style="">
                                    <div class="col-lg-2" style="">
                                        <div class="form-group" style="">
                                            <asp:Label runat="server" ID="Label2"><label>Request No.</label></asp:Label>
                                            <asp:DropDownList ID="ddlrequestno" runat="server" CssClass="form-control" Width="200px"
                                                AutoPostBack="true" OnSelectedIndexChanged="ddlrequestno_OnSelectedIndexChanged">
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-2" style="">
                                        <div class="form-group" style="">
                                            <asp:Label runat="server" ID="lblDcNo"><label>Request No.</label></asp:Label>
                                            <asp:TextBox ID="txtDCNo" Width="150px" runat="server" CssClass="form-control" onkeypress="return NumberOnly()"
                                                Enabled="false"></asp:TextBox>
                                            <asp:TextBox ID="txtcompanyname" Visible="false" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-2" style="">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="lblDCDate"><label>Request Date</label></asp:Label>
                                            <asp:TextBox ID="txtDCDate" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDCDate"
                                                Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="col-lg-2" style="">
                                        <div class="form-group">
                                            <label>
                                              Request Prepared By</label>
                                            <asp:TextBox ID="txtAccepted" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                                              
                                        </div>
                                    </div>
                                    <div class="col-lg-2">
                                    <br />
                                     <asp:Button ID="btnPreview" runat="server" CssClass="btn btn-danger" Text="Receive Daily Production Item"
                                OnClick="btnPrev_Click" Visible="true" />
                                    </div>
                                    <div class="col-lg-2" style="">
                                    </div>
                                </div>
                                 <div class="row" style="">
                                 <hr style="width:1500;color:blue;height:50" />

                                 </div>


                                  <div class="row" style="">
                                 <div class="col-lg-2" style="">
                                        <div class="form-group" style="">
                                            <asp:Label runat="server" ID="Label1"><label>Receive No.</label></asp:Label>
                                            <asp:TextBox ID="txtReceiveNo" Width="150px" runat="server" CssClass="form-control" onkeypress="return NumberOnly()"
                                                Enabled="false"></asp:TextBox>
                                         
                                        </div>
                                    </div>
                                    <div class="col-lg-2" style="">
                                        <div class="form-group">
                                            <asp:Label runat="server" ID="Label3"><label>Receive Date</label></asp:Label>
                                            <asp:TextBox ID="txtReceiveDAte" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtReceiveDAte"
                                                Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                                    </div>
                                    <div class="col-lg-2" style="">
                                        <div class="form-group">
                                            <label>
                                              Receive Prepared By</label>
                                            <asp:TextBox ID="txtReceivePreparedby" runat="server" CssClass="form-control" Width="150px"></asp:TextBox>
                                              
                                        </div>
                                    </div>

                                 </div>

                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-12">
                        <div class="col-lg-6">
                            <div class="panel panel-default" style="">
                                <div class="panel-heading " style="background-color: #428bca; color: White">
                                    <b>Daily Production Item Details</b></div>
                                <div class="panel-body" style="">
                                    <asp:GridView ID="GridView2" AutoGenerateColumns="False" ShowFooter="True" CssClass="chzn-container"
                                        GridLines="Both" Width="80%" runat="server">
                                        <Columns>
                                            <asp:TemplateField HeaderText="S.No">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Item Name">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="Semiitemid" runat="server" Value='<%#Eval("itemid") %>' />
                                                    <asp:Label ID="lblIngredientName" runat="server" Text='<%#Eval("Definition") %>'></asp:Label>
                                                    <asp:Label ID="lblBatchno" runat="server" Visible="false" Text='<%#Eval("Batchno") %>'></asp:Label>
                                                    <asp:Label ID="lblexpirydate" runat="server" Visible="false" Text='<%#Eval("expirydate") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Transfer Qty">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblWantedRaw" runat="server" Text='<%#Eval("Qty") %>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Accept Qty">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtacceptqty" runat="server"  Text='<%#Eval("Qty") %>' ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Missing Qty">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtmissingqty"  runat="server" ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Damage Qty">
                                                <ItemTemplate>
                                                    <asp:TextBox ID="txtdamageqty"  runat="server" ></asp:TextBox>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="Unit" DataField="UOM" />
                                            <asp:BoundField HeaderText="Batch No" DataField="Batchno" />
                                            <asp:BoundField HeaderText="Expiry date" DataField="expirydate" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:Label ID="lblError" runat="server" Style="color: Red"></asp:Label>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6">
                        <div class="panel-heading " style="background-color: #428bca; color: White">
                                    <b>Item Details</b></div>
                                    <br />
                            <asp:GridView ID="gvRawRequest" Visible="false" runat="server" AutoGenerateColumns="false" Width="100%" Font-Names="Calibri"
                                Font-Size="Medium"   AllowSorting="true">
                                 <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> 
                                <Columns>
                                    <asp:TemplateField HeaderText="Item Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblProduct" runat="server" Text='<%#Eval("Definition")%>'></asp:Label>
                                            <asp:HiddenField ID="HDProductid" runat="server" Value='<%#Eval("ItemId") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Qty">
                                        <ItemTemplate>
                                            <asp:Label ID="lblQty" runat="server" Text='<%#Eval("Qty")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Branch Qty">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblorgQty" runat="server" Text='<%#Eval("orgQty")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Excess Qty">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblexcessqty" runat="server" Text='<%#Eval("excessqty")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="Adj.Qty" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtadjqty" OnTextChanged="Excess_click" AutoPostBack="true" runat="server">0</asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Final Qty" Visible="true">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="txtfinalqty" Text='<%#Eval("Qty")%>' runat="server">0</asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                </Columns>
                                <%--<FooterStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />
                                <HeaderStyle BackColor="#990100" ForeColor="White" HorizontalAlign="Center" />--%>
                            </asp:GridView>
                            <asp:Label ForeColor="Red" ID="lblMsg" runat="server"></asp:Label>
                           
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- /.col-lg-6 (nested) -->
    </div>
    <!-- /.row (nested) -->
    </form>
</body>
</html>
