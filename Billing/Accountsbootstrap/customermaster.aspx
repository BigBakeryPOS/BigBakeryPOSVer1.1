<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="customermaster.aspx.cs"
    Inherits="Billing.Accountsbootstrap.AccPage" %>

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
    <title>Contact Grid</title>
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    <script type="text/javascript" language="javascript">
        function valchk() {
            if (blankchk(document.getElementById('txtcustomername'), "Customer Name")
            //&& dropdownchk(document.getElementById('ddlgroup'), "Account Group")  
        && phonechk(document.getElementById('txtmobileno'), "MobileNo") && phonechk(document.getElementById('txtphoneno'), "PhoneNo")
        && blankchk(document.getElementById('txtblnce'), "Opening Balance")
        && blankchk(document.getElementById('txtmobileno'), "MobileNo")
        && blankchk(document.getElementById('txtphoneno'), "Phone No") && blankchk(document.getElementById('txtarea'), "Area")
        && blankchk(document.getElementById('txtaddress'), "Address") && blankchk(document.getElementById('txtcity'), "City")
        && emailchk(document.getElementById('txtemail'), "Email")) {
                alert("true");
            }
            else {
                alert("false");
                return false;
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
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <link href="../css/Pos_style.css" rel="stylesheet" />
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        blink, .blink {
            animation: blinker 1s linear infinite;
        }

        @keyframes blinker {
            50% {
                opacity: 0;
            }
        }
    </style>
    <script type="text/javascript">
        function FilterIngridents(txtSearch, cblEmployees) {
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
</head>
<body style="">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" Visible="false" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
        <asp:UpdatePanel runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">

                            <div class="col-lg-4">
                                <div class="panel panel-custom1">
                                    <div class="panel-header">
                                        <h1 runat="server" id="head1" class="page-header">Add Contact</h1>
                                    </div>
                                    <div class="panel-body panel-form-right">
                                        <div class="list-group">
                                            <asp:Label ID="lblerror" runat="server" ForeColor="#CC0000"></asp:Label>

                                            <div>
                                                <label>Contact Type</label>
                                                <asp:DropDownList ID="ddlCustomerType" OnSelectedIndexChanged="customertype_chnaged"
                                                    AutoPostBack="true" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <br />
                                             <div>
                                                <label>
                                                    Company Name</label>
                                                  <asp:TextBox CssClass="form-control" ID="txtcustomername" MaxLength="50" runat="server"
                                                    Style="text-transform: capitalize"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="reqName" ControlToValidate="txtcustomername"
                                                    ErrorMessage="Please enter Company name!" Style="color: Red" />
                                               
                                            </div>
                                            <div>
                                                <label>
                                                   Primary Contact Name</label>
                                                 <asp:TextBox CssClass="form-control" ID="txtcompanyname" MaxLength="50" runat="server"
                                                    Style="text-transform: capitalize"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator4" ControlToValidate="txtcompanyname"
                                                    ErrorMessage="Please enter your Contact name!" Style="color: Red" />

                                               
                                            </div>
                                             <div>
                                                <label>
                                                   Primary Mobile No</label>
                                                <asp:TextBox CssClass="form-control" ID="txtmobileno" MaxLength="10" Placeholder=""
                                                    runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="mobno" ControlToValidate="txtmobileno"
                                                    ErrorMessage="Please enter your Mobile No!" Style="color: Red" /><br />
                                               
                                            </div>
                                            <div id="bankdetails" runat="server" visible="false">
                                             <div>
                                                <label>
                                                   Secondary Contact Name</label>
                                                <asp:TextBox CssClass="form-control" ID="txtseccontactname" MaxLength="50" runat="server"
                                                    Style="text-transform: capitalize"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="reqsecname" ControlToValidate="txtseccontactname"
                                                    ErrorMessage="Please enter your name!" Style="color: Red" Enabled="false"/>
                                            </div>
                                             <div>
                                                <label>
                                                   Secondary Mobile No</label>
                                                <asp:TextBox CssClass="form-control" ID="txtsecmobileno" MaxLength="10" Placeholder=""
                                                    runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="secmobno" ControlToValidate="txtsecmobileno"
                                                    ErrorMessage="Please enter your Secondary Mobile No!" Style="color: Red" Enabled="false"/><br />
                                               
                                            </div>
                                             <div>
                                                <label>
                                                    Bank Name</label>
                                                <asp:TextBox CssClass="form-control" ID="txtbankname" MaxLength="15" runat="server"
                                                    Style="text-transform: capitalize"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="bank" ControlToValidate="txtbankname"
                                                    ErrorMessage="Please enter your Bank Name!" Style="color: Red" Enabled="false"/>
                                            </div>
                                             <div>
                                                <label>
                                                    Branch Name</label>
                                                <asp:TextBox CssClass="form-control" ID="txtbranchname"  runat="server" 
                                                    Style="text-transform: capitalize"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="branch" ControlToValidate="txtbranchname"
                                                    ErrorMessage="Please enter your Branch Name!" Style="color: Red" Enabled="false"/>
                                            </div>
                                             <div>
                                                <label>
                                                    IFSC Code</label>
                                                <asp:TextBox CssClass="form-control" ID="txtifsccode"  runat="server" 
                                                    Style="text-transform: capitalize"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="ifsccode" ControlToValidate="txtifsccode"
                                                    ErrorMessage="Please enter your IFSC Code!" Style="color: Red" Enabled="false"/>
                                            </div>
                                             <div>
                                                <label>
                                                    Account No</label>
                                                <asp:TextBox CssClass="form-control" ID="txtAccno"  runat="server" 
                                                    Style="text-transform: capitalize"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="accno" ControlToValidate="txtAccno"
                                                    ErrorMessage="Please enter your Account Number!" Style="color: Red" Enabled="false"/>
                                            </div>
                                                </div>
                                             <div>
                                                <label>
                                                    Address</label>
                                                <asp:TextBox CssClass="form-control" ID="txtaddress" MaxLength="150" runat="server" TextMode="MultiLine"
                                                    Style="text-transform: capitalize"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="address" ControlToValidate="txtaddress"
                                                    ErrorMessage="Please enter your Address!" Style="color: Red" Enabled="false"/>
                                            </div>
                                            <div>
                                                <label>
                                                    Area</label>
                                                <asp:TextBox CssClass="form-control" ID="txtarea" MaxLength="30" runat="server" Style="text-transform: capitalize"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator3" ControlToValidate="txtarea"
                                                    ErrorMessage="Please enter your Area!" Style="color: Red" Enabled="false"/>
                                            </div>
                                            <div>
                                                <label>
                                                    City</label>
                                                <asp:TextBox CssClass="form-control" ID="txtcity" MaxLength="30" runat="server" Style="text-transform: capitalize"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="city" ControlToValidate="txtcity"
                                                    ErrorMessage="Please enter your City!" Style="color: Red" Enabled="false"/>
                                            </div>
                                            <div>
                                                <label>
                                                    Pincode</label>
                                                <asp:TextBox CssClass="form-control" ID="txtpincode" MaxLength="6" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="pincode" ControlToValidate="txtpincode"
                                                    ErrorMessage="Please enter your Pin Code!" Style="color: Red" Enabled="false"/>
                                                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ValidationGroup="val1"
                                                    ControlToValidate="txtpincode" ValidationExpression="^[0-9]{6}$" ErrorMessage="Please enter a 6 digit pin code!"
                                                    Style="color: Red" Enabled="false"/>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                    FilterType="Numbers,Custom" ValidChars=" -," TargetControlID="txtpincode" />
                                            </div>
                                            <div id="divcode" runat="server" visible="false">
                                                <label>Code</label>
                                                <asp:TextBox CssClass="form-control" ID="txtcuscode" runat="server" Enabled="true"></asp:TextBox>

                                                 <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                    FilterType="Numbers,Custom" ValidChars=" -," TargetControlID="txtmobileno" />
                                                <asp:RegularExpressionValidator runat="server" ID="rexNumber" ValidationGroup="val1"
                                                    ControlToValidate="txtmobileno" ValidationExpression="^[0-9]{10}$" ErrorMessage="Please enter a 10 digit number!"
                                                    Style="color: Red" Enabled="false"/>

                                            </div>
                                            <div runat="server" visible="false">
                                                <label>
                                                    Land Line No</label>
                                                <asp:TextBox CssClass="form-control" ID="txtphoneno" MaxLength="15" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="phono" ControlToValidate="txtphoneno"
                                                    ErrorMessage="Please enter your Phone No!" Style="color: Red" Enabled="false"/>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                    FilterType="Numbers,Custom" ValidChars=" -," TargetControlID="txtphoneno" />
                                            </div>


                                            <div id="paymentdays" runat="server" visible="false">
                                                <label>
                                                    Payment Days</label>
                                                <asp:TextBox CssClass="form-control" ID="txtpaymentdays" MaxLength="30" runat="server">0</asp:TextBox>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                    FilterType="Numbers" ValidChars="" TargetControlID="txtpaymentdays" />
                                            </div>

                                            <div id="Div1" visible="true" runat="server">

                                                <label>
                                                    GST NO</label>
                                                <asp:TextBox CssClass="form-control" ID="txtgstno" placeholder="Enter GSTIN NO" runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator1"
                                                    ControlToValidate="txtgstno" ErrorMessage="Please enter GST No!" Style="color: Red" Enabled="false"/>


                                            </div>

                                            <div>

                                                <label>
                                                    E-mail</label>
                                                <asp:TextBox CssClass="form-control" ID="txtemail" placeholder="For Ex: test@gmail.com"
                                                    runat="server"></asp:TextBox>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="email" ControlToValidate="txtemail"
                                                    ErrorMessage="Please enter your Email!" Style="color: Red" Enabled="false"/>
                                                <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator2" ValidationGroup="val1"
                                                    ControlToValidate="txtemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                    ErrorMessage="Please enter a correct Email Id!" Style="color: Red" Enabled="false"/>
                                            </div>

                                            <div>
                                                <label>
                                                    Opening Balance</label>
                                                <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator2"
                                                    ControlToValidate="txtOBalance" Text="*" ErrorMessage="Please enter your opening balance amount!"
                                                    Style="color: Red" Enabled="false"/>
                                                <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                    FilterType="Numbers,Custom" ValidChars="." TargetControlID="txtOBalance" />
                                                <asp:TextBox CssClass="form-control" ID="txtOBalance" runat="server"
                                                    MaxLength="8">0</asp:TextBox>
                                            </div>
                                            <br />
                                            

                                            <div id="Div2" visible="true" runat="server">
                                                <div class="form-group">
                                                    <label>
                                                        Choose Type</label>
                                                    <asp:DropDownList ID="ddlCDType" runat="server" class="form-control" Style="font-weight: bold">
                                                        <asp:ListItem Text="Credit" Value="Credit Note"></asp:ListItem>
                                                        <asp:ListItem Text="Debit" Value="Debit Note"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                             <div id="Div3" visible="true" runat="server">
                                                <div class="form-group">
                                                    <label>
                                                        Province</label>
                                                    <asp:DropDownList ID="drpProvince" runat="server" class="form-control" Style="font-weight: bold">
                                                         <asp:ListItem Text="Intra State(CGST/SGST)" Value="Inner"></asp:ListItem>
                                                        <asp:ListItem Text="Inter State(IGST)" Value="Outer"></asp:ListItem>
                                                       
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div runat="server" id="disc" visible="false" class="form-group">
                                                <label>
                                                    Disc %</label>
                                                <asp:TextBox ID="txtdisc" runat="server" CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="form-group" id="divuser" runat="server">
                                                <label>
                                                    User Name</label>
                                                <asp:TextBox CssClass="form-control" ID="txtusername" placeholder="Enter UserName"
                                                    runat="server"></asp:TextBox>
                                                <%-- <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator2"
                                                            ControlToValidate="txtusername" ErrorMessage="Please enter username!" Style="color: Red" />--%>
                                            </div>



                                            <div id="divpwd" runat="server">
                                                <label>
                                                    Password</label>
                                                <asp:TextBox CssClass="form-control" ID="txtpassword" placeholder="Enter Password"
                                                    runat="server"></asp:TextBox>
                                                <%--  <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator3"
                                                            ControlToValidate="txtgstno" ErrorMessage="Please enter Passwrdo!" Style="color: Red" />--%>
                                            </div>




                                            <div class="form-group" id="divbranch" runat="server">
                                                <br />
                                                <label>
                                                    Branch</label>
                                                <asp:DropDownList ID="ddlbranch" runat="server" class="form-control">
                                                </asp:DropDownList>
                                            </div>




                                            <div class="form-group">
                                                <asp:Button ID="btnadd" runat="server" class="btn btn-lg btn-primary pos-btn1" Text="Save" OnClick="Add_Click"
                                                    Width="150px" ValidationGroup="val1" />
                                                <asp:Button ID="btnexit" runat="server" class="btn btn-lg btn-link" Text="Clear" OnClick="Exit_Click"
                                                    Width="150px" />
                                            </div>

                                        </div>

                                    </div>
                                </div>
                            </div>
                            <div class="col-lg-8">
                                <div class="row panel-custom1">
                                    <div class="panel-header">
                                        <h1 id="head2" runat="server" class="page-header">Contact Master</h1>
                                    </div>
                                    <div class="panel-body">

                                        <div class="col-md-4">
                                            <div class="form-group has-feedback">
                                                <asp:TextBox onkeyup="Search_Gridview(this, 'griditem')" AutoComplete="Off" CssClass="form-control" Enabled="true" ID="txtsearch" runat="server" placeholder="Search Item Text"></asp:TextBox>
                                                <span class="glyphicon glyphicon-search form-control-feedback"></span>
                                            </div>
                                        </div>


                                        <div class="col-lg-12">
                                            <label>Select Ingredient</label>

                                            <div class="table-responsive panel-grid-left">

                                                <div id="Ingredient" runat="server" visible="false" class="form-group">

                                                    <asp:Label ID="srch" Visible="false" runat="server"></asp:Label>

                                                    <asp:GridView ID="griditem" runat="server" AutoGenerateColumns="false" Width="100%" CssClass="table table-striped pos-table"
                                                        OnRowDataBound="GridView1_OnRowDataBound" padding="0" spacing="0" border="0">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Allow Item">
                                                                <ItemTemplate>
                                                                    <asp:CheckBox ID="chkitem" runat="server" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Item Name">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblitemid" runat="server" Text='<%#Eval("IngridID") %>' Visible="false"></asp:Label>
                                                                    <asp:Label ID="lblitemname" Font-Bold="true" runat="server" Text='<%#Eval("IngredientName") %>'
                                                                        Visible="true"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Print Name">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtitemprintname" Width="13pc" CssClass="form-control" runat="server"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:BoundField HeaderText="MRP" DataField="Rate" DataFormatString="{0:N2}" ItemStyle-Width="300px" />
                                                            <asp:TemplateField HeaderText="Rate">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtRate" Width="13pc" CssClass="form-control" runat="server"></asp:TextBox>
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
                        </div>
                    </div>
                </div>
                </form>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
