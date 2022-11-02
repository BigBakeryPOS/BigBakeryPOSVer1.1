<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="itempage.aspx.cs" Inherits="Billing.Accountsbootstrap.itempage" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
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
        p.uppercase
        {
            text-transform: uppercase;
        }
        
        p.lowercase
        {
            text-transform: lowercase;
        }
        
        p.capitalize
        {
            text-transform: capitalize;
        }
    </style>
    <style type="text/css">
         blink, .blink {
            animation: blinker 3s linear infinite;
        }

       @keyframes blinker {  
            50% { opacity: 0; }
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
        
            <div class="panel panel-default">
<%--            <blink> <label  style="color:Green; font-size:12px">Please Fill Item Name and Relevant Information. Note: Please Enter Rate Without Tax Because it's Tax Inclusive </label></blink>--%>
                <div class="panel-heading " style="background-color: #428bca; color: White">
                    <b>Item Create Form</b>     </div>
                <div class="panel-body">
                    <asp:ScriptManager ID="sc" runat="server">
                    </asp:ScriptManager>
                    <div class="col-lg-4" style="display:none">
                      
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
                      
                        <div class="form-group" style="display:none">
                            <label>
                                Select Sub Category(MultiSelect)
                            </label>
                       
                                <asp:TextBox ID="TextBox1" runat="server" onkeyup="SearchEmployees(this,'#chksubcategory');"
                                    CssClass="form-control"></asp:TextBox>
                             
                                    <asp:CheckBoxList ID="chksubcategory" runat="server">
                                    </asp:CheckBoxList>
                              
                       
                        </div>
                    </div>
                    <div class="col-lg-4">
                        <div class="form-group">
                            <label>
                                Select Category</label>
                            <asp:Label ID="lblitemid" runat="server" Visible="false"></asp:Label>
                            <asp:DropDownList runat="server" ID="ddlcategory" class="form-control" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                            <%-- <p class="help-block">Select Your Category</p>--%>
                        </div>
                        <div class="form-group">
                            <div>
                                <p class="help-block">
                                    <b>Category Code</b></p>
                                <asp:TextBox CssClass="form-control" ID="txtcatdescription" runat="server"
                                    MaxLength="150" Style="text-transform: capitalize" Enabled="false"></asp:TextBox>
                                <label>
                                    Item Name</label>
                                <asp:TextBox CssClass="form-control" ID="txtdescription" runat="server" MaxLength="150"
                                    Style="text-transform: capitalize;"></asp:TextBox>
                            </div>
                            <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                        </div>
                        <div class="form-group">
                            <label>
                                Print Item Name
                            </label>
                            <asp:TextBox CssClass="form-control" ID="txtprintitemname" runat="server" MaxLength="150"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                Serial No
                            </label>
                            <asp:TextBox CssClass="form-control" ID="txtSerial" runat="server" MaxLength="150"></asp:TextBox>
                        </div>
                         <div class="form-group">
                            <label>
                                HSN Code
                            </label>
                            <asp:TextBox CssClass="form-control" ID="txtHSNCode" runat="server" MaxLength="150"></asp:TextBox>
                        </div>

                           <div class="form-group">
                            <label>
                                MRP Price
                            </label>
                            <asp:TextBox CssClass="form-control" ID="txtMRPPrice" AutoPostBack="true" OnTextChanged="MRPPrice_OnTextChanged" runat="server" MaxLength="150"></asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="txtSerialNo" runat="server" Visible="false"
                                MaxLength="150">0</asp:TextBox>
                        </div>
                        <div class="form-group">
                            <asp:TextBox CssClass="form-control" ID="txtSize" runat="server" Visible="false"
                                MaxLength="150">0</asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                Tax
                            </label>
                            <asp:DropDownList CssClass="form-control" ID="ddltax" AutoPostBack="true" OnTextChanged="MRPPrice_OnTextChanged" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>
                                Rate *(Exclusive of Tax)
                            </label>
                            <asp:TextBox ID="txtRate" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
                        </div>
                        
                        <div class="form-group" id="purchase" runat="server" visible="false">
                            <label>
                                Expiry Date Required</label>
                            <asp:CheckBox ID="chkPurchsse" runat="server" />
                        </div>
                        <%--<button type="submit" class="btn btn-success" onclick="Add_Click">Add</button>--%>
                    </div>
              
                    <div class="col-lg-4">
                    <div class="form-group">
                            <label>
                                UOM
                            </label>
                            <asp:DropDownList ID="ddluom" runat="server" CssClass="form-control">
                            </asp:DropDownList>
                        </div>
                        <div class="form-group">
                            <label>
                                Minimum Stock Alert
                            </label>
                            <asp:TextBox CssClass="form-control" ID="txtminumumstock" runat="server" MaxLength="150">0</asp:TextBox>
                        </div>
                        <div class="form-group">
                            <label>
                                Display Online
                            </label>
                            <asp:RadioButtonList ID="raddisplay" runat="server">
                                <asp:ListItem Text="Yes" Value="Y" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="No" Value="N"></asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                        <div>
                            <label>
                                Image Upload</label>
                            <asp:UpdatePanel ID="UpdatePanel" runat="server">
                                <ContentTemplate>
                                    <asp:FileUpload ID="fp_Upload" runat="server" />
                                    <asp:Button ID="btnUpload123" runat="server" Text="Upload" CssClass="btn btn-primary"
                                        OnClick="btnUpload_Clickimg" Width="100px" /><asp:Image ID="img_Photo" runat="server"
                                            Width="5pc" BorderColor="1" />
                                    <asp:Label ID="lblFile_Path" runat="server" Visible="false"></asp:Label>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:PostBackTrigger ControlID="btnUpload123" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <br />
                        </div>
                         <div class="form-group">
                            <label>
                                Food type
                            </label>
                            <asp:DropDownList ID="drpfoodtype" runat="server" CssClass="form-control" >
                            <asp:ListItem Text="VEG" Value="VEG" ></asp:ListItem>
                            <asp:ListItem Text="NON-VEG" Value="NON-VEG" ></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                         <div class="form-group">
                            <label>
                                Bar Code
                            </label>
                            <asp:TextBox CssClass="form-control" ID="txtBarcode" runat="server"></asp:TextBox>
                        </div>

                         <div class="form-group">
                            <label>
                                Description
                            </label>
                            <asp:TextBox CssClass="form-control" ID="txtDetails" TextMode="MultiLine" runat="server"></asp:TextBox>
                        </div>
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
                            </asp:GridView>
                        </div>
                        <div align="center">
                            <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Save" OnClick="btnadd_Click" />
                            <asp:Button ID="btnexit" runat="server" class="btn  btn-warning" Text="Exit" OnClick="btnexit_Click" />
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
