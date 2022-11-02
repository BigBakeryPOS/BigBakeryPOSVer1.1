<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderForm.aspx.cs" Inherits="Billing.Accountsbootstrap.OrderForm" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register TagPrefix="Ajaxified" Assembly="Ajaxified" Namespace="Ajaxified" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register Assembly="TimePicker" Namespace="MKB.TimePicker" TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>Order Form</title>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    
    <style type="text/css">
         blink, .blink {
            animation: blinker 4s linear infinite;
        }

       @keyframes blinker {  
            50% { opacity: 0; }
       }
      </style>
    <script type="text/javascript">
        function checkDate(sender, args) {

            //Check if the date selected is less than todays date
            if (sender._selectedDate < new Date()) {
                //show the alert message
                alert("தவறான தேதி (OR) Select Valid Date Thank You!!!");
                //set the selected date to todays date in calendar extender control
                sender._selectedDate = new Date();

                // set the date back to the current date
                sender._textbox.set_Value(sender._selectedDate.format(sender._format))
                document.getElementById('<%= btnSave.ClientID %>').disabled = false;
            }
            else {
                document.getElementById('<%= btnSave.ClientID %>').enabled = true;
            }
        }
    </script>
    <script type="text/javascript">
        function Confirm(sender) {
            var selectedText = $(sender).find("option:selected").text();
            if (confirm("Do you want to Process With This PayMode:  " + selectedText + " ?")) {
                $("#hfResponse").val('Yes');
            } else {
                $("#hfResponse").val('No');
            }
        }
    </script>
    <script type="text/javascript">
        $(function () {
            var date = new Date();
            var currentMonth = date.getMonth();
            var currentDate = date.getDate();
            var currentYear = date.getFullYear();
            $('#txtDeliveryDate').datepicker({
                minDate: new Date(currentYear, currentMonth, currentDate)
            });
        });
</script>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <script src="../js/Extension.min.js" type="text/javascript"></script>
    <link href="../css/CSS_date.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" language="javascript">
        function valchk() {
            if (dropdownchk(document.getElementById('ddlcategory'), "Select Category")
            //&& dropdownchk(document.getElementById('ddlgroup'), "Account Group")  
        && blankchk(document.getElementById('txtdescription'), "Description")) {
                alert("true");
            }
            else {
                alert("false");
                return false;
            }
        }
        

    </script>
    <script language="javascript" type="text/javascript">
        function clientShowing(sender) {


        }
        function clientShown(sender) {

        }
        function clientHiding(sender) {

        }
        function clientHidden(sender) {

        }
        function selectionChanged(sender) {
            //alert(sender._selectedTime);
        }
    </script>
    <!-- Bootstrap Core CSS -->
    <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/calendar-blue.css" rel="stylesheet" type="text/css" />
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
    <script src="../Scripts/jquery-1.4.1.min.js" type="text/javascript"></script>
    <script src="../Scripts/jquery.dynDateTime.min.js" type="text/javascript"></script>
    <script src="../Scripts/calendar-en.min.js" type="text/javascript"></script>
    <link href="../Styles/calendar-blue.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        $(document).ready(function () {
            $('txtDeliveryTime').dynDateTime({
                showsTime: true,
                ifFormat: "%Y/%m/%d %H:%M",
                daFormat: "%l;%M %p, %e %m,  %Y",
                align: "BR",
                electric: false,
                singleClick: false,
                displayArea: ".siblings('.dtcDisplayArea')",
                button: ".next()"
            });
        });
    </script>
    <script src="../js/toastrmin.js" type="text/javascript"></script>
    <script src="../js/toastr.js" type="text/javascript"></script>
    <link href="../css/toastr.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function showpop1(msg, title) {

            toastr.options = {
                "closeButton": false,
                "debug": false,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-bottom-right",
                "preventDuplicates": true,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "12000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }
            // toastr['success'](msg, title);
            var d = Date();
            toastr.warning(msg, title);
            return false;
        }


        function showpop2(msg, title) {

            toastr.options = {
                "closeButton": true,
                "newestOnTop": false,
                "progressBar": true,
                "positionClass": "toast-bottom-center",
                "preventDuplicates": false,
                "onclick": null,
                "showDuration": "300",
                "hideDuration": "1000",
                "timeOut": "5000",
                "extendedTimeOut": "1000",
                "showEasing": "swing",
                "hideEasing": "linear",
                "showMethod": "fadeIn",
                "hideMethod": "fadeOut"
            }

            

            // toastr['success'](msg, title);
            var d = Date();
            toastr.warning(msg, title);
            return false;
        }
    </script>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="form1" runat="server" autocomplete="Off">
    <asp:UpdatePanel ID="UpdatePalnel" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <div runat="server" id="editbill" visible="false">
                            <blink> <label  id="lbleditbill" runat="server"  style="color:Green; font-size:12px"></label></blink>
                            <asp:Label ID="lblstatus" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblbillno" runat="server" Visible="false"></asp:Label>
                            <asp:Label ID="lblpaymodesic" runat="server" Visible="false"></asp:Label>
                        </div>
                        <%-- <div class="col-lg-12">--%>
                        <div class="panel-heading" style="background-color: #0071BD; color: White">
                            Order Form
                            <div align="center" style="margin-top: -2pc;" >
                            <label>
                                Select ProductionType</label>
                            <asp:DropDownList ID="drpproductiontype" runat="server" Width="10%" CssClass="form-control"
                                OnSelectedIndexChanged="Producttype_chnaged" AutoPostBack="true">
                            </asp:DropDownList>
                            </div>
                            <div class="pull-right" style="margin-top: -2pc;" >
                                <label>
                                    Order No:</label>
                                <label id="lblBranch" runat="server">
                                    -</label>
                                <label id="lblOrderNo" runat="server">
                                </label>
                            </div>
                        </div>
                        <%--</div>--%>
                        <div class="panel-body">
                            <div class="col-lg-12">
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div runat="server" visible="false" align="center">
                                            Want to Sync to Production:
                                            <asp:CheckBox ID="chkchecklist" Checked="false" runat="server" /></div>
                                        <div class="col-lg-1">
                                            <b>Book No :</b>
                                            <asp:Label ID="lblbookcode" Font-Bold="true" Font-Size="16px" runat="server"></asp:Label>
                                            <asp:TextBox ID="txtbookNo" MaxLength="4" runat="server" Width="100%" CssClass="form-control"></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender6" runat="server"
                                                FilterType="Numbers" ValidChars="" TargetControlID="txtbookNo" />
                                            <asp:TextBox ID="txtabookno" runat="server" Width="100%" Visible="false" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-1">
                                            <b>Date</b>
                                            <asp:TextBox ID="txtOrderDate" Enabled="false" runat="server" CssClass="form-control"
                                                Width="95px"></asp:TextBox>
                                                
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtOrderDate"
                                                Format="yyyy-MM-dd hh:mm tt" runat="server"   CssClass="cal_Theme1 ">
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                                        <div class="col-lg-1">
                                            <b>PayMode</b>
                                            <asp:DropDownList ID="drpPayment" onchange="Confirm(this)" OnSelectedIndexChanged="paymodeclick"
                                                AutoPostBack="true" runat="server" CssClass="form-control">
                                            </asp:DropDownList>
                                            <asp:HiddenField ID="hfResponse" runat="server" />
                                        </div>
                                        <div class="col-lg-2">
                                            <b>Phone No</b>
                                            <asp:TextBox ID="txtPhineNo" OnTextChanged="txtphone_TextChanged" MaxLength="10"
                                                AutoPostBack="true" runat="server" CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <div class="col-lg-2">
                                            <b>Customer Name</b>
                                            <asp:TextBox ID="txtCustname" runat="server" CssClass="form-control"></asp:TextBox></div>
                                        <div class="col-lg-2">
                                            <b>Delivery Date</b>
                                            <asp:TextBox ID="txtDeliveryDate" runat="server" CssClass="form-control" OnTextChanged="txtDeliveryDtae_textChanged"
                                                AutoPostBack="true"></asp:TextBox>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="MM/dd/yyyy" TargetControlID="txtDeliveryDate"
                                                runat="server" CssClass="cal_Theme1"  OnClientDateSelectionChanged="checkDate">
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                                        <div class="col-lg-2">
                                            <b>Delivery Time</b>
                                            <table>
                                                <tr>
                                                    <td>
                                                        <asp:TextBox ID="txtDeliveryTime" runat="server" Visible="false"></asp:TextBox>
                                                        <asp:DropDownList ID="ddlHours" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlHours_SelectedIndexChanged"
                                                            Width="70px">
                                                            <asp:ListItem Text="01" Value="01"></asp:ListItem>
                                                            <asp:ListItem Text="02" Value="02"></asp:ListItem>
                                                            <asp:ListItem Text="03" Value="03"></asp:ListItem>
                                                            <asp:ListItem Text="04" Value="04"></asp:ListItem>
                                                            <asp:ListItem Text="05" Value="05"></asp:ListItem>
                                                            <asp:ListItem Text="06" Value="06"></asp:ListItem>
                                                            <asp:ListItem Text="07" Value="07"></asp:ListItem>
                                                            <asp:ListItem Text="08" Value="08"></asp:ListItem>
                                                            <asp:ListItem Text="09" Value="09"></asp:ListItem>
                                                            <asp:ListItem Text="10" Value="10"></asp:ListItem>
                                                            <asp:ListItem Text="11" Value="11"></asp:ListItem>
                                                            <asp:ListItem Text="12" Value="12"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlMinutes" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlMinutes_SelectedIndexChanged"
                                                            Width="70px">
                                                            <asp:ListItem Text="00" Value="00"></asp:ListItem>
                                                            <asp:ListItem Text="15" Value="15"></asp:ListItem>
                                                            <asp:ListItem Text="30" Value="30"></asp:ListItem>
                                                            <asp:ListItem Text="45" Value="45"></asp:ListItem>
                                                            <asp:ListItem Text="60" Value="60"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlMeridian" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlMeridian_SelectedIndexChanged"
                                                            Width="70px">
                                                            <asp:ListItem Text="AM" Value="AM"></asp:ListItem>
                                                            <asp:ListItem Text="PM" Value="PM"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                        <table id="dataTables-example" width="100%">
                                            <tr align="center">
                                                <td>
                                                    <div style="display: none">
                                                        <b>Previous cancel order no.</b>
                                                        <asp:DropDownList ID="ddlcancelorder" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlcancelorder_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                </td>
                                                <td>
                                                    <label>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                            <tr align="center">
                                                <td>
                                                    <label>
                                                </td>
                                                <td style="display: none">
                                                    <label>
                                                        Address</label>
                                                    <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control" TextMode="MultiLine"
                                                        Width="250px" Height="50px"></asp:TextBox>
                                                </td>
                                                <td>
                                                    <label>
                                                </td>
                                                <td>
                                                    <label>
                                                </td>
                                                <td>
                                                </td>
                                            </tr>
                                        </table>
                                        <div style="width: 100%;">
                                            <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>--%>
                                            <asp:GridView ID="gridorder" runat="server" AutoGenerateColumns="false" Width="100%"
                                                HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="Wheat" OnRowDeleting="gridorder_RowDeleting"
                                                OnRowDataBound="gridorder_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Category" HeaderStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="drpcategory" runat="server" CssClass="form-control" OnSelectedIndexChanged="category_chnaged"
                                                                AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Item" HeaderStyle-Width="18%">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="drpitem" runat="server" CssClass="form-control" OnSelectedIndexChanged="productCode_SelectedIndexChanged"
                                                                AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Qty" ItemStyle-Width="5%" ItemStyle-Font-Size="Smaller">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblitemdiscount" runat="server" Style="display: none">0</asp:Label>
                                                            <asp:TextBox ID="txtQty" AutoPostBack="true" Width="100%" Enabled="true" OnTextChanged="txtqty_chnaged"
                                                                runat="server" CssClass="form-control"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="ftbeqty" runat="server" TargetControlID="txtQty"
                                                                FilterType="Custom,Numbers" ValidChars="." />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="8%" HeaderText="Rate" ItemStyle-Font-Size="Smaller">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtRate" Width="100%" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="8%" HeaderText="Tax" ItemStyle-Font-Size="Smaller">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltax" Visible="true" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="10%" HeaderText="Amount" ItemStyle-Font-Size="Smaller">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtAmount" Width="100%" CssClass="form-control" Style="text-align: right"
                                                                runat="server" Enabled="false"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderStyle-Width="5%" HeaderText="Units" ItemStyle-Font-Size="Smaller">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblunits" Visible="false" runat="server"></asp:Label>
                                                            <asp:Label ID="lblunitid" Visible="false" runat="server"></asp:Label>
                                                            <asp:DropDownList ID="ddUnits" runat="server" CssClass="form-control">
                                                                <asp:ListItem Text="Kg"></asp:ListItem>
                                                                <asp:ListItem Text="Nos"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Model no" Visible="true" HeaderStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:DropDownList ID="drpmodelno" runat="server" CssClass="form-control" OnSelectedIndexChanged="ModelNo_chnaged"
                                                                AutoPostBack="true">
                                                            </asp:DropDownList>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                     <asp:TemplateField HeaderText="Model Image" Visible="true" HeaderStyle-Width="15%">
                                                        <ItemTemplate>
                                                            <asp:Image ID="lblimg" runat="server" Width="5pc"  />
                                                            <asp:Label ID="lblimgpath" runat="server" Visible="true" ></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="add" runat="server" OnClick="btnnew_Click">
                                                                <asp:Image ID="img" Width="20px" runat="server" ImageUrl="~/images/edit_add.png" /></asp:LinkButton>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:CommandField ShowDeleteButton="True" ButtonType="Button" />
                                                </Columns>
                                            </asp:GridView>
                                            <hr />
                                            <br />
                                            <br />
                                            <div align="center" style="background-color: Silver">
                                                <label>
                                                    Calculation Details</label>
                                            </div>
                                            <table class="table ">
                                                <tr runat="server" visible="false" align="center">
                                                    <td>
                                                        <label>
                                                            Category</label>
                                                        <asp:DropDownList ID="ddCategory1" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddCategory1_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="TextBox1" runat="server" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            Item</label>
                                                        <asp:DropDownList ID="ddlFlavour1" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlFlavour1_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtFalvAmount1" runat="server" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            Qty</label>
                                                        <asp:TextBox ID="txtQty1" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnTextChanged="txtQty1_TextChanged"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="ftbe" runat="server" TargetControlID="txtQty1"
                                                            FilterType="Custom,Numbers" ValidChars="." />
                                                    </td>
                                                    <td>
                                                        <label>
                                                            Rate/Kg</label><asp:Label runat="server" ID="lbltax1" Visible="false"> </asp:Label>
                                                        <asp:TextBox ID="txtrate1" Enabled="false" runat="server" Style="text-align: right"
                                                            CssClass="form-control" OnTextChanged="txtQty1_TextChanged"></asp:TextBox>
                                                        <asp:Label runat="server" ID="lbldisc1" Visible="false"> </asp:Label>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            Amount</label>
                                                        <asp:TextBox ID="txtamount1" Enabled="false" runat="server" Style="text-align: right"
                                                            CssClass="form-control">0</asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            Units</label>
                                                        <asp:DropDownList ID="ddUnits1" runat="server" CssClass="form-control">
                                                            <asp:ListItem Text="Kg"></asp:ListItem>
                                                            <asp:ListItem Text="Nos"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr runat="server" visible="false" align="center">
                                                    <td>
                                                        <asp:DropDownList ID="ddCategory2" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddCategory2_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="TextBox2" runat="server" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlFlavour2" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlFlavour2_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtFalvAmount2" runat="server" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtQty2" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnTextChanged="txtQty2_TextChanged"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                            TargetControlID="txtQty2" FilterType="Custom,Numbers" ValidChars="." />
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lbltax2" Visible="false"> </asp:Label>
                                                        <asp:TextBox ID="txtrate2" Enabled="false" Style="text-align: right" runat="server"
                                                            CssClass="form-control" OnTextChanged="txtQty1_TextChanged"></asp:TextBox>
                                                        <asp:Label runat="server" ID="lbldisc2" Visible="false"> </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtamount2" Enabled="false" Style="text-align: right" runat="server"
                                                            CssClass="form-control">0</asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddUnits2" runat="server" CssClass="form-control">
                                                            <asp:ListItem Text="Kg"></asp:ListItem>
                                                            <asp:ListItem Text="Nos"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr runat="server" visible="false" align="center">
                                                    <td>
                                                        <asp:DropDownList ID="ddCategory3" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddCategory3_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="TextBox3" runat="server" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlFlavour3" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlFlavour3_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtFalvAmount3" runat="server" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtQty3" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnTextChanged="txtQty3_TextChanged"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                            TargetControlID="txtQty3" FilterType="Custom,Numbers" ValidChars="." />
                                                        <asp:Label runat="server" ID="lbldisc3" Visible="false"> </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label runat="server" ID="lbltax3" Visible="false"> </asp:Label>
                                                        <asp:TextBox ID="txtrate3" Enabled="false" Style="text-align: right" runat="server"
                                                            CssClass="form-control" OnTextChanged="txtQty1_TextChanged"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtamount3" Enabled="false" Style="text-align: right" runat="server"
                                                            CssClass="form-control">0</asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddUnits3" runat="server" CssClass="form-control">
                                                            <asp:ListItem Text="Kg"></asp:ListItem>
                                                            <asp:ListItem Text="Nos"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr runat="server" visible="false" align="center">
                                                    <td>
                                                        <asp:DropDownList ID="ddCategory4" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddCategory4_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="TextBox4" runat="server" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlFlavour4" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlFlavour4_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtFalvAmount4" runat="server" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtQty4" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnTextChanged="txtQty4_TextChanged"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                            TargetControlID="txtQty4" FilterType="Custom,Numbers" ValidChars="." />
                                                        <asp:Label runat="server" ID="lbldisc4" Visible="false"> </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtrate4" Enabled="false" Style="text-align: right" runat="server"
                                                            CssClass="form-control" OnTextChanged="txtQty1_TextChanged"></asp:TextBox><asp:Label
                                                                runat="server" ID="lbltax4" Visible="false"> </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtamount4" Enabled="false" Style="text-align: right" runat="server"
                                                            CssClass="form-control">0</asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddUnits4" runat="server" CssClass="form-control">
                                                            <asp:ListItem Text="Kg"></asp:ListItem>
                                                            <asp:ListItem Text="Nos"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr runat="server" visible="false" align="center">
                                                    <td>
                                                        <asp:DropDownList ID="ddCategory5" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddCategory5_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="TextBox5" runat="server" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddlFlavour5" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlFlavour_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtFalvAmount5" runat="server" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtQty5" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            OnTextChanged="txtQty_TextChanged"></asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                            TargetControlID="txtQty5" FilterType="Custom,Numbers" ValidChars="." />
                                                        <asp:Label runat="server" ID="lbldisc5" Visible="false"> </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtrate5" Enabled="false" Style="text-align: right" runat="server"
                                                            CssClass="form-control" OnTextChanged="txtQty1_TextChanged"></asp:TextBox>
                                                        <asp:Label runat="server" ID="lbltax5" Visible="false"> </asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtamount5" Enabled="false" Style="text-align: right" runat="server"
                                                            CssClass="form-control">0</asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="ddUnits5" runat="server" CssClass="form-control">
                                                            <asp:ListItem Text="Kg"></asp:ListItem>
                                                            <asp:ListItem Text="Nos"></asp:ListItem>
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Order Option</label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drporderlist" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator id="reqFavoriteColor" ValidationGroup="val" Text="Please Select Order Type" InitialValue="Select Order Option" ControlToValidate="drporderlist" Runat="server" /> </td>--%>
                                                        <td>
                                                            <asp:DropDownList ID="ddlfunctions" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                        </td>
                                                        <td>
                                                            <label>
                                                                Sub.Total
                                                            </label>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtsubtotal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                        </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Pick Up Location</label>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="drppickup" runat="server" CssClass="form-control">
                                                        </asp:DropDownList>
                                                        <%--<asp:RequiredFieldValidator id="RequiredFieldValidator1" ValidationGroup="val" Text="Please Select PickUp Location" InitialValue="Select Pickup Location" ControlToValidate="drppickup" Runat="server" />--%>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButtonList ID="radiomode" runat="server" AutoPostBack="true" OnSelectedIndexChanged="radiomode_SelectedIndexChanged"
                                                            RepeatDirection="Horizontal">
                                                            <asp:ListItem Text="Full payment" Value="Full"></asp:ListItem>
                                                            <asp:ListItem Text="Advance" Value="Adv"></asp:ListItem>
                                                        </asp:RadioButtonList>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            CGST
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtcgst" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Delivery charge</label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtdeliverycharge" runat="server" CssClass="form-control">0</asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:CheckBox ID="chk" runat="server" Text="Sms" />
                                                    </td>
                                                    <td>
                                                        <label>
                                                            SGST
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtsgst" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <label>
                                                            Order Taken by
                                                        </label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtOrdetBy" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <%--<td colspan="2" width="70px">--%>
                                                        <asp:Label ID="lblNbilltype" runat="server" Visible="false" Text="'1'"></asp:Label>
                                                        <asp:Label ID="lbldisctype" runat="server" Visible="false" Text="'2'"></asp:Label>
                                                        <asp:DropDownList ID="attednertype" OnSelectedIndexChanged="attednerchk" AutoPostBack="true"
                                                            runat="server" Enabled="false">
                                                        </asp:DropDownList>
                                                        <asp:Label ID="lbloritot" runat="server" Visible="false"></asp:Label>
                                                        <label>
                                                            Disc.Chk</label>
                                                        <asp:CheckBox ID="chkdisc" runat="server" OnCheckedChanged="disc_checkedchanged"
                                                            AutoPostBack="true" />
                                                        <asp:TextBox ID="txtdiscotp" runat="server" placeholder="Enter OTP" Enabled="false"
                                                            TextMode="Password" AutoCompleteType="Disabled" Width="95px" OnTextChanged="otp_chnaged"
                                                            AutoPostBack="true"></asp:TextBox>
                                                        <br />
                                                        <label>
                                                            Max.disc</label>
                                                        <asp:Label ID="lblmaxdiscount" Text="0" Visible="true" Font-Bold="true" Font-Size="Larger"
                                                            ForeColor="Red" runat="server"></asp:Label>
                                                        <%-- </td>--%>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            Discount %
                                                        </label>
                                                        <asp:DropDownList ID="drpdischk" runat="server" CssClass="form-control" OnSelectedIndexChanged="disc_selectedindex"
                                                            AutoPostBack="true">
                                                        </asp:DropDownList>
                                                        <asp:TextBox ID="txtdiscper" runat="server" Visible="false" Text="0" Enabled="false"
                                                            CssClass="form-control" OnTextChanged="txtDiscount_TextChanged" AutoPostBack="true">0</asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            Disc.Amount
                                                        </label>
                                                        <asp:TextBox ID="txtdiscamount" runat="server" CssClass="form-control" Enabled="false">0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <asp:Button ID="btnSave" runat="server" CssClass="btn btn-success" ValidationGroup="val"
                                                            Text="Save & Print" UseSubmitBehavior="false" OnClientClick="this.disabled=true;"
                                                            OnClick="btnSave_Click" />
                                                        <asp:Button ID="Button1" runat="server" CssClass="btn btn-danger" Text="Exit" UseSubmitBehavior="false"
                                                            PostBackUrl="~/Accountsbootstrap/OrderGrid.aspx" />
                                                        <div id="chkdelv" runat="server" visible="false">
                                                            <label>
                                                                Delivery Status</label>
                                                            <asp:CheckBox ID="chkdelivery" runat="server" />
                                                            <asp:TextBox ID="txtdeliveryby" runat="server"></asp:TextBox>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div runat="server" id="Tpaid" visible="false">
                                                            <label>
                                                                Total Paid (Advance + P.amount + BAL. - Refund):</label>
                                                            <asp:Label ID="totpaid" Font-Bold="true" Font-Size="25px" BackColor="Green" ForeColor="White"
                                                                runat="server"></asp:Label>
                                                        </div>
                                                        <div runat="server" id="Ramount" visible="false">
                                                            <label>
                                                                Refund Amount:</label>
                                                            <asp:Label ID="lblrefundamount" Font-Bold="true" Font-Size="30px" BackColor="Red"
                                                                runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            Total Amount</label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txttotal" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                        <div id="Epaymode" runat="server" visible="false">
                                                            <b>PayMode</b>
                                                            <asp:DropDownList ID="drpPayment1" onchange="Confirm(this)" OnSelectedIndexChanged="paymodeclick"
                                                                AutoPostBack="true" runat="server" CssClass="form-control">
                                                            </asp:DropDownList>
                                                            <asp:HiddenField ID="HiddenField1" runat="server" />
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div style="padding-left: 2pc" id="Pamount" runat="server" visible="false">
                                                            <b>Amount</b><br />
                                                            <asp:TextBox ID="txtpartialamount" runat="server" OnTextChanged="partial_amount"
                                                                AutoPostBack="true" Enabled="true"></asp:TextBox>
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                                TargetControlID="txtpartialamount" FilterType="Custom,Numbers" ValidChars="." />
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <div runat="server" visible="false" id="balpaid">
                                                            <label>
                                                                Balance Paid</label>
                                                            <asp:Label ID="lblbalpaid" runat="server"></asp:Label>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            Advance</label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtAdvance" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            Enabled="false" OnTextChanged="txtAdvance_TextChanged">0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            Payment Details</label>
                                                        <asp:GridView ID="Gridpaymentdetails" EmptyDataText="No Payment Details" runat="server"
                                                            Width="100%" AutoGenerateColumns="false" Font-Names="Calibri">
                                                            <Columns>
                                                                <asp:BoundField DataField="Billdate" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Payment Date" />
                                                                <asp:BoundField DataField="Amount" DataFormatString="{0:###,##0.00}" HeaderText="Paid Amount" />
                                                                <asp:BoundField DataField="Type" HeaderText="Paid Type" />
                                                                <asp:BoundField DataField="mod" HeaderText="Pay Mode" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </td>
                                                    <td>
                                                    </td>
                                                    <td>
                                                        <label>
                                                            Balance</label>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtBalance" runat="server" Enabled="false" CssClass="form-control">0</asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="display: none">
                                                        <label>
                                                            Messege</label>
                                                        <asp:TextBox TextMode="MultiLine" MaxLength="50" ID="txtMessege" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </td>
                                                    <td style="display: none">
                                                        <label>
                                                            Notes</label>
                                                        <asp:TextBox TextMode="MultiLine" MaxLength="50" ID="txtNotes" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="display: none">
                                                        <label>
                                                            Delivery Place
                                                        </label>
                                                        <asp:TextBox ID="txtPlace" runat="server" CssClass="form-control" placeholder="eg Kk Nagar"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                    </td>
                                                </tr>
                                            </table>
                                            <%-- </ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePalnel">
        <ProgressTemplate>
            <div class="overlay">
                <div style="z-index: 1000; margin-left: 350px; margin-top: 200px; opacity: 1; -moz-opacity: 1;">
                    <img alt="" src="~/images/Preloader_10.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>
</html>
