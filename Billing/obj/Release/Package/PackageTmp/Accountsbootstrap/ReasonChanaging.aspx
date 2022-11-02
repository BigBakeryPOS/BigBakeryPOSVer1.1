<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReasonChanaging.aspx.cs"
    Inherits="Billing.Accountsbootstrap.ReasonChanaging" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title></title>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
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


        function Diaplay() {
            var div = document.getElementById("div");

            if (div.style.display == "none") {
                div.style.display = "inline";




            }
            else {
                div.style.display = "none";


            }
        }
    </script>
</head>
<body>
    <usc:Header ID="Header" runat="server" />
    <form id="form1" runat="server">
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label">Welcome : </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label">Welcome: </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:ScriptManager ID="script" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upanel" runat="server" EnableViewState="true">
        <ContentTemplate>
            <div class="panel panel-body">
        <div class="panel-heading " style="background-color:#428bca; color:White" ><b>Stock Return Reason Changing</b></div>
               
                <div class="row">
                    <div class="col-lg-6">
                        <div>
                            Date
                            <asp:TextBox ID="txtDate" runat="server" CssClass="form-control"></asp:TextBox>
                            <ajaxToolkit:CalendarExtender ID="cal" runat="server" CssClass="cal_Theme1" TargetControlID="txtDate">
                            </ajaxToolkit:CalendarExtender>
                        </div>
                        <div>
                            <asp:GridView ID="gvCustsales" runat="server" AllowPaging="true" PageSize="100" CssClass="mGrid"
                                DataKeyNames="RetNo" ShowFooter="true" OnRowDataBound="gvCustsales_RowDataBound"
                                AutoGenerateColumns="false" EmptyDataText="No data found!" ShowHeaderWhenEmpty="True"
                                OnRowCommand="gvCustsales_RowCommand">
                                <Columns>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Left" ItemStyle-Width="30%" HeaderText="RetNo."
                                        HeaderStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <a href="javascript:switchViews('dv<%# Eval("RetNo") %>', 'imdiv<%# Eval("RetNo") %>');"
                                                style="text-decoration: none;">
                                                <img id="imdiv<%# Eval("RetNo") %>" alt="Show" border="0" src="../images/plus.gif" />
                                            </a>
                                            <%# Eval("RetNo")%>
                                            <div id="dv<%# Eval("RetNo") %>" style="display: none; position: relative;">
                                                <asp:GridView runat="server" ID="gvLiaLedger" CssClass="mGrid" GridLines="Both" AutoGenerateColumns="false"
                                                    DataKeyNames="TransRetId" ShowFooter="true">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Transid" Visible="false" DataField="TransRetId" />
                                                        <asp:BoundField HeaderText="Product" DataField="Definition" />
                                                        <asp:BoundField HeaderText="Qty" DataField="Quantity" />
                                                        <asp:BoundField HeaderText="Amt" DataField="Amount" DataFormatString='{0:f}' />
                                                        <asp:BoundField HeaderText="Return No" DataField="RetNo" />
                                                        <asp:BoundField HeaderText="Reason" DataField="Reason" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField HeaderText="Ret No" DataField="RetNo" />
                                    <asp:BoundField HeaderText="Return Date" DataField="RetDate" />
                                    <asp:BoundField HeaderText="Reason" DataField="Reason" />
                                    <asp:TemplateField HeaderText="Change">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="link" runat="server" Text="Select" CommandName="Change" CommandArgument='<%# Eval("RetNo") %>'></asp:LinkButton>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle BackColor="#990000" />
                                <PagerSettings FirstPageText="First" LastPageText="Last" Mode="NumericFirstLast"
                                    NextPageText="Next" PreviousPageText="Previous" />
                            </asp:GridView>
                        </div>
                    </div>
                </div>
                <div id="div" runat="server" style="display:none" >
                    <div class="col-lg-7">
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>
                                    Reasons</label>
                                <asp:DropDownList ID="ddlreason" runat="server" CssClass="form-control" Width="150px" AutoPostBack="true" OnSelectedIndexChanged="drpPayment_OnSelectedIndexChanged">
                                    <%--<asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                    <asp:ListItem Text="DateBar" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Damage" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Wrong GRN" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Stock (+)(-)" Value="13"></asp:ListItem>
                                    <asp:ListItem Text="Stock Shift" Value="14"></asp:ListItem>
                                    <asp:ListItem Text="Stock Consumed" Value="15"></asp:ListItem>--%>
                                    <%-- <asp:ListItem Text="Wastage" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="DateBar" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="Excess" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="Damage" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="Wrong GRN" Value="5"></asp:ListItem>
                                    <asp:ListItem Text="Shortage" Value="6"></asp:ListItem>
                                    <asp:ListItem Text="Fungus" Value="7"></asp:ListItem>
                                    <asp:ListItem Text="Fungus Before Date" Value="8"></asp:ListItem>
                                    <asp:ListItem Text="To Production" Value="9"></asp:ListItem>
                                    <asp:ListItem Text="Return To Production(Recycle)" Value="10"></asp:ListItem>
                                    <asp:ListItem Text="To Pothys" Value="12"></asp:ListItem>--%>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3">
                            <div class="form-group">
                                <label>
                                    Sub Reasons</label>
                                <asp:DropDownList ID="ddlsubreasons" runat="server" CssClass="form-control" Width="200px">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-1">
                            <br />
                            <asp:Button ID="btnch" runat="server" Text="Change" OnClick="btnch_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
