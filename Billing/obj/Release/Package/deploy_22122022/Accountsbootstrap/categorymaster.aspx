<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="categorymaster.aspx.cs"
    Inherits="Billing.Accountsbootstrap.categorymaster" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Create Group</title>
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
    <script type="text/javascript" language="javascript">
        function valchk() {
            if (blankchk(document.getElementById('txtcategory'), "Category")) {
                alert("true");
            }
            else {
                alert("false");
                return false;
            }
        }
    </script>
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
<body style="font-family:Calibri; font-size:medium;">
    <asp:Label runat="server" Visible="false" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" Visible="false" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
    <div class="row">
        <div class="col-lg-12">
                <div class="col-lg-12"  style="margin-top:13px">
           
        </div>
        <!-- /.col-lg-12 -->
    </div>
    <div class="row">
        <div class="col-lg-12">
        
                    <div class="row">
                      <div class="col-lg-3"></div>
                        <div class="col-lg-6">
                          <div class="panel panel-default">
               <div class="panel-heading " style="background-color:#428bca; color:White" ><b>Group Create</b></div>
                <div class="panel-body">
                  <div class="col-lg-12" >
                            <form runat="server" id="form1" method="post">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <div class="form-group">
                                <asp:TextBox CssClass="form-control" ID="txtcategoryId" runat="server" Visible="false"></asp:TextBox>
                            </div>
                            <div class="form-group">
                                <label>
                                    Group Name</label>
                                <asp:ListBox Visible="false" Style="height: 100px" runat="server" DataValueField="CategoryID"
                                    ID="listcategory" CssClass="form-control" AutoPostBack="true"></asp:ListBox>
                                <%--<onselectedindexchanged="listcategory_SelectedIndexChanged" asp:DropDownList ID="ddlcategory" CssClass="form-control"  runat="server"></asp:DropDownList>--%>
                                <asp:TextBox CssClass="form-control" ID="txtcategory" runat="server" placeholder="To Add New Category"
                                    Style="text-transform: capitalize" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="txtcat" ControlToValidate="txtcategory"
                                    ValidationGroup="val1" ErrorMessage="Please enter your Category!" Style="color: Red" />
                            </div>
                            <div class="form-group">
                                <label>
                                    Group Code</label>
                                <asp:TextBox CssClass="form-control" ID="txtcatcode" runat="server" placeholder="Enter Category Code" Width="200px"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ID="rvcatcode" ControlToValidate="txtcatcode"
                                    ValidationGroup="val1" ErrorMessage="Please enter your Category!" Style="color: Red" />
                                <label id="lblCatID" visible="false" runat="server">
                                </label>
                                <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                            </div>
                            <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Save" OnClick="Add_Click"
                                ValidationGroup="val1" AccessKey="s" Width="150px" />
                            <label>
                            </label>
                            <asp:Button ID="btnexit" runat="server" class="btn btn-warning" Text="Exit" OnClick="Exit_Click" Width="150px" />
                            </form>
                            </div>
                            </div></div>
                        </div>
                        <!-- /.col-lg-6 (nested) -->
                    </div>
                 
            <!-- /.panel -->
        </div>
        <!-- /.col-lg-12 -->
    </div>
</body>
</html>
