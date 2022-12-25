<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="OfferGrid.aspx.cs" Inherits="Billing.Accountsbootstrap.OfferGrid" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Offer</title>
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
    <%--<script type="text/javascript" language="javascript">
        function valchk() {
            if (blankchk(document.getElementById('txtcategory'), "Category")) {
                alert("true");
            }
            else {
                alert("false");
                return false;
            }
        }
	</script>--%>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
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
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h2 id="hd1" runat="server" class="page-header" style="text-align: left; color: #fe0002">
                OFFER Product</h2>
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
            <div class="panel panel-default">
                <div class="panel-body">
                    <asp:HiddenField ID="selected_tab" runat="server" />
                    <asp:Button ID="Button3" runat="server" Text="Do PostBack" Visible="false" />
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <div id="add" runat="server" class="form-group">
                        <div class="row">
                            <div class="col-lg-6">
                            <div id="Div2" runat="server" style="overflow: auto; height: 350px">
                                        <asp:GridView ID="gridview" runat="server" AllowPaging="false" PageSize="10" 
                                            AutoGenerateColumns="false"  OnRowCommand="gridview_rowcommand" EmptyDataText="No Records Found" 
                                            AllowSorting="true" CssClass="mydatagrid" HeaderStyle-CssClass="header" RowStyle-CssClass="rows" >
                                            
                                            <EmptyDataRowStyle HorizontalAlign="Center" BackColor="#59d3b4" ForeColor="Black" />
                                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                                NextPageText="Next" PreviousPageText="Previous" />
                                            <Columns>
                                                <asp:BoundField HeaderText="Category User ID" DataField="OfferId" Visible="false" />
                                                <asp:BoundField HeaderText="Offer Name" DataField="OfferName"   />
                                                <asp:BoundField HeaderText="Offer Value" DataField="TotalRate"   />
                                                <asp:BoundField HeaderText="Offer Start Date" DataField="From_Time"   />
                                                <asp:BoundField HeaderText="Offer To Date" DataField="To_Time"   />
                                                <asp:BoundField HeaderText="Is Active" DataField="IsActive"   />
                                                
                                                <asp:TemplateField Visible="true" ItemStyle-HorizontalAlign="Center" HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnedit" CommandArgument='<%#Eval("OfferId") %>' CommandName="Editt"
                                                            runat="server">
                                                            <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" width="55px"/></asp:LinkButton>
                                                        <asp:HiddenField ID="ldgID" runat="server" Value='<%# Bind("OfferId") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField Visible="false" ItemStyle-HorizontalAlign="Center" HeaderText="Delete">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btndel" CommandArgument='<%#Eval("OfferId") %>' CommandName="Del"
                                                            runat="server">
                                                            <asp:Image ID="Image1" ImageUrl="~/images/DeleteIcon_btn.png" runat="server" /></asp:LinkButton>
                                                        <asp:ImageButton ID="imgdisable" ImageUrl="~/images/delete.png" runat="server" Visible="false"
                                                            Enabled="false" ToolTip="Not Allow To Delete" />
                                                        <ajaxToolkit:ModalPopupExtender ID="lnkDelete_ModalPopupExtender" runat="server"
                                                            CancelControlID="ButtonDeleteCancel" OkControlID="ButtonDeleleOkay" TargetControlID="btndel"
                                                            PopupControlID="DivDeleteConfirmation" BackgroundCssClass="ModalPopupBG">
                                                        </ajaxToolkit:ModalPopupExtender>
                                                        <ajaxToolkit:ConfirmButtonExtender ID="lnkDelete_ConfirmButtonExtender" runat="server"
                                                            TargetControlID="btndel" Enabled="True" DisplayModalPopupID="lnkDelete_ModalPopupExtender">
                                                        </ajaxToolkit:ConfirmButtonExtender>
                                                        
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                            <FooterStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                            <HeaderStyle BackColor="#336699" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                        </asp:GridView>
                                    </div>
                            </div>
                            <div class="col-lg-3">
                                <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
                                    ID="val1" ShowMessageBox="true" ShowSummary="false" />
                                <asp:TextBox ID="txtcombiid" runat="server" Visible="false"></asp:TextBox>
                                <div class="form-group">
                                    <label style="margin-top: -10px">
                                        Discount Name</label>
                                    <asp:TextBox CssClass="form-control" ID="txtcomboname" runat="server" MaxLength="150"></asp:TextBox>
                                </div>
                                 <div class="form-group">
                                    <label style="margin-top: -10px">
                                        Discount (%)</label>
                                    <asp:TextBox CssClass="form-control" ID="txtdiscper" runat="server" MaxLength="150"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label>
                                        From Date</label>
                                    <asp:TextBox CssClass="form-control" ID="txtfromdate" runat="server" MaxLength="150"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfromdate"
                                        PopupButtonID="txtfromdate" EnabledOnClient="true" runat="server" Format="dd/MM/yyyy"
                                        CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                    <asp:Label ID="Label1" runat="server" Style="color: Red"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label>
                                        To Date</label>
                                    <asp:TextBox CssClass="form-control" ID="txttodate" runat="server" MaxLength="150"></asp:TextBox>
                                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txttodate"
                                        Format="dd/MM/yyyy" PopupButtonID="txttodate" EnabledOnClient="true" runat="server"
                                        CssClass="cal_Theme1">
                                    </ajaxToolkit:CalendarExtender>
                                </div>
                                <div class="form-group">
                                    <label>
                                        From Time
                                    </label>
                                    <asp:DropDownList ID="ddlTimeFrom" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:Label ID="fromtime" runat="server" BackColor="Red" Font-Bold="true" ForeColor="White"
                                        Visible="false"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label>
                                        TO Time</label>
                                    <asp:DropDownList ID="ddlTimeTo" CssClass="form-control" runat="server">
                                    </asp:DropDownList>
                                    <asp:Label ID="totime" runat="server" BackColor="Red" Font-Bold="true" ForeColor="White"
                                        Visible="false"></asp:Label>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Is Active</label>
                                    <asp:DropDownList ID="drpisactive" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"> </asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"> </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div class="form-group">
                                    <label>
                                        Is Discount</label>
                                    <asp:DropDownList ID="drpisdiscount" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"> </asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"> </asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                                <div id="Div1" runat="server" visible="false" class="form-group">
                                    <label>
                                        Total Amount</label>
                                    <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
                                </div>
                                <asp:Button ID="btnadd" runat="server" class="btn btn-info" ValidationGroup="val1"
                                    Text="Save" Style="width: 120px; margin-top: 15px" OnClick="addclick" />
                                <asp:Button ID="btnexit" runat="server" class="btn  btn-warning" Style="width: 120px;
                                    margin-top: 15px" Text="Exit" OnClick="btnexit_Click" />
                            </div>
                            <div class="col-lg-3">
                                <div class="panel panel-default">
                                    <!-- /.panel-heading -->
                                    <div class="panel-body">
                                        <div class="table-responsive">
                                            <asp:Label ID="Label7" runat="server" Style="color: Red"></asp:Label>
                                            <table class="table table-striped table-bordered table-hover" id="Table1" width="100%">
                                                <tr>
                                                    <td colspan="7">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                <asp:Panel ID="Panel1" runat="server" Width="100%">
                                                                    <asp:CheckBoxList ID="chklistcategory" runat="server">
                                                                    </asp:CheckBoxList>
                                                                </asp:Panel>
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
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
    </div>
    <!-- /.col-lg-12 -->
    <!-- /.row -->
    </form>
    <!-- /#page-wrapper -->
</body>
</html>
