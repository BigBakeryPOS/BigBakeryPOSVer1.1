<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Denomination.aspx.cs" Inherits="Billing.Accountsbootstrap.Denomination" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1">
    <style type="text/css" re>
        .table-striped1 > tbody > tr:nth-child(even)
        {
            background-color: #81d8d0;
        }
        .table-striped1 > tbody > tr:nth-child(odd)
        {
            background-color: #81d8d0;
        }
        /* Background Gradient for Analagous Colors */
        .gradient2
        {
            background-color: #08D0AA; /* For WebKit (Safari, Chrome, etc) */
            background: #08D0AA -webkit-gradient(linear, left top, left bottom, from(#0871D0), to(#08D0AA)) no-repeat; /* Mozilla,Firefox/Gecko */
            background: #08D0AA -moz-linear-gradient(top, #0871D0, #08D0AA) no-repeat; /* IE 5.5 - 7 */
            filter: progid:DXImageTransform.Microsoft.gradient(startColorstr=#0871D0, endColorstr=#08D0AA) no-repeat; /* IE 8 */
            -ms-filter: "progid:DXImageTransform.Microsoft.gradient(startColorstr=#0871D0, endColorstr=#0871D0)" no-repeat;
        }
    </style>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <title>Customer Sales Report</title>
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
    <script type="text/javascript">
        function alertMessage() {
            alert('Are You Sure, You want to delete This Customer!');
        }

        function switchViews(obj, imG) {
            var div = document.getElementById(obj);
            var img = document.getElementById(imG);
            if (div.style.display == "none") {
                div.style.display = "inline";


                img.src = "../images/minus.gif";

            }
            else {
                div.style.display = "none";
                img.src = "../images/plus.gif";

            }
        }
    </script>
    <script type="text/javascript" language="javascript">
        var oldRowColor;

        // this function is used to change the backgound color

        function ChangeColor() {

            var obj = window.event.srcElement;

            if (obj.tagName == "INPUT" && obj.type == "text") {

                obj = obj.parentElement.parentElement;

                oldRowColor = obj.className;

                obj.className = "HighLightRowColor";

            }

        }

        // this function is used to reset the background color 
        function ResetColor() {

            var obj = window.event.srcElement;

            if (obj.tagName == "INPUT" && obj.type == "text") {

                obj = obj.parentElement.parentElement;

                obj.className = oldRowColor;

            }

        }

    </script>
    <style type="text/css">
        .RowStyleBackGroundColor
        {
            background-color: White;
        }
        
        .RowAlternateStyleBackGroundColor
        {
            background-color: White;
        }
        
        .HighLightRowColor
        {
            background-color: #eeeeee;
            font-weight: bold;
            font-size: xx-large;
            color: White;
        }
    </style>
    <style>
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
    <form runat="server" id="form1" method="post" style="margin-top: 0px">
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label ID="chkhour" runat="server" Visible="false" Text="09"></asp:Label>
    <asp:Label ID="chkminu" runat="server" Visible="false" Text="30"></asp:Label>
        <asp:Label ID="lbldefaultcur" runat="server" Visible="false" Text="INR"></asp:Label>
    <asp:UpdatePanel ID="Updatepnel" runat="server" UpdateMode="Conditional" EnableViewState="true"
        ChildrenAsTriggers="true">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="container-fluid">
	<div class="row">
    <div class="col-lg-12">
    <div class="row panel-custom1">
        <div class="panel-header">
          <h1 class="page-header">Denomination</h1>
	    </div>
         <div class="panel-body">
            <div class="row">
               <div class="col-lg-2">
                        <label>Select Date:</label>
                        <asp:TextBox ID="date" Enabled="false" runat="server" Class="form-control"></asp:TextBox>
                        <ajaxToolkit:CalendarExtender ID="cal1" runat="server" TargetControlID="date" Format="yyyy-MM-dd">
                        </ajaxToolkit:CalendarExtender>
                        <asp:Button ID="btnSubmit" runat="server" Visible="false" Text="Submit" CssClass="btn btn-info" />
                </div>
                
                <asp:Button ID="btndayyclose" Visible="false" Text=" Day-Close " CssClass="btn btn-danger" runat="server" PostBackUrl="~/Accountsbootstrap/Closing_report.aspx" />
            </div>
            <br />
            <div class="row">
              
                    
                    <div class="col-lg-3">
                                         <label> Over-All  Denomination Table</label>
                                 <div class="table-responsive panel-grid-left">
                                <asp:GridView ID="griddenomination" Width="100%" runat="server" AutoGenerateColumns="false" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0">
                                    <Columns>
                                        <asp:BoundField DataField="Name" HeaderText="" />
                                        <asp:TemplateField HeaderText="No's">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDenominationid" Visible="false" runat="server" Text='<%#Eval("Denominationid")%>'></asp:Label>
                                                <asp:Label ID="lblname" Visible="false" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                <asp:Label ID="lblvalue" Visible="false" runat="server" Text='<%#Eval("Value")%>'></asp:Label>
                                                <asp:TextBox ID="lblnos" Width="100%" runat="server" onBlur="ResetColor()" onFocus="ChangeColor()"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <RowStyle CssClass="RowStyleBackGroundColor" ForeColor="Black" />
                                    <AlternatingRowStyle CssClass="RowAlternateStyleBackGroundColor" />
                                </asp:GridView>
                                 </div>
                                        <div>
                                        <asp:Button ID="Button1" runat="server" Visible="false" Text=" " Enabled="false" CssClass="btn btn-info pos-btn1"
                                            OnClick="Button1_Click" />
                                  
                                        <asp:Label ID="lblErr" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                   
                                        <asp:Button ID="btncalc" runat="server" Text="Calculate" CssClass="btn btn-info pos-btn1"
                                            OnClick="getoverallcalculation" TabIndex="11" />
                                    </div>
                               
                            <div>
                                <label>
                                    Total Amount :</label>
                                <asp:Label ID="lblgrandtotal" runat="server" Font-Bold="true"></asp:Label>
                            </div>
                             <div>
                                <label>
                                    Balance Amount :</label>
                                <asp:Label ID="lblbalanceamount"   runat="server" Font-Bold="true"></asp:Label>
                            </div>
                             
                        </div>
                         <div class="col-lg-3">
                   
                                          <label> Cash To Office</label>
                                     <div class="table-responsive panel-grid-left">
                                        <div class="col-lg-12" align="center">
                                            <label>
                                                Select Session Type</label>
                                            <asp:DropDownList ID="drpsessiontype1" runat="server" CssClass="form-control" Width="80%" >
                                            </asp:DropDownList>
                                      
                                        </div>
                                            <asp:GridView ID="gvdenominationoffice" Width="100%" runat="server" AutoGenerateColumns="false" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0">
                                                <Columns>
                                                    <asp:BoundField DataField="Name" HeaderText="" />
                                                    <asp:TemplateField HeaderText="No's">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDenominationid" Visible="false" runat="server" Text='<%#Eval("Denominationid")%>'></asp:Label>
                                                            <asp:Label ID="lblname" Visible="false" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                            <asp:Label ID="lblvalue" Visible="false" runat="server" Text='<%#Eval("Value")%>'></asp:Label>
                                                            <asp:TextBox ID="lblnos" Width="100%" runat="server" onBlur="ResetColor()" onFocus="ChangeColor()"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle CssClass="RowStyleBackGroundColor" ForeColor="Black" />
                                                <AlternatingRowStyle CssClass="RowAlternateStyleBackGroundColor" />
                                            </asp:GridView>
                                           
                                        </div>
                                         <asp:Button ID="Button3" runat="server" Visible="false" Text="Save" Enabled="true" CssClass="btn btn-info"
                                                OnClick="Button11office_Click" />
                                            <asp:Label ID="Label1" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                            <asp:Button ID="Button5" runat="server" Text="Calculate" CssClass="btn btn-info pos-btn1"
                                                OnClick="getoverallcalculation" TabIndex="11" />
                                        <div>

                                            <label>
                                                Total Amount :</label>
                                            <asp:Label ID="lblgrandtotalDenominoffice"  runat="server"
                                                Font-Bold="true"></asp:Label>
                                        </div>
                                    
                        </div>
                    


                                            <div class="col-lg-3">
                        
                                            <label>Closing Petty Cash</label>
                                        <div class="table-responsive panel-grid-left">
                                        <div class="col-lg-12" align="center">
                                            <label>
                                                Select Session Type</label>
                                            <asp:DropDownList ID="drpsessiontype" runat="server" CssClass="form-control" Width="80%">
                                            </asp:DropDownList>
                                       </div>
                                        
                                            <asp:GridView ID="gvdenominationcloseing" Width="100%" runat="server" AutoGenerateColumns="false" cssClass="table table-striped pos-table" padding="0" spacing="0" border="0">
                                                <Columns>
                                                    <asp:BoundField DataField="Name" HeaderText="" />
                                                    <asp:TemplateField HeaderText="No's">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblDenominationid" Visible="false" runat="server" Text='<%#Eval("Denominationid")%>'></asp:Label>
                                                            <asp:Label ID="lblname" Visible="false" runat="server" Text='<%#Eval("Name")%>'></asp:Label>
                                                            <asp:Label ID="lblvalue" Visible="false" runat="server" Text='<%#Eval("Value")%>'></asp:Label>
                                                            <asp:TextBox ID="lblnos" Enabled="false" Width="100%" runat="server" onBlur="ResetColor()" onFocus="ChangeColor()"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField HeaderText="Total">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lbltotal" runat="server"></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                                <RowStyle CssClass="RowStyleBackGroundColor" ForeColor="Black" />
                                                <AlternatingRowStyle CssClass="RowAlternateStyleBackGroundColor" />
                                            </asp:GridView>
                                            
                                        </div>
                                        <asp:Button ID="Button4" runat="server" Text="Day Close" Enabled="true" CssClass="btn btn-info pos-btn1" ValidationGroup="val1"
                                                OnClick="Button1_Click" />
                                            <asp:Label ID="Label7" runat="server" ForeColor="Red" Visible="false"></asp:Label>
                                            <asp:Button ID="Button2" runat="server" Text="Calculate" Visible="false" CssClass="btn btn-info pos-btn1"
                                                OnClick="btncalcc_Click" TabIndex="11" />
                                        <div>
                                            <label>
                                                Total Amount :</label>
                                            <asp:Label ID="lblgrandtotalDenomin" runat="server"
                                                Font-Bold="true"></asp:Label>
                                        </div>
                                   
                        </div>
                  
                    <div class="col-lg-3">
                    <div  runat="server" >
                    <label>Over All Card Amount</label>
                    <asp:TextBox ID="txtoverallcard" runat="server" CssClass="form-control" ></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server"
                                            FilterType="Numbers,Custom" ValidChars="." TargetControlID="txtoverallcard" />
                                            <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="phono" ControlToValidate="txtoverallcard"
                                                    ErrorMessage="Please enter your Card Amount!" Style="color: Red" />
                    </div>
                    <div id="Div1"  runat="server" >
                    <label>Over All Acc.Tans. Amount</label>
                    <asp:TextBox ID="txtoverallpaytm" runat="server" CssClass="form-control" ></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender1" runat="server"
                                            FilterType="Numbers,Custom" ValidChars="." TargetControlID="txtoverallpaytm" />
                                            <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator1" ControlToValidate="txtoverallpaytm"
                                                    ErrorMessage="Please enter your Paytm Amount!" Style="color: Red" />
                    </div>
                      <div id="Div3"  runat="server" >
                    <label>Over All PhonePe Amount</label>
                    <asp:TextBox ID="txtoverallphonepe" runat="server" CssClass="form-control" ></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender4" runat="server"
                                            FilterType="Numbers,Custom" ValidChars="." TargetControlID="txtoverallphonepe" />
                                            <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator3" ControlToValidate="txtoverallphonepe"
                                                    ErrorMessage="Please enter your Paytm Amount!" Style="color: Red" />
                    </div>
                    <div id="Div2"  runat="server" >
                    <label>Over All Credit Amount</label>
                    <asp:TextBox ID="txtcreditamount" runat="server" CssClass="form-control" ></asp:TextBox>
                    <ajaxToolkit:FilteredTextBoxExtender ID="FilteredTextBoxExtender2" runat="server"
                                            FilterType="Numbers,Custom" ValidChars="." TargetControlID="txtcreditamount" />
                                            <asp:RequiredFieldValidator runat="server" ValidationGroup="val1" ID="RequiredFieldValidator2" ControlToValidate="txtcreditamount"
                                                    ErrorMessage="Please enter your Credit Amount!" Style="color: Red" />
                    </div>
                    </div>
                   
                   </div> 
            </div>
            </div>
            </div>
            </div>
           </div>
          
        </ContentTemplate>
        <Triggers>
        </Triggers>
    </asp:UpdatePanel>
    </form>
</body>
</html>
