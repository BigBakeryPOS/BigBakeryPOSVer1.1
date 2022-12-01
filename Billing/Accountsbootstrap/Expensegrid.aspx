<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Expensegrid.aspx.cs" Inherits="Billing.Accountsbootstrap.Expensegrid" EnableEventValidation="false" ValidateRequest="false" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1">

    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById('<%= gridledger.ClientID %>');
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');
            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="size:landscape">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');
            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
    </script>

    <title>Expense Grid</title>
    <link href="css/mGrid.css" rel="Stylesheet" type="text/css" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />

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
    <script type="text/javascript" src="../jqueryCalendar/jquery-1.6.2.min.js"></script>
    <script type="text/javascript" src="../jqueryCalendar/jquery-ui-1.8.15.custom.min.js"></script>
    <link rel="stylesheet" href="../jqueryCalendar/jqueryCalendar.css" />


    <link rel="Stylesheet" type="text/css" href="../Styles/style1.css" />




    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <link href="../images/fav.ico" type="image/x-icon" rel="Shortcut Icon" />

    <script type="text/javascript">

          function alertorder() {
              alert('Are You Sure, You want to cancel This Customer sales!');
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
</head>
<body>
    <form runat="server" id="form1" method="post">
        <usc:Header ID="Header" runat="server" />
        <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
        <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
        <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-8">
                    <div class="row">
                        <div class="row panel-custom1">
                            <div class="panel-header">
                                <h1 class="page-header">Expense Details
           <span class="pull-right" style="display: none">
               <asp:LinkButton ID="btnadd1" runat="server" OnClick="btnadd_Click">
             <button type="button" class="btn btn-primary btn-md pos-btn1">
				<span class="glyphicon glyphicon-plus" aria-hidden="true"></span> ADD
			</button>
               </asp:LinkButton>
           </span>
                                </h1>
                            </div>
                            <div class="panel-body">
                                <div class="row">

                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>


                                    <asp:DropDownList ID="ddlsearch" CssClass="form-control" Visible="false"
                                        runat="server" Width="237px">
                                    </asp:DropDownList>
                                    <div class="col-lg-3">
                                        <label>From :</label>
                                        <asp:TextBox ID="txtFrom" runat="server" CssClass="form-control" Text="--Select Date--"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtFrom" runat="server"
                                            CssClass="cal_Theme1">
                                        </ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="col-lg-3">
                                        <label>To :</label>
                                        <asp:TextBox ID="txtTo" runat="server" CssClass="form-control" Text="--Select Date--"></asp:TextBox>
                                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txtTo" runat="server"
                                            CssClass="cal_Theme1">
                                        </ajaxToolkit:CalendarExtender>
                                    </div>
                                    <div class="col-lg-6">
                                        <br />
                                        <asp:Button ID="btnsearch" runat="server" class="btn btn-info pos-btn1" Text="Search"
                                            OnClick="btnsearch_Click" />



                                        <asp:Button ID="btnPrint" runat="server" class="btn btn-success" Visible="false" Text="Print"
                                            Style="margin-top: 10px;" OnClientClick=" printGrid();" />

                                        &nbsp;&nbsp;&nbsp;<asp:Button ID="btnexportexcel" runat="server" class="btn  btn-success" Text="Export-Excel" OnClick="btnExport_Click" />

                                    </div>

                                    <div class="col-lg-12">

                                        <div runat="server" id="div2" class="table-responsive panel-grid-left">

                                            <asp:GridView ID="gridledger" runat="server" AllowPaging="false" PageSize="50"
                                                AutoGenerateColumns="false" CssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                                OnRowCommand="gridledger_RowCommand">
                                                <%-- <HeaderStyle BackColor="#3366FF" />
                                <PagerSettings FirstPageText="1"  Mode="Numeric"  />--%>
                                                <Columns>

                                                    <asp:BoundField HeaderText="Payment Entry ID" DataField="PaymentEntryID" />
                                                    <asp:BoundField HeaderText="Date" DataField="Date" DataFormatString='{0:dd-MMM-yyyy}' />
                                                    <asp:BoundField HeaderText="Ledger Name" DataField="LedgerName" />
                                                    <asp:BoundField HeaderText="Description" DataField="Description" />
                                                    <asp:BoundField HeaderText="Amount" DataField="Amount" DataFormatString="{0:###,##0.00}" />
                                                     
                                                    <asp:TemplateField HeaderText="Delete">
                                                        <ItemTemplate>
                                                            <asp:LinkButton ID="lnkbtn" runat="server" CommandName="Del" CommandArgument='<%#Eval("PaymentEntryID") %>'>
                                                                <asp:Image ID="imgdel" runat="server" ImageUrl="~/images/delete.png" Visible="false" />
                                                                <button type="button" class="btn btn-danger btn-md">
                                                                    <span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
                                                                </button>
                                                            </asp:LinkButton>
                                                            <%-- <ajaxToolkit:modalpopupextender   
		id="lnkDelete_ModalPopupExtender" runat="server" 
		cancelcontrolid="ButtonDeleteCancel" okcontrolid="ButtonDeleleOkay" 
		targetcontrolid="lnkbtn"  popupcontrolid="DivDeleteConfirmation" 
		backgroundcssclass="ModalPopupBG">
        </ajaxToolkit:modalpopupextender>
        <ajaxToolkit:ConfirmButtonExtender id="lnkDelete_ConfirmButtonExtender" 
		runat="server" targetcontrolid="lnkbtn" enabled="True" 
		displaymodalpopupid="lnkDelete_ModalPopupExtender">
        </ajaxToolkit:ConfirmButtonExtender>--%>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <%-- <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                            </asp:GridView>
                                        </div>

                                        Total:
                                        <label id="lblTotal" runat="server"></label>

                                    </div>


                                    <asp:Panel Width="30%" class="popupConfirmation" ID="DivDeleteConfirmation"
                                        Style="display: none; background: #fffbd6" runat="server">
                                        <div class="popup_Container">
                                            <div class="popup_Titlebar" id="PopupHeader">
                                                <div align="center" style="color: Red" class="TitlebarLeft">
                                                    Warning Message!!!
                                                </div>
                                                <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                                                </div>
                                            </div>
                                            <div align="center" style="color: Red" class="popup_Body">
                                                <p>
                                                    Are you sure want Delete this ?
                                                </p>
                                            </div>
                                            <div align="center" class="popup_Buttons">
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
                <div class="col-lg-4">
                    <div class="row panel-custom1">
                        <div class="panel-header">
                            <h1 class="page-header">Expense Entry
         
                            </h1>
                        </div>
                        <div class="panel-body">
                            <div class="row">

                                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>

                                        <div class="col-lg-12">

                                            <label>
                                                Date</label>
                                            <asp:TextBox CssClass="form-control" ID="txtdate" Text="--Select Date--" runat="server"></asp:TextBox>
                                            <asp:Label ID="lbldateError" runat="server" ForeColor="Red"></asp:Label>
                                            <ajaxToolkit:CalendarExtender ID="CalendarExtender3" Format="dd/MM/yyyy" TargetControlID="txtdate"
                                                runat="server" CssClass="cal_Theme1">
                                            </ajaxToolkit:CalendarExtender>
                                        </div>
                                        <div class=" col-lg-12">
                                            <br />
                                            <label>
                                                Account Name</label>
                                            <asp:DropDownList ID="ddlLedger" CssClass="form-control" Width="100%" runat="server">
                                            </asp:DropDownList>
                                        </div>
                                        <div class="col-lg-12">
                                            <br />
                                            <label>
                                                Amount</label>
                                            <asp:TextBox CssClass="form-control" ID="txtamount" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="please enter Amount" ValidationGroup="val1"
                                                ForeColor="Red" ControlToValidate="txtamount"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class=" col-lg-12">
                                            <label>
                                                Description(Any)</label>
                                            <asp:TextBox CssClass="form-control" ID="txtdescrip" runat="server" TextMode="MultiLine">
                                            </asp:TextBox>
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
                                        <div class="col-lg-12" align="center">
                                            <br />
                                            <asp:Button ID="btnsave" runat="server" OnClientClick="ClientSideClick(this)" UseSubmitBehavior="false" ValidationGroup="val1" Width="150px"
                                                class="btn btn-md btn-primary pos-btn1" Text="Save" OnClick="btnsave_Click" />

                                            <asp:RadioButton ID="order" runat="server" Text="Order" Visible="false" AutoPostBack="true"
                                                OnCheckedChanged="order_CheckedChanged" />
                                        </div>
                                        </div>
                                <!-- /.col-lg-6 (nested) -->
                                    </ContentTemplate>
                                </asp:UpdatePanel>

                                <!-- /.col-lg-6 (nested) -->
                                <!-- /.col-lg-6 (nested) -->
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
