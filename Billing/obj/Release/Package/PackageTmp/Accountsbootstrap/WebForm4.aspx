<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm4.aspx.cs" Inherits="Billing.Accountsbootstrap.WebForm4" %>

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
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <title>Sales Return Report </title>
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
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
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <style type="text/css">
        .GroupHeaderStyle
        {
            background-color: #afc3dd;
            color: Black;
            font-weight: bold;
            text-transform: uppercase;
        }
        .SubTotalRowStyle
        {
            background-color: #cccccc;
            color: Black;
            font-weight: bold;
        }
        .GrandTotalRowStyle
        {
            background-color: #007aff;
            color: black;
            font-weight: bold;
        }
        .align1
        {
            text-align: right;
        }
        
        .myGridStyle1 tr th
        {
            padding: 8px;
            color: #afc3dd;
            background-color: #000000;
            border: 1px solid gray;
            font-family: Arial;
            font-weight: bold;
            text-align: center;
            text-transform: uppercase;
        }
        
        
        
        
        
        .myGridStyle1 tr:nth-child(even)
        {
            background-color: #ffffff;
        }
        
        
        
        .myGridStyle1 tr:nth-child(odd)
        {
            background-color: #ffffff;
        }
        
        
        
        .myGridStyle1 td
        {
            border: 1px solid gray;
            padding: 8px;
        }
    </style>
    <!-- Start Styles. Move the 'style' tags and everything between them to between the 'head' tags -->
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!--<link href="../Styles/style1.css" rel="stylesheet"/>-->
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
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
     <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Sales Return Report Grid</h1>
	    </div>
       
   
                <div class="panel-body">
                    
                            <form id="form1" runat="server">
                            <asp:UpdatePanel ID="update" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="row">
                                        
                                            <div class="form-group" id="Admin" runat="server">
                                                <label>
                                                    Select Branch</label>
                                                <asp:DropDownList CssClass="form-control" ID="ddlBranch" runat="server">
                                                    <asp:ListItem Text="KK Nagar" Value="co1"></asp:ListItem>
                                                    <asp:ListItem Text=" Byepass" Value="co2"></asp:ListItem>
                                                    <asp:ListItem Text=" BB Kulam" Value="co3"></asp:ListItem>
                                                    <asp:ListItem Text="Narayanapuram" Value="co4"></asp:ListItem>
                                                    <asp:ListItem Text="Nellai" Value="co5"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        
                                        <div class="col-lg-3">
                                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                                            </asp:ScriptManager>
                                          
                                                <b><asp:Label ID="lblFromDate" runat="server" >From Date</asp:Label></b>
                                                <asp:TextBox ID="txtFromDate" runat="server" AutoPostBack="true" CssClass="form-control center-block"
                                                    OnTextChanged="txtFromDate_TextChanged"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtFromDate"
                                                    ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                                                </asp:RangeValidator>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender1" Format="yyyy-MM-dd" TargetControlID="txtFromDate"
                                                    runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                          
                                        </div>
                                        <div class="col-lg-3">
                                           
                                                <b><asp:Label ID="lblToDate" runat="server">To Date</asp:Label></b>
                                                <asp:TextBox ID="txtToDate" runat="server" AutoPostBack="true" CssClass="form-control center-block"
                                                    OnTextChanged="txtToDate_TextChanged"></asp:TextBox>
                                                <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="txtToDate"
                                                    ErrorMessage="Please Select valid Date Thank You!!!" Type="Date">
                                                </asp:RangeValidator>
                                                <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="yyyy-MM-dd" TargetControlID="txtToDate"
                                                    runat="server" CssClass="cal_Theme1">
                                                </ajaxToolkit:CalendarExtender>
                                            
                                        </div>
                                        <div class="col-lg-6">
                                       
                                    <br />
                                         <asp:RadioButton ID="rbdReasons" runat="server" Text="Reasons" class="form-group"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdReasons_CheckedChanged" />
                                           
                                       
                                      
                                            
                                                <asp:RadioButton ID="rbdCtry" runat="server" Text="Category" class="form-group"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdCtry_CheckedChanged" />
                                            
                                       
                                       
                                           
                                                <asp:RadioButton ID="rbdProduct" runat="server" Text="Product" class="form-group"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdProduct_CheckedChanged" />
                                           
                                     <asp:Button ID="btn" runat="server" Text="Export To Excel" Visible="false" CssClass="btn btn-success pos-btn1"
                                                    OnClick="btnExport_Click" />


                                        <div id="Div1" runat="server" visible="false">
                                            <div id="Div2" runat="server" visible="false" class="form-group">
                                                <asp:RadioButton ID="rdbCustomer" runat="server" Text="Customer" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rdbCustomer_CheckedChanged" />
                                            </div>
                                        </div>
                                       
                                            <div id="Div3" runat="server" visible="false" class="form-group">
                                                <asp:RadioButton ID="rbdPayMode" runat="server" Text="Payment Mode" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdPayMode_CheckedChanged" />
                                            </div>
                                       
                                       
                                            <div runat="server" visible="false">
                                                <asp:RadioButton ID="rbproqty" runat="server" Text="Product wise Qty" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbproqty_CheckedChanged" />
                                            </div>
                                        
                                       
                                           
                                             
                                       
                                            <div id="Div5" runat="server" visible="false" class="form-group">
                                                <asp:RadioButton ID="rbdcatqty" runat="server" Text="Category wise Qty" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdcatqty_CheckedChanged" />
                                            </div>
                                        
                                       
                                            <div id="Div4" runat="server" class="form-group" visible="false">
                                                <asp:RadioButton ID="rbdBrnd" runat="server" Text="Quantity" CssClass="center-block"
                                                    AutoPostBack="true" GroupName="a" OnCheckedChanged="rbdBrnd_CheckedChanged" />
                                            
                                        </div>
                                       
                                    </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-lg-12">
                                            <div class="table-responsive panel-grid-left">
                                                
                                                            <asp:GridView ID="gridPurchase"  runat="server" EmptyDataText="Sorry Data Not Found!"
                                                              cssClass="table table-striped pos-table" AutoGenerateColumns="false" OnRowCreated="gridPurchase_RowCreated" padding="0" spacing="0" border="0"
                                                                OnRowDataBound="gridPurchase_RowDataBound">
                                                                <Columns>
                                                                    <asp:BoundField DataField="BillNo" Visible="false" />
                                                                    <asp:BoundField DataField="BillNo" HeaderText="Bill No"  />
                                                                    <asp:BoundField DataField="BillDate" HeaderText="Bill Date" 
                                                                        DataFormatString="{0:MMM-dd-yyyy}" />
                                                                    <asp:BoundField DataField="LedgerName" HeaderText="Customer"  />
                                                                    <asp:BoundField DataField="Payment_Mode" HeaderText="Payment Mode" ItemStyle-HorizontalAlign="Center" />
                                                                    <asp:BoundField DataField="category" HeaderText="Category"  />
                                                                    <asp:BoundField DataField="Definition" HeaderText="Item"  />
                                                                    <%-- <asp:BoundField DataField="BrandName" HeaderText="Brand Name" ItemStyle-HorizontalAlign="Center" />--%>
                                                                    <asp:BoundField DataField="Reasons" HeaderText="Reasons"  />
                                                                    <asp:BoundField DataField="Quantity" HeaderText="Quantity"  />
                                                                    <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" DataFormatString="{0:###,##0.00}"
                                                                        Visible="false"  />
                                                                    <asp:BoundField DataField="NetAmount" HeaderText="Amount"  />
                                                                </Columns>
                                                            </asp:GridView>
                                                        
                                                        <asp:GridView ID="gridcatqty"  runat="server" EmptyDataText="Sorry Data Not Found!"
                                                            cssClass="table table-striped pos-table" AutoGenerateColumns="false" OnRowCreated="gridcatqty_RowCreated1"
                                                            OnRowDataBound="gridcatqty_RowDataBound1">
                                                            <Columns>
                                                                <asp:BoundField DataField="category" HeaderText="Group" />
                                                                <asp:BoundField DataField="Definition" HeaderText="ItemName" />
                                                                <asp:BoundField DataField="qty" HeaderText="Quantity" ItemStyle-HorizontalAlign="Center" />
                                                            </Columns>
                                                        </asp:GridView>
                                                   
                                                        <td visible="false" id="Td1" runat="server">
                                                            Total:<label id="lblTotal" runat="server"></label>
                                                        </td>
                                                   
                                            </div>
                                        </div>
                                    </div>
                                    </div>
                                   
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gridPurchase" EventName="RowDataBound" />
                                    <asp:AsyncPostBackTrigger ControlID="gridcatqty" EventName="RowDataBound"></asp:AsyncPostBackTrigger>
                                    <asp:AsyncPostBackTrigger ControlID="gridcatqty" EventName="RowDataBound"></asp:AsyncPostBackTrigger>
                                    <asp:PostBackTrigger ControlID="btn"></asp:PostBackTrigger>
                                </Triggers>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gridcatqty" EventName="RowDataBound" />
                                </Triggers>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btn" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="update">
                                <%-- <ProgressTemplate>
            <div class="overlay">
                <div style="z-index: 100; margin-left: 50px; margin-top: 50px; opacity: 1; -moz-opacity: 1;">
                    <img alt="" src="../images/Preloader_10.gif" />
                </div>
            </div>
        </ProgressTemplate>--%>
                                <%-- for text <ProgressTemplate>
        <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0; right: 0; left: 0; z-index: 9999999; background-color: #000000; opacity: 0.7;">
            <span style="border-width: 0px; position: fixed; padding: 50px; background-color: #FFFFFF; font-size: 36px; left: 40%; top: 40%;">Loading ...</span>
        </div>
    </ProgressTemplate>--%>
                                <ProgressTemplate>
                                    <div style="position: fixed; text-align: center; height: 100%; width: 100%; top: 0;
                                        right: 0; left: 0; z-index: 9999999; opacity: 0.7;">
                                        <asp:Image ID="imgUpdateProgress" runat="server" ImageUrl="../images/Preloader_10.gif"
                                            AlternateText="Loading ..." ToolTip="Loading ..." Style="padding: 10px; position: fixed;
                                            top: 45%; left: 50%;" />
                                    </div>
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                            </form>
                       
                </div>
           
    </div>
    </div>
    </div>
    </div>
</body>
</html>
