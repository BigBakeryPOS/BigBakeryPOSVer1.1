<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MinQty.aspx.cs" Inherits="Billing.Accountsbootstrap.MinQty" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta content="" charset="utf-8"/>
    <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <link href="css/mGrid.css" rel="stylesheet" type="text/css" />
    <title>set Qty  </title>
    <link rel="Stylesheet" type="text/css" href="../Styles/AjaxPopUp.css" />
    <script language="javascript" type="text/javascript" src="../js/Validation.js"></script>
    
    
    
    <link href="../Styles/chosen.css" rel="Stylesheet" />
    <!-- Bootstrap Core CSS -->
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
      <link href="../Styles/style1.css" rel="stylesheet"/>
    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
    <script type="text/javascript">
        function printGrid() {
            var gridData = document.getElementById("tbl");
            var windowUrl = 'about:blank';
            //set print document name for gridview
            var uniqueName = new Date();
            var windowName = 'Print_' + uniqueName.getTime();

            var prtWindow = window.open(windowUrl, windowName,
        'left=100,top=100,right=100,bottom=100,width=700,height=500');

            prtWindow.document.write('<html><head></head>');
            prtWindow.document.write('<body style="background:none !important">');
            prtWindow.document.write(gridData.outerHTML);
            prtWindow.document.write('</body></html>');

            prtWindow.document.close();
            prtWindow.focus();
            prtWindow.print();
            prtWindow.close();
        }
</script>
    </head>
<body>
    <form id="form1" runat="server">
    <usc:Header ID="Header" runat="server" />
     <asp:Label runat="server" ID="lblUser" ForeColor="White" Visible="false" CssClass="label"> </asp:Label>
    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <br />
    <div class="panel-heading " style="background-color:#428bca; color:White" ><b>Minimum Qty</b></div>
    <div class="col-lg-12" align="center">
    <div class="col-lg-4">
    <br />
    <div class="panel-heading " style="background-color:#428bca; color:White" ><b>Minimum Qty Details</b></div>
    <br />
    <asp:GridView ID="gvSet" runat="server" AutoGenerateColumns="false" onrowcommand="gv_RowCommand" CssClass="mGrid" OnRowDataBound="gvSet_OnRowDataBound">
    <Columns>
     <asp:BoundField DataField="categoryuserid" Visible="false"/>
    <asp:BoundField DataField="Category" HeaderText="Group" />
     <asp:BoundField DataField="Definition" HeaderText="Item" />
      <asp:BoundField DataField="MinQty" HeaderText="MinQty" />
       <asp:BoundField DataField="FixQty" HeaderText="Order_Qty" />
      <asp:TemplateField>
      <ItemTemplate>
      <asp:LinkButton ID="btn" runat="server" CommandName="et" CommandArgument='<%#Eval("categoryuserid") %>'><asp:Image ID="img" runat="server"  width="55px" /></asp:LinkButton>
      </ItemTemplate>
      </asp:TemplateField>
    </Columns>
    </asp:GridView>
    </div>
    <div class="col-lg-2" >
    </div>
    <div class="col-lg-4" >
    <br />
    <div class="panel-heading " style="background-color:#428bca; color:White" ><b>Minimum Qty Entry</b></div>
    <div class="form-group">
    <label >Group</label>
    <asp:DropDownList ID="ddlcategory" runat="server" CssClass="form-control" 
            onselectedindexchanged="ddlcategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
    </div>
    <div class="form-group">
    <label >Item</label>
    <asp:DropDownList ID="ddlItems" runat="server" CssClass="form-control"></asp:DropDownList>
    </div>
    <div class="form-group">
    <label >Minimun Qty</label>
   <asp:TextBox ID="txtminqty" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
    <div class="form-group">
    <label >Order Qty</label>
   <asp:TextBox ID="txtSet" runat="server" CssClass="form-control"></asp:TextBox>
    </div>
      <div class="form-group">
      <asp:Button ID="btnsave" runat="server" CssClass="btn btn-danger" Text="Save" 
              onclick="btnsave_Click" />
      
      <asp:Button ID="Button1" runat="server" CssClass="btn btn-success" Text="Cancel" onclick="Button1_Click" 
               />
    
      <asp:Button ID="Button2" runat="server" CssClass="btn btn-warning" Text="Exit" onclick="Button2_Click" 
              />
      </div>
    </div>
    
    </div>
    </form>
</body>
</html>
