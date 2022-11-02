<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemUpdateScreen.aspx.cs" Inherits="Billing.Accountsbootstrap.ItemUpdateScreen" %>

<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="en">
<head>
    <meta content="" charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />
    <meta name="description" content="" />
    <meta name="author" content="" />
    <title>Quick Item </title>
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Styles/style1.css" rel="stylesheet" />
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
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

background-color:White;

}

.RowAlternateStyleBackGroundColor

{

background-color:White;

}

.HighLightRowColor

{

background-color:Orange;
font-weight:bold;
font-size:xx-large;
color:White;

}
        </style>
</head>
<body style="">
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <usc:Header ID="Header" runat="server" />
    <br />
    <div class="col-lg-12">
        <div class="panel panel-primary">
            <div class="panel-heading" style="text-align: center; font-size: large">
                Item Update
            </div>
            <div class="panel-body" style="">
                <div class="row" style="">
                    <div style="">
                        <form runat="server" id="form1" method="post">
                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <div class="col-lg-12">
                            <div class="col-lg-3">
                                <label>
                                    Select Category</label>
                                <asp:DropDownList ID="ddlcategory" CssClass="form-control" OnSelectedIndexChanged="catergory_changed"
                                    AutoPostBack="true" runat="server" Style="width: 273px;">
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-3">
                                <label>
                                    Is Active</label>
                                <asp:DropDownList ID="drpisactive" OnSelectedIndexChanged="active_indexchnaged" AutoPostBack="true" CssClass="form-control" runat="server" Style="width: 273px;">
                                    <asp:ListItem Text="Active" Value="0"  Selected="True"></asp:ListItem>
                                    <asp:ListItem Text="IsActive" Value="1"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div class="col-lg-3">
                                <label>
                                    Overall Search only on Item </label>
                                <asp:TextBox ID="txtoverallitem" runat="server" CssClass="form-control" OnTextChanged="overall_itemsearch" AutoPostBack="true" ></asp:TextBox>
                            </div>
                        </div>
                        <br />
                        <br />
                        <div class="col-lg-12">
                            <div class="col-lg-1">
                            </div>
                            <div class="col-lg-12">
                            <asp:UpdatePanel ID="updpanel" runat="server" UpdateMode="Conditional" >
                            <ContentTemplate>
                                <asp:GridView ID="gvproatkDetails" runat="server" OnRowDataBound="gvcustomerorder_RowDataBound" AutoGenerateColumns="false" CssClass="mGrid"
                                    Width="100%" EmptyDataText="No Record Found">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Item Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblitemname" runat="server" Text='<%# Eval("definition")%>' CssClass="form-control"></asp:Label>
                                                <asp:TextBox ID="txtitemname" onBlur="ResetColor()" onFocus="ChangeColor()" runat="server" Text='<%# Eval("definition")%>' CssClass="form-control"></asp:TextBox>
                                                <asp:Label ID="lblitemid" Visible="false" Text='<%# Eval("itemid")%>' runat="server" CssClass="form-control"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Print Item Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblprintitemname" runat="server" Text='<%# Eval("printitem")%>' CssClass="form-control"></asp:Label>
                                                <asp:TextBox ID="txtprintitemname" onBlur="ResetColor()" onFocus="ChangeColor()" runat="server" Text='<%# Eval("printitem")%>' CssClass="form-control"></asp:TextBox>
                                                
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:BoundField DataField="serial" HeaderText="Serial No" />
                                        <asp:TemplateField HeaderText="Tax">
                                            <ItemTemplate>
                                                <asp:Label ID="lbltax" runat="server" Text='<%# Eval("tax")%>' CssClass="form-control"></asp:Label>
                                                <asp:Label ID="lbltaxid" runat="server" Text='<%# Eval("taxval")%>' Visible="false" ></asp:Label>
                                                <asp:DropDownList CssClass="form-control" ID="ddltax" runat="server">
                                                  
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblrate" runat="server" Text='<%# Eval("Rate")%>' CssClass="form-control"></asp:Label>
                                                <asp:TextBox ID="txtrate" onBlur="ResetColor()" onFocus="ChangeColor()" runat="server" Text='<%# Eval("Rate")%>' CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="HSN Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblHSNcode" runat="server" Text='<%# Eval("HSNcode")%>' CssClass="form-control"></asp:Label>
                                                <asp:TextBox ID="txtHSNcode" onBlur="ResetColor()" onFocus="ChangeColor()" runat="server" Text='<%# Eval("HSNcode")%>' CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="UOM">
                                            <ItemTemplate>
                                                <asp:Label ID="lbluom" runat="server" Text='<%# Eval("name")%>' CssClass="form-control"></asp:Label>
                                                <asp:Label ID="lbluomid" runat="server" Text='<%# Eval("unit")%>' Visible="false"></asp:Label>
                                                <asp:DropDownList ID="drpuom" runat="server" CssClass="form-control" ></asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Is Active">
                                            <ItemTemplate>
                                                <asp:Label ID="lblisactive" runat="server" Text='<%# Eval("IsActive")%>' CssClass="form-control"></asp:Label>
                                                <asp:DropDownList ID="drpisactive" runat="server" CssClass="form-control" >
                                                <asp:ListItem Value="0" Text="Active" ></asp:ListItem>
                                                <asp:ListItem Value="1" Text="In-Active" ></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Display Online">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDisplayOnline" runat="server" Text='<%# Eval("DisplayOnline")%>' CssClass="form-control"></asp:Label>
                                                <asp:DropDownList ID="drpdispalyonline" runat="server" CssClass="form-control" >
                                                <asp:ListItem Value="Y" Text="Yes" ></asp:ListItem>
                                                <asp:ListItem Value="N" Text="No" ></asp:ListItem>
                                                </asp:DropDownList>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        
                                        <asp:TemplateField>
                                        <ItemTemplate>
                                        <asp:Button ID="btnupdate" runat="server" Text="Update" OnClick="btnupdate_click" />
                                        </ItemTemplate>
                                        </asp:TemplateField>

                                    </Columns>
                                    <RowStyle CssClass="RowStyleBackGroundColor" ForeColor="Black" />
 <AlternatingRowStyle CssClass="RowAlternateStyleBackGroundColor" />
                                </asp:GridView>
                                </ContentTemplate>
                                </asp:UpdatePanel>
                            </div>
                            <div class="col-lg-1">
                            </div>
                        </div>
                      
                        </form>
                    </div>
                    <!-- /.col-lg-6 (nested) -->
                </div>
                <!-- /.row (nested) -->
            </div>
            <!-- /.panel-body -->
        </div>
    </div>
</body>
</html>
