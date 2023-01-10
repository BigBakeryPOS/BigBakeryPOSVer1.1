<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OnlineBillEntry.aspx.cs"
    Inherits="Billing.Accountsbootstrap.OnlineBillEntry" %>

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
    <title>Online Order Alert</title>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .modalBackground
        {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }
        .modalPopup
        {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 140px;
        }
    </style>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" href="Style/chosen.css" />
    <link href="Style/chosen.css" rel="stylesheet" type="text/css" />
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" Visible="false" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" Visible="false" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
        
        <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Online Order Entry</h1>
	    </div>
         
            <div id="Divv3" runat="server" class="col-lg-3">
                <div class="list-group">
                    <asp:Label ID="lblonlinenumberid" runat="server" Visible="false"></asp:Label>
                    <label>
                        Select Branch</label>
                    <asp:DropDownList ID="drpbranch" runat="server" Font-Bold="true"  CssClass="form-control">
                    </asp:DropDownList>
                    <asp:Label ID="lblordercount" Visible="false" runat="server"></asp:Label>
                    <asp:Label ID="lblordertype" Visible="false" runat="server"></asp:Label>
               <br />
                    <label>
                        Select Sales Type</label>
                    <asp:DropDownList ID="drpsalestype" runat="server" 
                        OnSelectedIndexChanged="drpsalestype_selectedindex" AutoPostBack="true" 
                        CssClass="form-control">
                    </asp:DropDownList>
                <br />
                    <label>
                        Payment Mode</label>
                    <asp:DropDownList Width="100%" ID="drpPayment" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                <br />
                    <label>
                        Order Number</label>
                    <asp:TextBox ID="txtordernumber" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                        FilterType="LowercaseLetters,uppercaseletters,Numbers" ValidChars="" TargetControlID="txtordernumber" />
                <br />
                    <label>
                        Entry By</label>
                    <asp:TextBox ID="txtentryby" runat="server" CssClass="form-control"></asp:TextBox>
                   <br />
                    <label>
                        Sender Name</label>
                    <asp:TextBox ID="txtsendername" runat="server" CssClass="form-control"></asp:TextBox>
                 </div>
                    </div>
                  <div id="Div1" runat="server" class="col-lg-3">
                <div class="list-group">
                    <label>
                        Sender No.</label>
                    <asp:TextBox ID="txtsenderno" runat="server" CssClass="form-control"></asp:TextBox>
                 <br />
                    <label>
                        Receiver Name</label>
                    <asp:TextBox ID="txtreceivername" runat="server" CssClass="form-control"></asp:TextBox>
                 <br />
                    <label>
                        Receiver No.</label>
                    <asp:TextBox ID="txtreceiverno" runat="server" CssClass="form-control"></asp:TextBox>
                 <br />
                    <label>
                        Order Date</label>
                    <asp:TextBox ID="txtorderdate" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtorderdate"
                        PopupButtonID="txtdate1" EnabledOnClient="true" runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                 <br />
                    <label>
                        Delivery Date</label>
                    <asp:TextBox ID="txtdeliverydate" runat="server" CssClass="form-control"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txtdeliverydate"
                        PopupButtonID="txtdate1" EnabledOnClient="true" runat="server" CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                </div>
            </div>
            <div id="Div3" runat="server" class="col-lg-6">
                <asp:UpdatePanel ID="UpdatePanel3" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                     <div id="Div5" runat="server" class="col-lg-12">
                        <table width="100%">
                            <tr style="color: steelblue;">
                                <td valign="top" style="width: 5%">
                                    <label style="color: black;">
                                        Sl.No</label>
                                    <asp:TextBox ID="txtmanualslno" runat="server" Width="100%" Text="1" CssClass="form-control"></asp:TextBox>
                                </td>
                                <td valign="top" style="width: 40%">
                                    <label style="color: black;">
                                        Select Item</label>
                                    <asp:DropDownList ID="drpitemsearch" runat="server" CssClass="form-control" Width="100%">
                                    </asp:DropDownList>
                                </td>
                                <td valign="top" style="width: 10%">
                                    <label style="color: black;">
                                        Qty</label>
                                    <asp:TextBox ID="txtmanualqty" runat="server" CssClass="form-control" OnTextChanged="Qty_chnaged" AutoPostBack="true" Width="100%"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server" 
                                        FilterType="Numbers" ValidChars="" TargetControlID="txtmanualqty" />
                                </td>
                                <td id="Td1" valign="top" runat="server" visible="false" style="width: 15%">
                                    <label>
                                        Rate</label>
                                    <asp:TextBox ID="txtrate" runat="server" CssClass="form-control" OnTextChanged="Qty_chnaged"
                                        AutoPostBack="true"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                        FilterType="Numbers" ValidChars="" TargetControlID="txtrate" />
                                </td>
                                <td valign="top" style="width: 15%">
                                   
                                    <br />
                                    <asp:ImageButton ID="imgbtnplus" runat="server" ImageUrl="~/images/edit_add1.png"
                                        OnClick="Qty_chnaged" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="5">
                                <div style="width: 100%; overflow: auto">
                                    <asp:GridView ID="gvlist" runat="server" AutoGenerateColumns="false" Width="100%" cssClass="table table-striped pos-table"
                                        OnRowCommand="gvlist_RowCommand" padding="0" spacing="0" border="0" HeaderStyle-BackColor="#d8d8d8" HeaderStyle-ForeColor="Black"
                                        OnRowDataBound="gvlist_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Cat.Type" ItemStyle-Width="10">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblcattype" runat="server" Text='<%#Eval("cattype") %>' Visible="true"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="S.No" ItemStyle-Width="10">
                                                <ItemTemplate>
                                                    <%--<asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />--%>
                                                    <asp:Label ID="lblRowNumber" Text='<%#Convert.ToInt32(Eval("Sno")) %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField Visible="false" ItemStyle-CssClass="hidden" ItemStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                    <asp:Label ID="categoryid" runat="server" Text='<%#Eval("categoryid") %>' Visible="false"></asp:Label>
                                                    <asp:Label ID="lblcombo" runat="server" Text='<%#Eval("combo") %>' Visible="false"></asp:Label>
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
                                            <asp:TemplateField HeaderText="Stock" Visible="false" ItemStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                    <asp:Label ID="Available_QTY" runat="server" Text='<%#Eval("Available_QTY") %>' Visible="true"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Qty" ItemStyle-Width="10%" ItemStyle-Font-Size="Smaller">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblitemdiscount" runat="server" Text='<%#Eval("Disamt") %>' Style="display: none">0</asp:Label>
                                                    <asp:Label ID="txttax" Visible="false" runat="server" Text='<%#Eval("TAX") %>'></asp:Label>
                                                    <asp:TextBox ID="txtQty" AutoPostBack="true" Width="100%" Enabled="true" Text='<%#Eval("Qty") %>'
                                                        OnTextChanged="txtqty_chnaged" runat="server"></asp:TextBox>
                                                    <asp:TextBox ID="txtshwqty" Visible="false" Width="100%" Enabled="false" Text='<%#Eval("ShwQty") %>'
                                                        runat="server"></asp:TextBox>
                                                    <asp:TextBox ID="txtcqty" Visible="false" Width="100%" Enabled="false" Text='<%#Eval("CQty") %>'
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
                                                    <asp:ImageButton ID="imgminus" runat="server" ToolTip="Less Item" CommandName="minus"
                                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' Height="21px" Width="21px"
                                                        ImageUrl="~/images/Minusnew.png" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="imgdel" runat="server" ToolTip="Cancel Item" CommandName="remove"
                                                        CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' Height="25px" Width="25px"
                                                        ImageUrl="~/images/cancel-circle.png" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    </div>
                                    <br />
                                    <asp:Label ID="lblRound" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                             </table>
                             </div>
                            <div id="Div2" runat="server" class="col-lg-6">
                            <div class="list-group">
                        
                                        <label>
                                            Total Amount</label>
                                        <asp:TextBox ID="txtamount"  runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                                    <br />
                                        <label>
                                            Gst Amnt</label>
                                        <asp:TextBox ID="txtgstamnt"  Enabled="false" Visible="true" runat="server" CssClass="form-control"></asp:TextBox>
                                    <br />
                                        <label>
                                            Discount</label>
                                        <asp:TextBox ID="txtdiscount"  runat="server" CssClass="form-control"
                                            ></asp:TextBox>
                                    <br />
                                        <label>
                                            GST % / Amount</label>
                                            <asp:TextBox ID="txtgstper"  runat="server" Text="18.00" CssClass="form-control" ></asp:TextBox>
                                       </div></div> 
                                     <div id="Div4" runat="server" class="col-lg-6">
                            <div class="list-group">  

                                        <label>
                                            Total Qty</label>
                                        <asp:TextBox ID="txttotqty" Enabled="false" runat="server" CssClass="form-control"></asp:TextBox>
                                   <br />
                                        <label>
                                            Grand Total</label>
                                        <asp:TextBox ID="txtgrandamount" Enabled="false" Visible="true" runat="server" CssClass="form-control"></asp:TextBox>
                                    <br />
                                        <label>
                                            Delivery Charge</label>
                                        <asp:TextBox ID="txtdeliverycharge" runat="server" CssClass="form-control" ></asp:TextBox>
                                   <br />
                                        <label>
                                            Actual Total Amount</label>
                                        <asp:TextBox ID="txtactamount" runat="server" CssClass="form-control"></asp:TextBox>
                                
                            
                           <br /><br />
                                    <asp:Button ID="btnadd" runat="server" class="btn btn-lg btn-primary pos-btn1" ValidationGroup="val1"
                                        Text="Save" OnClick="addclick" />
                                    &nbsp;&nbsp;&nbsp;<asp:Button ID="btnexit" runat="server" class="btn btn-lg btn-link"   Text="Reset" PostBackUrl="~/Accountsbootstrap/OnlineBillEntry.aspx" />
                               </div>
                            </div>
                       
                        <script src="Scripts/jquery.min.js" type="text/javascript"></script>
                        <script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
                        <script src="Scripts/jquery.min.js" type="text/javascript"></script>
                        <script src="Scripts/chosen.jquery.js" type="text/javascript"></script>
                        <script type="text/javascript">                            $(".chzn-select").chosen(); $(".chzn-select-deselect").chosen({ allow_single_deselect: true }); </script>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
            <div class="panel-body">
                 
                     <div class="table-responsive panel-grid-left">
                            <asp:GridView ID="gvip" runat="server" AutoGenerateColumns="false" cssClass="table table-striped pos-table"
                                Caption="Online Order Details" OnRowCommand="gvcat_RowCommand" OnRowDataBound="gvcat_rowdatabound"
                                Width="100%" EmptyDataText="No Record Found" padding="0" spacing="0" border="0">
                                <%--<HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                    HorizontalAlign="Center" ForeColor="White" />--%>
                                <Columns>
                                    <asp:BoundField DataField="do_not_use" HeaderText="Time Elapsed" />
                                    <asp:BoundField DataField="RequestType" HeaderText="Req.Type" />
                                    <asp:BoundField DataField="OnlineID" HeaderText="ID" />
                                    <asp:BoundField DataField="PaymentType" HeaderText="Online Name" />
                                    <asp:BoundField DataField="OnlineNumber" HeaderText="Order No" />
                                    <asp:BoundField DataField="BranchCode" HeaderText="Branch Code" />
                                    <asp:BoundField DataField="EntryDate" HeaderText="Entry Date" DataFormatString='{0:dd/MMM/yyyy hh:mm:ss tt}' />
                                    <asp:BoundField DataField="HStatus" Visible="false" HeaderText="H.Status" />
                                    <asp:BoundField DataField="HkotNo" Visible="false" HeaderText="H.Kot No" />
                                    <asp:BoundField DataField="Status" HeaderText="I.Status" />
                                    <asp:BoundField DataField="KotNo" HeaderText="I.Kot No" />
                                    <asp:BoundField DataField="cstatus" HeaderText="C.Status" />
                                    <asp:BoundField DataField="cdate" Visible="false" HeaderText="C.Date" />
                                    <asp:BoundField DataField="reason" Visible="false" HeaderText="Reason" />
                                    <asp:TemplateField Visible="true" ItemStyle-HorizontalAlign="Center" HeaderText="Edit">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btnedit" CommandArgument='<%#Eval("OnlineID") %>' CommandName="Edits" cssclass="btn btn-warning btn-md"
                                                runat="server">
                                                <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" Width="55px" Visible="false" />
                                                <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                </asp:LinkButton>
                                            <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                            <asp:HiddenField ID="ldgID" runat="server" Value='<%# Bind("OnlineID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Cancel Sales">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="btndelete" runat="server" CommandArgument='<%#Eval("OnlineID") %>'
                                                CommandName="cancels" Visible="true">
                                                <asp:Image ID="dlt" runat="server" ImageAlign="Middle" ImageUrl="~/images/cancel-circle.png"
                                                    Width="37px" Visible="false" />
                                                     <button type="button" class="btn btn-danger btn-md">
												<span class="glyphicon glyphicon-remove" aria-hidden="true"></span>
												</button>
                                                </asp:LinkButton>
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
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
               
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
                            <br />
                            <asp:TextBox ID="txtRef" runat="server" placeholder="Enter Notes "></asp:TextBox>
                            <br />
                            <label>
                                Reason</label><br />
                            <asp:DropDownList ID="ddlmainreason" runat="server">
                                <asp:ListItem Text="Customer"></asp:ListItem>
                                <asp:ListItem Text="Partner"></asp:ListItem>
                                <asp:ListItem Text="Retaurant(BF)"></asp:ListItem>
                            </asp:DropDownList>
                            <br />
                            <label>
                                Sub Reason</label><br />
                            <asp:DropDownList ID="dlReason" runat="server">
                                <asp:ListItem Text="select"></asp:ListItem>
                                <asp:ListItem Text="Change Product"></asp:ListItem>
                                <asp:ListItem Text="Quantity Change"></asp:ListItem>
                            </asp:DropDownList>
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
   
      </div>
        </div>
        </div>
        </div>
    </div>
    </div>
  
    </form>
</body>
</html>
