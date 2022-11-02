<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="dispatchEntry.aspx.cs" Inherits="Billing.Accountsbootstrap.dispatchEntry" %>

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
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <title>Dispatch Entry Details </title>
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <script language="javascript" type="text/javascript">
        function pageLoad() {
            ShowPopup();
            setTimeout(HidePopup, 2000);
        }

        function ShowPopup() {
            $find('modalpopup').show();
            //$get('Button1').click();
        }

        function HidePopup() {
            $find('modalpopup').hide();
            //$get('btnCancel').click();
        }
    </script>
    <style type="text/css">
         blink, .blink {
            animation: blinker 1s linear infinite;
        }

       @keyframes blinker {  
            50% { opacity: 0; }
       }
      </style>
    <script type="text/javascript">
        function Search_Gridview(strKey, strGV) {


            var strData = strKey.value.toLowerCase().split(" ");

            var tblData = document.getElementById(strGV);

            var rowData;
            for (var i = 1; i < tblData.rows.length; i++) {
                rowData = tblData.rows[i].innerHTML;
                var styleDisplay = 'none';
                for (var j = 0; j < strData.length; j++) {
                    if (rowData.toLowerCase().indexOf(strData[j]) >= 0)

                        styleDisplay = '';
                    else {
                        styleDisplay = 'none';
                        break;
                    }
                }
                tblData.rows[i].style.display = styleDisplay;
            }
        } 

    </script>
      <style>
        .chkChoice input
        {
            margin-left: -30px;
        }
        .chkChoice td
        {
            padding-left: 45px;
        }
        
        .chkChoice1 input
        {
            margin-left: -10px;
        }
        .chkChoice1 td
        {
            padding-left: 10px;
        }
    </style>
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
</head>
<body style="font-family: Calibri; font-size: medium;">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="col-lg-12">
        <div class="col-lg-6">
            <div class="panel panel-default">
                <div class="panel-heading " style="background-color: #428bca; color: White">
                    <b>Dispatch Entry Details</b></div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="col-lg-6">
                                <asp:TextBox CssClass="form-control" placeholder="Search Details.. " ID="txtsearch"
                                    onkeyup="Search_Gridview(this, 'gridview')" runat="server" MaxLength="50" Width="150px"></asp:TextBox>
                                <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                            </div>
                            <div class="col-lg-6">
                                <asp:Button ID="btnresret" runat="server" class="btn btn-warning" Text="Reset" OnClick="Btn_Reset"
                                    Width="150px" /></div>
                        </div>
                    </div>
                    <div style="height: 350px; overflow: scroll">
                        <br />
                        <asp:GridView ID="gridview" runat="server" UseAccessibleHeader="true" CssClass="mGrid"
                            AllowPaging="false" AutoGenerateColumns="false" AllowSorting="true" OnRowCommand="gvcat_RowCommand"
                            OnSorting="gridview_Sorting" OnRowDataBound="gridview_OnRowDataBound" OnRowEditing="gridview_RowEditing">
                            <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                NextPageText="Next" PreviousPageText="Previous" />
                            <Columns>
                                <asp:BoundField HeaderText="Dis.No" DataField="DispatchNo" />
                                <asp:BoundField HeaderText="Dis.Date" DataField="DispatchDate" />
                                <asp:BoundField HeaderText="Vihcl.No" DataField="VehicleNumber" />
                                <asp:BoundField HeaderText="Emp.Name" DataField="Employeename" />
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedit" ForeColor="White" CommandArgument='<%#Eval("Dispatchid") %>'
                                            CommandName="Editt" runat="server">
                                            <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" width="55px"/></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bakery Print">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btnedit1" ForeColor="White" CommandArgument='<%#Eval("Dispatchid") %>'
                                            CommandName="print" runat="server">
                                            <asp:Image ID="imdedit1" ImageUrl="~/images/print (1).png" runat="server" Width="50px" /></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Order Print">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="btneditorder" ForeColor="White" CommandArgument='<%#Eval("Dispatchid") %>'
                                            CommandName="printorder" runat="server">
                                            <asp:Image ID="imdeditorder" ImageUrl="~/images/print (1).png" runat="server"  Width="50px" /></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                               
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="panel panel-default">
                <%--   <blink> <label  style="color:Green; font-size:12px">Need To Add Branch Setting For Daily Stock Request Process.Please Fill CareFull!!!.Thank You!!!</label></blink>--%>
                <div class="panel-heading " style="background-color: #428bca; color: White">
                    <b>Dispatch Create</b></div>
                <div class="panel-body">
                    <div class="col-lg-12">
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="txtinterid" runat="server" Visible="false"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                Dispatch No</label>
                            <asp:TextBox ID="txtdispatchno" runat="server" Enabled="false" CssClass="form-control" ></asp:TextBox>
                        </div>

                        <div class="form-group">
                            <label>
                                Vehicle No</label>
                            <asp:DropDownList ID="drpvehicleno" runat="server" CssClass="form-control" ></asp:DropDownList>
                        </div>

                        <div class="form-group">
                            <label>
                                Employee Name</label>
                            <asp:DropDownList ID="drpemployee" runat="server" CssClass="form-control" ></asp:DropDownList>
                        </div>


                        <div class="form-group">
                            <label>
                                Goods Transfer Number</label>
                            <asp:CheckBoxList ID="chkgrnno" runat="server" RepeatColumns="5" CssClass="chkChoice1" >
                            </asp:CheckBoxList>
                        </div>

                        <div class="form-group">
                            <label>
                                For Order Cake</label>
                            <asp:CheckBoxList ID="chkordercake" runat="server" RepeatColumns="5" CssClass="chkChoice1" >
                            </asp:CheckBoxList>
                        </div>
                        <asp:Button ID="btnSave" runat="server" class="btn btn-success" Text="Save" OnClick="btnSave_Click"
                            ValidationGroup="val1" AccessKey="s" Width="150px" />
                        <label>
                        </label>
                        <asp:Button ID="btnexit" runat="server" class="btn btn-warning" Text="Exit" OnClick="Exit_Click"
                            Width="150px" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:Panel class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none"
        runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    Online List</div>
                <div class="TitlebarRight" onclick="$get('ButtonDeleteCancel').click();">
                </div>
            </div>
            <div class="popup_Body">
                <p>
                    Are you sure want to delete?
                    <blink> <label  style="color:Red; font-size:12px">If you Delete This Inter Branch Setting It Will Affect Your Branchs or Your Production!!!</label> </blink>
                </p>
            </div>
            <div class="popup_Buttons">
                <input id="ButtonDeleleOkay" type="button" value="Yes" />
                <input id="ButtonDeleteCancel" type="button" value="No" />
            </div>
        </div>
    </asp:Panel>
    </form>
</body>
</html>
