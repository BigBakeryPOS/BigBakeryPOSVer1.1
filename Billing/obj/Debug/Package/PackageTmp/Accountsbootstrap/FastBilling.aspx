<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FastBilling.aspx.cs" Inherits="Billing.Accountsbootstrap.FastBilling" %>

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
    <title> Fast Sales </title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../css/TableCSSCode.css" rel="stylesheet" type="text/css" />
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script src="../js/jquery-1.10.2.min.js" type="text/javascript"></script>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.12.0/themes/base/jquery-ui.css">
    <script type="text/javascript" src="https://code.jquery.com/jquery-1.12.4.js"></script>
    <script type="text/jscript" src="https://code.jquery.com/ui/1.12.0/jquery-ui.js"></script>
    <%-- <script type="text/javascript">
        $(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_initializeRequest(InitializeRequest1);
            prm.add_endRequest(EndRequest1);
            InitAutoCompl1();
        });

        function InitializeRequest1(sender, args) {
        }

        function EndRequest1(sender, args) {
            // after update occur on UpdatePanel re-init the Autocomplete
            InitAutoCompl1();
        }

        function InitAutoCompl1() {

            $("input[id='txtsalesperson']").on("keyup", function (event) {
                if (event.which == 13) {
                    $("input[name='txtCountry1']").focus();
                }
            });
        }
    </script>--%>
    <script type="text/javascript">
        $(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_initializeRequest(InitializeRequest2);
            prm.add_endRequest(EndRequest2);
            InitAutoCompl2();
        });

        function InitializeRequest2(sender, args) {

        }

        function EndRequest2(sender, args) {
            // after update occur on UpdatePanel re-init the Autocomplete

            InitAutoCompl2();
        }

        function InitAutoCompl2() {

            $("input[id='NtxtQty']").on("keyup", function (event) {
                if (event.which == 13) {

                    $("input[name='txtCountry1']").focus();
                }
            });
        }
    </script>
    <script type="text/javascript">
        $(function () {
            var prm = Sys.WebForms.PageRequestManager.getInstance();
            prm.add_initializeRequest(InitializeRequest);
            prm.add_endRequest(EndRequest);
            InitAutoCompl();
            InitAutoCompll();
        });

        function InitializeRequest(sender, args) {
        }

        function EndRequest(sender, args) {
            // after update occur on UpdatePanel re-init the Autocomplete
            InitAutoCompl();
            InitAutoCompll();
        }


        function InitAutoCompl() {

            $("input[id='txtCountry1']").on("keyup", function (event) {
                var txt = $(this).val();
                var rate = document.getElementById('Ntxtrate').value;
                if ((event.which == 13) && (txt == "" || txt == null)) {
                    $(this).focus();
                }
                else if (event.which == 13) {
                    if (rate == "" || rate == null || rate == "0.00") {
                        document.getElementById('Ntxtrate').value = "";
                        $("input[name='Ntxtrate']").focus();
                    }
                    else {
                        $("input[name='NtxtQty']").focus();

                    }
                }

            });

            $("input[id='Ntxtrate']").on("keyup", function (event) {
                var txt = $(this).val();

                if ((event.which == 13) && (txt == "" || txt == null)) {
                    $(this).focus();
                }
                else if (event.which == 13) {
                    $("input[name='NtxtQty']").focus();
                }

            });

            $("input[id='Ntxtrate']").on("keydown", function (event) {
                var txt = $(this).val();
                if (event.which == 13) {
                    event.preventDefault();
                    return false;
                }
            });

            $("input[id='txtCountry1']").on("keydown", function (event) {
                var txt = $(this).val();
                if ((event.which == 13) && (txt == "" || txt == null)) {
                    event.preventDefault();
                    return false;
                }
                else if ((event.which == 32) && (txt == "" || txt == null)) {
                    $("#btnPrint").click();
                    event.preventDefault();
                    return false;
                }
            });

            $("input[id='txtsalesperson']").on("keydown", function (event) {
                var txt = $(this).val();
                if ((event.which == 13) && (txt == "" || txt == null)) {
                    event.preventDefault();
                    return false;
                }
            });

            $("#<%=txtCountry1.ClientID %>").autocomplete({
                source: function (request, response) {
                    
                    $.ajax({
                        url: '<%=ResolveUrl("~/Accountsbootstrap/FastBilling.aspx/GetCountrie") %>',
                        data: "{ 'prefix': '" + request.term + "'}",
                        dataType: "json",
                        type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {
                                    label: item.split('|')[0],
                                    val: item.split('|')[1],
                                    rate: item.split('|')[2]
                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfCustomerId]").val(i.item.val);
                    $("[id$=Ntxtrate]").val(i.item.rate);
                },
                minLength: 1,
                autoFocus: true
            });
        }



        function InitAutoCompll() {

            $("input[id='txtsalesperson']").on("keyup", function (event) {

                var txt = $(this).val();
                if ((event.which == 13) && (txt == "" || txt == null)) {
                    event.preventDefault();
                    return false;
                }
                else if (event.which == 13 && txt != "" && txt != null) {
                    $("input[name='txtCountry1']").focus();
                }

            });

            $("#<%=txtsalesperson.ClientID %>").autocomplete({
            
                source: function (request, response) {
                    $.ajax({
                        url: '<%=ResolveUrl("~/Accountsbootstrap/FastBilling.aspx/GetSalesPerson") %>',
                        // data: "{ 'prefix': '" + JSON.stringify(request.term) + "'}",
                        data: "prefixText=" + JSON.stringify(request.term),
                        dataType: "json",
                        //type: "POST",
                        contentType: "application/json; charset=utf-8",
                        success: function (data) {
                            response($.map(data.d, function (item) {
                                return {

                                    label: item.split('/')[0],
                                    val: item.split('/')[1]

                                }
                            }))
                        },
                        error: function (response) {
                            alert(response.responseText);
                        },
                        failure: function (response) {
                            alert(response.responseText);
                        }
                    });
                },
                select: function (e, i) {
                    $("[id$=hfsalespersonId]").val(i.item.val);

                },
                minLength: 1,
                autoFocus: true
            });
        } 

    </script>
    <script type="text/javascript">
        function DisableButton() {
            alert("HI");
            document.getElementById("<%=btnPrint .ClientID %>").disabled = true;
        }
        window.onbeforeunload = DisableButton;
    </script>
    <script type="text/javascript">
        function alertMessage() {
            // alert('Mail Sent Successfully!!!');
        }

        function SelectGiven() {
            alert('Enter Your Name!');
        }

        function Mobile() {
            alert('Enter  Mobile No!');
        }


       
    </script>
    <script type="text/javascript">
        function Search_Gridview(strKey, strGV) {


            //            var strData = strKey.value.toLowerCase().split(" ");
            var strGV = '<%=GridView1.ClientID%>';

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
    <script language="Javascript" type="text/javascript">

        function onlyNos(e, t) {
            alert("HI");
            try {
                if (window.event) {
                    var charCode = window.event.keyCode;
                }
                else if (e) {
                    var charCode = e.which;
                }
                else { return true; }
                if (charCode > 31 && (charCode < 48 || charCode > 57)) {
                    return false;
                }
                return true;
            }
            catch (err) {
                alert(err.Description);
            }
        }
 
    </script>
    <script type="text/javascript">
        function setFocus() {
            alert("Test2");
            document.DropDownList1.focus();
        }
    </script>
   
    <style type="text/css">
        .styled-button-101
        {
            border-radius: 15px;
            moz-border-radius: 15px;
            webkit-border-radius: 15px; /*adjust height and width*/
            height: 50px;
            width: 200px; /*change border colour*/
            border: 1px #245ec6 solid;
        }
        
        .styled-button-105
        {
            background: #5CCD00;
            filter: progid: DXImageTransform.Microsoft.gradient( startColorstr='#5CCD00', endColorstr='#4AA400',GradientType=0);
            padding: 10px 15px;
            color: #fff;
            font-family: 'Helvetica Neue' ,sans-serif;
            font-size: 12px;
            font-weight: bolder;
            border-radius: 5px;
            -moz-border-radius: 5px;
            -webkit-border-radius: 5px;
            border: 1px solid #459A00;
            white-space: normal;
            width: 150px;
        }
        .style1
        {
            height: 39px;
        }
    </style>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>



    <form id="form1" runat="server">
    <div>
    
        <asp:UpdatePanel ID="UpdatePanel" runat="server" UpdateMode="Conditional" >
            <ContentTemplate>
                
                <asp:Label runat="server" ID="lbltempsalesid" Visible="false"></asp:Label>
                <asp:Label ID="lblmargin" Visible="false" runat="server" ></asp:Label>
                <asp:Label ID="lblmargintax" Visible="false" runat="server"></asp:Label>
                <asp:Label ID="lblpaygate" Visible="false" runat="server" ></asp:Label>


                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>

                <table width="100%" border="0">
                    <tr>
                        <td valign="top" style="width: 15%">
                        
                            <div style="overflow: scroll; height: 40pc">
                                <asp:GridView ID="GridView1" BorderStyle="None" runat="server" AutoGenerateColumns="false"
                                    ShowHeader="false" BorderColor="White" OnRowCommand="GridView1_RowCommand">
                                    <Columns>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:Button ID="Button1" runat="server" Font-Bold="true" Height="30px" Width="150px"
                                                    Text='<%#Eval("Category")%>' CommandArgument='<%#Eval("CategoryID") %>' BackColor="#428bca"
                                                    ForeColor="White" OnClick="Button1_Click" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </td>
                        <td valign="top" width="45%">
                       
                            <div style="overflow: scroll; height: 40pc">
                            
                                <table>
                                    <tr runat="server" visible="false" >
                                        <td align="left" valign="top" style="width: 15%">
                                            <asp:GridView ID="GridView2" runat="server" Width="100%" ShowHeader="false" GridLines="None"
                                                BorderColor="White" AutoGenerateColumns="false" Style="overflow: auto; height: 50px"
                                                OnRowDataBound="GridView2_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Button ID="Button2" CssClass="styled-button-101" Font-Bold="true" runat="server"
                                                                Text='<%#Eval("Definition")%>' CommandArgument='<%#Eval("CategoryUserID") %>  '
                                                                Font-Size="14px" BackColor="#FFFF00" ForeColor="Black" OnClick="Button2_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                        <td valign="top" style="width: 15%">
                                            <asp:GridView ID="GridView3" runat="server" Width="100%" ShowHeader="false" GridLines="None"
                                                BorderColor="White" AutoGenerateColumns="false" Style="overflow: auto; height: 50px"
                                                OnRowDataBound="GridView3_RowDataBound">
                                                <Columns>
                                                    <asp:TemplateField>
                                                        <ItemTemplate>
                                                            <asp:Button ID="Button2" runat="server" CssClass="styled-button-101" Font-Bold="true"
                                                                Text='<%#Eval("Definition")%>' CommandArgument='<%#Eval("CategoryUserID") %>'
                                                                Font-Size="14px" BackColor="#FFFF00" ForeColor="Black" OnClick="Button2_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                        <td valign="top" style="width: 15%">
                                            <asp:GridView ID="GridView4" OnRowDataBound="GridView4_RowDataBound" GridLines="None"
                                                runat="server" Width="100%" ShowHeader="false" BorderColor="White" AutoGenerateColumns="false"
                                                Style="overflow: auto; height: 50px">
                                                <Columns>
                                                    <asp:TemplateField ItemStyle-Wrap="true">
                                                        <ItemTemplate>
                                                            <asp:Button ID="Button2" runat="server" CssClass="styled-button-101" Font-Bold="true"
                                                                Text='<%#Eval("Definition")%>' CommandArgument='<%#Eval("CategoryUserID") %>'
                                                                Font-Size="14px" BackColor="#FFFF00" ForeColor="Black" OnClick="Button2_Click" />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                     <tr id="allitem" runat="server" visible="true" style="background-color: Gray;">
                                            <td width="5%">
                                                <asp:TextBox ID="TextBox1" runat="server" Width="50px" Height="35px" Font-Size="X-Large"
                                                    Enabled="false" Visible="false"></asp:TextBox>
                                            </td>
                                            <td>
                                                <label style="color: White">
                                                    Sales Person</label><br />
                                                <asp:TextBox ID="txtsalesperson" TabIndex="1" runat="server" Width="100px"></asp:TextBox>
                                                <asp:HiddenField ID="hfsalespersonId" runat="server" />
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                    FilterType="LowercaseLetters,UppercaseLetters,custom,Numbers" InvalidChars=" "
                                                    TargetControlID="txtsalesperson" />
                                            </td>
                                            <td style="width: 15px">
                                            </td>
                                            <td>
                                                <label style="color: White">
                                                    Enter Item</label><br />
                                                <asp:DropDownList ID="drpitemNew" runat="server" CssClass="chzn-select" AutoPostBack="true"
                                                    Visible="false" OnSelectedIndexChanged="drpitemNew_TextChanged" Width="100px">
                                                </asp:DropDownList>
                                                <asp:Label ID="lblitemid" runat="server" Visible="false"></asp:Label>
                                                <asp:TextBox ID="txtCountry1" runat="server" TabIndex="2"></asp:TextBox>
                                                <asp:HiddenField ID="hfCustomerId" runat="server" />
                                            </td>
                                            <td style="width: 15px">
                                                <td>
                                                    <label style="color: White">
                                                        Rate</label><br />
                                                    <asp:TextBox ID="Ntxtrate" placeholder="Enter Rate" runat="server" TabIndex="3" Width="100px"></asp:TextBox>
                                                </td>
                                                </td>
                                                <td style="width: 15px">
                                                    <td>
                                                        <label style="color: White">
                                                            Enter Qty</label><br />
                                                        <asp:TextBox ID="txtsno" Visible="false" Text="1" Width="10%" runat="server"></asp:TextBox>
                                                        <asp:TextBox ID="NtxtQty" placeholder="Enter Qty" AutoPostBack="true" runat="server"
                                                            TabIndex="3" OnTextChanged="Qty_chnaged" Width="100px"></asp:TextBox>
                                                    </td>
                                                    <td width="8%">
                                                        <asp:DropDownList ID="DropDownList2" Visible="false" runat="server" CssClass="chzn-select"
                                                            Width="200px">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td id="Td17" runat="server" visible="false">
                                                        <label style="color: White">
                                                            Employe Code</label>
                                                        <asp:DropDownList ID="ddlsaleser" runat="server" Width="100px" />
                                                    </td>
                                                    </td>
                                        </tr>
                                </table>
                            </div>
                        </td>
                        <td valign="top" style="width: 40%">
                            <table>
                                <tr>
                                    <td width="20%">
                                        <label>
                                            Bill/Kot No</label>
                                        <asp:TextBox ID="txtBillNo" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </td>
                                    <td>
                                        <label>
                                            Bill Date</label>
                                        <asp:TextBox ID="txtBillDate" CssClass="form-control" Text="-Select Date--" Enabled="false"
                                            runat="server"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtBillDate"
                                            PopupButtonID="txtdate1" EnabledOnClient="true" runat="server" CssClass="cal_Theme1">
                                        </ajaxToolkit:CalendarExtender>
                                    </td>
                                    <td>
                                        <label>
                                            Sales Type</label>
                                        <asp:DropDownList ID="drpsalestype" Width="100%" runat="server" OnSelectedIndexChanged="drpsalestype_selectedindex"
                                            AutoPostBack="true" CssClass="form-control">
                                        </asp:DropDownList>
                                        <asp:Label ID="lblisnormal" runat="server" Visible="false" ></asp:Label>
                                    </td>
                                    <td width="25%">
                                        <label>
                                            Payment Mode</label>
                                        <asp:DropDownList Width="100%" ID="drpPayment" runat="server" OnSelectedIndexChanged="drppayment_selectedindex"
                                            AutoPostBack="false" CssClass="form-control">
                                            <%-- <asp:ListItem Text="Cash" Value="1" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="Customer Credit" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Compliment" Value="3" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="Card" Value="4" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="Staff Credit" Value="5" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="BBKulam" Value="7" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="ByePass" Value="8" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="KKNagar" Value="9" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="NP" Value="10" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="Bank" Value="11" Enabled="true"></asp:ListItem>
                                            <asp:ListItem Text="Staff Consumption" Value="12" Enabled="true"></asp:ListItem>--%>
                                        </asp:DropDownList>
                                    </td>
                                    
                                </tr>
                                <tr>
                                    <td>
                                        <label>
                                            Mobile Number</label>
                                        <asp:TextBox ID="txtmobile" runat="server" CssClass="form-control" AutoPostBack="true"
                                            MaxLength="10" placeholder="Mobile No" OnTextChanged="txtmobile_TextChanged">    </asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                            FilterType="Numbers,Custom" ValidChars=" -," TargetControlID="txtmobile" />
                                    </td>
                                    <td>
                                        <label>
                                            Customer Name</label>
                                        <asp:TextBox ID="txtCustomerName" runat="server" CssClass="form-control" placeholder="Customer Name"></asp:TextBox>
                                    </td>
                                    <td runat="server" id="Chkbills" visible="false" >
                                        <label>
                                            Order No</label>
                                        <asp:TextBox ID="txtorderno" runat="server" Width="80%" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td runat="server" id="chkgivenby" visible="false">
                                        <label>
                                            Given By</label>
                                        <asp:TextBox ID="txtgiven" runat="server" Width="80%" CssClass="form-control"></asp:TextBox>
                                    </td>
                                    <td id="Td1" runat="server" visible="false">
                                        <label>
                                            Approved</label>
                                        <asp:DropDownList ID="ddlApproved" CssClass="form-control" runat="server" AutoPostBack="true"
                                            OnSelectedIndexChanged="ddlApproved_OnSelectedIndexChanged">
                                            <asp:ListItem Value="Select" Text="Select"></asp:ListItem>
                                            <asp:ListItem Value="Mr Anand " Text="Mr Anand"></asp:ListItem>
                                            <asp:ListItem Value="Mr Navaneethan " Selected="True" Text="Mr Navaneethan"></asp:ListItem>
                                            <asp:ListItem Value="Mr Sudarshan " Text="Mr Sudarshan"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <label>
                                            Amount</label><br />
                                        <label id="lbldisplay" runat="server" style="font-size: x-large; color: Blue">
                                        </label>
                                    </td>
                                </tr>
                                <tr style="display: none">
                                    <td>
                                        <label>
                                            Attender Name</label>
                                        <asp:DropDownList ID="ddattender" runat="server" MaxLength="10" CssClass="form-control">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        <label>
                                            Billed by</label>
                                        <asp:TextBox ID="txtbilled" runat="server" CssClass="form-control" AutoPostBack="true"
                                            MaxLength="10" placeholder="Billed by">    </asp:TextBox>
                                    </td>
                                    <td>
                                        <label>
                                            Cashier Name</label>
                                        <asp:DropDownList ID="ddlCashier" runat="server" MaxLength="10" CssClass="form-control">
                                        </asp:DropDownList>
                                        <label id="lblTax" runat="server" visible="false">
                                        </label>
                                    </td>
                                </tr>
                            </table>
                            <div style="width: 100%; height: 18pc; overflow: scroll">
                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="false" Width="100%"
                                            HeaderStyle-BackColor="Black" HeaderStyle-ForeColor="Wheat" OnRowCommand="gvlist_RowCommand"
                                            OnRowDataBound="gvlist_RowDataBound">
                                            <Columns>
                                                <asp:TemplateField HeaderText="S.No"  ItemStyle-Width="10">
                                                    <ItemTemplate>
                                                        <%--<asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />--%>
                                                        <asp:Label ID="lblRowNumber" Text='<%#Convert.ToInt32(Eval("Sno")) %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" ItemStyle-CssClass="hidden" ItemStyle-Font-Size="Smaller">
                                                    <ItemTemplate>
                                                        <asp:Label ID="categoryid" runat="server" Text='<%#Eval("categoryid") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" ItemStyle-CssClass="hidden" ItemStyle-Font-Size="Smaller">
                                                    <ItemTemplate>
                                                        <asp:Label ID="CategoryUserid" runat="server" Text='<%#Eval("CategoryUserid") %>'
                                                            Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" ItemStyle-CssClass="hidden" ItemStyle-Font-Size="Smaller">
                                                    <ItemTemplate>
                                                        <asp:Label ID="StockID" runat="server" Text='<%#Eval("StockID") %>' Visible="false"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Item" ItemStyle-Font-Size="Smaller">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Definition" runat="server" Width="100%" Text='<%#Eval("Definition") %>'
                                                            Enabled="false"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Stock" ItemStyle-Font-Size="Smaller">
                                                    <ItemTemplate>
                                                        <asp:Label ID="Available_QTY" runat="server" Text='<%#Eval("Available_QTY") %>' Visible="true"></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Qty" ItemStyle-Width="10%" ItemStyle-Font-Size="Smaller">
                                                    <ItemTemplate>
                                                        <asp:Label ID="txttax" Visible="false" runat="server" Text='<%#Eval("TAX") %>'></asp:Label>
                                                        <asp:TextBox ID="txtQty" AutoPostBack="true" Width="100%" Enabled="true" OnTextChanged="txtqty_chnaged" Text='<%#Eval("Qty") %>'
                                                            runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="12%" HeaderText="Rate" ItemStyle-Font-Size="Smaller">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Rate" Width="100%" Text='<%#Eval("Rate") %>' Enabled="false" runat="server"></asp:TextBox>
                                                        <asp:TextBox ID="txtrate" Visible="false" Width="100%" Text='<%#Eval("OriRate") %>'
                                                            Enabled="false" runat="server"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderStyle-Width="15%" HeaderText="Amount" ItemStyle-Font-Size="Smaller">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="Amount" Width="100%" Text='<%#Eval("Amount") %>' Style="text-align: right"
                                                            runat="server" Enabled="false"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgminus" runat="server" CommandName="minus" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                            Height="20px" Width="20px" ImageUrl="~/images/Minus.png" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField>
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="imgdel" runat="server" CommandName="remove" CommandArgument='<%# ((GridViewRow) Container).RowIndex %>'
                                                            Height="20px" Width="20px" ImageUrl="~/images/cancel-circle.png" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                       
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                            </div>
                             <table id="Table1" width="100%" align="right" runat="server" class="table-bordered" style="background-color: White;">
                                         <tr id="trsub" runat="server">
                                        
                                        <td width="50px">
                                        <label>Total Qty</label>
                                        </td>
                                        <td width="50px">
                                        <asp:Label ID="lbltotqty" Font-Bold="true" ForeColor="Red" Font-Size="20px" runat="server" ></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <label>
                                                Item - Total</label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="tr17" runat="server">
                                        <td width="50px">
                                        <label>
                                                CGST:</label>
                                                 <asp:Label ID="lblcgst" runat="server" Width="50px">0</asp:Label>
                                        </td>
                                        <td width="50px">
                                         <label>
                                                SGST:</label>
                                                <asp:Label ID="lblsgst" runat="server" Width="50px">0</asp:Label>
                                        </td>
                                        <td width="50px">
                                         <label>
                                                Tax</label>
                                        </td>
                                       
                                        <td width="30px">
                                           <asp:TextBox ID="txtTax" runat="server" Width="50px">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="tr18" runat="server">
                                      
                                        <td width="50px">
                                        </td>
                                        <td width="50px">
                                        </td>
                                        <td width="50px">
                                           
                                        </td>
                                        <td width="30px">
                                            
                                        </td>
                                    </tr>
                                    <tr id="tr19" runat="server">
                                       
                                        <td width="50px">
                                        </td>
                                        <td width="50px">
                                        </td>
                                        <td width="50px">
                                            <label>
                                                SubTotal</label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lblsubttl" runat="server" Width="50px">0</asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="trdis" runat="server">
                                      
                                        <td colspan="2" width="50px">
                                        <label>Disc. Check</label>
                                        <asp:CheckBox ID="chkdisc" runat="server" OnCheckedChanged="disc_checkedchanged" AutoPostBack="true"  />
                                        <asp:TextBox ID="txtdiscotp" runat="server"  placeholder="Enter OTP" Enabled="false" OnTextChanged="otp_chnaged" AutoPostBack="true" ></asp:TextBox>
                                        </td>
                                        
                                        <td width="50px">
                                            <label>
                                                Disc %</label>
                                            <asp:TextBox ID="txtDiscount" runat="server" AutoPostBack="false" Width="50px" OnTextChanged="txtDiscount_TextChanged">0</asp:TextBox>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lbldisco" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="tradv" runat="server" style="display: none">
                                       
                                        <td width="50px">
                                        </td>
                                        <td width="50px">
                                        </td>
                                        <td width="50px">
                                            <label>
                                                Advance</label>
                                        </td>
                                        <td width="30px">
                                            <asp:TextBox ID="txtAdvance" runat="server" AutoPostBack="true" Width="50px" OnTextChanged="txtAdvance_TextChanged">0</asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="trTax" runat="server" visible="false">
                                       
                                        <td width="50px">
                                        </td>
                                        <td width="50px">
                                        </td>
                                        <td width="50px">
                                           
                                        </td>
                                        <td width="30px">
                                            
                                        </td>
                                    </tr>
                                    <tr id="trTot" runat="server">
                                       
                                        <td width="50px">
                                        </td>
                                        <td width="50px">
                                        </td>
                                        <td width="50px">
                                            <label>
                                                Total</label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lblGrandTotal" runat="server" Width="50px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr id="tr15" runat="server" style="display: none">
                                       
                                        <td width="50px">
                                        </td>
                                        <td width="50px">
                                        </td>
                                        <td width="50px">
                                            <label>
                                                Cash Received</label>
                                        </td>
                                        <td width="30px">
                                            <asp:TextBox ID="txtReceived" runat="server" AutoPostBack="true" AccessKey="c" OnTextChanged="txtReceived_TextChanged"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr id="tr16" runat="server" visible="false">
                                     
                                        <td width="50px">
                                        </td>
                                        <td width="50px">
                                        </td>
                                        <td width="50px">
                                            <label>
                                                Balance</label>
                                        </td>
                                        <td width="30px">
                                            <asp:TextBox ID="txtBal" runat="server"></asp:TextBox>
                                        </td>
                                    </tr>
                                        </table>
                            <table border="0" cellpadding="0" cellspacing="0" class="hidden" style="background-color: White;"
                                id="tblBill" runat="server">
                                <tr style="background-color: #428bca; color: White">
                                    <th width="100px">
                                        Item
                                    </th>
                                    <th width="50px">
                                        Stock
                                    </th>
                                    <th width="50px">
                                        Qty
                                    </th>
                                    <th width="50px">
                                        Rate
                                    </th>
                                    <th width="30px">
                                        Amount
                                    </th>
                                    <th width="20px">
                                        Change
                                    </th>
                                </tr>
                                <tbody>
                                    <tr id="tr" runat="server">
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblCatID1" runat="server"></asp:Label>
                                        </td>
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblItemID1" runat="server"></asp:Label>
                                        </td>
                                        <td id="td2" runat="server" width="20px">
                                            <asp:Label ID="lblItem1" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblAQty1" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:TextBox ID="txtQty1" runat="server" AutoPostBack="true" OnTextChanged="txtQty1_TextChanged"
                                                Width="50px"></asp:TextBox>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblRate1" runat="server"></asp:Label>
                                            <asp:Label ID="lbltaxam1" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lblAmount1" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="btnmin" runat="server" OnClick="btnmin_Click">
                                                <asp:Image ID="imgmin" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                    Height="20px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="btncal" runat="server" OnClick="btncal_Click">
                                                <asp:Image ID="img1" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                    Height="20px" /></asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr id="tr1" runat="server">
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblCatID2" runat="server"></asp:Label>
                                        </td>
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblItemID2" runat="server"></asp:Label>
                                        </td>
                                        <td id="td3" runat="server" width="100px">
                                            <asp:Label ID="lblItem2" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblAQty2" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:TextBox ID="txtQty2" runat="server" AutoPostBack="true" OnTextChanged="txtQty2_TextChanged"
                                                Width="50px"></asp:TextBox>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblRate2" runat="server"></asp:Label><asp:Label ID="lbltaxam2" runat="server"
                                                Visible="false"></asp:Label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lblAmount2" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton10" runat="server" OnClick="LinkButton10_Click">
                                                <asp:Image ID="Image10" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                    Height="20px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">
                                                <asp:Image ID="Image1" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                    Height="20px" /></asp:LinkButton>
                                            <label id="lblTax1" runat="server" visible="false">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr id="tr2" runat="server">
                                        <td visible="false" width="20" class="style1">
                                            <asp:Label ID="lblCatID3" runat="server"></asp:Label>
                                        </td>
                                        <td visible="false" width="20" class="style1">
                                            <asp:Label ID="lblItemID3" runat="server"></asp:Label>
                                        </td>
                                        <td id="td4" runat="server" width="100px" class="style1">
                                            <asp:Label ID="lblItem3" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px" class="style1">
                                            <asp:Label ID="lblAQty3" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px" class="style1">
                                            <asp:TextBox ID="txtQty3" runat="server" AutoPostBack="true" OnTextChanged="txtQty3_TextChanged"
                                                Width="50px"></asp:TextBox>
                                        </td>
                                        <td width="50px" class="style1">
                                            <asp:Label ID="lblRate3" runat="server"></asp:Label><asp:Label ID="lbltaxam3" runat="server"
                                                Visible="false"></asp:Label>
                                        </td>
                                        <td width="30px" class="style1">
                                            <asp:Label ID="lblAmount3" runat="server"></asp:Label>
                                        </td>
                                        <td class="style1">
                                            <asp:LinkButton ID="LinkButton11" runat="server" OnClick="LinkButton11_Click">
                                                <asp:Image ID="Image11" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                    Height="20px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click">
                                                <asp:Image ID="Image2" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                    Height="20px" /></asp:LinkButton>
                                            <label id="lblTax2" runat="server" visible="false">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr id="tr3" runat="server">
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblCatID4" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblItemID4" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td id="td5" runat="server" width="100px">
                                            <asp:Label ID="lblItem4" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblAQty4" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:TextBox ID="txtQty4" runat="server" AutoPostBack="true" OnTextChanged="txtQty4_TextChanged"
                                                Width="50px"></asp:TextBox>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblRate4" runat="server"></asp:Label><asp:Label ID="lbltaxam4" runat="server"
                                                Visible="false"></asp:Label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lblAmount4" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton12" runat="server" OnClick="LinkButton12_Click">
                                                <asp:Image ID="Image12" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                    Height="20px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click">
                                                <asp:Image ID="Image3" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                    Height="20px" /></asp:LinkButton>
                                            <label id="lblTax3" runat="server" visible="false">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr id="tr4" runat="server">
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblCatID5" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblItemID5" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td id="td6" runat="server" width="100px">
                                            <asp:Label ID="lblItem5" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblAQty5" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:TextBox ID="txtQty5" runat="server" AutoPostBack="true" OnTextChanged="txtQty5_TextChanged"
                                                Width="50px"></asp:TextBox>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblRate5" runat="server"></asp:Label><asp:Label ID="lbltaxam5" runat="server"
                                                Visible="false"></asp:Label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lblAmount5" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton13" runat="server" OnClick="LinkButton13_Click">
                                                <asp:Image ID="Image13" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                    Height="20px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click">
                                                <asp:Image ID="Image4" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                    Height="20px" /></asp:LinkButton>
                                            <label id="lblTax4" runat="server" visible="false">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr id="tr5" runat="server">
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblCatID6" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblItemID6" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td id="td7" runat="server" width="100px">
                                            <asp:Label ID="lblItem6" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblAQty6" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:TextBox ID="txtQty6" runat="server" AutoPostBack="true" OnTextChanged="txtQty6_TextChanged"
                                                Width="50px"></asp:TextBox>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblRate6" runat="server"></asp:Label>
                                            <asp:Label ID="lbltaxam6" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lblAmount6" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton14" runat="server" OnClick="LinkButton14_Click">
                                                <asp:Image ID="Image14" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                    Height="20px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click">
                                                <asp:Image ID="Image5" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                    Height="20px" /></asp:LinkButton>
                                            <label id="lblTax5" runat="server" visible="false">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr id="tr6" runat="server">
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblCatID7" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblItemID7" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td id="td8" runat="server" width="100px">
                                            <asp:Label ID="lblItem7" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblAQty7" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:TextBox ID="txtQty7" runat="server" AutoPostBack="true" OnTextChanged="txtQty7_TextChanged"
                                                Width="50px"></asp:TextBox>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblRate7" runat="server"></asp:Label><asp:Label ID="lbltaxam7" runat="server"
                                                Visible="false"></asp:Label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lblAmount7" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton15" runat="server" OnClick="LinkButton15_Click">
                                                <asp:Image ID="Image15" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                    Height="20px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click">
                                                <asp:Image ID="Image6" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                    Height="20px" /></asp:LinkButton>
                                            <label id="lblTax6" runat="server" visible="false">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr id="tr7" runat="server">
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblCatID8" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblItemID8" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td id="td9" runat="server" width="100px">
                                            <asp:Label ID="lblItem8" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblAQty8" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:TextBox ID="txtQty8" runat="server" AutoPostBack="true" OnTextChanged="txtQty8_TextChanged"
                                                Width="50px"></asp:TextBox>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblRate8" runat="server"></asp:Label><asp:Label ID="lbltaxam8" runat="server"
                                                Visible="false"></asp:Label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lblAmount8" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton16" runat="server" OnClick="LinkButton16_Click">
                                                <asp:Image ID="Image16" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                    Height="20px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton7" runat="server" OnClick="LinkButton7_Click">
                                                <asp:Image ID="Image7" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                    Height="20px" /></asp:LinkButton>
                                            <label id="lblTax7" runat="server" visible="false">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr id="tr8" runat="server">
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblCatID9" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblItemID9" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td id="td10" runat="server" width="100px">
                                            <asp:Label ID="lblItem9" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblAQty9" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:TextBox ID="txtQty9" runat="server" AutoPostBack="true" OnTextChanged="txtQty9_TextChanged"
                                                Width="50px"></asp:TextBox>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblRate9" runat="server"></asp:Label><asp:Label ID="lbltaxam9" runat="server"
                                                Visible="false"></asp:Label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lblAmount9" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton17" runat="server" OnClick="LinkButton17_Click">
                                                <asp:Image ID="Image17" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                    Height="20px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton8" runat="server" OnClick="LinkButton8_Click">
                                                <asp:Image ID="Image8" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                    Height="20px" /></asp:LinkButton>
                                            <label id="lblTax8" runat="server" visible="false">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr id="tr9" runat="server">
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblCatID10" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblItemID10" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td id="td11" runat="server" width="100px">
                                            <asp:Label ID="lblItem10" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblAQty10" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:TextBox ID="txtQty10" runat="server" AutoPostBack="true" OnTextChanged="txtQty10_TextChanged"
                                                Width="50px"></asp:TextBox>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblRate10" runat="server"></asp:Label><asp:Label ID="lbltaxam10" runat="server"
                                                Visible="false"></asp:Label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lblAmount10" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton18" runat="server" OnClick="LinkButton18_Click">
                                                <asp:Image ID="Image18" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                    Height="20px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton9" runat="server" OnClick="LinkButton9_Click">
                                                <asp:Image ID="Image9" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                    Height="20px" /></asp:LinkButton>
                                            <label id="lblTax9" runat="server" visible="false">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr id="tr10" runat="server">
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblCatID11" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblItemID11" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td id="td12" runat="server" width="100px">
                                            <asp:Label ID="lblItem11" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblAQty11" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:TextBox ID="txtQty11" runat="server" AutoPostBack="true" OnTextChanged="txtQty11_TextChanged"
                                                Width="50px"></asp:TextBox>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblRate11" runat="server"></asp:Label><asp:Label ID="lbltaxam11" runat="server"
                                                Visible="false"></asp:Label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lblAmount11" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton19" runat="server" OnClick="LinkButton19_Click">
                                                <asp:Image ID="Image19" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                    Height="20px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton20" runat="server" OnClick="LinkButton20_Click">
                                                <asp:Image ID="Image20" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                    Height="20px" /></asp:LinkButton>
                                            <label id="lblTax10" runat="server" visible="false">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr id="tr11" runat="server">
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblCatID12" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblItemID12" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td id="td13" runat="server" width="100px">
                                            <asp:Label ID="lblItem12" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblAQty12" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:TextBox ID="txtQty12" runat="server" AutoPostBack="true" OnTextChanged="txtQty12_TextChanged"
                                                Width="50px"></asp:TextBox>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblRate12" runat="server"></asp:Label><asp:Label ID="lbltaxam12" runat="server"
                                                Visible="false"></asp:Label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lblAmount12" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton21" runat="server" OnClick="LinkButton21_Click">
                                                <asp:Image ID="Image21" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                    Height="20px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton22" runat="server" OnClick="LinkButton22_Click">
                                                <asp:Image ID="Image22" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                    Height="20px" /></asp:LinkButton>
                                            <label id="lblTax11" runat="server" visible="false">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr id="tr12" runat="server">
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblCatID13" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblItemID13" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td id="td14" runat="server" width="100px">
                                            <asp:Label ID="lblItem13" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblAQty13" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:TextBox ID="txtQty13" runat="server" AutoPostBack="true" OnTextChanged="txtQty13_TextChanged"
                                                Width="50px"></asp:TextBox>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblRate13" runat="server"></asp:Label><asp:Label ID="lbltaxam13" runat="server"
                                                Visible="false"></asp:Label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lblAmount13" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton23" runat="server" OnClick="LinkButton23_Click">
                                                <asp:Image ID="Image23" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                    Height="20px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton24" runat="server" OnClick="LinkButton24_Click">
                                                <asp:Image ID="Image24" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                    Height="20px" /></asp:LinkButton>
                                            <label id="lblTax12" runat="server" visible="false">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr id="tr13" runat="server">
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblCatID14" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblItemID14" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td id="td15" runat="server" width="100px">
                                            <asp:Label ID="lblItem14" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblAQty14" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:TextBox ID="txtQty14" runat="server" AutoPostBack="true" OnTextChanged="txtQty14_TextChanged"
                                                Width="50px"></asp:TextBox>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblRate14" runat="server"></asp:Label><asp:Label ID="lbltaxam14" runat="server"
                                                Visible="false"></asp:Label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lblAmount14" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton25" runat="server" OnClick="LinkButton25_Click">
                                                <asp:Image ID="Image25" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                    Height="20px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton26" runat="server" OnClick="LinkButton26_Click">
                                                <asp:Image ID="Image26" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                    Height="20px" /></asp:LinkButton>
                                            <label id="lblTax13" runat="server" visible="false">
                                            </label>
                                        </td>
                                    </tr>
                                    <tr id="tr14" runat="server">
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblCatID15" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td visible="false" width="20">
                                            <asp:Label ID="lblItemID15" runat="server" Visible="false"></asp:Label>
                                        </td>
                                        <td id="td16" runat="server" width="100px">
                                            <asp:Label ID="lblItem15" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblAQty15" runat="server"></asp:Label>
                                        </td>
                                        <td width="50px">
                                            <asp:TextBox ID="txtQty15" runat="server" AutoPostBack="true" OnTextChanged="txtQty15_TextChanged"
                                                Width="50px"></asp:TextBox>
                                        </td>
                                        <td width="50px">
                                            <asp:Label ID="lblRate15" runat="server"></asp:Label><asp:Label ID="lbltaxam15" runat="server"
                                                Visible="false"></asp:Label>
                                        </td>
                                        <td width="30px">
                                            <asp:Label ID="lblAmount15" runat="server"></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="LinkButton27" runat="server" OnClick="LinkButton27_Click">
                                                <asp:Image ID="Image27" runat="server" Width="20px" ImageUrl="~/images/Minus.png"
                                                    Height="20px" />
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="LinkButton28" runat="server" OnClick="LinkButton28_Click">
                                                <asp:Image ID="Image28" runat="server" ImageUrl="~/images/cancel-circle.png" Width="20px"
                                                    Height="20px" /></asp:LinkButton>
                                            <label id="lblTax14" runat="server" visible="false">
                                            </label>
                                        </td>
                                    </tr>


                                   
                                </tbody>
                            </table>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Button ID="btnPrint" runat="server" CssClass="btn btn-success" Width="100px"
                                            UseSubmitBehavior="false" OnClientClick="this.disabled=true;" OnClick="btnPrint_Click"
                                            Text="Print" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnReset" runat="server" CssClass="btn btn-warning " Width="100px"
                                            Text="Reset" OnClick="btnReset_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="btnCancel" runat="server" CssClass="btn btn-danger" Width="100px"
                                            Text="Cancel" OnClick="btnCancel_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Button5" runat="server" CssClass="btn btn-primary" Width="120px" Visible="true"
                                            Text="Hold Bill" OnClick="btnhold_check" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Button4" runat="server" CssClass="btn btn-info" Width="120px" Text="Smry.Bills"
                                            PostBackUrl="~/Accountsbootstrap/Home_Page.aspx" />
                                    </td>
                                </tr>
                            </table>
                            <table>
                                <tr>
                                    <td valign="top" style="width: 15%">
                                        <label>
                                            Hold Bill's</label>
                                        <asp:DataList ID="Holdbill" runat="server" CssClass="SlidingBox" Height="100px" ScrollBars="auto"
                                            RepeatColumns="5" RepeatDirection="Horizontal" RepeatLayout="Table" Width="50%">
                                            <ItemTemplate>
                                                <asp:Button ID="Button1" runat="server" Font-Bold="true" Height="40px" Width="10pc"
                                                    Text='<%#Eval("BillNo")+"-"+ Eval("SalesTypeOrderNo")%>' CommandArgument='<%#Eval("TempSalesID") %>' BackColor="#428bca"
                                                    ForeColor="White" OnClick="Button1hold_Click" />
                                                <br />
                                                <asp:ImageButton ID="btndelete" runat="server" Font-Bold="true" Height="30px" Width="30px"
                                                    CommandArgument='<%#Eval("TempSalesID") %>' ImageAlign="Middle" ImageUrl="~/images/cancel-circle.png"
                                                    OnClick="btncncl_click" />
                                                <asp:Image ID="dlt" runat="server" ImageUrl="~/images/cancel-circle.png" Visible="false" />
                                                <asp:Image ID="Image1" runat="server" ImageAlign="Middle" ImageUrl="~/images/cancel.png"
                                                    Visible="false" />
                                                <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                    CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btndelete"
                                                    PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                                </ajaxToolkit:ModalPopupExtender>
                                                <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                    TargetControlID="btndelete" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                                </ajaxToolkit:ConfirmButtonExtender>
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                            </table>
                            </td>
                            </tr>
                            </table>
                           
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdateProgress ID="prgLoadingStatus" runat="server" DynamicLayout="true">
            <ProgressTemplate>
                <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                    right: 0; left: 0; z-index: 9999999; opacity: 0.7;">
                    <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="../images/Preloader_10.gif"
                        AlternateText="Loading  Please wait..." ToolTip="Loading  Please wait..." Style="padding: 10px;
                        position: fixed; top: 45%; left: 50%;" />
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
    </div>
    <asp:Panel Width="30%" class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none;
        background: #fffbd6" runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div align="center" style="color: Red" class="TitlebarLeft">
                    Warning Message!!!</div>
                <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                </div>
            </div>
            <div align="center" style="color: Red" class="popup_Body">
                <asp:TextBox ID="txtRef" runat="server" placeholder="Enter Hold No"></asp:TextBox>
                <asp:DropDownList ID="dlReason" runat="server">
                    <asp:ListItem Text="select"></asp:ListItem>
                    <asp:ListItem Text="Change Product"></asp:ListItem>
                    <asp:ListItem Text="Quantity Change"></asp:ListItem>
                </asp:DropDownList>
                <br />
                <asp:TextBox ID="txtreasontext" runat="server" TextMode="MultiLine" placeholder="Enter Reason Please!!!"></asp:TextBox>
                <p>
                    Are you sure want to Cancel this Bill?
                </p>
            </div>
            <div align="center" class="popup_Buttons">
                <input id="ButtonDeleleOkay" type="button" value="Yes" />
                <input id="ButtonDeleteCancel" type="button" value="No" />
            </div>
        </div>
    </asp:Panel>
    </form>
</body>
</html>

