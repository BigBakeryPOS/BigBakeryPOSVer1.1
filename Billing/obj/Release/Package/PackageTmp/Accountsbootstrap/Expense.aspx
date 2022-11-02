<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Expense.aspx.cs" Inherits="Billing.Accountsbootstrap.Expense" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Expense</title>
    <script type="text/javascript">
        function visible() {
            radio = document.getElementById('orderno');
            radio.style.visibility = 'visible';
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
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <script type="text/javascript" src="../jqueryCalendar/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../jqueryCalendar/jquery-ui-1.8.15.custom.min.js"></script>
    <link rel="stylesheet" href="../jqueryCalendar/jqueryCalendar.css" />
    <link rel="Stylesheet" type="text/css" href="../Styles/date.css" />
    <link rel="Stylesheet" type="text/css" href="../Styles/style1.css" />
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
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <div class="row">
        <div class="col-lg-12">
            <h1 class="page-header">
            </h1>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-heading " style="background-color: #428bca; color: White">
                    <b>Payment Entry</b></div>
                <div class="panel-body">
                    <div class="row">
                        <form id="Form1" runat="server">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:ScriptManager ID="scriptmanager" runat="server">
                                </asp:ScriptManager>
                                <div class="col-lg-3">
                                    <div class="form-group">
                                        <label>
                                            Date</label>
                                        <asp:TextBox CssClass="form-control" ID="txtdate" Text="--Select Date--" runat="server"></asp:TextBox>
                                        <asp:Label ID="lbldateError" runat="server" ForeColor="Red"></asp:Label>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="dd/MM/yyyy" TargetControlID="txtdate"
                                            runat="server" CssClass="cal_Theme1">
                                        </ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Account Name</label>
                                        <asp:DropDownList ID="ddlLedger" CssClass="form-control" Width="100%" runat="server">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Description(Any)</label>
                                        <asp:TextBox CssClass="form-control" ID="txtdescrip" runat="server">
                                        </asp:TextBox>
                                    </div>
                                    <div class="form-group">
                                        <label>
                                            Amount</label>
                                        <asp:TextBox CssClass="form-control" ID="txtamount" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="please enter Amount" ValidationGroup="val1"
                                            ForeColor="Red" ControlToValidate="txtamount"></asp:RequiredFieldValidator>
                                    </div>
                                    <div class="form-group" id="orderno" runat="server" visible="false">
                                        <label>
                                            Order Form No</label>
                                        <asp:TextBox CssClass="form-control" ID="txtNo" runat="server" placeholder="Enter Orderform No"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="please enter Orderform No"
                                            ForeColor="Red" ControlToValidate="txtNo"></asp:RequiredFieldValidator>
                                        <label>
                                            Pay Mode</label>
                                        <asp:DropDownList ID="ddPaymode" runat="server" CssClass="form-control">
                                            <asp:ListItem Value="Cash"></asp:ListItem>
                                            <asp:ListItem Value="card"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="form-group">
                                        <asp:Button ID="btnsave" runat="server" OnClientClick="ClientSideClick(this)" UseSubmitBehavior="false" ValidationGroup="val1"
                                            class="btn btn-success" Text="Save" OnClick="btnsave_Click" />
                                        <asp:Button ID="Button1" runat="server" class="btn btn-warning" Text="Exit" OnClick="btnexit_Click" />
                                        <asp:RadioButton ID="order" runat="server" Text="Order" Visible="false" AutoPostBack="true"
                                            OnCheckedChanged="order_CheckedChanged" />
                                    </div>
                                </div>
                                <!-- /.col-lg-6 (nested) -->
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </form>
                        <!-- /.col-lg-6 (nested) -->
                        <!-- /.col-lg-6 (nested) -->
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->
    <!-- /#page-wrapper -->
    <!-- jQuery -->
</body>
</html>
