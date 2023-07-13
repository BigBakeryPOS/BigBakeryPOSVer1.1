<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="itempage.aspx.cs" Inherits="Billing.Accountsbootstrap.itempage" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<!DOCTYPE html>
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Item Details</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <script type="text/javascript" language="javascript">
        function valchk() {
            if (dropdownchk(document.getElementById('ddlcategory'), "Select Category")
                //&& dropdownchk(document.getElementById('ddlgroup'), "Account Group")  
                && blankchk(document.getElementById('txtdescription'), "Description")) {
                alert("true");
            }
            else {
                alert("false");
                return false;
            }
        }


    </script>
    <script type="text/javascript">
        function SearchEmployees(txtSearch, cblEmployees) {
            if ($(txtSearch).val() != "") {
                var count = 0;
                $(cblEmployees).children('tbody').children('tr').each(function () {
                    var match = false;
                    $(this).children('td').children('label').each(function () {
                        if ($(this).text().toUpperCase().indexOf($(txtSearch).val().toUpperCase()) > -1)
                            match = true;
                    });
                    if (match) {
                        $(this).show();
                        count++;
                    }
                    else { $(this).hide(); }
                });
                $('#spnCount').html((count) + ' match');
            }
            else {
                $(cblEmployees).children('tbody').children('tr').each(function () {
                    $(this).show();
                });
                $('#spnCount').html('');
            }
        }
    </script>
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
    <script type="text/javascript">
        function myFunction() {
            window.open("http://localhost:57111/Accountsbootstrap/customermaster.aspx?Mode=Vendor", "Popup", 'width=300,height=500,left=100,top=100,resizable=yes,modal=yes,center=yes');
        }
    </script>
    <style type="text/css">
        p.uppercase {
            text-transform: uppercase;
        }

        p.lowercase {
            text-transform: lowercase;
        }

        p.capitalize {
            text-transform: capitalize;
        }
    </style>
    <style type="text/css">
        blink, .blink {
            animation: blinker 3s linear infinite;
        }

        @keyframes blinker {
            50% {
                opacity: 0;
            }
        }
    </style>
    <script type="text/javascript">
        function ValidateCheckBoxList(sender, args) {
            var checkBoxList = document.getElementById("<%=chkbranch.ClientID %>");
            var checkboxes = checkBoxList.getElementsByTagName("input");
            var isValid = false;
            for (var i = 0; i < checkboxes.length; i++) {
                if (checkboxes[i].checked) {
                    isValid = true;
                    break;
                }
            }
            args.IsValid = isValid;
        }
    </script>
</head>
<body style="">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" Visible="false" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" Visible="false" ForeColor="White" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <div class="row">
        <form id="Form1" runat="server" method="post">
            <div class="col-lg-12">
                <div class="panel panel-custom1">
                    <%--            <blink> <label  style="color:Green; font-size:12px">Please Fill Item Name and Relevant Information. Note: Please Enter Rate Without Tax Because it's Tax Inclusive </label></blink>--%>
                    <div class="panel-header">
                        <h1 class="page-header">Add Item</h1>
                    </div>
                    <div class="panel-body">
                        <asp:ScriptManager ID="sc" runat="server">
                        </asp:ScriptManager>
                        <div style="display: none">
                            <%--  <blink><label style="color:Red; font-size:10px;>Please Be CareFul.Selecting Below Multiselect CheckBox </label></blink>--%>
                            <div class="form-group">
                                <label>
                                    Select Branch(MultiSelect)
                                </label>
                                <asp:TextBox ID="txtbranch" runat="server" Visible="false" onkeyup="SearchEmployees(this,'#chkbranch');"
                                    CssClass="form-control"></asp:TextBox>
                                <asp:CheckBoxList ID="chkbranch" runat="server">
                                </asp:CheckBoxList>
                                <asp:CustomValidator ID="CustomValidator1" ErrorMessage="Please select at least one item."
                                    ForeColor="Red" ClientValidationFunction="ValidateCheckBoxList" runat="server" />
                            </div>
                            <div class="form-group" style="display: none">
                                <label>
                                    Select Sub Category(MultiSelect)
                                </label>
                                <asp:TextBox ID="TextBox1" runat="server" onkeyup="SearchEmployees(this,'#chksubcategory');"
                                    CssClass="form-control"></asp:TextBox>
                                <asp:CheckBoxList ID="chksubcategory" runat="server">
                                </asp:CheckBoxList>
                            </div>
                        </div>


                        <div class="col-lg-3">
                            <div class="list-group">
                                <label>Item Type</label>
                                <asp:RadioButtonList ID="rdbitemtype" runat="server" RepeatColumns="3" OnSelectedIndexChanged="rdbitemtype_click" AutoPostBack="true">
                                    <asp:ListItem Text="Food Item (POS)" Selected="True" Value="F"></asp:ListItem>
                                    <asp:ListItem Text="Order Form Item" Value="O"></asp:ListItem>
                                </asp:RadioButtonList>
                                <br />
                                <label>Select Category</label>
                                <asp:Label ID="lblitemid" runat="server" Visible="false"></asp:Label>
                                <asp:DropDownList runat="server" ID="ddlcategory" class="form-control" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                <br />
                                <%-- <p class="help-block">Select Your Category</p>--%>
                                <label>Select Sub Category</label>
                                <asp:DropDownList runat="server" ID="drpsubcategory" class="form-control">
                                </asp:DropDownList>
                                <div runat="server" visible="false">

                                    <label>Category Code</label>
                                    <asp:TextBox CssClass="form-control" ID="txtcatdescription" runat="server" MaxLength="150"
                                        Style="text-transform: capitalize" Enabled="false"></asp:TextBox>
                                </div>
                                <br />
                                <label>Item Name</label>
                                <asp:TextBox CssClass="form-control" ID="txtdescription" runat="server" MaxLength="150"
                                    Style="text-transform: capitalize;"></asp:TextBox>
                                <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                                <br />

                                <label>Print Item Name</label>
                                <asp:TextBox CssClass="form-control" ID="txtprintitemname" runat="server" MaxLength="150"></asp:TextBox>
                                <br />

                                <label>Serial No</label>
                                <asp:TextBox CssClass="form-control" ID="txtSerial" runat="server" MaxLength="150"></asp:TextBox>
                                <br />

                                <label>HSN Code</label>
                                <asp:TextBox CssClass="form-control" ID="txtHSNCode" runat="server" MaxLength="150"></asp:TextBox>
                                <br />



                                <%--<button type="submit" class="btn btn-success" onclick="Add_Click">Add</button>--%>
                            </div>
                        </div>


                        <div class="col-lg-3">
                            <div class="list-group">
                                <asp:TextBox CssClass="form-control" ID="txtSerialNo" runat="server" Visible="false"
                                    MaxLength="150">0</asp:TextBox>
                                <asp:TextBox CssClass="form-control" ID="txtSize" runat="server" Visible="false"
                                    MaxLength="150">0</asp:TextBox>
                                <label>
                                    Default Currency</label><br />
                                <asp:Label ID="lbldefaultcurrencyid" runat="server" Text="0" Visible="false"></asp:Label>
                                <asp:Label ID="lbldefaultcurrencyname" runat="server"></asp:Label>
                                <br />
                                <br />

                                <div class="form-group" id="purchase" runat="server" visible="false">
                                    <label>
                                        Expiry Date Required</label>
                                    <asp:CheckBox ID="chkPurchsse" runat="server" />
                                </div>

                                <label>
                                    UOM
                                </label>
                                <asp:DropDownList ID="ddluom" runat="server" CssClass="form-control">
                                </asp:DropDownList>
                                <br />
                                <label>
                                    Minimum Stock Alert
                                </label>
                                <asp:TextBox CssClass="form-control" ID="txtminumumstock" runat="server" MaxLength="150">0</asp:TextBox>
                                <br />

                                <label>
                                    Image Upload</label>
                                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                    <ContentTemplate>
                                        <asp:FileUpload ID="fp_Upload" runat="server" Style="display: inline" Width="45%" />
                                        <asp:Button ID="btnUpload123" runat="server" Text="Upload" CssClass="btn btn-danger pos-btn1"
                                            OnClick="btnUpload_Clickimg" /><asp:Image ID="img_Photo" runat="server"
                                                Width="5pc" BorderColor="1" />
                                        <asp:Label ID="lblFile_Path" runat="server" Visible="false"></asp:Label>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:PostBackTrigger ControlID="btnUpload123" />
                                    </Triggers>
                                </asp:UpdatePanel>

                                <br />

                                <label>
                                    Food type
                                </label>
                                <asp:DropDownList ID="drpfoodtype" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="VEG" Value="VEG"></asp:ListItem>
                                    <asp:ListItem Text="NON-VEG" Value="NON-VEG"></asp:ListItem>
                                </asp:DropDownList>
                                <br />

                                <label>
                                    Bar Code
                                </label>
                                <asp:TextBox CssClass="form-control" ID="txtBarcode" runat="server"></asp:TextBox>
                                <br />
                                <div id="Div1" runat="server" visible="true" class="form-group">
                                    <label>
                                        Expiry Day(In Days) :
                                    </label>
                                    <asp:TextBox CssClass="form-control" ID="txtexpday" Enabled="true" Text="0"
                                        runat="server" MaxLength="150"></asp:TextBox>
                                    <ajaxToolkit:FilteredTextBoxExtender ID="ftxtex" runat="server" TargetControlID="txtexpday"
                                        FilterType="Custom,Numbers" ValidChars="." />
                                </div>
                                <br />
                                <label>
                                    Description
                                </label>
                                <asp:TextBox CssClass="form-control" ID="txtDetails" TextMode="MultiLine" runat="server"></asp:TextBox>
                            </div>
                        </div>


                        <div class="col-lg-4">
                            <table runat="server" width="100%">

                                <tr id="trfood" runat="server" visible="true">
                                    <td>
                                        <%--<div class="list-group">--%>
                                        <div class="form-group">
                                            <label>
                                                Rate Type
                                            </label>
                                            <asp:DropDownList ID="drpratetype" runat="server" CssClass="form-control" OnSelectedIndexChanged="mrp_calculation"
                                                AutoPostBack="true">
                                                <asp:ListItem Text="Inclusive of Tax" Selected="True" Value="I"></asp:ListItem>
                                                <asp:ListItem Text="Exclusive of Tax"  Value="E"></asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label>
                                                CESS (if applicable)
                                            </label>
                                            <asp:CheckBox ID="chkcess" runat="server" OnCheckedChanged="chk_cess" AutoPostBack="true" />
                                        </div>

                                        <div id="defmrp" runat="server" visible="false" class="form-group">
                                            <label>
                                                MRP Price :
                                        <asp:Label ID="lblpricename" Text="" runat="server"></asp:Label>
                                            </label>
                                            <asp:TextBox CssClass="form-control" ID="txtMRPPrice" Enabled="false" AutoPostBack="true"
                                                OnTextChanged="mrp_calculation" runat="server" MaxLength="150"></asp:TextBox>
                                        </div>
                                        <br />
                                        <div id="mrp1" runat="server" visible="false" class="form-group">
                                            <label>
                                                MRP Price :
                                        <asp:Label ID="lblpricename1" Text="" runat="server"></asp:Label>
                                            </label>
                                            <asp:TextBox CssClass="form-control" ID="txtMRPPrice1" Enabled="false" AutoPostBack="true"
                                                OnTextChanged="mrp_calculation" runat="server" MaxLength="150"></asp:TextBox>
                                        </div>
                                        <br />
                                        <div id="mrp2" runat="server" visible="false" class="form-group">
                                            <label>
                                                MRP Price :
                                        <asp:Label ID="lblpricename2" Text="" runat="server"></asp:Label>
                                            </label>
                                            <asp:TextBox CssClass="form-control" ID="txtMRPPrice2" Enabled="false" AutoPostBack="true"
                                                OnTextChanged="mrp_calculation" runat="server" MaxLength="150"></asp:TextBox>
                                        </div>
                                        <br />
                                        <div id="mrp3" runat="server" visible="false" class="form-group">
                                            <label>
                                                MRP Price :
                                        <asp:Label ID="lblpricename3" Text="KSH" runat="server"></asp:Label>
                                            </label>
                                            <asp:TextBox CssClass="form-control" ID="txtMRPPrice3" Enabled="false" AutoPostBack="true"
                                                OnTextChanged="mrp_calculation" runat="server" MaxLength="150"></asp:TextBox>
                                        </div>
                                        <br />
                                        <div id="mrp4" runat="server" visible="false" class="form-group">
                                            <label>
                                                MRP Price :
                                        <asp:Label ID="lblpricename4" runat="server"></asp:Label>
                                            </label>
                                            <asp:TextBox CssClass="form-control" ID="txtMRPPrice4" Enabled="false" AutoPostBack="true"
                                                OnTextChanged="mrp_calculation" runat="server" MaxLength="150"></asp:TextBox>
                                        </div>
                                        <br />
                                        <div id="mrp5" runat="server" visible="false" class="form-group">
                                            <label>
                                                MRP Price :
                                        <asp:Label ID="lblpricename5" runat="server"></asp:Label>
                                            </label>
                                            <asp:TextBox CssClass="form-control" ID="txtMRPPrice5" Enabled="false" AutoPostBack="true"
                                                OnTextChanged="mrp_calculation" runat="server" MaxLength="150"></asp:TextBox>
                                        </div>
                                        <br />

                                        <div class="form-group" runat="server" visible="false">
                                            <label>
                                                Upload Data From Excel
                                            </label>
                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                <ContentTemplate>
                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                    <asp:Button ID="btnAsyncUpload" Visible="false" runat="server" Text="Async_Upload"
                                                        OnClick="Async_Upload_File" />
                                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" OnClick="Upload_File" />
                                                </ContentTemplate>
                                                <Triggers>
                                                    <asp:AsyncPostBackTrigger ControlID="btnAsyncUpload" EventName="Click" />
                                                    <asp:PostBackTrigger ControlID="btnUpload" />
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <asp:GridView ID="GridView2" runat="server">
                                                <Columns>
                                                    <asp:TemplateField HeaderText="Rate Name">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblCategory" runat="server" Text='<%#Eval("Category") %>'></asp:Label>
                                                            <asp:HiddenField ID="hideCategoryID" runat="server" Value='<%#Eval("CategoryID") %>' />
                                                            <asp:HiddenField ID="hideCategoryUserID" runat="server" Value='<%#Eval("CategoryUserID") %>' />
                                                            <asp:HiddenField ID="hideUOMID" runat="server" Value='<%#Eval("UOMID") %>' />
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Enter Rate">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtrate" runat="server" CssClass="form-control"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>






                                        <%--</div>--%>
                                    </td>
                                    <td style="width: 10px"></td>
                                    <td>
                                        <div id="Div2" runat="server" visible="true" class="form-group">
                                            <label>
                                                Tax
                                            </label>
                                            <asp:DropDownList CssClass="form-control" ID="ddltax" AutoPostBack="true" OnTextChanged="mrp_calculation"
                                                runat="server">
                                            </asp:DropDownList>

                                        </div>

                                        <div id="divcess" runat="server" visible="false"  class="form-group">
                                            <label>
                                                CESS %
                                            </label>
                                            <asp:TextBox ID="txtcessper" Text="0" runat="server" CssClass="form-control" AutoPostBack="true" OnTextChanged="mrp_calculation" ></asp:TextBox>
                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server" TargetControlID="txtcessper"
                                        FilterType="Custom,Numbers" ValidChars="." />
                                        </div>

                                        <div id="defrate" runat="server" visible="false" class="form-group">
                                            <label>
                                                Rate *(Exclusive of Tax)
                                            </label>
                                            <asp:TextBox ID="txtRate" runat="server" Enabled="false" AutoPostBack="true" OnTextChanged="mrp_calculation"
                                                CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <br />
                                        <div id="rate1" runat="server" visible="false" class="form-group">
                                            <label>
                                                Rate *(Exclusive of Tax)
                                            </label>
                                            <asp:TextBox ID="txtRate1" runat="server" Enabled="false" AutoPostBack="true" OnTextChanged="mrp_calculation"
                                                CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <br />
                                        <div id="rate2" runat="server" visible="false" class="form-group">
                                            <label>
                                                Rate *(Exclusive of Tax)
                                            </label>
                                            <asp:TextBox ID="txtRate2" runat="server" Enabled="false" AutoPostBack="true" OnTextChanged="mrp_calculation"
                                                CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <br />
                                        <div id="rate3" runat="server" visible="false" class="form-group">
                                            <label>
                                                Rate *(Exclusive of Tax)
                                            </label>
                                            <asp:TextBox ID="txtRate3" runat="server" Enabled="false" AutoPostBack="true" OnTextChanged="mrp_calculation"
                                                CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <br />
                                        <div id="rate4" runat="server" visible="false" class="form-group">
                                            <label>
                                                Rate *(Exclusive of Tax)
                                            </label>
                                            <asp:TextBox ID="txtRate4" runat="server" Enabled="false" AutoPostBack="true" OnTextChanged="mrp_calculation"
                                                CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <br />
                                        <div id="rate5" runat="server" visible="false" class="form-group">
                                            <label>
                                                Rate *(Exclusive of Tax)
                                            </label>
                                            <asp:TextBox ID="txtRate5" runat="server" Enabled="false" AutoPostBack="true" OnTextChanged="mrp_calculation"
                                                CssClass="form-control"></asp:TextBox>
                                        </div>
                                        <br />

                                    </td>
                                </tr>

                                <tr id="trflavour" runat="server" visible="false">
                                    <td colspan="3">
                                        <asp:GridView ID="gridflavourrate" runat="server" AutoGenerateColumns="false">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Select Item ">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="idcheck" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Flavour Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblFlavourName" runat="server" Text='<%#Eval("FlavourName") %>'></asp:Label>
                                                        <asp:Label ID="lblflavourid" runat="server" Text='<%#Eval("flavourid") %>'></asp:Label>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Mrp">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtmrprate" OnTextChanged="gridmrp_calculation" AutoPostBack="true" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Rate">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtrate" OnTextChanged="gridmrp_calculation" AutoPostBack="true" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>

                                <tr id="tr1" runat="server" visible="true">
                                    <td>
                                        <asp:Button ID="btnadd" runat="server" class="btn btn-lg btn-primary pos-btn1" Text="Save" OnClick="btnadd_Click" Width="150px" /></td>
                                    <td style="width: 10px"></td>
                                    <td>
                                        <asp:Button ID="btnexit" runat="server" class="btn btn-lg btn-warning pos-btn3" Text="Clear" OnClick="btnexit_Click" Width="150px" /></td>
                                </tr>
                            </table>



                        </div>




                        <div class="col-lg-2">
                            <label>
                                Production UOM
                            </label>
                            <asp:DropDownList ID="drpproductionuom" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                            <br />
                            <label>
                                Received Qty
                            </label>
                            <asp:TextBox ID="txtreceivedqty" runat="server" CssClass="form-control"></asp:TextBox>
                            <br />
                            <label>
                                Display Online
                            </label>
                            <asp:RadioButtonList ID="raddisplay" runat="server" RepeatColumns="2">
                                <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <label>Qty Type</label>
                            <asp:RadioButtonList ID="radbnsalestype" runat="server" RepeatColumns="3">
                                <asp:ListItem Text="Each" Selected="True" Value="E"></asp:ListItem>
                                <asp:ListItem Text="Decimal Value" Value="D"></asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <label>Addon's</label>
                            <asp:RadioButtonList ID="rdbaddon" runat="server" RepeatColumns="3">
                                <asp:ListItem Text="Yes" Selected="True" Value="Y"></asp:ListItem>
                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <label>Maintenance Stock </label>
                            <asp:RadioButtonList ID="rdbmaintenancestock" runat="server" RepeatColumns="3">
                                <asp:ListItem Text="Yes" Selected="True" Value="Y"></asp:ListItem>
                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <label>Kot Required </label>
                            <asp:RadioButtonList ID="rdbkotrequired" runat="server" RepeatColumns="3">
                                <asp:ListItem Text="Yes" Selected="True" Value="Y"></asp:ListItem>
                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <label>Cooking instruction Required </label>
                            <asp:RadioButtonList ID="rdbcookinginstruction" runat="server" RepeatColumns="3">
                                <asp:ListItem Text="Yes" Selected="True" Value="Y"></asp:ListItem>
                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                            </asp:RadioButtonList>
                            <br />
                            <label>Is Barcode Required </label>
                            <asp:RadioButtonList ID="rdbbarcode" runat="server" RepeatColumns="3">
                                <asp:ListItem Text="Yes" Selected="True" Value="Y"></asp:ListItem>
                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>

                        <div runat="server" visible="false" class="col-lg-3">
                            <div class="form-group">
                                <label>
                                    Enter Rate Setting
                                </label>
                                <div class="table-responsive panel-grid-left">

                                    <asp:GridView ID="gridratesetting" runat="server" AllowPaging="false" Width="100%" AutoGenerateColumns="false"
                                        CssClass="table table-striped pos-table" EmptyDataText="No Records Found" AllowSorting="true"
                                        padding="0" spacing="0" border="0">
                                        <Columns>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                        <!-- /.col-lg-6 (nested) -->
                    </div>
                    <!-- /.row (nested) -->
                </div>
                <!-- /.panel-body -->
            </div>
        </form>
        <!-- /.panel -->
    </div>
    <!-- /.col-lg-12 -->
    </div>
    <!-- /.row -->
    </div>
    <!-- /#page-wrapper -->
</body>
</html>
