<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InvoiceUpload.aspx.cs"
    Inherits="Billing.Accountsbootstrap.InvoiceUpload" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Invoice Upload </title>
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
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
    <script type="text/javascript">
        function LoadDiv(url) {
            var img = new Image();

            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("imgFull");
            var imgLoader = document.getElementById("imgLoader");
            imgLoader.style.display = "block";
            img.onload = function () {
                imgFull.src = img.src;
                imgFull.style.display = "block";
                imgLoader.style.display = "none";
            };
            img.src = url;
            var width = document.body.clientWidth;
            if (document.body.clientHeight > document.body.scrollHeight) {
                bcgDiv.style.height = document.body.clientHeight + "px";
            }
            else {
                bcgDiv.style.height = document.body.scrollHeight + "px";
            }
            imgDiv.style.left = (width - 650) / 2 + "px";
            imgDiv.style.top = "20px";
            bcgDiv.style.width = "100%";

            bcgDiv.style.display = "block";
            imgDiv.style.display = "block";
            return false;
        }
        function HideDiv() {
            var bcgDiv = document.getElementById("divBackground");
            var imgDiv = document.getElementById("divImage");
            var imgFull = document.getElementById("imgFull");
            if (bcgDiv != null) {
                bcgDiv.style.display = "none";
                imgDiv.style.display = "none";
                imgFull.style.display = "none";
            }
        }
    </script>
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
    <style type="text/css"> 
         blink, .blink {
            animation: blinker 1s linear infinite;
        }

       @keyframes blinker { 
            50% { opacity: 0; }
       }
      </style>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="f1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="col-lg-12">
        <div class="col-lg-6">
            <div class="panel panel-default">
                <div class="panel-heading " style="background-color: #428bca; color: White">
                    <b>Invoice Upload </b>
                </div>
                <div class="panel-body">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="col-lg-6">
                                <asp:TextBox CssClass="form-control" ID="txtsearch" runat="server" onkeyup="Search_Gridview(this, 'gv')"
                                    placeholder="Search Bill No.." MaxLength="50" Style="width: 150px"></asp:TextBox>
                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                    FilterType="LowercaseLetters, UppercaseLetters,Numbers,Custom" ValidChars=" -"
                                    TargetControlID="txtsearch" />
                            </div>
                            <div class="col-lg-6">
                                <asp:Button ID="btnresret" runat="server" class="btn btn-warning" Text="Reset" OnClick="Btn_Reset"
                                    Width="150px" /></div>
                        </div>
                        <div class="col-lg-12">
                            <br />
                            <div style="height: 392px; overflow: scroll">
                                <asp:GridView ID="gv" runat="server" DataKeyNames="UploadId" OnRowCommand="edit"
                                    Width="100%" Font-Names="Calibri" EmptyDataText="Oops! No Activity Performed."
                                    AutoGenerateColumns="false">
                                    <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px"
                                        HorizontalAlign="Center" ForeColor="White" />
                                    <Columns>
                                        <asp:BoundField HeaderText="UomID" DataField="UploadId" Visible="false" />
                                        <asp:BoundField HeaderText="Supplier" DataField="ledgername" />
                                        <asp:BoundField HeaderText="Invoice No" DataField="InvoiceNo" />
                                        <asp:BoundField HeaderText="Branch Name" DataField="brancharea" />
                                        <asp:TemplateField ItemStyle-Width="5%" Visible="false" HeaderText="Preview Image">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl='<%# Eval("InvoiceImage")%>'
                                                    Width="50px" Height="50px" Style="cursor: pointer" OnClientClick="return LoadDiv(this.src);" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Download Here">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkDownload" runat="server" CommandName='<%# Eval("InvoiceImage") %>'
                                                    Text="D" OnClick="lnkDownload_OnClick" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="Edit" Visible="false"
                                            HeaderStyle-Font-Names="Calibri">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btnedit" CommandArgument='<%#Eval("UploadId") %>' CommandName="EditRow"
                                                    runat="server">
                                                    <asp:Image ID="imdedit" ImageUrl="~/images/edit.png" runat="server" width="55px" />
                                                </asp:LinkButton>
                                                <asp:HiddenField ID="ldgID" runat="server" Value='<%# Bind("UploadId") %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Delete" Visible="false">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="btndel" CommandArgument='<%#Eval("UploadId") %>' CommandName="Del"
                                                    runat="server">
                                                    <asp:Image ID="Image1" ImageUrl="~/images/delete.png" runat="server" /></asp:LinkButton>
                                                <asp:ImageButton ID="imgdisable1321" ImageUrl="~/images/delete.png" runat="server"
                                                    Visible="false" Enabled="false" ToolTip="Not Allow To Delete" />
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
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-6">
            <div class="panel panel-default">
                <%--  <blink> <label  style="color:Green; font-size:12px">Please Fill Unit Of Measure </label></blink>--%>
                <div class="panel-heading " style="background-color: #428bca; color: White">
                    <b>Create Invoice</b></div>
                <div class="panel-body">
                    <div class="list-group">
                        <asp:TextBox ID="txtinvoiceid" Visible="false" runat="server"></asp:TextBox>
                        <br />
                        <label>
                            Invoice Date</label>
                        <asp:TextBox CssClass="form-control" ID="txtinvoicedate" Enabled="true" runat="server"
                            TabIndex="1" placeholder="Select Date"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="CalendarExtender2" Format="dd/MM/yyyy" TargetControlID="txtinvoicedate"
                            runat="server" CssClass="cal_Theme1">
                        </ajaxToolkit:CalendarExtender>
                        <%--<ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtendername" runat="server"
                            FilterType="LowercaseLetters, UppercaseLetters,Custom,Numbers" ValidChars=" ./\!@#$%^&*,-"
                            TargetControlID="txtuom" />--%>
                        <br />
                        <label>
                            Supplier</label>
                        <asp:DropDownList ID="ddlsuplier" runat="server" TabIndex="2" CssClass="form-control">
                        </asp:DropDownList>
                        <br />
                        <label>
                            Invoice No</label>
                        <asp:TextBox ID="txtinvoiceno" runat="server" CssClass="form-control"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ID="txtinvoiceno1" ControlToValidate="txtinvoiceno"
                            ValidationGroup="val1" ErrorMessage="Please Enter your Invoice No!" Style="color: Red" />
                        <label>
                            Production Branch</label>
                        <asp:DropDownList ID="DrpProductionBranch" runat="server" CssClass="form-control">
                        </asp:DropDownList>
                        <br />
                        <label>
                            File Upload</label>
                        <asp:UpdatePanel ID="UpdatePanel" runat="server">
                            <ContentTemplate>
                                <asp:FileUpload ID="fp_Upload" runat="server" />
                                <asp:Button ID="btnUpload123" runat="server" Text="Upload" CssClass="btn btn-primary"
                                    OnClick="btnUpload_Clickimg" Width="100px" Visible="false" /><asp:Image ID="img_Photo"
                                        runat="server" Width="70px" BorderColor="1" />
                                <asp:Label ID="lblFile_Path" runat="server" Visible="false"></asp:Label>
                            </ContentTemplate>
                            <Triggers>
                                <asp:PostBackTrigger ControlID="btnUpload123" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                    <div>
                        <asp:Button ID="btnSubmit" Style="width: 150px; margin-left: 0px;" runat="server"
                            class="btn btn-success" Text="Save" OnClick="btnSubmit_Click" />
                        <asp:Button ID="btnclaear" Style="width: 150px; margin-left: 1px;" runat="server"
                            class="btn btn-warning" Text="Cancel" OnClick="btncancel_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div id="divBackground">
    </div>
    <div id="divImage">
        <table style="height: 100%; width: 100%">
            <tr>
                <td valign="middle" align="center">
                    <img id="imgLoader" alt="" src="images/loader.gif" />
                    <img id="imgFull" alt="" src="" style="display: none; height: 500px; width: 590px" />
                </td>
            </tr>
            <tr>
                <td align="center" valign="bottom">
                    <input id="btnClose" type="button" value="close" onclick="HideDiv()" />
                </td>
            </tr>
        </table>
    </div>
    </form>
    <asp:Panel class="popupConfirmation" ID="DivDeleteConfirmation" Style="display: none"
        runat="server">
        <div class="popup_Container">
            <div class="popup_Titlebar" id="PopupHeader">
                <div class="TitlebarLeft">
                    Category List</div>
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
</body>
</html>
