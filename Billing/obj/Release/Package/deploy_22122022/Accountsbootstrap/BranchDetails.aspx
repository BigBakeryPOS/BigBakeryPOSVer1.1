<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BranchDetails.aspx.cs"
    Inherits="Billing.Accountsbootstrap.BranchDetails" %>

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
    <title>Branch Grid</title>
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
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet" />
    <link href="../css/Pos_style.css" rel="stylesheet" />
    <!-- Custom Fonts -->
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

        .rbl input[type="radio"] {
            margin-left: 10px;
            margin-right: 1px;
        }
    </style>
    <script type="text/javascript">
        function shwwindow(myurl) {
            window.open(myurl, '_blank');
        }

        function shwwindow1(myurl1) {
            window.open(myurl1, '_blank');
        }
    </script>
</head>
<body style="">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" Visible="false" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="Form1" runat="server">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="row panel-custom1">
                                <div class="panel-header">
                                    <h1 class="page-header">Branch Master</h1>
                                </div>
                                <div class="panel-body">
                                    <blink>
                                        <label style="color: #007aff">Please Fill Branch Details  </label>
                                    </blink>
                                    <div class="row">
                                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                                        </asp:ScriptManager>
                                        <div class="col-lg-3">
                                            <div class="list-group">
                                                <label>
                                                    Branch Type</label>
                                                <asp:DropDownList ID="drpbranchtype" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Own Branch" Value="O"></asp:ListItem>
                                                    <asp:ListItem Text="Franchise Branch" Value="F"></asp:ListItem>
                                                    <asp:ListItem Text="Own/Franchise Branch" Value="F/O"></asp:ListItem>
                                                    <asp:ListItem Text="Production" Value="P"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <label>
                                                    Production Type</label>
                                                <asp:DropDownList ID="drpproductiontype" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                                    <asp:ListItem Text="Production" Value="P"></asp:ListItem>
                                                    <asp:ListItem Text="Icing" Value="I"></asp:ListItem>
                                                    <asp:ListItem Text="Nil" Value="Nil"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <label>
                                                    Branch Name</label>
                                                <asp:TextBox CssClass="form-control" ID="txtbranchname" MaxLength="50" runat="server"
                                                    Style="text-transform: capitalize"></asp:TextBox>
                                                <br />
                                                <label>
                                                    Franchise Name</label>
                                                <asp:TextBox CssClass="form-control" ID="txtFranchisename" MaxLength="50" runat="server"
                                                    Style="text-transform: capitalize"></asp:TextBox>
                                                <br />
                                                <label>
                                                    Contact Name</label>
                                                <asp:TextBox CssClass="form-control" ID="txtcustomername" MaxLength="50" runat="server"
                                                    Style="text-transform: capitalize"></asp:TextBox>
                                                <br />
                                                <label>
                                                    Mobile No</label>
                                                <asp:TextBox CssClass="form-control" ID="txtmobileno" MaxLength="10" Placeholder=""
                                                    runat="server"></asp:TextBox>
                                                <br />
                                                <label>
                                                    Land Line No</label>
                                                <asp:TextBox CssClass="form-control" ID="txtphoneno" MaxLength="15" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="list-group">
                                                <label>
                                                    Country</label>
                                                <asp:TextBox CssClass="form-control" ID="txtcountry" MaxLength="30" runat="server"
                                                    Style="text-transform: capitalize"></asp:TextBox>
                                                <br />
                                                <label>
                                                    State</label>
                                                <asp:TextBox CssClass="form-control" ID="txtstate" MaxLength="30" runat="server"
                                                    Style="text-transform: capitalize"></asp:TextBox>
                                                <br />
                                                <label>
                                                    City</label>
                                                <asp:TextBox CssClass="form-control" ID="txtcity" MaxLength="30" runat="server" Style="text-transform: capitalize"></asp:TextBox>
                                                <br />
                                                <label>
                                                    Address</label>
                                                <asp:TextBox CssClass="form-control" ID="txtaddress" Height="34px" TextMode="MultiLine"
                                                    runat="server" Style="text-transform: capitalize"></asp:TextBox>
                                                <br />
                                                <label>
                                                    Pincode</label>
                                                <asp:TextBox CssClass="form-control" ID="txtpincode" MaxLength="6" runat="server"></asp:TextBox>
                                                <br />
                                                <label>
                                                    GSTIN
                                                </label>
                                                <asp:TextBox CssClass="form-control" ID="txtgstin" runat="server"></asp:TextBox>
                                                <br />
                                                <div id="Div1" runat="server" visible="true" class="form-group">
                                                    <label>
                                                        Currency
                                                    </label>
                                                    <asp:TextBox CssClass="form-control" ID="txtcurrency" runat="server"></asp:TextBox>
                                                    <asp:Label ID="lblloginid" runat="server" Visible="false"></asp:Label>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="list-group">
                                                <label>
                                                    Branchcode
                                                </label>
                                                <asp:TextBox CssClass="form-control" ID="txtbranchcode" runat="server"></asp:TextBox>
                                                <asp:TextBox ID="txtbranchid" runat="server" Visible="false"></asp:TextBox>
                                                <br />
                                                <label>
                                                    Branch Area</label>
                                                <asp:TextBox CssClass="form-control" ID="txtbrancharea" MaxLength="30" runat="server"
                                                    Style="text-transform: capitalize"></asp:TextBox>
                                                <br />
                                                <label>
                                                    E-mail</label>
                                                <asp:TextBox CssClass="form-control" ID="txtemail" placeholder="For Ex: test@gmail.com"
                                                    runat="server"></asp:TextBox>
                                                <br />
                                                <div id="Div2" runat="server" visible="false">
                                                    <label>
                                                        Production E-mail</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtpemail" placeholder="For Ex: test@gmail.com"
                                                        runat="server"></asp:TextBox>
                                                    <br />
                                                    <label>
                                                        Icing E-mail</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtiemail" placeholder="For Ex: test@gmail.com"
                                                        runat="server"></asp:TextBox>
                                                    <br />
                                                    <label>
                                                        Other E-mail</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtoemail" placeholder="For Ex: test@gmail.com"
                                                        runat="server"></asp:TextBox>
                                                    <br />
                                                </div>
                                                <label>
                                                    User Name</label>
                                                <asp:TextBox CssClass="form-control" ID="txtUsername" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="list-group">
                                                <div runat="server" visible="false">
                                                    <label>
                                                        Online Sales Enabled
                                                    </label>
                                                    <asp:DropDownList ID="drponlineenabeld" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div runat="server" visible="false">
                                                    <br />
                                                    <label>
                                                        Order Form Online Sync
                                                    </label>
                                                    <asp:DropDownList ID="drporderonlinesync" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <br />
                                                </div>
                                                <div>
                                                    <label>
                                                        Print Auto-Close
                                                    </label>
                                                    <asp:DropDownList ID="drpprintautoclose" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <br />
                                                </div>
                                                <div runat="server" visible="false">
                                                    <label>
                                                        Dispatch Goods Directly
                                                    </label>
                                                    <asp:DropDownList ID="drpsdispatch" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                    </asp:DropDownList>
                                                    <br />
                                                </div>
                                                <div>
                                                    <label>
                                                        Fssai no
                                                    </label>
                                                    <asp:TextBox CssClass="form-control" ID="txtfssaino" runat="server"></asp:TextBox>
                                                    <br />
                                                </div>
                                                <div>
                                                    <label>
                                                        Online Bill From POS
                                                    </label>
                                                    <asp:DropDownList ID="drponlinepos" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <br />
                                                <label>
                                                    Password</label>
                                                <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="row panel-custom1">
                                <div class="panel-header">
                                    <h1 class="page-header">Branch Setting Details</h1>
                                </div>
                                <div class="panel-body">
                                    <blink>
                                        <label style="color: #007aff">Please Fill Branch Details  </label>
                                    </blink>
                                    <div class="row">
                                        <div class="col-lg-3">
                                            <div class="list-group">
                                                <label>
                                                    Bill Generate Code (like Big - 1)
                                                </label>
                                                <asp:TextBox ID="txtbillgenerateCode" runat="server" CssClass="form-control"></asp:TextBox>
                                                <br />
                                                <label>
                                                    Bill Generate Setting
                                                </label>
                                                <asp:DropDownList ID="drpbillsetting" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Date Bill Wise" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="Whole Bill wise" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <label>
                                                    Pos Sales Setting
                                                </label>
                                                <asp:DropDownList ID="drppossalessetting" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Script Search With Like" Value="S"></asp:ListItem>
                                                    <asp:ListItem Text="Script Search With Value" Value="S1"></asp:ListItem>
                                                    <asp:ListItem Text="Dropdown Search" Value="D"></asp:ListItem>
                                                </asp:DropDownList>
                                                 <br />
                                                <label>
                                                    POS Print bill Setting</label>
                                                <asp:DropDownList ID="drpprintbillsetting" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="1" Value="1"></asp:ListItem>
                                                    <asp:ListItem Text="2" Value="2"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="list-group">
                                                <label>
                                                    Tax Split Up Setting</label>
                                                <asp:DropDownList ID="drptaxsplitup" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <label>
                                                    Tax Type Setting</label>
                                                <asp:DropDownList ID="drptaxsetting" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Indian Tax Wise(CGST / SGST)" Value="I"></asp:ListItem>
                                                    <asp:ListItem Text="Other (VAT)" Value="O"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <label>
                                                    Make Roundoff Setting</label>
                                                <asp:DropDownList ID="drproundoffsetting" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Roundoff With Greater Than 0.50" Value="WG"></asp:ListItem>
                                                    <asp:ListItem Text="Roundoff With Equal to 0.50" Value="WE"></asp:ListItem>
                                                    <asp:ListItem Text="No Roundoff" Value="NR"></asp:ListItem>
                                                </asp:DropDownList>
                                                 <br />
                                                <label>
                                                    Order From Book No check</label>
                                                <asp:DropDownList ID="drporderbooknocheck" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:DropDownList>
                                               
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="list-group">
                                                <label>
                                                    Bill Print With Logo</label>
                                                <asp:DropDownList ID="drpprintlogo" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <label>
                                                    Rate Type Setting</label>
                                                <asp:DropDownList ID="drpratesetting" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Two Digit(0.00)" Value="0.00"></asp:ListItem>
                                                    <asp:ListItem Text="Three Digit(0.000)" Value="0.000"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <label>
                                                    Auto Qty Fill Setting in POS</label>
                                                <asp:DropDownList ID="drpautoqtysetting" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <label>
                                                    Day close Time Setting</label>
                                               <asp:DropDownList ID="ddlTimeFrom" runat="server" CssClass="form-control" ></asp:DropDownList>


                                               
                                            </div>
                                        </div>
                                        <div class="col-lg-3">
                                            <div class="list-group">
                                                <label>
                                                    Bakery Version</label>
                                                (<asp:Label ID="lblcurversion" runat="server" Font-Bold="true"></asp:Label>)
                                            <asp:DropDownList ID="drpversion" runat="server" CssClass="form-control" Enabled="false">
                                            </asp:DropDownList>
                                                <blink>
                                                    <label id="blink_msg" runat="server" visible="false" style="color: Red">Need to Update Application Version.Thank you!!!</label></blink>
                                                <br />
                                                <label>
                                                    Qty Type Setting</label>
                                                <asp:DropDownList ID="drpqtysetting" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Two Digit(0.00)" Value="0.00"></asp:ListItem>
                                                    <asp:ListItem Text="Three Digit(0.000)" Value="0.000"></asp:ListItem>
                                                </asp:DropDownList>
                                                <br />
                                                <label>
                                                    POS Attender Check</label>
                                                <asp:DropDownList ID="drpattednercheck" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                    <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="panel-header">
                                        <h1 class="page-header"></i>Print Setting</h1>
                                    </div>
                                    <div class="panel-body">
                                        <label>
                                            Sales Print Options
                                        </label>
                                        <asp:RadioButtonList ID="Rdltype" CssClass="rbl" runat="server" RepeatColumns="2">
                                            <asp:ListItem Text="Option 1" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="Option 2" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <br />
                                        <center>
                                            <asp:Button ID="btnSample1" runat="server" class="btn btn-success pos-btn1" OnClick="btnSample1_Click"
                                                Text="View Option1 Example" Width="160px" ValidationGroup="val1" />
                                            <asp:Button ID="Button2" runat="server" class=" btn btn-primary pos-btn1" OnClick="btnSample2_Click"
                                                Text="View Option2 Example" Width="160px" ValidationGroup="val1" /></center>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="panel-header">
                                        <h1 class="page-header"></i>Stock Setting</h1>
                                    </div>
                                    <div class="panel-body ">
                                        <label>
                                            Stock Options
                                        </label>
                                        <br />
                                        <asp:RadioButtonList ID="RdlStocktype" CssClass="rbl" runat="server" RepeatColumns="2">
                                            <asp:ListItem Text="With Stock" Value="1" Selected="True"></asp:ListItem>
                                            <asp:ListItem Text="With OutStock" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>
                                        <br />
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="panel-header">
                                        <h1 class="page-header"></i>Image Upload</h1>
                                    </div>
                                    <div class="panel-body">
                                        <label>
                                            Company Logo
                                        </label>
                                        <br />
                                        <asp:Image ID="img_Photo" runat="server" class="img-fluid" Height="50px" Width="50px" />
                                        <br />
                                        <br />
                                        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                            <ContentTemplate>
                                                <label>
                                                    Image Upload</label>
                                                <asp:FileUpload ID="FileUpload1" runat="server" Style="display: inline" Width="45%" />
                                                <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-primary pos-btn1"
                                                    OnClick="btnUpload_Clickimg" Width="80px" />
                                                <asp:Label ID="lblFile_Path" runat="server" Visible="false"></asp:Label>
                                            </ContentTemplate>
                                            <Triggers>
                                                <asp:PostBackTrigger ControlID="btnUpload" />
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <asp:Label ID="Label1" runat="server" Style="color: Red"></asp:Label>
                                    <asp:Button ID="btnadd" runat="server" class="btn btn-lg btn-primary pos-btn1" Text="Save"
                                        OnClick="Add_Click" Width="150px" ValidationGroup="val1" />
                                    <asp:Button ID="Button3" runat="server" class="btn btn-lg btn-link" Text="Clear"
                                        OnClick="Exit_Click" Width="150px" />
                                    <br />
                                    <br />
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
