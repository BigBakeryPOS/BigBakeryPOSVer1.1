<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Amount.aspx.cs" Inherits="Billing.Accountsbootstrap.Amount" %>
<%@ Register TagPrefix="usc" TagName="Header" Src="~/HeaderMaster/Header.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head >
 <meta http-equiv="X-UA-Compatible" content="IE=edge"/>
    <meta name="viewport" content="width=device-width, initial-scale=1"/>
    <meta name="description" content=""/>
    <meta name="author" content=""/>
    <title></title>
      <link href="../css/bootstrap.min.css" rel="stylesheet"/>

    <!-- MetisMenu CSS -->
    <link href="../css/plugins/metisMenu/metisMenu.min.css" rel="stylesheet"/>

    <!-- Custom CSS -->
    <link href="../css/sb-admin-2.css" rel="stylesheet"/>

    <!-- Custom Fonts -->
    <link href="../font-awesome-4.1.0/css/font-awesome.min.css" rel="stylesheet" type="text/css"/>
    <script type="text/javascript">
        function Denomination() {


            var gridData = document.getElementById('<%= Print.ClientID %>');


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
    <script type="text/javascript">
        function check() {

            var check = document.getElementById("ddlopt").value;
            var amt = document.getElementById("txtamt").value;

            if (check == "Select") {
                alert("Select an Option");
                return;
            }
            else if (amt == "") {
                alert("Enter Amount");
                return;
            }
            
                
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <usc:Header ID="Header" runat="server" />

 <asp:Label runat="server" ID="lblWelcome" ForeColor="White" CssClass="label" >Welcome : </asp:Label>
                    <asp:Label runat="server" ID="lblUser" ForeColor="White" CssClass="label"> </asp:Label>
                    <asp:Label runat="server" ID="lblUserID" ForeColor="White" CssClass="label" Visible="false"> </asp:Label>
    <div class="panel-danger">
    <div class="row">
    <div class="col-lg-6">
    <div class="col-lg-3">
    <b>Customer Name</b>
    <asp:Label ID="custname" runat="server"></asp:Label>
    </div>
    <div class="col-lg-3">
    <b>Order No</b>
    <asp:Label ID="lblBokno" runat="server"></asp:Label>
    </div>

    </div>
    </div>
    
    <div class="row">
    <div class="col-lg-12">
    <div class="col-lg-3">
    <b>Option</b>
    <asp:DropDownList ID="ddlopt" runat="server" CssClass="form-control" Width="150px">
    <asp:ListItem Text="Select"></asp:ListItem>
    <asp:ListItem Text="Add +" > </asp:ListItem>
    <asp:ListItem Text="Less -"></asp:ListItem>
    </asp:DropDownList>
    </div>
    <div class="col-lg-3">
    <b>Amount</b>
    <asp:TextBox ID="txtamt" runat="server" CssClass="form-control" Width="150px" placeholder="Enter Amount"></asp:TextBox>
    </div>
     <div class="col-lg-3">
    <b>Pay Mode</b>
    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control" Width="150px">
    <asp:ListItem Text="Select"></asp:ListItem>
    <asp:ListItem Text="Cash" Value="1"></asp:ListItem>
    <asp:ListItem Text="Card" Value="4"></asp:ListItem>
    </asp:DropDownList>
    </div>
    <div class="col-lg-2">
    <asp:Button ID="btnsave" Text="save" runat="server" 
            CssClass="btn btn-danger btn-lg " OnClientClick=" return check();" 
            onclick="btnsave_Click" />
    </div>

    </div>
    </div>
    <div class="row" runat="server" id="Print"  visible="false" >
    <table >
    <tr>
    <td align="center">
     <asp:Label ID="l2" runat="server" style="font-weight:bolder;font-size:x-large">Receipt</asp:Label><br />
     
     
    </td>
    </tr>
    <tr>
    <td>
    <img      src="../images/blackforestlogo.png" />
    <br />
                                   <asp:Label ID="lblstore" runat="server" 
                                       style="font-weight:bold;font-size:x-large"></asp:Label>
                                   <br />
                                   <asp:Label ID="lblAddres" runat="server" style="font-size:small"></asp:Label>
    </td>
    </tr>
    <tr>
    <td>Receipt No
    <label id="Receiptno" runat="server"></label>
    </td>
    <td>
    Date
    <label id="lblDate" runat="server"></label>
    </td>
    
    </tr>
    <tr>
    <td>
    Name
    <asp:Label ID="lblName" runat="server"></asp:Label>
    </td><td>
     Order no
    <asp:Label ID="lblord" runat="server"></asp:Label>
    </td>
    </tr>

    <tr>
    <td>
    <b>Sum of Amount Rs-  <label id="lblrupees" runat="server" > </label>    </b>
    </td>
    <td>
    <label id="reson" runat="server"></label> &nbsp as
    </td>
    <td>
    <label id="paymode" runat="server"></label> 
    </td>
    </tr>
    </table>
    </div>
    
    </div>
    </form>
</body>
</html>
