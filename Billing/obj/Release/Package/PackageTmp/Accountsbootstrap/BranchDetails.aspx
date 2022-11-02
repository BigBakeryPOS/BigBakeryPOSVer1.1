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
    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <style type="text/css"> 
         blink, .blink {
            animation: blinker 1s linear infinite;
        }

       @keyframes blinker { 
            50% { opacity: 0; }
       }
       
         .rbl input[type="radio"]
        {
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
    <div class="row" style="margin-top: 0px">
        <div class="col-lg-12">
            <h1 class="page-header">
            </h1>
        </div>
    </div>
    <form id="Form1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
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
                                        <blink> <label  style="color:Green; font-size:12px">Please Fill Branch Details  </label></blink>
                                        <div class="panel-heading" style="background-color: #0071BD; color: White; text-align: left">
                                            Branch Master
                                        </div>
                                        <div class="panel-body">
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>
                                                        Branch Type</label>
                                                    <asp:DropDownList ID="drpbranchtype" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="Own Branch" Value="O"></asp:ListItem>
                                                        <asp:ListItem Text="Franchise Branch" Value="F"></asp:ListItem>
                                                        <asp:ListItem Text="Own/Franchise Branch" Value="F/O"></asp:ListItem>
                                                        <asp:ListItem Text="Production" Value="P"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Production Type</label>
                                                    <asp:DropDownList ID="drpproductiontype" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                                        <asp:ListItem Text="Production" Value="P"></asp:ListItem>
                                                        <asp:ListItem Text="Icing" Value="I"></asp:ListItem>
                                                        <asp:ListItem Text="Nil" Value="Nil"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Branch Name</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtbranchname" MaxLength="50" runat="server"
                                                        Style="text-transform: capitalize"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Franchise Name</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtFranchisename" MaxLength="50" runat="server"
                                                        Style="text-transform: capitalize"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Contact Name</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtcustomername" MaxLength="50" runat="server"
                                                        Style="text-transform: capitalize"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Mobile No</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtmobileno" MaxLength="10" Placeholder=""
                                                        runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Land Line No</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtphoneno" MaxLength="15" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>
                                                        Country</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtcountry" MaxLength="30" runat="server"
                                                        Style="text-transform: capitalize"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        State</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtstate" MaxLength="30" runat="server"
                                                        Style="text-transform: capitalize"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        City</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtcity" MaxLength="30" runat="server" Style="text-transform: capitalize"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Address</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtaddress" Height="34px" TextMode="MultiLine" runat="server"
                                                        Style="text-transform: capitalize"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Pincode</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtpincode" MaxLength="6" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        GSTIN
                                                    </label>
                                                    <asp:TextBox CssClass="form-control" ID="txtgstin" runat="server"></asp:TextBox>
                                                </div>
                                                <div id="Div1" runat="server" visible="true" class="form-group">
                                                    <label>
                                                        Currency
                                                    </label>
                                                    <asp:TextBox CssClass="form-control" ID="txtcurrency" runat="server"></asp:TextBox>
                                                    <asp:Label ID="lblloginid" runat="server" Visible="false"></asp:Label>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>
                                                        Branchcode
                                                    </label>
                                                    <asp:TextBox CssClass="form-control" ID="txtbranchcode" runat="server"></asp:TextBox>
                                                    <asp:TextBox ID="txtbranchid" runat="server" Visible="false"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Branch Area</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtbrancharea" MaxLength="30" runat="server"
                                                        Style="text-transform: capitalize"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        E-mail</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtemail" placeholder="For Ex: test@gmail.com"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Production E-mail</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtpemail" placeholder="For Ex: test@gmail.com"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Icing E-mail</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtiemail" placeholder="For Ex: test@gmail.com"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Other E-mail</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtoemail" placeholder="For Ex: test@gmail.com"
                                                        runat="server"></asp:TextBox>
                                                </div>
                                                  <div class="form-group">
                                                    <label>
                                                        User Name</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtUsername" runat="server"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-3">
                                                <div class="form-group">
                                                    <label>
                                                        Online Sales Enabled
                                                    </label>
                                                    <asp:DropDownList ID="drponlineenabeld" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Order Form Online Sync
                                                    </label>
                                                    <asp:DropDownList ID="drporderonlinesync" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Print Auto-Close
                                                    </label>
                                                    <asp:DropDownList ID="drpprintautoclose" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Dispatch Goods Directly
                                                    </label>
                                                    <asp:DropDownList ID="drpsdispatch" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Fssai no
                                                    </label>
                                                    <asp:TextBox CssClass="form-control" ID="txtfssaino" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label>
                                                        Online Bill From POS
                                                    </label>
                                                    <asp:DropDownList ID="drponlinepos" runat="server" CssClass="form-control">
                                                        <asp:ListItem Text="Yes" Value="Y"></asp:ListItem>
                                                        <asp:ListItem Text="No" Value="N"></asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                 <div class="form-group">
                                                    <label>
                                                        Password</label>
                                                    <asp:TextBox CssClass="form-control" ID="txtPassword" runat="server"></asp:TextBox>
                                                </div>
                                                 
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="">
                            <div class="panel-body">
                                <div class="col-lg-4">
                                    <div class="panel panel-default" style="height: 150px;">
                                        <div class="panel-heading" style="background-color: green; color: White; text-align: center">
                                            <i class="fa fa-cogs" aria-hidden="true"></i> Print Setting
                                        </div>
                                        <div class="panel-body">
                                            <label>
                                                Sales Print Options
                                            </label>
                                            <asp:RadioButtonList ID="Rdltype" CssClass="rbl" runat="server" RepeatColumns="2">
                                                <asp:ListItem Text="Option 1" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="Option 2" Value="2"></asp:ListItem>
                                            </asp:RadioButtonList>
                                            <asp:Button ID="btnSample1" runat="server" class="btn btn-success" OnClick="btnSample1_Click"
                                                Text="View Option1 Example" Width="200px" ValidationGroup="val1" />
                                            <asp:Button ID="Button2" runat="server" class=" btn btn-primary" OnClick="btnSample2_Click"
                                                Text="View Option2 Example" Width="200px" ValidationGroup="val1" />
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-4">
                                    <div class="panel panel-default" style="height: 150px;">
                                        <div class="panel-heading" style="background-color: #0071BD; color: White; text-align: center">
                                            <i class="fa fa-cogs" aria-hidden="true"></i> Stock Setting
                                        </div>
                                        <div class="panel-body">
                                            <label>
                                                Stock Options
                                            </label>
                                            <asp:RadioButtonList ID="RdlStocktype" CssClass="rbl" runat="server" RepeatColumns="2">
                                                <asp:ListItem Text="With Stock" Value="1" Selected="True"></asp:ListItem>
                                                <asp:ListItem Text="With OutStock" Value="2"></asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-lg-4">
                                    <div class="panel panel-default" style="height: 230px;">
                                        <div class="panel-heading" style="background-color: #0071BD; color: White; text-align: center">
                                            <i class="fa fa-cogs" aria-hidden="true"></i> Image Upload
                                        </div>
                                        <div class="panel-body">
                                            <label>
                                                Company Logo
                                            </label>
                                                 <div class="col-lg-4">
                                                            <asp:Image ID="img_Photo" runat="server" class="img-fluid" Height="50px" Width="50px" />
                                                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                                                <ContentTemplate>
                                                                    <label>
                                                                        Image Upload</label>
                                                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                                                    <br />
                                                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="btn btn-primary"
                                                                        OnClick="btnUpload_Clickimg"  Width="100px" />
                                                                    <asp:Label ID="lblFile_Path" runat="server" Visible="false"></asp:Label>
                                                                </ContentTemplate>
                                                                <Triggers>
                                                                    <asp:PostBackTrigger ControlID="btnUpload" />
                                                                </Triggers>
                                                            </asp:UpdatePanel>
                                                        </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="row" style="">
                            <div class="col-lg-4">
                            </div>
                            <div class="col-lg-4">
                            </div>
                            <div class="col-lg-4">
                                <asp:Label ID="lblerror" runat="server" Style="color: Red"></asp:Label>
                                <asp:Button ID="btnadd" runat="server" class="btn btn-success" Text="Save" OnClick="Add_Click"
                                    Width="150px" ValidationGroup="val1" />
                                <asp:Button ID="btnexit" runat="server" class="btn btn-warning" Text="Exit" OnClick="Exit_Click"
                                    Width="150px" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            </div> </form>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
