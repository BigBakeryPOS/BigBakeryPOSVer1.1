<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReturnReceiving.aspx.cs"
    Inherits="Billing.Accountsbootstrap.ReturnReceiving" %>

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
    <title>Return  Receiving Stock</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <!-- Bootstrap Core CSS -->
    <link href="../Styles/style1.css" rel="stylesheet" type="text/css" />
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById("div1");
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
            prtWindow.print();
            prtWindow.close();
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
    <style type="text/css">
        .blink
        {
            text-decoration: blink;
        }
    </style>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Return Receiving Stock</h1>
	    </div>
    <div class="panel-body">
       
            <div class="row">
                
                        <div  runat="server" visible="false" class="col-lg-3" >
                            <label>
                                Select RetNo
                            </label>
                            <asp:DropDownList ID="ddlretno" runat="server" CssClass="form-control"
                                AutoPostBack="true" OnSelectedIndexChanged="ddlretno_OnSelectedIndexChanged">
                            </asp:DropDownList>
                    </div>
                    <div class="col-lg-3">
                        <asp:Button ID="btnsave" runat="server" CssClass="btn btn-info pos-btn1" Text="Receive"
                             OnClick="btnsave_OnClick" OnClientClick="ClientSideClick(this)"
                            UseSubmitBehavior="false" />
                    </div>
            </div>
            <br />
            <div id="div1" class="row" runat="server">
                    <div class="col-lg-6">
                    <div class="table-responsive panel-grid-left">
                        <asp:GridView ID="gvallReturns" Caption="Stock Returned Receving" EmptyDataText="No Data Found" runat="server" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0" OnRowCommand="gvPurchaseEntry_RowCommand"
                            ShowFooter="true" AutoGenerateColumns="false" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="SNo">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Branch" DataField="Branch" />
                                <asp:BoundField HeaderText="RetNo" DataField="RetNo" />
                                <asp:BoundField HeaderText="RetDate" DataField="RetDate" DataFormatString="{0:dd/MMM/yy}" />
                                <asp:BoundField HeaderText="Reason" DataField="Reason" />
                                <asp:BoundField HeaderText="SubReasons" DataField="SubReasons" />
                                <asp:BoundField HeaderText="Notes" DataField="notes" />
                                <asp:BoundField HeaderText="Qty" DataField="Quantity" />
                                <asp:TemplateField HeaderText="Accept and View">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnprint" runat="server" CommandArgument='<%#Eval("RetNo") %>'
                                            CommandName="view">
                                            <asp:Image ID="print" runat="server" ImageAlign="Middle" ImageUrl="~/images/info_button.png" Visible="false" />
                                            <button type="button" class="btn btn-primary btn-md">
						                        <span class="glyphicon glyphicon-info-sign" aria-hidden="true"></span>
					                        </button>
                                            </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                          <%--  <FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />--%>
                        </asp:GridView>
                    </div>
                    </div>
                    <div class="col-lg-6">
                    <div class="table-responsive panel-grid-left">
                        <asp:GridView ID="gvReturns" Caption="Stock Return Receving Entry" runat="server" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                            ShowFooter="true" AutoGenerateColumns="false" Width="100%">
                            <Columns>
                                <asp:TemplateField HeaderText="SNo">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Branch" DataField="Branch" />
                                <asp:BoundField HeaderText="RetNo" DataField="RetNo" />
                                <asp:BoundField HeaderText="RetDate" DataField="RetDate" DataFormatString="{0:dd/MMM/yy}" />
                                <asp:BoundField HeaderText="Reason" DataField="Reason" />
                                <asp:BoundField HeaderText="SubReasons" DataField="SubReasons" />
                                <asp:BoundField HeaderText="Notes" DataField="notes" />
                                <asp:BoundField HeaderText="Group" DataField="Category" />
                                <asp:BoundField HeaderText="Item" DataField="Definition" />
                                <asp:BoundField HeaderText="Qty" DataField="Qty" />
                                <asp:TemplateField HeaderText="Receive Qty">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtqty" runat="server" CssClass="form-control" Text='<%# Bind("Qty") %>'
                                            Width="120px"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            FilterType="Numbers,custom" TargetControlID="txtqty" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                        <asp:HiddenField ID="hdTransRetID" runat="server" Value='<%# Bind("TransRetID") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Missing Qty">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtmissingqty" runat="server" CssClass="form-control" Width="120px"></asp:TextBox>
                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                            FilterType="Numbers,custom" TargetControlID="txtmissingqty" ValidChars=".">
                                        </ajaxToolkit:FilteredTextBoxExtender>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <%--<FooterStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />
                            <HeaderStyle BackColor="#990000" ForeColor="White" HorizontalAlign="Center" />--%>
                        </asp:GridView>
                    </div>
                    </div>
            </div>
       
    </div>
    </div>
    </div>
    </div>
    </div>
    </form>
</body>
</html>
