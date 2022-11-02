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
            <div class="col-lg-12" style="">
                <div>
                    <div class="panel-body" style="">
                        <div class="row" style="">
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            <div class="row" style="">
                                <div class="col-lg-12">
                                    <div class="panel panel-default">
                                        <div class="panel-heading" style="background-color: #0071BD; color: White; text-align: left">
                                            Contact Master
                                        </div>
                                        <div class="panel-body">
                                            <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                                            <div class="col-lg-12">
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <label>
                                                            Contact Type</label>
                                                        <asp:DropDownList ID="ddlCustomerType" OnSelectedIndexChanged="customertype_chnaged"
                                                            AutoPostBack="true" runat="server" class="form-control">
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group" id="divcode" runat="server">
                                                        <label>
                                                            Code</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtcuscode" runat="server" Enabled="false"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <br />
                                                        <label>
                                                            Contact Name</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtcustomername" MaxLength="50" runat="server"
                                                            Style="text-transform: capitalize"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="reqName" ControlToValidate="txtcustomername"
                                                            ErrorMessage="Please enter your name!" Style="color: Red" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label>
                                                            Mobile No</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtmobileno" MaxLength="10" Placeholder=""
                                                            runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="mobno" ControlToValidate="txtmobileno"
                                                            ErrorMessage="Please enter your Mobile No!" Style="color: Red" /><br />
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                                            FilterType="Numbers,Custom" ValidChars=" -," TargetControlID="txtmobileno" />
                                                        <asp:RegularExpressionValidator runat="server" ID="rexNumber" ValidationGroup="val1"
                                                            ControlToValidate="txtmobileno" ValidationExpression="^[0-9]{10}$" ErrorMessage="Please enter a 10 digit number!"
                                                            Style="color: Red" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label>
                                                            Land Line No</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtphoneno" MaxLength="15" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="phono" ControlToValidate="txtphoneno"
                                                            ErrorMessage="Please enter your Phone No!" Style="color: Red" />
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                            FilterType="Numbers,Custom" ValidChars=" -," TargetControlID="txtphoneno" />
                                                    </div>
                                                    <div class="form-group">
                                                        <br />
                                                        <label>
                                                            E-mail</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtemail" placeholder="For Ex: test@gmail.com"
                                                            runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="email" ControlToValidate="txtemail"
                                                            ErrorMessage="Please enter your Email!" Style="color: Red" />
                                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator2" ValidationGroup="val1"
                                                            ControlToValidate="txtemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                            ErrorMessage="Please enter a correct Email Id!" Style="color: Red" />
                                                    </div>
                                                    <div runat="server" id="disc" visible="false" class="form-group">
                                                        <label>
                                                            Disc %</label>
                                                        <asp:TextBox ID="txtdisc" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <label>
                                                            City</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtcity" MaxLength="30" runat="server" Style="text-transform: capitalize"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="city" ControlToValidate="txtcity"
                                                            ErrorMessage="Please enter your City!" Style="color: Red" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label>
                                                            Area</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtarea" MaxLength="30" runat="server" Style="text-transform: capitalize"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="area" ControlToValidate="txtarea"
                                                            ErrorMessage="Please enter your Area!" Style="color: Red" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label>
                                                            Address</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtaddress" MaxLength="150" runat="server"
                                                            Style="text-transform: capitalize"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="address" ControlToValidate="txtaddress"
                                                            ErrorMessage="Please enter your Address!" Style="color: Red" />
                                                    </div>
                                                    <div class="form-group">
                                                        <br />
                                                        <label>
                                                            Pincode</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtpincode" MaxLength="6" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="pincode" ControlToValidate="txtpincode"
                                                            ErrorMessage="Please enter your Pin Code!" Style="color: Red" />
                                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator1" ValidationGroup="val1"
                                                            ControlToValidate="txtpincode" ValidationExpression="^[0-9]{6}$" ErrorMessage="Please enter a 6 digit pin code!"
                                                            Style="color: Red" />
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                                            FilterType="Numbers,Custom" ValidChars=" -," TargetControlID="txtpincode" />
                                                    </div>
                                                    <div class="form-group">
                                                        <label>
                                                            GST NO</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtgstno" placeholder="Enter GSTIN NO" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator1"
                                                            ControlToValidate="txtgstno" ErrorMessage="Please enter GST No!" Style="color: Red" />
                                                    </div>
                                                    <div class="form-group" id="paymentdays" runat="server" visible="false">
                                                        <label>
                                                            Payment Days</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtpaymentdays" MaxLength="30" runat="server">0</asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                            FilterType="Numbers" ValidChars="" TargetControlID="txtpaymentdays" />
                                                    </div>
                                                    <div id="Div1"  visible="true" runat="server">
                                                        <div class="form-group">
                                                            <label style="margin-left: -15px">
                                                                Opening Balance</label>
                                                            <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator2"
                                                                ControlToValidate="txtOBalance" Text="*" ErrorMessage="Please enter your opening balance amount!"
                                                                Style="color: Red" />
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                                FilterType="Numbers,Custom" ValidChars="." TargetControlID="txtOBalance" />
                                                            <asp:TextBox CssClass="form-control" ID="txtOBalance" runat="server" Width="140px"
                                                                MaxLength="8" Style="text-align: right; width: 153px; margin-left: -15px; font-weight: bold">0</asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div id="Div2" visible="true" runat="server">
                                                        <div class="form-group">
                                                            <label>
                                                                Choose Type</label>
                                                            <asp:DropDownList ID="ddlCDType" runat="server" class="form-control" Style="font-weight: bold"
                                                               Width="140px">
                                                                <asp:ListItem Text="Credit" Value="Credit Note"></asp:ListItem>
                                                                <asp:ListItem Text="Debit" Value="Debit Note"></asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-lg-2">
                                                    <div class="form-group">
                                                        <br />
                                                        <table>
                                                            <tr>
                                                                <td>
                                                                    <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Save" OnClick="Add_Click"
                                                                        Width="120px" ValidationGroup="val1" />
                                                                </td>
                                                                <td>
                                                                    &nbsp&nbsp&nbsp
                                                                </td>
                                                                <td>
                                                                    <asp:Button ID="btnexit" runat="server" class="btn btn-warning" Text="Exit" OnClick="Exit_Click"
                                                                        Width="120px" />
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div class="form-group" id="divuser" runat="server">
                                                        <label>
                                                            User Name</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtusername" placeholder="Enter UserName"
                                                            runat="server"></asp:TextBox>
                                                        <%-- <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator2"
                                                            ControlToValidate="txtusername" ErrorMessage="Please enter username!" Style="color: Red" />--%>
                                                    </div>
                                                    <div class="form-group" id="divpwd" runat="server">
                                                        <br />
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
                                                </div>
                                                <div class="col-lg-6">
                                                    <div id="Ingredient" runat="server" visible="false" class="form-group">
                                                        <label>
                                                            Select Ingredient</label>
                                                        <asp:TextBox onkeyup="Search_Gridview(this, 'griditem')" AutoComplete="Off" CssClass="form-control"
                                                            Enabled="true" ID="txtsearch" runat="server" placeholder="Search Item Text"></asp:TextBox>
                                                        <div style="overflow: scroll; height: 500px" id="Div7" class="form-group" runat="server">
                                                            <asp:GridView ID="griditem" runat="server" AutoGenerateColumns="false" Width="100%"
                                                                OnRowDataBound="GridView1_OnRowDataBound">
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
                    </div>
                </div>
            </form>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
