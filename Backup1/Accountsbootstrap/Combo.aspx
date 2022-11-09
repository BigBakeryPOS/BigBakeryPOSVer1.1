<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Combo.aspx.cs" Inherits="Billing.Accountsbootstrap.Combo" %>

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
    <title>Combo</title>
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
    <link href="../css/Pos_style.css" rel="stylesheet" />
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
   <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="col-lg-4">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Add Combo Product</h1>
	    </div>
    
                <div class="panel-body">
                    <asp:HiddenField ID="selected_tab" runat="server" />
                    <asp:Button ID="Button3" runat="server" Text="Do PostBack" Visible="false" />
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <div class="panel-body panel-form-right">
                    <div class="list-group">
                        
                            
                                <asp:ValidationSummary runat="server" HeaderText="Validation Messages" ValidationGroup="val1"
                                    ID="val1" ShowMessageBox="true" ShowSummary="false" />
                                <asp:TextBox ID="txtcombiid" runat="server" Visible="false"></asp:TextBox>
                                
                                    <label>Category</label>
                                    <asp:DropDownList runat="server" Enabled="true" ID="drpCategory" class="form-control">
                                    </asp:DropDownList>
                                <br />
                               
                                    <label>Combo Name</label>
                                    <asp:TextBox CssClass="form-control" ID="txtcomboname" runat="server" MaxLength="150"></asp:TextBox>
                               <br /> 
                                <div runat="server" visible="false" class="form-group">
                                    <label>Is Discount</label>
                                    <asp:DropDownList ID="drpisdiscount" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Yes" Selected="True" Value="1"> </asp:ListItem>
                                        <asp:ListItem Text="No" Value="0"> </asp:ListItem>
                                    </asp:DropDownList>
                                </div>


                               
                                    <label>Is Active</label>
                                    <asp:DropDownList ID="drpisactive" CssClass="form-control" runat="server">
                                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"> </asp:ListItem>
                                        <asp:ListItem Text="No" Value="No"> </asp:ListItem>
                                    </asp:DropDownList>
                                    <br />
                                    <%--<asp:CheckBox ID="chkisactive" runat="server" />--%>
                                
                                <div id="Div1" runat="server" visible="false" class="form-group">
                                    <label>
                                        Total Amount</label>
                                    <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
                                </div>


                                <asp:Button ID="btnadd" runat="server" class="btn btn-lg btn-primary pos-btn1" ValidationGroup="val1"
                                    Text="Save" width="150px" OnClick="addclick" />
                                <asp:Button ID="btnexit" runat="server" class="btn btn-lg btn-link" width="150px" Text="Clear" OnClick="btnexit_Click" />
                            
                            
                       
                        
                        <!-- /.col-lg-6 (nested) -->
                    </div>
                    <!-- /.row (nested) -->
                </div>
                </div>
             
    </div>
    </div>
    <div class="col-lg-8">
                                <div class="row panel-custom1">
                                <div class="panel-header">
				                    <h1 class="page-header">Add Combo</h1>
		                            </div>
                                    <!-- /.panel-heading -->
                                    <div class="panel-body">
                                        <div class="table-responsive panel-grid-left">
                                                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                            <ContentTemplate>
                                                                
                                                                    <asp:GridView ID="gvcombo" AutoGenerateColumns="False" ShowFooter="false" OnRowDataBound="GridView2_RowDataBound"
                                                                        OnRowDeleting="GridView2_RowDeleting" CssClass="table table-striped pos-table" padding="0" spacing="0" border="0"
                                                                        runat="server">
                                                                        <%--<HeaderStyle BackColor="#59d3b4" />--%>
                                                                       <%-- <EmptyDataRowStyle HorizontalAlign="Center" BackColor="#59d3b4" ForeColor="Black" />--%>
                                                                        <Columns>
                                                                            <asp:TemplateField HeaderText="S.No">
                                                                                <ItemTemplate>
                                                                                    <%# Container.DataItemIndex + 1 %>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Item Name"  >
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList  ID="drpitem" OnSelectedIndexChanged="drpitem_changed" CssClass="form-control" Width="100px"
                                                                                        AutoPostBack="true" runat="server">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Item Rate" >
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="PRate" Enabled="false" Width="100px" runat="server" CssClass="form-control"></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="GST %" >
                                                                                <ItemTemplate>
                                                                                    <asp:DropDownList ID="ddltax" Width="100px" runat="server" CssClass="form-control">
                                                                                    </asp:DropDownList>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Qty" >
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtqty" OnTextChanged="txtQty_TextChanged" CssClass="form-control"  Width="100px" AutoPostBack="true" runat="server"
                                                                                        ></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Rate" >
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txtrate" runat="server" OnTextChanged="txtRate_TextChanged" CssClass="form-control" Width="100px" AutoPostBack="true"
                                                                                        ></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField HeaderText="Total Rate" >
                                                                                <ItemTemplate>
                                                                                    <asp:TextBox ID="txttotalrate" Enabled="false" Width="100px" runat="server" CssClass="form-control" ></asp:TextBox>
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:TemplateField>
                                                                                <ItemTemplate>
                                                                                    <asp:Button ID="ButtonAdd1" runat="server" AutoPostback="false" Width="100px" CssClass="btn btn-primary pos-btn1" EnableTheming="false" 
                                                                                       Text="Add New" OnClick="ButtonAdd1_Click" />
                                                                                </ItemTemplate>
                                                                            </asp:TemplateField>
                                                                            <asp:CommandField ControlStyle-Width="100%" ShowDeleteButton="True" ButtonType="Button"  />
                                                                        </Columns>
                                                                    </asp:GridView>
                                                                    <div align="right">
                                                                        <asp:TextBox ID="getttal" runat="server" Text="0.00" CssClass="form-control" Width="150px"></asp:TextBox>
                                                                    </div>
                                                             
                                                            </ContentTemplate>
                                                        </asp:UpdatePanel>
                                        </div>
                                    </div>
                                </div>
                            </div>
    </div>
    </div>
    </div>
    <div id="div7" runat="server" align="center" visible="false">
                            <table cellpadding="1" cellspacing="2" width="450px" style="border: 1px solid blue;
                                height: 150px;">
                                <tr class="headerPopUp">
                                    <td id="Td1" runat="server" colspan="4">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4">
                                        <table style="width: 100%">
                                            <tr>
                                                <td style="width: 30%">
                                                </td>
                                                <td style="width: 35%">
                                                    <div>
                                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                                        <asp:GridView ID="GridView1" runat="server">
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                                <td style="width: 35%">
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td style="width: 30%">
                                                            </td>
                                                            <td style="width: 35%" align="center">
                                                                <asp:Button ID="btnUpload1" runat="server" Height="31px" class="btn btn-info" Text="Upload"
                                                                    Width="100px" />
                                                            </td>
                                                            <td style="width: 35%">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <table style="width: 100%">
                                                        <tr>
                                                            <td style="width: 15%">
                                                            </td>
                                                            <td style="width: 70%" align="center">
                                                                <asp:Button ID="Button2" runat="server" class="btn btn-info" Text="Download the Sample Excel Format"
                                                                    Height="31px" />
                                                                <asp:Button ID="Button1" runat="server" class="btn btn-warning" Text="Exit" />
                                                            </td>
                                                            <td style="width: 15%">
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </div>
    <!-- /.col-lg-12 -->
    <!-- /.row -->
    </form>
    <!-- /#page-wrapper -->
</body>
</html>
