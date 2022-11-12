<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Purchase.aspx.cs" Inherits="Billing.Accountsbootstrap.Purchase" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<html lang="en">
<head id="Head1" runat="server">
    <script language="javascript" type="text/javascript">

        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
                event.returnValue = true;
            else

                event.returnValue = false;
        }

    </script>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>PO Form</title>
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
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <form runat="server" id="form1" method="post">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-lg-12">
                    <div class="panel panel-default">
                        <div class="panel-body">
                            <div class="row">
                                <div class="col-lg-12" style="margin-top: 50px;">
                                    <div class="form-group" style="text-align: center;">
                                        <h2>
                                            Blaack Forest</h2>
                                        <%--<h2> <asp:Label ID="lblcompanyname" runat="server"></asp:Label> </h2><br />
                                            <b><asp:Label ID="lblarea" runat="server"></asp:Label><br />--%>
                                        A.KARTHIKA MARTS ( Bakery Division)<br />
                                        2/232, MALLIGAI CROSS STREET,<br />
                                        GOMATHIPURAM II ROAD,<br />
                                        MADURAI-625020,,<br />
                                        TAMILNADU STATE, INDIA.,<br />
                                        </b>
                                    </div>
                                    <div class="form-group" style="text-align: center;">
                                        <h2>
                                            Purchase order
                                        </h2>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-lg-12">
                                        <div class="panel-body">
                                            <div class="table-responsive">
                                                <table class="table table-striped table-bordered table-hover">
                                                    <tr>
                                                        <td valign="top">
                                                            <div class="row">
                                                                <div class="col-lg-12">
                                                                    <div class="form-group">
                                                                        <asp:Label runat="server" ID="Label1">Vendor Name </asp:Label>
                                                                        <asp:DropDownList runat="server" ID="ddlvendor" class="form-control" AutoPostBack="true"
                                                                            OnSelectedIndexChanged="ddlcustomerID_SelectedIndexChanged">
                                                                        </asp:DropDownList>
                                                                        <asp:TextBox ID="txtSupplied" runat="server" CssClass="form-control" TextMode="MultiLine"
                                                                            Height="150px"></asp:TextBox>
                                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ValidationGroup="val1"
                                                                            ControlToValidate="txtSupplied" Style="color: Red" ErrorMessage="Enter Address"></asp:RequiredFieldValidator>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <td style="padding-top: 35px">
                                                            <div class="row">
                                                                <div class="col-lg-12">
                                                                    <div class="form-group">
                                                                        <asp:Label runat="server" ID="lblDcNo">DC No.</asp:Label>
                                                                        <asp:TextBox ID="txtDCNo" runat="server" CssClass="form-control" onkeypress="return NumberOnly()"></asp:TextBox>
                                                                        <asp:TextBox ID="txtcompanyname" Visible="false" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <asp:Label runat="server" ID="lblDCDate">DC Date</asp:Label>
                                                                        <asp:TextBox ID="txtDCDate" runat="server" CssClass="form-control"></asp:TextBox>
                                                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtDCDate"
                                                                            runat="server" CssClass="cal_Theme1">
                                                                        </ajaxToolkit:CalendarExtender>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </td>
                                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                                        </asp:ScriptManager>
                                                        <td style="padding-top: 35px">
                                                            <div class="col-lg-6">
                                                                <asp:Label runat="server" ID="Label3">No. </asp:Label>
                                                                <asp:TextBox ID="txtpono" CssClass="form-control" runat="server"></asp:TextBox>
                                                                <br />
                                                                <asp:Label runat="server" ID="Label4">Bill Date</asp:Label>
                                                                <asp:TextBox CssClass="form-control" ID="txtpodate" runat="server" Text="--Select Date--"></asp:TextBox>
                                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtpodate"
                                                                    runat="server" CssClass="cal_Theme1">
                                                                </ajaxToolkit:CalendarExtender>
                                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="val1"
                                                                    ControlToValidate="txtpodate" Style="color: Red" ErrorMessage="Enter PO Date"></asp:RequiredFieldValidator><br />
                                                            </div>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12">
                                <div class="panel-body">
                                    <div class="table-responsive">
                                        <asp:Label ID="lblError" runat="server" Style="color: Red"></asp:Label>
                                        <table class="table table-striped table-bordered table-hover" id="dataTables-example">
                                            <thead>
                                                <tr>
                                                    <th>
                                                        Category
                                                    </th>
                                                    <th>
                                                        Item
                                                    </th>
                                                    <th>
                                                        Serial No
                                                    </th>
                                                    <th>
                                                        Qty
                                                    </th>
                                                    <th>
                                                        Rate
                                                    </th>
                                                    <th id="dischead" runat="server">
                                                        Disc
                                                    </th>
                                                    <th>
                                                        Amount
                                                    </th>
                                                    <th>
                                                    </th>
                                                    <th>
                                                        Cancel
                                                    </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr class="odd gradeX">
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlcategory" class="form-control" TabIndex="1"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddldef" CssClass="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddldef_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlSno" CssClass="form-control" TabIndex="2">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <%--<td><asp:TextBox CssClass="form-control" ID="txtdef" runat="server"></asp:TextBox></td>--%>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" ID="txtqty" TabIndex="3" Width="100px" Style="text-align: right"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ControlToValidate="txtqty"
                                                        runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                                    <td class="center">
                                                        <asp:TextBox MaxLength="4" TabIndex="5" CssClass="form-control" ID="txtrate" runat="server"
                                                            Width="100px " OnTextChanged="txtrate_TextChanged1" AutoPostBack="True" Style="text-align: right">0</asp:TextBox>
                                                    </td>
                                                    <td id="disc" runat="server">
                                                        <asp:TextBox ID="txtdisc" Visible="false" runat="server" CssClass="form-control"
                                                            AutoPostBack="true" TabIndex="6" Width="100px " OnTextChanged="txtdisc_TextChanged">0</asp:TextBox>
                                                    </td>
                                                    <td class="center">
                                                        <asp:TextBox CssClass="form-control" Style="text-align: right" TabIndex="8" ID="txtamount"
                                                            runat="server" AutoPostBack="True" ReadOnly="true"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtdamt" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTamt" runat="server" CssClass="form-control" Visible="false">0</asp:TextBox>
                                                        <asp:DropDownList Visible="false" ID="ddlunits" runat="server" TabIndex="4" CssClass="form-control">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList Visible="false" ID="ddTax" runat="server" CssClass="form-control"
                                                            AutoPostBack="true" TabIndex="7" OnSelectedIndexChanged="ddtax_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                </tr>
                                            </tbody>
                                            <tbody>
                                                <tr class="odd gradeX">
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlcategory1" class="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlcategory1_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddldef1" AutoPostBack="true" CssClass="form-control"
                                                            OnSelectedIndexChanged="ddldef1_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlSNo1" CssClass="form-control" TabIndex="2">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <%--<td><asp:TextBox CssClass="form-control" ID="ddldef1" runat="server"></asp:TextBox></td>--%>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" ID="txtqty1" Width="100px " Style="text-align: right"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" ControlToValidate="txtqty1"
                                                        runat="server" ErrorMessage="Only Numbers allowed" ValidationExpression="\d+"></asp:RegularExpressionValidator>
                                                    <td class="center">
                                                        <asp:TextBox MaxLength="4" CssClass="form-control" ID="txtrate1" Style="text-align: right"
                                                            runat="server" OnTextChanged="txtrate_TextChanged2" Width="100px " AutoPostBack="True">0</asp:TextBox>
                                                    </td>
                                                    <td id="disc1" runat="server">
                                                        <asp:TextBox ID="txtdisc1" Visible="false" runat="server" CssClass="form-control"
                                                            Width="100px " AutoPostBack="true" OnTextChanged="txtdisc1_TextChanged">0</asp:TextBox>
                                                    </td>
                                                    <td class="center">
                                                        <asp:TextBox CssClass="form-control" ID="txtamount1" Style="text-align: right" runat="server"
                                                            Enabled="false" AutoPostBack="true"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtdamt1" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTamt1" runat="server" CssClass="form-control" Visible="false">0</asp:TextBox>
                                                        <asp:DropDownList ID="ddlunits1" runat="server" Visible="false" CssClass="form-control">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="ddTax1" runat="server" CssClass="form-control" Visible="false"
                                                            AutoPostBack="true" OnSelectedIndexChanged="ddTax1_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/cancel-circle.png"
                                                            OnClick="ImageButton1_Click" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                            <tbody>
                                                <tr class="odd gradeX">
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlcategory2" class="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlcategory2_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" AutoPostBack="true" ID="ddldef2" CssClass="form-control"
                                                            OnSelectedIndexChanged="ddldef2_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlSno2" CssClass="form-control" TabIndex="2">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" ID="txtqty2" Width="100px " Style="text-align: right"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="center">
                                                        <asp:TextBox MaxLength="4" CssClass="form-control" Style="text-align: right" ID="txtrate2"
                                                            runat="server" OnTextChanged="txtrate_TextChanged3" Width="100px " AutoPostBack="True">0</asp:TextBox>
                                                    </td>
                                                    <td id="disc2" runat="server">
                                                        <asp:TextBox ID="txtdisc2" runat="server" CssClass="form-control" Width="100px "
                                                            AutoPostBack="true" Visible="false" OnTextChanged="txtdisc2_TextChanged">0</asp:TextBox>
                                                    </td>
                                                    <td class="center">
                                                        <asp:TextBox CssClass="form-control" Style="text-align: right" ID="txtamount2" runat="server"
                                                            Enabled="false" AutoPostBack="true"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtdamt2" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTamt2" runat="server" CssClass="form-control" Visible="false">0</asp:TextBox>
                                                        <asp:DropDownList ID="ddTax2" AutoPostBack="true" runat="server" Visible="false"
                                                            CssClass="form-control" OnSelectedIndexChanged="ddTax2_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="ddlunits2" runat="server" CssClass="form-control" Visible="false">
                                                        </asp:DropDownList>
                                                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/cancel-circle.png"
                                                            OnClick="ImageButton2_Click" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                            <tbody>
                                                <tr class="odd gradeX">
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlcategory3" class="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlcategory3_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList AutoPostBack="true" runat="server" ID="ddldef3" CssClass="form-control"
                                                            OnSelectedIndexChanged="ddldef3_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlSno3" CssClass="form-control" TabIndex="2">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" ID="txtqty3" Width="100px " Style="text-align: right"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="center">
                                                        <asp:TextBox CssClass="form-control" ID="txtrate3" MaxLength="4" Style="text-align: right"
                                                            runat="server" OnTextChanged="txtrate_TextChanged4" Width="100px " AutoPostBack="True">0</asp:TextBox>
                                                    </td>
                                                    <td id="disc3" runat="server">
                                                        <asp:TextBox ID="txtdisc3" runat="server" CssClass="form-control" Width="100px "
                                                            AutoPostBack="true" Visible="false" OnTextChanged="txtdisc3_TextChanged">0</asp:TextBox>
                                                    </td>
                                                    <td class="center">
                                                        <asp:TextBox CssClass="form-control" ID="txtamount3" Style="text-align: right" runat="server"
                                                            Enabled="false" AutoPostBack="true"></asp:TextBox>
                                                        <td>
                                                            <asp:TextBox ID="txtdamt3" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                                        </td>
                                                        <td>
                                                            <asp:TextBox ID="txtTamt3" runat="server" CssClass="form-control" Visible="false">0</asp:TextBox>
                                                            <asp:DropDownList ID="ddlunits3" runat="server" Visible="false" CssClass="form-control">
                                                            </asp:DropDownList>
                                                            <asp:DropDownList ID="ddTax3" runat="server" AutoPostBack="true" Visible="false"
                                                                CssClass="form-control" OnSelectedIndexChanged="ddTax3_SelectedIndexChanged">
                                                            </asp:DropDownList>
                                                            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/cancel-circle.png"
                                                                OnClick="ImageButton3_Click" />
                                                        </td>
                                                </tr>
                                            </tbody>
                                            <tbody>
                                                <tr class="odd gradeX">
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlcategory4" class="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlcategory4_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" AutoPostBack="true" ID="ddldef4" CssClass="form-control"
                                                            OnSelectedIndexChanged="ddldef4_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlSno4" CssClass="form-control" TabIndex="2">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" ID="txtqty4" Width="100px " Style="text-align: right"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="center">
                                                        <asp:TextBox CssClass="form-control" ID="txtrate4" MaxLength="4" Style="text-align: right"
                                                            runat="server" OnTextChanged="txtrate_TextChanged5" Width="100px " AutoPostBack="True">0</asp:TextBox>
                                                    </td>
                                                    <td id="disc4" runat="server">
                                                        <asp:TextBox ID="txtdisc4" runat="server" CssClass="form-control" Width="100px "
                                                            AutoPostBack="true" Visible="false" OnTextChanged="txtdisc4_TextChanged">0</asp:TextBox>
                                                    </td>
                                                    <td class="center">
                                                        <asp:TextBox CssClass="form-control" ID="txtamount4" Style="text-align: right" runat="server"
                                                            Enabled="false" AutoPostBack="true"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtdamt4" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTamt4" runat="server" CssClass="form-control" Visible="false">0</asp:TextBox>
                                                        <asp:DropDownList ID="ddTax4" runat="server" AutoPostBack="true" Visible="false"
                                                            CssClass="form-control" OnSelectedIndexChanged="ddTax4_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="ddlunits4" runat="server" Visible="false" CssClass="form-control">
                                                        </asp:DropDownList>
                                                        <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/images/cancel-circle.png"
                                                            OnClick="ImageButton4_Click" />
                                                    </td>
                                                </tr>
                                            </tbody>
                                            <tbody>
                                                <tr class="odd gradeX">
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlcategory5" class="form-control" AutoPostBack="true"
                                                            OnSelectedIndexChanged="ddlcategory5_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" AutoPostBack="true" ID="ddldef5" CssClass="form-control"
                                                            OnSelectedIndexChanged="ddldef5_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList runat="server" ID="ddlSno5" CssClass="form-control" TabIndex="2">
                                                        </asp:DropDownList>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox CssClass="form-control" ID="txtqty5" Width="100px " Style="text-align: right"
                                                            runat="server"></asp:TextBox>
                                                    </td>
                                                    <td class="center">
                                                        <asp:TextBox CssClass="form-control" ID="txtrate5" MaxLength="4" Style="text-align: right"
                                                            runat="server" Width="100px " OnTextChanged="txtrate_TextChanged6" AutoPostBack="True">0</asp:TextBox>
                                                    </td>
                                                    <td id="disc5" runat="server">
                                                        <asp:TextBox ID="txtdisc5" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            Width="100px " Visible="false" OnTextChanged="txtdisc5_TextChanged">0</asp:TextBox>
                                                    </td>
                                                    <td class="center">
                                                        <asp:TextBox CssClass="form-control" ID="txtamount5" Style="text-align: right" runat="server"
                                                            Enabled="false" AutoPostBack="true"></asp:TextBox>
                                                        <asp:DropDownList ID="ddlunits5" runat="server" Visible="false" CssClass="form-control">
                                                        </asp:DropDownList>
                                                        <asp:DropDownList ID="ddTax5" runat="server" CssClass="form-control" AutoPostBack="true"
                                                            Visible="false" OnSelectedIndexChanged="ddTax5_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                        <label style="margin-top: 11px;">
                                                            Sub-Total</label>
                                                        <asp:TextBox CssClass="form-control" ID="txttotal" runat="server" Enabled="false"
                                                            Style="width: 110px; margin-left: 135px; margin-top: -29px; text-align: right">0</asp:TextBox>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <label style="margin-top: 18px;">
                                                                        Disc
                                                                    </label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox CssClass="form-control" ID="txtdiscount" runat="server" Style="width: 110px;
                                                                        margin-left: 85px; margin-top: 11px; text-align: right">0</asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <label style="margin-top: 14px;">
                                                                        Tax(Amount)</label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox CssClass="form-control" ID="txtTaxamt5" runat="server" Style="width: 110px;
                                                                        margin-left: 43px; margin-top: 17px; text-align: right">0</asp:TextBox>
                                                                    <%--<asp:Label ID="lblTax" runat="server"></asp:Label>--%>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <table>
                                                            <tr id="tax14" runat="server">
                                                                <td>
                                                                    <label style="margin-top: 14px;">
                                                                        VAT Input 14.5 %</label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox CssClass="form-control" ID="txtTaxamt14" Enabled="false" runat="server"
                                                                        Style="width: 110px; margin-left: 43px; margin-top: 17px; text-align: right">0</asp:TextBox>
                                                                    <%--<asp:Label ID="lblTax" runat="server"></asp:Label>--%>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <label>
                                                                        CST</label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtCst" runat="server" CssClass="form-control" Style="width: 110px;
                                                                        margin-left: 50px; margin-top: 17px; text-align: right">0</asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <label>
                                                                        Excise Duty</label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txtExcisr" runat="server" CssClass="form-control" Style="width: 110px;
                                                                        margin-left: 50px; margin-top: 17px; text-align: right">0</asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                        <label style="margin-top: 22px;">
                                                            Grand Total</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtgrandtotal" runat="server" Style="width: 110px;
                                                            margin-left: 145px; margin-top: -29px; text-align: right"></asp:TextBox>
                                                        <asp:Button ID="btncalc" runat="server" Text="Calc" CssClass="btn btn-success" Style="width: 45px;
                                                            margin-left: 10px; margin-top: -4px;" OnClick="btncalc_Click" />
                                                        <asp:RequiredFieldValidator ID="txtgt" ValidationGroup="val1" ControlToValidate="txtgrandtotal"
                                                            ErrorMessage="Please calculate your Grand Total" runat="server"></asp:RequiredFieldValidator>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtdamt5" runat="server" CssClass="form-control" Visible="false"></asp:TextBox>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="txtTamt5" runat="server" CssClass="form-control" Visible="false">0</asp:TextBox>
                                                        <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/images/cancel-circle.png"
                                                            OnClick="ImageButton5_Click" />
                                                    </td>
                                                </tr>
                                                <tr align="center">
                                                    <td>
                                                        <asp:LinkButton ID="New" runat="server" Text="New Item" ForeColor="Chocolate " AccessKey="N"
                                                            OnClientClick="return myFunction()"></asp:LinkButton>(Press Alt+N)
                                                    </td>
                                                </tr>
                                            </tbody>
                                        </table>
                                        </td> </tr> </tbody>
                                    </div>
                                    <asp:Button ID="btnadd" Text="Save" runat="server" class="btn btn-success" ValidationGroup="val1"
                                        OnClick="Add_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="panel-body">
                                <div class="table-responsive">
                                    <table class="table table-striped table-bordered table-hover">
                                    </table>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.col-lg-6 (nested) -->
                </div>
                <!-- /.row (nested) -->
            </div>
            <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
            </div>
            <!-- /.col-lg-12 -->
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
