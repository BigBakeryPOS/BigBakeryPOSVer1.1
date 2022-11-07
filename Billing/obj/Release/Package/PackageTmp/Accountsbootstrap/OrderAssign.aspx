<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OrderAssign.aspx.cs" Inherits="Billing.Accountsbootstrap.OrderAssign" %>

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
    <title>Order Assign Grid</title>
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
     <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
     <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header"> Order Assign Entry</h1>
	    </div>

            <div id="Div2" runat="server" visible="false">
                <%-- Blaackforestonline@gmail.com--%>
                <asp:TextBox ID="txtemail" runat="server" Text="jothikumar@bigdbiz.in"></asp:TextBox>
            </div>
           
                <div class="panel-body">
                    <form runat="server" id="form1">
                    <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
                        ID="val1" ShowMessageBox="true" ShowSummary="false" />
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>

                    <div class="row">
                    <div class="col-lg-12">
                        <div runat="server" visible="false" class="col-lg-3">
                            
                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="phono" ControlToValidate="txtsearch"
                                    ErrorMessage="Please enter your searching Data!" Text="*" Style="color: White" />
                                <asp:TextBox CssClass="form-control" Enabled="true" ID="txtsearch" runat="server"
                                    placeholder="Search Text" Style="width: 150px;"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                    FilterType="LowercaseLetters, UppercaseLetters,Numbers,Custom" ValidChars=" "
                                    TargetControlID="txtsearch" />
                           
                        </div>
                        <div class="col-lg-3">
                            
                                <label>
                                    Date Type</label>
                                <asp:RadioButtonList ID="raddatetype" OnSelectedIndexChanged="Date_chnage" AutoPostBack="true" RepeatColumns="2"
                                    runat="server">
                                    <asp:ListItem Value="OrderDate" Text="Order Date"></asp:ListItem>
                                    <asp:ListItem Value="DeliveryDate" Text="Delivery Date" Selected="True"></asp:ListItem>
                                </asp:RadioButtonList>
                            
                        </div>
                        <div class="col-lg-3">
                           
                                <label>
                                    Select Date</label>
                                <asp:TextBox runat="server" ID="txtfromdate" CssClass="form-control" AutoPostBack="true"
                                    OnTextChanged="txtfromdate_TextChanged"> 
                                </asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfromdate"
                                    Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                           </div>
                           <div class="col-lg-3">
                           
                                <label>
                                    From Date(only For Deliery date)</label>
                                <asp:TextBox runat="server" ID="txttodate" CssClass="form-control"> 
                                </asp:TextBox>
                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txttodate"
                                    Format="dd/MM/yyyy" runat="server" CssClass="cal_Theme1">
                                </ajaxToolkit:CalendarExtender>
                            </div>
                            <div class="col-lg-3">
                                <label>
                                    Time Up TO for Delivery Date :
                                </label>
                                <asp:Label ID="lblshowtime" runat="server" Text="12:00 PM" Font-Bold="true"></asp:Label> <br />
                                <asp:Label ID="lbltime" runat="server" Text="12:00" Visible="false"></asp:Label>
                                <br /> <br />
                            </div>
                        
                        <div class="col-lg-3">
                          
                                <label>
                                    Select Status</label>
                                <asp:DropDownList ID="drpstatus" runat="server" OnSelectedIndexChanged="Status_chnaged"
                                    AutoPostBack="true" CssClass="form-control">
                                </asp:DropDownList>
                           
                        </div>
                        <div class="col-lg-3">
                          
                                <label>
                                    Branch</label>
                                <asp:DropDownList CssClass=" form-control" ID="drpbranch" AutoPostBack="true"
                                    OnSelectedIndexChanged="ddlsuplier_OnSelectedIndexChanged"  runat="server">
                                </asp:DropDownList>
                           
                        </div>
                        <div class="col-lg-3">
                         
                                <label>
                                    Status Details</label>
                                <asp:GridView ID="gridstatus" runat="server" AutoGenerateColumns="false" CssClass="mGrid">
                                    <Columns>
                                        <asp:BoundField DataField="status" HeaderText="Status Name" />
                                        <asp:BoundField DataField="cnt" HeaderText="Count" />
                                    </Columns>
                                </asp:GridView>
                           
                        </div>
                        <asp:Button ID="btnemail" Visible="false" runat="server" CssClass="btn btn-default"
                            Text="Email - Order Detailed Report" OnClick="btnSendMail_Click" />
                        <%-- <div class="col-lg-2 ">
                            <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Add New" OnClick="Add_Click"
                                Style="width: 120px; margin-right: 450px; margin-top: 20px" />
                        </div>--%>
                    </div>
                   
                    <div class="col-lg-12">
                        <div class="col-lg-3">
                           
                                <%--<asp:Button ID="btnpending" runat="server" Text="Pending" Font-Bold="true" Font-Size="20px"
                                    OnClick="Pending_click" Width="100%" Height="5pc" CssClass="btn btn-info" />--%>
                                <asp:Label ID="lblpending" runat="server" Font-Bold="true" Font-Size="18px"></asp:Label>
                            
                        </div>
                        <div class="col-lg-3">
                           
                                <%--<asp:Button ID="btnaccpeted" runat="server" Text="Accepted" Font-Bold="true" Font-Size="20px"
                                    OnClick="Accept_chnaged" Width="100%" Height="5pc" CssClass="btn btn-secondary" />--%>
                                <asp:Label ID="lblaccpetedandassign" runat="server" Font-Bold="true" Font-Size="18px"></asp:Label>
                            
                        </div>
                        <div class="col-lg-3">
                          
                                <%--<asp:Button ID="btnassign" runat="server" Text="Assigned" Font-Bold="true" Font-Size="20px"
                                    OnClick="Assign_chnaged" Width="100%" Height="5pc" CssClass="btn btn-danger" />--%>
                                <asp:Label ID="lblhold" runat="server" Font-Bold="true" Font-Size="18px"></asp:Label>
                            
                        </div>
                        <div class="col-lg-2">
                            
                                <%--<asp:Button ID="btncompleted" runat="server" Text="Completed" Font-Bold="true" Font-Size="20px"
                                    OnClick="Completed_chnaged" Width="100%" Height="5pc" CssClass="btn btn-warning" />--%>
                                <asp:Label ID="lblcompleted" runat="server" Font-Bold="true" Font-Size="18px"></asp:Label>
                            
                        </div>
                        <div class="col-lg-3">
                          
                                <%--<asp:Button ID="btntransit" runat="server" Text="Transit" Font-Bold="true" Font-Size="20px"
                                    OnClick="Transit_chnaged" Width="100%" Height="5pc" CssClass="btn btn-success" />--%>
                                <asp:Label ID="lbltransit" runat="server" Font-Bold="true" Font-Size="18px"></asp:Label>
                           
                        </div>
                        <div class="col-lg-3">
                           
                                <%--<asp:Button ID="btndelivered" runat="server" Text="Delivered" Font-Bold="true" Font-Size="20px"
                                    Width="100%" Height="5pc" CssClass="btn btn-primary" OnClick="Delivered_chnaged" />--%>
                                <asp:Label ID="lbldelivered" runat="server" Font-Bold="true" Font-Size="18px"></asp:Label>
                            
                        </div>
                        <div class="col-lg-3">
                            
                                <%--<asp:Button ID="btndelivered" runat="server" Text="Delivered" Font-Bold="true" Font-Size="20px"
                                    Width="100%" Height="5pc" CssClass="btn btn-primary" OnClick="Delivered_chnaged" />--%>
                                <asp:Label ID="lblcancel" runat="server" Font-Bold="true" Font-Size="18px"></asp:Label>
                            
                        </div>
                    </div>
                    </div>
                    
                    <div class="col-lg-12">

                                <div id="Div1" runat="server" class="table-responsive panel-grid-left">
                                    <asp:GridView ID="BankGrid" runat="server" DataKeyNames="billno,Branchcode,bookno" cssClass="table table-striped pos-table"
                                        Width="100%" AllowSorting="true" Font-Names="Calibri" OnRowDataBound="GridView1_OnRowDataBound"
                                        OnRowCommand="bankgrid_rowcommand" EmptyDataText="No Records Found" AutoGenerateColumns="false" padding="0" spacing="0" border="0">
                                     <%--   <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                            HorizontalAlign="Center" ForeColor="White" />--%>
                                        <%--  <HeaderStyle BackColor="#3366FF" />--%>
                                       <%-- <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                            NextPageText="Next" PreviousPageText="Previous" />--%>
                                            <PagerStyle CssClass="pos-paging" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Preview">
                                                <ItemTemplate>
                                                    <%--<asp:LinkButton ID="btnprint" CommandArgument='<%#Eval("OrderNo") + ";" +Eval("Branchcode")+ ";" +Eval("ProcessStatus") + ";"+Eval("bookno")+";"+Eval("SubOrderSummaryId")%>'--%>
                                                    <asp:LinkButton ID="btnprint" CommandArgument='<%#Eval("OrderNo") + ";" +Eval("Branchcode")+ ";"+Eval("bookno")%>'
                                                        CommandName="Preview" runat="server">
                                                        <asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png" Visible="false" /></asp:LinkButton>
                                                    
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField HeaderText="BranchCode" DataField="Branchcode" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="BookNo" DataField="BookNo" />
                                            <asp:BoundField HeaderText="OrderNo" DataField="OrderNo" />
                                            <asp:BoundField HeaderText="OrderDate" DataField="OrderDate" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField HeaderText="Delivery Date" DataField="deliverydate" DataFormatString="{0:dd/MM/yyyy}" />
                                            <asp:BoundField HeaderText="Delivery Time" DataField="Deliverytime" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:BoundField HeaderText="Delivery Status" DataField="DeliverStatus" HeaderStyle-HorizontalAlign="Center" />
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50%" HeaderText="Item Details"
                                                HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <a href="javascript:switchViews('dv<%# Eval("BookNo") %>');" style="text-decoration: none;">
                                                        <%--<img id="imdiv<%# Eval("BookNo") %>" alt="Show" runat="server"  border="0" src="../images/plus.gif" />--%>
                                                    </a>
                                                    <div id="dv<%# Eval("BookNo") %>">
                                                        <asp:GridView ID="GridView11" runat="server" ShowFooter="true" AutoGenerateColumns="false" cssClass="table table-striped pos-table"
                                                            Font-Names="Calibri" EmptyDataText="No Records Found" padding="0" spacing="0" border="0">
                                                          <%--  <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                                                HorizontalAlign="Center" ForeColor="White" />--%>
                                                            <Columns>
                                                                <asp:BoundField DataField="definition" HeaderText="Item Name" />
                                                                <asp:BoundField DataField="Qty" HeaderText="Qty" />
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--7--%>
                                            <asp:TemplateField Visible="false" HeaderText="Employee Assign">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblassignemp" runat="server" Text='<%#Eval("Empname")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Process Change">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btndel" CommandArgument='<%#Eval("billno") + ";" +Eval("Branchcode")+ ";" +Eval("DeliverStatus")%>'
                                                        CommandName="Process" runat="server">
                                                        <asp:Label ID="lblbtn" runat="server" Text='<%#Eval("DeliverStatus") %>'></asp:Label></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50%" HeaderText="Employee Item Details"
                                                HeaderStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <%--  <a href="javascript:switchViews('dv<%# Eval("BillNo") %>');" style="text-decoration: none;">--%>
                                                    <%--<img id="imdiv<%# Eval("BookNo") %>" alt="Show" runat="server"  border="0" src="../images/plus.gif" />--%>
                                                    <%--   </a>--%>
                                                    <%-- <div id="dv<%# Eval("BillNo") %>"> --%>
                                                    <asp:GridView ID="GridView12" runat="server" ShowFooter="true" AutoGenerateColumns="false" cssClass="table table-striped pos-table"
                                                        DataKeyNames="billno,Branchcode,bookno,SubStatusId" Font-Names="Calibri" EmptyDataText="No Records Found" padding="0" spacing="0" border="0"
                                                        OnRowDataBound="GridView12_OnRowDataBound">
                                                       <%-- <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                                            HorizontalAlign="Center" ForeColor="White" />--%>
                                                        <Columns>
                                                            <asp:BoundField DataField="SubStatusId" HeaderText="SubStatusId" Visible="false" />
                                                            <asp:BoundField DataField="SubStatusName" HeaderText="SubStatusName" />
                                                            <asp:BoundField DataField="BillNo" HeaderText="BillNo" Visible="false" />
                                                            <asp:BoundField DataField="Branchcode" HeaderText="Branchcode" Visible="false" />
                                                            <asp:BoundField DataField="EmployeeId" HeaderText="EmployeeId" Visible="false" />
                                                            <asp:BoundField DataField="EmployeeName" HeaderText="Employee Name" />
                                                            <asp:BoundField DataField="status" HeaderText="Status" ItemStyle-Font-Bold="true"
                                                                ItemStyle-Font-Size="20px" />
                                                            <asp:TemplateField HeaderText="Employee ">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="drpemployeeassign" runat="server" OnSelectedIndexChanged="ddlemployee_Chnaged"
                                                                        AutoPostBack="true" CssClass="form-control">
                                                                    </asp:DropDownList>
                                                                    <asp:Label ID="lblbillno" Visible="false" runat="server" Text='<%#Eval("BillNo")%>'></asp:Label>
                                                                    <asp:Label ID="lblbookno" Visible="false" runat="server" Text='<%#Eval("bookno")%>'></asp:Label>
                                                                    <asp:Label ID="lblbranchcode" Visible="false" runat="server" Text='<%#Eval("Branchcode")%>'></asp:Label>
                                                                    <asp:Label ID="lblSubOrderSummaryId" Visible="false" runat="server" Text='<%#Eval("SubOrderSummaryId")%>'></asp:Label>
                                                                    <asp:Label ID="lblSubStatusId" Visible="false" runat="server" Text='<%#Eval("SubStatusId")%>'></asp:Label>
                                                                    <asp:Label ID="lblstatus" Style="display: none" runat="server" Text='<%#Eval("status")%>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Kot Print">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnpprint" CommandArgument='<%#Eval("orderno") + ";" +Eval("Branchcode")%>'
                                                        CommandName="KotPrint" runat="server">
                                                        <asp:Image ID="imgprint" runat="server" ImageUrl="~/images/print (1).png" Width="50px" />
                                                    </asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <%--<asp:TemplateField HeaderText="Edit" ItemStyle-HorizontalAlign="center" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btnedit" runat="server" CommandArgument='<%#Eval("Purchaseorderid") %>'
                                                        CommandName="Select">
                                                        <asp:Image ID="img" runat="server" ImageUrl="~/images/edit.png" /></asp:LinkButton>
                                                    <asp:ImageButton ID="imgdisable" ImageUrl="~/images/edit.png" runat="server" Visible="false"
                                                        Enabled="false" ToolTip="Not Allow To Delete" />
                                                    <asp:HiddenField ID="ldgID" runat="server" Value='<%# Bind("Purchaseorderid") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Delete" ItemStyle-HorizontalAlign="Center" Visible="false">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("Purchaseorderid") %>'
                                                        CommandName="delete" OnClientClick="alertMessage()">
                                                        <asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/delete.png" /></asp:LinkButton>
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
                                            </asp:TemplateField>--%>
                                        </Columns>
                                       <%-- <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                        <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />--%>
                                    </asp:GridView>
                                </div>

                        <script src="../Scripts/jquery.min.js" type="text/javascript"></script>
                        <script src="../Scripts/chosen.jquery.js" type="text/javascript"></script>
                        <script type="text/javascript">                            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
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
                    </form>
                </div>
 
    </div>
    </div>
    </div>
    </div>
</body>
</html>
