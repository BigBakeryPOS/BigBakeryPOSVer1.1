<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InterProdGoodReceivedNote.aspx.cs" Inherits="Billing.Accountsbootstrap.InterProdGoodReceivedNote" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head id="Head1">
    <style type="text/css">
        div.MaskedDiv
        {
            visibility: hidden;
            position: absolute;
            left: 0px;
            top: 0px;
            font-family: verdana;
            font-weight: bold;
            padding: 40px;
            z-index: 100;
            background-image: url(Mask.png); /* ieWin only stuff */
            _background-image: none;
            _filter: progid:DXImageTransform.Microsoft.AlphaImageLoader(enabled=true, sizingMethod=scale src='Mask.png');
        }
    </style>
    <script language="javascript" type="text/javascript">

        function NumberOnly() {
            var AsciiValue = event.keyCode
            if ((AsciiValue >= 48 && AsciiValue <= 57) || (AsciiValue == 8 || AsciiValue == 127))
                event.returnValue = true;
            else

                event.returnValue = false;
        }

    </script>
     <script type="text/javascript">
         function ClientSideClick(myButton) {
             // Client side validation
             if (typeof (Page_ClientValidate) == 'function') {
                 if (Page_ClientValidate() == false)
                 { return false; }
             }

             //make sure the button is not of type "submit" but "button"
             if (myButton.getAttribute('type') == 'button') {
                 // disable the button
                 myButton.disabled = true;
                 myButton.className = "btn-inactive";
                 myButton.value = "processing...";
             }
             return true;
         }
    </script>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Inter Production Goods Received</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
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
            window.open("http://localhost:57111/Accountsbootstrap/itempage.aspx?Mode=Purchase", "Popup", 'height=300,width=500,resizable=yes,modal=yes,center=yes');
        }
    </script>
    <style type="text/css">
        .Hide
        {
            display: none;
        }
    </style>
    <style type="text/css">
        .overlay
        {
            position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
            -moz-opacity: 0.8;
        }
        .GridviewDiv
        {
            font-size: 100%;
            font-family: 'Lucida Grande' , 'Lucida Sans Unicode' , Verdana, Arial, Helevetica, sans-serif;
            color: #303933;
        }
        .headerstyle
        {
            color: #FFFFFF;
            border-right-color: #abb079;
            border-bottom-color: #abb079;
            background-color: #df5015;
            padding: 0.5em 0.5em 0.5em 0.5em;
            text-align: center;
        }
    </style>
    <script type="text/javascript">
        function showProgress() {
            var updateProgress = $get("<%= UpdateProgress.ClientID %>");
            updateProgress.style.display = "block";
        }
    </script>
</head>
<body style="">
    <usc:Header ID="Header" runat="server" />
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="black" CssClass="label" Visible="false"></asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="black" CssClass="label" Visible="false"> </asp:Label>
    <form runat="server" id="form1" method="post">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <div class="row" style="">
                <div class="col-lg-12" style="">
                    <div class="panel panel-default" style="">
                        <div class="panel-body" style="">
                            <div class="row">
                                <div class="col-lg-12" style="margin-top: 0px;">
                                   
             <div class="panel panel-default" style="">
            <div class="panel-heading " style="background-color: #428bca; color: White">
                                        <b>
                                           Inter Production Goods Received Entry
                                        </b>
                                        </div>
                   
                        <asp:Button ID="btncheck" runat="server" OnClick="check_Qty" Text="Check Qty" CssClass="btn btn-info"  />
                            <table class="table table-striped table-bordered table-hover" style="">
                                <tr style="">
                                    <td style="" align="center">
                                        <table class="table table-striped table-bordered table-hover">
                                            <tr>
                                                <td style="">
                                                    <asp:GridView ID="gvPurchase" runat="server" AutoGenerateColumns="false" Width="100%" Font-Names="Calibri" >
                                                    <HeaderStyle BackColor="#428bca" BorderColor="Gray" BorderStyle="Solid" BorderWidth="1px" HorizontalAlign="Center" ForeColor="White" /> 
                                                        <Columns>
                                                            <asp:BoundField HeaderText="category" DataField="Category" />
                                                            <asp:BoundField HeaderText="Item Name" DataField="printItem" />
                                                            <asp:TemplateField ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="Hiddenfield" runat="server" Value='<%#Eval("CategoryID") %>' />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField ItemStyle-CssClass="Hide" HeaderStyle-CssClass="Hide">
                                                                <ItemTemplate>
                                                                    <asp:HiddenField ID="Hiddenfield1" runat="server" Value='<%#Eval("CategoryUserID") %>' />
                                                                    <asp:Label ID="lblitemname" runat="server" Text='<%#Eval("Item") %>' Visible="false" ></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <%--   <asp:BoundField HeaderText="Ordered Qty" DataField="OrderQty" />
                                                            <asp:BoundField HeaderText="SentQty" DataField="SentQty" />--%>
                                                            <asp:TemplateField HeaderText="Requested/Ordered Qty">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="txtOrderQty" runat="server" Text='<%#Eval("OrderQty") %>' Enabled="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Transfer/Sent Qty">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="txtSentQty" runat="server" Text='<%#Eval("SentQty") %>' Enabled="false"></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Received Qty">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtWeight"  runat="server" Text='<%#Eval("SentQty") %>' Enabled="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Damage Qty">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtdmgqty"  runat="server"  Enabled="true"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="Missing Qty">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="txtmissqty"  runat="server"  Enabled="true"></asp:TextBox>
                                                                          <asp:TextBox ID="txtfinalqty" runat="server" Visible="false"  Enabled="false"></asp:TextBox>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                              
                                                              
                                                              
                                                            <asp:BoundField HeaderText="Units" DataField="UOM" />
                                                            <%--<asp:BoundField HeaderText="Expiry Date" DataField="ExpiryDate" />--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="" colspan="2">
                                                  
                                                    <label>
                                                        Remarks</label>
                                                    <asp:TextBox ID="txtRemarks" runat="server" TextMode="MultiLine" Width="300px" Height="75px"
                                                        CssClass="form-control"></asp:TextBox>  
                                                    <label id="lblrem" runat="server" style="color: Red"><asp:Button ID="btnvalue" runat="server" CssClass="btn btn-success" Text="Receive"
                                                        OnClick="btnvalue_Click" OnClientClick="ClientSideClick(this)" UseSubmitBehavior="false" />
                                                    </label>
                                                </td>
                                               
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            <asp:Label ID="Label2" runat="server" Style="color: Red"></asp:Label>
                            </td> </tr> </tbody>
                        
                    </div>
                    </div>
                    </div>
                     </div>
                     </div>
                    <!-- /.col-lg-6 (nested) -->
                </div>
                <!-- /.row (nested) -->
            </div>
            <!-- /.panel-body -->
            </div>
            <!-- /.panel -->
            </div> </div>
            <!-- /.col-lg-12 -->
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="overlay">
                <div style="z-index: 1000; margin-left: 350px; margin-top: 200px; opacity: 1; -moz-opacity: 1;">
                    <img alt="" src="../images/Preloader_10.gif" />
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
    </form>
</body>
</html>

