<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bankmaster.aspx.cs"
    Inherits="Billing.Accountsbootstrap.Bankmaster" %>

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
            <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
               <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Contact Master</h1>
	    </div>
                   
                            <asp:ScriptManager ID="ScriptManager1" runat="server">
                            </asp:ScriptManager>
                            
                                        <div class="panel-body">
                                            <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                                            <div class="col-lg-3">
                                           <div class="list-group">
                                                   <%-- <div class="form-group">
                                                        <label>
                                                            Contact Type</label>
                                                        <asp:DropDownList ID="ddlCustomerType" OnSelectedIndexChanged="customertype_chnaged"
                                                            AutoPostBack="true" runat="server" class="form-control">
                                                        </asp:DropDownList>
                                                    </div>--%>
                                                     <div class="form-group" id="divcode" runat="server">
                                                        <label>
                                                            Code</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtcuscode" runat="server" Enabled="false"></asp:TextBox>
                                                    </div>
                                                   
                                                        <label>
                                                            Bank Name</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtcustomername" MaxLength="50" runat="server"
                                                            Style="text-transform: capitalize"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="reqName" ControlToValidate="txtcustomername"
                                                            ErrorMessage="Please enter Bank name!" Style="color: Red" />
                                                  <br />
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
                                                    <br />
                                                    <div runat="server" id="disc" visible="false" >
                                                        <label>
                                                            Disc %</label>
                                                        <asp:TextBox ID="txtdisc" runat="server" CssClass="form-control"></asp:TextBox>
                                                    </div>
                                                  

                                                     
                                                            <label>
                                                                Opening Balance</label>
                                                            <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator2"
                                                                ControlToValidate="txtOBalance" Text="*" ErrorMessage="Please enter your opening balance amount!"
                                                                Style="color: Red" />
                                                            <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender5" runat="server"
                                                                FilterType="Numbers,Custom" ValidChars="." TargetControlID="txtOBalance" />
                                                            <asp:TextBox CssClass="form-control" ID="txtOBalance" runat="server" 
                                                                MaxLength="8" >0</asp:TextBox>
                                                       
                                                   
                                                   <br /> <br />
                                                    
                                                            <label>
                                                                Choose Type</label>
                                                            <asp:DropDownList ID="ddlCDType" runat="server" class="form-control" Style="font-weight: bold"
                                                               >
                                                                <asp:ListItem Text="Credit" Value="Credit Note"></asp:ListItem>
                                                                <asp:ListItem Text="Debit" Value="Debit Note"></asp:ListItem>
                                                            </asp:DropDownList>
                                                    <br /> <br />
                                                     <label>
                                                            Land Line No</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtphoneno" MaxLength="15" runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="phono" ControlToValidate="txtphoneno"
                                                            ErrorMessage="Please enter your Phone No!" Style="color: Red" />
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                                            FilterType="Numbers,Custom" ValidChars=" -," TargetControlID="txtphoneno" />
                                                   <br /> <br />
                                                        <label>
                                                            City</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtcity" MaxLength="30" runat="server" Style="text-transform: capitalize"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="city" ControlToValidate="txtcity"
                                                            ErrorMessage="Please enter your City!" Style="color: Red" />
                                                       
                                                </div>
                                                </div>
                                                 <div class="col-lg-3">
                                                     <div class="list-group">
                                                       
                                                  
                                                        <label>
                                                            Area</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtarea" MaxLength="30" runat="server" Style="text-transform: capitalize"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="area" ControlToValidate="txtarea"
                                                            ErrorMessage="Please enter your Area!" Style="color: Red" />
                                                    <br />
                                                   
                                            
                                                        <label>
                                                            Address</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtaddress" MaxLength="150" runat="server"
                                                            Style="text-transform: capitalize"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="address" ControlToValidate="txtaddress"
                                                            ErrorMessage="Please enter your Address!" Style="color: Red" />
                                                    <br />
                                                     <div  id="paymentdays" runat="server" visible="false" >
                                                        <label>
                                                            Payment Days</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtpaymentdays" MaxLength="30" runat="server" >0</asp:TextBox>
                                                        <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                                            FilterType="Numbers" ValidChars="" TargetControlID="txtpaymentdays" />
                                                    </div>
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
                                                    <br />
                                                        <label>E-mail</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtemail" placeholder="For Ex: test@gmail.com"
                                                            runat="server"></asp:TextBox>
                                                        <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="email" ControlToValidate="txtemail"
                                                            ErrorMessage="Please enter your Email!" Style="color: Red" />
                                                        <asp:RegularExpressionValidator runat="server" ID="RegularExpressionValidator2" ValidationGroup="val1"
                                                            ControlToValidate="txtemail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                            ErrorMessage="Please enter a correct Email Id!" Style="color: Red" />
                                                      <br />
                                                        <label>
                                                            GST NO</label>
                                                        <asp:TextBox CssClass="form-control" ID="txtgstno" placeholder="Enter GSTIN NO" runat="server"></asp:TextBox>
                                                      <%--  <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator1"
                                                            ControlToValidate="txtgstno" ErrorMessage="Please enter GST No!" Style="color: Red" />--%>
                                                <br /><br /> <br />
                                                                <asp:Button ID="btnadd" runat="server" class="btn btn-lg btn-primary pos-btn1" Text="Save" OnClick="Add_Click"
                                                                    Width="150px" ValidationGroup="val1" />
                                                         
                                                                <asp:Button ID="btnexit" runat="server" class="btn btn-lg btn-link" Text="Exit" OnClick="Exit_Click"
                                                                    Width="120px" />
                                                           
                                               </div>
                                                    </div>
                                                <div class="col-lg-6">
                                                    <div id="Ingredient" runat="server" visible="false" class="form-group">
                                                        <label>
                                                            Select Ingredient</label>
                                                            <div class="col-lg-4">
                                                             <div class="form-group has-feedback">
                                                        <asp:TextBox onkeyup="Search_Gridview(this, 'griditem')" AutoComplete="Off" CssClass="form-control"
                                                            Enabled="true" ID="txtsearch" runat="server" placeholder="Search Item Text"></asp:TextBox>
                                                             <span class="glyphicon glyphicon-search form-control-feedback"></span>
                                                            </div></div>
                                                        <div class="table-responsive panel-grid-left">
                                                            <asp:GridView ID="griditem" runat="server" AutoGenerateColumns="false" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0" Width="100%">
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
                
            </form>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
