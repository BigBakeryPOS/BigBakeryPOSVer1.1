<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Invoice.aspx.cs" Inherits="Billing.Accountsbootstrap.Invoice" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    
 <meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title>Home</title>
    <link rel="Stylesheet" type="text/css" href="../css/date.css" />
   <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../Styles/style1.css" rel="stylesheet"/>
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    <style type="text/css" xml:space="preserve" class="blink"> text-decoration: blink; </style>
    <style type="text/css">
    .blinkytext
    {
     text-decoration: blink;
    }
</style>

<script type="text/javascript">
<!--
    var g_blinkTime = 100;
    var g_blinkCounter = 0;


    function blinkElement(elementId) {
        if ((g_blinkCounter % 2) == 0) {
            document.getElementById(elementId).style.visibility = 'visible';
        }
        else {
            document.getElementById(elementId).style.visibility = 'hidden';
        }


        if (g_blinkCounter < 1) {
            g_blinkCounter++;
        }
        else {
            g_blinkCounter--
        }


        window.setTimeout('blinkElement(\"' + elementId + '\")', g_blinkTime);
    }
// -->
</script>

<style type="text/css">
.blink
{
 
text-decoration:blink
}
</style>
</head>
<body> 

 
    <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <form id="form1" runat="server">
    <div class="row">
    <div class="panel panel-default">
    
    <div class="panel-body">
    
   <div class="table-responsive">
    <table class="table table-bordered table-striped">
    <tr>
    <td>
    <label>Bill NO </label>
    <asp:TextBox ID="txtBillno" runat="server" Width="150px" CssClass="form-control"></asp:TextBox>
   
    <label>Bill Date </label>
    <asp:TextBox ID="txtDate" runat="server" Width="150px" CssClass="form-control" 
            ontextchanged="txtDate_TextChanged"></asp:TextBox>

           
    </td>
    </tr>
    <tr>
    <td>
      <asp:GridView ID="gvOrder" runat="server"  Width="100px"
                                         CssClass="myGridStyle" AutoGenerateColumns="false" 
            ondatabound="gvOrder_DataBound" onrowdatabound="gvOrder_RowDataBound" 
            onrowdeleted="gvOrder_RowDeleted" onrowdeleting="gvOrder_RowDeleting" 
                                        >
                                        <Columns>
                                        <asp:BoundField HeaderText="S.No" />
                                        <asp:TemplateField HeaderText ="Category">
                                        <ItemTemplate>
                                        <asp:DropDownList ID="ddlCategory" runat="server" AutoPostBack="true"  onselectedindexchanged="ddlCategort_SelectedIndexChanged" ></asp:DropDownList>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText ="Item">
                                        <ItemTemplate>
                                         <asp:DropDownList ID="ddlItem" runat="server" ></asp:DropDownList>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText ="Quantity">
                                        <ItemTemplate>
                                        <asp:TextBox ID="txtQty" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText ="Rate">
                                        <ItemTemplate>
                                         <asp:TextBox ID="txtRate" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText ="Amount">
                                        <ItemTemplate>
                                         <asp:TextBox ID="txtAmount" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                        </asp:TemplateField>
                                       <asp:CommandField ShowDeleteButton="true"  />
                                        </Columns>
                                         <FooterStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
   <HeaderStyle BackColor="#990100" Font-Bold="True" ForeColor="White" HorizontalAlign="Left" />
                                        </asp:GridView>

    </td>
    </tr>
    <tr>
    <td>
    <asp:Button ID="btnadd" Text="Add New Row" runat="server" onclick="btnadd_Click" />
    </td>
    </tr>
    <tr>
    <td>
    <asp:Button ID="Button1" Text="Save" runat="server" onclick="Button1_Click" />
    </td>
    </tr>
      <tr>
    <td>
    <asp:Button ID="Button2" Text="Get" runat="server" onclick="Button2_Click"  />
    </td>
    </tr>
   
    </table>
    </div>
     </div></div></div>
    </form>
</body>
</html>
