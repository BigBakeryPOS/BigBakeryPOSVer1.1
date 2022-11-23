<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NotificationPage.aspx.cs"
    Inherits="Billing.Accountsbootstrap.NotificationPage" %>

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
    <title>Notification Alert</title>
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
    <div id="Div1" runat="server" class="col-lg-8">
              <div class="row panel-custom1">
                    <div class="panel-header">
                      <h1 class="page-header">Notification List</h1>
	                </div>
                <div class="panel-body">
                <div class="col-lg-12">
                        <div class="table-responsive panel-grid-left">
                            <asp:GridView ID="gvip" runat="server" AutoGenerateColumns="false" cssClass="table table-striped pos-table" OnRowCommand="gvcat_RowCommand" padding="0" spacing="0" border="0"  >
                                <Columns>
                                <asp:BoundField DataField="MessageTitle" HeaderText="Messgae Title" />
                                <asp:BoundField DataField="MessageContent" HeaderText="Messgae Content" />
                                <asp:BoundField DataField="Fromdate" HeaderText="From date" />
                                <asp:BoundField DataField="Todate" HeaderText="To date" />
                                <asp:BoundField DataField="IsActive" HeaderText="Is Active" />
                                 <asp:TemplateField Visible="true" ItemStyle-HorizontalAlign="Center" HeaderText="Edit">
                                                    <ItemTemplate>
                                                        <asp:LinkButton ID="btnedit" CommandArgument='<%#Eval("messageid") %>' CommandName="Edits" cssclass="btn btn-warning btn-md"
                                                            runat="server">
                                                            <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" Visible="false" />
                                                             <span class="glyphicon glyphicon-pencil" aria-hidden="true"></span>
                                                            </asp:LinkButton>
                                                        <%--<asp:LinkButton ID="btnedit" runat="server"  Text="edit"  CommandArgument='<%#Eval("categoryid") %>' CommandName="edit"></asp:LinkButton>--%>
                                                        <asp:HiddenField ID="ldgID" runat="server" Value='<%# Bind("messageid") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
              </div>
              </div>         
            </div>
           </div>
           </div>
         <div class="col-lg-4">
        <div class="panel panel-custom1">
		<div class="panel-header">
				<h1 class="page-header">Add Notification Details</h1>
		</div>
                <div class="panel-body panel-form-right">
                <div class="list-group">
                  <label>
                        Select Branch(MultiSelect)
                    </label>
                    <asp:TextBox ID="txtbranch" runat="server" onkeyup="SearchEmployees(this,'#chkbranch');"
                        CssClass="form-control"></asp:TextBox>
                        <br />
                    <asp:CheckBoxList ID="chkbranch" runat="server" >
                    </asp:CheckBoxList>
                    <br />
                    <asp:Label ID="lblmessgaeid" runat="server" Visible="false" ></asp:Label>
                    <label>
                        Message Title</label>
                    <asp:TextBox CssClass="form-control" ID="txtmsgtitle" runat="server" MaxLength="150"></asp:TextBox>
                    <br />
                    <label>
                        Message Content</label>
                    <asp:TextBox CssClass="form-control" ID="txtmessagecontent" TextMode="MultiLine"
                        runat="server" MaxLength="150"></asp:TextBox>
                    <br />
                     <label>
                        From Date</label>
                    <asp:TextBox CssClass="form-control" ID="txtfromdate" runat="server" MaxLength="150"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender1" TargetControlID="txtfromdate"
                        PopupButtonID="txtfromdate" EnabledOnClient="true" runat="server" Format="dd/MM/yyyy"
                        CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                    <asp:Label ID="Label1" runat="server" Style="color: Red"></asp:Label>
                    <br />
                    <label>
                        To Date</label>
                    <asp:TextBox CssClass="form-control" ID="txttodate" runat="server" MaxLength="150"></asp:TextBox>
                    <ajaxToolkit:CalendarExtender ID="CalendarExtender2" TargetControlID="txttodate"
                        Format="dd/MM/yyyy" PopupButtonID="txttodate" EnabledOnClient="true" runat="server"
                        CssClass="cal_Theme1">
                    </ajaxToolkit:CalendarExtender>
                    <br />
                     <label>
                        From Time
                    </label>
                    <asp:DropDownList ID="ddlTimeFrom" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="fromtime" runat="server" BackColor="Red" Font-Bold="true" ForeColor="White"
                        Visible="false"></asp:Label>
                        <br />
                          <label>
                        TO Time</label>
                    <asp:DropDownList ID="ddlTimeTo" CssClass="form-control" runat="server">
                    </asp:DropDownList>
                    <asp:Label ID="totime" runat="server" BackColor="Red" Font-Bold="true" ForeColor="White"
                        Visible="false"></asp:Label>
                        <br />
                     <label>
                        Is Active</label>
                    <asp:DropDownList ID="drpisactive" CssClass="form-control" runat="server">
                        <asp:ListItem Text="Yes" Selected="True" Value="Yes"> </asp:ListItem>
                        <asp:ListItem Text="No" Value="No"> </asp:ListItem>
                    </asp:DropDownList>
                    <br />
                     <asp:Button ID="btnadd" runat="server" class="btn btn-lg btn-primary pos-btn1" ValidationGroup="val1"
                                    Text="Save" width="150px" OnClick="addclick" />
                                <asp:Button ID="btnexit" runat="server" class="btn btn-lg btn-link" 
                                    Text="Clear" PostBackUrl="~/Accountsbootstrap/NotificationPage.aspx"  />
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
